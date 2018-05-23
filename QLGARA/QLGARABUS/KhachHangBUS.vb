Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class KhachHangBUS
    Private khachhangDAL As New KhachHangDAL()
    Public Function Insert(khachhangDTO As KhachHangDTO) As Result
        Return khachhangDAL.Insert(khachhangDTO)
    End Function

    Public Function Update(khachhangDTO As KhachHangDTO) As Result
        Return khachhangDAL.Update(khachhangDTO)
    End Function

    Public Function Delete(maphieu As String) As Result
        Return khachhangDAL.Delete(maphieu)
    End Function

    Public Function BuildMaKH(ByRef nextMakh As String) As Result
        Return khachhangDAL.BuildMaKH(nextMakh)
    End Function
End Class
