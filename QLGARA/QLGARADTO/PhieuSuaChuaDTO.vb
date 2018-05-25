Public Class PhieuSuaChuaDTO
    Dim strmaphieusc As String
    Dim strmaphieutn As String
    Dim dtsuachua As DateTime

    Public Property MaPhieuSC As String
        Get
            Return strmaphieusc
        End Get
        Set(value As String)
            strmaphieusc = value
        End Set
    End Property

    Public Property MaPhieuTN As String
        Get
            Return strmaphieutn
        End Get
        Set(value As String)
            strmaphieutn = value
        End Set
    End Property

     Public Property NgaySC As DateTime
        Get
            Return dtsuachua
        End Get
        Set(value As DateTime)
            dtsuachua = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(a As String, b As String, c As DateTime)
        strmaphieusc = a
        strmaphieutn = b
	dtsuachua = c
    End Sub
End Class
