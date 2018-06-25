Public Class TonCuoiDTO
    Dim strTenPhuTung As String
    Dim numTonCuoi As Integer

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property TonCuoi As Integer
        Get
            Return numTonCuoi
        End Get
        Set(value As Integer)
            numTonCuoi = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strTenPT As String, numTC As Integer)
        strTenPhuTung = strTenPT
        numTonCuoi = numTC
    End Sub
End Class
