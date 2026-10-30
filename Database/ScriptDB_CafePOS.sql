CREATE DATABASE CafePOSDB;
GO
USE CafePOSDB;
GO

-- 1. Bảng Bàn ăn
CREATE TABLE BanAn (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Trống' -- 'Trống' hoặc 'Có khách'
);
GO

-- 2. Bảng Danh mục món
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);
GO

-- 3. Bảng Món ăn
CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
    DonGia DECIMAL(18,2) NOT NULL
);
GO

-- 4. Bảng Hóa đơn & Chi tiết hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT FOREIGN KEY REFERENCES BanAn(MaBan),
    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);
GO

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaMon INT FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHoaDon, MaMon)
);
GO

-- Chèn dữ liệu mẫu
INSERT INTO BanAn (TenBan, TrangThai) VALUES 
(N'Bàn 01', N'Trống'), (N'Bàn 02', N'Trống'), (N'Bàn 03', N'Trống'),
(N'Bàn 04', N'Trống'), (N'Bàn 05', N'Trống'), (N'Bàn 06', N'Trống');

INSERT INTO DanhMuc (TenDanhMuc) VALUES 
(N'Cà phê'), (N'Trà sữa'), (N'Đồ ăn nhẹ');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES 
(N'Cà phê đen', 1, 25000),
(N'Cà phê sữa', 1, 30000),
(N'Bạc xỉu', 1, 35000),
(N'Trà sữa trân châu', 2, 40000),
(N'Trà đào cam sả', 2, 45000),
(N'Hướng dương', 3, 20000),
(N'Khô bò', 3, 50000);
GO