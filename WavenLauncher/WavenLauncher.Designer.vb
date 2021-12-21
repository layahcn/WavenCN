<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WavenLauncher
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WavenLauncher))
        Me.StartButton = New System.Windows.Forms.Button()
        Me.WLVersionLabel = New System.Windows.Forms.Label()
        Me.ALVersionLabel = New System.Windows.Forms.Label()
        Me.QuitForm = New System.Windows.Forms.Button()
        Me.FormTitle = New System.Windows.Forms.Label()
        Me.IcoPicture = New System.Windows.Forms.PictureBox()
        Me.ShowToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelDirGM = New System.Windows.Forms.Label()
        Me.OpenSettings = New System.Windows.Forms.Button()
        Me.GMVersionLabel = New System.Windows.Forms.Label()
        Me.AutoUDCheck = New System.Windows.Forms.CheckBox()
        Me.UpdateCN = New System.Windows.Forms.Button()
        Me.ButtonDirGM = New System.Windows.Forms.Button()
        Me.LocGameCheck = New System.Windows.Forms.CheckBox()
        Me.LocALCheck = New System.Windows.Forms.CheckBox()
        Me.CloseAction = New System.Windows.Forms.GroupBox()
        Me.CloseForm2 = New System.Windows.Forms.RadioButton()
        Me.CloseForm1 = New System.Windows.Forms.RadioButton()
        Me.CloseForm0 = New System.Windows.Forms.RadioButton()
        Me.SysTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SysTrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_ShowForm = New System.Windows.Forms.Timer(Me.components)
        Me.SelectDirDialog = New System.Windows.Forms.OpenFileDialog()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.StatusPanel = New System.Windows.Forms.Panel()
        Me.WLVerStatus = New System.Windows.Forms.Label()
        Me.Timer_NewVersionNeon = New System.Windows.Forms.Timer(Me.components)
        Me.PanelProgressBar = New System.Windows.Forms.Panel()
        Me.PanelProgress = New System.Windows.Forms.Panel()
        Me.Timer_ShowDSpeed = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonSwitchLine = New System.Windows.Forms.Button()
        Me.LabelSwitchLine = New System.Windows.Forms.Label()
        Me.Timer_CheckVersion = New System.Windows.Forms.Timer(Me.components)
        Me.SettingPanel = New System.Windows.Forms.Panel()
        Me.PingLabel = New System.Windows.Forms.Label()
        Me.ButtonDirAL = New System.Windows.Forms.Button()
        Me.LabelDirAL = New System.Windows.Forms.Label()
        Me.MiniForm = New System.Windows.Forms.Button()
        Me.Timer_HideForm = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Ping = New System.Windows.Forms.Timer(Me.components)
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CloseAction.SuspendLayout()
        Me.SysTrayMenu.SuspendLayout()
        Me.StatusPanel.SuspendLayout()
        Me.PanelProgressBar.SuspendLayout()
        Me.SettingPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Teal
        Me.StartButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StartButton.ForeColor = System.Drawing.Color.Yellow
        Me.StartButton.Location = New System.Drawing.Point(571, 350)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(115, 45)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "启动战网"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'WLVersionLabel
        '
        Me.WLVersionLabel.AutoSize = True
        Me.WLVersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.WLVersionLabel.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WLVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.WLVersionLabel.Location = New System.Drawing.Point(320, 17)
        Me.WLVersionLabel.Name = "WLVersionLabel"
        Me.WLVersionLabel.Size = New System.Drawing.Size(93, 20)
        Me.WLVersionLabel.TabIndex = 3
        Me.WLVersionLabel.Text = "软件版本号："
        Me.WLVersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ALVersionLabel
        '
        Me.ALVersionLabel.AutoSize = True
        Me.ALVersionLabel.BackColor = System.Drawing.Color.Teal
        Me.ALVersionLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ALVersionLabel.Enabled = False
        Me.ALVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ALVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.ALVersionLabel.Location = New System.Drawing.Point(153, 19)
        Me.ALVersionLabel.Name = "ALVersionLabel"
        Me.ALVersionLabel.Size = New System.Drawing.Size(92, 17)
        Me.ALVersionLabel.TabIndex = 5
        Me.ALVersionLabel.Text = "适用战网版本："
        '
        'QuitForm
        '
        Me.QuitForm.BackColor = System.Drawing.Color.Transparent
        Me.QuitForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.QuitForm.FlatAppearance.BorderSize = 0
        Me.QuitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitForm.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.QuitForm.ForeColor = System.Drawing.Color.Yellow
        Me.QuitForm.Location = New System.Drawing.Point(659, 0)
        Me.QuitForm.Name = "QuitForm"
        Me.QuitForm.Size = New System.Drawing.Size(37, 37)
        Me.QuitForm.TabIndex = 14
        Me.QuitForm.Text = "×"
        Me.QuitForm.UseVisualStyleBackColor = False
        '
        'FormTitle
        '
        Me.FormTitle.AutoSize = True
        Me.FormTitle.BackColor = System.Drawing.Color.Transparent
        Me.FormTitle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormTitle.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormTitle.ForeColor = System.Drawing.Color.Yellow
        Me.FormTitle.Location = New System.Drawing.Point(48, 13)
        Me.FormTitle.Name = "FormTitle"
        Me.FormTitle.Size = New System.Drawing.Size(259, 26)
        Me.FormTitle.TabIndex = 10
        Me.FormTitle.Text = "Waven汉化启动器 by layah"
        Me.FormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IcoPicture
        '
        Me.IcoPicture.BackColor = System.Drawing.Color.Transparent
        Me.IcoPicture.Image = CType(resources.GetObject("IcoPicture.Image"), System.Drawing.Image)
        Me.IcoPicture.Location = New System.Drawing.Point(10, 10)
        Me.IcoPicture.Name = "IcoPicture"
        Me.IcoPicture.Size = New System.Drawing.Size(32, 32)
        Me.IcoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IcoPicture.TabIndex = 11
        Me.IcoPicture.TabStop = False
        '
        'ShowToolTip
        '
        Me.ShowToolTip.AutoPopDelay = 10000
        Me.ShowToolTip.InitialDelay = 100
        Me.ShowToolTip.IsBalloon = True
        Me.ShowToolTip.ReshowDelay = 100
        '
        'LabelDirGM
        '
        Me.LabelDirGM.BackColor = System.Drawing.Color.White
        Me.LabelDirGM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelDirGM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelDirGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelDirGM.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelDirGM.ForeColor = System.Drawing.Color.Black
        Me.LabelDirGM.Location = New System.Drawing.Point(152, 103)
        Me.LabelDirGM.Name = "LabelDirGM"
        Me.LabelDirGM.Size = New System.Drawing.Size(307, 21)
        Me.LabelDirGM.TabIndex = 9
        Me.LabelDirGM.Text = "选择Waven游戏路径"
        Me.LabelDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ShowToolTip.SetToolTip(Me.LabelDirGM, "选择Waven游戏路径")
        '
        'OpenSettings
        '
        Me.OpenSettings.BackColor = System.Drawing.Color.Teal
        Me.OpenSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSettings.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpenSettings.ForeColor = System.Drawing.Color.Yellow
        Me.OpenSettings.Location = New System.Drawing.Point(485, 350)
        Me.OpenSettings.Name = "OpenSettings"
        Me.OpenSettings.Size = New System.Drawing.Size(80, 45)
        Me.OpenSettings.TabIndex = 1
        Me.OpenSettings.Text = "设置"
        Me.OpenSettings.UseVisualStyleBackColor = False
        '
        'GMVersionLabel
        '
        Me.GMVersionLabel.AutoSize = True
        Me.GMVersionLabel.BackColor = System.Drawing.Color.Teal
        Me.GMVersionLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GMVersionLabel.Enabled = False
        Me.GMVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GMVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.GMVersionLabel.Location = New System.Drawing.Point(153, 76)
        Me.GMVersionLabel.Name = "GMVersionLabel"
        Me.GMVersionLabel.Size = New System.Drawing.Size(92, 17)
        Me.GMVersionLabel.TabIndex = 8
        Me.GMVersionLabel.Text = "适用游戏版本："
        '
        'AutoUDCheck
        '
        Me.AutoUDCheck.AutoSize = True
        Me.AutoUDCheck.BackColor = System.Drawing.Color.Teal
        Me.AutoUDCheck.Checked = True
        Me.AutoUDCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoUDCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AutoUDCheck.Enabled = False
        Me.AutoUDCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AutoUDCheck.ForeColor = System.Drawing.Color.Yellow
        Me.AutoUDCheck.Location = New System.Drawing.Point(476, 72)
        Me.AutoUDCheck.Name = "AutoUDCheck"
        Me.AutoUDCheck.Size = New System.Drawing.Size(99, 21)
        Me.AutoUDCheck.TabIndex = 12
        Me.AutoUDCheck.Text = "自动安装汉化"
        Me.AutoUDCheck.UseVisualStyleBackColor = False
        '
        'UpdateCN
        '
        Me.UpdateCN.BackColor = System.Drawing.Color.Teal
        Me.UpdateCN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UpdateCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateCN.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpdateCN.ForeColor = System.Drawing.Color.Yellow
        Me.UpdateCN.Location = New System.Drawing.Point(474, 101)
        Me.UpdateCN.Name = "UpdateCN"
        Me.UpdateCN.Size = New System.Drawing.Size(101, 25)
        Me.UpdateCN.TabIndex = 13
        Me.UpdateCN.Text = "强制下载汉化"
        Me.UpdateCN.UseVisualStyleBackColor = False
        '
        'ButtonDirGM
        '
        Me.ButtonDirGM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDirGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDirGM.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonDirGM.ForeColor = System.Drawing.Color.White
        Me.ButtonDirGM.Location = New System.Drawing.Point(434, 104)
        Me.ButtonDirGM.Name = "ButtonDirGM"
        Me.ButtonDirGM.Size = New System.Drawing.Size(24, 19)
        Me.ButtonDirGM.TabIndex = 9
        Me.ButtonDirGM.Text = "…"
        Me.ButtonDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirGM.UseVisualStyleBackColor = True
        '
        'LocGameCheck
        '
        Me.LocGameCheck.AutoSize = True
        Me.LocGameCheck.BackColor = System.Drawing.Color.Teal
        Me.LocGameCheck.Checked = True
        Me.LocGameCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LocGameCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LocGameCheck.Enabled = False
        Me.LocGameCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocGameCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocGameCheck.Location = New System.Drawing.Point(476, 45)
        Me.LocGameCheck.Name = "LocGameCheck"
        Me.LocGameCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocGameCheck.TabIndex = 11
        Me.LocGameCheck.Text = "启用游戏汉化"
        Me.LocGameCheck.UseVisualStyleBackColor = False
        '
        'LocALCheck
        '
        Me.LocALCheck.AutoSize = True
        Me.LocALCheck.BackColor = System.Drawing.Color.Teal
        Me.LocALCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LocALCheck.Enabled = False
        Me.LocALCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocALCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocALCheck.Location = New System.Drawing.Point(476, 18)
        Me.LocALCheck.Name = "LocALCheck"
        Me.LocALCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocALCheck.TabIndex = 10
        Me.LocALCheck.Text = "启用战网汉化"
        Me.LocALCheck.UseVisualStyleBackColor = False
        '
        'CloseAction
        '
        Me.CloseAction.BackColor = System.Drawing.Color.Teal
        Me.CloseAction.Controls.Add(Me.CloseForm2)
        Me.CloseAction.Controls.Add(Me.CloseForm1)
        Me.CloseAction.Controls.Add(Me.CloseForm0)
        Me.CloseAction.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseAction.ForeColor = System.Drawing.Color.Yellow
        Me.CloseAction.Location = New System.Drawing.Point(18, 19)
        Me.CloseAction.Name = "CloseAction"
        Me.CloseAction.Size = New System.Drawing.Size(119, 107)
        Me.CloseAction.TabIndex = 0
        Me.CloseAction.TabStop = False
        Me.CloseAction.Text = "点击关闭按钮时"
        '
        'CloseForm2
        '
        Me.CloseForm2.AutoSize = True
        Me.CloseForm2.BackColor = System.Drawing.Color.Teal
        Me.CloseForm2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm2.Location = New System.Drawing.Point(11, 76)
        Me.CloseForm2.Name = "CloseForm2"
        Me.CloseForm2.Size = New System.Drawing.Size(86, 21)
        Me.CloseForm2.TabIndex = 4
        Me.CloseForm2.TabStop = True
        Me.CloseForm2.Text = "隐藏至托盘"
        Me.CloseForm2.UseVisualStyleBackColor = False
        '
        'CloseForm1
        '
        Me.CloseForm1.AutoSize = True
        Me.CloseForm1.BackColor = System.Drawing.Color.Teal
        Me.CloseForm1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm1.Location = New System.Drawing.Point(11, 49)
        Me.CloseForm1.Name = "CloseForm1"
        Me.CloseForm1.Size = New System.Drawing.Size(62, 21)
        Me.CloseForm1.TabIndex = 3
        Me.CloseForm1.TabStop = True
        Me.CloseForm1.Text = "最小化"
        Me.CloseForm1.UseVisualStyleBackColor = False
        '
        'CloseForm0
        '
        Me.CloseForm0.AutoSize = True
        Me.CloseForm0.BackColor = System.Drawing.Color.Teal
        Me.CloseForm0.Checked = True
        Me.CloseForm0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm0.Location = New System.Drawing.Point(11, 22)
        Me.CloseForm0.Name = "CloseForm0"
        Me.CloseForm0.Size = New System.Drawing.Size(74, 21)
        Me.CloseForm0.TabIndex = 2
        Me.CloseForm0.TabStop = True
        Me.CloseForm0.Text = "退出程序"
        Me.CloseForm0.UseVisualStyleBackColor = False
        '
        'SysTrayIcon
        '
        Me.SysTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.SysTrayIcon.BalloonTipTitle = "Waven汉化启动器"
        Me.SysTrayIcon.ContextMenuStrip = Me.SysTrayMenu
        Me.SysTrayIcon.Icon = CType(resources.GetObject("SysTrayIcon.Icon"), System.Drawing.Icon)
        Me.SysTrayIcon.Text = "Waven汉化启动器 by layah"
        '
        'SysTrayMenu
        '
        Me.SysTrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.SysTrayMenu.Name = "ContextMenuStrip1"
        Me.SysTrayMenu.Size = New System.Drawing.Size(182, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "显示主界面"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem2.Text = "退出"
        '
        'Timer_ShowForm
        '
        Me.Timer_ShowForm.Interval = 15
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StatusLabel.ForeColor = System.Drawing.Color.Yellow
        Me.StatusLabel.Location = New System.Drawing.Point(0, 33)
        Me.StatusLabel.MaximumSize = New System.Drawing.Size(475, 100)
        Me.StatusLabel.MinimumSize = New System.Drawing.Size(475, 0)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(475, 17)
        Me.StatusLabel.TabIndex = 17
        '
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.Color.Teal
        Me.StatusPanel.Controls.Add(Me.StatusLabel)
        Me.StatusPanel.Location = New System.Drawing.Point(5, 348)
        Me.StatusPanel.Name = "StatusPanel"
        Me.StatusPanel.Size = New System.Drawing.Size(478, 50)
        Me.StatusPanel.TabIndex = 19
        '
        'WLVerStatus
        '
        Me.WLVerStatus.AutoSize = True
        Me.WLVerStatus.BackColor = System.Drawing.Color.Transparent
        Me.WLVerStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WLVerStatus.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WLVerStatus.ForeColor = System.Drawing.Color.Yellow
        Me.WLVerStatus.Location = New System.Drawing.Point(475, 17)
        Me.WLVerStatus.Name = "WLVerStatus"
        Me.WLVerStatus.Size = New System.Drawing.Size(90, 20)
        Me.WLVerStatus.TabIndex = 20
        Me.WLVerStatus.Text = "检测更新中…"
        Me.WLVerStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Timer_NewVersionNeon
        '
        Me.Timer_NewVersionNeon.Interval = 500
        '
        'PanelProgressBar
        '
        Me.PanelProgressBar.BackColor = System.Drawing.Color.Teal
        Me.PanelProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelProgressBar.Controls.Add(Me.PanelProgress)
        Me.PanelProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelProgressBar.Location = New System.Drawing.Point(0, 401)
        Me.PanelProgressBar.Name = "PanelProgressBar"
        Me.PanelProgressBar.Size = New System.Drawing.Size(696, 10)
        Me.PanelProgressBar.TabIndex = 21
        '
        'PanelProgress
        '
        Me.PanelProgress.BackColor = System.Drawing.Color.Yellow
        Me.PanelProgress.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelProgress.Location = New System.Drawing.Point(0, 0)
        Me.PanelProgress.Name = "PanelProgress"
        Me.PanelProgress.Size = New System.Drawing.Size(0, 8)
        Me.PanelProgress.TabIndex = 0
        '
        'Timer_ShowDSpeed
        '
        '
        'ButtonSwitchLine
        '
        Me.ButtonSwitchLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSwitchLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSwitchLine.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonSwitchLine.ForeColor = System.Drawing.Color.White
        Me.ButtonSwitchLine.Location = New System.Drawing.Point(434, 18)
        Me.ButtonSwitchLine.Name = "ButtonSwitchLine"
        Me.ButtonSwitchLine.Size = New System.Drawing.Size(24, 19)
        Me.ButtonSwitchLine.TabIndex = 6
        Me.ButtonSwitchLine.Text = "…"
        Me.ButtonSwitchLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSwitchLine.UseVisualStyleBackColor = True
        '
        'LabelSwitchLine
        '
        Me.LabelSwitchLine.BackColor = System.Drawing.Color.White
        Me.LabelSwitchLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelSwitchLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelSwitchLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelSwitchLine.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelSwitchLine.Location = New System.Drawing.Point(339, 17)
        Me.LabelSwitchLine.Name = "LabelSwitchLine"
        Me.LabelSwitchLine.Size = New System.Drawing.Size(119, 21)
        Me.LabelSwitchLine.TabIndex = 6
        Me.LabelSwitchLine.Text = "国内下载线路"
        Me.LabelSwitchLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer_CheckVersion
        '
        Me.Timer_CheckVersion.Interval = 50
        '
        'SettingPanel
        '
        Me.SettingPanel.BackColor = System.Drawing.Color.Teal
        Me.SettingPanel.Controls.Add(Me.PingLabel)
        Me.SettingPanel.Controls.Add(Me.ButtonSwitchLine)
        Me.SettingPanel.Controls.Add(Me.CloseAction)
        Me.SettingPanel.Controls.Add(Me.ALVersionLabel)
        Me.SettingPanel.Controls.Add(Me.LabelSwitchLine)
        Me.SettingPanel.Controls.Add(Me.GMVersionLabel)
        Me.SettingPanel.Controls.Add(Me.LocALCheck)
        Me.SettingPanel.Controls.Add(Me.LocGameCheck)
        Me.SettingPanel.Controls.Add(Me.ButtonDirAL)
        Me.SettingPanel.Controls.Add(Me.ButtonDirGM)
        Me.SettingPanel.Controls.Add(Me.LabelDirAL)
        Me.SettingPanel.Controls.Add(Me.LabelDirGM)
        Me.SettingPanel.Controls.Add(Me.UpdateCN)
        Me.SettingPanel.Controls.Add(Me.AutoUDCheck)
        Me.SettingPanel.Location = New System.Drawing.Point(96, 201)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.Size = New System.Drawing.Size(590, 141)
        Me.SettingPanel.TabIndex = 25
        '
        'PingLabel
        '
        Me.PingLabel.AutoSize = True
        Me.PingLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PingLabel.ForeColor = System.Drawing.Color.Yellow
        Me.PingLabel.Location = New System.Drawing.Point(339, 76)
        Me.PingLabel.Name = "PingLabel"
        Me.PingLabel.Size = New System.Drawing.Size(95, 17)
        Me.PingLabel.TabIndex = 14
        Me.PingLabel.Text = "游戏延迟：- ms"
        '
        'ButtonDirAL
        '
        Me.ButtonDirAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDirAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDirAL.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonDirAL.ForeColor = System.Drawing.Color.White
        Me.ButtonDirAL.Location = New System.Drawing.Point(434, 46)
        Me.ButtonDirAL.Name = "ButtonDirAL"
        Me.ButtonDirAL.Size = New System.Drawing.Size(24, 19)
        Me.ButtonDirAL.TabIndex = 7
        Me.ButtonDirAL.Text = "…"
        Me.ButtonDirAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirAL.UseVisualStyleBackColor = True
        '
        'LabelDirAL
        '
        Me.LabelDirAL.BackColor = System.Drawing.Color.White
        Me.LabelDirAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelDirAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelDirAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelDirAL.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelDirAL.ForeColor = System.Drawing.Color.Black
        Me.LabelDirAL.Location = New System.Drawing.Point(152, 45)
        Me.LabelDirAL.Name = "LabelDirAL"
        Me.LabelDirAL.Size = New System.Drawing.Size(307, 21)
        Me.LabelDirAL.TabIndex = 7
        Me.LabelDirAL.Text = "选择Ankama战网路径"
        Me.LabelDirAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MiniForm
        '
        Me.MiniForm.BackColor = System.Drawing.Color.Transparent
        Me.MiniForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MiniForm.FlatAppearance.BorderSize = 0
        Me.MiniForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MiniForm.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MiniForm.ForeColor = System.Drawing.Color.Yellow
        Me.MiniForm.Location = New System.Drawing.Point(622, 0)
        Me.MiniForm.Name = "MiniForm"
        Me.MiniForm.Size = New System.Drawing.Size(37, 37)
        Me.MiniForm.TabIndex = 26
        Me.MiniForm.Text = "一"
        Me.MiniForm.UseVisualStyleBackColor = False
        '
        'Timer_HideForm
        '
        Me.Timer_HideForm.Interval = 15
        '
        'Timer_Ping
        '
        '
        'WavenLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(696, 411)
        Me.Controls.Add(Me.MiniForm)
        Me.Controls.Add(Me.SettingPanel)
        Me.Controls.Add(Me.PanelProgressBar)
        Me.Controls.Add(Me.WLVerStatus)
        Me.Controls.Add(Me.StatusPanel)
        Me.Controls.Add(Me.OpenSettings)
        Me.Controls.Add(Me.IcoPicture)
        Me.Controls.Add(Me.FormTitle)
        Me.Controls.Add(Me.QuitForm)
        Me.Controls.Add(Me.WLVersionLabel)
        Me.Controls.Add(Me.StartButton)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WavenLauncher"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waven汉化启动器 by layah"
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CloseAction.ResumeLayout(False)
        Me.CloseAction.PerformLayout()
        Me.SysTrayMenu.ResumeLayout(False)
        Me.StatusPanel.ResumeLayout(False)
        Me.StatusPanel.PerformLayout()
        Me.PanelProgressBar.ResumeLayout(False)
        Me.SettingPanel.ResumeLayout(False)
        Me.SettingPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As Button
    Friend WithEvents WLVersionLabel As Label
    Friend WithEvents ALVersionLabel As Label
    Friend WithEvents QuitForm As Button
    Friend WithEvents FormTitle As Label
    Friend WithEvents IcoPicture As PictureBox
    Friend WithEvents ShowToolTip As ToolTip
    Friend WithEvents OpenSettings As Button
    Friend WithEvents LocGameCheck As CheckBox
    Friend WithEvents LocALCheck As CheckBox
    Friend WithEvents CloseAction As GroupBox
    Friend WithEvents CloseForm2 As RadioButton
    Friend WithEvents CloseForm1 As RadioButton
    Friend WithEvents CloseForm0 As RadioButton
    Friend WithEvents SysTrayIcon As NotifyIcon
    Friend WithEvents Timer_ShowForm As Timer
    Friend WithEvents SysTrayMenu As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonDirGM As Button
    Friend WithEvents LabelDirGM As Label
    Friend WithEvents SelectDirDialog As OpenFileDialog
    Friend WithEvents StatusLabel As Label
    Friend WithEvents StatusPanel As Panel
    Friend WithEvents UpdateCN As Button
    Friend WithEvents WLVerStatus As Label
    Friend WithEvents Timer_NewVersionNeon As Timer
    Friend WithEvents AutoUDCheck As CheckBox
    Friend WithEvents PanelProgressBar As Panel
    Friend WithEvents PanelProgress As Panel
    Friend WithEvents Timer_ShowDSpeed As Timer
    Friend WithEvents GMVersionLabel As Label
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Timer_CheckVersion As Timer
    Friend WithEvents LabelSwitchLine As Label
    Friend WithEvents ButtonSwitchLine As Button
    Friend WithEvents SettingPanel As Panel
    Friend WithEvents LabelDirAL As Label
    Friend WithEvents ButtonDirAL As Button
    Friend WithEvents MiniForm As Button
    Friend WithEvents Timer_HideForm As Timer
    Friend WithEvents PingLabel As Label
    Friend WithEvents Timer_Ping As Timer
End Class
