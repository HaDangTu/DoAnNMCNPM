Imports QLGARADTO
Imports System.Configuration
Imports System.Data.SqlClient
Imports Utility

Public Class DanhSachXeDAL
    Private connectionstring As String
    Public Sub New()
        connectionstring = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(ConnectionString As String)
        Me.connectionstring = ConnectionString
    End Sub

    'Public Function Select_By_MaTTXe(MaTTXe As String, ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Dim query As String
    '    query = String.Empty
    '    query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
    '    query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
    '    query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
    '    query &= "TT_XE.MaTTXe = @MaTTXe "

    '    Using conn As New SqlConnection(connectionstring)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@MaTTXe", MaTTXe)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                Dim msOnDB As String
    '                msOnDB = Nothing
    '                If reader.HasRows = True Then
    '                    While reader.Read()
    '                        ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
    '                                                                reader("TenKH"), reader("TienNo")))
    '                    End While
    '                End If
    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True)
    'End Function

    'Public Function Select_By_BienSo(bienso As String, ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Dim query As String
    '    query = String.Empty
    '    query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
    '    query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
    '    query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
    '    query &= "BienSo = @BienSo "

    '    Using conn As New SqlConnection(connectionstring)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@BienSo", bienso)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                Dim msOnDB As String
    '                msOnDB = Nothing
    '                If reader.HasRows = True Then
    '                    While reader.Read()
    '                        ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
    '                                                                reader("TenKH"), reader("TienNo")))
    '                    End While
    '                End If
    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True)
    'End Function

    'Public Function Select_By_HieuXe(MaHX As String, ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Dim query As String
    '    query = String.Empty
    '    query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
    '    query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
    '    query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
    '    query &= "HIEUXE.MaHX = @MaHX "

    '    Using conn As New SqlConnection(connectionstring)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@MaHX", MaHX)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                Dim msOnDB As String
    '                msOnDB = Nothing
    '                If reader.HasRows = True Then
    '                    While reader.Read()
    '                        ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
    '                                                                reader("TenKH"), reader("TienNo")))
    '                    End While
    '                End If
    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True)
    'End Function

    'Public Function Select_By_MaKH(MaKH As String, ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Dim query As String
    '    query = String.Empty
    '    query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
    '    query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
    '    query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
    '    query &= "KHACHHANG.MaKH = @MaKh "

    '    Using conn As New SqlConnection(connectionstring)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@MaKH", MaKH)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                Dim msOnDB As String
    '                msOnDB = Nothing
    '                If reader.HasRows = True Then
    '                    While reader.Read()
    '                        ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
    '                                                                reader("TenKH"), reader("TienNo")))
    '                    End While
    '                End If
    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True)
    'End Function

    'Public Function Select_By_TenKH(TenKH As String, ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
    '    Dim query As String
    '    query = String.Empty
    '    query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
    '    query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
    '    query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
    '    query &= "TenKH = @TenKH "

    '    Using conn As New SqlConnection(connectionstring)
    '        Using comm As New SqlCommand()
    '            With comm
    '                .Connection = conn
    '                .CommandType = CommandType.Text
    '                .CommandText = query
    '                .Parameters.AddWithValue("@TenKH", TenKH)
    '            End With
    '            Try
    '                conn.Open()
    '                Dim reader As SqlDataReader
    '                reader = comm.ExecuteReader()
    '                Dim msOnDB As String
    '                msOnDB = Nothing
    '                If reader.HasRows = True Then
    '                    While reader.Read()
    '                        ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
    '                                                                reader("TenKH"), reader("TienNo")))
    '                    End While
    '                End If
    '            Catch ex As Exception
    '                conn.Close()
    '                System.Console.WriteLine(ex.StackTrace)
    '                Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
    '            End Try
    '        End Using
    '    End Using
    '    Return New Result(True)
    'End Function

    Public Function Select_By_TienNo(tiennoMin As Double, tiennoMax As Double,
                                     ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
        query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
        query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX AND "
        query &= "TienNo >= @TienNoMin AND TienNo <= @TienNoMax "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@TienNoMin", tiennoMin)
                    .Parameters.AddWithValue("@TienNoMax", tiennoMax)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim msOnDB As String
                    msOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
                                                                    reader("TenKH"), reader("TienNo")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function Select_DanhSachXe(MaTTXe As String, BienSo As String, MaHX As String, TenKH As String,
                                      MaKH As String,
                                      ByRef ListofDanhSachXe As List(Of DanhSachXeDTO)) As Result
        Dim query As String
        query = String.Empty
        query &= "SELECT [BienSo], [TenHX], [TenKH], [TienNo] "
        query &= "FROM [TT_XE], [KHACHHANG], [HIEUXE] "
        query &= "WHERE TT_XE.MaKH = KHACHHANG.MaKH AND TT_Xe.MaHX = HIEUXE.MaHX  "
        query &= "And (TT_XE.MaTTXe = @MaTTXe OR BienSo = @BienSo OR HIEUXE.MaHX = @MaHX OR "
        query &= "TenKH = @TenKH OR KHACHHANG.MaKH = @MaKH) "

        Using conn As New SqlConnection(connectionstring)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaTTXe", MaTTXe)
                    .Parameters.AddWithValue("@BienSo", BienSo)
                    .Parameters.AddWithValue("@MaHX", MaHX)
                    .Parameters.AddWithValue("@MaKH", MaKH)
                    .Parameters.AddWithValue("@TenKH", TenKH)

                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim msOnDB As String
                    msOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            ListofDanhSachXe.Add(New DanhSachXeDTO(reader("BienSo"), reader("TenHX"),
                                                                    reader("TenKH"), reader("TienNo")))
                        End While
                    End If
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, "Lấy danh sách xe không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

End Class
