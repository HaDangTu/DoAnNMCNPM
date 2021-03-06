/****** To insert Vietnames:  ******/
/****** 1. make sure script in Unicode-16 ******/
/****** 2. Put N before Vietnames text ******/
/******    Example: N'Nguyễn Công Hoan' ******/

USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLGARA')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLGARA') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLGARA]
END
GO
CREATE DATABASE [QLGARA]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 24/06/2018 8:19:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [nvarchar](40) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](10) NULL,
	[TienNo] [float] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[HIEUXE]    Script Date: 24/06/2018 8:21:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HIEUXE](
	[MaHX] [nvarchar](40) NOT NULL,
	[TenHX] [nvarchar](50) NULL,
	[NhanSua] [nvarchar](10) NULL,
 CONSTRAINT [PK_HIEUXE] PRIMARY KEY CLUSTERED 
(
	[MaHX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_XE]    Script Date: 24/06/2018 8:22:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_XE](
	[MaTTXe] [nvarchar](40) NOT NULL,
	[MaKH] [nvarchar](40) NULL,
	[MaHX] [nvarchar](40) NULL,
	[BienSo] [varchar](40) NULL,
 CONSTRAINT [PK_TT_XE] PRIMARY KEY CLUSTERED 
(
	[MaTTXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TT_XE]  WITH CHECK ADD  CONSTRAINT [FK_TT_XE1] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO

ALTER TABLE [dbo].[TT_XE] CHECK CONSTRAINT [FK_TT_XE1]
GO

ALTER TABLE [dbo].[TT_XE]  WITH CHECK ADD  CONSTRAINT [FK_TT_XE2] FOREIGN KEY([MaHX])
REFERENCES [dbo].[HIEUXE] ([MaHX])
GO

ALTER TABLE [dbo].[TT_XE] CHECK CONSTRAINT [FK_TT_XE2]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[PHIEUTIEPNHAN]    Script Date: 24/06/2018 8:23:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PHIEUTIEPNHAN](
	[MaPhieuTN] [nvarchar](40) NOT NULL,
	[MaTTXe] [nvarchar](40) NULL,
	[NgayNhan] [datetime2](7) NULL,
 CONSTRAINT [PK_PHIEUTIEPNHAN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PHIEUTIEPNHAN]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUTIEPNHAN] FOREIGN KEY([MaTTXe])
REFERENCES [dbo].[TT_XE] ([MaTTXe])
GO

ALTER TABLE [dbo].[PHIEUTIEPNHAN] CHECK CONSTRAINT [FK_PHIEUTIEPNHAN]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[PHIEUTHUTIEN]    Script Date: 24/06/2018 8:23:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PHIEUTHUTIEN](
	[MaPhieuThuTien] [nvarchar](40) NOT NULL,
	[MaPhieuTN] [nvarchar](40) NULL,
	[NgayThuTien] [datetime2](7) NULL,
	[SoTienThu] [float] NULL,
 CONSTRAINT [PK_PHIEUTHUTIEN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThuTien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PHIEUTHUTIEN]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUTHUTIEN] FOREIGN KEY([MaPhieuTN])
REFERENCES [dbo].[PHIEUTIEPNHAN] ([MaPhieuTN])
GO

ALTER TABLE [dbo].[PHIEUTHUTIEN] CHECK CONSTRAINT [FK_PHIEUTHUTIEN]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[THAMSO]    Script Date: 24/06/2018 8:24:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[THAMSO](
	[SoXeSuaChua] [float] NULL
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[BAOCAOTON]    Script Date: 24/06/2018 8:24:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BAOCAOTON](
	[MaBaoCaoTon] [nvarchar](40) NOT NULL,
	[Thang] [int] NULL,
 CONSTRAINT [PK_BAOCAOTON] PRIMARY KEY CLUSTERED 
(
	[MaBaoCaoTon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[DOANHSO]    Script Date: 24/06/2018 8:09:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DOANHSO](
	[MaDoanhSo] [nvarchar](40) NOT NULL,
	[Thang] [tinyint] NULL,
	[TongDoanhThu] [float] NULL,
 CONSTRAINT [PK_DOANHSO] PRIMARY KEY CLUSTERED 
(
	[MaDoanhSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [QLGARA]
GO

/****** Object:  Table [dbo].[PHIEUSUACHUA]    Script Date: 24/06/2018 8:25:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PHIEUSUACHUA](
	[MaPhieuSC] [nvarchar](40) NOT NULL,
	[MaPhieuTN] [nvarchar](40) NULL,
	[NgaySC] [datetime2](7) NULL,
 CONSTRAINT [PK_PHIEUSUACHUA] PRIMARY KEY CLUSTERED 
(
	[MaPhieuSC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PHIEUSUACHUA]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUSUACHUA] FOREIGN KEY([MaPhieuTN])
REFERENCES [dbo].[PHIEUTIEPNHAN] ([MaPhieuTN])
GO

ALTER TABLE [dbo].[PHIEUSUACHUA] CHECK CONSTRAINT [FK_PHIEUSUACHUA]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[PHUTUNG]    Script Date: 24/06/2018 8:26:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PHUTUNG](
	[MaPhuTung] [nvarchar](40) NOT NULL,
	[TenPhuTung] [nvarchar](50) NULL,
	[SoLuongCon] [int] NULL,
	[DonGia] [float] NULL,
 CONSTRAINT [PK_PHUTUNG] PRIMARY KEY CLUSTERED 
(
	[MaPhuTung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[NHAPPHUTUNG]    Script Date: 24/06/2018 8:27:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NHAPPHUTUNG](
	[MaNhapPhuTung] [nvarchar](40) NOT NULL,
	[NgayNhap] [datetime2](7) NULL,
	[TongTienNhap] [float] NULL,
 CONSTRAINT [PK_NHAPPHUTUNG] PRIMARY KEY CLUSTERED 
(
	[MaNhapPhuTung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_NHAPPHUTUNG]    Script Date: 24/06/2018 8:27:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_NHAPPHUTUNG](
	[MaTTNhapPhuTung] [nvarchar](40) NOT NULL,
	[MaNhapPhuTung] [nvarchar](40) NULL,
	[MaPhuTung] [nvarchar](40) NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
 CONSTRAINT [PK_TT_NHAPPHUTUNG] PRIMARY KEY CLUSTERED 
(
	[MaTTNhapPhuTung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TT_NHAPPHUTUNG]  WITH CHECK ADD  CONSTRAINT [FK_TT_NHAPPHUTUNG1] FOREIGN KEY([MaNhapPhuTung])
REFERENCES [dbo].[NHAPPHUTUNG] ([MaNhapPhuTung])
GO

ALTER TABLE [dbo].[TT_NHAPPHUTUNG] CHECK CONSTRAINT [FK_TT_NHAPPHUTUNG1]
GO

ALTER TABLE [dbo].[TT_NHAPPHUTUNG]  WITH CHECK ADD  CONSTRAINT [FK_TT_NHAPPHUTUNG2] FOREIGN KEY([MaPhuTung])
REFERENCES [dbo].[PHUTUNG] ([MaPhuTung])
GO

ALTER TABLE [dbo].[TT_NHAPPHUTUNG] CHECK CONSTRAINT [FK_TT_NHAPPHUTUNG2]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[NHAPPHATSINH]    Script Date: 24/06/2018 8:28:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NHAPPHATSINH](
	[MaPhieuNhapPS] [nvarchar](40) NOT NULL,
	[NgayNhapPS] [datetime2](7) NULL,
	[TongTienPS] [float] NULL,
 CONSTRAINT [PK_NHAPPHATSINH] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhapPS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_PHATSINH]    Script Date: 24/06/2018 8:28:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_PHATSINH](
	[MaTTPhatSinh] [nvarchar](40) NOT NULL,
	[MaPhieuNhapPS] [nvarchar](40) NULL,
	[MaPhuTung] [nvarchar](40) NULL,
	[SoLuongPS] [int] NULL,
	[DonGiaPS] [float] NULL,
 CONSTRAINT [PK_TT_PHATSINH] PRIMARY KEY CLUSTERED 
(
	[MaTTPhatSinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TT_PHATSINH]  WITH CHECK ADD  CONSTRAINT [FK_TT_PHATSINH1] FOREIGN KEY([MaPhieuNhapPS])
REFERENCES [dbo].[NHAPPHATSINH] ([MaPhieuNhapPS])
GO

ALTER TABLE [dbo].[TT_PHATSINH] CHECK CONSTRAINT [FK_TT_PHATSINH1]
GO

ALTER TABLE [dbo].[TT_PHATSINH]  WITH CHECK ADD  CONSTRAINT [FK_TT_PHATSINH2] FOREIGN KEY([MaPhuTung])
REFERENCES [dbo].[PHUTUNG] ([MaPhuTung])
GO

ALTER TABLE [dbo].[TT_PHATSINH] CHECK CONSTRAINT [FK_TT_PHATSINH2]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[LOAITIENCONG]    Script Date: 24/06/2018 8:29:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LOAITIENCONG](
	[MaTienCong] [nvarchar](40) NOT NULL,
	[TenLoaiTienCong] [nvarchar](50) NULL,
	[MucTien] [nvarchar](40) NULL,
 CONSTRAINT [PK_LOAITIENCONG] PRIMARY KEY CLUSTERED 
(
	[MaTienCong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_PHIEUSUACHUA]    Script Date: 24/06/2018 8:29:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_PHIEUSUACHUA](
	[MaTTPhieuSuaChua] [nvarchar](40) NOT NULL,
	[MaPhieuSC] [nvarchar](40) NULL,
	[MaPhuTung] [nvarchar](40) NULL,
	[NoiDung] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[MaTienCong] [nvarchar](40) NULL,
 CONSTRAINT [PK_TT_PHIEUSUACHUA] PRIMARY KEY CLUSTERED 
(
	[MaTTPhieuSuaChua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA]  WITH CHECK ADD  CONSTRAINT [FK_TT_PHIEUSUACHUA1] FOREIGN KEY([MaPhieuSC])
REFERENCES [dbo].[PHIEUSUACHUA] ([MaPhieuSC])
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA] CHECK CONSTRAINT [FK_TT_PHIEUSUACHUA1]
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA]  WITH CHECK ADD  CONSTRAINT [FK_TT_PHIEUSUACHUA2] FOREIGN KEY([MaPhuTung])
REFERENCES [dbo].[PHUTUNG] ([MaPhuTung])
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA] CHECK CONSTRAINT [FK_TT_PHIEUSUACHUA2]
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA]  WITH CHECK ADD  CONSTRAINT [FK_TT_PHIEUSUACHUA3] FOREIGN KEY([MaTienCong])
REFERENCES [dbo].[LOAITIENCONG] ([MaTienCong])
GO

ALTER TABLE [dbo].[TT_PHIEUSUACHUA] CHECK CONSTRAINT [FK_TT_PHIEUSUACHUA3]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[BAOCAOTON]    Script Date: 24/06/2018 8:11:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BAOCAOTON](
	[MaBaoCaoTon] [nvarchar](40) NOT NULL,
	[Thang] [tinyint] NULL,
 CONSTRAINT [PK_BAOCAOTON] PRIMARY KEY CLUSTERED 
(
	[MaBaoCaoTon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_DOANHSO]    Script Date: 24/06/2018 8:31:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_DOANHSO](
	[MaTTDoanhSo] [nvarchar](40) NOT NULL,
	[HieuXe] [nvarchar](20) NULL,
	[SoLuotSua] [tinyint] NULL,
	[ThanhTien] [float] NULL,
	[TiLe] [float] NULL,
	[MaDoanhSo] [nvarchar](40) NULL,
 CONSTRAINT [PK_TT_DOANHSO] PRIMARY KEY CLUSTERED 
(
	[MaTTDoanhSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [QLGARA]
GO

/****** Object:  Table [dbo].[TT_BAOCAOTON]    Script Date: 24/06/2018 10:27:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TT_BAOCAOTON](
	[MaTTBaoCaoTon] [nvarchar](40) NOT NULL,
	[TenPhuTung] [nvarchar](40) NULL,
	[TonDau] [float] NULL,
	[PhatSinh] [float] NULL,
	[TonCuoi] [float] NULL,
	[MaBaoCaoTon] [nvarchar](40) NULL,
 CONSTRAINT [PK_TT_BaoCaoTon] PRIMARY KEY CLUSTERED 
(
	[MaTTBaoCaoTon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TT_BAOCAOTON]  WITH CHECK ADD  CONSTRAINT [FK_TT_BAOCAOTON_BAOCAOTON] FOREIGN KEY([MaBaoCaoTon])
REFERENCES [dbo].[BAOCAOTON] ([MaBaoCaoTon])
GO

ALTER TABLE [dbo].[TT_BAOCAOTON] CHECK CONSTRAINT [FK_TT_BAOCAOTON_BAOCAOTON]
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[KHACHHANG]
           ([MaKH]
           ,[TenKH]
           ,[DiaChi]
           ,[DienThoai]
           ,[TienNo])
     VALUES
           ('KH000001'
           ,N'Ngô Kinh'
           ,N'120 Trương Định'
           ,'090934343'
           ,0)
GO

INSERT INTO [dbo].[KHACHHANG]
           ([MaKH]
           ,[TenKH]
           ,[DiaChi]
           ,[DienThoai]
           ,[TienNo])
     VALUES
           ('KH000002'
           ,N'Tom Cruise'
           ,N'12 Nguyễn Hữu Cảnh'
           ,'090934343'
           ,0)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000001'
           ,'Ford'
           ,N'có')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000002'
           ,'Toyota'
           ,N'có')
GO


INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000003'
           ,'Chevrolet'
           ,N'có')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000004'
           ,'Kia'
           ,N'có')
GO



INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000005'
           ,'Honda'
           ,N'có')
GO


INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000006'
           ,'Suzuki'
           ,N'không')
GO


INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000007'
           ,'Audi'
           ,N'có')
GO



INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000008'
           ,'BMW'
           ,N'có')
GO



INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000009'
           ,'Mazda'
           ,N'không')
GO

 INSERT INTO [dbo].[HIEUXE]
           ([MaHX]
           ,[TenHX]
           ,[NhanSua])
     VALUES
           ('HX000010'
           ,'Mecerdes-Benz'
           ,N'có')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_XE]
           ([MaTTXe]
           ,[MaKH]
           ,[MaHX]
           ,[BienSo])
     VALUES
           ('TT000001'
           ,'KH000001'
           ,'HX000003'
           ,'81A-044.54')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[PHIEUTIEPNHAN]
           ([MaPhieuTN]
           ,[MaTTXe]
           ,[NgayNhan])
     VALUES
           ('MP000001'
           ,'TT000001'
           ,convert(datetime,'5/20/2018 00:00:00'))
GO

INSERT INTO [dbo].[PHIEUTIEPNHAN]
           ([MaPhieuTN]
           ,[MaTTXe]
           ,[NgayNhan])
     VALUES
           ('MP000002'
           ,'TT000002'
           ,convert(datetime,'5/21/2018 00:00:00'))
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[PHUTUNG]
           ([MaPhuTung]
           ,[TenPhuTung]
           ,[SoLuongCon]
           ,[DonGia])
     VALUES
           ('PT000001'
           ,'A'
           ,14
           ,1000000)
GO




INSERT INTO [dbo].[PHUTUNG]
           ([MaPhuTung]
           ,[TenPhuTung]
           ,[SoLuongCon]
           ,[DonGia])
     VALUES
           ('PT000002'
           ,'B'
           ,15
           ,2000000)
GO

INSERT INTO [dbo].[PHUTUNG]
           ([MaPhuTung]
           ,[TenPhuTung]
           ,[SoLuongCon]
           ,[DonGia])
     VALUES
           ('PT000003'
           ,'C'
           ,30
           ,3000000)
GO

INSERT INTO [dbo].[PHUTUNG]
           ([MaPhuTung]
           ,[TenPhuTung]
           ,[SoLuongCon]
           ,[DonGia])
     VALUES
           ('PT000004'
           ,'D'
           ,20
           ,4000000)
GO

INSERT INTO [dbo].[LOAITIENCONG]
           ([MaTienCong]
           ,[TenLoaiTienCong]
           ,[MucTien])
     VALUES
           ('TC000001'
           ,N'Loại 1'
           ,100000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[LOAITIENCONG]
           ([MaTienCong]
           ,[TenLoaiTienCong]
           ,[MucTien])
     VALUES
           ('TC000002'
           ,N'Loại 2'
           ,200000)
GO

INSERT INTO [dbo].[LOAITIENCONG]
           ([MaTienCong]
           ,[TenLoaiTienCong]
           ,[MucTien])
     VALUES
           ('TC000003'
           ,N'Loại 3'
           ,300000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[PHIEUSUACHUA]
           ([MaPhieuSC]
           ,[MaPhieuTN]
           ,[NgaySC])
     VALUES
           ('SC000001'
           ,'MP000001'
           ,convert(datetime,'5/20/2018 00:00:00'))
GO



INSERT INTO [dbo].[PHIEUSUACHUA]
           ([MaPhieuSC]
           ,[MaPhieuTN]
           ,[NgaySC])
     VALUES
           ('SC000002'
           ,'MP000002'
           ,convert(datetime,'5/21/2018 00:00:00'))
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_PHIEUSUACHUA]
           ([MaTTPhieuSuaChua]
           ,[MaPhieuSC]
           ,[MaPhuTung]
           ,[NoiDung]
           ,[SoLuong]
           ,[MaTienCong])
     VALUES
           ('TS000001'
           ,'SC000001'
           ,'PT000001'
           ,N'Thay phanh'
           ,1
           ,'TC000001')
GO



INSERT INTO [dbo].[TT_PHIEUSUACHUA]
           ([MaTTPhieuSuaChua]
           ,[MaPhieuSC]
           ,[MaPhuTung]
           ,[NoiDung]
           ,[SoLuong]
           ,[MaTienCong])
     VALUES
           ('TS000002'
           ,'SC000002'
           ,'PT000001'
           ,N'Thay gương'
           ,1
           ,'TC000002')
GO

INSERT INTO [dbo].[TT_PHIEUSUACHUA]
           ([MaTTPhieuSuaChua]
           ,[MaPhieuSC]
           ,[MaPhuTung]
           ,[NoiDung]
           ,[SoLuong]
           ,[MaTienCong])
     VALUES
           ('TS000003'
           ,'SC000002'
           ,'PT000002'
           ,N'Thay lốp'
           ,2
           ,'TC000001')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[PHIEUTHUTIEN]
           ([MaPhieuThuTien]
           ,[MaPhieuTN]
           ,[NgayThuTien]
           ,[SoTienThu])
     VALUES
           ('MT000001'
           ,'MP000001'
           ,convert(datetime,'5/20/2018 00:00:00')
           ,8000)
GO

INSERT INTO [dbo].[PHIEUTHUTIEN]
           ([MaPhieuThuTien]
           ,[MaPhieuTN]
           ,[NgayThuTien]
           ,[SoTienThu])
     VALUES
           ('MT000002'
           ,'MP000002'
           ,convert(datetime,'5/21/2018 00:00:00')
           ,1200000)
GO

USE [QLGARA]
GO



INSERT INTO [dbo].[THAMSO]
           ([SoXeSuaChua])
     VALUES
           (30)
GO

USE [QLGARA]
GO



INSERT INTO [dbo].[NHAPPHUTUNG]
           ([MaNhapPhuTung]
           ,[NgayNhap]
           ,[TongTienNhap])
     VALUES
           ('NP000001'
           ,convert(datetime,'5/10/2018 00:00:00')
           ,10000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[NHAPPHUTUNG]
           ([MaNhapPhuTung]
           ,[NgayNhap]
           ,[TongTienNhap])
     VALUES
           ('NP000002'
           ,convert(datetime,'5/15/2018 00:00:00')
           ,2000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_NHAPPHUTUNG]
           ([MaTTNhapPhuTung]
           ,[MaNhapPhuTung]
           ,[MaPhuTung]
           ,[SoLuongNhap]
           ,[DonGiaNhap])
     VALUES
           ('NT000001'
           ,'NP000001'
           ,'PT000001'
           ,2
           ,1000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_NHAPPHUTUNG]
           ([MaTTNhapPhuTung]
           ,[MaNhapPhuTung]
           ,[MaPhuTung]
           ,[SoLuongNhap]
           ,[DonGiaNhap])
     VALUES
           ('NT000002'
           ,'NP000001'
           ,'PT000002'
           ,3
           ,2000000)
GO

INSERT INTO [dbo].[TT_NHAPPHUTUNG]
           ([MaTTNhapPhuTung]
           ,[MaNhapPhuTung]
           ,[MaPhuTung]
           ,[SoLuongNhap]
           ,[DonGiaNhap])
     VALUES
           ('NT000003'
           ,'NP000001'
           ,'PT000003'
           ,1
           ,2000000)
GO

INSERT INTO [dbo].[TT_NHAPPHUTUNG]
           ([MaTTNhapPhuTung]
           ,[MaNhapPhuTung]
           ,[MaPhuTung]
           ,[SoLuongNhap]
           ,[DonGiaNhap])
     VALUES
           ('NT000004'
           ,'NP000002'
           ,'PT000002'
           ,1
           ,2000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[NHAPPHATSINH]
           ([MaPhieuNhapPS]
           ,[NgayNhapPS]
           ,[TongTienPS])
     VALUES
           ('PS000001'
           ,convert(datetime,'5/15/2018 00:00:00')
           ,20000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_PHATSINH]
           ([MaTTPhatSinh]
           ,[MaPhieuNhapPS]
           ,[MaPhuTung]
           ,[SoLuongPS]
           ,[DonGiaPS])
     VALUES
           ('TP000001'
           ,'PS000001'
           ,'PT000001'
           ,5
           ,1000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_PHATSINH]
           ([MaTTPhatSinh]
           ,[MaPhieuNhapPS]
           ,[MaPhuTung]
           ,[SoLuongPS]
           ,[DonGiaPS])
     VALUES
           ('TP000002'
           ,'PS000001'
           ,'PT000002'
           ,10
           ,1000000)
GO

INSERT INTO [dbo].[TT_PHATSINH]
           ([MaTTPhatSinh]
           ,[MaPhieuNhapPS]
           ,[MaPhuTung]
           ,[SoLuongPS]
           ,[DonGiaPS])
     VALUES
           ('TP000003'
           ,'PS000001'
           ,'PT000003'
           ,5
           ,1000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[DOANHSO]
           ([MaDoanhSo]
           ,[Thang]
           ,[TongDoanhThu])
     VALUES
           ('DS000001'
           ,5
           ,15000000)
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_DOANHSO]
           ([MaTTDoanhSo]
           ,[HieuXe]
           ,[SoLuotSua]
           ,[ThanhTien]
           ,[TiLe]
           ,[MaDoanhSo])
     VALUES
           ('TD000001'
           ,'Ford'
           ,2
           ,3000000
           ,0.16
           ,'DS000001')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[TT_DOANHSO]
           ([MaTTDoanhSo]
           ,[HieuXe]
           ,[SoLuotSua]
           ,[ThanhTien]
           ,[TiLe]
           ,[MaDoanhSo])
     VALUES
           ('TD000002'
           ,'Chevrolet'
           ,3
           ,4000000
           ,0.25
           ,'DS000001')
GO

INSERT INTO [dbo].[TT_DOANHSO]
           ([MaTTDoanhSo]
           ,[HieuXe]
           ,[SoLuotSua]
           ,[ThanhTien]
           ,[TiLe]
           ,[MaDoanhSo])
     VALUES
           ('TD000003'
           ,'Toyota'
           ,7
           ,8000000
           ,0.58
           ,'DS000001')
GO

USE [QLGARA]
GO

INSERT INTO [dbo].[BAOCAOTON]
           ([MaBaoCaoTon]
           ,[Thang])
     VALUES
           ('CT000001'
           ,5)
GO


USE [QLGARA]
GO

INSERT INTO [dbo].[TT_BAOCAOTON]
           ([MaTTBaoCaoTon]
           ,[TenPhuTung]
           ,[TonDau]
           ,[PhatSinh]
           ,[TonCuoi]
           ,[MaBaoCaoTon])
     VALUES
           ('TX000001'
           ,'A'
           ,0
           ,0
           ,0
           ,'CT000001')
GO



INSERT INTO [dbo].[TT_BAOCAOTON]
           ([MaTTBaoCaoTon]
           ,[TenPhuTung]
           ,[TonDau]
           ,[PhatSinh]
           ,[TonCuoi]
           ,[MaBaoCaoTon])
     VALUES
           ('TX000002'
           ,'B'
           ,0
           ,0
           ,0
           ,'CT000001')
GO



INSERT INTO [dbo].[TT_BAOCAOTON]
           ([MaTTBaoCaoTon]
           ,[TenPhuTung]
           ,[TonDau]
           ,[PhatSinh]
           ,[TonCuoi]
           ,[MaBaoCaoTon])
     VALUES
           ('TX000003'
           ,'C'
           ,0
           ,0
           ,0
           ,'CT000001')
GO


INSERT INTO [dbo].[TT_BAOCAOTON]
           ([MaTTBaoCaoTon]
           ,[TenPhuTung]
           ,[TonDau]
           ,[PhatSinh]
           ,[TonCuoi]
           ,[MaBaoCaoTon])
     VALUES
           ('TX000004'
           ,'D'
           ,0
           ,0
           ,0
           ,'CT000001')
GO