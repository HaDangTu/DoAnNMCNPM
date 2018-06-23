Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class TTNhapPhuTungBUS
    Private ttnhapphutungDAL As New TTNhapPhuTungDAL()

    Public Function BuildMaTTNhapPT(ByRef nextMaNhapPhuTung As String) As Result
        Return ttnhapphutungDAL.BuildMaTTNhapPT(nextMaNhapPhuTung)
    End Function

    Public Function Insert(ttnhapphutung As TTNhapPhuTungDTO) As Result
        Return ttnhapphutungDAL.Insert(ttnhapphutung)
    End Function

    Public Function Select_SoLuongNhap(Thang As Integer, ByRef ListofSoLuongNhap As List(Of Integer)) As Result
        Return ttnhapphutungDAL.Select_SoLuongNhap(Thang, ListofSoLuongNhap)
    End Function
End Class
