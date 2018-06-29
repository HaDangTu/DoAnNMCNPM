Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class HoSoSuaChuaBUS
    Private hososuachuaDAL As New HoSoSuaChuaDAL()

    Public Function SelectALL(ngaynhan As DateTime, ByRef ListofHoSoSuaChua As List(Of HoSoSuaChuaDTO)) As Result
        Return hososuachuaDAL.Sellect_All(ngaynhan, ListofHoSoSuaChua)
    End Function

End Class
