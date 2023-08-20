Imports System.IO
Imports System.IO.Compression  '解压文件用
Imports System.Net
Imports System.Net.Sockets
Imports System.Security.Cryptography '校验文件用
Imports System.Text
Imports System.Threading
Imports Microsoft.Win32 '读写注册表用

Public Class WavenLauncher
    Const VersionWL As UInteger = 202308201  '汉化启动器9位版本号，跟随发布版本
    Dim NewVersionWL As String  '检测最新汉化启动器版本号
    Dim NewVersionCN As String  '检测最新游戏汉化文本版本号
    Dim NewVersionAL As String  '检测最新战网版本号
    Dim NewVersionGM As String  '检测最新游戏版本号
    Dim ZipVersionGM As String  '储存游戏硬盘版版本号
    Dim wlneedtoupdate As Boolean = False  '汉化启动器是否需要更新
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
    Dim percentage As Single = 0  '用于初始化进度条
    Dim FinishLocGM As Boolean = False  '存储游戏汉化状态
    'Dim finishStartAL As Boolean = False  '存储战网经由汉化启动器启动状态
    Dim gameisrunning As Boolean = False  '存储游戏运行状态
    Dim layoutDS As String '储存下载时输出文本
    Dim waitZiptoCN As Boolean = False '汉化游戏时缺zip时下载并解压
    Dim VersionResourcePage As String '储存资源更新发布页，不再使用需审核的lofter博客
    Dim VersionResource As String '储存资源更新发布页的所有字符，以避免多次发起网络获取
    ReadOnly VersionSW As New Stopwatch '用于获取资源更新发布页时候的超时判断
    Dim enforce As Boolean = False '跳过校验强制下载
    Dim LastMsg As String '储存汉化结果的输出文本
    Dim CurrentVersionPage As String = "https://cytrus.cdn.ankama.com/cytrus.json" '储存官方服务器游戏版本检测页
    Dim CurrentVersion As String '储存从官方服务器检测到的游戏版本
    ReadOnly LocalJsonFile As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\zaap\repositories\production\waven\main\release.json" '存储本地游戏信息文件路径
    ReadOnly ReleaseJsonFile As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\zaap\repositories\production\waven\main\data\release.json" '存储游戏服务器状态文件路径
    Dim LocalGMVersion As String '储存从本地缓存检测到的游戏版本
    Dim LocalALVersion As String '储存从本地缓存检测到的战网版本
    Dim StartDLTime As Date '储存下载开始时间
    Dim RestTime As Long '储存下载剩余时间
    Dim newstatusText As String '储存最新状态信息
    Dim oldstatusText As String '储存旧的状态信息
    Dim laststatusText As String '储存上一条状态信息
    Dim beforestatusText As String '储存前一条状态信息
    'ReadOnly Authorization As String = "&Authorization=Bearer%20eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9."
    ReadOnly clouddrive As String = "http://pan.layah.tk/"
    ReadOnly gitpage As String = "https://jihulab.com/ankamacn/waven/-/raw/main/"
    Dim accessToken As String  '储存云盘分享链接代码
    'Dim domainNumber As String  '储存云盘下载服务器编号
    Dim CheckHash As String  '储存校验用hash值
    Dim lastUpdate As Date  '储存计算下载速度的起始时间
    Dim lastBytes As Long = 0  '储存计算下载速度的起始大小
    Dim timeStart As Date  '储存计算下载速度的当前时间
    Dim timeNow As Date  '储存计算下载速度的当前时间
    Dim timeTotal As TimeSpan  '储存计算下载速度的时间变化量
    Dim timeChange As TimeSpan  '储存计算下载速度的时间变化量
    Dim bytesChange As Long = 0  '储存计算下载速度的大小变化量
    Dim TCPstatus As String  '储存TCP连接状态
    Dim TickCount As Byte  '储存Ping间隔计时次数
    Dim pingflag As Boolean  '判断Ping是否有回应
    Dim latency As UInteger  '储存游戏服务器Ping延迟
    Dim btnStatusChanged As Boolean  '判断开始游戏按钮文本与行为是否一致
    Dim lastbtnStatus As String  '储存上次开始游戏按钮文本
    ReadOnly RegistryPath As String = "SOFTWARE\Ankama\Waven"  '储存注册表用户首选项中Waven游戏相关设置路径
    ReadOnly fullscreenKey As String = "Screenmanager Fullscreen mode_h3630240806"
    ReadOnly windowWidthKey As String = "Screenmanager Resolution Width_h182942802"
    ReadOnly windowHeightKey As String = "Screenmanager Resolution Height_h2627697771"
    ReadOnly graphQualityKey As String = "Waven.Graphics.Alpha.PreferredGraphicQualityIndexV2_h3609782037"
    Dim tempWindowWidth As Int32
    Dim tempWindowHeight As Int32
    Dim ScreenSize As Size

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
            TopMost = True  '窗口置顶
            Opacity = 0  '隐式加载窗体以避免窗体背景重绘造成的控件闪烁
            If Not My.Settings.Valid Then
                My.Settings.Upgrade() '继承旧版设置
                My.Settings.Valid = True
                My.Settings.Save()
            End If
            StatusPanel.BackColor = Color.FromArgb(63, 132, 139)
            PanelProgressBar.BackColor = Color.FromArgb(63, 132, 139)
            Select Case My.Settings.AutoUD
                Case True, False
                    AutoUD = My.Settings.AutoUD
                    AutoUDCheck.Checked = My.Settings.AutoUD
                Case Else
                    My.Settings.AutoUD = True  '若设置不合法取默认值
            End Select '检查版本前先给当前是否自动更新汉化赋值
            WLVersionLabel.Text += $"{FormatWLVersion(VersionWL)}"
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
                CheckLocalAL()
            Else
                ButtonDirAL.BackColor = Color.Red
                LabelDirGM.Enabled = False
                ButtonDirGM.Enabled = False
                GMVersionLabel.Enabled = False
                LocalALVersion = "未查询到"
            End If
            CheckFileExisting(My.Settings.GMDir)  '验证游戏路径合法性，不合法取空值
            GMDir = My.Settings.GMDir
            If File.Exists(GMDir) Then
                GameDataPath = Path.GetDirectoryName(GMDir)  '存储游戏目录
                LabelDirGM.Text = GMDir '显示游戏路径
                CheckRegValue(fullscreenKey)
                CheckRegValue(windowWidthKey)
                CheckRegValue(windowHeightKey)
                CheckRegValue(graphQualityKey)
                CheckLocalGM()
            Else
                AutoUD = False '无游戏路径则不自动安装汉化
                ButtonDirGM.BackColor = Color.Red
                LocalGMVersion = "未查询到"
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
            ShowToolTip.SetToolTip(PingLabel, "每5s检测一次Waven游戏服务器延迟")  '游戏延迟提示
            ShowToolTip.SetToolTip(WindowWidth, "设置游戏分辨率，建议不低于1280×720且宽高比为16:9")  '分辨率提示
            ShowToolTip.SetToolTip(WindowHeight, "设置游戏分辨率，建议不低于1280×720且宽高比为16:9")  '分辨率提示
            ShowToolTip.SetToolTip(WindowResolution, "设置游戏分辨率，建议不低于1280×720且宽高比为16:9")  '分辨率提示
            ShowInTaskbar = True  '防止任务栏未显示图标
            Process.Start(AppDomain.CurrentDomain.BaseDirectory & mainAppExe)  '利用单实例应用程序特性确保打开窗口时在最前

            Timer_ShowForm.Enabled = True  '加载完窗体再触发计时器延时显示窗体
            CheckVersion() '检查版本

            If Not IO.File.Exists(ALDir) Then
                Firsttip()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LoadForm Error")
        End Try
    End Sub

    Private Sub CheckLocalGM()
        LocalGMVersion = GetLocalJson("version", 7, 12) '从本地缓存获取本地游戏版本
        If LocalGMVersion.EndsWith("""") Then
            LocalGMVersion = LocalGMVersion.Substring(0, 11)
        End If
        LocalGMVersionLabel.Text = "★ 本地游戏版本：" & LocalGMVersion
    End Sub

    Private Sub CheckLocalAL()
        Dim versionInfo = FileVersionInfo.GetVersionInfo(ALDir) '从本地战网程序获取本地战网版本
        Dim version As String = versionInfo.FileVersion
        LocalALVersion = version.Substring(0, Len(version) - 6)
        LocalALVersionLabel.Text = "★ 本地战网版本：" & LocalALVersion
    End Sub

    '自定义TabControl的标签样式
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(Color.White)
        Dim TextBrush As New SolidBrush(Color.Teal)
        Using sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            'If we are currently painting the Selected TabItem we'll 
            'change the brush colors and inflate the rectangle.
            If CBool(e.State And DrawItemState.Selected) Then
                FillBrush.Color = Color.Teal
                TextBrush.Color = Color.Yellow
                ItemRect.Inflate(2, 2)
            End If

            'Set up rotation for left and right aligned tabs
            If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
                Dim RotateAngle As Single = 90
                If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
                Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
                e.Graphics.TranslateTransform(cp.X, cp.Y)
                e.Graphics.RotateTransform(RotateAngle)
                ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
            End If

            'Next we'll paint the TabItem with our Fill Brush
            e.Graphics.FillRectangle(FillBrush, ItemRect)

            'Now draw the text.
            e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)
        End Using

        'Reset any Graphics rotation
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        FillBrush.Dispose()
        TextBrush.Dispose()

    End Sub

    '接受点击任务栏最小化
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_MINIMIZEBOX As Integer = &H20000
            'Const WS_EX_COMPOSITED As Integer = &H2000000
            Dim cp As CreateParams = MyBase.CreateParams
            'cp.Style = cp.Style And Not WS_EX_COMPOSITED '不挖空背景直接重绘控件
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
                        + MsgBoxStyle.SystemModal _
                        + MsgBoxStyle.MsgBoxSetForeground _
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
                                Color.White, 1, ButtonBorderStyle.Dashed,
                                Color.White, 1, ButtonBorderStyle.Dashed,
                                Color.White, 1, ButtonBorderStyle.Dashed,
                                Color.White, 1, ButtonBorderStyle.Dashed)
    End Sub

    '检测软件和汉化文本的版本
    Private Sub CheckVersion()
        Try
            If UpdateCN.Text = "强制下载汉化" Or WLVerStatus.Text = "检测失败，点此重试" Then
                WLVerStatus.Text = "检测更新中…"
                If UpdateCN.Text = "强制下载汉化" Then
                    UpdateCN.Text = "检测更新中…"
                End If
                LayoutLabel("正在检测更新中…线路为" & LabelSwitchLine.Text)
                PanelProgress.BackColor = Color.Yellow
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

    '每50ms检测一次是否获取到了更新资源页
    Private Sub CheckVersion_Tick(sender As Object, e As EventArgs) Handles Timer_CheckVersion.Tick
        Try
            If VersionSW.ElapsedMilliseconds < 8000 Then
                SetPanelPB(VersionSW.ElapsedMilliseconds / 100)
            End If
            If VersionSW.ElapsedMilliseconds > 10000 Then '若超过10秒则停止检测
                Timer_CheckVersion.Enabled = False
                SetPanelPB(0)
                VersionSW.Stop()
                VersionSW.Reset()
                WLVerStatus.Text = "检测失败，点此重试"
                If VersionResource = "" AndAlso CurrentVersion = "" Then
                    LayoutLabel("检测更新失败，请检查网络连接并重试")
                Else
                    If VersionResource = "" Then
                        LayoutLabel("获取资源更新发布页失败，请尝试切换下载线路")
                    Else
                        LayoutLabel("获取Waven游戏最新版本失败，部分提示功能受限制")
                        AfterCheckVersion()
                        CurrentVersionPage = $"{clouddrive}1:/cytrus.json"  '若官方页获取不到则使用镜像页
                        Exit Sub
                    End If
                End If
                UpdateCN.Text = "强制下载汉化"
            End If
            If VersionResource <> "" AndAlso CurrentVersion <> "" Then '若获取到非空的资源页文本
                Timer_CheckVersion.Enabled = False
                SetPanelPB(100)
                PanelProgress.BackColor = Color.Yellow
                VersionSW.Stop()
                VersionSW.Reset()
                If VersionWL = My.Settings.VersionWL Then
                    LayoutLabel("检测更新成功，汉化启动器已就绪")
                Else
                    LayoutLabel($"Waven汉化启动器版本已成功从{FormatWLVersion(My.Settings.VersionWL)}更新到{FormatWLVersion(VersionWL)}")
                End If
                My.Settings.VersionWL = VersionWL
                My.Settings.Save()
                AfterCheckVersion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckVersionResource Error")
        End Try
    End Sub

    Private Function FormatWLVersion(ByVal version As UInteger) As String
        Return $"{(version \ 100000) - 2020}.{(version Mod 100000) \ 1000}.{(version Mod 1000) \ 10}.{version Mod 10}"
    End Function

    Private Function FormatGMVersion(ByVal version As UInteger) As String
        Return $"{Val(version) \ 100000}.{(Val(version) Mod 100000) \ 1000}.{(Val(version) Mod 1000) \ 10}-V{Val(version) Mod 10}"
    End Function

    '准备异步获取更新资源页
    Private Async Sub ProcessVersionResource()
        Try
            Dim task_RV As Task(Of String) = GetNewGameVersion()
            Dim task_VR As Task(Of String) = HandleVersionResource(INTLine)
            VersionResource = Await task_VR
            CurrentVersion = Await task_RV
            task_VR.Dispose()
            task_RV.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ProcessVersionResource Error")
        End Try
    End Sub

    '处理异步获取更新资源页
    Private Async Function HandleVersionResource(ByVal line As Boolean) As Task(Of String)
        Try
            Select Case line '选择下载线路
                Case False
                    VersionResourcePage = $"{gitpage}README.md?inline=false"
                Case True
                    VersionResourcePage = $"{clouddrive}1:/README.md"
            End Select
            Dim Resource As String
            Dim request As HttpWebRequest = CType(WebRequest.Create(VersionResourcePage), HttpWebRequest)
            request.KeepAlive = False  '无需建立持续连接
            request.Timeout = 10000
            request.Credentials = CredentialCache.DefaultCredentials
            Using response As HttpWebResponse = CType(Await request.GetResponseAsync(), HttpWebResponse)
                Using dataStream As Stream = response.GetResponseStream()
                    Dim reader As New StreamReader(dataStream)
                    Resource = Await reader.ReadToEndAsync()
                End Using
            End Using
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
                If tempVersionResource.EndsWith(" ") Then
                    tempVersionResource = tempVersionResource.Substring(0, length - 1)
                End If
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
            Dim request As HttpWebRequest = CType(WebRequest.Create(CurrentVersionPage), HttpWebRequest)
            request.KeepAlive = False
            request.Timeout = 10000
            request.Credentials = CredentialCache.DefaultCredentials
            Using response As HttpWebResponse = CType(Await request.GetResponseAsync(), HttpWebResponse)
                Using dataStream As Stream = response.GetResponseStream()
                    Dim reader As New StreamReader(dataStream)
                    CurrentVersionResource = Await reader.ReadToEndAsync()
                End Using
            End Using
            Dim WavenID As String = """gameId"":22,"
            Dim tempCurrentVersion As String = CurrentVersionResource.Remove(0, CurrentVersionResource.IndexOf(WavenID))
            tempCurrentVersion = tempCurrentVersion.Remove(0, tempCurrentVersion.IndexOf("windows"))
            tempCurrentVersion = tempCurrentVersion.Remove(0, tempCurrentVersion.IndexOf("main") + 11)
            tempCurrentVersion = tempCurrentVersion.Substring(0, 12)
            If tempCurrentVersion.EndsWith("""") Then
                tempCurrentVersion = tempCurrentVersion.Substring(0, 11)
            End If
            Return tempCurrentVersion
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '根据版本改变程序信息状态
    Private Sub AfterCheckVersion()
        Try
            NewVersionWL = GetVersion("软件版本号") '获取到最新版本号后赋值
            NewVersionCN = GetVersion("游戏汉化版本")
            NewVersionAL = GetVersion("适用战网版本", 6) '获取到最新版本号后赋值
            NewVersionGM = GetVersion("适用游戏版本", 12)
            ZipVersionGM = GetVersion("游戏硬盘版", 12)
            'accessToken = VersionResource.Remove(0, VersionResource.IndexOf("授权下载密匙") + 8)
            'domainNumber = VersionResource.Remove(0, VersionResource.IndexOf("授权下载密匙") + 7).Substring(0, 1)
            ALVersionLabel.Text = "★ 点击下载战网：" & NewVersionAL
            GMVersionLabel.Text = "★ 点击下载游戏：" & NewVersionGM
            LocalALVersionLabel.Text = "★ 本地战网版本：" & LocalALVersion
            LocalGMVersionLabel.Text = "★ 本地游戏版本：" & LocalGMVersion
            If Val(NewVersionWL) > VersionWL Then
                '若获取到版本号比当前软件版本号要新（如201908051>201908011
                WLVerStatus.Text = "点此更新软件"
                wlneedtoupdate = True  '设置需要更新以便点击label时为下载
                Timer_NewVersionNeon.Enabled = True  '开启红黄闪烁
                VersionAL = My.Settings.VersionAL
                'ALVersionLabel.Text = "适用战网版本：" & VersionAL
                VersionGM = My.Settings.VersionGM
                'GMVersionLabel.Text = "适用游戏版本：" & VersionGM ' 显示软件自带版本号
            Else
                If CurrentVersion <> "" Then
                    WLVerStatus.Text = ""
                End If
                VersionAL = NewVersionAL
                'ALVersionLabel.Text = "适用战网版本：" & NewVersionAL
                VersionGM = NewVersionGM
                'GMVersionLabel.Text = "适用游戏版本：" & NewVersionGM ' 显示兼容的版本号
            End If
            ALVersionLabel.Enabled = True
            If File.Exists(ALDir) Then
                GMVersionLabel.Enabled = True
            End If
            LocALCheck.Enabled = True
            LocGameCheck.Enabled = True
            AutoUDCheck.Enabled = True
            WindowedMode.Enabled = True
            If NewVersionCN <> "" Then
                UpdateCN.Text = FormatGMVersion(NewVersionCN)
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
                DownloadFile($"{clouddrive}0:/Waven/Waven-zh-cn.zip",
                             "Waven-zh-cn.zip",
                             DefaultFileAddress)
            Else
                DownloadFile($"{gitpage}Waven-zh-cn.zip",
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
            Exit Sub
        End If
        ButtonAction(False)      '更改按钮状态
        If VersionSW.IsRunning Then '若正在检测更新资源页
            LayoutLabel("正在检测更新中…暂时不能" & StartButton.Text)
            Exit Sub
        End If
        If DownloadClient.IsBusy Then '若有下载任务
            DownloadClient.CancelAsync()
            enforce = False
            Timer_ShowDSpeed.Enabled = False
            Exit Sub
        End If
        If btnStatusChanged = True Then
            LayoutLabel($"检测到按钮变为【{StartButton.Text}】，为防止误操作，已取消【{lastbtnStatus}】动作")
        Else
            ButtonAction(True)       '点击执行过程
        End If
    End Sub

    '更改按钮状态以及输出相应的提示文字
    Private Sub ButtonStatus(Status As StartStatus)
        Select Case Status
            Case StartStatus.DownloadAL
                CheckbtnStatus("下载战网")
            Case StartStatus.StartAL
                CheckbtnStatus("启动战网")
            Case StartStatus.LocGM
                CheckbtnStatus("汉化游戏")
            Case StartStatus.Setdir
                CheckbtnStatus("设置路径")
            Case StartStatus.Quit
                CheckbtnStatus("退出软件")
            Case StartStatus.CancelDownload
                CheckbtnStatus("取消下载")
        End Select
    End Sub

    Private Sub CheckbtnStatus(ByVal text As String)
        lastbtnStatus = StartButton.Text
        If text = lastbtnStatus Then
            btnStatusChanged = False
        Else
            btnStatusChanged = True
        End If
        StartButton.Text = text
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
                                    StartAL()
                                Else
                                    DFileCN("战网汉化文件", "en.json", DefaultFileAddress)
                                End If
                                Exit Sub
                            End If
                        Else  '若不需要汉化战网
                            If Action Then '则恢复启动英文版
                                LayoutLabel("正在启动战网，未启用战网汉化")
                                If VersionResource = "" Then
                                    StartAL()
                                Else
                                    DFileCN("战网原版文件", "en.json", DefaultFileAddress)
                                End If
                            End If
                            'End If
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
                        LayoutLabel("游戏需要修复，暂时不可安装汉化")
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
                            If GetReleaseJson("serverBlocked") = "true" Or GetReleaseJson("teasing") = "true" Or GetReleaseJson("teasing") = """WAV" Then
                                LayoutLabel("游戏服务器目前不可用，暂时不可安装汉化")
                                Exit Sub
                            End If
                            If VersionResource = "" Then
                                LayoutLabel("未检测到版本信息，请检查网络连接后再安装汉化。或可尝试强制下载安装汉化")
                                Exit Sub
                            End If
                            If GetLocalJson("version", 2, 5) = "false" Or GetLocalJson("version", 2, 5) = "" Then
                                LayoutLabel("未检测到本地游戏版本，请打开战网校验游戏文件")
                                Exit Sub
                            End If

                            If LocalGMVersion <> CurrentVersion AndAlso CurrentVersion <> "" Then
                                LayoutLabel($"本地游戏版本为{LocalGMVersion}，请更新到{CurrentVersion}后再安装汉化！")
                                Exit Sub
                            End If
                            Dim tempVersionCN As String
                            If UpdateCN.Text = "强制下载汉化" Then
                                Dim tempversion As String = GetVersion("游戏汉化版本")
                                tempVersionCN = FormatGMVersion(tempversion) & "。PS检测最新游戏版本失败，若游戏有更新可能无法正常使用汉化"
                            Else
                                tempVersionCN = UpdateCN.Text
                            End If
                            Dim frfrDir As String = GameDataPath & "\Waven_Data\StreamingAssets\AssetBundles\core\localization.fr-fr"
                            Dim CurrentCNMD5 As String = GetFileMD5(frfrDir)
                            Dim newCNMD5 As String = GetVersion("localization.fr-fr", 32)
                            If CurrentCNMD5 = newCNMD5 Then '若fr-fr文件为汉化版
                                LayoutLabel($"已安装过汉化，版本为【{tempVersionCN}】")
                                FinishLocGM = True
                                ButtonAction(False)
                                Exit Sub
                            End If
                            If CurrentVersion = NewVersionGM Or CurrentVersion = "" Then  '若汉化适用版本与游戏版本一致或未获取到官方游戏版本
                                If wlneedtoupdate Then '若软件需更新则提示
                                    LayoutLabel("Waven汉化启动器过旧！请更新软件！")
                                    Exit Sub
                                End If
                                If LocalGMVersion = NewVersionGM Then  '若未检测到最新游戏版本，那么比较本地游戏版本与汉化适用版本
                                    ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                                    '调用解压zip方法
                                    LastMsg = $"安装汉化成功，版本为【{tempVersionCN}】"
                                Else
                                    LayoutLabel($"汉化失败：本地游戏版本为{LocalGMVersion}，而汉化适用版本为{NewVersionGM}。")
                                    Exit Sub
                                End If
                            Else  '若汉化适用版本与游戏版本不一致
                                Dim VersionMSG As String
                                Dim CancelMSG As String
                                VersionMSG = "【注意】检测到汉化适用游戏版本与最新游戏版本不一致，不推荐安装汉化。"
                                CancelMSG = "取消安装汉化。关注Waven群等待新版补丁吧。"
                                bFormDragging = False
                                '对话框
                                If MsgBox($"{VersionMSG}{vbCrLf}是否仍要尝试安装汉化？可能会无法打开游戏",
                                            MsgBoxStyle.Exclamation _
                                            + MsgBoxStyle.SystemModal _
                                            + MsgBoxStyle.MsgBoxSetForeground _
                                            + MsgBoxStyle.OkCancel _
                                            + MsgBoxStyle.DefaultButton2,
                                            "汉化适用游戏版本不一致") _
                                      = MsgBoxResult.Ok Then
                                    ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                                    '调用解压zip方法
                                    LastMsg = "若无法打开游戏请在设置里取消勾选【启用游戏汉化】或使用战网修复游戏"
                                Else
                                    LayoutLabel(CancelMSG)
                                    Exit Sub
                                End If
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
                If Not expath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) Then
                    expath += Path.DirectorySeparatorChar  '目录结尾添加\
                End If
                LayoutLabel($"正在解压【{zipname}】至：""{expath}""")  '输出label显示正在解压的文件
                Using file As New FileStream(zipPath, FileMode.Open)
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
                End Using
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
                            StartAL()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "汉化战网失败")
                        End Try
                    Case "Waven-zh-cn.zip"
                        LayoutLabel($"本地游戏汉化包已是最新版【{UpdateCN.Text}】，可进行安装")
                        If File.Exists(GMDir) AndAlso (waitZiptoCN Or AutoUD) Then
                            LocGame()
                        Else
                            ButtonAction(False) '改变按钮状态
                            enforce = False
                        End If
                    Case "Waven-fr-fr.zip"
                        If CheckProcessRunning("GM") Then
                            KillProcess("Waven")
                            gameisrunning = False
                            bFormDragging = False
                            '对话框
                            MsgBox($"【注意】恢复游戏原版文件需关闭游戏，{vbCrLf}即将卸载当前游戏汉化",
                              MsgBoxStyle.Exclamation _
                              + MsgBoxStyle.SystemModal _
                              + MsgBoxStyle.MsgBoxSetForeground _
                              + MsgBoxStyle.OkOnly,
                              "卸载当前游戏汉化")
                        End If
                        Try
                            If File.Exists(GMDir) Then
                                GameDataPath = Path.GetDirectoryName(GMDir)
                                ExZip(DefaultFileAddress, "Waven-fr-fr.zip", GameDataPath)
                                '调用解压zip方法
                                Dim DelFile As New FileInfo(GameDataPath & "\zh-cn.json")
                                DelFile.Delete()
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
                            '对话框
                            If MsgBox($"【注意】安装Ankama战网将会强制覆盖文件，{vbCrLf}是否要继续Ankama战网硬盘版的安装？",
                                      MsgBoxStyle.Exclamation _
                                      + MsgBoxStyle.SystemModal _
                                      + MsgBoxStyle.MsgBoxSetForeground _
                                      + MsgBoxStyle.OkCancel _
                                      + MsgBoxStyle.DefaultButton2,
                                      "Ankama战网硬盘版下载完成") _
                                 = MsgBoxResult.Ok Then
                                If File.Exists(ALDir) Then '判断当前战网是否已安装并设置过路径
                                    ExZip(DefaultFileAddress, "Ankama-Launcher.zip", Path.GetDirectoryName(ALDir))
                                Else
                                    ExZip(DefaultFileAddress, "Ankama-Launcher.zip", DefaultALDataPath)
                                    ALDir = DefaultALDataPath & "Ankama Launcher.exe"
                                    My.Settings.ALDir = ALDir
                                    LabelDirAL.Text = ALDir
                                    ButtonDirAL.BackColor = Color.Teal
                                    LabelDirGM.Enabled = True
                                    ButtonDirGM.Enabled = True
                                    GMVersionLabel.Enabled = True
                                End If
                                ButtonAction(False) '改变按钮状态
                                CheckLocalAL()
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
                            '对话框
                            If MsgBox($"【注意】安装Waven游戏会强制覆盖文件，{vbCrLf}是否要继续Waven游戏硬盘版的安装？",
                                      MsgBoxStyle.Exclamation _
                                      + MsgBoxStyle.SystemModal _
                                      + MsgBoxStyle.MsgBoxSetForeground _
                                      + MsgBoxStyle.OkCancel _
                                      + MsgBoxStyle.DefaultButton2,
                                      "Waven游戏硬盘版下载完成") _
                                 = MsgBoxResult.Ok Then
                                WriteLocalJson()
                                If File.Exists(GMDir) Then '判断当前游戏是否已安装并设置过路径
                                    ExZip(DefaultFileAddress, "Waven.zip", Path.GetDirectoryName(GMDir))
                                Else
                                    ExZip(DefaultFileAddress, "Waven.zip", DefaultGameDataPath)
                                    GMDir = DefaultGameDataPath & "Waven.zip"
                                    LabelDirGM.Text = GMDir
                                    ButtonDirGM.BackColor = Color.Teal
                                End If
                                ButtonAction(False)
                                CheckLocalGM()
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

    Private Sub StartAL()
        '启动战网
        Try
            'finishStartAL = True
            TopMost = False
            Process.Start(ALDir)
            Thread.Sleep(1000)
            ButtonAction(False)  '改变按钮状态
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "StartAL Error")
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
                ScreenSize = GetRealScreenSize()
                CheckRegValue(fullscreenKey)
                CheckRegValue(windowWidthKey)
                CheckRegValue(windowHeightKey)
                CheckRegValue(graphQualityKey)
                SettingPanel.Show()  '显示设置面板
                Checkping()  '开始检测游戏服务器延迟
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
                        If GMDir <> "" Then
                            SetRegValue(graphQualityKey, GraphQualityList.SelectedIndex)
                            If Val(WindowWidth.Text) <> tempWindowWidth Or Val(WindowHeight.Text) <> tempWindowHeight Then
                                tempWindowWidth = Val(WindowWidth.Text)
                                tempWindowHeight = Val(WindowHeight.Text)
                                SetRegValue(windowWidthKey, tempWindowWidth)
                                SetRegValue(windowHeightKey, tempWindowHeight)
                                LayoutLabel($"已设置游戏分辨率为{tempWindowWidth}×{tempWindowHeight}")
                            End If
                            If WindowedMode.Checked Then  '如果勾选窗口模式
                                SetRegValue(fullscreenKey, 3)
                            Else
                                SetRegValue(fullscreenKey, 1)
                            End If
                            If GMDir <> My.Settings.GMDir Then
                                '若游戏路径已选择
                                ButtonAction(False)  '改变按钮状态
                                CheckLocalGM()
                            End If
                        End If
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
                            CheckLocalAL()
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
                    Timer_Ping.Enabled = False
                    OpenSettings.Text = "设置"
                    PanelVisible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Settings Error")
        End Try
    End Sub

    Private Sub Checkping()  '委托异步检测服务器延迟
        If Timer_Ping.Enabled = False Then
            TickCount = 0
            Timer_Ping.Enabled = True
            Dim task_ping As New Task(AddressOf DelegateProcess)
            task_ping.Start()
        End If
    End Sub

    Private Async Sub DelegateProcess()  '委托线程
        Try
            Dim task_ping As Task(Of Boolean) = PingwithPort("waven-101.ankama-games.com", "5988")
            TCPstatus = Await task_ping
            task_ping.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DelegateProcess Error")
        End Try
    End Sub

    Private Async Function PingwithPort(ByVal IP As String, ByVal Port As Short) As Task(Of Boolean)
        Try  '连接TCP端口，返回连接状态
            Using TCP As New TcpClient
                Dim pingwatch As New Stopwatch
                Dim status As Boolean = False
                pingwatch.Start()
                Await TCP.ConnectAsync(IP, Port)
                pingwatch.Stop()
                status = TCP.Connected
                latency = pingwatch.ElapsedMilliseconds
                TCP.Close()
                Return status
            End Using
        Catch ex As Exception
            Return False
            Timer_Ping.Enabled = False
        End Try
    End Function

    Private Sub Timer_Ping_Tick(sender As Object, e As EventArgs) Handles Timer_Ping.Tick
        '每隔大致5s检测一次返回值，tick100ms。由于计时器间隔不一定准确，所以只是大概5s，要准确只能读取系统时钟
        TickCount += 1
        If PingLabel.Text = "★ 游戏延迟：- ms" Then '首次打开设置若获取到则先直接显示一次
            If Len(TCPstatus) <> 0 AndAlso latency < 3000 Then
                If TCPstatus Then
                    TickCount = 51
                End If
            End If
        End If
        If TickCount > 50 Then
            If Len(TCPstatus) <> 0 AndAlso latency < 3000 Then
                If TCPstatus Then
                    PingLabel.Text = $"★ 游戏延迟：{latency} ms"
                Else
                    PingLabel.Text = "★ 游戏延迟：- ms"
                End If
                pingflag = True
                TCPstatus = ""
            End If
            If pingflag Then
                pingflag = False
            Else
                PingLabel.Text = "★ 游戏延迟：超时"
            End If
            Timer_Ping.Enabled = False
            Checkping()
        End If
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
        '窗体加载完成+渐显效果 15ms，实际波动范围0ms-50ms，所以效果一般。。
        Opacity += 0.1  '恢复透明度显示窗体
        If Opacity >= 1 Then
            Timer_ShowForm.Enabled = False  '关闭计时器
        End If
        If OpenSettings.Text = "设置" Then
            SettingPanel.Hide()
        End If
    End Sub

    Private Sub Timer_HideForm_Tick(sender As Object, e As EventArgs) Handles Timer_HideForm.Tick
        '隐藏窗体渐隐效果 15ms
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
                    GMVersionLabel.Enabled = True
                    LabelDirGM.Enabled = True
                    ButtonDirGM.Enabled = True
                    CheckLocalAL()
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
                If GetLocalJson("location") = "" Then
                    tempinidr = DefaultGameDataPath
                Else
                    tempinidr = GetLocalJson("location")
                End If

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
                    CheckRegValue(fullscreenKey)
                    CheckRegValue(windowWidthKey)
                    CheckRegValue(windowHeightKey)
                    CheckRegValue(graphQualityKey)
                    CheckLocalGM()
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
            If ProcessList.Length > 0 Then
                '获取程序系统进程列表
                Dim LaunchProcess As Process
                For Each LaunchProcess In ProcessList
                    If LaunchProcess.MainModule.FileName IsNot Nothing Then
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
            '这东西太奇怪了，直接设置不回显了
            MsgBox("错误详情：" & ex32.ToString, MsgBoxStyle.Exclamation, "查询战网或游戏进程时出错")
            Return False
        Catch ex As Exception
            MsgBox("错误详情：" & ex.ToString, MsgBoxStyle.Exclamation, "查询战网或游戏进程时出错")
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
            Dim hashCN As String = ""
            If DownloadFileName = "en.json" Then
                hashCN = DownloadFileName & My.Settings.LocAL '区分要校验的是原版还是汉化版战网语言文件
            Else
                hashCN = DownloadFileName
            End If
            CheckHash = GetVersion(hashCN, 32)
            If enforce = False AndAlso File.Exists(DownloadFilePath) Then '若不强制下载且存在已下好的文件
                If GetFileMD5(DownloadFilePath) = CheckHash Then '若校验到文件是最新则跳过下载步骤
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
                DownloadClient.DownloadFileAsync(New Uri(url), DownloadFilePath)
                DownloadSW.Start()
                '开始异步下载，记录起始时间
                lastBytes = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "下载文件失败")
        End Try
    End Sub

    '获取下载进度
    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            DownloadSW.Restart() '有下载事件重置超时判断
            If e.TotalBytesToReceive = -1 Or e.ProgressPercentage = 100 Then
                percentage = e.ProgressPercentage
            Else
                percentage = Math.Round(e.BytesReceived / e.TotalBytesToReceive * 100, 2)
            End If
            If lastBytes = 0 Then  '初始化测速模块
                timeStart = Date.Now
                lastUpdate = timeStart
                lastBytes = e.BytesReceived
                DownloadSpeed = 0
                bytesChange = 0
                RestTime = 0
                Return
            End If
            timeNow = Date.Now
            timeChange = timeNow - lastUpdate
            If timeChange.TotalMilliseconds > 999 Then  '事件间隔999ms以上输出一次速度
                If DownloadSpeed = 0 Then  '上次瞬时速度为0时用总体平均速度代替
                    timeTotal = timeNow - timeStart
                    DownloadSpeed = (e.BytesReceived / (timeTotal.TotalMilliseconds / 1000.0#)).ToString("#")
                    RestTime = CLng((e.TotalBytesToReceive - e.BytesReceived) / DownloadSpeed)
                End If
                bytesChange = e.BytesReceived - lastBytes
                DownloadSpeed = CLng(DownloadSpeed * 0.618 + Val((bytesChange / (timeChange.TotalMilliseconds / 1000.0#)).ToString("#")) * 0.382)
                If RestTime <> -1 Then  '剩余秒数=历史秒数*0.382+剩余文件大小/瞬时下载速度*0.618
                    RestTime = CLng(RestTime * 0.382 + ((e.TotalBytesToReceive - e.BytesReceived) / DownloadSpeed) * 0.618)
                End If
                lastBytes = e.BytesReceived
                lastUpdate = timeNow
            End If
            LocalFileSize = $"{TransBytes(e.BytesReceived)}/{TransBytes(e.TotalBytesToReceive)}"
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
        ElseIf DownloadSW.ElapsedMilliseconds > 5000 Then '超过5s无下载事件清零下载速度
            DownloadSpeed = 0
            RestTime = -1
        End If
        layoutDS = $"已完成：{LocalFileSize} ({Format(percentage, "0.00")}%)，下载速度"
        If bytesChange = 0 Then '初始显示
            layoutDS += "计算中"
        Else
            layoutDS += $"：{TransBytes(DownloadSpeed)}/s"
        End If
        timeChange = Date.Now - timeStart
        LayoutLabel($"[{StartDLTime:HH:mm:ss}] 正在下载【{DownloadFileName}】至【WLDownload】文件夹{vbCrLf}下载线路：{LabelSwitchLine.Text}，已用时：{Int(timeChange.TotalMinutes)}分{timeChange.Seconds}秒，剩余{TransTime(RestTime)}{vbCrLf}{layoutDS}")
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
            Return "-"
        End Try
    End Function

    '转换秒数，用于显示下载所需剩余时间
    Public Function TransTime(ByVal Seconds As Long) As String
        Try
            If Seconds < 0 Then
                Return "时间未知"
            ElseIf bytesChange = 0 Then
                Return "时间计算中"
            ElseIf Seconds < 60 Then
                Return $"时间：{Seconds}秒"
            ElseIf Seconds < 3600 Then
                Return $"时间：{Seconds \ 60}分{Seconds Mod 60}秒"
            ElseIf Seconds < 86400 Then
                Return $"时间：{Seconds \ 3600}时{(Seconds Mod 3600) \ 60}分"
            Else
                Return "时间 > 1天"
            End If
        Catch ex As Exception
            Return "时间未知"
        End Try
    End Function

    '下载完成动作
    Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Try
            OpenSettings.Enabled = True
            Timer_ShowDSpeed.Enabled = False
            DisplayForm()
            If percentage = 100 Then  '异步任务进度满则说明文件下载成功
                SetPanelPB(100)
                If enforce = True Then
                    Exit Try
                Else
                    If GetFileMD5(DownloadFilePath) = CheckHash Then '若校验文件成功则说明下载文件通过验证
                        If DownloadFileName = "Waven.zip" Or DownloadFileName = "Ankama-Launcher.zip" Then
                            LayoutLabel($"校验结果：【{DownloadFileName}】与服务器一致")
                        End If
                        Exit Try
                    Else
                        LayoutLabel($"校验结果：【{DownloadFileName}】与服务器不一致，可能是地址失效")
                    End If
                End If
            End If
            enforce = False
            percentage = 0
            PanelProgress.BackColor = Color.Orange
            Dim DelFile As New FileInfo(DownloadFilePath)
            DelFile.Delete()
            If Directory.Exists(tempUpdatePath) Then
                Directory.Delete(tempUpdatePath, True)
            End If
        Catch ex As Exception
            MsgBox("请关闭占用文件的程序。错误原因：" & ex.Message, MsgBoxStyle.Exclamation, "清理下载文件失败")
        Finally
            If percentage = 100 Then
                LayoutLabel($"下载成功：【{DownloadFileName}】 - 下载线路为{LabelSwitchLine.Text}")
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

    Private Sub SetPanelPB(ByVal percentage As Single)
        Try
            PanelProgress.Width = Math.Truncate(percentage * PanelProgressBar.Width / 100)
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
            Dim oFile As New FileInfo(oPath)
            Dim tFile As New FileInfo(tPath)
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
                    If filename = "Ankama-Launcher.zip" Then
                        accessToken = VersionResource.Remove(0, VersionResource.IndexOf(FileNameCN) + 7).Substring(0, 22)
                        'DownloadFile($"https://fs-{domainNumber}.matpool.com/fs?path=%2F{filename}{Authorization}{accessToken}", filename, savepath)
                        DownloadFile($"http://pan.blockelite.cn:15021/web/client/pubshares/{accessToken}?compress=false", filename, savepath)
                    ElseIf filename = "en.json" And My.Settings.LocAL Then  '战网汉化版文件
                        DownloadFile($"{gitpage}src/{filename}", filename, savepath)
                    Else
                        DownloadFile($"{gitpage}{filename}", filename, savepath)
                    End If
                Case True '国际线路走CloudFlare的workers脚本爬谷歌网盘
                    If filename = "Ankama-Launcher.zip" Then
                        DownloadFile($"{clouddrive}0:/{filename}", filename, savepath)
                    ElseIf filename = "en.json" And My.Settings.LocAL Then  '战网汉化版文件
                        DownloadFile($"{clouddrive}1:/{filename}", filename, savepath)
                    Else
                        DownloadFile($"{clouddrive}0:/Waven/{filename}", filename, savepath)
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
            Using swXcopy As New StreamWriter(fs, Encoding.Default)
                Dim strOriginalPath As String = tempUpdatePath.Substring(0, tempUpdatePath.Length - 1)
                swXcopy.WriteLine(String.Format("
                @echo off
                xcopy /y/s/e/v " & Chr(34) & strOriginalPath & Chr(34) & " " & Chr(34) & Directory.GetCurrentDirectory() & Chr(34) & "", AppDomain.CurrentDomain.FriendlyName))
            End Using
            Dim filename As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "killmyself.bat")
            fs = New FileStream(filename, FileMode.CreateNew)
            Using bat As New StreamWriter(fs, Encoding.Default)
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
            Dim info As New ProcessStartInfo(filename) With {
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
            If Not DownloadClient.IsBusy Then
                If wlneedtoupdate Then  '若检测到了更新则下载
                    DFileCN("汉化软件文件", mainAppExe, Application.StartupPath & "\WLTemp")
                Else  '否则重试检测
                    CheckVersion()
                End If
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
            If CurrentVersion <> ZipVersionGM AndAlso CurrentVersion <> "" Then
                '对话框
                If MsgBox($"【注意】检测到最新游戏版本为{CurrentVersion}，{vbCrLf}是否仍要下载{ZipVersionGM}版本？",
                    MsgBoxStyle.Exclamation _
                    + MsgBoxStyle.SystemModal _
                    + MsgBoxStyle.MsgBoxSetForeground _
                    + MsgBoxStyle.OkCancel _
                    + MsgBoxStyle.DefaultButton2,
                    "Waven硬盘版版本不是最新") _
                    <> MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
            OpenOrSaveSetting(False)
            If INTLine Then
                DownloadFile($"{clouddrive}0:/Waven/Waven.zip", "Waven.zip", DefaultFileAddress)
            Else
                accessToken = VersionResource.Remove(0, VersionResource.IndexOf("游戏安装文件") + 7).Substring(0, 22)
                DownloadFile($"http://pan.blockelite.cn:15021/web/client/pubshares/{accessToken}?compress=false", "Waven.zip", DefaultFileAddress)
            End If
        Catch ex As Exception
            LayoutLabel("下载失败:" & ex.Message & "。请检查网络连接。")
        End Try
    End Sub

    '计算文件MD5值
    Private Function GetFileMD5(ByVal file_path As String) As String
        Try
            Dim ofile As New FileInfo(file_path)
            If ofile.Name = "Waven.zip" Or ofile.Name = "Ankama-Launcher.zip" Then
                LayoutLabel($"正在校验文件：【{ofile.Name}】")
            End If
            Dim file_stream As FileStream = File.OpenRead(file_path)
            file_stream.Position = 0
            Dim hash As MD5 = MD5.Create() '创建MD5哈希算法实例
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
            If name = "location" Then
                temp = temp.Remove(0, 1)
                temp = temp.Substring(0, temp.IndexOf(""""))
                Return temp.Replace("\\", "\")
            Else
                Return temp.Substring(0, length)
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '获取本地记录的服务器状态信息
    Private Function GetReleaseJson(ByVal name As String, Optional ByVal shift As Byte = 2, Optional ByVal length As Byte = 4) As String
        Try
            Dim valuelist As String = ""
            If File.Exists(ReleaseJsonFile) Then
                valuelist = File.ReadAllText(ReleaseJsonFile)
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
            Dim tempVersion As String
            If CurrentVersion = "" Then
                tempVersion = ZipVersionGM
            Else
                tempVersion = CurrentVersion
            End If
            Dim JsonSecondHalf As String = $"version"":""6.0_{ZipVersionGM}"",""repositoryVersion"":""6.0_{tempVersion}"",""installedFragments"":[""configuration"",""win32_x64""],""isInstalling"":false,""isUpdating"":false,""isRepairing"":false,""isDirty"":false,""_schemaVersion"":1}}"
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
                JsonFirstHalf = $"{{""id"":""wavenmain"",""gameUid"":""waven"",""gameId"":22,""gameOrder"":7,""gameName"":""Waven"",""name"":""main"",""location"":""{tempgamepath}"","""
            End If
            File.WriteAllText(LocalJsonFile, JsonFirstHalf & JsonSecondHalf)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "WriteLocalJson Error")
        End Try
    End Sub

    Private Sub Firsttip()
        Dim tooltip1 As New ToolTip
        Dim point1 As New Point(5, 30)
        tooltip1.Show("第一次使用请点击上方标题仔细阅读教程", FormTitle, point1)
    End Sub

    '读取注册表对应键值
    Private Sub CheckRegValue(key As String)
        Try
            Using regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, False)
                If regKey IsNot Nothing Then
                    '读取注册表指定路径子项，并根据键值显示状态
                    Select Case key
                        Case fullscreenKey
                            Select Case regKey.GetValue(key, 1)
                                Case 1
                                    WindowedMode.Checked = False
                                Case 3
                                    WindowedMode.Checked = True
                                Case Else
                                    SetRegValue(key, 1)
                                    WindowedMode.Checked = False
                            End Select
                        Case windowWidthKey
                            tempWindowWidth = regKey.GetValue(key, 1280)
                            WindowWidth.Text = tempWindowWidth
                        Case windowHeightKey
                            tempWindowHeight = regKey.GetValue(key, 720)
                            WindowHeight.Text = tempWindowHeight
                        Case graphQualityKey
                            GraphQualityList.SelectedIndex = regKey.GetValue(key, 0)
                    End Select
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "GetRegValue Error")
        End Try
    End Sub

    '修改注册表对应键值
    Private Sub SetRegValue(key As String, value As Int32)
        Try
            '打开注册表指定路径子项，True表示应用写访问权限
            Using regKey As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryPath, True)
                If regKey IsNot Nothing Then
                    regKey.SetValue(key, value)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "SetRegValue Error")
        End Try
    End Sub

    '利用屏幕截图到Bitmap，找到Alpha=0的像素点，以获得缩放之前屏幕真实分辨率
    Public Function GetRealScreenSize() As Size
        Dim W As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim H As Integer = Screen.PrimaryScreen.Bounds.Height

        Dim Img As Image = New Bitmap(W * 3, H * 3)
        Dim G As Graphics
        G = Graphics.FromImage(Img)
        G.CopyFromScreen(New Point(0, 0), New Point(0, 0), Img.Size)
        G.Dispose()
        GC.Collect()
        Dim i As Integer
        For i = W To W * 3 - 1 Step 1
            Dim PointColor As Color = CType(Img, Bitmap).GetPixel(i, 0)
            If PointColor.A = 0 And PointColor.R = 0 And PointColor.G = 0 And PointColor.B = 0 Then
                W = i
                Exit For
            End If
        Next

        If W <> Screen.PrimaryScreen.Bounds.Width Then
            H = CInt(H * (W / Screen.PrimaryScreen.Bounds.Width))
        End If
        Return New Size(W, H)
    End Function

    '限制分辨率输入框只能输入数字或删除键,并且不得超过屏幕分辨率
    Private Sub WindowWidth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles WindowWidth.KeyPress
        Try
            If WindowWidth.SelectionStart.ToString = 0 AndAlso e.KeyChar = Chr(48) Then
                e.Handled = True
            End If
            If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) Then
                e.Handled = True
            End If
            If Char.IsDigit(e.KeyChar) AndAlso Val(WindowWidth.Text) = ScreenSize.Width Then
                WindowWidth.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Width KeyPress Error")
        End Try
    End Sub

    Private Sub WindowWidth_TextChanged(sender As Object, e As EventArgs) Handles WindowWidth.TextChanged
        If Val(WindowWidth.Text) > ScreenSize.Width Then
            WindowWidth.Text = ScreenSize.Width
        End If
    End Sub

    Private Sub WindowWidth_Leave(sender As Object, e As EventArgs) Handles WindowWidth.Leave
        WindowWidth.Text = Val(WindowWidth.Text)
        If Val(WindowWidth.Text) < 100 Then
            WindowWidth.Text = 100
        End If
    End Sub

    Private Sub WindowHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles WindowHeight.KeyPress
        Try
            If WindowHeight.SelectionStart.ToString = 0 AndAlso e.KeyChar = Chr(48) Then
                e.Handled = True
            End If
            If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = Chr(8)) Then
                e.Handled = True
            End If
            If Char.IsDigit(e.KeyChar) AndAlso Val(WindowHeight.Text) = ScreenSize.Height Then
                WindowHeight.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Height KeyPress Error")
        End Try
    End Sub

    Private Sub WindowHeight_TextChanged(sender As Object, e As EventArgs) Handles WindowHeight.TextChanged
        If Val(WindowHeight.Text) > ScreenSize.Height Then
            WindowHeight.Text = ScreenSize.Height
        End If
    End Sub

    Private Sub WindowHeight_Leave(sender As Object, e As EventArgs) Handles WindowHeight.Leave
        If Val(WindowHeight.Text) < 100 Then
            WindowHeight.Text = 100
        End If
    End Sub

    Private Sub WindowedMode_CheckedChanged(sender As Object, e As EventArgs) Handles WindowedMode.CheckedChanged
        CheckRegValue(windowWidthKey)
        CheckRegValue(windowHeightKey)
        CheckRegValue(graphQualityKey)
    End Sub

    Private Sub WLVersionLabel_Click(sender As Object, e As EventArgs) Handles WLVersionLabel.Click
        'Process.Start("zaap://app/games/game/waven/main?launch")
    End Sub
End Class
