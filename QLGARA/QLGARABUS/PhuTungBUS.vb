Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class PhuTungBUS
    Private phutungDAL As New PhuTungDAL()

    Public Function isvalidPhuTung(phutung As String) As Boolean
        Dim ListofPhuTung As New List(Of PhuTungDTO)()
        ListofPhuTung = phutungDAL.SelectAll()
        For Each phutungDTO As PhuTungDTO In ListofPhuTung
            If (phutung = phutungDTO.MaPhuTung) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function Insert(phutung As PhuTungDTO) As Result
        Return phutungDAL.Insert(phutung)
    End Function

    Public Function Update(phutung As PhuTungDTO) As Result
        Return phutungDAL.Update(phutung)
    End Function

    Public Function Delete(maphutung As String) As Result
        Return phutungDAL.Delete(maphutung)
    End Function

    Public Function BulidMaPhuTung(nextMaPT As String)
        Return phutungDAL.BulidMaPhuTung(nextMaPT)
    End Function

    Public Function Sellect_All() As List(Of PhuTungDTO)
        Return phutungDAL.SelectAll()
    End Function
    Public Function Select_DonGia(maPhuTung) As Double
        Return phutungDAL.Select_DonGia(maPhuTung)
    End Function

End Class
