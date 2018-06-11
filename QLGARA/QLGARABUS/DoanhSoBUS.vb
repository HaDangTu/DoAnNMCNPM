Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class DoanhSoBUS
    Private doanhsoDAL As New DoanhSoDAL

    Public Function isvalidMonth(thang As Integer) As Boolean
        If (thang < 0 Or thang > 12 Or thang > Now.Month) Then
            Return False
        End If
        Return True
    End Function

    Public Function Insert(doanhsoDTO As DoanhSoDTO) As Result
        Return doanhsoDAL.Insert(doanhsoDTO)
    End Function

    Public Function SoLuotSC_1_HieuXe(thang As Integer) As List(Of LuotSuaChuaDTO)
        Return doanhsoDAL.SoLuotSC_1_HieuXe(thang)
    End Function

    Public Function ThanhTien(thang As Integer) As List(Of ThanhTienDTO)
        Return doanhsoDAL.ThanhTien(thang)
    End Function

    Public Function TongDoanhThu(thang As Integer) As Integer
        Return doanhsoDAL.TongDoanhThu(thang)

    End Function

    Public Function TongSoLuotSua(thang As Integer) As Integer
        Return doanhsoDAL.TongSoLuotSua(thang)
    End Function

    Public Function BuildMaDoanhSo(ByRef nextMaDoanhSo As String) As Result
        Return doanhsoDAL.BuildMaDoanhSo(nextMaDoanhSo)
    End Function
End Class
