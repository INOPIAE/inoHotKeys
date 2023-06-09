﻿Imports System.Collections
Imports System.Collections.Specialized
Imports System.Globalization
Imports System.Net
Imports System.Threading

Public Class FrmShortcutSettings

    Dim userSettings As New StringCollection()
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        Close()
    End Sub

    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Shortcuts Is Nothing Or My.Settings.Shortcuts.Count < ShortcutCount Then
            InitializeShortcuts()
        End If
        userSettings = My.Settings.Shortcuts


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
            newRow.Cells(6).ReadOnly = True
            newRow.Cells(7).Value = IIf(item(3) = 1, True, False)
            If IsOutlookInstalled() = False And item(2).Trim = "New email" Then
                newRow.ReadOnly = True
            End If
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
                Dim intActivated As Int16 = IIf(r.Cells(7).Value = True, 1, 0)
                If r.Cells(5).Value = "New Email" And IsOutlookInstalled() = False And intActivated = 1 Then
                    intActivated = 0
                End If

                uSettings.Add(Math.Abs(intModifier) & "," & r.Cells(4).Value.Trim & "," & r.Cells(5).Value.Trim & "," & IIf(r.Cells(7).Value = True, 1, 0))
            End If

        Next
        My.Settings.Shortcuts = uSettings
        My.Settings.Save()
        RemoveGlobalHotkeySupport()
        AddGlobalHotkeySupport()
    End Sub

    Private Sub CmdOK_Click(sender As Object, e As EventArgs) Handles CmdOK.Click
        CmdSave.PerformClick()
        Close()
    End Sub

    Private Sub FrmSettings_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Width < minWidth Then Width = minWidth
        If Height < minHeight Then Height = minHeight

        DgvSettings.Width = Width - 50
        DgvSettings.Height = Height - 20 - CmdOK.Width

        CmdOK.Left = Width - 50 - CmdOK.Width
        CmdOK.Top = Height - 50 - CmdOK.Height

        CmdSave.Left = (Width - 50 - CmdOK.Width) / 2
        CmdSave.Top = Height - 50 - CmdOK.Height

        CmdCancel.Top = Height - 50 - CmdOK.Height

        With DgvSettings
            .Columns(6).Width = .Width - .Columns(0).Width - .Columns(1).Width - .Columns(2).Width - .Columns(3).Width - .Columns(4).Width - .Columns(7).Width - 65
        End With
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
            .Columns(7).HeaderCell.Value = My.Resources.Resources.ShortSetActivated
        End With

        Text = My.Resources.Resources.ShortSetCaption
    End Sub

    Private Sub DgvSettings_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSettings.CellMouseEnter
        If e.RowIndex = 0 Then
            DgvSettings.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = My.Resources.Resources.ShortSetMsgOutlookMissing
        End If
    End Sub
End Class
