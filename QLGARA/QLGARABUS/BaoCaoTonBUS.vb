Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class BaoCaoTonBUS
    Private baocaotonDAL As New BaoCaoTonDAL()

    Public Function BuildMaBaoCaoTon(ByRef nextMaBaoCaoTon As String) As Result
        Return baocaotonDAL.BuildMaBaoCaoTon(nextMaBaoCaoTon)
    End Function

    Public Function Insert(baocaoton As BaoCaoTonDTO) As Result
        Return baocaotonDAL.Insert(baocaoton)
    End Function
End Class
