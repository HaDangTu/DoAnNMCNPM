Public Class NhapPhuTungDTO
    Dim strMaNhapPhuTung As String
    Dim dtNgayNhap As DateTime
    Dim numTongTienNhap As Double

    Public Property MaNhapPhuTung As String
        Get
            Return strMaNhapPhuTung
        End Get
        Set(value As String)
            strMaNhapPhuTung = value
        End Set
    End Property

    Public Property NgayNhap As Date
        Get
            Return dtNgayNhap
        End Get
        Set(value As Date)
            dtNgayNhap = value
        End Set
    End Property

    Public Property TongTienNhap As Double
        Get
            Return numTongTienNhap
        End Get
        Set(value As Double)
            numTongTienNhap = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaNhapPT As String, dtNgay As DateTime, numTongTN As Double)
        strMaNhapPhuTung = strMaNhapPT
        dtNgayNhap = dtNgay
        numTongTienNhap = numTongTN
    End Sub

End Class
