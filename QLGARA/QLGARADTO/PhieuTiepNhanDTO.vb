Public Class PhieuTiepNhanDTO
    Dim strmaphieu As String
    Dim strmattxe As String
    Dim dtngaytiepnhan As DateTime

    Public Property MaPhieu As String
        Get
            Return strmaphieu
        End Get
        Set(value As String)
            strmaphieu = value
        End Set
    End Property

    Public Property NgayTiepNhan As Date
        Get
            Return dtngaytiepnhan
        End Get
        Set(value As Date)
            dtngaytiepnhan = value
        End Set
    End Property

    Public Property MaTTXe As String
        Get
            Return strmattxe
        End Get
        Set(value As String)
            strmattxe = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(mphieu As String, mttxe As String, ntiepnhan As DateTime)
        strmaphieu = mphieu
        strmattxe = mttxe
        dtngaytiepnhan = ntiepnhan
    End Sub
End Class
