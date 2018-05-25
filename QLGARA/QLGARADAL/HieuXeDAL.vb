Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class HieuXeDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaHX(ByRef nextMaHX As String) As Result
        nextMaHX = String.Empty
        Dim prefix = "HX"
        nextMaHX = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaHX]"
        query &= "FROM [HIEUXE]"
        query &= "ORDER BY [MaHX] DESC"

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
                            msOnDB = Reader("[MaHX]")
                        End While
                    End If

                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim tmp As String
                        Dim tmp1 As String
                        tmp = msOnDB.Substring(2)
                        tmp1 = msOnDB.Substring(2, 5)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1
                        Dim v = converttodecimal.ToString()
                        tmp1.Substring(0, tmp1.Length - v.Length + 1)
                        tmp = converttodecimal.ToString()
                        nextMaHX = nextMaHX + tmp1 + tmp
                        System.Console.WriteLine(nextMaHX)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã hiệu xe kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(hieuxe As HieuXeDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [HIEUXE]"
        query &= " ([MaHX], [TenHX])"
        query &= "VALUES (@MaHX, @TenHX)"

        Dim nextMaHX As String
        nextMaHX = "1"
        BuildMaHX(nextMaHX)
        hieuxe.MaHX = nextMaHX

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaHX", hieuxe.MaHX)
                    .Parameters.AddWithValue("@TenHX", hieuxe.TenHX)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm hiệu xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(hieuxe As HieuXeDTO)
        Dim query As String
        query = String.Empty
        query &= "UPDATE [HIEUXE]"
        query &= " SET [TenHX] = @TenHX"
        query &= " WHERE [MaHX] = @MaHX"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaHX", hieuxe.MaHX)
                    .Parameters.AddWithValue("@TenHX", hieuxe.TenHX)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa hiệu xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(mahieuxe As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [HIEUXE]"
        query &= "WHERE [MaHX] =  @MaHX"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaHX", mahieuxe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa hiệu xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Select_ALL(ByRef ListofHieuxe As List(Of HieuXeDTO)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [MaHX], [TenHX] FROM [HIEUXE]"

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
                    Reader = comm.ExecuteReader()
                    If Reader.HasRows Then
                        While Reader.Read()
                            ListofHieuxe.Add(New HieuXeDTO(Reader("MaHX"), Reader("TenHX")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy tất cả hiệu xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function
End Class
