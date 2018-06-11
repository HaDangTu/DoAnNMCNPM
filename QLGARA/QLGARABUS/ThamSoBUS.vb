Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class ThamSoBUS
    Private thamsoDAL As New ThamSoDAL()

    Public Function isvalidChange(num As Integer) As Boolean
        If (num < 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function Update(thamso As ThamSoDTO) As Result
        Return thamsoDAL.Update(thamso)
    End Function

    Public Function SelectALL(ByRef thamso As ThamSoDTO) As Result
        Return thamsoDAL.SelectALL(thamso)
    End Function

End Class
