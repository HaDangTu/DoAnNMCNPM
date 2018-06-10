Public Class TTNhapPhuTungDTO
    Dim strMaTTNhapPhuTung As String
    Dim strMaNhapPhuTung As String
    Dim strMaPhuTung As String
    Dim numSoLuongNhap As Integer
    Dim numDonGiaNhap As Double

    Public Property MaTTNhapPhuTung As String
        Get
            Return strMaTTNhapPhuTung
        End Get
        Set(value As String)
            strMaTTNhapPhuTung = value
        End Set
    End Property

    Public Property MaNhapPhuTung As String
        Get
            Return strMaNhapPhuTung
        End Get
        Set(value As String)
            strMaNhapPhuTung = value
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

    Public Property SoLuongNhap As Integer
        Get
            Return numSoLuongNhap
        End Get
        Set(value As Integer)
            numSoLuongNhap = value
        End Set
    End Property

    Public Property DonGiaNhap As Double
        Get
            Return numDonGiaNhap
        End Get
        Set(value As Double)
            numDonGiaNhap = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaTTNPT As String, strMaNhapPT As String, strMaPT As String,
                   numSLNhap As Integer, numDGNhap As Double)
        strMaTTNhapPhuTung = strMaTTNPT
        strMaNhapPhuTung = strMaNhapPT
        strMaPhuTung = strMaPT
        numSoLuongNhap = numSLNhap
        numDonGiaNhap = numDGNhap
    End Sub
End Class
