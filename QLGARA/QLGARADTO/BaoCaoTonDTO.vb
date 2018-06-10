Public Class BaoCaoTonDTO
    Dim strMaBaoCaoTon As String
    Dim dtThang As Integer

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
            Return dtThang
        End Get
        Set(value As Integer)
            dtThang = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strMaBCT As String, dtMonth As Integer)
        strMaBaoCaoTon = strMaBCT
        dtThang = dtMonth
    End Sub
End Class
