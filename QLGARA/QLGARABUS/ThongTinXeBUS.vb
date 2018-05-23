Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class ThongTinXeBUS
    Private thongtinxeDAL As New ThongTinXeDAL()

    Public Function isvalidthongtinxe(thongtinxeDTO As ThongTinXeDTO) As Integer
        Dim ListofThongtinxe As List(Of ThongTinXeDTO)
        ListofThongtinxe = thongtinxeDAL.SelectAll()
        For i As Integer = 0 To ListofThongtinxe.Count - 1
            If (thongtinxeDTO.BienSo = ListofThongtinxe.ElementAt(i).BienSo) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Function Insert(thongtinxeDTO As ThongTinXeDTO) As Result
        Return thongtinxeDAL.Insert(thongtinxeDTO)
    End Function

    Public Function Update(thongtinxeDTO As ThongTinXeDTO) As Result
        Return thongtinxeDAL.Update(thongtinxeDTO)
    End Function

    Public Function Update(mattxe As String) As Result
        Return thongtinxeDAL.Delete(mattxe)
    End Function

    Public Function BuildMaTTXe(ByRef nextMaTTXe As String) As Result
        Return thongtinxeDAL.BuidMaTTXe(nextMaTTXe)
    End Function

    Public Function SelectALL() As List(Of ThongTinXeDTO)
        Return thongtinxeDAL.SelectAll()
    End Function
End Class
