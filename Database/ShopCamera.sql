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
	FOREIGN KEY(MaTL) REFERENCES TheLoai(MaTL)
)
GO

CREATE TABLE NhanVien(
	MaNV INT IDENTITY(1000000, 1) NOT NULL PRIMARY KEY,
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
	DiaChi NVARCHAR(255),
	Sdt NVARCHAR(10)
)
GO

CREATE TABLE HoaDon(
	MaHD INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	MaKH INT,
	MaNV INT,
	DiaChiShip NVARCHAR(60),
	FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH),
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO

CREATE TABLE ChiTietHoaDon(
	MaHD INT,
	MaSP INT,
	SoLuong SMALLINT
	PRIMARY KEY (MaHD, MaSP),
	FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
)
GO
--Cụm thêm thông tin cho CSDL ==================================================================================================

INSERT INTO KhachHang (TenLienHe, DiaChi, Sdt)
VALUES 
    (N'Lê Thị Thanh An', N'An Giang', '0123456789'),
    (N'Nguyễn Phương Anh', N'Bà Rịa – Vũng Tàu', '0234567890'),
    (N'Phạm Giang Linh', N'Bà Rịa – Vũng Tàu', '0345678901'),
    (N'Bùi Thị Khánh Linh', N'Bạc Liêu', '0456789012'),
    (N'Đinh Hoàng Minh', N'Bắc Giang', '0567890123'),
    (N'Tạ Thị Ngọc Minh', N'Bắc Kạn', '0678901234'),
    (N'Tạ Thị Khánh Ngọc', N'Bắc Kạn', '0789012345'),
    (N'Lê Phương Thảo', N'Bắc Ninh', '0890123456'),
    (N'Phạm Hoài Thương', N'Bến Tre', '0901234567'),
    (N'Phạm Nhật Tiến', N'Bình Dương', '0912345678');

	INSERT INTO SanPham (TenSP, MaTL, DonGiaSP, GiamGia, TonKhoSP, NhanSanXuat)
VALUES 
    (N'Camera IP 360 Độ 2MP Xiaomi Mi Home C200', 1, 550000, 1, 50, N'Xiaomi'),
    (N'Camera IP 360 Độ 2MP EZVIZ H6C', 1, 650000, 1, 30, N'EZVIZ'),
    (N'Camera IP 360 Độ 2MP IMOU Ranger 2C TA22CP', 1, 750000, 1, 20, N'Trung Quốc'),
    (N'Máy ảnh Canon EOS M50 Mark II', 2, 14990000, 1, 40, N'Canon'),
    (N'Máy ảnh Canon EOS R5', 2, 149990000, 1, 15, N'Canon'),
    (N'Canon 600D', 2, 5490000, 1, 60, N'Canon'),
    (N'Máy ảnh Nikon Z6 II', 2, 47480000, 1, 25, N'Nikon'),
    (N'Nikon D3500', 2, 10800000, 1, 35, N'Nikon'),
    (N'Máy ảnh Nikon Z7', 2, 54480000, 1, 45, N'Nikon'),
    (N'Máy ảnh Nikon Z30', 2, 15500000, 1, 18, N'Nikon');

	INSERT INTO TheLoai (TenTL, MoTaTL)
VALUES 
    (N'Camera an ninh', N'Mô tả thể loại 1'),
    (N'Camera chụp ảnh', N'Mô tả thể loại 2');

	INSERT INTO NhanVien (PassNV, HoLotNV, TenNV, DiaChiNV, SdtNV)
VALUES 
    ('0000', N'Nguyễn Lâm Quốc', N'Bảo', N'Trà Vinh', '0123456789'),
    ('1111', N'Đinh Lê Bảo', 'Duy', N'Trà Vinh', '0987654321'),
    ('2222', N'Nguyễn Văn', N'Vửng', N'Trà Vinh', '0123987654');

-- Thêm 5 hóa đơn
INSERT INTO HoaDon (MaKH, MaNV, DiaChiShip)
VALUES 
    (1, 1000000, N'Hà Nội');

-- Thêm chi tiết hóa đơn cho 5 hóa đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong)
VALUES
    (4, 6, 2);

-- Cụm xử lý thử nghệm ================================================================
SELECT
    SP.MaSP,
    SP.TenSP,
    SP.NhanSanXuat,
    SUM(CTHD.SoLuong) AS SoLuongBan
FROM
    SanPham SP
JOIN
    ChiTietHoaDon CTHD ON SP.MaSP = CTHD.MaSP
GROUP BY
    SP.MaSP, SP.TenSP, SP.NhanSanXuat
ORDER BY
    SoLuongBan DESC;

SELECT KH.TenLienHe, KH.DiaChi, KH.Sdt, SP.TenSP, TL.TenTL, NV.TenNV, CTHD.SoLuong, SP.DonGiaSP, SP.TonKhoSP, HD.MaHD, SP.MaSP, KH.MaKH, NV.MaNV, TL.MaTL
FROM HoaDon as HD, SanPham as SP, ChiTietHoaDon as CTHD, KhachHang as KH, NhanVien as NV, TheLoai as TL
WHERE HD.MaHD = CTHD.MaHD AND HD.MaKH = KH.MaKH AND HD.MaNV = NV.MaNV AND CTHD.MaSP = SP.MaSP AND SP.MaTL = TL.MaTL
ORDER BY HD.MaHD DESC
