Imports System.Runtime.InteropServices
Imports System.Runtime.Versioning
Imports System.Security

' taken from https://stackoverflow.com/questions/61140188/how-to-connect-an-open-excel-application-in-net-core-3-1/70398580#70398580
Module ExMarshal
    Friend Const OLEAUT32 As String = "oleaut32.dll"
    Friend Const OLE32 As String = "ole32.dll"

    <System.Security.SecurityCritical>
    Function GetActiveObject(ByVal progID As String) As Object
        Dim obj As Object = Nothing
        Dim clsid As Guid

        Try
            CLSIDFromProgIDEx(progID, clsid)
        Catch __unusedException1__ As Exception
            CLSIDFromProgID(progID, clsid)
        End Try

        GetActiveObject(clsid, IntPtr.Zero, obj)
        Return obj
    End Function

    <DllImport(OLE32, PreserveSig:=False)> <ResourceExposure(ResourceScope.None)> <SuppressUnmanagedCodeSecurity> <System.Security.SecurityCritical> Private Sub CLSIDFromProgIDEx(<MarshalAs(UnmanagedType.LPWStr)> ByVal progId As String, <Out> ByRef clsid As Guid)
    End Sub

    <DllImport(OLE32, PreserveSig:=False)> <ResourceExposure(ResourceScope.None)> <SuppressUnmanagedCodeSecurity> <System.Security.SecurityCritical> Private Sub CLSIDFromProgID(<MarshalAs(UnmanagedType.LPWStr)> ByVal progId As String, <Out> ByRef clsid As Guid)
    End Sub

    <DllImport(OLEAUT32, PreserveSig:=False)> <ResourceExposure(ResourceScope.None)> <SuppressUnmanagedCodeSecurity> <System.Security.SecurityCritical> Private Sub GetActiveObject(ByRef rclsid As Guid, ByVal reserved As IntPtr, <Out> <MarshalAs(UnmanagedType.[Interface])> ByRef ppunk As Object)
    End Sub
End Module
