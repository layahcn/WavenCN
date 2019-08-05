Imports System.IO
Imports System.Net

Public Class WavenLauncher
    Const VersionWL As UInt32 = 20190802  ' 汉化启动器版本号
    Dim bFormDragging As Boolean = False    ' 判断窗体是否被拖动
    Dim oPointClicked As Point  ' 记录鼠标拖动位置
    Dim PanelVisible As Boolean = False   ' 设置界面默认隐藏
    Dim CloseForm As UShort = 0
    Dim LocAL As Boolean = False   '默认不汉化战网
    Dim LocGM As Boolean = True   '预设用户设置条目
    Dim ALDir As String '存储战网路径
    Dim GMDir As String  '存储游戏路径
    Dim VersionAL As String ' 存储战网汉化适用战网版本号
    Dim DownloadClient As New WebClient  '用于下载资源
    ReadOnly DefaultFileAddress As String = Application.StartupPath  '默认文件下载位置为同目录
    Dim DownloadFilePath As String  '正在下载文件的本地存储路径
    Dim DownloadFileName As String  '正在下载文件的名称


    Private Enum StartStatus As Byte  '用于改变开始游戏按钮文本与行为
        DownloadAL = 0
        StartAL = 1
        LocGM = 2
        Setdir = 3
        Quit = 4
    End Enum
    Private Sub WavenLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 窗体载入时的动作
        Try
            Visible = False
            Opacity = 0  '先隐藏窗体，等全部控件刷新完后再显示，避免控件背景重绘造成的闪烁
            'ToolTip1.SetToolTip(ALVersionLabel, "点击下载Ankama Launcher官方客户端")
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
                        My.Settings.CloseForm = 0
                End Select
                Select Case My.Settings.LocAL
                    Case True, False
                        LocAL = My.Settings.LocAL
                    Case Else
                        My.Settings.LocAL = True
                End Select
                Select Case My.Settings.LocGame
                    Case True, False
                        LocGM = My.Settings.LocGame
                    Case Else
                        My.Settings.LocGame = True
                End Select
                'CheckFileExisting(My.Settings.ALDir) '验证路径合法性
                'ALDir = My.Settings.ALDir
                ALDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\AppData\Local\Programs\zaap\Ankama Launcher.exe"
                '直接设置战网路径，因为安装时根本选不了路径，都是默认安装在这路径下的
                If Not IO.File.Exists(ALDir) Then  '检测是否安装战网
                    ButtonStatus(StartStatus.DownloadAL)  '路径下不存在战网则按钮显示下载战网

                End If
                CheckFileExisting(My.Settings.GMDir)  '验证游戏路径合法性
                GMDir = My.Settings.GMDir

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Read Settings Error")
            End Try
            Try
                If CheckProcessRunning("AL") Then '检测战网运行状态

                    If IO.File.Exists(GMDir) Then
                        If LocGM Then  '检测用户是否要汉化游戏，默认要
                            ButtonStatus(StartStatus.LocGM)   '按钮显示汉化游戏
                        Else
                            ButtonStatus(StartStatus.Quit)  '显示退出程序
                            LayoutLabel("不汉化游戏你开我作甚！哼！")
                        End If
                    Else
                        ButtonStatus(StartStatus.Setdir)  '显示设置路径
                    End If
                Else
                    ButtonStatus(StartStatus.StartAL)  '战网没运行则显示启动战网
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ChangeButtonStatus Error")
            End Try
            Try
                AddHandler DownloadClient.DownloadProgressChanged, AddressOf ShowDownProgress
                AddHandler DownloadClient.DownloadFileCompleted, AddressOf DownloadFileCompleted
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "AddHandler Error")
            End Try
            CheckVersion()
            ' 调用检查版本过程
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

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles ALVersionLabel.Click

        Try
            '直接调用浏览器下载Ankama Launcher
            'Process.Start("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe")
            '测试用WebClint类的DownloadFile方法下载
            DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
            DownloadFile("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe", "Ankama_Launcher-Setup.exe")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Download Ankama Launcher Error")
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        ' 根据按钮状态执行不同过程
        ButtonAction(True)
        ButtonAction(False)

    End Sub

    Private Sub ButtonStatus(Status As StartStatus)
        Try
            Select Case Status
                Case StartStatus.DownloadAL
                    StartButton.Text = "下载战网"
                    LayoutLabel("请点击下载战网，安装好战网后再打开本程序", "提示：")
                Case StartStatus.StartAL
                    StartButton.Text = "启动战网"
                Case StartStatus.LocGM
                    StartButton.Text = "汉化游戏"
                    LayoutLabel("请检查游戏是否处于最新状态后再汉化", "提示：")
                Case StartStatus.Setdir
                    StartButton.Text = "设置路径"
                    LayoutLabel("请在设置里选择游戏路径，若未安装请用前往战网安装", "提示：")
                Case StartStatus.Quit
                    StartButton.Text = "退出程序"
                    LayoutLabel("可以关闭汉化启动器了，下次启动战网前请先开本程序", "提示：")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ButtonStatus Error")
        End Try

    End Sub

    Private Sub ButtonAction(Optional Action As Boolean = False)
        '按钮动作，False表示只改变按钮状态

        If IO.File.Exists(ALDir) Then
            '判断战网是否存在
            Try
                If CheckProcessRunning("AL") Then  '检测战网是否运行

                Else

                    If LocAL Then
                        If Action Then

                        End If

                    End If
                    Process.Start(ALDir)
                End If

                'DownloadFile("https://github.com/layahcn/WavenCN/raw/master/en.json", "en.json")

                Process.Start(ALDir)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "战网启动失败")
            End Try
        Else
            '下载战网
            DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
            DownloadFile("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe", "Ankama_Launcher-Setup.exe")


        End If

    End Sub
    Private Sub AfterDownload()
        Try
            If DownloadFileName = "Ankama_Launcher-Setup.exe" Then  '如果成功下载战网则直接打开
                Try
                    Process.Start(DownloadFilePath)
                    Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "打开战网安装文件失败")
                End Try
            End If
            If DownloadFileName = "en.json" Then  '如果是战网的汉化下载完成
                Try  '替换战网汉化文件


                    Dim LocALpath = Path.GetDirectoryName(ALDir) & "\resources\static\langs"
                    LayoutLabel(LocALpath & "\en.json", "汉化战网文件中：")
                    ReplaceFile(LocALpath, "en.json")
                    Process.Start(ALDir)
                    LayoutLabel("汉化战网成功，启动战网")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "汉化战网失败")
                End Try

            End If


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
                        Case Else
                            CloseForm = 0
                            CloseForm0.Checked = True
                            Exit Select
                    End Select
                    If LocAL = True Then
                        LocALCheck.Checked = True
                    Else
                        LocAL = False
                    End If
                    If LocGM = True Then
                        LocGameCheck.Checked = True
                    End If
                    'If ALDir <> "" Then
                    '    LabelDirAL.Text = ALDir
                    'End If
                    If GMDir <> "" Then
                        LabelDirGM.Text = GMDir
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Get Settings Error")
                    CloseForm0.Checked = True
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
                        With My.Settings
                            .CloseForm = CloseForm '保存最小化的操作
                            .LocAL = LocAL '保存是否汉化启动战网
                            .LocGame = LocGM '保存是否汉化启动游戏
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
            Opacity = 0
            Show()   '显示主窗体
            Focus()  '前台窗体
            WindowState = FormWindowState.Normal   '正常化窗体，避免仍处于最小化到任务栏
            SysTrayIcon.Visible = False   '隐藏系统托盘小图标
            Timer1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DisplayForm Error")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '计时器只是作为一个窗体加载完成触发的入口
        Opacity = 1
        Timer1.Enabled = False
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
            Select Case LaunchWhat
                Case "AL"
                    With OpenFileDialog1
                        .Title = "选择Ankama Launcher战网路径"
                        .Filter = "Ankama战网|Ankama Launcher.exe"
                    End With
                    If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        '路径合法则存储
                        LabelDirAL.Text = OpenFileDialog1.FileName
                        ALDir = OpenFileDialog1.FileName
                    End If
                Case "GM"
                    With OpenFileDialog1
                        .Title = "选择Waven游戏路径"
                        .Filter = "Waven游戏|Waven.exe"
                    End With
                    If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        '路径合法则存储
                        LabelDirGM.Text = OpenFileDialog1.FileName
                        GMDir = OpenFileDialog1.FileName
                    End If
            End Select
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

    Private Sub DownloadFile(ByVal url As String, ByVal filename As String)
        '下载文件
        Try
            If DownloadClient.IsBusy = False Then
                ToolTip1.SetToolTip(StatusLabel, "点击取消下载")
                DownloadFileName = filename
                DownloadFilePath = $"{DefaultFileAddress}\{DownloadFileName}"
                LayoutLabel(DownloadFilePath, "下载中(0%)：")
                ProgressBar1.Value = 0
                DownloadClient.DownloadFileAsync(New Uri(url), DownloadFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DownloadFile Error")
        End Try


    End Sub

    Private Sub ShowDownProgress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        '显示下载进度
        Try
            Invoke(New Action(Of Integer)(Sub(i) ProgressBar1.Value = i), e.ProgressPercentage)
            LayoutLabel(DownloadFilePath, "下载中(" & ProgressBar1.Value & "%)：")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ShowDownProgress Error")
        End Try

    End Sub

    Sub DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        '下载完成
        Try
            If ProgressBar1.Value = 100 Then
                LayoutLabel(DownloadFilePath, "下载成功：")
                AfterDownload()
            Else
                LayoutLabel(DownloadFilePath, "下载失败：")
            End If
            ToolTip1.SetToolTip(StatusLabel, "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DownloadData Not Completed Error")
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
        '此事件仅供测试用
        'CheckProcessRunning("AL")
        'CheckProcessRunning("GM")
        'ProgressBar1.Value = 50
        '战网汉化文件地址 https://github.com/layahcn/WavenCN/raw/master/en.json
        'DownloadFile("https://github.com/layahcn/WavenCN/raw/master/en.json", "en.json")
        'Process.Start(ALDir)
        'LayoutLabel("汉化已完成，正在返回Ankama Launcher")
        'StartButton.Enabled = False
        'DFileCN("战网安装文件", "Ankama_Launcher-Setup.exe")
        'DFileCN("战网汉化文件", "en.json")

    End Sub

    Private Sub DFileCN(ByVal FileNameCN As String, ByVal filename As String)
        '官网的获取网页文字的方法，没啥改动，恐怕很容易报错
        Try
            Dim request As WebRequest =
              WebRequest.Create("http://layah.lofter.com/")  '用轻博客获取版本号等内容
            ' If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.  
            LayoutLabel(CType(response, HttpWebResponse).StatusDescription， "连接更新服务器：")
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
                    responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf(FileNameCN) + FileNameCN.Length + 1)
                    Console.WriteLine(responseFromServer)  '测试输出
                    responseFromServer = responseFromServer.Substring(0, 16)
                    TestLabel2.Text = responseFromServer   '测试输出
                    DownloadFile($"https://attachments-cdn.shimo.im/{responseFromServer}/{filename}", filename)
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
    Private Sub LayoutLabel(ByVal Text As String, Optional ByVal KeyWord As String = "状态：")
        '显示当前状态信息提示
        StatusLabel.Text = KeyWord & Text
    End Sub

    Private Sub StatusLabel_Click(sender As Object, e As EventArgs) Handles StatusLabel.Click
        DownloadClient.CancelAsync()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UpdateLoc.Click
        DownloadClient.Proxy = New WebProxy()  '下载一定要加这句，不用代理！！！
        DownloadFile("https://github.com/layahcn/WavenCN/raw/master/en.json", "en.json")
        'DownloadFile("https://attachments-cdn.shimo.im/5T4dV8xSX40DjREE/en.json", "en.json")


    End Sub
End Class
