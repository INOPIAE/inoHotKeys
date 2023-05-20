Imports System.Collections.Specialized

Module MdlShortcuts
    Public hook As New ClsHooks

    Public minWidth As Int16 = 570
    Public minHeight As Int16 = 270

    Public ClsLang As New ClsTranslation

    Public ShortcutCount As Long = 2

    Public Sub AddGlobalHotkeySupport()

        ' register the event that is fired after the key press.
        AddHandler hook.KeyPressed, AddressOf Hook_KeyPressed
        For Each items As String In My.Settings.Shortcuts
            Dim item() As String = items.Split(",")
            If item(3) = 1 Then
                hook.RegisterHotKey(Math.Abs(CInt(item(0))), KeyFromString(item(1)))
            End If
        Next
        ' register the control + alt + F12 combination as hot key.
        'hook.RegisterHotKey(inoHotKeys.ModifierKeys.Control Or inoHotKeys.ModifierKeys.Alt, Keys.F12)
    End Sub
    Public Sub RemoveGlobalHotkeySupport()
        ' unregister all registered hot keys.
        hook.Dispose()
    End Sub

    Private Sub Hook_KeyPressed(sender As Object, e As KeyPressedEventArgs)
        ' show the keys pressed in a label.
        'Debug.Print(e.Modifier.ToString() + " + " + e.Key.ToString())
        For Each items As String In My.Settings.Shortcuts
            Dim item() As String = items.Split(",")

            If e.Modifier = item(0) And e.Key = KeyFromString(item(1)) And item(3) = 1 And item(2) = "New email" Then
                If IsOutlookInstalled() Then CreateEmail()
                Exit Sub
            End If
            If e.Modifier = item(0) And e.Key = KeyFromString(item(1)) And item(3) = 1 And item(2) = "Sleep" Then
                SendToSleep()
                Exit Sub
            End If
        Next
    End Sub

    Public Function KeyFromString(theKey As String) As Keys
        Dim kc As New KeysConverter()
        Return CType(kc.ConvertFrom(theKey), Keys)
    End Function

    Public Sub InitializeShortcuts()
        Dim userSettings As New StringCollection()
        Dim blnUpdate As Boolean = False
        Try
            If My.Settings.Shortcuts.Count < 1 Then

            End If
        Catch ex As NullReferenceException
            userSettings.Add("6,M,New email,1")
            My.Settings.Shortcuts = userSettings
            My.Settings.Save()
            blnUpdate = True
        End Try
        If My.Settings.Shortcuts.Count < 2 Then
            If My.Settings.Shortcuts.Count = 1 And blnUpdate = False Then
                userSettings.Add("6,M,New email,1")
            End If
            userSettings.Add("9, S, Sleep, 1")
            blnUpdate = True
        End If
        If blnUpdate = True Then
            My.Settings.Shortcuts = userSettings
            My.Settings.Save()
        End If
    End Sub
End Module
