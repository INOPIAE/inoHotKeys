Imports IWshRuntimeLibrary


Module MdlTools

    Public ShortCutPath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) & ".lnk"
    Public Sub CreateShortcutInStartUp(ByVal Description As String)
        Dim WshShell As WshShell = New WshShell()
        'Dim ShortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        'Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(System.IO.Path.Combine(ShortCutPath, Application.ProductName) & ".lnk"), IWshShortcut)
        Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(ShortCutPath), IWshShortcut)
        Shortcut.TargetPath = Application.ExecutablePath
        Shortcut.WorkingDirectory = Application.StartupPath
        Shortcut.Description = Description
        Shortcut.Save()
    End Sub

End Module
