Imports QLGARADAL
Imports QLGARADTO
Imports Utility

Public Class LoaiTienCongBUS
    Private loaitiencongDAL As New LoaiTienCongDAL()

    Public Function isvalid_LoaiTienCong(matiencong As String) As Boolean
        Dim ListofLoaiTienCong As New List(Of LoaiTienCongDTO)()
        For Each loaitiencongDTO As LoaiTienCongDTO In ListofLoaiTienCong
            If (loaitiencongDTO.MaTC = matiencong) Then
                Return True
            End If
        Next
        Return False
    End Function


    Public Function Insert(tiencong As LoaiTienCongDTO) As Result
        Return loaitiencongDAL.Insert(tiencong)
    End Function

    Public Function Update(tiencong As LoaiTienCongDTO) As Result
        Return loaitiencongDAL.Update(tiencong)
    End Function

    Public Function Delete(matiencong As String) As Result
        Return loaitiencongDAL.Delete(matiencong)
    End Function

    Public Function BuildMaLoaiTC(nextMaTC As String)
        Return loaitiencongDAL.BuildMaLoaiTC(nextMaTC)
    End Function

    Public Function SelectALL() As List(Of LoaiTienCongDTO)
        Return loaitiencongDAL.SelectAll()
    End Function

    Public Function Select_MucTien(matiencong As String) As Double
        Return loaitiencongDAL.Select_MucTien(matiencong)
    End Function
End Class
