Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class KhachHangDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaMKH(nextMaKH As String) As Result
        nextMaKH = String.Empty
        Dim prefix = "MP"
        nextMaKH = prefix + "00000"

        Dim query As String
        query = String.Empty
        query &= "SELECT [MaKH]"
        query &= "FROM [KHACHHANG]"
        query &= "ORDER BY [MaKH] DESC"

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
                            msOnDB = Reader("[MaPhieuTN]")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        tmp = msOnDB.Substring(msOnDB.Length - 6, 5)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1

                        tmp = converttodecimal.ToString()
                        nextMaKH = nextMaKH + tmp
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã phiếu kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(khachhang As KhachHangDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [KHACHHANG]"
        query &= "([MaKH], [TenKH], [DiaChi], [DienThoai])"
        query &= "VALUE (@MaKH, @TenKH, @DiaChi, @DienThoai)"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaKH", khachhang.MaKH)
                    .Parameters.AddWithValue("@TenKH", khachhang.TenKH)
                    .Parameters.AddWithValue("@DiaChi", khachhang.DiaChi)
                    .Parameters.AddWithValue("@DienThoai", khachhang.DienThoai)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm khách hàng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
