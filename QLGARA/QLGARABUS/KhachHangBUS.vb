Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class KhachHangBUS
    Private khachhangDAL As New KhachhangDAL()

    Public Function isvalidKhachHang(khachhang As KhachHangDTO) As Boolean

        Dim listofkhachhang As New List(Of KhachHangDTO)()
        listofkhachhang = khachhangDAL.SelectAll()
        For i As Integer = 0 To listofkhachhang.Count - 1
            If (khachhang.TenKH = listofkhachhang.ElementAt(i).TenKH And
                    khachhang.DiaChi = listofkhachhang.ElementAt(i).DiaChi And
                    khachhang.DienThoai = listofkhachhang.ElementAt(i).DienThoai) Then
                Return True
            End If
        Next
        Return False
    End Function
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

    Public Function SelectALL() As List(Of KhachHangDTO)
        Return khachhangDAL.SelectAll()
    End Function

    Public Function SelectMaKH_ByBienSo(bienso As String) As KhachHangDTO
        Return khachhangDAL.SelectMaKH_byBienso(bienso)
    End Function
End Class
