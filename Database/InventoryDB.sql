CREATE DATABASE InventoryDB;
GO
USE InventoryDB;
GO

-- 1. B?ng Nhà cung c?p
CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(255)
);
GO

-- 2. B?ng V?t t?
CREATE TABLE VatTu (
    MaVatTu VARCHAR(20) PRIMARY KEY,
    TenVatTu NVARCHAR(150) NOT NULL,
    DVT NVARCHAR(20),
    SoLuongTon DECIMAL(18,2) DEFAULT 0 CHECK (SoLuongTon >= 0)
);
GO

-- 3. B?ng Phi?u nh?p / xu?t kho
CREATE TABLE PhieuKho (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    LoaiPhieu NVARCHAR(10) NOT NULL CHECK (LoaiPhieu IN (N'NHAP', N'XUAT')),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNCC INT NULL FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    TongTien DECIMAL(18,2) DEFAULT 0
);
GO

-- 4. B?ng Chi ti?t phi?u kho
CREATE TABLE ChiTietPhieuKho (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuKho(MaPhieu),
    MaVatTu VARCHAR(20) FOREIGN KEY REFERENCES VatTu(MaVatTu),
    SoLuong DECIMAL(18,2) NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaPhieu, MaVatTu)
);
GO

-- D? li?u m?u ban ??u
INSERT INTO NhaCungCap (TenNCC, DienThoai, DiaChi) VALUES
(N'Công ty TNHH Thép Vi?t Nh?t', '0901234567', N'Hà N?i'),
(N'T?ng kho Xi M?ng Hà Tiên', '0912345678', N'TP. H? Chí Minh'),
(N'??i lý G?ch Men Viglacera', '0987654321', N'?à N?ng');

INSERT INTO VatTu (MaVatTu, TenVatTu, DVT, SoLuongTon) VALUES
('VT01', N'Xi m?ng PCB40', N'Bao', 100),
('VT02', N'Thép phi 10', N'Cây', 50),
('VT03', N'Cát vàng xây d?ng', N'Kh?i', 15),
('VT04', N'G?ch ?ng 4 l?', N'Viên', 2000),
('VT05', N'S?n lót ch?ng ki?m', N'Thùng', 5);
GO