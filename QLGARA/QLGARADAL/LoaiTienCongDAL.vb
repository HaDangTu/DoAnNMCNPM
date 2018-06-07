Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class LoaiTienCongDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaLoaiTC(ByRef nextmaloaiTC As String) As Result
        nextmaloaiTC = String.Empty
        Dim prefix = "TC"
        nextmaloaiTC = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTienCong]"
        query &= " FROM [LOAITIENCONG]"
        query &= " ORDER BY [MaTienCong] DESC"

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
                            msOnDB = Reader("MaTienCong")
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
                        nextmaloaiTC = nextmaloaiTC + tmp1 + tmp
                        System.Console.WriteLine(nextmaloaiTC)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã loại tiền công kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(loaitiencong As LoaiTienCongDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [LOAITIENCONG]"
        query &= " ([MaTienCong], [TenLoaiTienCong], [MucTien]])"
        query &= " VALUES (@MaTienCong, @TenTenLoaiTienCong, @MucTien)"

        Dim nextmatc As String
        nextmatc = "1"
        BuildMaLoaiTC(nextmatc)
        loaitiencong.MaTC = nextmatc

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTienCong", loaitiencong.MaTC)
                    .Parameters.AddWithValue("@TenLoaiTienCong", loaitiencong.TenLoaiTC)
                    .Parameters.AddWithValue("@MucTien", loaitiencong.MucTien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm loại tiền công thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(loaitiencong As LoaiTienCongDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [LOAITIENCONG]"
        query &= " SET [TenLoaiTienCong] = @TenLoaiTienCong, [MucTien] = @MucTien"
        query &= " WHERE [MaTienCong] = @MaTienCong"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTienCong", loaitiencong.MaTC)
                    .Parameters.AddWithValue("@TenLoaiTienCong", loaitiencong.TenLoaiTC)
                    .Parameters.AddWithValue("@MucTien", loaitiencong.MucTien)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin loại tiền công thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(matc As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [LOAITIENCONG]"
        query &= " WHERE [MaTienCong] =  @MaTienCong"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTienCong", matc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa loại tiền công thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function SelectAll() As List(Of LoaiTienCongDTO)
        Dim query As String
        Dim ListofLoaiTienCong As New List(Of LoaiTienCongDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [LOAITIENCONG]"

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
                            ListofLoaiTienCong.Add(New LoaiTienCongDTO(reader("MaTienCong"),
                                                                    reader("TenLoaiTienCong"),
                                                                    reader("MucTien")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return ListofLoaiTienCong
                End Try
            End Using
        End Using
        Return ListofLoaiTienCong
    End Function


    Public Function Select_MucTien(matiencong As String)
        Dim query As String
        Dim MucTien As Double
        query = String.Empty
        query &= "SELECT MucTien"
        query &= " FROM [LOAITIENCONG]"
        query &= "WHERE [MaTienCong] = @MaTienCong"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTienCong", matiencong)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While (reader.Read())
                            MucTien = reader("MucTien")
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return 0
                End Try
            End Using
        End Using
        Return MucTien
    End Function
End Class
