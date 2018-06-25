Public Class SLNhapDTO
    Dim strTenPhuTung As String
    Dim numSLNhap As String

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property SLNhap As String
        Get
            Return numSLNhap
        End Get
        Set(value As String)
            numSLNhap = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strTenPT As String, numSL As String)
        strTenPhuTung = strTenPT
        numSLNhap = numSL
    End Sub
End Class
