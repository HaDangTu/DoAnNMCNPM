Public Class DoanhSoDTO
    Dim strMaDoanhSo As String
    Dim dtThang As Integer
    Dim numTongDoanhSo As Double

    Public Property MaDoanhSo As String
        Get
            Return strMaDoanhSo
        End Get
        Set(value As String)
            strMaDoanhSo = value
        End Set
    End Property

    Public Property Thang As Integer
        Get
            Return dtThang
        End Get
        Set(value As Integer)
            dtThang = value
        End Set
    End Property



    Public Property TongDoanhThu As Double
        Get
            Return numTongDoanhSo
        End Get
        Set(value As Double)
            numTongDoanhSo = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaDS As String, dtT As Integer, numTongDT As Double)
        strMaDoanhSo = strMaDS
        dtThang = dtT
        numTongDoanhSo = numTongDT
    End Sub
End Class
