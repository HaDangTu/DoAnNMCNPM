Public Class BaoCaoTonDTO
    Dim strMaBaoCaoTon As String
    Dim numThang As Integer
    Dim strTenPhuTung As String
    Dim numTonDau As Double
    Dim numPhatSinh As Double
    Dim numTonCuoi As Double

    Public Property MaBaoCaoTon As String
        Get
            Return strMaBaoCaoTon
        End Get
        Set(value As String)
            strMaBaoCaoTon = value
        End Set
    End Property

    Public Property Thang As Integer
        Get
            Return numThang
        End Get
        Set(value As Integer)
            numThang = value
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

    Public Sub New()

    End Sub

    Public Sub New(strMaBCTon As String, nummonth As Integer, strTenPT As String,
                   numTD As Double, numPS As Double, numTC As Double)
        strMaBaoCaoTon = strMaBCTon
        numThang = nummonth
        strTenPhuTung = strTenPT
        numTonDau = numTD
        numPhatSinh = numPS
        numTonCuoi = numTC
    End Sub
End Class
