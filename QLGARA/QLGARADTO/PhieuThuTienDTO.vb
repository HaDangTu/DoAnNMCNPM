Public Class PhieuThuTienDTO
    Dim strmaphieuthutien As String
    Dim strmaphieutiepnhan As String
    Dim dtngaythutien As DateTime
    Dim numsotienthu As Long

    Public Property MaPhieuThuTien As String
        Get
            Return strmaphieuthutien
        End Get
        Set(value As String)
            strmaphieuthutien = value
        End Set
    End Property

    Public Property MaPhieuTN As String
        Get
            Return strmaphieutiepnhan
        End Get
        Set(value As String)
            strmaphieutiepnhan = value
        End Set
    End Property

    Public Property NgayThuTien As Date
        Get
            Return dtngaythutien
        End Get
        Set(value As Date)
            dtngaythutien = value
        End Set
    End Property

    Public Property SoTienThu As Long
        Get
            Return numsotienthu
        End Get
        Set(value As Long)
            numsotienthu = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strmaphieutt As String, strmaphieutn As String, dtngaytt As DateTime, numsott As Long)
        strmaphieuthutien = strmaphieutt
        strmaphieutiepnhan = strmaphieutn
        dtngaythutien = dtngaytt
        numsotienthu = numsott
    End Sub
End Class
