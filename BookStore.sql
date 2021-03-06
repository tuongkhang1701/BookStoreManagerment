USE [master]
GO
/****** Object:  Database [BanSachQuaMang]    Script Date: 06/10/2021 1:05:05 PM ******/
CREATE DATABASE [BanSachQuaMang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanSachQuaMang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BanSachQuaMang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BanSachQuaMang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BanSachQuaMang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BanSachQuaMang] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanSachQuaMang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BanSachQuaMang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BanSachQuaMang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanSachQuaMang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanSachQuaMang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BanSachQuaMang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanSachQuaMang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BanSachQuaMang] SET  MULTI_USER 
GO
ALTER DATABASE [BanSachQuaMang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanSachQuaMang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanSachQuaMang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanSachQuaMang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BanSachQuaMang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BanSachQuaMang] SET QUERY_STORE = OFF
GO
USE [BanSachQuaMang]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[userName] [nvarchar](100) NOT NULL,
	[displayName] [nvarchar](100) NOT NULL,
	[passWord] [nvarchar](100) NOT NULL,
	[type] [int] NOT NULL,
 CONSTRAINT [PK__Account__66DCF95DA2CD9C56] PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[Type] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongTyPhatHanh]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTyPhatHanh](
	[IDCongTy] [int] IDENTITY(1,1) NOT NULL,
	[TenCongTy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__CongTyPh__3E616C9019AE74D4] PRIMARY KEY CLUSTERED 
(
	[IDCongTy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IDGioHang] [int] IDENTITY(1,1) NOT NULL,
	[IDSach] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IDGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[NgayGiaoHang] [date] NULL,
	[IDTT] [int] NOT NULL,
	[username] [nvarchar](100) NULL,
 CONSTRAINT [PK__HoaDon__5B896F49EBC3E315] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonChiTiet]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChiTiet](
	[IDHDCT] [int] IDENTITY(1,1) NOT NULL,
	[IDSach] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[IDHoaDon] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonChiTiet] PRIMARY KEY CLUSTERED 
(
	[IDHDCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCC]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCC](
	[IDNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__NXB__945B98FB73C6D671] PRIMARY KEY CLUSTERED 
(
	[IDNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[IDSach] [int] IDENTITY(1,1) NOT NULL,
	[TenSach] [nvarchar](100) NOT NULL,
	[DonGia] [decimal](18, 0) NOT NULL,
	[SoTrang] [int] NOT NULL,
	[IDCongTy] [int] NOT NULL,
	[IDNCC] [int] NOT NULL,
	[IDTG] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK__Sach__C6F2F76B0C69D383] PRIMARY KEY CLUSTERED 
(
	[IDSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[IDTG] [int] IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__TacGia__B87C3A8FCFE9BF3C] PRIMARY KEY CLUSTERED 
(
	[IDTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[IDTT] [int] IDENTITY(1,1) NOT NULL,
	[CachTT] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[IDTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_displayName]  DEFAULT (N'Khách hàng') FOR [displayName]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_passWord]  DEFAULT ((1)) FOR [passWord]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_type]  DEFAULT ((0)) FOR [type]
GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (N'client') FOR [Name]
GO
ALTER TABLE [dbo].[HoaDonChiTiet] ADD  CONSTRAINT [DF_HoaDonChiTiet_SoLuong]  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_SoLuong]  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([type])
REFERENCES [dbo].[AccountType] ([Type])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_Account]
GO
ALTER TABLE [dbo].[GioHang]  WITH CHECK ADD  CONSTRAINT [FK_GioHang_Sach] FOREIGN KEY([IDSach])
REFERENCES [dbo].[Sach] ([IDSach])
GO
ALTER TABLE [dbo].[GioHang] CHECK CONSTRAINT [FK_GioHang_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Account] FOREIGN KEY([username])
REFERENCES [dbo].[Account] ([userName])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Account]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_ThanhToan] FOREIGN KEY([IDTT])
REFERENCES [dbo].[ThanhToan] ([IDTT])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_ThanhToan]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([IDHoaDon])
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_HoaDon]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_CongTyPhatHanh] FOREIGN KEY([IDCongTy])
REFERENCES [dbo].[CongTyPhatHanh] ([IDCongTy])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_CongTyPhatHanh]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NCC] FOREIGN KEY([IDNCC])
REFERENCES [dbo].[NCC] ([IDNCC])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NCC]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([IDTG])
REFERENCES [dbo].[TacGia] ([IDTG])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteAccount]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DeleteAccount]
@username nvarchar(100)
as
begin
	delete HoaDonChiTiet where userName = @username

	delete HoaDon where username = @username
	
	DELETE GioHang where userName = @username
	
	delete Account where userName = @username
