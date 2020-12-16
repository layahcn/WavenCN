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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelDirAL = New System.Windows.Forms.Label()
        Me.LabelDirGM = New System.Windows.Forms.Label()
        Me.OpenSettings = New System.Windows.Forms.Button()
        Me.SettingPanel = New System.Windows.Forms.Panel()
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
        Me.ButtonDirAL = New System.Windows.Forms.Button()
        Me.SysTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TestLabel2 = New System.Windows.Forms.Label()
        Me.TestLabel1 = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WLVerStatus = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelProgressBar = New System.Windows.Forms.Panel()
        Me.PanelProgress = New System.Windows.Forms.Panel()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SettingPanel.SuspendLayout()
        Me.CloseAction.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelProgressBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Teal
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
        '
        'ALVersionLabel
        '
        Me.ALVersionLabel.AutoSize = True
        Me.ALVersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.ALVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ALVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.ALVersionLabel.Location = New System.Drawing.Point(22, 109)
        Me.ALVersionLabel.Name = "ALVersionLabel"
        Me.ALVersionLabel.Size = New System.Drawing.Size(92, 17)
        Me.ALVersionLabel.TabIndex = 4
        Me.ALVersionLabel.Text = "适用战网版本："
        '
        'QuitForm
        '
        Me.QuitForm.BackColor = System.Drawing.Color.Red
        Me.QuitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitForm.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.QuitForm.Location = New System.Drawing.Point(664, 5)
        Me.QuitForm.Name = "QuitForm"
        Me.QuitForm.Size = New System.Drawing.Size(27, 27)
        Me.QuitForm.TabIndex = 1
        Me.QuitForm.Text = "×"
        Me.QuitForm.UseVisualStyleBackColor = False
        '
        'FormTitle
        '
        Me.FormTitle.AutoSize = True
        Me.FormTitle.BackColor = System.Drawing.Color.Transparent
        Me.FormTitle.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormTitle.ForeColor = System.Drawing.Color.Yellow
        Me.FormTitle.Location = New System.Drawing.Point(48, 13)
        Me.FormTitle.Name = "FormTitle"
        Me.FormTitle.Size = New System.Drawing.Size(259, 26)
        Me.FormTitle.TabIndex = 10
        Me.FormTitle.Text = "Waven汉化启动器 by layah"
        '
        'IcoPicture
        '
        Me.IcoPicture.BackColor = System.Drawing.Color.Transparent
        Me.IcoPicture.Image = CType(resources.GetObject("IcoPicture.Image"), System.Drawing.Image)
        Me.IcoPicture.Location = New System.Drawing.Point(7, 6)
        Me.IcoPicture.Name = "IcoPicture"
        Me.IcoPicture.Size = New System.Drawing.Size(38, 40)
        Me.IcoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IcoPicture.TabIndex = 11
        Me.IcoPicture.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'LabelDirAL
        '
        Me.LabelDirAL.BackColor = System.Drawing.Color.White
        Me.LabelDirAL.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelDirAL.ForeColor = System.Drawing.Color.Black
        Me.LabelDirAL.Location = New System.Drawing.Point(67, 44)
        Me.LabelDirAL.Name = "LabelDirAL"
        Me.LabelDirAL.Size = New System.Drawing.Size(437, 21)
        Me.LabelDirAL.TabIndex = 3
        Me.LabelDirAL.Text = "选择Ankama Launcher战网路径"
        Me.LabelDirAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.LabelDirAL, "选择Ankama Launcher战网路径")
        Me.LabelDirAL.Visible = False
        '
        'LabelDirGM
        '
        Me.LabelDirGM.BackColor = System.Drawing.Color.White
        Me.LabelDirGM.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelDirGM.ForeColor = System.Drawing.Color.Black
        Me.LabelDirGM.Location = New System.Drawing.Point(22, 77)
        Me.LabelDirGM.Name = "LabelDirGM"
        Me.LabelDirGM.Size = New System.Drawing.Size(310, 21)
        Me.LabelDirGM.TabIndex = 4
        Me.LabelDirGM.Text = "选择Waven游戏路径"
        Me.LabelDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.LabelDirGM, "选择Waven游戏路径")
        '
        'OpenSettings
        '
        Me.OpenSettings.BackColor = System.Drawing.Color.Teal
        Me.OpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSettings.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpenSettings.ForeColor = System.Drawing.Color.Yellow
        Me.OpenSettings.Location = New System.Drawing.Point(485, 350)
        Me.OpenSettings.Name = "OpenSettings"
        Me.OpenSettings.Size = New System.Drawing.Size(80, 45)
        Me.OpenSettings.TabIndex = 12
        Me.OpenSettings.Text = "设置"
        Me.OpenSettings.UseVisualStyleBackColor = False
        '
        'SettingPanel
        '
        Me.SettingPanel.BackColor = System.Drawing.Color.Teal
        Me.SettingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SettingPanel.Controls.Add(Me.GMVersionLabel)
        Me.SettingPanel.Controls.Add(Me.AutoUDCheck)
        Me.SettingPanel.Controls.Add(Me.UpdateCN)
        Me.SettingPanel.Controls.Add(Me.ButtonDirGM)
        Me.SettingPanel.Controls.Add(Me.LabelDirGM)
        Me.SettingPanel.Controls.Add(Me.ALVersionLabel)
        Me.SettingPanel.Controls.Add(Me.LocGameCheck)
        Me.SettingPanel.Controls.Add(Me.LocALCheck)
        Me.SettingPanel.Controls.Add(Me.CloseAction)
        Me.SettingPanel.ForeColor = System.Drawing.Color.Yellow
        Me.SettingPanel.Location = New System.Drawing.Point(201, 200)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.Size = New System.Drawing.Size(485, 144)
        Me.SettingPanel.TabIndex = 13
        Me.SettingPanel.Visible = False
        '
        'GMVersionLabel
        '
        Me.GMVersionLabel.AutoSize = True
        Me.GMVersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.GMVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GMVersionLabel.Location = New System.Drawing.Point(176, 109)
        Me.GMVersionLabel.Name = "GMVersionLabel"
        Me.GMVersionLabel.Size = New System.Drawing.Size(92, 17)
        Me.GMVersionLabel.TabIndex = 9
        Me.GMVersionLabel.Text = "适用游戏版本："
        '
        'AutoUDCheck
        '
        Me.AutoUDCheck.AutoSize = True
        Me.AutoUDCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AutoUDCheck.Location = New System.Drawing.Point(369, 76)
        Me.AutoUDCheck.Name = "AutoUDCheck"
        Me.AutoUDCheck.Size = New System.Drawing.Size(99, 21)
        Me.AutoUDCheck.TabIndex = 8
        Me.AutoUDCheck.Text = "自动更新汉化"
        Me.AutoUDCheck.UseVisualStyleBackColor = True
        '
        'UpdateCN
        '
        Me.UpdateCN.BackColor = System.Drawing.Color.Teal
        Me.UpdateCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateCN.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpdateCN.ForeColor = System.Drawing.Color.Yellow
        Me.UpdateCN.Location = New System.Drawing.Point(369, 105)
        Me.UpdateCN.Name = "UpdateCN"
        Me.UpdateCN.Size = New System.Drawing.Size(99, 25)
        Me.UpdateCN.TabIndex = 7
        Me.UpdateCN.Text = "汉化版本"
        Me.UpdateCN.UseVisualStyleBackColor = False
        '
        'ButtonDirGM
        '
        Me.ButtonDirGM.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonDirGM.Location = New System.Drawing.Point(309, 78)
        Me.ButtonDirGM.Name = "ButtonDirGM"
        Me.ButtonDirGM.Size = New System.Drawing.Size(22, 19)
        Me.ButtonDirGM.TabIndex = 6
        Me.ButtonDirGM.Text = "…"
        Me.ButtonDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirGM.UseVisualStyleBackColor = True
        '
        'LocGameCheck
        '
        Me.LocGameCheck.AutoSize = True
        Me.LocGameCheck.BackColor = System.Drawing.Color.Transparent
        Me.LocGameCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocGameCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocGameCheck.Location = New System.Drawing.Point(369, 45)
        Me.LocGameCheck.Name = "LocGameCheck"
        Me.LocGameCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocGameCheck.TabIndex = 2
        Me.LocGameCheck.Text = "启用游戏汉化"
        Me.LocGameCheck.UseVisualStyleBackColor = False
        '
        'LocALCheck
        '
        Me.LocALCheck.AutoSize = True
        Me.LocALCheck.BackColor = System.Drawing.Color.Transparent
        Me.LocALCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocALCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocALCheck.Location = New System.Drawing.Point(369, 14)
        Me.LocALCheck.Name = "LocALCheck"
        Me.LocALCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocALCheck.TabIndex = 1
        Me.LocALCheck.Text = "启用战网汉化"
        Me.LocALCheck.UseVisualStyleBackColor = False
        '
        'CloseAction
        '
        Me.CloseAction.Controls.Add(Me.CloseForm2)
        Me.CloseAction.Controls.Add(Me.CloseForm1)
        Me.CloseAction.Controls.Add(Me.CloseForm0)
        Me.CloseAction.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseAction.ForeColor = System.Drawing.Color.Yellow
        Me.CloseAction.Location = New System.Drawing.Point(22, 14)
        Me.CloseAction.Name = "CloseAction"
        Me.CloseAction.Size = New System.Drawing.Size(310, 52)
        Me.CloseAction.TabIndex = 0
        Me.CloseAction.TabStop = False
        Me.CloseAction.Text = "点击右上角关闭按钮时"
        '
        'CloseForm2
        '
        Me.CloseForm2.AutoSize = True
        Me.CloseForm2.BackColor = System.Drawing.Color.Transparent
        Me.CloseForm2.Location = New System.Drawing.Point(176, 23)
        Me.CloseForm2.Name = "CloseForm2"
        Me.CloseForm2.Size = New System.Drawing.Size(122, 21)
        Me.CloseForm2.TabIndex = 2
        Me.CloseForm2.TabStop = True
        Me.CloseForm2.Text = "最小化到系统托盘"
        Me.CloseForm2.UseVisualStyleBackColor = False
        '
        'CloseForm1
        '
        Me.CloseForm1.AutoSize = True
        Me.CloseForm1.BackColor = System.Drawing.Color.Transparent
        Me.CloseForm1.Location = New System.Drawing.Point(99, 23)
        Me.CloseForm1.Name = "CloseForm1"
        Me.CloseForm1.Size = New System.Drawing.Size(62, 21)
        Me.CloseForm1.TabIndex = 1
        Me.CloseForm1.TabStop = True
        Me.CloseForm1.Text = "最小化"
        Me.CloseForm1.UseVisualStyleBackColor = False
        '
        'CloseForm0
        '
        Me.CloseForm0.AutoSize = True
        Me.CloseForm0.BackColor = System.Drawing.Color.Transparent
        Me.CloseForm0.Location = New System.Drawing.Point(14, 23)
        Me.CloseForm0.Name = "CloseForm0"
        Me.CloseForm0.Size = New System.Drawing.Size(74, 21)
        Me.CloseForm0.TabIndex = 0
        Me.CloseForm0.TabStop = True
        Me.CloseForm0.Text = "退出程序"
        Me.CloseForm0.UseVisualStyleBackColor = False
        '
        'ButtonDirAL
        '
        Me.ButtonDirAL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonDirAL.Location = New System.Drawing.Point(481, 45)
        Me.ButtonDirAL.Name = "ButtonDirAL"
        Me.ButtonDirAL.Size = New System.Drawing.Size(22, 19)
        Me.ButtonDirAL.TabIndex = 5
        Me.ButtonDirAL.Text = "…"
        Me.ButtonDirAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirAL.UseVisualStyleBackColor = True
        Me.ButtonDirAL.Visible = False
        '
        'SysTrayIcon
        '
        Me.SysTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.SysTrayIcon.BalloonTipTitle = "Waven汉化启动器"
        Me.SysTrayIcon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.SysTrayIcon.Icon = CType(resources.GetObject("SysTrayIcon.Icon"), System.Drawing.Icon)
        Me.SysTrayIcon.Text = "Waven汉化启动器 by layah"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem3, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 76)
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
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'TestLabel2
        '
        Me.TestLabel2.AutoSize = True
        Me.TestLabel2.Location = New System.Drawing.Point(68, 94)
        Me.TestLabel2.Name = "TestLabel2"
        Me.TestLabel2.Size = New System.Drawing.Size(137, 12)
        Me.TestLabel2.TabIndex = 15
        Me.TestLabel2.Text = "测试输出用，发布请隐藏"
        Me.TestLabel2.Visible = False
        '
        'TestLabel1
        '
        Me.TestLabel1.AutoSize = True
        Me.TestLabel1.Location = New System.Drawing.Point(68, 75)
        Me.TestLabel1.Name = "TestLabel1"
        Me.TestLabel1.Size = New System.Drawing.Size(137, 12)
        Me.TestLabel1.TabIndex = 16
        Me.TestLabel1.Text = "测试输出用，发布请隐藏"
        Me.TestLabel1.Visible = False
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
        Me.StatusLabel.Text = "欢迎使用Waven汉化启动器"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.StatusLabel)
        Me.Panel1.Location = New System.Drawing.Point(5, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(478, 50)
        Me.Panel1.TabIndex = 19
        '
        'WLVerStatus
        '
        Me.WLVerStatus.AutoSize = True
        Me.WLVerStatus.BackColor = System.Drawing.Color.Transparent
        Me.WLVerStatus.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WLVerStatus.ForeColor = System.Drawing.Color.Yellow
        Me.WLVerStatus.Location = New System.Drawing.Point(490, 17)
        Me.WLVerStatus.Name = "WLVerStatus"
        Me.WLVerStatus.Size = New System.Drawing.Size(90, 20)
        Me.WLVerStatus.TabIndex = 20
        Me.WLVerStatus.Text = "检测更新中…"
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'PanelProgressBar
        '
        Me.PanelProgressBar.BackColor = System.Drawing.Color.Transparent
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
        'Timer3
        '
        Me.Timer3.Interval = 200
        '
        'Timer4
        '
        Me.Timer4.Interval = 10
        '
        'WavenLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(696, 411)
        Me.Controls.Add(Me.PanelProgressBar)
        Me.Controls.Add(Me.WLVerStatus)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonDirAL)
        Me.Controls.Add(Me.TestLabel1)
        Me.Controls.Add(Me.TestLabel2)
        Me.Controls.Add(Me.LabelDirAL)
        Me.Controls.Add(Me.SettingPanel)
        Me.Controls.Add(Me.OpenSettings)
        Me.Controls.Add(Me.IcoPicture)
        Me.Controls.Add(Me.FormTitle)
        Me.Controls.Add(Me.QuitForm)
        Me.Controls.Add(Me.WLVersionLabel)
        Me.Controls.Add(Me.StartButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WavenLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waven汉化启动器 by layah"
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SettingPanel.ResumeLayout(False)
        Me.SettingPanel.PerformLayout()
        Me.CloseAction.ResumeLayout(False)
        Me.CloseAction.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelProgressBar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As Button
    Friend WithEvents WLVersionLabel As Label
    Friend WithEvents ALVersionLabel As Label
    Friend WithEvents QuitForm As Button
    Friend WithEvents FormTitle As Label
    Friend WithEvents IcoPicture As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents OpenSettings As Button
    Friend WithEvents SettingPanel As Panel
    Friend WithEvents LocGameCheck As CheckBox
    Friend WithEvents LocALCheck As CheckBox
    Friend WithEvents CloseAction As GroupBox
    Friend WithEvents CloseForm2 As RadioButton
    Friend WithEvents CloseForm1 As RadioButton
    Friend WithEvents CloseForm0 As RadioButton
    Friend WithEvents SysTrayIcon As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonDirGM As Button
    Friend WithEvents ButtonDirAL As Button
    Friend WithEvents LabelDirGM As Label
    Friend WithEvents LabelDirAL As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TestLabel2 As Label
    Friend WithEvents TestLabel1 As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UpdateCN As Button
    Friend WithEvents WLVerStatus As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents AutoUDCheck As CheckBox
    Friend WithEvents PanelProgressBar As Panel
    Friend WithEvents PanelProgress As Panel
    Friend WithEvents Timer3 As Timer
    Friend WithEvents GMVersionLabel As Label
    Friend WithEvents Timer4 As Timer
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
