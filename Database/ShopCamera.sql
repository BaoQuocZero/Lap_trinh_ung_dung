CREATE DATABASE ShopCamera
ON
(	NAME = 'ShopCamera_data',
	FILENAME = 'E:\Code\Lap_trinh_ung_dung\Database\ShopCamera_data.mdf'
	--SIZE = 10MB,
	--MAXSIZE = 100MB,
	--FILEGROWTH = 5MB
)
LOG ON
(	NAME = 'ShopCamera_log',
	FILENAME = 'E:\Code\Lap_trinh_ung_dung\Database\ShopCamera_log.ldf'
	--SIZE = 5MB,
	--MAXSIZE = 50MB,
	--FILEGROWTH = 5MB
)
GO
USE ShopCamera;
GO
CREATE TABLE TheLoai(
	MaTL INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenTL NVARCHAR(100) NOT NULL,
	MoTaTL NTEXT,
	HinhAnhTL IMAGE
)
GO
CREATE TABLE NhaCungCap(
	MaNCC INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenCongTyNCC NVARCHAR(40) NOT NULL,
	TenLienHeNCC NVARCHAR(30),
	ThongTinLienLacNCC NVARCHAR(30),
	DiaChiNCC NVARCHAR(60),
	ThanhPho NVARCHAR(30),
	Region NVARCHAR(15),
	MaBuuDien NVARCHAR(10),
	QuocGia NVARCHAR(15),
	Sdt NVARCHAR(24),
	Fax NVARCHAR(24),
	WebSite NTEXT
)
/*
GO
SELECT CONSTRAINT_NAME 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE TABLE_NAME = 'NhaCungCap' AND CONSTRAINT_TYPE = 'CHECK';
GO
ALTER TABLE NhaCungCap
DROP CONSTRAINT CK__NhaCungCap__Sdt__398D8EEE;
GO
ALTER TABLE NhaCungCap
ADD CONSTRAINT CK__NhaCungCap__Sdt__398D8EEE CHECK (LEN(Sdt) = 10 AND ISNUMERIC(Sdt) = 1);
*/
GO
CREATE TABLE SanPham(
	MaSP INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenSP NVARCHAR(255) NOT NULL,
	MaNCC INT,
	MaTL INT,
	SoLuongTrenDonViSP NVARCHAR (50),
	DonGiaSP MONEY,
	TonKhoSP SMALLINT,
	DatTruocSP SMALLINT,
	TonKhoToiThieuSP SMALLINT,
	NgungKinhDoanhSP BIT NOT NULL CHECK (NgungKinhDoanhSP IN (0, 1))
	FOREIGN KEY(MaNCC) REFERENCES NhaCungCap(MaNCC),
	FOREIGN KEY(MaTL) REFERENCES TheLoai(MaTL)
)
GO
CREATE TABLE NhanVien(
	MaNV INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	HoLotNV NVARCHAR(20) NOT NULL,
	TenNV NVARCHAR(10) NOT NULL,
	ChucVu NVARCHAR(30),
	GioiTinh NVARCHAR(4),
	NgaySinh DATETIME CHECK( NgaySinh <= GETDATE()),
	NgayVaoLam DATETIME CHECK( NgayVaoLam <= GETDATE()),
	DiaChiNV NVARCHAR(60),
	ThanhPho NVARCHAR(15),
	Region NVARCHAR(15),
	MaBuuDien NVARCHAR(10),
	QuocGia NVARCHAR(15),
	SdtNV NVARCHAR(24),
	AnhNV IMAGE,
	GhiChu NTEXT,
)
/*
GO
SELECT CONSTRAINT_NAME 
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
WHERE TABLE_NAME = 'NhanVien' AND CONSTRAINT_TYPE = 'CHECK';
GO
ALTER TABLE NhanVien
ADD CONSTRAINT SdtNV CHECK (LEN(SdtNV) = 10 AND ISNUMERIC(SdtNV) = 1);
*/
GO
CREATE TABLE KhachHang(
	MaKH INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenCongTy NVARCHAR(40),
	TenLienHe NVARCHAR(30) NOT NULL,
	ThongTinLienLac NVARCHAR(30),
	DiaChi NVARCHAR(60),
	ThanhPho NVARCHAR(30),
	Region NVARCHAR(15),
	MaBuuDien NVARCHAR(10),
	QuocGia NVARCHAR(15),
	Sdt NVARCHAR(24),
	Fax NVARCHAR(24),
)
/*
GO
ALTER TABLE KhachHang
DROP CONSTRAINT CK__KhachHang__Sdt__44FF419A;
GO
ALTER TABLE KhachHang
ADD CONSTRAINT CK__KhachHang__Sdt__4CA06362 CHECK (LEN(Sdt) = 10 AND ISNUMERIC(Sdt) = 1);
*/
GO
CREATE TABLE Shippers(
	MaShipper INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenCongTy NVARCHAR(40),
	Sdt NVARCHAR(24),
)
GO
CREATE TABLE HoaDon(
	MaHD INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	MaKH INT,
	MaNV INT,
	NgayDatHang DATETIME CHECK( NgayDatHang <= GETDATE()),
	NgayNhanHangDuKien DATETIME,
	NgayNhanHangThucTe DATETIME,
	ShipVia INT,
	PhiShip MONEY,
	CongTyVanChuyen NVARCHAR(40),
	DiaChiShip NVARCHAR(60),
	TinhThanh NVARCHAR(30),
	Region NVARCHAR(15),
	MaBuuDien NVARCHAR(10),
	QuocGia NVARCHAR(15)
	FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
	FOREIGN KEY(ShipVia) REFERENCES Shippers(MaShipper)
)
GO
CREATE TABLE ChiTietHoaDon(
	MaHD INT,
	MaSP INT,
	SoLuong SMALLINT,
	GiamGia REAL --tương đương với FLOAT(24)
	PRIMARY KEY (MaHD, MaSP)
	FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
)

