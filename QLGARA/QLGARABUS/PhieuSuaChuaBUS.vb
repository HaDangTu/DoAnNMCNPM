Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class PhieuSuaChuaBUS
    Private phieusuachuaDAL As New PhieuSuaChuaDAL()

    Public Function isvalidPhieuTN(maphieutiepnhan As String) As Boolean
        Dim ListofPhieuSC As New List(Of PhieuSuaChuaDTO)()
        For Each phieusuachua As PhieuSuaChuaDTO In ListofPhieuSC
            If (maphieutiepnhan = phieusuachua.MaPhieuTN) Then
                Return True     'phiếu tiếp nhận đã lập phiếu sửa chữa
            End If
        Next
        Return False
    End Function

    Public Function Insert(phieusuachua As PhieuSuaChuaDTO) As Result
        Return phieusuachuaDAL.Insert(phieusuachua)
    End Function

    Public Function Update(phieusuachua As PhieuSuaChuaDTO) As Result
        Return phieusuachuaDAL.Update(phieusuachua)
    End Function

    Public Function Delete(maphieuSC As String) As Result
        Return phieusuachuaDAL.Delete(maphieuSC)
    End Function

    Public Function BuildMaPhieuSC(nextMaPhieuSC As String)
        Return phieusuachuaDAL.BuildMaPhieuSC(nextMaPhieuSC)
    End Function


End Class
