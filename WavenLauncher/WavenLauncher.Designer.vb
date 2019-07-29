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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WavenLauncher))
        Me.DownloadAL = New System.Windows.Forms.Button()
        Me.LocAL = New System.Windows.Forms.Button()
        Me.LocGame = New System.Windows.Forms.Button()
        Me.WLVersion = New System.Windows.Forms.Label()
        Me.ALVersion = New System.Windows.Forms.Label()
        Me.QuitForm = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'DownloadAL
        '
        Me.DownloadAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DownloadAL.Location = New System.Drawing.Point(321, 339)
        Me.DownloadAL.Name = "DownloadAL"
        Me.DownloadAL.Size = New System.Drawing.Size(117, 60)
        Me.DownloadAL.TabIndex = 1
        Me.DownloadAL.Text = "下载Ankama Launcher"
        Me.DownloadAL.UseVisualStyleBackColor = True
        '
        'LocAL
        '
        Me.LocAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LocAL.Location = New System.Drawing.Point(444, 339)
        Me.LocAL.Name = "LocAL"
        Me.LocAL.Size = New System.Drawing.Size(117, 60)
        Me.LocAL.TabIndex = 2
        Me.LocAL.Text = "汉化启动战网"
        Me.LocAL.UseVisualStyleBackColor = True
        '
        'LocGame
        '
        Me.LocGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LocGame.Location = New System.Drawing.Point(567, 339)
        Me.LocGame.Name = "LocGame"
        Me.LocGame.Size = New System.Drawing.Size(117, 60)
        Me.LocGame.TabIndex = 3
        Me.LocGame.Text = "汉化开始游戏"
        Me.LocGame.UseVisualStyleBackColor = True
        '
        'WLVersion
        '
        Me.WLVersion.AutoSize = True
        Me.WLVersion.Location = New System.Drawing.Point(293, 17)
        Me.WLVersion.Name = "WLVersion"
        Me.WLVersion.Size = New System.Drawing.Size(191, 12)
        Me.WLVersion.TabIndex = 3
        Me.WLVersion.Text = "汉化启动器版本：xxxx - by layah"
        '
        'ALVersion
        '
        Me.ALVersion.AutoSize = True
        Me.ALVersion.Location = New System.Drawing.Point(12, 352)
        Me.ALVersion.Name = "ALVersion"
        Me.ALVersion.Size = New System.Drawing.Size(155, 12)
        Me.ALVersion.TabIndex = 4
        Me.ALVersion.Text = "适用Ankama Launcher版本："
        '
        'QuitForm
        '
        Me.QuitForm.BackColor = System.Drawing.Color.Red
        Me.QuitForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.QuitForm.Font = New System.Drawing.Font("锐字锐线怒放黑简1.0", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.QuitForm.Location = New System.Drawing.Point(667, 2)
        Me.QuitForm.Name = "QuitForm"
        Me.QuitForm.Size = New System.Drawing.Size(27, 27)
        Me.QuitForm.TabIndex = 0
        Me.QuitForm.Text = "×"
        Me.QuitForm.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(173, 349)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 21)
        Me.TextBox2.TabIndex = 6
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 381)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(71, 12)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "广告位招租1"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(123, 381)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(71, 12)
        Me.LinkLabel2.TabIndex = 8
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "广告位招租2"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(220, 381)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(71, 12)
        Me.LinkLabel3.TabIndex = 9
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "广告位招租3"
        '
        'WavenLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(696, 411)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.QuitForm)
        Me.Controls.Add(Me.ALVersion)
        Me.Controls.Add(Me.WLVersion)
        Me.Controls.Add(Me.LocGame)
        Me.Controls.Add(Me.LocAL)
        Me.Controls.Add(Me.DownloadAL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WavenLauncher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Waven汉化启动器 by layah"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DownloadAL As Button
    Friend WithEvents LocAL As Button
    Friend WithEvents LocGame As Button
    Friend WithEvents WLVersion As Label
    Friend WithEvents ALVersion As Label
    Friend WithEvents QuitForm As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
End Class
