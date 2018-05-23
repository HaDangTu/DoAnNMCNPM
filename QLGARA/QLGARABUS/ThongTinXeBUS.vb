Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class ThongTinXeBUS
    Private thongtinxeDAL As New ThongTinXeDAL()


    Public Function Insert(ByRef thongtinxeDTO As ThongTinXeDTO) As Result
        Return thongtinxeDAL.Insert(thongtinxeDTO)
    End Function



    Public Function BuildMaTTXe(ByRef nextMaTTXe As String) As Result
        Return thongtinxeDAL.BuidMaTTXe(nextMaTTXe)
    End Function
End Class
