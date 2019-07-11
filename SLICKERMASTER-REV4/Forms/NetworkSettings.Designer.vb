<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NetworkSettings
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Port = New System.Windows.Forms.NumericUpDown()
        Me.Pass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.shps = New System.Windows.Forms.CheckBox()
        Me.strt = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.autostrt = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveImplantFromDENYListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddImplantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Port, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Socket Port : "
        '
        'Port
        '
        Me.Port.Location = New System.Drawing.Point(128, 23)
        Me.Port.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Port.Name = "Port"
        Me.Port.Size = New System.Drawing.Size(193, 20)
        Me.Port.TabIndex = 1
        Me.Port.Value = New Decimal(New Integer() {6666, 0, 0, 0})
        '
        'Pass
        '
        Me.Pass.Location = New System.Drawing.Point(128, 49)
        Me.Pass.Name = "Pass"
        Me.Pass.Size = New System.Drawing.Size(193, 20)
        Me.Pass.TabIndex = 2
        Me.Pass.Text = "pa$$word"
        Me.Pass.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Connection Password :"
        '
        'shps
        '
        Me.shps.AutoSize = True
        Me.shps.Location = New System.Drawing.Point(128, 75)
        Me.shps.Name = "shps"
        Me.shps.Size = New System.Drawing.Size(102, 17)
        Me.shps.TabIndex = 4
        Me.shps.Text = "Show Password"
        Me.shps.UseVisualStyleBackColor = True
        '
        'strt
        '
        Me.strt.Location = New System.Drawing.Point(252, 98)
        Me.strt.Name = "strt"
        Me.strt.Size = New System.Drawing.Size(69, 25)
        Me.strt.TabIndex = 5
        Me.strt.Text = "Start"
        Me.strt.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 309)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(337, 25)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Save and Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'autostrt
        '
        Me.autostrt.AutoSize = True
        Me.autostrt.Location = New System.Drawing.Point(248, 75)
        Me.autostrt.Name = "autostrt"
        Me.autostrt.Size = New System.Drawing.Size(73, 17)
        Me.autostrt.TabIndex = 7
        Me.autostrt.Text = "Auto Start"
        Me.autostrt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.autostrt)
        Me.GroupBox1.Controls.Add(Me.Port)
        Me.GroupBox1.Controls.Add(Me.Pass)
        Me.GroupBox1.Controls.Add(Me.strt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.shps)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 172)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 131)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Socket Server"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 154)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Deny List"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(9, 19)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(312, 119)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IP"
        Me.ColumnHeader1.Width = 307
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddImplantToolStripMenuItem, Me.RemoveImplantFromDENYListToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 48)
        '
        'RemoveImplantFromDENYListToolStripMenuItem
        '
        Me.RemoveImplantFromDENYListToolStripMenuItem.Name = "RemoveImplantFromDENYListToolStripMenuItem"
        Me.RemoveImplantFromDENYListToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.RemoveImplantFromDENYListToolStripMenuItem.Text = "Remove Implant"
        '
        'AddImplantToolStripMenuItem
        '
        Me.AddImplantToolStripMenuItem.Name = "AddImplantToolStripMenuItem"
        Me.AddImplantToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.AddImplantToolStripMenuItem.Text = "Add Implant "
        '
        'NetworkSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 346)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NetworkSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Network Settings"
        CType(Me.Port, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Port As NumericUpDown
    Friend WithEvents Pass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents shps As CheckBox
    Friend WithEvents strt As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents autostrt As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddImplantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveImplantFromDENYListToolStripMenuItem As ToolStripMenuItem
End Class
