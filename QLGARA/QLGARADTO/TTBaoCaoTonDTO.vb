Public Class TTBaoCaoTonDTO
    Dim strMaTTBaoCaoTon As String
    Dim strTenPhuTung As String
    Dim numTonDau As Double
    Dim numPhatSinh As Double
    Dim numTonCuoi As Double
    Dim strMaBaoCaoTon As String

    Public Property MaTTBaoCaoTon As String
        Get
            Return strMaTTBaoCaoTon
        End Get
        Set(value As String)
            strMaTTBaoCaoTon = value
        End Set
    End Property

    Public Property TenPhuTung As String
        Get
            Return strTenPhuTung
        End Get
        Set(value As String)
            strTenPhuTung = value
        End Set
    End Property

    Public Property TonDau As Double
        Get
            Return numTonDau
        End Get
        Set(value As Double)
            numTonDau = value
        End Set
    End Property

    Public Property PhatSinh As Double
        Get
            Return numPhatSinh
        End Get
        Set(value As Double)
            numPhatSinh = value
        End Set
    End Property

    Public Property TonCuoi As Double
        Get
            Return numTonCuoi
        End Get
        Set(value As Double)
            numTonCuoi = value
        End Set
    End Property

    Public Property MaBaoCaoTon As String
        Get
            Return strMaBaoCaoTon
        End Get
        Set(value As String)
            strMaBaoCaoTon = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaTTBCT As String, strTenPT As String, numTD As Double, numPS As Double,
                    numTC As Double, strMaBCT As String)
        strMaTTBaoCaoTon = strMaTTBCT
        strTenPhuTung = strTenPT
        numTonDau = numTD
        numPhatSinh = numPS
        numTonCuoi = numTC
        strMaBaoCaoTon = strMaBCT
    End Sub
End Class
