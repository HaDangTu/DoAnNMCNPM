Public Class TTPhieuSuaChuaDTO
    Dim strmaphieusc As String
    Dim strmaphutung As String
    Dim strnoidung As String
    Dim numsoluong As Double
    Dim strmatiencong As String

    Public Property MaPhieuSC As String
        Get
            Return strmaphieusc
        End Get
        Set(value As String)
            strmaphieusc = value
        End Set
    End Property

    Public Property MaPhuTung As String
        Get
            Return strmaphutung
        End Get
        Set(value As String)
            strmaphutung = value
        End Set
    End Property

     Public Property NoiDung As String
        Get
            Return strnoidung
        End Get
        Set(value As String)
            strnoidung = value
        End Set
    End Property

    Public Property SoLuong As Double
        Get
            Return numsoluong
        End Get
        Set(value As Double)
            numsoluong = value
        End Set
    End Property

    Public Property MaTienCong As String
        Get
            Return strmatiencong
        End Get
        Set(value As String)
            strmatiencong = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(a As String, b As String, c As String, d As Double, e As String)
        strmaphieusc = a
        strmaphutung = b
	strnoidung = c
        numsoluong = d
        strmatiencong = e
    End Sub
End Class
