Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class PhuTungDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BulidMaPhuTung(ByRef nextMaPT As String) As Result
        nextMaPT = String.Empty
        Dim prefix = "PT"
        nextMaPT = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhuTung]"
        query &= "FROM [PHUTUNG]"
        query &= "ORDER BY [MaPhuTung] DESC"

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
                            msOnDB = Reader("MaPhuTung")
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
                        nextMaPT = nextMaPT + tmp1 + tmp
                        System.Console.WriteLine(nextMaPT)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã phụ tùng kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(phutung As PhuTungDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [PHUTUNG]"
        query &= " ([MaPhuTung], [TenPhuTung], [DonGia], [SoLuongCon])"
        query &= " VALUES (@MaPhuTung, @TenMaPhuTung, @DonGia, @SoLuongCon)"

        Dim nextMaPT As String
        nextMaPT = "1"
        BulidMaPhuTung(nextMaPT)
        phutung.MaPhuTung = nextMaPT

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhuTung", phutung.MaPhuTung)
                    .Parameters.AddWithValue("@TenPhuTung", phutung.TenPhuTung)
                    .Parameters.AddWithValue("@DonGia", phutung.DonGia)
                    .Parameters.AddWithValue("@SoLuongCon", phutung.SoLuongCon)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm phụ tùng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(phutung As PhuTungDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [PHUTUNG]"
        query &= " SET [TenPhuTung] = @TenPhuTung, [DonGia] = @DonGia, [SoLuongCon] = @SoLuongCon"
        query &= " WHERE [MaPhuTung] = @MaPhuTung"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhuTung", phutung.MaPhuTung)
                    .Parameters.AddWithValue("@TenPhuTung", phutung.TenPhuTung)
                    .Parameters.AddWithValue("@DonGia", phutung.DonGia)
                    .Parameters.AddWithValue("@SoLuongCon", phutung.SoLuongCon)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin phụ tùng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maphutung As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [PHUTUNG]"
        query &= "WHERE [MaPhuTung] =  @MaPhuTung"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhuTung", maphutung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa phụ tùng thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function SelectAll() As List(Of PhuTungDTO)
        Dim query As String
        Dim ListofPhuTung As New List(Of PhuTungDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [PHUTUNG]"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            ListofPhuTung.Add(New PhuTungDTO(reader("MaPhuTung"), reader("TenPhuTung"),
                                             reader("DonGia"), reader("SoLuongCon")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return ListofPhuTung
    End Function

    Public Function Select_DonGia(maPhuTung As String) As Double
        Dim query As String
        Dim DonGia As Double
        query = String.Empty
        query &= "SELECT DonGia"
        query &= " FROM [PHUTUNG]"
        query &= "WHERE [MaPhuTung] = @MaPhuTung"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhuTung", maPhuTung)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            DonGia = reader("DonGia")
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return DonGia
    End Function
End Class
