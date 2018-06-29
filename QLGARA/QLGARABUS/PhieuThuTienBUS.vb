Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class PhieuThuTienBUS
    Dim phieuthutienDAL As New PhieuThuTienDAL()
    Dim khachangDAL As New KhachhangDAL()
    Dim thongtinxeDAL As New ThongTinXeDAL()

    Public Function isValidThongTin(tenchuxe As String, dienthoai As String, biensoxe As String, sotienthu As String)
        If (tenchuxe.Trim = "" Or dienthoai.Trim = "" Or biensoxe.Trim = "" Or sotienthu.Trim = "") Then
            Return False
        End If
        Return True
    End Function


    Public Function isvalidtenchuxe(tenchuxe As String) As Boolean
        Dim listofkhachhang As New List(Of KhachHangDTO)
        listofkhachhang = khachangDAL.SelectAll()
        For i As Integer = 0 To listofkhachhang.Count
            If (listofkhachhang.ElementAt(i).TenKH = tenchuxe) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function isvalidbienso(biensoxe As String) As Boolean
        Dim listofthongtinxe As New List(Of ThongTinXeDTO)
        listofthongtinxe = thongtinxeDAL.SelectAll()
        For i As Integer = 0 To listofthongtinxe.Count
            If (listofthongtinxe.ElementAt(i).BienSo = biensoxe) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function isvalidTienThu(phieuthutien As PhieuThuTienDTO, biensoxe As String)
        If (phieuthutien.SoTienThu > phieuthutienDAL.TimNoKhachhang(biensoxe)) Then
            Return False
        End If
        Return True
    End Function

    Public Function Insert(phieuthutien As PhieuThuTienDTO) As Result
        Return phieuthutienDAL.Insert(phieuthutien)
    End Function

    Public Function Update(phieuthutien As PhieuThuTienDTO) As Result
        Return phieuthutienDAL.Update(phieuthutien)
    End Function

    Public Function Delete(maphieu As String) As Result
        Return phieuthutienDAL.Delete(maphieu)
    End Function

    Public Function BuildMaPhieutt(ByRef nextMaphieuTT As String) As Result
        Return phieuthutienDAL.BuildMaPhieuTT(nextMaphieuTT)
    End Function
End Class
