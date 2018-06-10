
Public Class NhapPhatSinhDTO
    Dim strMaPhieuNhapPS As String
    Dim dtNgayNhapPS As DateTime
    Dim numTongTienPS As Double

    Public Property MaPhieuNhapPS As String
        Get
            Return strMaPhieuNhapPS
        End Get
        Set(value As String)
            strMaPhieuNhapPS = value
        End Set
    End Property

    Public Property NgayNhapPS As Date
        Get
            Return dtNgayNhapPS
        End Get
        Set(value As Date)
            dtNgayNhapPS = value
        End Set
    End Property

    Public Property TongTienPS As Double
        Get
            Return numTongTienPS
        End Get
        Set(value As Double)
            numTongTienPS = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaPhieuPS As String, dtNgayPS As String, numTongPS As Double)
        strMaPhieuNhapPS = strMaPhieuPS
        dtNgayNhapPS = dtNgayPS
        numTongTienPS = numTongPS
    End Sub
End Class
