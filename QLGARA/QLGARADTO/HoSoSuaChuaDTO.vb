Public Class HoSoSuaChuaDTO
    Dim strbienso As String
    Dim strtenchuxe As String
    Dim strdienthoai As String
    Dim strdiachi As String
    Dim strhieuxe As String

    Public Property BienSo As String
        Get
            Return strbienso
        End Get
        Set(value As String)
            strbienso = value
        End Set
    End Property

    Public Property TenChuXe As String
        Get
            Return strtenchuxe
        End Get
        Set(value As String)
            strtenchuxe = value
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

    Public Property DiaChi As String
        Get
            Return strdiachi
        End Get
        Set(value As String)
            strdiachi = value
        End Set
    End Property

    Public Property HieuXe As String
        Get
            Return strhieuxe
        End Get
        Set(value As String)
            strhieuxe = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(bso As String, tchuxe As String, dthoai As String, dchi As String, hxe As String)
        strbienso = bso
        strtenchuxe = tchuxe
        strdienthoai = dthoai
        strdiachi = dchi
        strhieuxe = hxe
    End Sub
End Class
