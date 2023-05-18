<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CmdCancel = New Button()
        CmdSave = New Button()
        CmdOK = New Button()
        LblLanguage = New Label()
        cboLanguage = New ComboBox()
        CkbAutostart = New CheckBox()
        SuspendLayout()
        ' 
        ' CmdCancel
        ' 
        CmdCancel.Location = New Point(94, 294)
        CmdCancel.Name = "CmdCancel"
        CmdCancel.Size = New Size(130, 30)
        CmdCancel.TabIndex = 4
        CmdCancel.Text = "Cancel"
        CmdCancel.UseVisualStyleBackColor = True
        ' 
        ' CmdSave
        ' 
        CmdSave.Location = New Point(305, 294)
        CmdSave.Name = "CmdSave"
        CmdSave.Size = New Size(130, 30)
        CmdSave.TabIndex = 2
        CmdSave.Text = "Save"
        CmdSave.UseVisualStyleBackColor = True
        ' 
        ' CmdOK
        ' 
        CmdOK.Location = New Point(578, 294)
        CmdOK.Name = "CmdOK"
        CmdOK.Size = New Size(130, 30)
        CmdOK.TabIndex = 3
        CmdOK.Text = "OK"
        CmdOK.UseVisualStyleBackColor = True
        ' 
        ' LblLanguage
        ' 
        LblLanguage.AutoSize = True
        LblLanguage.Location = New Point(102, 59)
        LblLanguage.Name = "LblLanguage"
        LblLanguage.Size = New Size(59, 15)
        LblLanguage.TabIndex = 0
        LblLanguage.Text = "Language"
        ' 
        ' cboLanguage
        ' 
        cboLanguage.FormattingEnabled = True
        cboLanguage.Location = New Point(233, 55)
        cboLanguage.Name = "cboLanguage"
        cboLanguage.Size = New Size(332, 23)
        cboLanguage.TabIndex = 1
        ' 
        ' CkbAutostart
        ' 
        CkbAutostart.AutoSize = True
        CkbAutostart.Location = New Point(236, 109)
        CkbAutostart.Name = "CkbAutostart"
        CkbAutostart.Size = New Size(75, 19)
        CkbAutostart.TabIndex = 5
        CkbAutostart.Text = "Autostart"
        CkbAutostart.UseVisualStyleBackColor = True
        ' 
        ' FrmOptions
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(CkbAutostart)
        Controls.Add(cboLanguage)
        Controls.Add(LblLanguage)
        Controls.Add(CmdCancel)
        Controls.Add(CmdSave)
        Controls.Add(CmdOK)
        Name = "FrmOptions"
        Text = "FrmOptions"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CmdCancel As Button
    Friend WithEvents CmdSave As Button
    Friend WithEvents CmdOK As Button
    Friend WithEvents LblLanguage As Label
    Friend WithEvents cboLanguage As ComboBox
    Friend WithEvents CkbAutostart As CheckBox
End Class
