Public Class TTDoanhSoDTO
    Dim strMaTTDoanhSo As String
    Dim strHieuXe As String
    Dim numSoLuotSua As Integer
    Dim numThanhTien As Double
    Dim numTiLe As Double
    Dim strMaDoanhSo As String

    Public Property MaTTDoanhSo As String
        Get
            Return strMaTTDoanhSo
        End Get
        Set(value As String)
            strMaTTDoanhSo = value
        End Set
    End Property

    Public Property HieuXe As String
        Get
            Return strHieuXe
        End Get
        Set(value As String)
            strHieuXe = value
        End Set
    End Property

    Public Property SoLuotSua As Integer
        Get
            Return numSoLuotSua
        End Get
        Set(value As Integer)
            numSoLuotSua = value
        End Set
    End Property

    Public Property ThanhTien As Double
        Get
            Return numThanhTien
        End Get
        Set(value As Double)
            numThanhTien = value
        End Set
    End Property

    Public Property TiLe As Double
        Get
            Return numTiLe
        End Get
        Set(value As Double)
            numTiLe = value
        End Set
    End Property

    Public Property MaDoanhSo As String
        Get
            Return strMaDoanhSo
        End Get
        Set(value As String)
            strMaDoanhSo = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMattDS As String, strHx As String, numSoLS As Integer, numTT As Double,
                   numTL As Double, strMaDS As String)
        strMaTTDoanhSo = strMattDS
        strHieuXe = strHx
        numSoLuotSua = numSoLS
        numThanhTien = numTT
        numTiLe = numTL
        strMaDoanhSo = strMaDS
    End Sub
End Class
