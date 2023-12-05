CREATE DATABASE ShopCamera
ON
(	NAME = 'ShopCamera_data',
	FILENAME = 'C:\Code\ShopCamera_data.mdf'
	--SIZE = 10MB,
	--MAXSIZE = 100MB,
	--FILEGROWTH = 5MB
)
LOG ON
(	NAME = 'ShopCamera_log',
	FILENAME = 'C:\Code\ShopCamera_data.ldf'
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
	MoTaTL NTEXT
)
GO

CREATE TABLE SanPham(
	MaSP INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenSP NVARCHAR(255) NOT NULL,
	MaTL INT,
	DonGiaSP MONEY,
	GiamGia FLOAT,
	TonKhoSP SMALLINT,
	NhanSanXuat NVARCHAR(255)
	--FOREIGN KEY(MaTL) REFERENCES TheLoai(MaTL)
)
GO

CREATE TABLE NhanVien(
	MaNV INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	PassNV VARCHAR(255),
	HoLotNV NVARCHAR(100) NOT NULL,
	TenNV NVARCHAR(100) NOT NULL,
	DiaChiNV NVARCHAR(255),
	SdtNV NVARCHAR(24)
)
GO

CREATE TABLE KhachHang(
	MaKH INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	TenLienHe NVARCHAR(30) NOT NULL,
	DiaChi NVARCHAR(60),
	Sdt NVARCHAR(24)
)
GO

CREATE TABLE HoaDon(
	MaHD INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	MaKH VARCHAR(255),
	MaNV VARCHAR(255),
	DiaChiShip NVARCHAR(60),
	--FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH),
	--FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO

CREATE TABLE ChiTietHoaDon(
	MaHD INT,
	MaSP INT,
	SoLuong SMALLINT
	PRIMARY KEY (MaHD, MaSP),
	--FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
	--FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
)
GO
--Cụm thêm thông tin cho CSDL ==================================================================================================

INSERT INTO KhachHang (TenLienHe, DiaChi, Sdt)
VALUES 
    (N'Khách Hàng 1', N'Địa Chỉ 1', '0123456789'),
    (N'Khách Hàng 2', N'Địa Chỉ 2', '0234567890'),
    (N'Khách Hàng 3', N'Địa Chỉ 3', '0345678901'),
    (N'Khách Hàng 4', N'Địa Chỉ 4', '0456789012'),
    (N'Khách Hàng 5', N'Địa Chỉ 5', '0567890123'),
    (N'Khách Hàng 6', N'Địa Chỉ 6', '0678901234'),
    (N'Khách Hàng 7', N'Địa Chỉ 7', '0789012345'),
    (N'Khách Hàng 8', N'Địa Chỉ 8', '0890123456'),
    (N'Khách Hàng 9', N'Địa Chỉ 9', '0901234567'),
    (N'Khách Hàng 10', N'Địa Chỉ 10', '0912345678');

	INSERT INTO SanPham (TenSP, MaTL, DonGiaSP, GiamGia, TonKhoSP, NhanSanXuat)
VALUES 
    (N'Sản Phẩm 1', 1, 1000000, 0.1, 50, N'Nhà Sản Xuất 1'),
    (N'Sản Phẩm 2', 2, 1500000, 0.15, 30, N'Nhà Sản Xuất 2'),
    (N'Sản Phẩm 3', 1, 800000, 0.2, 20, N'Nhà Sản Xuất 3'),
    (N'Sản Phẩm 4', 3, 1200000, 0.05, 40, N'Nhà Sản Xuất 4'),
    (N'Sản Phẩm 5', 2, 2000000, 0.25, 15, N'Nhà Sản Xuất 5'),
    (N'Sản Phẩm 6', 1, 900000, 0.1, 60, N'Nhà Sản Xuất 6'),
    (N'Sản Phẩm 7', 3, 1800000, 0.2, 25, N'Nhà Sản Xuất 7'),
    (N'Sản Phẩm 8', 2, 1300000, 0.15, 35, N'Nhà Sản Xuất 8'),
    (N'Sản Phẩm 9', 1, 1100000, 0.1, 45, N'Nhà Sản Xuất 9'),
    (N'Sản Phẩm 10', 3, 1600000, 0.18, 18, N'Nhà Sản Xuất 10');

	INSERT INTO TheLoai (TenTL, MoTaTL)
VALUES 
    (N'Thể Loại 1', N'Mô tả thể loại 1'),
    (N'Thể Loại 2', N'Mô tả thể loại 2'),
    (N'Thể Loại 3', N'Mô tả thể loại 3');

	INSERT INTO NhanVien (PassNV, HoLotNV, TenNV, DiaChiNV, SdtNV)
VALUES 
    ('MatKhau1', 'HoLot1', 'Ten1', 'DiaChi1', '0123456789'),
    ('MatKhau2', 'HoLot2', 'Ten2', 'DiaChi2', '0987654321'),
    ('MatKhau3', 'HoLot3', 'Ten3', 'DiaChi3', '0123987654');

-- Thêm 5 hóa đơn
INSERT INTO HoaDon (MaKH, MaNV, DiaChiShip)
VALUES 
    (1, 1, N'Địa Chỉ 1'),
    (2, 2, N'Địa Chỉ 2'),
    (1, 3, N'Địa Chỉ 1'),
    (2, 3, N'Địa Chỉ 2'),
    (3, 2, N'Địa Chỉ 3');

-- Thêm chi tiết hóa đơn cho 5 hóa đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong)
VALUES
    (1, 1, 2), (1, 3, 1), (1, 5, 3),
    (2, 2, 1), (2, 4, 2), (2, 6, 1),
    (3, 1, 2), (3, 3, 1), (3, 7, 3),
    (4, 2, 1), (4, 4, 2), (4, 8, 1),
    (5, 3, 1), (5, 5, 2), (5, 9, 1);

-- Cụm xử lý thử nghệm ================================================================
SELECT 
    KH.TenLienHe AS [Tên khách hàng], 
    COUNT(CTHD.MaSP) AS [Số sản phẩm đã mua],
    SUM(SP.DonGiaSP * (1 - SP.GiamGia) * CTHD.SoLuong) AS [Số tiền đã chi]
FROM KhachHang AS KH
JOIN HoaDon AS HD ON KH.MaKH = HD.MaKH
JOIN ChiTietHoaDon AS CTHD ON HD.MaHD = CTHD.MaHD
JOIN SanPham AS SP ON CTHD.MaSP = SP.MaSP
GROUP BY KH.TenLienHe;


