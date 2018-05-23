﻿Imports QLGARADTO
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
                        tmp1 = msOnDB.Substring(2, 5)
                        Dim converttodecimal As Decimal
                        converttodecimal = Convert.ToDecimal(tmp)
                        converttodecimal += 1
                        Dim v = converttodecimal.ToString()
                        tmp1.Substring(0, tmp1.Length - v.Length + 1)
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

End Class
