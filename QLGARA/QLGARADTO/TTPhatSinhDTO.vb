Public Class TTPhatSinhDTO
    Dim strMaTTPhatSinh As String
    Dim strMaPhieuNhapPS As String
    Dim strMaPhuTung As String
    Dim numSoLuongPS As Integer
    Dim numDonGiaPS As Double

    Public Property MaTTPhatSinh As String
        Get
            Return strMaTTPhatSinh
        End Get
        Set(value As String)
            strMaTTPhatSinh = value
        End Set
    End Property

    Public Property MaPhieuNhapPS As String
        Get
            Return strMaPhieuNhapPS
        End Get
        Set(value As String)
            strMaPhieuNhapPS = value
        End Set
    End Property

    Public Property MaPhuTung As String
        Get
            Return strMaPhuTung
        End Get
        Set(value As String)
            strMaPhuTung = value
        End Set
    End Property

    Public Property SoLuongPS As Integer
        Get
            Return numSoLuongPS
        End Get
        Set(value As Integer)
            numSoLuongPS = value
        End Set
    End Property

    Public Property DonGiaPS As Double
        Get
            Return numDonGiaPS
        End Get
        Set(value As Double)
            numDonGiaPS = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaTTPS As String, strMaPhieuNPS As String, strMaPT As String,
                   numSLPS As Integer, numDGiaPS As Double)
        strMaTTPhatSinh = strMaTTPS
        strMaPhieuNhapPS = strMaPhieuNPS
        strMaPhuTung = strMaPT
        numSoLuongPS = numSLPS
        numDonGiaPS = numDGiaPS
    End Sub
End Class
