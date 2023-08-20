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
        Me.QuitForm = New System.Windows.Forms.Button()
        Me.FormTitle = New System.Windows.Forms.Label()
        Me.IcoPicture = New System.Windows.Forms.PictureBox()
        Me.ShowToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.LabelDirGM = New System.Windows.Forms.Label()
        Me.OpenSettings = New System.Windows.Forms.Button()
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
        Me.Timer_CheckVersion = New System.Windows.Forms.Timer(Me.components)
        Me.SettingPanel = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GMVersionLabel = New System.Windows.Forms.Label()
        Me.ButtonSwitchLine = New System.Windows.Forms.Button()
        Me.ALVersionLabel = New System.Windows.Forms.Label()
        Me.LabelSwitchLine = New System.Windows.Forms.Label()
        Me.LocalGMVersionLabel = New System.Windows.Forms.Label()
        Me.LocalALVersionLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AutoUDCheck = New System.Windows.Forms.CheckBox()
        Me.UpdateCN = New System.Windows.Forms.Button()
        Me.LocGameCheck = New System.Windows.Forms.CheckBox()
        Me.LocALCheck = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.CloseAction = New System.Windows.Forms.GroupBox()
        Me.CloseForm2 = New System.Windows.Forms.RadioButton()
        Me.CloseForm1 = New System.Windows.Forms.RadioButton()
        Me.CloseForm0 = New System.Windows.Forms.RadioButton()
        Me.ButtonDirGM = New System.Windows.Forms.Button()
        Me.ButtonDirAL = New System.Windows.Forms.Button()
        Me.LabelDirAL = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.WindowedMode = New System.Windows.Forms.CheckBox()
        Me.PingLabel = New System.Windows.Forms.Label()
        Me.WindowHeight = New System.Windows.Forms.TextBox()
        Me.WindowWidth = New System.Windows.Forms.TextBox()
        Me.WindowResolution = New System.Windows.Forms.Label()
        Me.GraphQualityList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MiniForm = New System.Windows.Forms.Button()
        Me.Timer_HideForm = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Ping = New System.Windows.Forms.Timer(Me.components)
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SysTrayMenu.SuspendLayout()
        Me.StatusPanel.SuspendLayout()
        Me.PanelProgressBar.SuspendLayout()
        Me.SettingPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.CloseAction.SuspendLayout()
        Me.TabPage4.SuspendLayout()
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
        Me.QuitForm.TabIndex = 3
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
        Me.LabelDirGM.Location = New System.Drawing.Point(34, 59)
        Me.LabelDirGM.Name = "LabelDirGM"
        Me.LabelDirGM.Size = New System.Drawing.Size(307, 21)
        Me.LabelDirGM.TabIndex = 10
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
        Me.OpenSettings.TabIndex = 23
        Me.OpenSettings.Text = "设置"
        Me.OpenSettings.UseVisualStyleBackColor = False
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
        'Timer_CheckVersion
        '
        Me.Timer_CheckVersion.Interval = 50
        '
        'SettingPanel
        '
        Me.SettingPanel.BackColor = System.Drawing.Color.Teal
        Me.SettingPanel.Controls.Add(Me.TabControl1)
        Me.SettingPanel.Location = New System.Drawing.Point(305, 140)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.Size = New System.Drawing.Size(381, 202)
        Me.SettingPanel.TabIndex = 25
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Font = New System.Drawing.Font("微软雅黑", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(387, 205)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Teal
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.GMVersionLabel)
        Me.TabPage1.Controls.Add(Me.ButtonSwitchLine)
        Me.TabPage1.Controls.Add(Me.ALVersionLabel)
        Me.TabPage1.Controls.Add(Me.LabelSwitchLine)
        Me.TabPage1.Controls.Add(Me.LocalGMVersionLabel)
        Me.TabPage1.Controls.Add(Me.LocalALVersionLabel)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(379, 173)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "下载"
        '
        'GMVersionLabel
        '
        Me.GMVersionLabel.AutoSize = True
        Me.GMVersionLabel.BackColor = System.Drawing.Color.Teal
        Me.GMVersionLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GMVersionLabel.Enabled = False
        Me.GMVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GMVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.GMVersionLabel.Location = New System.Drawing.Point(187, 79)
        Me.GMVersionLabel.Name = "GMVersionLabel"
        Me.GMVersionLabel.Size = New System.Drawing.Size(106, 17)
        Me.GMVersionLabel.TabIndex = 9
        Me.GMVersionLabel.Text = "★ 点击下载游戏："
        '
        'ButtonSwitchLine
        '
        Me.ButtonSwitchLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSwitchLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSwitchLine.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonSwitchLine.ForeColor = System.Drawing.Color.White
        Me.ButtonSwitchLine.Location = New System.Drawing.Point(230, 30)
        Me.ButtonSwitchLine.Name = "ButtonSwitchLine"
        Me.ButtonSwitchLine.Size = New System.Drawing.Size(24, 19)
        Me.ButtonSwitchLine.TabIndex = 4
        Me.ButtonSwitchLine.Text = "…"
        Me.ButtonSwitchLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSwitchLine.UseVisualStyleBackColor = True
        '
        'ALVersionLabel
        '
        Me.ALVersionLabel.AutoSize = True
        Me.ALVersionLabel.BackColor = System.Drawing.Color.Teal
        Me.ALVersionLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ALVersionLabel.Enabled = False
        Me.ALVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ALVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.ALVersionLabel.Location = New System.Drawing.Point(24, 79)
        Me.ALVersionLabel.Name = "ALVersionLabel"
        Me.ALVersionLabel.Size = New System.Drawing.Size(106, 17)
        Me.ALVersionLabel.TabIndex = 4
        Me.ALVersionLabel.Text = "★ 点击下载战网："
        '
        'LabelSwitchLine
        '
        Me.LabelSwitchLine.BackColor = System.Drawing.Color.White
        Me.LabelSwitchLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelSwitchLine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelSwitchLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelSwitchLine.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelSwitchLine.Location = New System.Drawing.Point(135, 29)
        Me.LabelSwitchLine.Name = "LabelSwitchLine"
        Me.LabelSwitchLine.Size = New System.Drawing.Size(119, 21)
        Me.LabelSwitchLine.TabIndex = 5
        Me.LabelSwitchLine.Text = "国内下载线路"
        Me.LabelSwitchLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LocalGMVersionLabel
        '
        Me.LocalGMVersionLabel.AutoSize = True
        Me.LocalGMVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocalGMVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.LocalGMVersionLabel.Location = New System.Drawing.Point(187, 125)
        Me.LocalGMVersionLabel.Name = "LocalGMVersionLabel"
        Me.LocalGMVersionLabel.Size = New System.Drawing.Size(106, 17)
        Me.LocalGMVersionLabel.TabIndex = 15
        Me.LocalGMVersionLabel.Text = "★ 本地游戏版本："
        '
        'LocalALVersionLabel
        '
        Me.LocalALVersionLabel.AutoSize = True
        Me.LocalALVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocalALVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.LocalALVersionLabel.Location = New System.Drawing.Point(24, 125)
        Me.LocalALVersionLabel.Name = "LocalALVersionLabel"
        Me.LocalALVersionLabel.Size = New System.Drawing.Size(106, 17)
        Me.LocalALVersionLabel.TabIndex = 15
        Me.LocalALVersionLabel.Text = "★ 本地战网版本："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(24, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "★ 设置下载线路："
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Teal
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.AutoUDCheck)
        Me.TabPage2.Controls.Add(Me.UpdateCN)
        Me.TabPage2.Controls.Add(Me.LocGameCheck)
        Me.TabPage2.Controls.Add(Me.LocALCheck)
        Me.TabPage2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(379, 173)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "汉化"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(30, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "★ 游戏汉化："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(30, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "★ 战网汉化："
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
        Me.AutoUDCheck.Location = New System.Drawing.Point(241, 73)
        Me.AutoUDCheck.Name = "AutoUDCheck"
        Me.AutoUDCheck.Size = New System.Drawing.Size(99, 21)
        Me.AutoUDCheck.TabIndex = 17
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
        Me.UpdateCN.Location = New System.Drawing.Point(118, 110)
        Me.UpdateCN.Name = "UpdateCN"
        Me.UpdateCN.Size = New System.Drawing.Size(101, 25)
        Me.UpdateCN.TabIndex = 22
        Me.UpdateCN.Text = "强制下载汉化"
        Me.UpdateCN.UseVisualStyleBackColor = False
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
        Me.LocGameCheck.Location = New System.Drawing.Point(118, 73)
        Me.LocGameCheck.Name = "LocGameCheck"
        Me.LocGameCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocGameCheck.TabIndex = 16
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
        Me.LocALCheck.Location = New System.Drawing.Point(118, 36)
        Me.LocALCheck.Name = "LocALCheck"
        Me.LocALCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocALCheck.TabIndex = 15
        Me.LocALCheck.Text = "启用战网汉化"
        Me.LocALCheck.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Teal
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage3.Controls.Add(Me.CloseAction)
        Me.TabPage3.Controls.Add(Me.ButtonDirGM)
        Me.TabPage3.Controls.Add(Me.ButtonDirAL)
        Me.TabPage3.Controls.Add(Me.LabelDirAL)
        Me.TabPage3.Controls.Add(Me.LabelDirGM)
        Me.TabPage3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(379, 173)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "启动"
        '
        'CloseAction
        '
        Me.CloseAction.BackColor = System.Drawing.Color.Teal
        Me.CloseAction.Controls.Add(Me.CloseForm2)
        Me.CloseAction.Controls.Add(Me.CloseForm1)
        Me.CloseAction.Controls.Add(Me.CloseForm0)
        Me.CloseAction.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseAction.ForeColor = System.Drawing.Color.Yellow
        Me.CloseAction.Location = New System.Drawing.Point(34, 100)
        Me.CloseAction.Name = "CloseAction"
        Me.CloseAction.Size = New System.Drawing.Size(306, 56)
        Me.CloseAction.TabIndex = 7
        Me.CloseAction.TabStop = False
        Me.CloseAction.Text = "点击汉化启动器关闭按钮时"
        '
        'CloseForm2
        '
        Me.CloseForm2.AutoSize = True
        Me.CloseForm2.BackColor = System.Drawing.Color.Teal
        Me.CloseForm2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm2.Location = New System.Drawing.Point(195, 22)
        Me.CloseForm2.Name = "CloseForm2"
        Me.CloseForm2.Size = New System.Drawing.Size(110, 21)
        Me.CloseForm2.TabIndex = 9
        Me.CloseForm2.TabStop = True
        Me.CloseForm2.Text = "隐藏至系统托盘"
        Me.CloseForm2.UseVisualStyleBackColor = False
        '
        'CloseForm1
        '
        Me.CloseForm1.AutoSize = True
        Me.CloseForm1.BackColor = System.Drawing.Color.Teal
        Me.CloseForm1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseForm1.Location = New System.Drawing.Point(85, 22)
        Me.CloseForm1.Name = "CloseForm1"
        Me.CloseForm1.Size = New System.Drawing.Size(110, 21)
        Me.CloseForm1.TabIndex = 8
        Me.CloseForm1.TabStop = True
        Me.CloseForm1.Text = "最小化到任务栏"
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
        Me.CloseForm0.TabIndex = 7
        Me.CloseForm0.TabStop = True
        Me.CloseForm0.Text = "退出程序"
        Me.CloseForm0.UseVisualStyleBackColor = False
        '
        'ButtonDirGM
        '
        Me.ButtonDirGM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDirGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDirGM.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonDirGM.ForeColor = System.Drawing.Color.White
        Me.ButtonDirGM.Location = New System.Drawing.Point(316, 60)
        Me.ButtonDirGM.Name = "ButtonDirGM"
        Me.ButtonDirGM.Size = New System.Drawing.Size(24, 19)
        Me.ButtonDirGM.TabIndex = 6
        Me.ButtonDirGM.Text = "…"
        Me.ButtonDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirGM.UseVisualStyleBackColor = True
        '
        'ButtonDirAL
        '
        Me.ButtonDirAL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDirAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDirAL.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButtonDirAL.ForeColor = System.Drawing.Color.White
        Me.ButtonDirAL.Location = New System.Drawing.Point(316, 22)
        Me.ButtonDirAL.Name = "ButtonDirAL"
        Me.ButtonDirAL.Size = New System.Drawing.Size(24, 19)
        Me.ButtonDirAL.TabIndex = 5
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
        Me.LabelDirAL.Location = New System.Drawing.Point(34, 21)
        Me.LabelDirAL.Name = "LabelDirAL"
        Me.LabelDirAL.Size = New System.Drawing.Size(307, 21)
        Me.LabelDirAL.TabIndex = 7
        Me.LabelDirAL.Text = "选择Ankama战网路径"
        Me.LabelDirAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Teal
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Controls.Add(Me.WindowedMode)
        Me.TabPage4.Controls.Add(Me.PingLabel)
        Me.TabPage4.Controls.Add(Me.WindowHeight)
        Me.TabPage4.Controls.Add(Me.WindowWidth)
        Me.TabPage4.Controls.Add(Me.WindowResolution)
        Me.TabPage4.Controls.Add(Me.GraphQualityList)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 28)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(379, 173)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "游戏"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(37, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "★ 分辨率："
        '
        'WindowedMode
        '
        Me.WindowedMode.AutoSize = True
        Me.WindowedMode.BackColor = System.Drawing.Color.Teal
        Me.WindowedMode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WindowedMode.Enabled = False
        Me.WindowedMode.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WindowedMode.ForeColor = System.Drawing.Color.Yellow
        Me.WindowedMode.Location = New System.Drawing.Point(236, 35)
        Me.WindowedMode.Name = "WindowedMode"
        Me.WindowedMode.Size = New System.Drawing.Size(99, 21)
        Me.WindowedMode.TabIndex = 18
        Me.WindowedMode.Text = "窗口模式游戏"
        Me.WindowedMode.UseVisualStyleBackColor = False
        '
        'PingLabel
        '
        Me.PingLabel.AutoSize = True
        Me.PingLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PingLabel.ForeColor = System.Drawing.Color.Yellow
        Me.PingLabel.Location = New System.Drawing.Point(37, 120)
        Me.PingLabel.Name = "PingLabel"
        Me.PingLabel.Size = New System.Drawing.Size(109, 17)
        Me.PingLabel.TabIndex = 14
        Me.PingLabel.Text = "★ 游戏延迟：- ms"
        '
        'WindowHeight
        '
        Me.WindowHeight.BackColor = System.Drawing.SystemColors.Window
        Me.WindowHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.WindowHeight.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WindowHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WindowHeight.Location = New System.Drawing.Point(155, 36)
        Me.WindowHeight.MaxLength = 5
        Me.WindowHeight.Name = "WindowHeight"
        Me.WindowHeight.ShortcutsEnabled = False
        Me.WindowHeight.Size = New System.Drawing.Size(35, 16)
        Me.WindowHeight.TabIndex = 20
        Me.WindowHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WindowWidth
        '
        Me.WindowWidth.BackColor = System.Drawing.SystemColors.Window
        Me.WindowWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.WindowWidth.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WindowWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.WindowWidth.Location = New System.Drawing.Point(106, 36)
        Me.WindowWidth.MaxLength = 5
        Me.WindowWidth.Name = "WindowWidth"
        Me.WindowWidth.ShortcutsEnabled = False
        Me.WindowWidth.Size = New System.Drawing.Size(35, 16)
        Me.WindowWidth.TabIndex = 19
        Me.WindowWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WindowResolution
        '
        Me.WindowResolution.AutoSize = True
        Me.WindowResolution.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WindowResolution.ForeColor = System.Drawing.Color.Yellow
        Me.WindowResolution.Location = New System.Drawing.Point(138, 32)
        Me.WindowResolution.Name = "WindowResolution"
        Me.WindowResolution.Size = New System.Drawing.Size(22, 22)
        Me.WindowResolution.TabIndex = 14
        Me.WindowResolution.Text = "×"
        '
        'GraphQualityList
        '
        Me.GraphQualityList.BackColor = System.Drawing.Color.Teal
        Me.GraphQualityList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GraphQualityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GraphQualityList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GraphQualityList.ForeColor = System.Drawing.Color.Yellow
        Me.GraphQualityList.FormattingEnabled = True
        Me.GraphQualityList.ItemHeight = 17
        Me.GraphQualityList.Items.AddRange(New Object() {"极低", "低", "中等", "高", "极致"})
        Me.GraphQualityList.Location = New System.Drawing.Point(117, 73)
        Me.GraphQualityList.Name = "GraphQualityList"
        Me.GraphQualityList.Size = New System.Drawing.Size(73, 25)
        Me.GraphQualityList.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(37, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "★ 游戏画质："
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
        Me.MiniForm.TabIndex = 2
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
        Me.SysTrayMenu.ResumeLayout(False)
        Me.StatusPanel.ResumeLayout(False)
        Me.StatusPanel.PerformLayout()
        Me.PanelProgressBar.ResumeLayout(False)
        Me.SettingPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.CloseAction.ResumeLayout(False)
        Me.CloseAction.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As Button
    Friend WithEvents WLVersionLabel As Label
    Friend WithEvents QuitForm As Button
    Friend WithEvents FormTitle As Label
    Friend WithEvents IcoPicture As PictureBox
    Friend WithEvents ShowToolTip As ToolTip
    Friend WithEvents OpenSettings As Button
    Friend WithEvents SysTrayIcon As NotifyIcon
    Friend WithEvents Timer_ShowForm As Timer
    Friend WithEvents SysTrayMenu As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SelectDirDialog As OpenFileDialog
    Friend WithEvents StatusLabel As Label
    Friend WithEvents StatusPanel As Panel
    Friend WithEvents WLVerStatus As Label
    Friend WithEvents Timer_NewVersionNeon As Timer
    Friend WithEvents PanelProgressBar As Panel
    Friend WithEvents PanelProgress As Panel
    Friend WithEvents Timer_ShowDSpeed As Timer
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents Timer_CheckVersion As Timer
    Friend WithEvents SettingPanel As Panel
    Friend WithEvents MiniForm As Button
    Friend WithEvents Timer_HideForm As Timer
    Friend WithEvents Timer_Ping As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GMVersionLabel As Label
    Friend WithEvents ButtonSwitchLine As Button
    Friend WithEvents ALVersionLabel As Label
    Friend WithEvents LabelSwitchLine As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents AutoUDCheck As CheckBox
    Friend WithEvents UpdateCN As Button
    Friend WithEvents LocGameCheck As CheckBox
    Friend WithEvents LocALCheck As CheckBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents CloseAction As GroupBox
    Friend WithEvents CloseForm2 As RadioButton
    Friend WithEvents CloseForm1 As RadioButton
    Friend WithEvents CloseForm0 As RadioButton
    Friend WithEvents ButtonDirGM As Button
    Friend WithEvents ButtonDirAL As Button
    Friend WithEvents LabelDirAL As Label
    Friend WithEvents LabelDirGM As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents WindowedMode As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PingLabel As Label
    Friend WithEvents WindowHeight As TextBox
    Friend WithEvents WindowWidth As TextBox
    Friend WithEvents WindowResolution As Label
    Friend WithEvents GraphQualityList As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LocalGMVersionLabel As Label
    Friend WithEvents LocalALVersionLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
End Class
