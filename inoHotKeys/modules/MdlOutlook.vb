
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Module MdlOutlook
    Public Sub CreateEmail()

        Dim olApp As Outlook.Application
        Dim olMail As Outlook.MailItem

        If Process.GetProcessesByName("OUTLOOK").Count() > 0 Then
            'here is the part where i get the error in the second part
            olApp = DirectCast(ExMarshal.GetActiveObject("Outlook.Application"), Outlook.Application)
        Else
            olApp = New Microsoft.Office.Interop.Outlook.Application
        End If
        olMail = olApp.CreateItem(Outlook.OlItemType.olMailItem)
        Dim olInspector As Outlook.Inspector = olMail.GetInspector
        olMail.Display()
        olInspector.Activate()
    End Sub

    Public Function IsOutlookInstalled() As Boolean
        Dim officeType As Type = Type.GetTypeFromProgID("Outlook.Application")

        If officeType Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
End Module
