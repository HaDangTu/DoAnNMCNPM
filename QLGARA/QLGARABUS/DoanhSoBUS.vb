Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class DoanhSoBUS
    Private doanhsoDAL As New DoanhSoDAL

    Public Function isvalidMonth(thang As Integer, year As Integer) As Boolean
        If (thang > Now.Month Or year > Now.Year) Then
            Return False
        End If
        Return True
    End Function

    Public Function Insert(doanhsoDTO As DoanhSoDTO) As Result
        Return doanhsoDAL.Insert(doanhsoDTO)
    End Function

    Public Function SoLuotSC_1_HieuXe(thang As Integer, nam As Integer) As List(Of LuotSuaChuaDTO)
        Return doanhsoDAL.SoLuotSC_1_HieuXe(thang, nam)
    End Function

    Public Function ThanhTien(thang As Integer, nam As Integer) As List(Of ThanhTienDTO)
        Return doanhsoDAL.ThanhTien(thang, nam)
    End Function

    Public Function TongDoanhThu(thang As Integer, nam As Integer) As Integer
        Return doanhsoDAL.TongDoanhThu(thang, nam)

    End Function

    Public Function TongSoLuotSua(thang As Integer, nam As Integer) As Integer
        Return doanhsoDAL.TongSoLuotSua(thang, nam)
    End Function

    Public Function BuildMaDoanhSo(ByRef nextMaDoanhSo As String) As Result
        Return doanhsoDAL.BuildMaDoanhSo(nextMaDoanhSo)
    End Function
End Class
