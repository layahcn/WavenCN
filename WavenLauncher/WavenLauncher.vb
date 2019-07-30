﻿Imports System.ComponentModel  '实现组件和控件的运行时和设计时行为
Imports System.Linq  '允许对任何数据类型进行查询

Public Class WavenLauncher
    Const VersionWL As UInt32 = 20190730  ' 汉化启动器版本号
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
            Visible = False
            Opacity = 0  '先隐藏窗体，等全部控件刷新完后再显示，避免控件背景重绘造成的闪烁
            ToolTip1.SetToolTip(ALVersion, "点击下载Ankama Launcher官方客户端")
            WLVersion.Text = WLVersion.Text _
                             & VersionWL
            ALVersion.Text = ALVersion.Text _
                             & VersionAL  ' 显示版本号
            If CheckSetting() Then '检测用户设置是否合法
                CloseForm = My.Settings.CloseForm
                LocAL = My.Settings.LocAL
                LocGame = My.Settings.LocGame  ' 获取用户设置
            End If
            CheckVersion()
            ' 调用检查版本函数
            Timer1.Enabled = True  '加载完窗体再触发time显示窗体
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
        '点击打开或关闭设置面板
        Try
            If PanelVisible = False Then
                SettingPanel.Visible = True  '显示设置面板
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
                SettingPanel.Visible = False  '隐藏设置面板
                OpenSettings.Text = "打开设置"
                PanelVisible = False
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

    Private Function CheckSetting() As Boolean
        If TypeName(My.Settings.CloseForm) = "Integer" Then

        End If
        Return True
    End Function

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        DisplayForm()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Close()
    End Sub
End Class
