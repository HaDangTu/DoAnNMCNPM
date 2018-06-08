Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class DanhSachXeBUS
    Private danhsachxeDAL As New DanhSachXeDAL()

    Public Function Select_DanhSachXe(MaTTXe As String, BienSo As String, MaHX As String, TenKH As String,
                                      MaKH As String,
                                      ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
        Return danhsachxeDAL.Select_DanhSachXe(MaTTXe, BienSo, MaHX, TenKH, MaKH,
                                               ListofDanhSachXe)
    End Function

    'Public Function Select_By_BienSo(bienso As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Return danhsachxeDAL.Select_By_BienSo(bienso, ListofDanhSachXe)
    'End Function

    'Public Function Select_By_HieuXe(MaHX As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Return danhsachxeDAL.Select_By_HieuXe(MaHX, ListofDanhSachXe)
    'End Function

    'Public Function Select_By_MaKH(MaKH As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Return danhsachxeDAL.Select_By_MaKH(MaKH, ListofDanhSachXe)
    'End Function

    'Public Function Select_By_MaTTXe(MaTTXe As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Return danhsachxeDAL.Select_By_MaTTXe(MaTTXe, ListofDanhSachXe)
    'End Function

    'Public Function Select_By_TenKH(TenKH As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Return danhsachxeDAL.Select_By_TenKH(TenKH, ListofDanhSachXe)
    'End Function

    Public Function Select_By_TienNo(TienNoMin As Double, ByRef TienNoMax As Double,
             ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
        Return danhsachxeDAL.Select_By_TienNo(TienNoMin, TienNoMax, ListofDanhSachXe)
    End Function
End Class
