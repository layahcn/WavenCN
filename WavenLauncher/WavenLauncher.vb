Imports System.IO
Imports System.IO.Compression  '解压文件用
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography '校验文件用
Imports System.Threading

Public Class WavenLauncher
    Const VersionWL As UInteger = 202102231  '汉化启动器版本号，跟随发布版本
    Dim NewVersionWL As String  '检测最新汉化启动器版本号
    Dim NewVersionCN As String  '检测最新游戏汉化文本版本号
    Dim NewVersionAL As String  '检测最新战网版本号
    Dim NewVersionGM As String  '检测最新游戏版本号
    Dim ZipVersionGM As String  '储存游戏硬盘版版本号
    Dim wlneedtoupdate = False  '汉化启动器是否需要更新
    Dim bFormDragging As Boolean = False    '判断窗体是否被拖动
    Dim oPointClicked As Point  '记录鼠标拖动位置
    Dim HideFormAction As Byte = 0 '设置渐隐窗口后动作
    Dim PanelVisible As Boolean = False   '设置界面默认隐藏
    Dim CloseForm As Byte = 0  '预设用户设置条目，默认叉叉关闭窗口
    Dim LocAL As Boolean = False   '默认不汉化战网
    Dim LocGM As Boolean = True   '默认汉化游戏
    Dim AutoUD As Boolean = True  '默认自动安装汉化
    Dim ALDir As String '存储战网启动路径
    Dim GMDir As String  '存储游戏启动路径
    Dim VersionAL As String  '存储战网汉化适用战网版本号
    Dim VersionGM As String  '存储游戏汉化适用游戏版本号
    Dim INTLine As Boolean = False '默认国内下载线路
    ReadOnly DownloadClient As New WebClient  '用于下载资源
    ReadOnly DefaultFileAddress As String = $"{Application.StartupPath}\WLDownload"  '默认文件下载目录
    ReadOnly tempUpdatePath As String = $"{AppDomain.CurrentDomain.BaseDirectory}WLTemp\"  '默认软件更新文件临时下载目录
    Dim GameDataPath As String  '存储游戏安装目录
    ReadOnly DefaultGameDataPath As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Ankama\zaap\waven\" '存储默认的游戏安装目录
    Dim ALDataPath As String  '存储战网安装目录
    ReadOnly DefaultALDataPath As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\Ankama\Ankama Launcher\" '存储默认的战网安装目录
    Dim DownloadFilePath As String  '正在下载文件的本地存储路径
    Dim DownloadFileName As String  '正在下载文件的名称
    ReadOnly DownloadSW As New Stopwatch '用于下载时候失去连接的超时判断
    Dim DownloadSpeed As String '显示下载速度
    Dim LocalFileSize As String '显示已下载文件大小
    ReadOnly mainAppExe As String = "WavenLauncher.exe"  '用于自爆更新的程序名
    Dim percentage As Byte = 0  '用于初始化进度条
    Dim FinishLocGM As Boolean = False  '存储游戏汉化状态
    Dim finishStartAL As Boolean = False  '存储战网经由汉化启动器启动状态
    Dim gameisrunning As Boolean = False  '存储游戏运行状态
    Dim layoutDS As String '储存下载时输出文本
    Dim waitZiptoCN As Boolean = False '汉化游戏时缺zip时下载并解压
    Dim VersionResourcePage As String '储存资源更新发布页，不再使用需审核的lofter博客
    Dim VersionResource As String '储存资源更新发布页的所有字符，以避免多次发起网络获取
    ReadOnly VersionSW As New Stopwatch '用于获取资源更新发布页时候的超时判断
    Dim enforce As Boolean = False '跳过校验强制下载
    Dim LastMsg As String '储存汉化结果的输出文本
    ReadOnly CurrentVersionPage As String = "https://launcher.cdn.ankama.com/cytrus.json" '储存官方服务器游戏版本检测页
    Dim CurrentVersion As String '储存从官方服务器检测到的游戏版本
    ReadOnly LocalJsonFile As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\zaap\repositories\production\waven\main\release.json" '存储本地游戏信息文件路径
    Dim LocalVersion As String '储存从本地缓存检测到的游戏版本
    Dim StartDLTime As Date '储存下载开始时间
    Dim ElapsedTime As String '储存下载用时
    Dim newstatusText As String '储存最新状态信息
    Dim oldstatusText As String '储存旧的状态信息
    Dim laststatusText As String '储存上一条状态信息
    Dim beforestatusText As String '储存前一条状态信息

    '用于改变开始游戏按钮文本与行为
    Private Enum StartStatus As Byte
        DownloadAL = 0  '下载战网
        StartAL = 1  '启动战网
        LocGM = 2  '汉化游戏
        Setdir = 3  '设置路径
        Quit = 4  '退出程序
        CancelDownload = 5 '取消下载
    End Enum

    ' 窗体载入时的动作
    Private Sub WavenLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            DoubleBuffered = True '使用辅助缓冲区重绘其图面，以减少或避免闪烁。
            StatusPanel.GetType.InvokeMember("DoubleBuffered",
                                              Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.SetProperty,
                                              Nothing,
                                              StatusPanel,
                                              New Object() {True})
            '绘制设置面板时开启双缓存
            SettingPanel.GetType.InvokeMember("DoubleBuffered",
                                              Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.SetProperty,
                                              Nothing,
                                              SettingPanel,
                                              New Object() {True})
            Opacity = 0  '隐式加载窗体以避免窗体背景重绘造成的控件闪烁
            If Not My.Settings.Valid Then
                My.Settings.Upgrade() '继承旧版设置
                My.Settings.Valid = True
                My.Settings.Save()
            End If
            StatusPanel.BackColor = Color.FromArgb(63, 132, 139)
            PanelProgressBar.BackColor = Color.FromArgb(63, 132, 139)
            LayoutLabel("欢迎使用Waven汉化启动器")
            Select Case My.Settings.AutoUD
                Case True, False
                    AutoUD = My.Settings.AutoUD
                    AutoUDCheck.Checked = My.Settings.AutoUD
                Case Else
                    My.Settings.AutoUD = True  '若设置不合法取默认值
            End Select '检查版本前先给当前是否自动更新汉化赋值
            WLVersionLabel.Text += $"{(VersionWL \ 100000) Mod 10}.{(VersionWL Mod 100000) _
                                     \ 1000}.{(VersionWL Mod 1000) \ 10}.{VersionWL Mod 10}"
            '获取并显示用户设置
            Select Case My.Settings.CloseForm
                Case 0, 1, 2
                    CloseForm = My.Settings.CloseForm
                    Select Case CloseForm
                        Case 0
                            CloseForm0.Checked = True
                        Case 1
                            CloseForm1.Checked = True
                        Case 2
                            CloseForm2.Checked = True
                    End Select
                Case Else
                    My.Settings.CloseForm = 0  '若设置不合法取默认值
            End Select
            Select Case My.Settings.LocAL
                Case True, False
                    LocAL = My.Settings.LocAL
                    LocALCheck.Checked = My.Settings.LocAL
                Case Else
                    My.Settings.LocAL = True  '若设置不合法取默认值
            End Select
            Select Case My.Settings.LocGM
                Case True, False
                    LocGM = My.Settings.LocGM
                    LocGameCheck.Checked = My.Settings.LocGM
                Case Else
                    My.Settings.LocGM = True  '若设置不合法取默认值
            End Select
            Select Case My.Settings.INTLine
                Case True, False
                    INTLine = My.Settings.INTLine
                Case Else
                    My.Settings.INTLine = False '若设置不合法取默认值
            End Select
            SwitchLine(False)  '根据设置的线路显示文本
            LabelDirAL.AutoEllipsis = True '保证路径文本不因空格而不显示空格之后的文本
            LabelDirGM.AutoEllipsis = True
            CheckFileExisting(My.Settings.ALDir)  '验证战网路径合法性，不合法取空值
            ALDir = My.Settings.ALDir
            If File.Exists(ALDir) Then
                ALDataPath = Path.GetDirectoryName(ALDir)  '存储战网目录
                LabelDirAL.Text = ALDir '显示战网路径
            Else
                ButtonDirAL.BackColor = Color.Red
                LabelDirGM.Enabled = False
                ButtonDirGM.Enabled = False
            End If
            CheckFileExisting(My.Settings.GMDir)  '验证游戏路径合法性，不合法取空值
            GMDir = My.Settings.GMDir
            If File.Exists(GMDir) Then
                GameDataPath = Path.GetDirectoryName(GMDir)  '存储游戏目录
                LabelDirGM.Text = GMDir '显示游戏路径
            Else
                AutoUD = False '无游戏路径则不自动安装汉化
                ButtonDirGM.BackColor = Color.Red
            End If
            '根据条件显示按钮状态
            If DownloadClient.IsBusy = True Then
                ButtonStatus(StartStatus.CancelDownload)
            Else
                If Not IO.File.Exists(ALDir) Then  '检测是否安装战网
                    ButtonStatus(StartStatus.DownloadAL)  '路径下不存在战网则按钮显示下载战网
                    LayoutLabel("请在设置里选择战网路径，若未安装请先下载")
                Else
                    If CheckProcessRunning("AL") Then '检测战网运行状态
                        If IO.File.Exists(GMDir) Then
                            If LocGM Then  '检测用户是否要汉化游戏，默认为是
                                ButtonStatus(StartStatus.LocGM)   '按钮显示汉化游戏
                            Else
                                ButtonStatus(StartStatus.Quit)  '显示退出程序
                                LayoutLabel("不汉化游戏你开我作甚！哼！")
                            End If
                        Else
                            ButtonStatus(StartStatus.Setdir)  '显示设置路径
                            LayoutLabel("请在设置里选择游戏路径，若未安装请先下载")
                        End If
                    Else
                        ButtonStatus(StartStatus.StartAL)  '战网没运行则显示启动战网
                    End If
                End If
            End If
            AddHandler DownloadClient.DownloadProgressChanged, AddressOf ShowDownProgress  '显示进度
            AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadFileCompleted  '下载完成
            ShowToolTip.SetToolTip(FormTitle, "点击访问Waven汉化启动器官网")  '左上角标题提示
            ShowToolTip.SetToolTip(ALVersionLabel, "点击强制下载或更新Ankama战网")  '战网版本号提示
            ShowToolTip.SetToolTip(GMVersionLabel, "点击强制下载或更新游戏")  '游戏版本号提示
            ShowToolTip.SetToolTip(UpdateCN, "点击强制下载并安装游戏汉化包")  '强制下载汉化提示
            ShowToolTip.SetToolTip(LocALCheck, "勾选后下次启动汉化版战网")  '勾选战网汉化提示
            ShowToolTip.SetToolTip(LocGameCheck, "勾选后开启汉化游戏功能，取消勾选点击保存则下载并恢复原版文件")  '勾选游戏汉化提示
            ShowToolTip.SetToolTip(AutoUDCheck, "勾选后每次启动本软件自动下载最新版的汉化文本并自动安装汉化")  '勾选自动安装汉化提示
            ShowToolTip.SetToolTip(LabelSwitchLine, "点击切换下载线路")  '切换下载线路提示
            ShowToolTip.SetToolTip(ButtonSwitchLine, "点击切换下载线路")  '切换下载线路提示
            ShowToolTip.SetToolTip(LabelDirAL, "选择Ankama战网路径")  '战网路径选择提示
            ShowToolTip.SetToolTip(ButtonDirAL, "选择Ankama战网路径")  '战网路径选择提示
            ShowToolTip.SetToolTip(ButtonDirGM, "选择Waven游戏路径")  '游戏路径选择提示
            Show()  '显示窗体。以下防止自爆更新后窗体未正常前台
            Focus()  '前台窗体
            WindowState = FormWindowState.Normal   '正常化窗体，避免仍处于最小化到任务栏
            Timer_ShowForm.Enabled = True  '加载完窗体再触发计时器延时显示窗体
            CheckVersion() '检查版本
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LoadForm Error")
        End Try
    End Sub

    '接受点击任务栏最小化
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_MINIMIZEBOX As Integer = &H20000
            Const WS_EX_COMPOSITED As Integer = &H2000000
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style And Not WS_EX_COMPOSITED '不挖空背景直接重绘控件
            cp.Style = cp.Style Or WS_MINIMIZEBOX
            Return cp
        End Get
    End Property

    '点击右上角退出程序叉叉
    Private Sub QuitForm_Click(sender As Object, e As EventArgs) Handles QuitForm.Click
        Try
            HideFormAction = CloseForm
            Select Case CloseForm
                Case 0
                    If DownloadClient.IsBusy = True Then
                        Close()
                    Else
                        Timer_HideForm.Enabled = True
                    End If
                Case 1
                    Timer_HideForm.Enabled = True   '最小化窗体
                Case 2
                    If DownloadClient.IsBusy = True Then
                        ToolStripMenuItem3.Text = $"正在下载{DownloadFileName}"
                        ToolStripMenuItem3.Visible = True
                    End If
                    SysTrayIcon.Visible = True  '隐藏窗体，最小化到系统托盘
                    Timer_HideForm.Enabled = True
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CloseFormButton Error")
        End Try
    End Sub

    Private Sub HideFrom()
        Select Case HideFormAction
            Case 0
                Close()
            Case 1
                WindowState = FormWindowState.Minimized
            Case 2
                Hide()
        End Select
    End Sub

    Private Sub QuitForm_MouseEnter(sender As Object, e As EventArgs) Handles QuitForm.MouseEnter
        QuitForm.ForeColor = Color.White
        QuitForm.BackColor = Color.Red
    End Sub

    Private Sub QuitForm_MouseLeave(sender As Object, e As EventArgs) Handles QuitForm.MouseLeave
        QuitForm.ForeColor = Color.Yellow
        QuitForm.BackColor = Color.Transparent
    End Sub

    '若正在下载时退出窗体则增加确认提示
    Private Sub WavenLauncher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If DownloadClient.IsBusy = True Then
            e.Cancel = True
            If MsgBox($"【注意】有文件正在下载中，{vbCrLf}是否要取消下载并退出软件？",
                          MsgBoxStyle.Exclamation _
                          + MsgBoxStyle.OkCancel _
                          + MsgBoxStyle.DefaultButton2,
                          "正在下载文件中…") _
                     = MsgBoxResult.Ok Then
                DownloadClient.CancelAsync()
                Timer_HideForm.Enabled = True
            End If
        End If
    End Sub

    Private Sub MiniForm_Click(sender As Object, e As EventArgs) Handles MiniForm.Click
        HideFormAction = 1
        Timer_HideForm.Enabled = True
    End Sub

    Private Sub MiniForm_MouseEnter(sender As Object, e As EventArgs) Handles MiniForm.MouseEnter
        MiniForm.ForeColor = Color.White
        MiniForm.BackColor = Color.Teal
    End Sub

    Private Sub MiniForm_MouseLeave(sender As Object, e As EventArgs) Handles MiniForm.MouseLeave
        MiniForm.ForeColor = Color.Yellow
        MiniForm.BackColor = Color.Transparent
    End Sub

    Private Sub MainForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        '位于窗体内鼠标按下
        bFormDragging = True
        oPointClicked = New Point(e.X, e.Y)
    End Sub

    Private Sub MainForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        '鼠标松开
        bFormDragging = False
    End Sub

    Private Sub WavenLauncher_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        bFormDragging = False '非活动窗口时释放拖动终止点判断
    End Sub

    Private Sub MainForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        '鼠标拖拽
        Try
            If bFormDragging Then
                Dim oMoveToPoint As Point
                ' 以当前鼠标位置为基础，找出目标位置
                oMoveToPoint = PointToScreen(New Point(e.X, e.Y))
                ' 根据开始位置作出调整
                oMoveToPoint.Offset(oPointClicked.X * -1, oPointClicked.Y * -1)
                ' 移动窗体
                Location = oMoveToPoint
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "MoveForm Error")
        End Try
    End Sub

    '绘制设置面板边框
    Private Sub SettingPanel_Paint(sender As Object, e As PaintEventArgs) Handles SettingPanel.Paint
        ControlPaint.DrawBorder(e.Graphics, SettingPanel.ClientRectangle,
                                Color.Yellow, 1, ButtonBorderStyle.Dashed,
                                Color.Yellow, 1, ButtonBorderStyle.Dashed,
                                Color.Yellow, 1, ButtonBorderStyle.Dashed,
                                Color.Yellow, 1, ButtonBorderStyle.Dashed)
    End Sub

    '检测软件和汉化文本的版本
    Private Sub CheckVersion()
        Try
            If UpdateCN.Text = "强制下载汉化" Then
                UpdateCN.Text = "检测更新中…"
                WLVerStatus.Text = "检测更新中…"
                LayoutLabel("正在检测更新中…线路为" & LabelSwitchLine.Text)
                Dim task_cv As New Task(AddressOf ProcessVersionResource) '异步获取更新资源页
                task_cv.Start()
                task_cv.Wait()
                VersionSW.Start()
                Timer_CheckVersion.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckVersion Error")
        End Try
    End Sub

    '每100ms检测一次是否获取到了更新资源页
    Private Sub CheckVersion_Tick(sender As Object, e As EventArgs) Handles Timer_CheckVersion.Tick
        Try
            If VersionSW.ElapsedMilliseconds < 8000 Then
                SetPanelPB(Math.Truncate(VersionSW.ElapsedMilliseconds / 100))
            End If
            If VersionSW.ElapsedMilliseconds > 10000 Then '若超过10秒则停止检测
                Timer_CheckVersion.Enabled = False
                SetPanelPB(0)
                VersionSW.Stop()
                VersionSW.Reset()
                If VersionResource = "" AndAlso CurrentVersion = "" Then
                    LayoutLabel("检测更新失败，请检查网络连接并重试")
                Else
                    If VersionResource = "" Then
                        LayoutLabel("获取资源更新发布页失败，请尝试切换下载线路")
                    Else
                        LayoutLabel("获取官方服务器游戏版本页失败，请尝试能否直连访问Ankama官网")
                    End If
                End If

                WLVerStatus.Text = "检测失败，点此重试"
                UpdateCN.Text = "强制下载汉化"
            End If
            If VersionResource <> "" AndAlso CurrentVersion <> "" Then '若获取到非空的资源页文本
                Timer_CheckVersion.Enabled = False
                SetPanelPB(100)
                VersionSW.Stop()
                VersionSW.Reset()
                NewVersionWL = GetVersion("软件版本号") '获取到最新版本号后赋值
                NewVersionCN = GetVersion("游戏汉化版本")
                NewVersionAL = GetVersion("适用战网版本", 5) '获取到最新版本号后赋值
                NewVersionGM = GetVersion("适用游戏版本", 11)
                ZipVersionGM = GetVersion("游戏硬盘版", 11)
                AfterCheckVersion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckVersionResource Error")
        End Try
    End Sub

    '准备异步获取更新资源页
    Private Async Sub ProcessVersionResource()
        Try
            Dim task_RV As Task(Of String) = GetNewGameVersion()
            CurrentVersion = Await task_RV
            Dim task_VR As Task(Of String) = HandleVersionResource(INTLine)
            VersionResource = Await task_VR
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ProcessVersionResource Error")
        End Try
    End Sub

    '处理异步获取更新资源页
    Private Async Function HandleVersionResource(ByVal line As Boolean) As Task(Of String)
        Try
            Select Case line '选择下载线路
                Case False
                    VersionResourcePage = "https://ankamacn.coding.net/p/coding-devops-guide/d/coding-devops-guide/git/raw/master/README.md?download=true"
                Case True
                    VersionResourcePage = "https://pan.layah.workers.dev/1:/README.md"
            End Select
            Dim Resource As String
            Dim request As WebRequest = WebRequest.Create(VersionResourcePage)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = Await request.GetResponseAsync()
            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Resource = Await reader.ReadToEndAsync()
            End Using
            response.Close()
            Return Resource
        Catch ex As Exception
            Return ""
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "GetVersionResource Error")
        End Try
    End Function

    Private Function GetVersion(ByVal nameCN As String, Optional ByVal length As Byte = 9)
        '获取版本号，默认位数为9位数字，时间8位+补丁1位。扩展获取游戏和战网版本号，以及校验、下载文件
        Try
            If VersionResource.Contains(nameCN) Then
                Dim tempVersionResource As String = ""
                tempVersionResource = VersionResource.Remove(0, VersionResource.IndexOf(nameCN) _
                                                                  + nameCN.Length _
                                                                  + 1)
                tempVersionResource = tempVersionResource.Substring(0, length)
                Return tempVersionResource
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '从官方服务器获取游戏的最新版本
    Private Async Function GetNewGameVersion() As Task(Of String)
        Try
            Dim CurrentVersionResource As String
            Dim request As WebRequest = WebRequest.Create(CurrentVersionPage)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = Await request.GetResponseAsync()
            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                CurrentVersionResource = Await reader.ReadToEndAsync()
            End Using
            response.Close()
            Dim WavenID As String = ":22,"
            Dim tempCurrentVersion As String = CurrentVersionResource.Remove(0, CurrentVersionResource.IndexOf(WavenID) _
                                                      + WavenID.Length _
                                                      + 192)
            tempCurrentVersion = tempCurrentVersion.Substring(0, 11)
            Return tempCurrentVersion
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '根据版本改变程序信息状态
    Private Sub AfterCheckVersion()
        Try
            LayoutLabel("检测更新成功，汉化启动器已就绪")
            If Val(NewVersionWL) > VersionWL Then
                '若获取到版本号比当前软件版本号要新（如201908051>201908011
                WLVerStatus.Text = "点此更新软件"
                wlneedtoupdate = True  '设置需要更新以便点击label时为下载
                Timer_NewVersionNeon.Enabled = True  '开启红黄闪烁
                VersionAL = My.Settings.VersionAL
                ALVersionLabel.Text += VersionAL
                VersionGM = My.Settings.VersionGM
                GMVersionLabel.Text += VersionGM ' 显示软件自带版本号
            Else
                WLVerStatus.Text = ""
                VersionAL = NewVersionAL
                ALVersionLabel.Text += NewVersionAL
                VersionGM = NewVersionGM
                GMVersionLabel.Text += NewVersionGM ' 显示兼容的版本号
            End If
            ALVersionLabel.Enabled = True
            GMVersionLabel.Enabled = True
            LocALCheck.Enabled = True
            LocGameCheck.Enabled = True
            AutoUDCheck.Enabled = True
            If NewVersionCN <> "" Then
                UpdateCN.Text = $"{Val(NewVersionCN) \ 100000}.{(Val(NewVersionCN) Mod 100000) _
                                  \ 1000}.{(Val(NewVersionCN) Mod 1000) \ 10}-V{Val(NewVersionCN) Mod 10}"
                ShowToolTip.SetToolTip(UpdateCN, "这是汉化包的最新版本号，点击强制下载并安装游戏汉化包")
            End If
            If AutoUD AndAlso LocGM Then
                DFileCN("游戏汉化文件", "Waven-zh-cn.zip", DefaultFileAddress)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AfterCheakVersion Error")
        End Try
    End Sub

    '强制下载汉化
    Private Sub UpdateCN_Click(sender As Object, e As EventArgs) Handles UpdateCN.Click
        If UpdateCN.Text <> "检测更新中…" Then
            OpenOrSaveSetting(False)
            enforce = True
            If INTLine Then
                DownloadFile("https://pan.layah.workers.dev/0:/Waven/Waven-zh-cn.zip",
                             "Waven-zh-cn.zip",
                             DefaultFileAddress)
            Else
                DownloadFile("https://ankamacn.coding.net/api/share/download/17cc82d7-9242-4712-9c33-5abc7e5da842",
                             "Waven-zh-cn.zip",
                             DefaultFileAddress)
            End If
        End If
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        ' 根据按钮状态执行不同过程
        If StartButton.Text = "退出软件" Then
            HideFormAction = 0
            Timer_HideForm.Enabled = True
        Else
            ButtonAction(False)      '更改按钮状态
            If VersionSW.IsRunning Then '若正在检测更新资源页
                LayoutLabel("正在检测更新中…暂时不能" & StartButton.Text)
                Exit Sub
            End If
            If DownloadClient.IsBusy Then '若有下载任务
                DownloadClient.CancelAsync()
                enforce = False
                Timer_ShowDSpeed.Enabled = False
            Else
                ButtonAction(True)       '点击执行过程
            End If
        End If
    End Sub

    '更改按钮状态以及输出相应的提示文字
    Private Sub ButtonStatus(Status As StartStatus)
        Select Case Status
            Case StartStatus.DownloadAL
                StartButton.Text = "下载战网"
            Case StartStatus.StartAL
                StartButton.Text = "启动战网"
            Case StartStatus.LocGM
                StartButton.Text = "汉化游戏"
            Case StartStatus.Setdir
                StartButton.Text = "设置路径"
            Case StartStatus.Quit
                StartButton.Text = "退出软件"
            Case StartStatus.CancelDownload
                StartButton.Text = "取消下载"
        End Select
    End Sub

    '按钮动作，False表示只改变按钮状态
    Private Sub ButtonAction(Optional Action As Boolean = False)
        Try
            If IO.File.Exists(ALDir) Then
                '判断战网是否存在
                Try
                    If CheckProcessRunning("AL") Then  '检测战网是否运行
                        If IO.File.Exists(GMDir) Then  '检测游戏路径是否已选择
                            If LocGM Then  '检测用户是否要汉化游戏，默认要
                                If FinishLocGM Then  '若已经进行了汉化过程
                                    ButtonStatus(StartStatus.Quit)
                                    If Action Then
                                        HideFormAction = 0
                                        Timer_HideForm.Enabled = True  '此时如果再点就是退出程序了
                                    End If
                                Else  '若未进行汉化过程
                                    ButtonStatus(StartStatus.LocGM)
                                    If Action Then
                                        If File.Exists(DefaultFileAddress & "\Waven-zh-cn.zip") Then
                                            LocGame()  '则进行汉化动作
                                        Else
                                            waitZiptoCN = True
                                            DFileCN("游戏汉化文件", "Waven-zh-cn.zip", DefaultFileAddress)
                                        End If
                                    End If
                                End If
                            Else  '若不汉化游戏
                                '啥都不干那就拜拜了您内~
                                ButtonStatus(StartStatus.Quit)
                                If Action Then '执行关闭窗口
                                    HideFormAction = 0
                                    Timer_HideForm.Enabled = True
                                End If
                            End If
                        Else   '若未选择游戏路径
                            ButtonStatus(StartStatus.Setdir)
                            If Action Then
                                OpenOrSaveSetting(True)  '保持设置窗口开启让用户先选择游戏路径
                                LayoutLabel("请在设置里选择游戏路径，若未安装请先下载")
                            End If
                        End If
                    Else  '若战网未运行
                        ButtonStatus(StartStatus.StartAL)  '战网没运行则显示启动战网
                        If LocAL Then  '若需要汉化战网
                            If Action Then '点击启动战网自动汉化
                                LayoutLabel("正在启动战网，已启用战网汉化")
                                If VersionResource = "" Then
                                    finishStartAL = True
                                    Process.Start(ALDir)
                                    Thread.Sleep(1000)
                                    ButtonAction(False)  '改变按钮状态
                                Else
                                    DFileCN("战网汉化文件", "en.json", DefaultFileAddress)
                                End If
                                Exit Sub
                            End If
                        Else  '若不需要汉化战网
                            If finishStartAL Then  '若已经启动过了战网
                                If IO.File.Exists(GMDir) Then  '检测游戏路径是否已选择
                                    If LocGM Then  '检测用户是否要汉化游戏，默认要
                                        'ButtonStatus(StartStatus.LocGM)
                                        If Action Then
                                            If File.Exists(DefaultFileAddress & "\Waven-zh-cn.zip") Then
                                                LocGame()  '则进行汉化动作
                                            Else
                                                DFileCN("游戏汉化文件", "Waven-zh-cn.zip", DefaultFileAddress)
                                            End If
                                        Else
                                            ButtonStatus(StartStatus.LocGM)
                                        End If
                                    Else  '若不汉化游戏
                                        '啥都不干那就拜拜了您内~
                                        ButtonStatus(StartStatus.Quit)
                                        If Action Then '执行关闭窗口
                                            HideFormAction = 0
                                            Timer_HideForm.Enabled = True
                                        End If
                                    End If
                                Else   '若未选择游戏路径
                                    ButtonStatus(StartStatus.Setdir)
                                    If Action Then
                                        OpenOrSaveSetting(True)  '保持设置窗口开启让用户先选择游戏路径
                                        LayoutLabel("请在设置里选择游戏路径，若未安装请先下载")
                                    End If
                                End If
                            Else  '若未启动战网
                                If Action Then '则恢复启动英文版
                                    LayoutLabel("正在启动战网，未启用战网汉化")
                                    If VersionResource = "" Then
                                        finishStartAL = True
                                        Process.Start(ALDir)
                                        Thread.Sleep(1000)
                                        ButtonAction(False)  '改变按钮状态
                                    Else
                                        DFileCN("战网原版文件", "en.json", DefaultFileAddress)
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "战网启动失败")
                End Try
            Else
                If DownloadClient.IsBusy = False Then
                    ButtonStatus(StartStatus.DownloadAL)  '战网不存在则显示下载战网
                End If
                '下载战网
                If Action Then
                    DFileCN("战网安装文件", "Ankama-Launcher.zip", DefaultFileAddress)
                End If
            End If
            Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ButtonAction Error")
        End Try
    End Sub

    '点击汉化游戏按钮
    Private Sub LocGame()
        Try
            If File.Exists(GMDir) Then
                If CheckProcessRunning("GM") Then  '若游戏已运行
                    gameisrunning = True
                    LayoutLabel("游戏正在运行中，请关闭后再安装汉化")
                    ButtonAction(False)  '改变按钮状态
                    enforce = False
                    Exit Sub
                Else  '若游戏未运行
                    gameisrunning = False
                    ButtonAction(False)
                    If GetLocalJson("isDirty") = "true" Then
                        LayoutLabel($"游戏需要修复，暂时不可安装汉化")
                        enforce = False
                        Exit Sub
                    End If
                    If GetLocalJson("isInstalling") = "true" Then
                        LayoutLabel("游戏正在安装中，暂时不可安装汉化")
                        enforce = False
                        Exit Sub
                    End If
                    If GetLocalJson("isUpdating") = "true" Then
                        LayoutLabel("游戏正在更新中，暂时不可安装汉化")
                        enforce = False
                        Exit Sub
                    End If
                    If GetLocalJson("isRepairing") = "true" Then
                        LayoutLabel("游戏正在修复中，暂时不可安装汉化")
                        enforce = False
                        Exit Sub
                    End If
                    Try
                        GameDataPath = Path.GetDirectoryName(GMDir)
                        If enforce Then
                            ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                            '调用解压zip方法
                            LastMsg = "强制安装汉化成功，有任何后果概不负责【手动滑稽"
                            enforce = False
                        Else
                            If VersionResource = "" Then
                                LayoutLabel("未检测到版本信息，请检查网络连接后再安装汉化。或可尝试强制下载安装汉化")
                                Exit Sub
                            End If
                            If GetLocalJson("version", 2, 5) = "false" Or GetLocalJson("version", 2, 5) = "" Then
                                LayoutLabel("未检测到本地游戏版本，请打开战网校验游戏文件")
                                Exit Sub
                            End If
                            LocalVersion = GetLocalJson("version", 7, 11) '从本地缓存获取本地游戏版本
                            If LocalVersion <> CurrentVersion AndAlso CurrentVersion <> "" Then
                                LayoutLabel($"本地游戏版本为{LocalVersion}，请打开战网更新游戏到{CurrentVersion}版本后再安装汉化！")
                                Exit Sub
                            End If
                            Dim tempVersionCN As String
                            If UpdateCN.Text = "强制下载汉化" Then
                                Dim tempversion As String = GetVersion("游戏汉化版本")
                                Dim formatversion As String = $"{Val(tempversion) \ 100000}.{(Val(tempversion) Mod 100000) _
                                                                \ 1000}.{(Val(tempversion) Mod 1000) \ 10}-V{Val(tempversion) Mod 10}"
                                tempVersionCN = formatversion & "。PS检测最新游戏版本失败，若游戏有更新可能无法正常使用汉化"
                            Else
                                tempVersionCN = UpdateCN.Text
                            End If
                            Dim frDir As String = GameDataPath & "\Waven_Data\StreamingAssets\AssetBundles\core\localization.fr-fr"
                            If IO.File.Exists(frDir) Then
                                Dim CurrentMD5 As String = GetFileMD5(frDir)
                                Dim newCNMD5 As String = GetVersion("汉化文件哈希值", 32)
                                Dim newFRMD5 As String = GetVersion("原版文件哈希值", 32)
                                Select Case CurrentMD5
                                    Case newCNMD5 '若检测到游戏文件已经是汉化好的
                                        LastMsg = $"已安装过汉化，版本为{tempVersionCN}【游戏语言请选择法语Francais】"
                                    Case newFRMD5 '若检测到游戏文件是符合汉化目标的原版文件
                                        ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                                        '调用解压zip方法
                                        LastMsg = $"安装汉化成功，版本为{tempVersionCN}【游戏语言请选择法语Francais】"
                                    Case Else
                                        If wlneedtoupdate Then '若文件与汉化适用不一致且软件需更新则提示
                                            LayoutLabel("Waven汉化启动器过旧！请更新软件！")
                                            Exit Sub
                                        End If
                                        Dim VersionMSG As String
                                        Dim CancelMSG As String
                                        '若文件与汉化适用不一致，且软件是最新，说明游戏版本有可能先于汉化版本从而更改了文件
                                        VersionMSG = "【注意】检测到汉化目标文件【localization.fr-fr】不匹配，有可能是游戏更新了文件导致的，不推荐安装汉化。若文件损坏可使用战网修复游戏"
                                        CancelMSG = "取消安装汉化。关注Waven群等待新版补丁吧。若文件损坏可使用战网修复游戏"
                                        bFormDragging = False
                                        If MsgBox($"{VersionMSG}{vbCrLf}是否仍要尝试安装汉化？可能会无法打开游戏",
                                                           MsgBoxStyle.Exclamation _
                                                           + MsgBoxStyle.OkCancel _
                                                           + MsgBoxStyle.DefaultButton2,
                                                           "文件校验结果不一致") _
                                                           = MsgBoxResult.Ok Then
                                            ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                                            '调用解压zip方法
                                            LastMsg = "若无法打开游戏请在设置里取消勾选【启用游戏汉化】或使用战网修复游戏"
                                        Else
                                            LayoutLabel(CancelMSG)
                                            Exit Sub
                                        End If
                                End Select
                            Else
                                LayoutLabel("检测到游戏文件不完整，请修复游戏")
                                Exit Sub
                            End If
                        End If
                        LayoutLabel(LastMsg)
                        FinishLocGM = True
                        ButtonAction(False)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExtractFiles Error")
                    End Try
                End If
            Else
                LayoutLabel("未检测到游戏路径，请重新设置")
                enforce = False
                ButtonAction(False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LocGame Error")
        End Try
    End Sub

    '解压zip文件方法，覆盖替换方式，无文件夹则创建文件夹，无文件新建空文件进行替换，默认不备份
    Private Sub ExZip(ByVal ziplocation As String, ByVal zipname As String, ByVal expath As String)
        Try
            Dim zipPath As String = $"{ziplocation}\{zipname}"  'zip源文件地址
            If IO.File.Exists(zipPath) Then  '若zip文件存在才进行解压
                expath = Path.GetFullPath(expath)  '获取目录的绝对路径
                If Not expath.EndsWith(
                        Path.DirectorySeparatorChar.ToString(),
                        StringComparison.Ordinal) Then
                    expath += Path.DirectorySeparatorChar  '目录结尾添加\
                End If
                LayoutLabel($"正在解压【{zipname}】至：""{expath}""")  '输出label显示正在解压的文件
                Dim file As New FileStream(zipPath, FileMode.Open)
                Dim pathcombine As String
                Dim destinationPath As String
                Using archive As New ZipArchive(file, ZipArchiveMode.Read)  '声明资源文件
                    For Each entry As ZipArchiveEntry In archive.Entries
                        pathcombine = Path.Combine(expath, entry.FullName)
                        destinationPath = Path.GetFullPath(pathcombine)  '设置输出路径
                        If Not entry.FullName.EndsWith("/") Then  '获取所有文件，排除目录。不可用扩展名判断，因为存在无扩展名文件
                            If Not System.IO.File.Exists(destinationPath) Then  '若目标文件不存在
                                If Not Directory.Exists(Path.GetDirectoryName(destinationPath)) Then  '若目标所在文件夹不存在
                                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath))  '创建文件夹
                                End If
                                System.IO.File.Create(destinationPath).Dispose()  '创建空的目标文件，前提是目录存在
                            End If
                            If destinationPath.StartsWith(expath, StringComparison.Ordinal) Then
                                entry.ExtractToFile(destinationPath, True)  '将解压获得的文件替换目标文件
                            End If
                        End If
                    Next
                End Using
                file.Close()
                LayoutLabel($"【{zipname}】解压成功")
            Else
                LayoutLabel($"【{zipname}】解压失败：文件不存在")
            End If
        Catch ex As Exception
            MsgBox("错误信息：" & ex.Message, MsgBoxStyle.Exclamation, "解压文件失败")
        End Try
    End Sub

    '下载百分比之后的动作
    Private Sub AfterDownload()
        Try
            percentage = 0 '重置下载进度
            If DownloadFileName = mainAppExe And File.Exists($"{Application.StartupPath}\WLTemp\{DownloadFileName}") Then
                '如果是自我更新则启动自爆
                KillSelfThenRun()
            End If
            If File.Exists($"{DefaultFileAddress}\{DownloadFileName}") Then '检查下载文件是否完整存在
                SetPanelPB(100)
                PanelProgress.BackColor = Color.Yellow
                Select Case DownloadFileName
                    Case "en.json"  '如果是战网的汉化下载完成
                        Try  '替换战网汉化文件
                            Dim LocALpath = $"{Path.GetDirectoryName(ALDir)}\resources\static\langs"
                            ReplaceFile(LocALpath, "en.json")
                            finishStartAL = True
                            Process.Start(ALDir)
                            Thread.Sleep(1000)
                            ButtonAction(False)  '改变按钮状态
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "汉化战网失败")
                        End Try
                    Case "Waven-zh-cn.zip"
                        LayoutLabel($"本地游戏汉化包已是最新版【{UpdateCN.Text}】，可进行安装")
                        If File.Exists(GMDir) AndAlso (waitZiptoCN Or AutoUD) Then
                            LocGame()
                        Else
                            ButtonAction(False) '改变按钮状态
                        End If
                    Case "Waven-fr-fr.zip"
                        If CheckProcessRunning("GM") Then
                            KillProcess("Waven")
                            gameisrunning = False
                            bFormDragging = False
                            MsgBox($"【注意】恢复游戏原版文件需关闭游戏，{vbCrLf}即将卸载当前游戏汉化",
                                                                MsgBoxStyle.Exclamation _
                                                                + MsgBoxStyle.OkOnly,
                                                                "卸载当前游戏汉化")
                        End If
                        Try
                            If File.Exists(GMDir) Then
                                GameDataPath = Path.GetDirectoryName(GMDir)
                                ExZip(DefaultFileAddress, "Waven-fr-fr.zip", GameDataPath)
                                '调用解压zip方法
                                LayoutLabel("已恢复游戏原版文件")
                                ButtonAction(False)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExtractFiles Error")
                        End Try
                    Case "Ankama-Launcher.zip" '战网硬盘版
                        Try
                            Try
                                KillProcess("Ankama Launcher")
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Kill Ankama Launcher Error")
                            End Try
                            LayoutLabel("正在准备安装Ankama战网")
                            bFormDragging = False
                            '添加一步确认，以免误点
                            If MsgBox($"【注意】安装Ankama战网将会强制覆盖文件，{vbCrLf}是否要继续Ankama战网硬盘版的安装？",
                                      MsgBoxStyle.Exclamation _
                                      + MsgBoxStyle.OkCancel _
                                      + MsgBoxStyle.DefaultButton2,
                                      "Ankama战网硬盘版下载完成") _
                                 = MsgBoxResult.Ok Then
                                If File.Exists(ALDir) Then '判断当前战网是否已安装并设置过路径
                                    ExZip(DefaultFileAddress, "Ankama-Launcher.zip", Path.GetDirectoryName(ALDir))
                                Else
                                    ExZip(DefaultFileAddress, "Ankama-Launcher.zip", DefaultALDataPath)
                                    ALDir = DefaultALDataPath & "Ankama Launcher.exe"
                                    LabelDirAL.Text = ALDir
                                    ButtonDirAL.BackColor = Color.Teal
                                    LabelDirGM.Enabled = True
                                    ButtonDirGM.Enabled = True
                                End If
                                ButtonAction(False) '改变按钮状态
                            Else
                                LayoutLabel("取消安装Ankama战网")
                                ButtonAction(False) '改变按钮状态
                                Return
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "安装战网失败")
                        End Try
                    Case "Waven.zip" '游戏硬盘版
                        Try
                            Try
                                KillProcess("Ankama Launcher")
                                KillProcess("Waven")
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Kill Waven Error")
                            End Try
                            LayoutLabel("正在准备安装Waven游戏")
                            bFormDragging = False
                            '添加一步确认，以免误点
                            If MsgBox($"【注意】安装Waven游戏会强制覆盖文件，{vbCrLf}是否要继续Waven游戏硬盘版的安装？",
                                      MsgBoxStyle.Exclamation _
                                      + MsgBoxStyle.OkCancel _
                                      + MsgBoxStyle.DefaultButton2,
                                      "Waven游戏硬盘版下载完成") _
                                 = MsgBoxResult.Ok Then
                                WriteLocalJson()
                                If File.Exists(GMDir) Then '判断当前游戏是否已安装并设置过路径
                                    ExZip(DefaultFileAddress, "Waven.zip", Path.GetDirectoryName(GMDir))
                                Else
                                    ExZip(DefaultFileAddress, "Waven.zip", DefaultGameDataPath)
                                End If
                                ButtonAction(False)
                            Else
                                LayoutLabel("取消安装Waven游戏")
                                ButtonAction(False) '改变按钮状态
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "安装游戏失败")
                        End Try
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AfterDownload Error")
        End Try
    End Sub

    Private Sub KillProcess(ByVal ProcessName As String)
        '杀死进程
        Dim myProcesses() As Process
        Dim myProcess As Process
        myProcesses = Process.GetProcessesByName(ProcessName)
        Try
            If myProcesses.Length > 0 Then
                For Each myProcess In myProcesses
                    If myProcess IsNot Nothing Then
                        myProcess.Kill()
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KillProcess Error")
        End Try
    End Sub

    '点击打开或关闭设置面板
    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles OpenSettings.Click
        OpenOrSaveSetting(False)
    End Sub

    '切换下载线路
    Private Sub SwitchLine(ByVal action As String)
        If action Then
            INTLine = Not INTLine
        End If
        If INTLine Then
            ButtonSwitchLine.BackColor = Color.Blue
            LabelSwitchLine.Text = "国际下载线路"
        Else
            ButtonSwitchLine.BackColor = Color.Teal
            LabelSwitchLine.Text = "国内下载线路"
        End If
    End Sub

    Private Sub SwitchLine_Click(sender As Object, e As EventArgs) Handles LabelSwitchLine.Click, ButtonSwitchLine.Click
        SwitchLine(True)
    End Sub

    'KeepOpening判断是否需要一直打开设置面板（因为战网不存在所以需要一直开着）
    Private Sub OpenOrSaveSetting(ByVal KeepOpening As Boolean)
        Try
            If PanelVisible = False Then
                SettingPanel.Show()  '显示设置面板
                OpenSettings.Text = "保存"
                PanelVisible = True
            Else
                If Not KeepOpening Then '如果不需要一直开着就保存
                    Try
                        Dim rButton As RadioButton =   '判断GroupBox控件中是哪一个单选按钮被选中
                            CloseAction.Controls _
                            .OfType(Of RadioButton) _
                            .FirstOrDefault(Function(r) r.Checked = True)
                        CloseForm = rButton.Name.Substring(9)  '截取单选按钮的编号
                        LocAL = LocALCheck.Checked
                        LocGM = LocGameCheck.Checked
                        AutoUD = AutoUDCheck.Checked
                        If LocAL <> My.Settings.LocAL Then
                            '若更改了战网汉化选项，则提示重启战网
                            ButtonAction(False)
                            LayoutLabel("设置将会于下次开启战网时生效")
                        End If
                        If LocGM <> My.Settings.LocGM Then
                            '若更改了游戏汉化选项
                            If LocGM = False Then
                                If GMDir <> "" Then
                                    DFileCN("游戏原版文件", "Waven-fr-fr.zip", DefaultFileAddress)
                                End If
                            Else
                                FinishLocGM = False
                                If AutoUD Then
                                    DFileCN("游戏汉化文件", "Waven-zh-cn.zip", DefaultFileAddress)
                                Else
                                    ButtonAction(False)
                                End If
                            End If
                        End If
                        If ALDir <> My.Settings.ALDir AndAlso ALDir <> "" Then
                            '若战网路径已选择且不为空
                            ButtonAction(False)  '改变按钮状态
                        End If
                        If GMDir <> My.Settings.GMDir AndAlso GMDir <> "" Then
                            '若游戏路径已选择且不为空
                            ButtonAction(False)  '改变按钮状态
                        End If
                        With My.Settings
                            .CloseForm = CloseForm '保存最小化的操作
                            .LocAL = LocAL '保存是否汉化启动战网
                            .LocGM = LocGM '保存是否汉化启动游戏
                            .AutoUD = AutoUD '保存是否自动更新汉化
                            .ALDir = ALDir  '保存战网路径
                            .GMDir = GMDir  '保存游戏路径
                            .INTLine = INTLine '保存下载线路
                            .Save()  '保存所有设置
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Settings Error")
                    End Try
                    SettingPanel.Hide()  '隐藏设置面板
                    OpenSettings.Text = "设置"
                    PanelVisible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Settings Error")
        End Try
    End Sub

    Private Sub SysTrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles SysTrayIcon.MouseDoubleClick
        '双击托盘小图标显示程序窗体
        DisplayForm()
    End Sub

    Public Sub DisplayForm()
        '显示程序窗体方法
        Try
            If SysTrayIcon.Visible = True Then
                SysTrayIcon.Visible = False   '隐藏系统托盘小图标
                ToolStripMenuItem3.Visible = False
            End If
            Show()   '显示主窗体
            Focus()  '前台窗体
            WindowState = FormWindowState.Normal   '正常化窗体，避免仍处于最小化到任务栏
            If Opacity = 0 Then
                Timer_ShowForm.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DisplayForm Error")
        End Try
    End Sub

    Private Sub ShowForm_Tick(sender As Object, e As EventArgs) Handles Timer_ShowForm.Tick
        '窗体加载完成+渐显效果 10ms
        If OpenSettings.Text = "设置" Then
            SettingPanel.Hide()
        End If
        Opacity += 0.1  '恢复透明度显示窗体
        If Opacity >= 1 Then
            Timer_ShowForm.Enabled = False  '关闭计时器
        End If
    End Sub

    Private Sub Timer_HideForm_Tick(sender As Object, e As EventArgs) Handles Timer_HideForm.Tick
        '隐藏窗体渐隐效果 10ms
        Opacity -= 0.2  '降低透明度
        If Opacity <= 0 Then
            Timer_HideForm.Enabled = False  '关闭计时器
            HideFrom()
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            Select Case m.Msg
                Case &H5
                    ' 为避免加载窗体或还原窗体时绘制出现黑框，处理Windows消息
                    If True Then
                        Select Case m.WParam.ToInt32()
                            Case 0
                                'SIZE_RESTORED
                                Timer_ShowForm.Enabled = True
                            Case 1
                                'SIZE_MINIMIZED
                                Opacity = 0
                            Case Else
                                Exit Select
                        End Select
                    End If
                    Exit Select
                Case Else
                    Exit Select
            End Select
            MyBase.WndProc(m)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Overrides WndProc Error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, ToolStripMenuItem3.Click
        '系统托盘图标右键菜单，打开主界面
        DisplayForm()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        '系统托盘图标右键菜单，关闭程序
        If DownloadClient.IsBusy Then
            DisplayForm()
            HideFormAction = 0
        End If
        Close()
    End Sub

    '选择战网路径
    Private Sub SetALDir()
        Try
            Dim tempinidr As String
            If String.IsNullOrEmpty(ALDir) Then
                tempinidr = DefaultALDataPath
            Else
                tempinidr = Path.GetDirectoryName(ALDir)
            End If
            With SelectDirDialog
                .Title = "选择Ankama战网路径"
                .Filter = "Ankama战网|Ankama Launcher.exe"
                .InitialDirectory = tempinidr
                '设置对话框打开时默认路径为默认安装战网的路径或已设置的路径
            End With
            If SelectDirDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If SelectDirDialog.FileName.Contains("Ankama Launcher.exe") Then
                    '路径合法则存储
                    ALDir = SelectDirDialog.FileName
                    LabelDirAL.Text = ALDir
                    ButtonDirAL.BackColor = Color.Teal
                    LabelDirGM.Enabled = True
                    ButtonDirGM.Enabled = True
                    LayoutLabel($"已选择Ankama战网路径""{ALDir}""，请点击保存以生效")
                Else
                    LayoutLabel($"所选择路径无Ankama战网程序")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "SetALPath Error")
        End Try
    End Sub

    '选择游戏路径
    Private Sub SetGMDir()
        Try
            Dim tempinidr As String
            If String.IsNullOrEmpty(GMDir) Then
                tempinidr = DefaultGameDataPath
            Else
                tempinidr = Path.GetDirectoryName(GMDir)
            End If
            With SelectDirDialog
                .Title = "选择Waven游戏路径"
                .Filter = "Waven游戏|Waven.exe"
                .InitialDirectory = tempinidr
                '设置对话框打开时默认路径为默认安装游戏的路径或已设置的路径
            End With
            If SelectDirDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If SelectDirDialog.FileName.Contains("Waven.exe") Then
                    '路径合法则存储
                    GMDir = SelectDirDialog.FileName
                    LabelDirGM.Text = GMDir
                    ButtonDirGM.BackColor = Color.Teal
                    LayoutLabel($"已选择Waven游戏路径""{GMDir}""，请点击保存以生效")
                Else
                    LayoutLabel($"所选择路径无Waven游戏程序")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "SetGamePath Error")
        End Try
    End Sub

    Private Sub SelectDirAL_Click(sender As Object, e As EventArgs) Handles LabelDirAL.Click, ButtonDirAL.Click
        '点击选择战网路径
        SetALDir()
    End Sub

    Private Sub SelectDirGM_Click(sender As Object, e As EventArgs) Handles LabelDirGM.Click, ButtonDirGM.Click
        '点击选择游戏路径
        SetGMDir()
    End Sub

    Private Sub CheckFileExisting(ByRef Dir As String)
        '验证路径合法性
        Try
            If Not File.Exists(Dir) Then
                Dir = ""
                '如果不合法重置为空值
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckFileExisting Error")
        End Try
    End Sub

    Private Function CheckProcessRunning(ByVal Program As String) As Boolean
        '查询程序进程判断程序是否运行，传递程序名
        Try
            Dim ProcessName As String = ""  '程序名
            Dim ProcessPath As String = ""  '程序路径
            Dim ProcessList() As Process
            Select Case Program
                Case "AL"
                    Dim tempALDir As String = ""
                    If String.IsNullOrEmpty(ALDir) Then
                        tempALDir = $"{DefaultALDataPath}Ankama Launcher.exe"
                    Else
                        tempALDir = ALDir
                    End If
                    ProcessName = "Ankama Launcher"
                    ProcessPath = tempALDir
                Case "GM"
                    Dim tempGMDir As String = ""
                    If String.IsNullOrEmpty(GMDir) Then
                        tempGMDir = DefaultGameDataPath & "Waven.exe"
                    Else
                        tempGMDir = GMDir
                    End If
                    ProcessName = "Waven"
                    ProcessPath = tempGMDir
                Case Else
                    Return False
                    Exit Function
            End Select
            ProcessList = Process.GetProcessesByName(ProcessName)
            If ProcessList IsNot Nothing Then
                '获取程序系统进程列表
                Dim LaunchProcess As Process
                For Each LaunchProcess In ProcessList
                    If LaunchProcess IsNot Nothing Then
                        If LaunchProcess.MainModule.FileName.Equals(ProcessPath, StringComparison.OrdinalIgnoreCase) Then
                            Return True
                            Exit Function
                        End If
                    End If
                Next
            End If
            Return False
        Catch ex32 As ComponentModel.Win32Exception
            '32位程序读取64位程序时报错，应将debug中选any cpu，并在项目设置里取消勾选首选32位
            '另外无法获取管理员权限运行进程的路径时也会报错
            MsgBox("快截图到群里领奖！错误详情：" & ex32.NativeErrorCode & ex32.Message,
                   MsgBoxStyle.Exclamation,
                   "恭喜你中奖了！")
            Return False
        Catch ex As Exception
            MsgBox("错误详情：" & ex.Message, MsgBoxStyle.Exclamation, "查询战网或游戏进程时出错")
            Return False
        End Try
    End Function

    '下载文件
    Private Sub DownloadFile(ByVal url As String, ByVal filename As String, ByVal savepath As String)
        Try
            If DownloadClient.IsBusy Or VersionSW.IsRunning Then '若有下载任务或正在检测更新资源页则直接退出sub
                enforce = False
                Exit Sub
            End If
            If VersionResource = "" AndAlso enforce = False Then '若仍未获取到更新资源页内容则重新检查版本
                CheckVersion()
                Exit Sub
            End If
            DownloadFileName = filename  '要下载的文件名
            DownloadFilePath = $"{savepath}\{DownloadFileName}"  '要保存的路径，包含文件名
            If enforce = False AndAlso File.Exists(DownloadFilePath) Then '若不强制下载且存在已下好的文件
                Dim newMD5 As String = ""
                Dim hashCN As String = ""
                If DownloadFileName = "en.json" Then
                    hashCN = DownloadFileName & My.Settings.LocAL '区分要校验的是原版还是汉化版战网语言文件
                Else
                    hashCN = DownloadFileName
                End If
                newMD5 = GetVersion(hashCN, 32)
                If GetFileMD5(DownloadFilePath) = newMD5 Then '若校验到文件是最新则跳过下载步骤
                    If DownloadFileName = "Waven.zip" Or DownloadFileName = "Ankama-Launcher.zip" Then
                        LayoutLabel($"校验完成：本地【{DownloadFileName}】与服务器一致，跳过下载")
                    End If
                    AfterDownload()
                    Exit Sub
                Else
                    If DownloadFileName = "Waven.zip" Or DownloadFileName = "Ankama-Launcher.zip" Then
                        LayoutLabel($"校验完成：本地【{DownloadFileName}】与服务器不一致")
                    End If
                End If
            End If
            SetPanelPB(0)  '开始下载时初始化进度条
            PanelProgress.BackColor = Color.Yellow
            ButtonStatus(StartStatus.CancelDownload)
            If SettingPanel.Visible = True Then
                SettingPanel.Hide()
                OpenSettings.Text = "设置"
                PanelVisible = False
            End If
            OpenSettings.Enabled = False
            If Not Directory.Exists(savepath) Then  '若下载路径不存在文件夹则创建
                Directory.CreateDirectory(savepath)
            End If
            If DownloadClient.IsBusy = False Then
                LayoutLabel($"开始下载：【{DownloadFileName}】 - 下载线路为{LabelSwitchLine.Text}")  '开始下载时初始化输出label
                DownloadClient.DownloadFileAsync(New Uri(url), DownloadFilePath, Stopwatch.StartNew)
                DownloadSW.Start()
                '开始异步下载，记录起始时间
            End If
        Catch ex As Exception
            MsgBox("请确认是否已经安装过4.7.2前置框架。错误信息：" & ex.Message, MsgBoxStyle.Exclamation, "下载文件失败")
        End Try
    End Sub

    '获取下载进度
    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            DownloadSW.Restart() '有下载事件重置超时判断
            percentage = e.ProgressPercentage
            DownloadSpeed = (e.BytesReceived / (DirectCast(e.UserState, Stopwatch).ElapsedMilliseconds / 1000.0#)).ToString("#")
            LocalFileSize = $"{TransBytes(e.BytesReceived)}/{TransBytes(e.TotalBytesToReceive)}"
            layoutDS = $"正在下载【{DownloadFileName}】至【WLDownload】文件夹{vbCrLf}下载速度：{TransBytes(DownloadSpeed)}/s，已完成：{LocalFileSize} ({percentage}%)"
            If Timer_ShowDSpeed.Enabled = False Then
                Timer_ShowDSpeed.Enabled = True
                StartDLTime = TimeOfDay
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ShowDownProgress Error")
        End Try
    End Sub

    '125ms刷新一次下载状态
    Private Sub ShowDSpeed_Tick(sender As Object, e As EventArgs) Handles Timer_ShowDSpeed.Tick
        If DownloadSW.ElapsedMilliseconds > 20000 Then '超过20s无下载事件则判定为下载失败
            DownloadClient.CancelAsync()
        End If
        ElapsedTime = (TimeOfDay - StartDLTime).ToString
        LayoutLabel($"[{StartDLTime:HH:mm:ss}] 下载用时-{ElapsedTime} 下载线路-{LabelSwitchLine.Text}{vbCrLf}{layoutDS}")
        SetPanelPB(percentage)
    End Sub

    '转换字节数目，用于显示下载速度及文件大小
    Public Function TransBytes(ByVal Bytes As Long) As String
        Try
            Dim Suffix() As String = {"B", "KB", "MB", "GB"}
            Dim ByteNumber As Single = Bytes
            For Index As Integer = 0 To Suffix.Length - 1
                If ByteNumber < 1000 Then
                    If Index = 0 Then
                        Return $"{ByteNumber} {Suffix(Index)}"
                    Else
                        Return $"{ByteNumber:0.#0} {Suffix(Index)}"
                    End If
                Else
                    ByteNumber /= 1024
                End If
            Next
            Return $"{ByteNumber:N} {Suffix(Suffix.Length - 1)}"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "TransBytes Error")
            Return "-"
        End Try
    End Function

    '下载完成动作
    Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Try
            OpenSettings.Enabled = True
            Timer_ShowDSpeed.Enabled = False
            If percentage = 100 Then  '异步任务进度满则说明文件下载成功
                DisplayForm()
                LayoutLabel($"下载成功：【{DownloadFileName}】 - 下载线路为{LabelSwitchLine.Text}")
            Else
                enforce = False
                PanelProgress.BackColor = Color.Orange
                Dim DelFile As FileInfo = New FileInfo(DownloadFilePath)
                DelFile.Delete()
                If Directory.Exists(tempUpdatePath) Then
                    Directory.Delete(tempUpdatePath, True)
                End If
            End If
        Catch ex As Exception
            MsgBox("请关闭占用文件的程序。错误原因：" & ex.Message, MsgBoxStyle.Exclamation, "清理下载文件失败")
        Finally
            If percentage = 100 Then
                AfterDownload()  '根据下载成功的文件执行不同动作
            Else
                If DownloadFileName = "Waven-fr-fr.zip" Then '失败则恢复汉化设置
                    My.Settings.LocGM = True
                    LocGM = True
                End If
                If Not e.Cancelled Or DownloadSW.ElapsedMilliseconds > 20000 Then '该值指示异步操作是否是被取消的
                    LayoutLabel($"下载失败：【{DownloadFileName}】 - 下载线路为{LabelSwitchLine.Text}")
                Else
                    LayoutLabel($"取消下载：【{DownloadFileName}】 - 下载线路为{LabelSwitchLine.Text}")
                End If
                DownloadSW.Stop()
                DownloadSW.Reset()
                ButtonAction(False) '改变按钮状态
            End If
        End Try
    End Sub

    Private Sub SetPanelPB(ByVal percentage As Byte)
        Try
            PanelProgress.Size = New Size(Math.Truncate(percentage * PanelProgressBar.Width / 100), 10)
            '用两个Panel嵌套在一起代替ProgressBar，Math.Truncate为去小数直接取整函数
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "SetPanelPB Error")
        End Try
    End Sub

    Private Sub ReplaceFile(ByVal tFilePath As String, ByVal FileName As String)
        '替换文件
        Try
            Dim oPath As String = $"{DefaultFileAddress}/{FileName}"
            Dim tPath As String = $"{tFilePath}/{FileName}"
            Dim oFile As FileInfo = New FileInfo(oPath)
            Dim tFile As FileInfo = New FileInfo(tPath)
            If IO.File.Exists(oPath) Then
                tFile.Delete()
                oFile.CopyTo(tPath) '替换文件
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ReplaceFile Error")
        End Try
    End Sub

    '下载方法实现
    Private Sub DFileCN(ByVal FileNameCN As String, ByVal filename As String, ByVal savepath As String)
        Try
            If Not Directory.Exists(savepath) Then
                Directory.CreateDirectory(savepath)
            End If
            Select Case INTLine '选择下载线路
                Case False '默认国内线路走coding网盘
                    Dim tempFileName As String = GetVersion(FileNameCN, 36)
                    If tempFileName <> "" Then
                        DownloadFile($"https://ankamacn.coding.net/api/share/download/{tempFileName}", filename, savepath)
                    Else
                        LayoutLabel("获取下载地址失败，可尝试切换线路")
                    End If
                Case True '国际线路走CloudFlare的workers脚本爬谷歌网盘
                    If filename = "Ankama-Launcher.zip" Then
                        DownloadFile($"https://pan.layah.workers.dev/0:/{filename}", filename, savepath)
                    ElseIf filename = "en.json" And My.Settings.LocAL Then
                        DownloadFile($"https://pan.layah.workers.dev/1:/{filename}", filename, savepath)
                    Else
                        DownloadFile($"https://pan.layah.workers.dev/0:/Waven/{filename}", filename, savepath)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DFileCN Error")
        End Try
    End Sub

    '委托显示输出
    Delegate Sub LayoutDelegate(ByVal Text As String)
    Private Sub LayoutLabel(ByVal Text As String)
        '输出label方法显示当前状态信息提示
        If StatusLabel.InvokeRequired Then
            StatusLabel.Invoke(New LayoutDelegate(AddressOf LayoutLabel), {Text})
            Return
        End If
        If DownloadClient.IsBusy Then
            StatusLabel.Text = Text
        Else
            newstatusText = $"[{TimeOfDay:HH:mm:ss}] {Text}"
            oldstatusText = StatusLabel.Text
            StatusLabel.Text = $"{oldstatusText}{vbCrLf}{newstatusText}"
            '行数过多截取显示
            If StatusLabel.Height > 69 Then
                oldstatusText = laststatusText
            ElseIf StatusLabel.Height > 52 Then
                oldstatusText = beforestatusText & vbCrLf & laststatusText
            End If
            StatusLabel.Text = $"{oldstatusText}{vbCrLf}{newstatusText}"
            beforestatusText = laststatusText
            laststatusText = newstatusText
            If Opacity = 1 Then '窗体载入时不重绘
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub KillSelfThenRun()   '自爆型更新程序
        '添加了Chr(34)支持空格路径，添加了Encoding.Default使编码从UTF-8转为ANSI从而支持中文路径
        Try
            Dim fs As FileStream = Nothing
            Dim strXCopyFiles As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XCopyFiles.bat")
            fs = New FileStream(strXCopyFiles, FileMode.CreateNew)
            Using swXcopy As StreamWriter = New StreamWriter(fs, Encoding.Default)
                Dim strOriginalPath As String = tempUpdatePath.Substring(0, tempUpdatePath.Length - 1)
                swXcopy.WriteLine(String.Format("
                @echo off
                xcopy /y/s/e/v " & Chr(34) & strOriginalPath & Chr(34) & " " & Chr(34) & Directory.GetCurrentDirectory() & Chr(34) & "", AppDomain.CurrentDomain.FriendlyName))
            End Using
            Dim filename As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "killmyself.bat")
            fs = New FileStream(filename, FileMode.CreateNew)
            Using bat As StreamWriter = New StreamWriter(fs, Encoding.Default)
                bat.WriteLine(String.Format("
                @echo off
                :selfkill
                attrib -a -r -s -h ""{0}""
                del ""{0}""
                if exist ""{0}"" goto selfkill
                call XCopyFiles.bat
                del XCopyFiles.bat
                del /f/q " & Chr(34) & tempUpdatePath & Chr(34) + Environment.NewLine & " rd " + Chr(34) & tempUpdatePath & Chr(34) + Environment.NewLine & " start " + mainAppExe + Environment.NewLine & " del %0 ", AppDomain.CurrentDomain.FriendlyName))
            End Using
            If fs IsNot Nothing Then
                fs.Dispose()
            End If
            Dim info As ProcessStartInfo = New ProcessStartInfo(filename) With {
                .WindowStyle = ProcessWindowStyle.Hidden
            }
            Process.Start(info)
            Environment.[Exit](0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Update SELF Error")
        End Try
    End Sub

    Private Sub NewVersionNeon_Tick(sender As Object, e As EventArgs) Handles Timer_NewVersionNeon.Tick
        '有更新则红黄交替闪烁提示下载
        If WLVerStatus.ForeColor = Color.Yellow Then
            WLVerStatus.ForeColor = Color.Red
        Else
            WLVerStatus.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub WLVerStatus_Click(sender As Object, e As EventArgs) Handles WLVerStatus.Click
        '点击更新提示label的动作
        Try
            If wlneedtoupdate Then  '若检测到了更新则下载
                DFileCN("汉化软件文件", mainAppExe, Application.StartupPath & "\WLTemp")
            Else  '否则重试检测
                CheckVersion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "VersionState.Click Error")
        End Try
    End Sub

    Private Sub FormTitle_Click(sender As Object, e As EventArgs) Handles FormTitle.Click
        '点击标题显示GitHub页面
        Process.Start("https://github.com/layahcn/WavenCN#waven%E6%B1%89%E5%8C%96%E5%90%AF%E5%8A%A8%E5%99%A8")
    End Sub

    Private Sub ALVersionLabel_Click(sender As Object, e As EventArgs) Handles ALVersionLabel.Click
        '点击战网版本号
        Try
            OpenOrSaveSetting(False)
            DFileCN("战网安装文件", "Ankama-Launcher.zip", DefaultFileAddress)
        Catch ex As Exception
            LayoutLabel("下载失败:" & ex.Message & "。请检查网络连接。")
        End Try
    End Sub

    Private Sub GMVersionLabel_Click(sender As Object, e As EventArgs) Handles GMVersionLabel.Click
        '点击游戏版本号
        Try
            If CurrentVersion <> ZipVersionGM Then
                If MsgBox($"【注意】检测到最新游戏版本为{CurrentVersion}，{vbCrLf}是否仍要下载{ZipVersionGM}版本？",
                    MsgBoxStyle.Exclamation _
                    + MsgBoxStyle.OkCancel _
                    + MsgBoxStyle.DefaultButton2,
                    "Waven硬盘版版本不是最新") _
                    <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
            OpenOrSaveSetting(False)
            If INTLine Then
                DownloadFile("https://pan.layah.workers.dev/0:/Waven/Waven.zip", "Waven.zip", DefaultFileAddress)
            Else
                Dim nameCN As String = "游戏硬盘直链"
                Dim templink As String = VersionResource.Remove(0, VersionResource.IndexOf(nameCN) _
                                                                  + nameCN.Length _
                                                                  + 1)
                DownloadFile(templink, "Waven.zip", DefaultFileAddress)
            End If

        Catch ex As Exception
            LayoutLabel("下载失败:" & ex.Message & "。请检查网络连接。")
        End Try
    End Sub

    '计算文件MD5值
    Private Function GetFileMD5(ByVal file_path As String) As String
        Try
            Dim ofile As FileInfo = New FileInfo(file_path)
            If ofile.Name = "Waven.zip" Or ofile.Name = "Ankama-Launcher.zip" Then
                LayoutLabel($"正在校验文件：【{ofile.Name}】")
            End If
            Dim file_stream As FileStream = File.OpenRead(file_path)
            file_stream.Position = 0
            Dim hash As MD5 = System.Security.Cryptography.MD5.Create() '创建MD5哈希算法实例
            Dim hashValue() As Byte = hash.ComputeHash(file_stream) '计算文件MD5哈希值
            Dim hash_hex As String = PrintByteArray(hashValue)
            file_stream.Close()
            Return hash_hex
        Catch ex As Exception
            Return ""
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "GetFileMD5 Error")
        End Try
    End Function

    '将Byte型数组转为十六进制两位数的字符串
    Private Function PrintByteArray(ByVal array() As Byte) As String
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value
    End Function

    '获取本地游戏版本信息
    Private Function GetLocalJson(ByVal name As String, Optional ByVal shift As Byte = 2, Optional ByVal length As Byte = 4) As String
        Try
            Dim valuelist As String = ""
            If File.Exists(LocalJsonFile) Then
                valuelist = File.ReadAllText(LocalJsonFile)
            Else
                Return ""
                Exit Function
            End If
            Dim temp As String = valuelist.Remove(0, valuelist.IndexOf(name) _
                                                      + name.Length _
                                                      + shift)
            Return temp.Substring(0, length)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '通过软件安装游戏硬盘版时写入本地游戏版本信息
    Private Sub WriteLocalJson()
        Try
            Dim JsonFirstHalf As String
            Dim JsonSecondHalf As String = $"version"":""5.0_{ZipVersionGM}"",""repositoryVersion"":""5.0_{CurrentVersion}"",""installedFragments"":[""win32_x64"",""main""],""isInstalling"":false,""isUpdating"":false,""isRepairing"":false,""updateDownloadedSize"":0,""updateDownloadedSizeDate"":0,""isDirty"":false,""_schemaVersion"":1}}"
            If File.Exists(LocalJsonFile) AndAlso GetLocalJson("location") <> "fals" Then
                Dim readtext As String
                readtext = File.ReadAllText(LocalJsonFile)
                JsonFirstHalf = readtext.Remove(readtext.IndexOf("version"))
            Else '本地游戏未设置过路径
                Dim tempgamepath As String
                If GameDataPath <> "" Then
                    tempgamepath = Replace(GameDataPath, "\", "\\")
                Else
                    tempgamepath = Replace(DefaultGameDataPath, "\", "\\")
                    tempgamepath = tempgamepath.Substring(0, tempgamepath.Length - 2)
                End If
                JsonFirstHalf = $"{{""id"":""wavenmain"",""gameUid"":""waven"",""gameId"":22,""gameOrder"":6,""gameName"":""Waven"",""name"":""main"",""location"":""{tempgamepath}"","""
            End If
            File.WriteAllText(LocalJsonFile, JsonFirstHalf & JsonSecondHalf)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "WriteLocalJson Error")
        End Try
    End Sub

End Class
