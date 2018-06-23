Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class NhapPhuTungBUS
    Dim nhapphutungDAL As New NhapPhuTungDAL()

    Public Function BuildMaNPT(ByRef nextMaNhapPT As String) As Result
        Return nhapphutungDAL.BuildMaNhapPhuTung(nextMaNhapPT)
    End Function
    Public Function Insert(nhapphutung As NhapPhuTungDTO) As Result
        Return nhapphutungDAL.Insert(nhapphutung)
    End Function

End Class
