Imports System.Globalization
Imports inoHotKeys.My

Public Class ClsTranslation
    Public Structure LanguageSetting
        Dim LCID As Long
        Dim Language As String
        Dim LanguageNative As String
        Dim LanguageName As String
    End Structure

    Public LanguageSettings() As LanguageSetting

    Public CurrentLanguage As String

    Public Sub New()
        FillLanguages()
    End Sub

    Public Function GetTranslatedAction(strAction As String) As String
        Select Case strAction
            Case "New email"
                Return My.Resources.Resources.NewOutlookEmail
        End Select
        Return ""
    End Function

    Private Sub FillLanguages()

        Dim Lang() As String = {"en-GB", "de-DE"}
        ReDim LanguageSettings(Lang.Length - 1)

        For iCount As Integer = 0 To Lang.Length - 1
            Dim myCIintl As New CultureInfo(Lang(iCount), False)
            LanguageSettings(iCount).LCID = myCIintl.LCID
            LanguageSettings(iCount).Language = myCIintl.EnglishName
            LanguageSettings(iCount).LanguageNative = myCIintl.NativeName
            LanguageSettings(iCount).LanguageName = myCIintl.Name
        Next

        CurrentLanguage = My.Settings.Language
        If CurrentLanguage = "" Then
            CurrentLanguage = System.Globalization.CultureInfo.CurrentCulture.Name
            Dim blnLanguage As Boolean = False
            For Each l As LanguageSetting In LanguageSettings
                If l.LanguageName = CurrentLanguage Then
                    blnLanguage = True
                    Exit For
                End If
            Next
            If blnLanguage = False Then
                CurrentLanguage = "en-GB"
                My.Settings.Language = CurrentLanguage
                My.Settings.Save()
            End If
        End If
    End Sub


End Class
