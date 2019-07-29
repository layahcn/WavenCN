Public Class WavenLauncher
    Const Version As UInt32 = 20190729  ' 汉化启动器版本号
    Private bFormDragging As Boolean = False    ' 判断窗体是否被拖动
    Private oPointClicked As Point  ' 记录鼠标拖动位置

    Private Sub WavenLauncher_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 窗体载入时的动作
        Try
            CheckVersion()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Check Version Error")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles QuitForm.Click
        ' 右上角退出程序叉叉
        Application.Exit()
    End Sub


    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        Me.bFormDragging = True
        Me.oPointClicked = New Point(e.X, e.Y)
    End Sub
    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Me.bFormDragging = False
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Try
            If Me.bFormDragging Then
                Dim oMoveToPoint As Point
                ' 以当前鼠标位置为基础，找出目标位置
                oMoveToPoint = Me.PointToScreen(New Point(e.X, e.Y))
                ' 根据开始位置作出调整
                oMoveToPoint.Offset(Me.oPointClicked.X * -1, Me.oPointClicked.Y * -1)
                ' 移动窗体
                Me.Location = oMoveToPoint
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Move Form Error")
        End Try

    End Sub
    Private Sub CheckVersion()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles DownloadAL.Click
        ' 直接调用浏览器下载Ankama Launcher
        Try
            Process.Start("https://ankama.akamaized.net/zaap/installers/production/Ankama%20Launcher-Setup.exe")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Download Ankama Launcher Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles LocGame.Click
        MsgBox("咕咕咕，在做了")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles LocAL.Click
        ' 汉化Ankama Launcher

    End Sub

End Class
