Public Class KhachHangDTO
    Dim strmakh As String
    Dim strtenkh As String
    Dim strdiachi As String
    Dim strdienthoai As String
    Dim numtienno As Double
    Public Property MaKH As String
        Get
            Return strmakh
        End Get
        Set(value As String)
            strmakh = value
        End Set
    End Property

    Public Property TenKH As String
        Get
            Return strtenkh
        End Get
        Set(value As String)
            strtenkh = value
        End Set
    End Property

    Public Property DiaChi As String
        Get
            Return strdiachi
        End Get
        Set(value As String)
            strdiachi = value
        End Set
    End Property

    Public Property DienThoai As String
        Get
            Return strdienthoai
        End Get
        Set(value As String)
            strdienthoai = value
        End Set
    End Property

    Public Property TienNo As Double
        Get
            Return numtienno
        End Get
        Set(value As Double)
            numtienno = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(mkh As String, ten As String, dchi As String, dthoai As String)
        strmakh = mkh
        strtenkh = ten
        strdiachi = dchi
        strdienthoai = dthoai
    End Sub

    Public Sub New(mkh As String, ten As String, dchi As String, dthoai As String, numtien As Double)
        strmakh = mkh
        strtenkh = ten
        strdiachi = dchi
        strdienthoai = dthoai
        numtienno = numtien
    End Sub
End Class
