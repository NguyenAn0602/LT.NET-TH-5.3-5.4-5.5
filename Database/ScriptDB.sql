-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 30, 2026 lúc 02:25 AM
-- Phiên bản máy phục vụ: 10.11.16-MariaDB
-- Phiên bản PHP: 8.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `cafeposdb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `banan`
--

CREATE TABLE `banan` (
  `MaBan` int(11) NOT NULL,
  `TenBan` varchar(50) NOT NULL,
  `TrangThai` varchar(20) DEFAULT 'Trống'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `banan`
--

INSERT INTO `banan` (`MaBan`, `TenBan`, `TrangThai`) VALUES
(1, 'Bàn 01', 'Trống'),
(2, 'Bàn 02', 'Trống'),
(3, 'Bàn 03', 'Trống'),
(4, 'Bàn 04', 'Trống'),
(5, 'Bàn 05', 'Trống'),
(6, 'Bàn 06', 'Trống');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitiethoadon`
--

CREATE TABLE `chitiethoadon` (
  `MaHoaDon` int(11) NOT NULL,
  `MaMon` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `danhmuc`
--

CREATE TABLE `danhmuc` (
  `MaDanhMuc` int(11) NOT NULL,
  `TenDanhMuc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `danhmuc`
--

INSERT INTO `danhmuc` (`MaDanhMuc`, `TenDanhMuc`) VALUES
(1, 'Cà phê'),
(2, 'Trà sữa'),
(3, 'Đồ ăn nhẹ');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hoadon`
--

CREATE TABLE `hoadon` (
  `MaHoaDon` int(11) NOT NULL,
  `MaBan` int(11) DEFAULT NULL,
  `GioVao` datetime DEFAULT current_timestamp(),
  `GioRa` datetime DEFAULT NULL,
  `TongTien` decimal(18,2) DEFAULT 0.00,
  `TrangThai` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `monan`
--

CREATE TABLE `monan` (
  `MaMon` int(11) NOT NULL,
  `TenMon` varchar(100) NOT NULL,
  `MaDanhMuc` int(11) DEFAULT NULL,
  `DonGia` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `monan`
--

INSERT INTO `monan` (`MaMon`, `TenMon`, `MaDanhMuc`, `DonGia`) VALUES
(1, 'Cà phê đen', 1, 25000.00),
(2, 'Cà phê sữa', 1, 30000.00),
(3, 'Trà sữa Trân châu', 2, 35000.00),
(4, 'Bánh Mì Cốt Lết', 3, 20000.00);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `banan`
--
ALTER TABLE `banan`
  ADD PRIMARY KEY (`MaBan`);

--
-- Chỉ mục cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD PRIMARY KEY (`MaHoaDon`,`MaMon`),
  ADD KEY `MaMon` (`MaMon`);

--
-- Chỉ mục cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  ADD PRIMARY KEY (`MaDanhMuc`);

--
-- Chỉ mục cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MaHoaDon`),
  ADD KEY `MaBan` (`MaBan`);

--
-- Chỉ mục cho bảng `monan`
--
ALTER TABLE `monan`
  ADD PRIMARY KEY (`MaMon`),
  ADD KEY `MaDanhMuc` (`MaDanhMuc`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `banan`
--
ALTER TABLE `banan`
  MODIFY `MaBan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  MODIFY `MaDanhMuc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `MaHoaDon` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `monan`
--
ALTER TABLE `monan`
  MODIFY `MaMon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ràng buộc đối với các bảng kết xuất
--

--
-- Ràng buộc cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD CONSTRAINT `chitiethoadon_ibfk_1` FOREIGN KEY (`MaHoaDon`) REFERENCES `hoadon` (`MaHoaDon`) ON DELETE CASCADE,
  ADD CONSTRAINT `chitiethoadon_ibfk_2` FOREIGN KEY (`MaMon`) REFERENCES `monan` (`MaMon`);

--
-- Ràng buộc cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MaBan`) REFERENCES `banan` (`MaBan`);

--
-- Ràng buộc cho bảng `monan`
--
ALTER TABLE `monan`
  ADD CONSTRAINT `monan_ibfk_1` FOREIGN KEY (`MaDanhMuc`) REFERENCES `danhmuc` (`MaDanhMuc`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
