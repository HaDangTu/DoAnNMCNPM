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

    Public Function isValidName(name As String) As Boolean
        Dim ArraySpecialCharacter() As Char = {"`", "`", "!", "@", "#", "&", "^", "&", "*", "(", ")",
            "_", "-", "+", "-", "*", "/", "{", "}", "[", "]", ":", ";", "<", ">", ",", ".", "?",
        "'"}
        'Tên chứa số
        For Each ch As Char In name
            If (Integer.TryParse(ch, 1) = True) Then
                Return False
            End If
        Next
        'Tên chứa các kí tự đặc biệt
        For Each ch As Char In name
            For Each spchar As Char In ArraySpecialCharacter
                If (ch = spchar) Then
                    Return False
                End If
            Next
        Next
        'Tên dưới 2 tiếng
        Dim dem = 0
        ' khử khoảng trắng ở phía cuối của chuỗi
        name = name.TrimEnd()

        For Each ch As String In name
            If (ch = " " Or ch = name.Last()) Then
                dem = dem + 1
            End If
        Next
        'Console.WriteLine(dem.ToString())

        If (dem <= 1) Then
            Return False
        End If

        Return True
    End Function

    Public Function isValidThongTin(hoten As String, dienthoai As String, diachi As String, tienno As String) As Boolean
        If (hoten.Trim = "" Or dienthoai.Trim = "" Or diachi.Trim = "" Or tienno.Trim = "") Then
            Return False
        End If
        Return True
    End Function

    Public Function isValidSoDienThoai(sodienthoai As String) As Boolean
        If (Decimal.TryParse(sodienthoai, 0) = False) Then
            Return False
        End If
        Return True
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

    Public Function SelectMaKH(tenKH As String, diachi As String, dienthoai As String) As KhachHangDTO
        Return khachhangDAL.SelectMaKH(tenKH, diachi, dienthoai)
    End Function
End Class
