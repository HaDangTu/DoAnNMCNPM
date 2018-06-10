Public Class LuotSuaChuaDTO
    Dim strTenHX As String
    Dim numSoLuotSuaChua As Integer

    Public Property TenHX As String
        Get
            Return strTenHX
        End Get
        Set(value As String)
            strTenHX = value
        End Set
    End Property

    Public Property SoLuotSuaChua As Integer
        Get
            Return numSoLuotSuaChua
        End Get
        Set(value As Integer)
            numSoLuotSuaChua = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(strten As String, numsoluot As Integer)
        strTenHX = strten
        numSoLuotSuaChua = numsoluot
    End Sub
End Class
