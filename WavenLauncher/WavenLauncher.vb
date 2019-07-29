Imports System.ComponentModel
Imports System.Linq
Public Class WavenLauncher
    Const VersionWL As UInt32 = 20190729  ' 汉化启动器版本号
    Const VersionAL As String = "2.9.20"  ' 适用战网版本号
    Dim bFormDragging As Boolean = False    ' 判断窗体是否被拖动
    Dim oPointClicked As Point  ' 记录鼠标拖动位置
    Dim PanelVisible As Boolean = False   ' 设置界面默认隐藏
    Dim CloseForm As UShort = 0
    Dim LocAL As Boolean = True
    Dim LocGame As Boolean = True   '预设用户设置条目

    Private Sub WavenLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 窗体载入时的动作
        Try
            ToolTip1.SetToolTip(ALVersion, "点击下载Ankama Launcher官方客户端")
            WLVersion.Text = WLVersion.Text _
                             & VersionWL
            ALVersion.Text = ALVersion.Text _
                             & VersionAL  ' 显示版本号
            CloseForm = My.Settings.CloseForm
            LocAL = My.Settings.LocAL
            LocGame = My.Settings.LocGame  ' 获取用户设置
            CheckVersion()
            ' 调用检查版本函数
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Load Form Error")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles QuitForm.Click
        Try   ' 右上角退出程序叉叉
            Select Case CloseForm
                Case 0
                    Close()
                Case 1
                    WindowState = FormWindowState.Minimized
                Case 2
                    Hide()
                    SysTrayIcon.Visible = True
                    SysTrayIcon.ShowBalloonTip(3000, "我在这儿", "我在这儿", ToolTipIcon.Info)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Close Form Button Error")
        End Try
    End Sub


    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        bFormDragging = True
        oPointClicked = New Point(e.X, e.Y)
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        bFormDragging = False
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles ALVersion.Click
        ' 直接调用浏览器下载Ankama Launcher
        Try
            Process.Start("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Download Ankama Launcher Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles StartGame.Click
        MsgBox("咕咕咕，在做了")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles StartAL.Click
        ' 汉化Ankama Launcher
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Localisation Error")
        End Try
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles OpenSettings.Click
        Try
            If PanelVisible = False Then
                SettingPanel.Visible = True
                OpenSettings.Text = "保存设置"
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
                    If LocGame = True Then
                        LocGameCheck.Checked = True
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Get CloseFormAction Error")
                    CloseForm0.Checked = True
                End Try
            Else
                Try
                    Dim rButton As RadioButton =   '判断GroupBox控件中是哪一个单选按钮被选中
                            CloseAction.Controls _
                            .OfType(Of RadioButton) _
                            .FirstOrDefault(Function(r) r.Checked = True)
                    CloseForm = rButton.Name.Substring(9)  '截取单选按钮的编号
                    LocAL = LocALCheck.Checked
                    LocGame = LocGameCheck.Checked
                    My.Settings.CloseForm = CloseForm '保存最小化的操作
                    My.Settings.LocAL = LocAL '保存是否汉化启动战网
                    My.Settings.LocGame = LocGame '保存是否汉化启动游戏
                    My.Settings.Save()  '保存所有设置
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Save CloseFormAction Error")
                End Try
                SettingPanel.Visible = False
                OpenSettings.Text = "打开设置"
                PanelVisible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Settings Error")
        End Try
    End Sub

    Private Sub WavenLauncher_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            My.Settings.Save()    '关闭窗体前保存用户设置
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Form Closing Error")
        End Try
    End Sub

    Private Sub SysTrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles SysTrayIcon.MouseDoubleClick
        Show()
        Focus()
        WindowState = FormWindowState.Normal
        SysTrayIcon.Visible = False
    End Sub
End Class
