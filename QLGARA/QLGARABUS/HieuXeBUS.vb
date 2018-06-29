Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class HieuXeBUS
    Private hieuxeDAL As New HieuXeDAL()

    Public Function isValidTenHieuXe(tenHX As String) As Boolean
        If (tenHX.Trim = "") Then
            Return False
        End If
        Return True
    End Function

    Public Function Insert(hieuxeDTO As HieuXeDTO) As Result
        Return hieuxeDAL.Insert(hieuxeDTO)
    End Function

    Public Function Update(hieuxeDTO As HieuXeDTO) As Result
        Return hieuxeDAL.Update(hieuxeDTO)
    End Function

    Public Function Delete(maphieu As String) As Result
        Return hieuxeDAL.Delete(maphieu)
    End Function

    Public Function SelectAll(ByRef ListofHieuXe As List(Of HieuXeDTO)) As Result
        Return hieuxeDAL.Select_ALL(ListofHieuXe)
    End Function
    Public Function BuildMaHX(ByRef nextMaHX As String) As Result
        Return hieuxeDAL.BuildMaHX(nextMaHX)
    End Function
End Class
