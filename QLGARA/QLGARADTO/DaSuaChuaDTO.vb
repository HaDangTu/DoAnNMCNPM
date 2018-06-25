Public Class DaSuaChuaDTO
    Dim strTenPhuTung As String
    Dim numSLDaSC As Integer

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property SLDaSC As Integer
        Get
            Return numSLDaSC
        End Get
        Set(value As Integer)
            numSLDaSC = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strtenPT As String, numSL As Integer)
        strTenPhuTung = strtenPT
        numSLDaSC = numSL
    End Sub

End Class
