Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility
Public Class PhieuSuaChuaDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuildMaPhieuSC(ByRef nextMaPhieuSC As String) As Result
        nextMaPhieuSC = String.Empty
        Dim prefix = "SC"
        nextMaPhieuSC = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaPhieuSC]"
        query &= "FROM [PHIEUSUACHUA]"
        query &= "ORDER BY [MaPhieuSC] DESC"

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
                            msOnDB = Reader("MaPhieuSC")
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
                        nextMaPhieuSC = nextMaPhieuSC + tmp1 + tmp
                        System.Console.WriteLine(nextMaPhieuSC)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã phiếu sửa chữa kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(phieusuachua As PhieuSuaChuaDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [PHIEUSUACHUA]"
        query &= " ([MaPhieuSC], [MaPhieuTN], [NgaySC])"
        query &= " VALUES (@MaPhieuSC, @MaPhieuTN, @NgaySC)"

        Dim nextMaPhieuSC As String
        nextMaPhieuSC = "1"
        BuildMaPhieuSC(nextMaPhieuSC)
        phieusuachua.MaPhieuSC = nextMaPhieuSC

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuSC", phieusuachua.MaPhieuSC)
                    .Parameters.AddWithValue("@MaPhieuTN", phieusuachua.MaPhieuTN)
                    .Parameters.AddWithValue("@NgaySC", phieusuachua.NgaySC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm phiếu sửa chữa thành công thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(phieusuachua As PhieuSuaChuaDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "UPDATE [PHIEUSUACHUA]"
        query &= " SET [MaPhieuTN] = @MaPhieuTN, [NgaySC] = @NgaySC"
        query &= " WHERE [MaPhieuSC] = @MaPhieuSC"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuSC", phieusuachua.MaPhieuSC)
                    .Parameters.AddWithValue("@MaPhieuTN", phieusuachua.MaPhieuTN)
                    .Parameters.AddWithValue("@NgaySC", phieusuachua.NgaySC)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin phiếu sửa chữa thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(maphieusc As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [PHIEUSUACHUA]"
        query &= "WHERE [MaPhieuSC] =  @MaPhieuSC"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaPhieuSC", maphieusc)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa phiếu sửa chữa  thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function SelectAll() As List(Of PhieuSuaChuaDTO)
        Dim query As String
        Dim ListOfPhieuSuaChua As New List(Of PhieuSuaChuaDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [PHIEUSUACHUA]"

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
                            ListOfPhieuSuaChua.Add(New PhieuSuaChuaDTO(reader("MaPhieuSC"), reader("MaPhieuTN"),
                                             reader("NgaySC")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return ListOfPhieuSuaChua
    End Function
End Class
