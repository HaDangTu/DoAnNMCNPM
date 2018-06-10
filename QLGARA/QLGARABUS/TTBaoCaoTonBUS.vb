Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class TTBaoCaoTonBUS
    Private ttbaocaotonDAL As New TTBaoCaoTonDAL()
    Public Function BuildMaTTBaoCaoTon(ByRef nextMaTTBaoCaoTon As String) As Result
        Return ttbaocaotonDAL.BuildMaTTBaoCaoTon(nextMaTTBaoCaoTon)
    End Function

    Public Function Insert(ttbaocaoton As TTBaoCaoTonDTO) As Result
        Return ttbaocaotonDAL.Insert(ttbaocaoton)
    End Function
End Class
