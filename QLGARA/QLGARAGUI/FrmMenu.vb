﻿Public Class FrmMenu
    Private Sub QuảnLíKháchHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíKháchHàngToolStripMenuItem.Click
        Dim frmQlKhachhang As New FrmQLKhachHang()
        frmQlKhachhang.MdiParent = Me
        frmQlKhachhang.Show()
    End Sub

    Private Sub LậpPhiếuTiếpNhậnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LậpPhiếuTiếpNhậnToolStripMenuItem.Click
        Dim frmLPtiepnhan As New FrmPhieuTiepNhan()
        frmLPtiepnhan.MdiParent = Me
        frmLPtiepnhan.Show()
    End Sub

    Private Sub LậpPhiếuThuTiềnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LậpPhiếuThuTiềnToolStripMenuItem.Click
        Dim frmLPthutien As New FrmPhieuThuTien()
        frmLPthutien.MdiParent = Me
        frmLPthutien.Show()
    End Sub

    Private Sub QuảnLíHiệuXeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLíHiệuXeToolStripMenuItem.Click
        Dim frmQLHieuXe As New FrmQLHieuXe()
        frmQLHieuXe.MdiParent = Me
        frmQLHieuXe.Show()
    End Sub
End Class