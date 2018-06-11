Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class NhapPhuTungDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaNhapPhuTung(ByRef nextMaNhapPhuTung As String) As Result
        nextMaNhapPhuTung = String.Empty
        Dim prefix = "NT"
        nextMaNhapPhuTung = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaNhapPhuTung]"
        query &= " FROM [NHAPPHUTUNG]"
        query &= " ORDER BY [MaNhapPhuTung] DESC"

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
                            msOnDB = Reader("MaNhapPhuTung")
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
                        nextMaNhapPhuTung = nextMaNhapPhuTung + tmp1 + tmp
                        System.Console.WriteLine(nextMaNhapPhuTung)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã nhập phụ tùng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(nhapphutung As NhapPhuTungDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [NHAPPHUTUNG]"
        query &= " ([MaNhapPhuTung], [NgayNhap], [TongTienNhap]) "
        query &= " VALUES (@MaNhapPhuTung, @NgayNhap, @TongTienNhap) "

        Dim nextMaNhapPhuTung As String
        nextMaNhapPhuTung = "1"
        BuildMaNhapPhuTung(nextMaNhapPhuTung)
        nhapphutung.MaNhapPhuTung = nextMaNhapPhuTung

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaNhapPhuTung", nhapphutung.MaNhapPhuTung)
                    .Parameters.AddWithValue("@NgayNhap", nhapphutung.NgayNhap)
                    .Parameters.AddWithValue("@TongTienNhap", nhapphutung.TongTienNhap)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm nhập phụ tùng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