end
GO
/****** Object:  StoredProcedure [dbo].[USP_deleteCTPH]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_deleteCTPH]
@idCTPH int
as
begin
	DECLARE @idSach int
	select @idSach = IDSach from Sach where IDCongTy = @idCTPH
	Delete GioHang where IDSach = @idSach

	Delete Sach where IDCongTy = @idCTPH

	Delete CongTyPhatHanh where IDCongTy = @idCTPH 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_deleteNCC]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[USP_deleteNCC]
@idNCC int
as
begin
	DECLARE @idSach int
	select @idSach = IDSach from Sach where IDNCC = @idNCC
	Delete GioHang where IDSach = @idSach

	Delete Sach where IDNCC = @idNCC

	Delete NCC where IDNCC = @idNCC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETETacGia]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DELETETacGia]
@idTG int
as
begin
	DECLARE @idSach int
	select @idSach = IDSach from Sach where IDTG = @idTG
	Delete GioHang where IDSach = @idSach

	Delete Sach where IDTG = @idTG

	Delete TacGia where IDTG = @idTG
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
as
begin
	select * from Account where userName = @userName
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBookList]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetBookList]
as
select * from Sach
GO
/****** Object:  StoredProcedure [dbo].[USP_getDoanhThu]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_getDoanhThu]
@fromDate date, @toDate date
as
begin
	SELECT HD.IDHoaDon ,NgayDat ,SUM(S.DonGia * HDCT.SoLuong) AS Tong, HD.username 
	FROM HoaDon AS HD, HoaDonChiTiet AS HDCT, Sach AS S 
	where HDCT.IDHoaDon = HD.IDHoaDon AND S.IDSach = HDCT.IDSach AND NgayDat between @fromDate and @toDate 
	group by HD.IDHoaDon, NgayDat, HD.username
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBag]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBag]
@idSach int, @soLuong int, @username nvarchar(100)
as
begin
	declare @isExist int
	declare @soLuongSach int

	select @isExist = IDGioHang ,@soLuongSach = SoLuong from GioHang where IDSach = @idSach and userName = @username
	if(@isExist > 0)
	begin
		declare @newBook int = @soLuongSach + @soLuong
		if(@newBook > 0)
			update GioHang set SoLuong = @newBook where IDSach = @idSach and userName = @username
		else
			delete GioHang where userName = @username and IDSach = @idSach
	end
	else
		insert into GioHang ( IDSach, SoLuong, userName ) values (@idSach, @soLuong, @username)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@userName nchar(20), @passWord nchar(20)
as
begin
	select * from Account where userName = @userName and passWord = @passWord
end
GO
/****** Object:  StoredProcedure [dbo].[USP_RemoveBook]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_RemoveBook]
@idSach int, @soLuong int, @username nvarchar(100)
as
begin
	declare @isExist int
	declare @soLuongSach int

	select @isExist = IDGioHang ,@soLuongSach = SoLuong from GioHang where IDSach = @idSach and userName = @username
	if(@isExist > 0)
	begin
		declare @newBook int = abs(@soLuongSach - @soLuong)
		if(@newBook > 0)
			update GioHang set SoLuong = @newBook where IDSach = @idSach and userName = @username
		else
			delete GioHang where userName = @username and IDSach = @idSach
	end
	else
		insert into GioHang ( IDSach, SoLuong, userName ) values (@idSach, @soLuong, @username)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 06/10/2021 1:05:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAccount]
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newPassWord nvarchar(100)
as
begin
	declare @isRightPass int = 0
	select @isRightPass = COUNT(*) from Account where userName = @userName and passWord = @passWord
	if(@isRightPass = 1)
	begin
		if(@newPassWord = null or @newPassWord = '')
		begin
			update Account set displayName = @displayName where userName = @userName
		end
		else
			update Account set displayName = @displayName, passWord = @newPassWord where userName = @userName
	end

end
GO
USE [master]
GO
ALTER DATABASE [BanSachQuaMang] SET  READ_WRITE 
GO
