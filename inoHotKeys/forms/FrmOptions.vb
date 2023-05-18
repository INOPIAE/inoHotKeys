Imports System.Globalization
Imports System.Threading

Public Class FrmOptions
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        Me.CmdSave.PerformClick()
        Me.Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If ClsLang.CurrentLanguage <> ClsLang.LanguageSettings(cboLanguage.SelectedIndex).LanguageName Then
            ClsLang.CurrentLanguage = ClsLang.LanguageSettings(cboLanguage.SelectedIndex).LanguageName
            MessageBox.Show(My.Resources.Resources.OptionMessageLanguageChange)
        End If
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(ClsLang.CurrentLanguage)
        My.Settings.Language = ClsLang.CurrentLanguage
        My.Settings.Save()
    End Sub

    Private Sub FrmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentIndex As Int16 = 0
        For intCount = 0 To ClsLang.LanguageSettings.Length - 1
            cboLanguage.Items.Add(String.Format("{0} - {1}", ClsLang.LanguageSettings(intCount).LanguageNative, ClsLang.LanguageSettings(intCount).Language))
            If ClsLang.LanguageSettings(intCount).LanguageName = ClsLang.CurrentLanguage Then
                currentIndex = intCount
            End If
        Next
        cboLanguage.SelectedIndex = currentIndex
        AddTranslation()
    End Sub

    Private Sub AddTranslation()
        Me.Text = My.Resources.Resources.OptionTitel
        LblLanguage.Text = My.Resources.Resources.OptionLanguage & ":"
        CmdCancel.Text = My.Resources.Resources.cmdCancel
        CmdSave.Text = My.Resources.Resources.cmdSave
        CmdOK.Text = My.Resources.Resources.cmdOK
    End Sub
End Class