Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility

Public Class ThongTinXeDAL
    Private connectionstring As String
    Public Sub New()
        'Read ConnectionString value from App.config file
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(connstring As String)
        connectionstring = connstring
    End Sub

    Public Function BuidMaTTXe(ByRef nextMaTTXe As String) As Result
        nextMaTTXe = String.Empty
        Dim prefix = "TT"
        nextMaTTXe = prefix

        Dim query As String
        query = String.Empty
        query &= "SELECT TOP 1 [MaTTXe]"
        query &= "FROM [TT_XE]"
        query &= "ORDER BY [MaTTXe] DESC"

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
                            msOnDB = Reader("MaTTXe")
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
                        nextMaTTXe = nextMaTTXe + tmp1 + tmp
                        System.Console.WriteLine(nextMaTTXe)
                    End If
                Catch ex As Exception
                    conn.Close() 'Thất bại
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy mã  kế thông tin kế tiếp không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) 'Thành công
    End Function

    Public Function Insert(thongtinxe As ThongTinXeDTO) As Result
        Dim query As String
        query = String.Empty
        query &= "INSERT INTO [TT_XE]"
        query &= "([MaTTXe], [MaKH], [MaHX], [BienSo])"
        query &= "VALUES (@MaTTXe, @MaKH, @MaHX, @BienSo)"

        Dim nextMaTTXe As String
        nextMaTTXe = "1"
        BuidMaTTXe(nextMaTTXe)
        thongtinxe.MaTTXe = nextMaTTXe

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTXe", thongtinxe.MaTTXe)
                    .Parameters.AddWithValue("@MaKH", thongtinxe.MaKH)
                    .Parameters.AddWithValue("@MaHX", thongtinxe.MaHX)
                    .Parameters.AddWithValue("@BienSo", thongtinxe.BienSo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Thêm thông tin thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Update(thongtinxe As ThongTinXeDTO)
        Dim query As String
        query = String.Empty
        query &= "UPDATE [TT_XE]"
        query &= " SET [MaKH] = @MaKH, [MaHX] = @MaHX, [BienSo] = @BienSo"
        query &= " WHERE [MaTTXe] = @MaTTXe"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTxe", thongtinxe.MaTTXe)
                    .Parameters.AddWithValue("@MaKH", thongtinxe.MaKH)
                    .Parameters.AddWithValue("@MaHX", thongtinxe.MaHX)
                    .Parameters.AddWithValue("@BienSo", thongtinxe.BienSo)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Sửa thông tin xe thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Delete(mathongtinxe As String) As Result
        Dim query As String
        query = String.Empty
        query &= "DELETE FROM [TT_Xe]"
        query &= "WHERE [MaTTXe] =  @MaTTXe"


        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTXe", mathongtinxe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Xóa thông tin thất bại", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function


    Public Function SelectAll() As List(Of ThongTinXeDTO)
        Dim query As String
        Dim Listofthongtinxe As New List(Of ThongTinXeDTO)()
        query = String.Empty
        query &= "SELECT *"
        query &= "FROM [TT_Xe]"

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
                            Listofthongtinxe.Add(New ThongTinXeDTO(reader("MaTTXe"), reader("MaKH"),
                                             reader("MaHX"), reader("BienSo")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Listofthongtinxe
                End Try
            End Using
        End Using
        Return Listofthongtinxe
    End Function

    Public Function SelectPhieutiepNhan_ByBienso(bienso As String) As PhieuTiepNhanDTO
        Dim Phieutiepnhan As New PhieuTiepNhanDTO()
        Dim query As String
        query = String.Empty
        query &= "SELECT [MaPhieuTN], [TT_XE].[MaTTXe], [NgayNhan]"
        query &= " FROM [PHIEUTIEPNHAN], [TT_XE]"
        query &= " WHERE PHIEUTIEPNHAN.MaTTXe = TT_XE.MaTTXe "
        query &= " AND [BienSo] = @BienSo"
        query &= " ORDER BY [MaPhieuTN] DESC"

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@BienSo", bienso)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If (reader.HasRows) Then
                        While reader.Read()
                            Phieutiepnhan = New PhieuTiepNhanDTO(reader("MaPhieuTN"),
                                                                 reader("MaTTXe"),
                                                                 reader("NgayNhan"))

                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return Nothing
                End Try
            End Using
        End Using
        Return Phieutiepnhan
    End Function
End Class