INSERT INTO [dbo].[NhanVien] (
      [HoLotNV]
      ,[TenNV]
      ,[ChucVu]
      ,[GioiTinh]
      ,[NgaySinh]
      ,[NgayVaoLam]
      ,[DiaChiNV]
      ,[ThanhPho]
      ,[Region]
      ,[MaBuuDien]
      ,[QuocGia]
      ,[SdtNV]
      ,[AnhNV]
      ,[GhiChu]
)
VALUES
	(N'Nguyễn Lâm Quốc', N'Bảo', N'Quản lý', N'Nam', 2003-01-06, 2023-10-29, N'Tiểu Cần, Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0123456789', null, null),
	(N'Nguyễn Văn', N'Vửng', N'Tiếp Thị', N'Nam', 2003-01-01, 2023-10-29, N'Châu Thành, Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0347482012', null, null),
	(N'Đinh Lê Bảo', N'Duy', N'Tiếp Thị', N'Nam', 2003-01-01, 2023-10-29, N'Châu Thành, Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0987654321', null, null);

INSERT INTO [dbo].[KhachHang] (
      [TenCongTy]
      ,[TenLienHe]
      ,[ThongTinLienLac]
      ,[DiaChi]
      ,[ThanhPho]
      ,[Region]
      ,[MaBuuDien]
      ,[QuocGia]
      ,[Sdt]
      ,[Fax]
)
VALUES
	(null, N'Hồ Hoàng Phúc', N'Đại học Trà Vinh', N'Tiểu Cần, Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0327434821', null),
	(null, N'Nguyễn Tín Thành', N'Đại học Trà Vinh', N'Thành phố Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0395890398', null),
	(null, N'Huỳnh Nhựt Huy', N'Đại học Trà Vinh', N'Thành phố Trà Vinh', N'Trà Vinh', 0294, 87000, N'Việt Nam', '0363507787', null);

INSERT INTO [dbo].[NhaCungCap](
	  [TenCongTyNCC]
      ,[TenLienHeNCC]
      ,[ThongTinLienLacNCC]
      ,[DiaChiNCC]
      ,[ThanhPho]
      ,[QuocGia]
      ,[Sdt]
      ,[WebSite]
)
VALUES
	(N'Sony', N'Yoshida Kenichiro', N'Minato, Tokyo, Nhật Bản', N'Minato, Tokyo, Nhật Bản', N'Tokyo', N'Nhật Bản', '02838222227', 'https://www.sony.com.vn/microsite/companyoutline'),
	(N'Nikon', N'Michio Kariya', N'Tokyo, Nhật Bản', N'Tokyo, Nhật Bản', N'Tokyo', N'Nhật Bản', '02838442008', 'https://www.nikon.com/'),
	(N'Camon', N'Mitarai Fujio', N'Ōta, Tokyo', N'Ōta, Tokyo', N'Tokyo', N'Nhật Bản', '02438812111', 'http://www.canon.com.vn/'),
	(N'Fujifilm', N'Teiichi Goto', N'Minato, Tôkyô, Nhật Bản', N'Minato, Tôkyô, Nhật Bản', N'Tokyo', N'Nhật Bản', ' 0243943-0321', 'https://www.nikon.com/'),
	(N'Leica', N'Andreas Kaufmann', N'Wetzlar, Đức', N'Wetzlar, Đức', N'Wetzlar', N'Đức', '0945488948', 'http://www.leica-camera.com/')

INSERT INTO [dbo].[TheLoai](
      [TenTL]
      ,[MoTaTL]
      ,[HinhAnhTL]
)
VALUES
	(N'Máy ảnh', N'Máy ảnh hay máy chụp hình là một dụng cụ dùng để thu ảnh thành một ảnh tĩnh hay thành một loạt các ảnh chuyển động', null)

INSERT INTO [dbo].[SanPham](
      [TenSP]
      ,[MaNCC]
      ,[MaTL]
      ,[SoLuongTrenDonViSP]
      ,[DonGiaSP]
      ,[TonKhoSP]
      ,[DatTruocSP]
      ,[TonKhoToiThieuSP]
      ,[NgungKinhDoanhSP]
)
VALUES
	(N'Sony a6000', 1, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 7000000, 12, 0, 1, 0),
	(N'Sony a6500', 1, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 25000000, 10, 0, 1, 0),
	(N'Nikon D5200', 2, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 4000000, 20, 0, 1, 0),
	(N'Nikon Z9', 2, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 130000000, 5, 0, 1, 0),
	(N'Canon 60D', 3, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 4000000, 20, 0, 1, 0),
	(N'Camon 6D', 3, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 10000000, 22, 0, 1, 0),
	(N'Fujifilm XT100', 4, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 8000000, 22, 0, 1, 0),
	(N'Fujifilm XT5', 4, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 8000000, 17, 0, 1, 0),
	(N'Leica M6', 5, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 65000000, 10, 0, 1, 0),
	(N'Leica M11', 5, 1, N'1xCamera, lens kit, pin, thẻ nhớ, túi đựng', 185000000, 5, 0, 1, 0)