Imports System.Collections
Imports System.Collections.Specialized
Imports System.Globalization
Imports System.Net
Imports System.Threading

Public Class FrmShortcutSettings

    Dim userSettings As New StringCollection()
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Shortcuts Is Nothing Or My.Settings.Shortcuts.Count = 0 Then
            Dim myArr() As String = {"6,M,New email"}
            userSettings.AddRange(myArr)
        Else
            userSettings = My.Settings.Shortcuts
        End If

        For Each items As String In userSettings
            Dim item() As String = items.Split(",")

            Dim index = DgvSettings.Rows.Add()
            Dim newRow = DgvSettings.Rows(index)

            Dim intWert As Int16 = CInt(item(0))
            If intWert >= 8 Then
                newRow.Cells(3).Value = True
                intWert -= 8
            End If
            If intWert >= 4 Then
                newRow.Cells(2).Value = True
                intWert -= 4
            End If
            If intWert >= 2 Then
                newRow.Cells(1).Value = True
                intWert -= 2
            End If
            If intWert >= 1 Then
                newRow.Cells(0).Value = True
            End If

            newRow.Cells(4).Value = item(1).Trim
            newRow.Cells(5).Value = item(2).Trim
            newRow.Cells(6).Value = ClsLang.GetTranslatedAction(item(2).Trim)
        Next

        AddTranslation()
    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        Dim uSettings As New StringCollection
        For Each r As DataGridViewRow In DgvSettings.Rows
            Dim intModifier As Int16 = -r.Cells(0).Value - r.Cells(1).Value * 2 - r.Cells(2).Value * 4 - r.Cells(3).Value * 8
            If intModifier = 0 Then
                MessageBox.Show(String.Format(My.Resources.Resources.ShortSetMessage1, r.Cells(5).Value.Trim) & Environment.NewLine & My.Resources.Resources.ShortSetMessage2)
                Exit Sub
            Else
                uSettings.Add(Math.Abs(intModifier) & "," & r.Cells(4).Value.Trim & "," & r.Cells(5).Value.Trim)
            End If

        Next
        My.Settings.Shortcuts = uSettings
        My.Settings.Save()
        RemoveGlobalHotkeySupport()
        AddGlobalHotkeySupport()
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        Me.CmdSave.PerformClick()
        Me.Close()
    End Sub

    Private Sub FrmSettings_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.Width < minWidth Then Me.Width = minWidth
        If Me.Height < minHeight Then Me.Height = minHeight

        Me.DgvSettings.Width = Me.Width - 50
        Me.DgvSettings.Height = Me.Height - 20 - CmdOK.Width

        Me.CmdOK.Left = Me.Width - 50 - CmdOK.Width
        Me.CmdOK.Top = Me.Height - 50 - CmdOK.Height

        Me.CmdSave.Left = (Me.Width - 50 - CmdOK.Width) / 2
        Me.CmdSave.Top = Me.Height - 50 - CmdOK.Height

        Me.CmdCancel.Top = Me.Height - 50 - CmdOK.Height
    End Sub

    Private Sub AddTranslation()
        CmdCancel.Text = My.Resources.Resources.cmdCancel
        CmdSave.Text = My.Resources.Resources.cmdSave
        CmdOK.Text = My.Resources.Resources.cmdOK

        With DgvSettings
            .Columns(0).HeaderCell.Value = My.Resources.Resources.ShortSetAlt
            .Columns(1).HeaderCell.Value = My.Resources.Resources.ShortSetCrtl
            .Columns(2).HeaderCell.Value = My.Resources.Resources.ShortSetShift
            .Columns(3).HeaderCell.Value = My.Resources.Resources.ShortSetWin
            .Columns(4).HeaderCell.Value = My.Resources.Resources.ShortSetKey
            .Columns(5).HeaderCell.Value = My.Resources.Resources.ShortSetAction
            .Columns(6).HeaderCell.Value = My.Resources.Resources.ShortSetAction
        End With

        Me.Text = My.Resources.Resources.ShortSetCaption
    End Sub
End Class
