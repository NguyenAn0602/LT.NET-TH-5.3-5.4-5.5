CREATE DATABASE HotelDB;
GO
USE HotelDB;
GO

-- 1. Bảng Phòng
CREATE TABLE Phong (
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50) NOT NULL, -- Đơn, Đôi, VIP
    GiaTheoGio DECIMAL(18,2) NOT NULL,
    TrangThai NVARCHAR(30) DEFAULT N'Trống' -- 'Trống', 'Đang ở', 'Đang dọn dẹp'
);
GO

-- 2. Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);
GO

-- 3. Bảng Dịch vụ
CREATE TABLE DichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL
);
GO

-- 4. Bảng Phiếu đặt phòng & Sử dụng dịch vụ
CREATE TABLE PhieuDatPhong (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) FOREIGN KEY REFERENCES Phong(SoPhong),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    NgayNhanPhong DATETIME DEFAULT GETDATE(),
    NgayTraPhong DATETIME NULL,
    TongTienThanhToan DECIMAL(18,2) DEFAULT 0
);
GO

CREATE TABLE SuDungDichVu (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuDatPhong(MaPhieu),
    MaDV INT FOREIGN KEY REFERENCES DichVu(MaDV),
    SoLuong INT NOT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (MaPhieu, MaDV, ThoiGian)
);
GO

-- Chèn dữ liệu mẫu ban đầu
INSERT INTO Phong (SoPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES
('P101', N'Đơn', 80000, N'Trống'),
('P102', N'Đơn', 80000, N'Trống'),
('P201', N'Đôi', 120000, N'Trống'),
('P202', N'Đôi', 120000, N'Trống'),
('P301', N'VIP', 200000, N'Trống');

INSERT INTO DichVu (TenDV, DonGia) VALUES
(N'Nước khoáng Lavie', 15000),
(N'Bò húc / Nước ngọt', 25000),
(N'Mì ly xúc xích', 30000),
(N'Giặt ủi quần áo', 50000);

INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES
(N'Nguyễn Văn An', '001202000123', '0912345678');
GO