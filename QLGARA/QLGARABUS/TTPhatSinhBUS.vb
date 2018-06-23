Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class TTPhatSinhBUS
    Dim ttphatsinhDAL As New TTPhatSinhDAL()

    Public Function BuildMaTTPhatSinh(ByRef nextMaTTPhatSinh As String)
        Return ttphatsinhDAL.BuildMaTTNhapPS(nextMaTTPhatSinh)
    End Function

    Public Function Insert(ttphatsinh As TTPhatSinhDTO)
        Return ttphatsinhDAL.Insert(ttphatsinh)
    End Function

    Public Function Update(ttphatsinh As TTPhatSinhDTO)
        Return ttphatsinhDAL.Update(ttphatsinh)
    End Function

    Public Function Delete(MaTTPhatSinh As String)
        Return ttphatsinhDAL.Delete(MaTTPhatSinh)
    End Function
End Class
