Imports System.ComponentModel
Imports System.Globalization
Imports System.Net.Mime.MediaTypeNames
Imports System.Threading
Imports System.Windows.Forms

Public Class FrmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Fenster " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Hier Code zum Öffnen der Datei hinzufügen
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Hier Code einfügen, um den aktuellen Inhalt des Formulars in einer Datei zu speichern
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Mithilfe von My.Computer.Clipboard.GetText() oder My.Computer.Clipboard.GetData Informationen aus der Zwischenablage abrufen
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Alle untergeordneten Formulare des übergeordneten Formulars schließen
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        With FrmInfo
            .Show()
        End With
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentUICulture = New CultureInfo(ClsLang.CurrentLanguage)

        AddTranslation()

        AddGlobalHotkeySupport()

        Me.ShortcutSettingsToolStripMenuItem.PerformClick()

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub FrmMain_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        RemoveGlobalHotkeySupport()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        With FrmOptions
            .Show()
        End With
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon.Visible = True
            Me.Hide()
            Me.ShowInTaskbar = False
        Else
            If Me.Width < minWidth Then Me.Width = minWidth
            If Me.Height < minHeight Then Me.Height = minHeight
        End If
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False
        Me.ShowInTaskbar = True
        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = "FrmShortcutSettings" Then
                ChildForm.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub ShortcutSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShortcutSettingsToolStripMenuItem.Click
        With FrmShortcutSettings
            .MdiParent = Me
            .Show()
            .WindowState = FormWindowState.Maximized
        End With
    End Sub

    Private Sub AddTranslation()
        Me.FileMenu.Text = My.Resources.Resources.MainFile
        Me.ExitToolStripMenuItem.Text = My.Resources.Resources.MainExit

        Me.ToolsMenu.Text = My.Resources.Resources.MainTools
        Me.OptionsToolStripMenuItem.Text = My.Resources.Resources.MainOptions
        Me.ShortcutSettingsToolStripMenuItem.Text = My.Resources.Resources.MainShortcutSettings

        Me.WindowsMenu.Text = My.Resources.Resources.MainWindows
        Me.NewWindowToolStripMenuItem.Text = My.Resources.Resources.MainNewWindows
        Me.CascadeToolStripMenuItem.Text = My.Resources.Resources.MainCascading
        Me.TileVerticalToolStripMenuItem.Text = My.Resources.Resources.MainTileVertical
        Me.TileHorizontalToolStripMenuItem.Text = My.Resources.Resources.MainTileHorizontal
        Me.CloseAllToolStripMenuItem.Text = My.Resources.Resources.MainCloseAll
        Me.ArrangeIconsToolStripMenuItem.Text = My.Resources.Resources.MainArrageIcons

        Me.HelpMenu.Text = My.Resources.Resources.MainHelp
        Me.AboutToolStripMenuItem.Text = My.Resources.Resources.MainAbout
    End Sub
End Class
