Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class BaoCaoTonBUS
    Private baocaotonDAL As New BaoCaoTonDAL()

    Public Function isValidThang(Thang As Integer) As Boolean
        If (Thang < 1 Or Thang > 12 Or Thang > Now.Month) Then
            Return False    'Tháng không hợp lệ
        End If
        Return True
    End Function
    Public Function BuildMaBaoCaoTon(ByRef nextMaBaoCaoTon As String) As Result
        Return baocaotonDAL.BuildMaBaoCaoTon(nextMaBaoCaoTon)
    End Function

    Public Function Insert(baocaoton As BaoCaoTonDTO) As Result
        Return baocaotonDAL.Insert(baocaoton)
    End Function

    Public Function Tong_SL_DaSC(Thang As Integer, ByRef ListofTong_SL_DaSC As List(Of Integer)) As Result
        Return baocaotonDAL.Tong_SL_DaSC(Thang, ListofTong_SL_DaSC)
    End Function

    Public Function Tong_SLPS(Thang As Integer, ByRef ListofTong_SLPS As List(Of Integer)) As Result
        Return baocaotonDAL.Tong_SLPS(Thang, ListofTong_SLPS)
    End Function

    Public Function Select_TonCuoi_byThang(Thang As Integer,
                                           ByRef ListofTonCuoi As List(Of Integer)) As Result
        Return baocaotonDAL.Select_TonCuoi_ByThang(Thang, ListofTonCuoi)
    End Function


End Class
