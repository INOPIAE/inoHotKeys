<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DgvSettings = New DataGridView()
        Alt = New DataGridViewCheckBoxColumn()
        Ctrl = New DataGridViewCheckBoxColumn()
        Shift = New DataGridViewCheckBoxColumn()
        Win = New DataGridViewCheckBoxColumn()
        Taste = New DataGridViewTextBoxColumn()
        Action = New DataGridViewTextBoxColumn()
        CmdOK = New Button()
        CmdSave = New Button()
        CmdCancel = New Button()
        CType(DgvSettings, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvSettings
        ' 
        DgvSettings.AllowUserToAddRows = False
        DgvSettings.AllowUserToDeleteRows = False
        DgvSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvSettings.Columns.AddRange(New DataGridViewColumn() {Alt, Ctrl, Shift, Win, Taste, Action})
        DgvSettings.Location = New Point(15, 15)
        DgvSettings.Name = "DgvSettings"
        DgvSettings.RowTemplate.Height = 25
        DgvSettings.Size = New Size(519, 161)
        DgvSettings.TabIndex = 0
        ' 
        ' Alt
        ' 
        Alt.HeaderText = "Alt"
        Alt.Name = "Alt"
        Alt.Width = 50
        ' 
        ' Ctrl
        ' 
        Ctrl.HeaderText = "Ctrl"
        Ctrl.Name = "Ctrl"
        Ctrl.Width = 50
        ' 
        ' Shift
        ' 
        Shift.HeaderText = "Shift"
        Shift.Name = "Shift"
        Shift.Width = 50
        ' 
        ' Win
        ' 
        Win.HeaderText = "Win"
        Win.Name = "Win"
        Win.Width = 50
        ' 
        ' Taste
        ' 
        Taste.HeaderText = "Taste"
        Taste.Name = "Taste"
        Taste.Width = 50
        ' 
        ' Action
        ' 
        Action.HeaderText = "Action"
        Action.Name = "Action"
        Action.Width = 200
        ' 
        ' CmdOK
        ' 
        CmdOK.Location = New Point(510, 224)
        CmdOK.Name = "CmdOK"
        CmdOK.Size = New Size(130, 30)
        CmdOK.TabIndex = 1
        CmdOK.Text = "OK"
        CmdOK.UseVisualStyleBackColor = True
        ' 
        ' CmdSave
        ' 
        CmdSave.Location = New Point(237, 224)
        CmdSave.Name = "CmdSave"
        CmdSave.Size = New Size(130, 30)
        CmdSave.TabIndex = 1
        CmdSave.Text = "Save"
        CmdSave.UseVisualStyleBackColor = True
        ' 
        ' CmdCancel
        ' 
        CmdCancel.Location = New Point(26, 224)
        CmdCancel.Name = "CmdCancel"
        CmdCancel.Size = New Size(130, 30)
        CmdCancel.TabIndex = 1
        CmdCancel.Text = "Cancel"
        CmdCancel.UseVisualStyleBackColor = True
        ' 
        ' FrmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(CmdCancel)
        Controls.Add(CmdSave)
        Controls.Add(CmdOK)
        Controls.Add(DgvSettings)
        Name = "FrmSettings"
        Text = "Shortcut Settings"
        CType(DgvSettings, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvSettings As DataGridView
    Friend WithEvents CmdOK As Button
    Friend WithEvents CmdSave As Button
    Friend WithEvents CmdCancel As Button
    Friend WithEvents Alt As DataGridViewCheckBoxColumn
    Friend WithEvents Ctrl As DataGridViewCheckBoxColumn
    Friend WithEvents Shift As DataGridViewCheckBoxColumn
    Friend WithEvents Win As DataGridViewCheckBoxColumn
    Friend WithEvents Taste As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewTextBoxColumn
End Class
