Imports QLGARADTO
Imports System.Data.SqlClient
Imports System.Configuration
Imports Utility

Public Class NhapPhatSinhDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaPhieuNhapPS(ByRef nextMaPhieuNhapPS As String) As Result
        nextMaPhieuNhapPS = String.Empty
        Dim prefix = "PS"
        nextMaPhieuNhapPS = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhieuNhapPS]"
        query &= " FROM [NHAPPHATSINH]"
        query &= " ORDER BY [MaPhieuNhapPS] DESC"

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
                            msOnDB = Reader("MaPhieuNhapPS")
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
                        nextMaPhieuNhapPS = nextMaPhieuNhapPS + tmp1 + tmp
                        System.Console.WriteLine(nextMaPhieuNhapPS)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã phiếu nhập phát sinh kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(nhapphatsinh As NhapPhatSinhDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [NHAPPHATSINH]"
        query &= " ([MaPhieuNhapPS], [NgayNhapPS], [TongTienPS]) "
        query &= " VALUES (@MaPhieuNhapPS, @NgayNhapPS, @TongTienPS)"

        Dim nextMaPhieuNhapPS As String
        nextMaPhieuNhapPS = "1"
        BuildMaPhieuNhapPS(nextMaPhieuNhapPS)
        nhapphatsinh.MaPhieuNhapPS = nextMaPhieuNhapPS

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuNhapPS", nhapphatsinh.MaPhieuNhapPS)
                    .Parameters.AddWithValue("@NgayNhapPS", nhapphatsinh.NgayNhapPS)
                    .Parameters.AddWithValue("@TongTienPS", nhapphatsinh.TongTienPS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm phiếu nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(nhapphatsinh As NhapPhatSinhDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [NHAPPHATSINH]"
        query &= " SET [NgayNhapPS] = @NgayNhapPS, [TongTienPS] = @TongTienPS "
        query &= " WHERE [MaPhieuNhapPS] = @MaPhieuNhapPS"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuNhapPS", nhapphatsinh.MaPhieuNhapPS)
                    .Parameters.AddWithValue("@NgayNhapPS", nhapphatsinh.NgayNhapPS)
                    .Parameters.AddWithValue("@TongTienPS", nhapphatsinh.TongTienPS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(MaPhieuNhapPS As String) As Result
        Dim query As String
        query = String.Empty
        query &= " DELETE FROM [NHAPPHATSINH]"
        query &= " WHERE [MaPhieuNhapPS] =  @MaPhieuNhapPS"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuNhapPS", MaPhieuNhapPS)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa phiếu nhập phát sinh thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class