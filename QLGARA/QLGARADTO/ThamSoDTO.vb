Public Class ThamSoDTO
    Dim numSoXeSuaChua As Double

    Public Property SoXeSuaChua As Double
        Get
            Return numSoXeSuaChua
        End Get
        Set(value As Double)
            numSoXeSuaChua = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(numSLxe As Double)
        numSoXeSuaChua = numSLxe
    End Sub
End Class
