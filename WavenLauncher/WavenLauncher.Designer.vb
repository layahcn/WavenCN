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
        Me.ButtonDirGM = New System.Windows.Forms.Button()
        Me.ButtonDirAL = New System.Windows.Forms.Button()
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TestLabel2 = New System.Windows.Forms.Label()
        Me.TestLabel1 = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UpdateLoc = New System.Windows.Forms.Button()
        CType(Me.IcoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SettingPanel.SuspendLayout()
        Me.CloseAction.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Teal
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StartButton.ForeColor = System.Drawing.Color.Yellow
        Me.StartButton.Location = New System.Drawing.Point(571, 350)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(115, 45)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "启动战网"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'WLVersionLabel
        '
        Me.WLVersionLabel.AutoSize = True
        Me.WLVersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.WLVersionLabel.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.WLVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.WLVersionLabel.Location = New System.Drawing.Point(340, 26)
        Me.WLVersionLabel.Name = "WLVersionLabel"
        Me.WLVersionLabel.Size = New System.Drawing.Size(63, 15)
        Me.WLVersionLabel.TabIndex = 3
        Me.WLVersionLabel.Text = "版本号："
        '
        'ALVersionLabel
        '
        Me.ALVersionLabel.AutoSize = True
        Me.ALVersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.ALVersionLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ALVersionLabel.ForeColor = System.Drawing.Color.Yellow
        Me.ALVersionLabel.Location = New System.Drawing.Point(18, 120)
        Me.ALVersionLabel.Name = "ALVersionLabel"
        Me.ALVersionLabel.Size = New System.Drawing.Size(178, 17)
        Me.ALVersionLabel.TabIndex = 4
        Me.ALVersionLabel.Text = "适用Ankama Launcher版本："
        '
        'QuitForm
        '
        Me.QuitForm.BackColor = System.Drawing.Color.Red
        Me.QuitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitForm.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.QuitForm.Location = New System.Drawing.Point(664, 5)
        Me.QuitForm.Name = "QuitForm"
        Me.QuitForm.Size = New System.Drawing.Size(27, 27)
        Me.QuitForm.TabIndex = 0
        Me.QuitForm.Text = "×"
        Me.QuitForm.UseVisualStyleBackColor = False
        '
        'FormTitle
        '
        Me.FormTitle.AutoSize = True
        Me.FormTitle.BackColor = System.Drawing.Color.Transparent
        Me.FormTitle.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormTitle.ForeColor = System.Drawing.Color.Yellow
        Me.FormTitle.Location = New System.Drawing.Point(61, 22)
        Me.FormTitle.Name = "FormTitle"
        Me.FormTitle.Size = New System.Drawing.Size(272, 20)
        Me.FormTitle.TabIndex = 10
        Me.FormTitle.Text = "Waven汉化启动器 by layah"
        '
        'IcoPicture
        '
        Me.IcoPicture.BackColor = System.Drawing.Color.Transparent
        Me.IcoPicture.Image = CType(resources.GetObject("IcoPicture.Image"), System.Drawing.Image)
        Me.IcoPicture.Location = New System.Drawing.Point(2, 7)
        Me.IcoPicture.Name = "IcoPicture"
        Me.IcoPicture.Size = New System.Drawing.Size(63, 52)
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
        Me.LabelDirGM.Location = New System.Drawing.Point(22, 17)
        Me.LabelDirGM.Name = "LabelDirGM"
        Me.LabelDirGM.Size = New System.Drawing.Size(437, 21)
        Me.LabelDirGM.TabIndex = 4
        Me.LabelDirGM.Text = "选择Waven游戏路径"
        Me.LabelDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.LabelDirGM, "选择Waven游戏路径")
        '
        'OpenSettings
        '
        Me.OpenSettings.BackColor = System.Drawing.Color.Teal
        Me.OpenSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenSettings.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
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
        Me.SettingPanel.Controls.Add(Me.UpdateLoc)
        Me.SettingPanel.Controls.Add(Me.ButtonDirGM)
        Me.SettingPanel.Controls.Add(Me.ALVersionLabel)
        Me.SettingPanel.Controls.Add(Me.LabelDirGM)
        Me.SettingPanel.Controls.Add(Me.LocGameCheck)
        Me.SettingPanel.Controls.Add(Me.LocALCheck)
        Me.SettingPanel.Controls.Add(Me.CloseAction)
        Me.SettingPanel.ForeColor = System.Drawing.Color.Yellow
        Me.SettingPanel.Location = New System.Drawing.Point(201, 187)
        Me.SettingPanel.Name = "SettingPanel"
        Me.SettingPanel.Size = New System.Drawing.Size(483, 157)
        Me.SettingPanel.TabIndex = 13
        Me.SettingPanel.Visible = False
        '
        'ButtonDirGM
        '
        Me.ButtonDirGM.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonDirGM.Location = New System.Drawing.Point(436, 18)
        Me.ButtonDirGM.Name = "ButtonDirGM"
        Me.ButtonDirGM.Size = New System.Drawing.Size(22, 19)
        Me.ButtonDirGM.TabIndex = 6
        Me.ButtonDirGM.Text = "…"
        Me.ButtonDirGM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDirGM.UseVisualStyleBackColor = True
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
        'LocGameCheck
        '
        Me.LocGameCheck.AutoSize = True
        Me.LocGameCheck.BackColor = System.Drawing.Color.Transparent
        Me.LocGameCheck.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LocGameCheck.ForeColor = System.Drawing.Color.Yellow
        Me.LocGameCheck.Location = New System.Drawing.Point(367, 88)
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
        Me.LocALCheck.Location = New System.Drawing.Point(367, 57)
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
        Me.CloseAction.Location = New System.Drawing.Point(20, 57)
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
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 54)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(136, 22)
        Me.ToolStripMenuItem1.Text = "显示主界面"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(136, 22)
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
        '
        'TestLabel1
        '
        Me.TestLabel1.AutoSize = True
        Me.TestLabel1.Location = New System.Drawing.Point(68, 75)
        Me.TestLabel1.Name = "TestLabel1"
        Me.TestLabel1.Size = New System.Drawing.Size(137, 12)
        Me.TestLabel1.TabIndex = 16
        Me.TestLabel1.Text = "测试输出用，发布请隐藏"
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StatusLabel.ForeColor = System.Drawing.Color.Yellow
        Me.StatusLabel.Location = New System.Drawing.Point(0, 33)
        Me.StatusLabel.MaximumSize = New System.Drawing.Size(450, 100)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(68, 17)
        Me.StatusLabel.TabIndex = 17
        Me.StatusLabel.Text = "状态：就绪"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Teal
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Yellow
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 401)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 10)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 18
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
        'UpdateLoc
        '
        Me.UpdateLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpdateLoc.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpdateLoc.Location = New System.Drawing.Point(374, 116)
        Me.UpdateLoc.Name = "UpdateLoc"
        Me.UpdateLoc.Size = New System.Drawing.Size(88, 25)
        Me.UpdateLoc.TabIndex = 7
        Me.UpdateLoc.Text = "更新汉化"
        Me.UpdateLoc.UseVisualStyleBackColor = True
        '
        'WavenLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(696, 411)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonDirAL)
        Me.Controls.Add(Me.TestLabel1)
        Me.Controls.Add(Me.TestLabel2)
        Me.Controls.Add(Me.LabelDirAL)
        Me.Controls.Add(Me.VersionState)
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
    Friend WithEvents VersionState As Label
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
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UpdateLoc As Button
End Class
