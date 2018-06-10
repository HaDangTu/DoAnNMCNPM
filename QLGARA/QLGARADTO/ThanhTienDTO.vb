Public Class ThanhTienDTO
    Dim strTenHX As String
    Dim numThanhTien As Double

    Public Property TenHX As String
        Get
            Return strTenHX
        End Get
        Set(value As String)
            strTenHX = value
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

    Public Sub New()

    End Sub

    Public Sub New(strTen As String, numTT As Double)
        strTenHX = strTen
        numThanhTien = numTT
    End Sub
End Class
