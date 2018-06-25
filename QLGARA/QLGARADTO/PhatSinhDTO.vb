Public Class PhatSinhDTO
    Dim strTenPhuTung As String
    Dim numSLPhatSinh As Integer

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property SLPhatSinh As Integer
        Get
            Return numSLPhatSinh
        End Get
        Set(value As Integer)
            numSLPhatSinh = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strtenPT As String, numSL As Integer)
        strTenPhuTung = strtenPT
        numSLPhatSinh = numSL
    End Sub
End Class
