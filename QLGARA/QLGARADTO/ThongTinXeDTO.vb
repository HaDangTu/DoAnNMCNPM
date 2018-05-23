Public Class ThongTinXeDTO
    Dim strmattxe As String
    Dim strmakh As String
    Dim strmahx As String
    Dim strbienso As String

    Public Property MaTTXe As String
        Get
            Return strmattxe
        End Get
        Set(value As String)
            strmattxe = value
        End Set
    End Property

    Public Property MaKH As String
        Get
            Return strmakh
        End Get
        Set(value As String)
            strmakh = value
        End Set
    End Property

    Public Property MaHX As String
        Get
            Return strmahx
        End Get
        Set(value As String)
            strmahx = value
        End Set
    End Property

    Public Property BienSo As String
        Get
            Return strbienso
        End Get
        Set(value As String)
            strbienso = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(mttxe As String, mkhang As String, mhxe As String, bsoxe As String)
        strmattxe = mttxe
        strmakh = mkhang
        strmahx = mhxe
        strbienso = bsoxe
    End Sub
End Class
