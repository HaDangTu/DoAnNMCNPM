Imports QLGARADTO
Imports QLGARABUS
Imports Utility

Public Class FrmThayDoiQuyDinh
    Dim thamsoBUS As New ThamSoBUS()
    Dim macdinh As New ThamSoDTO()
    Public Sub loadQuyDinh(ByRef thamso As ThamSoDTO)
        Dim result As Result
        result = thamsoBUS.SelectALL(thamso)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy thông tin quy định thất bại", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return
        End If
    End Sub

    Private Sub FrmThayDoiQuyDinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thamso As New ThamSoDTO()
        loadQuyDinh(thamso)
        loadQuyDinh(macdinh)
        tbSoXeSC.Text = thamso.SoXeSuaChua.ToString()

    End Sub

    Private Sub btThayDoi_Click(sender As Object, e As EventArgs) Handles btThayDoi.Click
        Dim thamso As New ThamSoDTO()
        Dim result As Result

        thamso.SoXeSuaChua = Integer.Parse(tbSoXeSC.Text)
        result = thamsoBUS.Update(thamso)
        If (result.FlagResult = False) Then
            MessageBox.Show("Thay đổi quy định thất bại", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        Else
            MessageBox.Show("Thay đổi quy định thành công", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
        tbSoXeSC.Text = thamso.SoXeSuaChua
    End Sub

    Private Sub btReset_Click(sender As Object, e As EventArgs) Handles btReset.Click
        Dim result As Result
        tbSoXeSC.Text = macdinh.SoXeSuaChua.ToString()
        thamsoBUS.Update(macdinh)
        result = thamsoBUS.Update(macdinh)
        If (result.FlagResult = False) Then
            MessageBox.Show("Thay đổi quy định thất bại", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        Else
            MessageBox.Show("Thay đổi quy định thành công", "Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub
End Class