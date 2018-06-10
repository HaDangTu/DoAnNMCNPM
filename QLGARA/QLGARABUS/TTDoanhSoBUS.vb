Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class TTDoanhSoBUS
    Private ttdoanhsoDAL As New TTDoanhSoDAL()

    Public Function BuildMaTTDoanhSo(nextMaTTDoanhSO As String) As Result
        Return ttdoanhsoDAL.BuildMaTTDoanhSo(nextMaTTDoanhSO)
    End Function

    Public Function Insert(ttdoanhso As TTDoanhSoDTO) As Result
        Return ttdoanhsoDAL.Insert(ttdoanhso)
    End Function

    Public Function Sellect_TTDoanhSo_byThang(thang As Integer) As List(Of TTDoanhSoDTO)
        Return ttdoanhsoDAL.Sellect_TTDoanhSo_byThang(thang)
    End Function
End Class
