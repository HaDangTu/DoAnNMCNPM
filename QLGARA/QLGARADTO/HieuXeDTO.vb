Public Class HieuXeDTO
    Dim strmahx As String
    Dim strtenhx As String

    Public Property MaHX As String
        Get
            Return strmahx
        End Get
        Set(value As String)
            strmahx = value
        End Set
    End Property

    Public Property TenHX As String
        Get
            Return strtenhx
        End Get
        Set(value As String)
            strtenhx = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(mhieuxe As String, tenhieuxe As String)
        strmahx = mhieuxe
        strtenhx = tenhieuxe
    End Sub
End Class
