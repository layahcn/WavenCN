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
        Me.StartAL = New System.Windows.Forms.Button()
        Me.StartGame = New System.Windows.Forms.Button()
        Me.WLVersion = New System.Windows.Forms.Label()
        Me.ALVersion = New System.Windows.Forms.Label()
        Me.QuitForm = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.FormTitle = New System.Windows.Forms.Label()
        Me.IcoPicture = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenSettings = New System.Windows.Forms.Button()
        Me.SettingPanel = New System.Windows.Forms.Panel()
        Me.LocGameCheck = New System.Windows.Forms.CheckBox()
        Me.LocALCheck = New System.Windows.Forms.CheckBox()
        Me.CloseAction = New System.Windows.Forms.GroupBox()
        Me.CloseForm2 = New System.Windows.Forms.RadioButton()
        Me.CloseForm1 = New System.Windows.Forms.RadioButton()
        Me.CloseForm0 = New System.Windows.Forms.RadioButton()
        Me.VersionState = New System.Windows.Forms.Label()
        Me.SysTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SettingPanel.SuspendLayout()
        Me.CloseAction.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartAL
        '
        Me.StartAL.BackColor = System.Drawing.Color.Teal
        Me.StartAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartAL.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StartAL.ForeColor = System.Drawing.Color.Yellow
        Me.StartAL.Location = New System.Drawing.Point(449, 350)
        Me.StartAL.Name = "StartAL"
        Me.StartAL.Size = New System.Drawing.Size(115, 45)
        Me.StartAL.TabIndex = 1
        Me.StartAL.Text = "启动战网"
        Me.StartAL.UseVisualStyleBackColor = False
        '
        'StartGame
        '
        Me.StartGame.BackColor = System.Drawing.Color.Teal
        Me.StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartGame.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StartGame.ForeColor = System.Drawing.Color.Yellow
        Me.StartGame.Location = New System.Drawing.Point(569, 350)
        Me.StartGame.Name = "StartGame"
        Me.StartGame.Size = New System.Drawing.Size(115, 45)
        Me.StartGame.TabIndex = 2
        Me.StartGame.Text = "开始游戏"
        Me.StartGame.UseVisualStyleBackColor = False
        '
        'WLVersion
        '
        Me.WLVersion.AutoSize = True
        Me.WLVersion.BackColor = System.Drawing.Color.Transparent
        Me.WLVersion.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WLVersion.ForeColor = System.Drawing.Color.Yellow
        Me.WLVersion.Location = New System.Drawing.Point(281, 19)
        Me.WLVersion.Name = "WLVersion"
        Me.WLVersion.Size = New System.Drawing.Size(63, 15)
        Me.WLVersion.TabIndex = 3
        Me.WLVersion.Text = "版本号："
        '
        'ALVersion
        '
        Me.ALVersion.AutoSize = True
        Me.ALVersion.BackColor = System.Drawing.Color.Transparent
        Me.ALVersion.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ALVersion.ForeColor = System.Drawing.Color.Yellow
        Me.ALVersion.Location = New System.Drawing.Point(22, 350)
        Me.ALVersion.Name = "ALVersion"
        Me.ALVersion.Size = New System.Drawing.Size(205, 19)
        Me.ALVersion.TabIndex = 4
        Me.ALVersion.Text = "适用Ankama Launcher版本："
        '
        'QuitForm
        '
        Me.QuitForm.BackColor = System.Drawing.Color.Red
        Me.QuitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitForm.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.QuitForm.Location = New System.Drawing.Point(659, 10)
        Me.QuitForm.Name = "QuitForm"
        Me.QuitForm.Size = New System.Drawing.Size(27, 27)
        Me.QuitForm.TabIndex = 0
        Me.QuitForm.Text = "×"
        Me.QuitForm.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel1.Location = New System.Drawing.Point(23, 376)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(75, 17)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "广告位招租1"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel2.Location = New System.Drawing.Point(125, 376)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(75, 17)
        Me.LinkLabel2.TabIndex = 8
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "广告位招租2"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel3.Location = New System.Drawing.Point(222, 376)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(75, 17)
        Me.LinkLabel3.TabIndex = 9
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "广告位招租3"
        '
        'FormTitle
        '
        Me.FormTitle.AutoSize = True
        Me.FormTitle.BackColor = System.Drawing.Color.Transparent
        Me.FormTitle.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormTitle.ForeColor = System.Drawing.Color.Yellow
        Me.FormTitle.Location = New System.Drawing.Point(45, 17)
        Me.FormTitle.Name = "FormTitle"
        Me.FormTitle.Size = New System.Drawing.Size(230, 17)
        Me.FormTitle.TabIndex = 10
        Me.FormTitle.Text = "Waven汉化启动器 by layah"
        '
        'IcoPicture
        '
        Me.IcoPicture.BackColor = System.Drawing.Color.Transparent
        Me.IcoPicture.Image = CType(resources.GetObject("IcoPicture.Image"), System.Drawing.Image)
        Me.IcoPicture.Location = New System.Drawing.Point(10, 10)
        Me.IcoPicture.Name = "IcoPicture"
        Me.IcoPicture.Size = New System.Drawing.Size(30, 30)
        Me.IcoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IcoPicture.TabIndex = 11
        Me.IcoPicture.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'OpenSettings
        '
        Me.OpenSettings.BackColor = System.Drawing.Color.Teal
        Me.OpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSettings.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OpenSettings.ForeColor = System.Drawing.Color.Yellow
        Me.OpenSettings.Location = New System.Drawing.Point(328, 350)
        Me.OpenSettings.Name = "OpenSettings"
        Me.OpenSettings.Size = New System.Drawing.Size(115, 45)
        Me.OpenSettings.TabIndex = 12
        Me.OpenSettings.Text = "打开设置"
        Me.OpenSettings.UseVisualStyleBackColor = False
        '
        'SettingPanel
        '
        Me.SettingPanel.BackColor = System.Drawing.Color.Teal
        Me.SettingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SettingPanel.Controls.Add(Me.LocGameCheck)
        Me.SettingPanel.Controls.Add(Me.LocALCheck)
        Me.SettingPanel.Controls.Add(Me.CloseAction)
        Me.SettingPanel.ForeColor = System.Drawing.Color.Yellow
        Me.SettingPanel.Location = New System.Drawing.Point(328, 229)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.Size = New System.Drawing.Size(356, 115)
        Me.SettingPanel.TabIndex = 13
        Me.SettingPanel.Visible = False
        '
        'LocGameCheck
        '
        Me.LocGameCheck.AutoSize = True
        Me.LocGameCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocGameCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocGameCheck.Location = New System.Drawing.Point(203, 80)
        Me.LocGameCheck.Name = "LocGameCheck"
        Me.LocGameCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocGameCheck.TabIndex = 2
        Me.LocGameCheck.Text = "汉化启动游戏"
        Me.LocGameCheck.UseVisualStyleBackColor = True
        '
        'LocALCheck
        '
        Me.LocALCheck.AutoSize = True
        Me.LocALCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocALCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocALCheck.Location = New System.Drawing.Point(41, 80)
        Me.LocALCheck.Name = "LocALCheck"
        Me.LocALCheck.Size = New System.Drawing.Size(99, 21)
        Me.LocALCheck.TabIndex = 1
        Me.LocALCheck.Text = "汉化启动战网"
        Me.LocALCheck.UseVisualStyleBackColor = True
        '
        'CloseAction
        '
        Me.CloseAction.Controls.Add(Me.CloseForm2)
        Me.CloseAction.Controls.Add(Me.CloseForm1)
        Me.CloseAction.Controls.Add(Me.CloseForm0)
        Me.CloseAction.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseAction.ForeColor = System.Drawing.Color.Yellow
        Me.CloseAction.Location = New System.Drawing.Point(23, 20)
        Me.CloseAction.Name = "CloseAction"
        Me.CloseAction.Size = New System.Drawing.Size(310, 52)
        Me.CloseAction.TabIndex = 0
        Me.CloseAction.TabStop = False
        Me.CloseAction.Text = "点击右上角关闭按钮时"
        '
        'CloseForm2
        '
        Me.CloseForm2.AutoSize = True
        Me.CloseForm2.Location = New System.Drawing.Point(176, 23)
        Me.CloseForm2.Name = "CloseForm2"
        Me.CloseForm2.Size = New System.Drawing.Size(122, 21)
        Me.CloseForm2.TabIndex = 2
        Me.CloseForm2.TabStop = True
        Me.CloseForm2.Text = "最小化到系统托盘"
        Me.CloseForm2.UseVisualStyleBackColor = True
        '
        'CloseForm1
        '
        Me.CloseForm1.AutoSize = True
        Me.CloseForm1.Location = New System.Drawing.Point(99, 23)
        Me.CloseForm1.Name = "CloseForm1"
        Me.CloseForm1.Size = New System.Drawing.Size(62, 21)
        Me.CloseForm1.TabIndex = 1
        Me.CloseForm1.TabStop = True
        Me.CloseForm1.Text = "最小化"
        Me.CloseForm1.UseVisualStyleBackColor = True
        '
        'CloseForm0
        '
        Me.CloseForm0.AutoSize = True
        Me.CloseForm0.Location = New System.Drawing.Point(14, 23)
        Me.CloseForm0.Name = "CloseForm0"
        Me.CloseForm0.Size = New System.Drawing.Size(74, 21)
        Me.CloseForm0.TabIndex = 0
        Me.CloseForm0.TabStop = True
        Me.CloseForm0.Text = "退出程序"
        Me.CloseForm0.UseVisualStyleBackColor = True
        '
        'VersionState
        '
        Me.VersionState.AutoSize = True
        Me.VersionState.BackColor = System.Drawing.Color.Transparent
        Me.VersionState.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.VersionState.ForeColor = System.Drawing.Color.Yellow
        Me.VersionState.Location = New System.Drawing.Point(446, 19)
        Me.VersionState.Name = "VersionState"
        Me.VersionState.Size = New System.Drawing.Size(0, 15)
        Me.VersionState.TabIndex = 14
        '
        'SysTrayIcon
        '
        Me.SysTrayIcon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.SysTrayIcon.Icon = CType(resources.GetObject("SysTrayIcon.Icon"), System.Drawing.Icon)
        Me.SysTrayIcon.Text = "Waven汉化启动器 by layah"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem1.Text = "显示主界面"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem2.Text = "退出"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'WavenLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(696, 411)
        Me.Controls.Add(Me.VersionState)
        Me.Controls.Add(Me.SettingPanel)
        Me.Controls.Add(Me.OpenSettings)
        Me.Controls.Add(Me.IcoPicture)
        Me.Controls.Add(Me.FormTitle)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.QuitForm)
        Me.Controls.Add(Me.ALVersion)
        Me.Controls.Add(Me.WLVersion)
        Me.Controls.Add(Me.StartGame)
        Me.Controls.Add(Me.StartAL)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartAL As Button
    Friend WithEvents StartGame As Button
    Friend WithEvents WLVersion As Label
    Friend WithEvents ALVersion As Label
    Friend WithEvents QuitForm As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
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
    Friend WithEvents VersionState As Label
    Friend WithEvents SysTrayIcon As NotifyIcon
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
