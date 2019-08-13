Imports System.IO
Imports System.IO.Compression  '解压文件用
Imports System.Net

Public Class WavenLauncher
    Const VersionWL As UInteger = 201908131 '汉化启动器版本号，跟随发布版本
    Dim NewVersionWL As UInteger  '检测最新汉化启动器版本号
    Dim NewVersionCN As UInteger  '检测最新游戏汉化文本版本号
    Dim wlneedtoupdate = False  '汉化启动器是否需要更新
    Dim cnneedtoupdate = False  '游戏汉化文本是否需要更新
    Dim bFormDragging As Boolean = False    '判断窗体是否被拖动
    Dim oPointClicked As Point  '记录鼠标拖动位置
    Dim PanelVisible As Boolean = False   '设置界面默认隐藏
    Dim CloseForm As UShort = 0  '预设用户设置条目，默认叉叉关闭窗口
    Dim LocAL As Boolean = False   '默认不汉化战网
    Dim LocGM As Boolean = True   '默认汉化游戏
    Dim AutoUD As Boolean = True  '默认自动更新汉化
    Dim ALDir As String '存储战网启动路径
    Dim GMDir As String  '存储游戏启动路径
    Dim VersionAL As String  '存储战网汉化适用战网版本号
    Dim VersionCN As UInteger '存储游戏汉化文本本地版本号
    Dim DownloadClient As New WebClient  '用于下载资源
    ReadOnly DefaultFileAddress As String = Application.StartupPath _
                                            & "\WLDownload"  '默认文件下载目录
    ReadOnly tempUpdatePath As String = AppDomain.CurrentDomain.BaseDirectory _
                                        & "WLTemp\"  '默认软件更新文件临时下载目录
    Dim GameDataPath As String  '存储游戏安装目录
    Dim DownloadFilePath As String  '正在下载文件的本地存储路径
    Dim DownloadFileName As String  '正在下载文件的名称
    Dim mainAppExe As String = "WavenLauncher.exe"  '用于自爆更新的程序名
    Dim percentage As UShort = 0  '用于初始化进度条
    Dim FinishLocGM As Boolean = False  '存储游戏汉化状态
    Dim finishStartAL As Boolean = False  '存储战网经由汉化启动器启动状态
    Dim gameisrunning As Boolean = False  '存储游戏运行状态

    Private Enum StartStatus As Byte  '用于改变开始游戏按钮文本与行为
        DownloadAL = 0  '下载战网
        StartAL = 1  '启动战网
        LocGM = 2  '汉化游戏
        Setdir = 3  '设置路径
        Quit = 4  '退出程序
    End Enum

    Private Sub WavenLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 窗体载入时的动作
        Try
            Visible = False
            Opacity = 0  '隐式加载窗体以避免窗体背景重绘造成的控件闪烁
            VersionCN = My.Settings.VersionCN  '检查版本前先给当前汉化文本版本赋值
            CheckVersion()
            ' 调用检查版本过程
            WLVersionLabel.Text = WLVersionLabel.Text _
                                  & VersionWL
            VersionAL = My.Settings.VersionAL
            ALVersionLabel.Text = ALVersionLabel.Text _
                                  & VersionAL  ' 显示版本号
            Try   '获取用户设置
                Select Case My.Settings.CloseForm
                    Case 0, 1, 2
                        CloseForm = My.Settings.CloseForm
                    Case Else
                        My.Settings.CloseForm = 0  '若设置不合法取默认值
                End Select
                Select Case My.Settings.LocAL
                    Case True, False
                        LocAL = My.Settings.LocAL
                    Case Else
                        My.Settings.LocAL = True  '若设置不合法取默认值
                End Select
                Select Case My.Settings.LocGM
                    Case True, False
                        LocGM = My.Settings.LocGM
                    Case Else
                        My.Settings.LocGM = True  '若设置不合法取默认值
                End Select
                Select Case My.Settings.LocGM
                    Case True, False
                        AutoUD = My.Settings.AutoUD
                    Case Else
                        My.Settings.AutoUD = True  '若设置不合法取默认值
                End Select
                'CheckFileExisting(My.Settings.ALDir) '验证路径合法性
                'ALDir = My.Settings.ALDir
                ALDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) _
                        & "\AppData\Local\Programs\zaap\Ankama Launcher.exe"
                '直接设置战网路径，因为安装时根本选不了路径，都是默认安装在这路径下的
                CheckFileExisting(My.Settings.GMDir)  '验证游戏路径合法性，不合法取空值
                GMDir = My.Settings.GMDir
                If File.Exists(GMDir） Then
                    GameDataPath = Path.GetDirectoryName(GMDir)  '存储游戏目录
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Read Settings Error")
            End Try
            Try  '根据条件显示按钮状态
                If Not IO.File.Exists(ALDir) Then  '检测是否安装战网
                    ButtonStatus(StartStatus.DownloadAL)  '路径下不存在战网则按钮显示下载战网
                Else
                    If CheckProcessRunning("AL") Then '检测战网运行状态
                        If AutoUD AndAlso cnneedtoupdate Then DFileCN("游戏汉化文件",
                                                                      "Waven-zh-cn.zip",
                                                                      DefaultFileAddress)
                        '若勾选了自动更新汉化，则下载游戏的汉化文件
                        If IO.File.Exists(GMDir) Then
                            If LocGM Then  '检测用户是否要汉化游戏，默认为是
                                ButtonStatus(StartStatus.LocGM)   '按钮显示汉化游戏
                            Else
                                ButtonStatus(StartStatus.Quit)  '显示退出程序
                                LayoutLabel("不汉化游戏你开我作甚！哼！", "(小声：")
                            End If
                        Else
                            ButtonStatus(StartStatus.Setdir)  '显示设置路径
                        End If
                    Else
                        ButtonStatus(StartStatus.StartAL)  '战网没运行则显示启动战网
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ChangeButtonStatus Error")
            End Try
            Try
                AddHandler DownloadClient.DownloadProgressChanged, AddressOf ShowDownProgress  '显示进度
                AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadFileCompleted  '下载完成
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AddHandler Error")
            End Try
            ToolTip1.SetToolTip(FormTitle, "点击访问Waven汉化启动器官网")  '左上角标题提示
            ToolTip1.SetToolTip(ALVersionLabel, "若需要修复战网的错误可以重新点击下载战网")  '战网版本号提示
            Show()  '显示窗体。以下防止自爆更新后窗体未正常前台
            Focus()  '前台窗体
            WindowState = FormWindowState.Normal   '正常化窗体，避免仍处于最小化到任务栏
            Timer1.Enabled = True  '加载完窗体再触发计时器延时显示窗体
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Load Form Error")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles QuitForm.Click
        '点击右上角退出程序叉叉
        Try
            Select Case CloseForm
                Case 0
                    Close()  '关闭主窗体=退出程序
                    'Application.Exit()   '直接退出程序而不触发窗体Closing事件
                Case 1
                    WindowState = FormWindowState.Minimized  '最小化窗体
                Case 2
                    Hide()
                    SysTrayIcon.Visible = True  '隐藏窗体，最小化到系统托盘
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Close Form Button Error")
        End Try
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        '位于窗体内鼠标按下
        bFormDragging = True
        oPointClicked = New Point(e.X, e.Y)
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        '鼠标松开
        bFormDragging = False
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
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
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Move Form Error")
        End Try
    End Sub

    Private Sub CheckVersion()
        '检测软件和汉化文本的版本
        Try
            LayoutLabel("获取版本信息中")
            GetVersion("软件版本号", NewVersionWL)
            GetVersion("游戏汉化版本", NewVersionCN)
            If NewVersionWL > VersionWL Then
                '若获取到版本号比当前软件版本号要新（如201908051>201908011
                WLVerStatus.Text = "点击下载最新版"
                wlneedtoupdate = True  '设置需要更新以便点击label时为下载
                Timer2.Enabled = True  '开启红黄闪烁
            ElseIf NewVersionWL = VersionWL Then
                WLVerStatus.Text = "已是最新版"
            Else
                WLVerStatus.Text = "获取更新失败，点击重试"
            End If
            If NewVersionCN > VersionCN Then
                '若获取到有最新汉化文本
                cnneedtoupdate = True
            ElseIf NewVersionCN = VersionCN Then
                UpdateCN.Text = "汉化已是最新"
                UpdateCN.Enabled = False
            Else
                UpdateCN.Text = "重测汉化更新"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckVersion Error")
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles ALVersionLabel.Click
        '测试用
        Try
            '直接调用浏览器下载Ankama Launcher
            'Process.Start("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe")
            '测试用WebClint类的DownloadFile方法下载
            'DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
            'DownloadFile("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
            DFileCN("战网安装文件", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Download Ankama Launcher Error")
        End Try
    End Sub '测试用

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        ' 根据按钮状态执行不同过程
        ButtonAction(True)  '点击执行过程
        ButtonAction(False)  '更改按钮状态
    End Sub

    Private Sub ButtonStatus(Status As StartStatus)
        '更改按钮状态以及输出相应的提示文字
        Try
            Select Case Status
                Case StartStatus.DownloadAL
                    StartButton.Text = "下载战网"
                    LayoutLabel("请点击下载战网，安装好战网后再打开本程序", "提示：")
                Case StartStatus.StartAL
                    StartButton.Text = "启动战网"
                    LayoutLabel("程序待命中")
                Case StartStatus.LocGM
                    StartButton.Text = "汉化游戏"
                    If gameisrunning Then
                        LayoutLabel("游戏正在运行中，请关闭后再试", "提示：")
                    Else
                        LayoutLabel("请检查游戏是否处于最新状态后再汉化", "提示：")
                    End If
                Case StartStatus.Setdir
                    StartButton.Text = "设置路径"
                    LayoutLabel("请在设置里选择游戏路径，若未安装请用前往战网安装", "提示：")
                Case StartStatus.Quit
                    StartButton.Text = "退出程序"
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ButtonStatus Error")
        End Try

    End Sub

    Private Sub ButtonAction(Optional Action As Boolean = False)
        '按钮动作，False表示只改变按钮状态
        Try
            If IO.File.Exists(ALDir) Then
                '判断战网是否存在
                Try
                    If CheckProcessRunning("AL") Then  '检测战网是否运行
                        If IO.File.Exists(GMDir) Then  '检测游戏路径是否已选择
                            If LocGM Then  '检测用户是否要汉化游戏，默认要
                                If FinishLocGM Then  '若已经进行了汉化过程
                                    ButtonStatus(StartStatus.Quit)
                                    If Action Then Close()  '此时如果再点就是退出程序了
                                Else  '若未进行汉化过程
                                    ButtonStatus(StartStatus.LocGM)
                                    If Action Then LocGame()  '则进行汉化动作
                                End If
                            Else  '若不汉化游戏
                                '啥都不干那就拜拜了您内~
                                ButtonStatus(StartStatus.Quit)
                                If Action Then Close()  '执行关闭窗口
                            End If
                        Else   '若未选择游戏路径
                            ButtonStatus(StartStatus.Setdir)
                            If Action Then OpenOrSaveSetting(True)  '保持设置窗口开启让用户先选择游戏路径
                        End If
                    Else  '若战网未运行
                        If LocAL Then  '若需要汉化战网
                            If Action Then '点击启动战网自动汉化
                                Try
                                    DFileCN("战网汉化文件", "en.json", DefaultFileAddress)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "下载战网汉化文件失败")
                                End Try
                                Return
                            End If
                        Else  '若不需要汉化战网
                            If finishStartAL Then  '若已经启动过了战网
                                If IO.File.Exists(GMDir) Then  '检测游戏路径是否已选择
                                    If LocGM Then  '检测用户是否要汉化游戏，默认要
                                        ButtonStatus(StartStatus.LocGM)
                                        If Action Then LocGame()
                                    Else  '若不汉化游戏
                                        '啥都不干那就拜拜了您内~
                                        ButtonStatus(StartStatus.Quit)
                                        If Action Then Close()  '执行关闭窗口
                                    End If
                                Else   '若未选择游戏路径
                                    ButtonStatus(StartStatus.Setdir)
                                    If Action Then OpenOrSaveSetting(True)  '保持设置窗口开启让用户先选择游戏路径
                                End If
                            Else  '若未启动战网
                                If Action Then '则恢复启动英文版
                                    Try
                                        DFileCN("战网原版文件", "en.json", DefaultFileAddress)
                                    Catch ex As Exception
                                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "下载战网汉化文件失败")
                                    End Try
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "战网启动失败")
                End Try
            Else
                '下载战网
                If Action Then
                    'DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
                    'DownloadFile("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
                    DFileCN("战网安装文件", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ButtonAction Error")
        End Try
    End Sub

    Private Sub LocGame()
        '点击汉化游戏按钮
        Try
            If CheckProcessRunning("GM") Then  '若游戏已运行
                gameisrunning = True
                LayoutLabel("请关闭游戏后再进行汉化", "提示：")
                Return
            Else  '若游戏未运行
                gameisrunning = False
                Try
                    If File.Exists(GMDir） Then
                        GameDataPath = Path.GetDirectoryName(GMDir)
                        ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
                        '调用解压zip方法
                        FinishLocGM = True
                        LayoutLabel("汉化游戏成功，返回战网点击Play或开始游戏")
                        Process.Start(ALDir)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExtractFiles Error")
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "LocGame Error")
        End Try
    End Sub

    Private Sub ExZip(ByVal ziplocation As String, ByVal zipname As String, ByVal expath As String, Optional ByVal needbackup As Boolean = True)
        '解压zip文件方法，覆盖替换方式，无文件夹则创建文件夹，无文件新建空文件进行替换，默认不备份
        Try
            Dim zipPath As String = $"{ziplocation}\{zipname}"  'zip源文件地址
            'TestLabel2.Text = zipPath
            LayoutLabel(zipPath, "解压中：")  '输出label显示正在解压的文件
            If IO.File.Exists(zipPath) Then  '若zip文件存在才进行解压
                expath = Path.GetFullPath(expath)  '获取目录的绝对路径
                If Not expath.EndsWith(Path.DirectorySeparatorChar.ToString(),
                                       StringComparison.Ordinal) Then
                    expath += Path.DirectorySeparatorChar  '目录结尾添加\
                End If
                Using archive As ZipArchive = ZipFile.OpenRead(zipPath)  '声明资源文件
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If Not Path.GetExtension(entry.FullName) = "" Then  '获取所有文件，排除目录
                            Dim destinationPath As String = Path.GetFullPath(Path.Combine(expath,
                                                                                          entry.FullName))  '设置输出路径
                            If Not System.IO.File.Exists(destinationPath) Then  '若目标文件不存在
                                If Not Directory.Exists(Path.GetDirectoryName(destinationPath)) Then  '若目标所在文件夹不存在
                                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath))  '则创建文件夹
                                End If
                                System.IO.File.Create(destinationPath).Dispose()  '创建空的目标文件，前提是目录存在
                            End If
                            If destinationPath.StartsWith(expath, StringComparison.Ordinal) Then
                                entry.ExtractToFile(destinationPath, True)  '将解压获得的文件替换目标文件
                            End If
                        End If
                    Next
                End Using
                LayoutLabel(zipPath, "解压成功：")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ExtractFiles Error")
        End Try
    End Sub

    Private Sub AfterDownload()
        '下载百分比之后的动作
        Try
            Select Case DownloadFileName
                Case "Ankama_Launcher-Setup.exe"  '如果成功下载战网则直接打开
                    Try
                        '添加一步确认，以免误点
                        If MsgBox("Ankama战网下载完成，需关闭本汉化启动器进行战网的安装" _
                                    & Chr(13) & Chr(10) &
                                  "【注意】安装Ankama战网将删去过去版本的战网",
                                  MsgBoxStyle.Exclamation _
                                  + MsgBoxStyle.OkCancel _
                                  + MsgBoxStyle.DefaultButton2,
                                  "即将安装Ankama战网") _
                           = MsgBoxResult.Ok Then
                            Process.Start(DownloadFilePath)
                            Close()
                        Else
                            Return
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "打开战网安装文件失败")
                    End Try
                Case "en.json"  '如果是战网的汉化下载完成
                    Try  '替换战网汉化文件
                        Dim LocALpath = Path.GetDirectoryName(ALDir) & "\resources\static\langs"
                        LayoutLabel(LocALpath & "\en.json", "汉化战网文件中：")
                        ReplaceFile(LocALpath, "en.json")
                        finishStartAL = True
                        Process.Start(ALDir)
                        LayoutLabel("汉化战网成功，启动战网")
                        ButtonAction(False)  '改变按钮状态
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "汉化战网失败")
                    End Try
                Case "Waven-zh-cn.zip"
                    LayoutLabel("已成功更新最新游戏汉化文件 - " & NewVersionCN)
                    My.Settings.VersionCN = NewVersionCN
                    VersionCN = NewVersionCN  '存储游戏汉化文件版本标识到用户设置
                    My.Settings.Save()
                    CheckVersion()  '再调用一次检测版本以让按钮变灰
                Case mainAppExe  '如果是下载软件
                    '自爆程序已启动
                    KillSelfThenRun()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AfterDownload Error")
        End Try
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles OpenSettings.Click
        '点击打开或关闭设置面板
        OpenOrSaveSetting(False)
    End Sub

    Private Sub OpenOrSaveSetting(ByVal KeepOpening As Boolean)
        'KeepOpening判断是否需要一直打开设置面板（因为战网不存在所以需要一直开着）
        Try
            If PanelVisible = False Then
                SettingPanel.Visible = True  '显示设置面板
                OpenSettings.Text = "保存"
                PanelVisible = True
                Try   '读取设置显示在设置界面
                    Select Case CloseForm
                        Case 0
                            CloseForm0.Checked = True
                        Case 1
                            CloseForm1.Checked = True
                        Case 2
                            CloseForm2.Checked = True
                    End Select
                    If LocAL = True Then
                        LocALCheck.Checked = True
                    End If
                    If LocGM = True Then
                        LocGameCheck.Checked = True
                    End If
                    If AutoUD = True Then
                        AutoUDCheck.Checked = True
                    End If
                    'If ALDir <> "" Then
                    '    LabelDirAL.Text = ALDir
                    'End If
                    If GMDir <> "" Then
                        LabelDirGM.Text = GMDir
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Get Settings Error")
                End Try
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
                        If LocAL <> My.Settings.LocAL Or LocGM <> My.Settings.LocGM Then
                            '若更改了汉化选项，则提示重启
                            ButtonAction(False)
                            LayoutLabel("部分设置无法及时生效，你可能需要重启所有程序", "注意：")
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
                            .Save()  '保存所有设置
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save Settings Error")
                    End Try
                    SettingPanel.Visible = False  '隐藏设置面板
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
            Opacity = 0  '隐式加载窗体以避免窗体背景重绘造成的控件闪烁
            Show()   '显示主窗体
            Focus()  '前台窗体
            WindowState = FormWindowState.Normal   '正常化窗体，避免仍处于最小化到任务栏
            SysTrayIcon.Visible = False   '隐藏系统托盘小图标
            Timer1.Enabled = True  '恢复窗体显示
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DisplayForm Error")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '计时器只是作为一个窗体加载完成触发的入口
        Opacity = 1  '恢复透明度显示窗体
        Timer1.Enabled = False  '关闭计时器
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Try
            Select Case m.Msg
                Case &H5
                    ' 为避免加载窗体或还原窗体时绘制出现黑框，处理Windows消息
                    'change size: WM_SIZE
                    If True Then
                        Select Case m.WParam.ToInt32()
                            Case 0
                                'SIZE_RESTORED
                                Timer1.Enabled = True
                            Case 1
                                'SIZE_MINIMIZED
                                Opacity = 0
                            Case 2
                                'SIZE_MAXIMIZED
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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        '系统托盘图标右键菜单，打开主界面
        DisplayForm()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        '系统托盘图标右键菜单，关闭程序
        Close()
    End Sub

    Private Sub SetDir(ByVal LaunchWhat As String)
        '选择战网或游戏路径
        Try
            'Select Case LaunchWhat
            '    Case "AL"
            '        With OpenFileDialog1
            '            .Title = "选择Ankama Launcher战网路径"
            '            .Filter = "Ankama战网|Ankama Launcher.exe"
            '        End With
            '        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            '            '路径合法则存储
            '            LabelDirAL.Text = OpenFileDialog1.FileName
            '            ALDir = OpenFileDialog1.FileName
            '        End If
            '    Case "GM"
            With OpenFileDialog1
                .Title = "选择Waven游戏路径"
                .Filter = "Waven游戏|Waven.exe"
            End With
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                '路径合法则存储
                LabelDirGM.Text = OpenFileDialog1.FileName
                GMDir = OpenFileDialog1.FileName
            End If
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Set Path Error")
        End Try
    End Sub

    'Private Sub LabelDirAL_Click(sender As Object, e As EventArgs) Handles LabelDirAL.Click
    '点击选择战网路径
    '    SetDir("AL")
    'End Sub

    'Private Sub ButtonDirAL_Click(sender As Object, e As EventArgs) Handles ButtonDirAL.Click
    '点击选择战网路径
    '    SetDir("AL")
    'End Sub

    Private Sub LabelDirGM_Click(sender As Object, e As EventArgs) Handles LabelDirGM.Click
        '点击选择游戏路径
        SetDir("GM")
    End Sub

    Private Sub ButtonDirGM_Click(sender As Object, e As EventArgs) Handles ButtonDirGM.Click
        '点击选择游戏路径
        SetDir("GM")
    End Sub

    Private Sub CheckFileExisting(ByRef Dir As String)
        '验证路径合法性
        Try
            If Not IO.File.Exists(Dir) Then
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
            Dim IsRunning As Boolean = False
            Dim ProcessName As String  '程序名
            Dim ProcessPath As String  '程序路径
            Dim ProcessList() As Process
            If Program = "AL" Then
                ProcessName = "Ankama Launcher"
                ProcessPath = ALDir
            ElseIf Program = "GM" Then
                ProcessName = "Waven"
                ProcessPath = GMDir
            Else
                Return False
                Exit Try
            End If
            '测试用
            TestLabel1.Text = "设定路径- " & ProcessPath
            TestLabel2.Text = ""
            '测试用
            ProcessList = Process.GetProcessesByName(ProcessName)
            '获取程序系统进程列表
            Dim LaunchProcess As Process
            For Each LaunchProcess In ProcessList
                '测试用
                TestLabel2.Text += "内存路径- " & LaunchProcess.MainModule.FileName & Chr(13) & Chr(10)
                '测试用
                If LaunchProcess.MainModule.FileName.Equals(  '忽略大小写比较路径
                    ProcessPath, StringComparison.OrdinalIgnoreCase) Then
                    IsRunning = True
                    Exit For
                End If
            Next
            Return IsRunning
        Catch ex32 As ComponentModel.Win32Exception
            TestLabel2.Text = "Win32Exception报错"
            '32位程序读取64位程序时报错，应将debug中选any cpu，并在项目设置里取消勾选首选32位
            '另外无法获取管理员权限运行进程的路径时也会报错
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "CheckProcessRunning Error")
            Return False
        End Try
    End Function

    Private Sub DownloadFile(ByVal url As String, ByVal filename As String, ByVal savepath As String)
        '下载文件
        Try
            If Not Directory.Exists(savepath) Then  '若下载路径不存在文件夹则创建
                Directory.CreateDirectory(savepath)
            End If
            If DownloadClient.IsBusy = False Then  '若未在下载中才开始下载，避免报错
                ToolTip1.SetToolTip(StatusLabel, "点击取消下载")  '可点击输出label取消下载
                DownloadFileName = filename  '要下载的文件名
                DownloadFilePath = $"{savepath}\{DownloadFileName}"  '要保存的路径，包含文件名
                LayoutLabel(DownloadFilePath, "下载中(0%)：")  '开始下载时初始化输出label
                'ProgressBar1.Value = 0  '开始下载时初始化进度条
                SetPanelPB(0)  '开始下载时初始化进度条
                DownloadClient.DownloadFileAsync(New Uri(url), DownloadFilePath)  '开始异步下载
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DownloadFile Error")
        End Try
    End Sub

    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        '显示下载进度
        Try
            Invoke(New Action(Of Integer)(Sub(i) percentage = i), e.ProgressPercentage)
            '多线程实时显示下载进度
            SetPanelPB(percentage)
            LayoutLabel(DownloadFilePath, "下载中(" _
                                          & percentage _
                                          & "%)：")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ShowDownProgress Error")
        End Try
    End Sub

    Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        '下载完成
        Try
            If percentage = 100 Then  '异步任务进度满则说明文件下载成功
                LayoutLabel(DownloadFilePath, "下载成功：")
                AfterDownload()  '根据下载成功的文件执行不同动作
            Else
                LayoutLabel(DownloadFilePath, "下载失败：")
            End If
            ToolTip1.SetToolTip(StatusLabel, "")  '重置输出label的提示泡泡
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DownloadData Not Completed Error")
        End Try
    End Sub

    Private Sub SetPanelPB(ByVal percentage As UShort)
        Try
            PanelProgress.Size = New Size((Math.Truncate(percentage) * PanelProgressBar.Width) / 100, 10)
            '用两个Panel嵌套在一起代替ProgressBar，Math.Truncate为取整函数
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "SetPanelPB Error")
        End Try
    End Sub

    Private Sub ReplaceFile(ByVal tFilePath As String, ByVal FileName As String)
        '替换文件
        Try
            Dim oPath As String = $"{DefaultFileAddress}/{FileName}"
            Dim tPath As String = $"{tFilePath}/{FileName}"
            'Dim bakPath As String = oPath & ".bak" '备份文件后加bak
            Dim oFile As FileInfo = New FileInfo(oPath)
            Dim tFile As FileInfo = New FileInfo(tPath)
            'Dim bakFile As FileInfo = New FileInfo(bakPath)
            If IO.File.Exists(oPath) Then
                'bakFile.Delete()
                'tFile.CopyTo(bakPath) '备份要替换的文件
                tFile.Delete()
                oFile.CopyTo(tPath) '替换文件
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ReplaceFile Error")
        End Try
    End Sub

    'Private Sub RecoverFile(ByVal tFilePath As String, ByVal FileName As String)
    '    Try
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, "RecoverFile Error")
    '    End Try
    'End Sub

    Private Sub TestLabel1_Click(sender As Object, e As EventArgs) Handles TestLabel1.Click
        '测试用
        'DFileCN("战网安装文件", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
        'DFileCN("软件更新地址", mainAppExe, Application.StartupPath & "\Temp")
        'DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
        'DownloadFile("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe", "Ankama_Launcher-Setup.exe", DefaultFileAddress)
        'ExZip(DefaultFileAddress, "Waven-zh-cn.zip", GameDataPath)
        CheckProcessRunning("GM")
    End Sub

    Private Sub DFileCN(ByVal FileNameCN As String, ByVal filename As String, ByVal savepath As String)
        '官网的获取网页文字的方法，没啥改动，恐怕很容易报错
        '这个是通过获取文件的对应16位字符串来下载石墨文档的直链附件
        Try
            If Not Directory.Exists(savepath) Then
                Directory.CreateDirectory(savepath)
            End If
            Dim request As WebRequest =
              WebRequest.Create("http://layah.lofter.com/")  '用轻博客获取下载地址
            ' If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.  
            'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            ' Get the stream containing content returned by the server. 
            ' The using block ensures the stream is automatically closed.
            Using dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  
                Dim reader As New StreamReader(dataStream)
                ' Read the content.  
                Dim responseFromServer As String = reader.ReadToEnd()
                ' Display the content.  
                Dim LocALFileLink As String = ""
                If responseFromServer.Contains(FileNameCN) Then
                    responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf(FileNameCN) _
                                                                      + FileNameCN.Length _
                                                                      + 1)
                    responseFromServer = responseFromServer.Substring(0, 16)
                    'TestLabel2.Text = responseFromServer   '测试输出
                    DownloadFile($"https://attachments-cdn.shimo.im/{responseFromServer}/{filename}",
                                 filename,
                                 savepath)
                    '石墨文档的附件，比GitHub上载快多了
                End If
                'Console.WriteLine(responseFromServer)
            End Using
            ' Clean up the response.
            response.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DFileCN Error")
        End Try

    End Sub

    Private Sub GetVersion(ByVal nameCN As String, ByRef name As UInteger)
        '获取版本号，位数为9位数字，时间8位+补丁1位
        Try
            Dim request As WebRequest =
              WebRequest.Create("http://layah.lofter.com/")  '用轻博客获取版本号
            ' If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.  
            'LayoutLabel(CType(response, HttpWebResponse).StatusDescription， "连接服务器：")
            'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            ' Get the stream containing content returned by the server. 
            ' The using block ensures the stream is automatically closed.
            Using dataStream As Stream = response.GetResponseStream()
                ' Open the stream using a StreamReader for easy access.  
                Dim reader As New StreamReader(dataStream)
                ' Read the content.  
                Dim responseFromServer As String = reader.ReadToEnd()
                ' Display the content.  
                Dim LocALFileLink As String = ""
                If responseFromServer.Contains(nameCN) Then
                    responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf(nameCN) _
                                                                      + nameCN.Length _
                                                                      + 1)
                    'Console.WriteLine(responseFromServer)  '测试输出
                    responseFromServer = Val(responseFromServer.Substring(0, 9))
                    name = responseFromServer
                End If
                'Console.WriteLine(responseFromServer)
            End Using
            ' Clean up the response.
            response.Close()
            LayoutLabel("获取版本信息完成")
        Catch ex As Exception
            LayoutLabel(ex.Message & "。请检查网络连接。", "获取版本更新信息失败:")
        End Try
    End Sub

    Private Sub LayoutLabel(ByVal Text As String, Optional ByVal KeyWord As String = "状态：")
        '输出label方法显示当前状态信息提示
        StatusLabel.Text = KeyWord & Text
    End Sub

    Private Sub StatusLabel_Click(sender As Object, e As EventArgs) Handles StatusLabel.Click
        '点击输出label取消下载
        DownloadClient.CancelAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UpdateCN.Click
        'DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
        'DownloadFile("https://github.com/layahcn/WavenCN/raw/master/en.json", "en.json", DefaultFileAddress)
        'DownloadFile("https://attachments-cdn.shimo.im/5T4dV8xSX40DjREE/en.json", "en.json")
        'DFileCN("战网汉化文件", "en.json", DefaultFileAddress)
        If cnneedtoupdate Then DFileCN("游戏汉化文件", "Waven-zh-cn.zip", DefaultFileAddress)
    End Sub

    Private Sub KillSelfThenRun()   '自爆型更新程序，无需更改（或许
        Try
            Dim strXCopyFiles As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XCopyFiles.bat")
            Using swXcopy As StreamWriter = File.CreateText(strXCopyFiles)
                Dim strOriginalPath As String = tempUpdatePath.Substring(0, tempUpdatePath.Length - 1)
                swXcopy.WriteLine(String.Format("
                @echo off
                xcopy /y/s/e/v " & strOriginalPath & " " & Directory.GetCurrentDirectory() & "", AppDomain.CurrentDomain.FriendlyName))
            End Using
            Dim filename As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "killmyself.bat")
            Using bat As StreamWriter = File.CreateText(filename)
                bat.WriteLine(String.Format("
                @echo off
                :selfkill
                attrib -a -r -s -h ""{0}""
                del ""{0}""
                if exist ""{0}"" goto selfkill
                call XCopyFiles.bat
                del XCopyFiles.bat
                del /f/q " & tempUpdatePath + Environment.NewLine & " rd " + tempUpdatePath + Environment.NewLine & " start " + mainAppExe + Environment.NewLine & " del %0 ", AppDomain.CurrentDomain.FriendlyName))
            End Using
            Dim info As ProcessStartInfo = New ProcessStartInfo(filename)
            info.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(info)
            Environment.[Exit](0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Update SELF Error")
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
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
                DFileCN("软件更新地址", mainAppExe, Application.StartupPath & "\WLTemp")
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
End Class
