Imports System.Globalization
Imports System.Threading

Public Class FrmOptions
    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        CmdSave.PerformClick()
        Close()
    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Close()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If ClsLang.CurrentLanguage <> ClsLang.LanguageSettings(cboLanguage.SelectedIndex).LanguageName Then
            ClsLang.CurrentLanguage = ClsLang.LanguageSettings(cboLanguage.SelectedIndex).LanguageName
            MessageBox.Show(My.Resources.Resources.OptionMessageLanguageChange)
        End If
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(ClsLang.CurrentLanguage)

        My.Settings.Autostart = CkbAutostart.Checked

        If CkbAutostart.Checked Then
            CreateShortcutInStartUp("")
        Else
            IO.File.Delete(ShortCutPath)
        End If

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

        CkbAutostart.Checked = My.Settings.Autostart

        AddTranslation()
    End Sub

    Private Sub AddTranslation()
        Text = My.Resources.Resources.OptionTitel
        LblLanguage.Text = My.Resources.Resources.OptionLanguage & ":"
        CmdCancel.Text = My.Resources.Resources.cmdCancel
        CmdSave.Text = My.Resources.Resources.cmdSave
        CmdOK.Text = My.Resources.Resources.cmdOK
        CkbAutostart.Text = My.Resources.Resources.OptionAutostart
    End Sub
End Class