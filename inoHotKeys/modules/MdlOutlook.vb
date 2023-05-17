
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Module MdlOutlook
    Public Sub CreateEmail()
        Dim outApp As Outlook.Application
        Dim outMail As Outlook.MailItem

        If Process.GetProcessesByName("OUTLOOK").Count() > 0 Then
            'here is the part where i get the error in the second part
            outApp = DirectCast(ExMarshal.GetActiveObject("Outlook.Application"), Outlook.Application)
        Else
            outApp = New Microsoft.Office.Interop.Outlook.Application
        End If
        outMail = outApp.CreateItem(Outlook.OlItemType.olMailItem)
        outMail.Display()
    End Sub
End Module
