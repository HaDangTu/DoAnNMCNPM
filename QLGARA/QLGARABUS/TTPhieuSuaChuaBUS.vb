﻿Imports QLGARADAL
Imports QLGARADTO
Imports Utility
Public Class TTPhieuSuaChuaBUS
    Private tt_phieusuachuaDAL As New TTPhieuSuaChuaDAL()

    Public Function Insert(tt_phieusuachuaDTO As TTPhieuSuaChuaDTO) As Result
        Return tt_phieusuachuaDAL.Insert(tt_phieusuachuaDTO)
    End Function

    Public Function BuildMaTTPhieuSC(ByRef nextMaTTPhieuSC As String) As Result
        Return tt_phieusuachuaDAL.BuildMaTTPhieuSC(nextMaTTPhieuSC)
    End Function
End Class
