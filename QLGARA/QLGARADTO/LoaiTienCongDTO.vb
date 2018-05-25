Public Class LoaiTienCongDTO
    Dim strmatc As String
    Dim strtenloaitc As String
    Dim nummuctien As Double

    Public Property MaTC As String
        Get
            Return strmatc
        End Get
        Set(value As String)
            strmatc = value
        End Set
    End Property

    Public Property TenLoaiTC As String
        Get
            Return strtenloaitc
        End Get
        Set(value As String)
            strtenloaitc = value
        End Set
    End Property

    Public Property MucTien As Double
        Get
            Return nummuctien
        End Get
        Set(value As Double)
            nummuctien = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(a As String, b As String, c as Double)
        strmatc = a
        strtenloaitc = b
	nummuctien = c
    End Sub
End Class
