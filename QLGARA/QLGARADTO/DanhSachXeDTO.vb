
Public Class DanhSachXeDTO
    Dim strbienso As String
    Dim strhieuxe As String
    Dim strchuxe As String
    Dim numtienno As Double

    Public Property BienSo As String
        Get
            Return strbienso
        End Get
        Set(value As String)
            strbienso = value
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

    Public Property ChuXe As String
        Get
            Return strchuxe
        End Get
        Set(value As String)
            strchuxe = value
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

    Public Sub New(strbso As String, strhxe As String, strcxe As String, numtno As String)
        strbienso = strbso
        strhieuxe = strhxe
        strchuxe = strcxe
        numtienno = numtno

    End Sub
End Class
