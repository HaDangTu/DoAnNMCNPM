Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class TTBaoCaoTonDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaTTBaoCaoTon(ByRef nextMaBaoCaoTon As String) As Result
        nextMaBaoCaoTon = String.Empty
        Dim prefix = "TX"
        nextMaBaoCaoTon = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTBaoCaoTon]"
        query &= " FROM [TT_BAOCAOTON]"
        query &= " ORDER BY [MaTTBaoCaoTon] DESC"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim Reader As SqlDataReader
                    Dim msOnDB As String
                    msOnDB = String.Empty
                    Reader = comm.ExecuteReader()
                    If (Reader.HasRows = True) Then
                        While Reader.Read()
                            msOnDB = Reader("MaTTBaoCaoTon")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        Dim tmp1 As String
                        tmp = msOnDB.Substring(2)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1
                        Dim v = converttodecimal.ToString()
                        tmp1 = tmp.Substring(0, tmp.Length - v.Length)
                        tmp = converttodecimal.ToString()
                        nextMaBaoCaoTon = nextMaBaoCaoTon + tmp1 + tmp
                        System.Console.WriteLine(nextMaBaoCaoTon)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã thông tin báo cáo tồn kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(ttbaocaoton As TTBaoCaoTonDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_BAOCAOTON]"
        query &= " ([MaTTBaoCaoTon], [TenPhuTung], [TonDau], [PhatSinh], [TonCuoi], [MaBaoCaoTon])"
        query &= " VALUES (@MaTTBaoCaoTon, @TenPhuTung, @TonDau, @PhatSinh, @TonCuoi, @MaBaoCaoTon)"

        Dim nextMaTTBaoCaoTon As String
        nextMaTTBaoCaoTon = "1"
        BuildMaTTBaoCaoTon(nextMaTTBaoCaoTon)
        ttbaocaoton.MaTTBaoCaoTon = nextMaTTBaoCaoTon

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTBaoCaoTon", ttbaocaoton.MaTTBaoCaoTon)
                    .Parameters.AddWithValue("@TenPhuTung", ttbaocaoton.TenPhuTung)
                    .Parameters.AddWithValue("@TonDau", ttbaocaoton.TonDau)
                    .Parameters.AddWithValue("@PhatSinh", ttbaocaoton.PhatSinh)
                    .Parameters.AddWithValue("@TonCuoi", ttbaocaoton.TonCuoi)
                    .Parameters.AddWithValue("@MaBaoCaoTon", ttbaocaoton.MaBaoCaoTon)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm báo cáo tồn thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
