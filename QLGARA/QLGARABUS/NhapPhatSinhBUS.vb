Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class NhapPhatSinhBUS
    Dim nhapphatsinhDAL As New NhapPhatSinhDAL()

    Public Function BuildMaPhieuNhapPS(ByRef nextMaPhieuNhapPS As String) As Result
        Return nhapphatsinhDAL.BuildMaPhieuNhapPS(nextMaPhieuNhapPS)
    End Function

    Public Function Insert(nhapphatsinh As NhapPhatSinhDTO) As Result
        Return nhapphatsinhDAL.Insert(nhapphatsinh)
    End Function

    Public Function Update(nhapphatsinh As NhapPhatSinhDTO) As Result
        Return nhapphatsinhDAL.Update(nhapphatsinh)
    End Function

    Public Function Delete(MaPhieuNhapPS As String) As Result
        Return nhapphatsinhDAL.Delete(MaPhieuNhapPS)
    End Function
End Class
