Imports System.Reflection
Imports System.Runtime

Module MdlShortcuts
    Public hook As New ClsHooks

    Public minWidth As Int16 = 570
    Public minHeight As Int16 = 270

    Public Sub AddGlobalHotkeySupport()

        ' register the event that is fired after the key press.
        AddHandler hook.KeyPressed, AddressOf hook_KeyPressed
        For Each items As String In My.Settings.Shortcuts
            Dim item() As String = items.Split(",")

            hook.RegisterHotKey(Math.Abs(CInt(item(0))), KeyFromString(item(1)))
        Next
        ' register the control + alt + F12 combination as hot key.
        'hook.RegisterHotKey(inoHotKeys.ModifierKeys.Control Or inoHotKeys.ModifierKeys.Alt, Keys.F12)
    End Sub
    Public Sub RemoveGlobalHotkeySupport()
        ' unregister all registered hot keys.
        hook.Dispose()
    End Sub

    Private Sub hook_KeyPressed(sender As Object, e As KeyPressedEventArgs)
        ' show the keys pressed in a label.
        ' Debug.Print(e.Modifier.ToString() + " + " + e.Key.ToString())
        For Each items As String In My.Settings.Shortcuts
            Dim item() As String = items.Split(",")

            If e.Modifier = item(0) And e.Key = KeyFromString(item(1)) Then
                CreateEmail()
                Exit Sub
            End If
        Next
    End Sub

    Public Function KeyFromString(theKey As String) As Keys
        Dim kc As New KeysConverter()
        Return CType(kc.ConvertFrom(theKey), Keys)
    End Function

End Module
