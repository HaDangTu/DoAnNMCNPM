Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class PhieuTiepNhanBUS
    Private phieutiepnhanDAL As New PhieuTiepNhanDAL()

    Public Function isvalidNumber()
        If (phieutiepnhanDAL.Count() > 30) Then
            Return False
        End If
        Return True
    End Function

    Public Function Insert(phieutiepnhan As PhieuTiepNhanDTO) As Result
        Return phieutiepnhanDAL.Insert(phieutiepnhan)
    End Function

    Public Function Update(phieutiepnhan As PhieuTiepNhanDTO) As Result
        Return phieutiepnhanDAL.Update(phieutiepnhan)
    End Function

    Public Function Delete(maphieu As String) As Result
        Return phieutiepnhanDAL.Delete(maphieu)
    End Function

    Public Function BuildMaPhieuTN(ByRef nextMaphieuTN As String) As Result
        Return phieutiepnhanDAL.BuildMaPhieu(nextMaphieuTN)
    End Function
End Class
