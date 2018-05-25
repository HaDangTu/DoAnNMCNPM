Public Class PhuTungDTO
    Dim strmaphutung As String
    Dim strtenphutung As String
    Dim numdongia As Double
    Dim numsoluongcon As Double

    Public Property MaPhuTung As String
        Get
            Return strmaphutung
        End Get
        Set(value As String)
            strmaphutung = value
        End Set
    End Property

    Public Property TenPhuTung As String
        Get
            Return strtenphutung
        End Get
        Set(value As String)
            strtenphutung = value
        End Set
    End Property

    Public Property DonGia As Double
        Get
            Return numdongia
        End Get
        Set(value As Double)
            numdongia = value
        End Set
    End Property

     Public Property SoLuongCon As Double
        Get
            Return numsoluongcon
        End Get
        Set(value As Double)
            numsoluongcon = value
        End Set
    End Property	

    Public Sub New()

    End Sub

    Public Sub New(mphutung As String, tphutung As String, dgia As Double, sluongcon As Double)
        strmaphutung = mphutung
        strtenphutung = tphutung
        numdongia = dgia
        numsoluongcon = sluongcon
    End Sub
End Class