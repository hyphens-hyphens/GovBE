/* Điểm quảng cáo */
#database GovBE

Create table AdsLocation (
	AdsLocationId INT AUTO_INCREMENT PRIMARY KEY,
    AdsAddress char(200),
    Width float,
    Height float,
    SizeUnit char(20),
    Quantity int,
    TypeID int, /* use enum typeads.cs*/
    AdsStatus char(30),/* use enum adslocationstatus.cs*/
    EndDate datetime,
    Latitude decimal,
    Longtitude decimal,
    

    
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1

);

/*Quảng cáo trên điểm quảng cáo*/
Create Table AdsNew(
	AdsNewId INT AUTO_INCREMENT PRIMARY KEY,
    AdsLocationId int,
    StartDate DateTime,
    EndDate DateTime,
    Comment char(200),
    CompanyInfo char(200),
    Email char(60),
    CompanyAddress char(200),
    PhoneNumber char(20),
    City char(100),
    District char(100),
    Ward char(100),
    Width float,
    Height float,
    SizeUnit char(20),
    AdsAddress char(200),
    Latitude decimal,
    Longtitude decimal,
    ProcessingStatus char(30), /*Use enum ProcessingStatus.cs 
    Thông tin về việc điểm đặt đã được quy hoạch hay chưa?*/ 



    CreateUserId int null,
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    UpdateUserId int null,
    IsActive bit not null default 1


);

Create Table ReportWarning (
	ReportWarningId INT AUTO_INCREMENT PRIMARY KEY,
	WarningType char(30), /*Use enum WarmType.cs*/
	FullName char(100),
    Email char(100),
    PhoneNumber char(20),
    Comment char(200),
    AdsLocationId int,
    ReportWarningStatus char(30), /*Use enum ReportWarningWarning.cs*/
    
    CreateUserId int null,
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    UpdateUserId int null,
    IsActive bit not null default 1
    
    #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(AdsLocationId)
);

/*Hình ảnh của quảng cáo*/
Create Table AdsNewImage
(
	AdsNewImageId INT AUTO_INCREMENT PRIMARY KEY,
	Image MEDIUMBLOB,
    AdsNewID int,
    
    CreateOnUtc DateTime,
    CreateUserId int null
    #FOREIGN KEY (AdsNewId) REFERENCES AdsNew(AdsNewId)
);

/*Hình ảnh của điểm quảng cáo*/
Create Table AdsLocationImage(

	AdsLocationImageId INT AUTO_INCREMENT PRIMARY KEY,
	Image MEDIUMBLOB,
    AdsLocationId int,
    #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(AdsLocationId)
    CreateOnUtc DateTime,
    CreateUserId int null
);

/*Url của điểm quảng cáo*/
Create Table ReportWarningUrl (
	ReportWarningImageId INT AUTO_INCREMENT PRIMARY KEY,
    ReportWarningId int,
    Url char(200),
    
    CreateOnUtc DateTime,
    CreateUserId int null
    
    #FOREIGN KEY (ReportWarningId) REFERENCES ReportWarning(ReportWarningId)
);

Create Table AdsLocationUpdate (
	AdsLocationUpdateId INT AUTO_INCREMENT PRIMARY KEY,
    AdsLocationId int,
    Date datetime,
    Comment char(200),
    StatusEdit char(30),
    
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1
   #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(AdsLocationId)
);

CREATE TABLE AdsProcessing(

	AdsProcessingId INT AUTO_INCREMENT PRIMARY KEY,
    AdsNewId int,
    ProcessingStatus char(30),
    Comment char(200),
    

    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1
);

CREATE TABLE AdsStatus(

	AdsStatusId INT AUTO_INCREMENT PRIMARY KEY,
    Name char(200),
    DisplayName char(200),

    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1
);

CREATE TABLE AdsType(
    AdsTypeId INT AUTO_INCREMENT PRIMARY KEY,
    Name char(200),
    DisplayName char(200),

    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1

);
CREATE TABLE WarningType(
    WarningTypeId INT AUTO_INCREMENT PRIMARY KEY,
    Name char(200),

    DisplayName char(200),
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    IsActive bit not null default 1

);


-- AdsType
INSERT INTO AdsType (Name, DisplayName, CreateOnUtc, LastUpdateOnUtc, IsActive) VALUES
('TruBangHiflex', 'Trụ bảng hiflex', NOW(), NOW(), 1),
('TruManHinhDienTuLed', 'Trụ màn hình điện tử LED', NOW(), NOW(), 1),
('BangHiflexOpTuong', 'Bảng hiflex ốp tường', NOW(), NOW(), 1),
('TruHopDen', 'Trụ hộp đèn', NOW(), NOW(), 1),
('ManHinhDienTuOpTuong', 'Màn hình điện tử ốp tường', NOW(), NOW(), 1),
('TruTreoBangRonDoc', 'Trụ treo băng rôn dọc', NOW(), NOW(), 1),
('TruTreoBangRonNgang', 'Trụ treo băng rôn ngang', NOW(), NOW(), 1),
('TruCumPano', 'Trụ/Cụm pano', NOW(), NOW(), 1),
('CongChao', 'Cổng chào', NOW(), NOW(), 1),
('TrungTamThuongMai', 'Trung tâm thương mại', NOW(), NOW(), 1);

-- WarningType
INSERT INTO WarningType (Name, DisplayName, CreateOnUtc, LastUpdateOnUtc, IsActive) VALUES
('ToGiacSaiPham', 'Tố giác sai phạm', NOW(), NOW(), 1),
('DongGopYKien', 'Đóng góp ý kiến', NOW(), NOW(), 1),
('DangKyNoiDung', 'Đăng ký nội dung', NOW(), NOW(), 1),
('GiaiDapThacMac', 'Giải đáp thắc mắc', NOW(), NOW(), 1);

-- AdsStatus
INSERT INTO AdsStatus (Name, DisplayName, CreateOnUtc, LastUpdateOnUtc, IsActive) VALUES
('HetHan', 'Hết hạn', NOW(), NOW(), 1),
('ConHan', 'Còn hạn', NOW(), NOW(), 1),
('ChuaXetDuyet', 'Chưa xét duyệt', NOW(), NOW(), 1),
('ViPham', 'Vi phạm', NOW(), NOW(), 1);

-- AdsLocation
INSERT INTO AdsLocation (AdsAddress, Width, Height, SizeUnit, Quantity, TypeID, AdsStatus, EndDate, Latitude, Longtitude, CreateOnUtc, LastUpdateOnUtc, IsActive) VALUES
('123 Lê Lợi, Quận 1', 5.5, 3.2, 'meters', 1, 1, 'Hết hạn', '2024-01-31 23:59:59', 10.762622, 106.660172, NOW(), NOW(), 1),
('456 Nguyễn Huệ, Quận 1', 6.5, 3.5, 'meters', 1, 2, 'còn hạn', '2024-02-28 23:59:59', 10.787755, 106.749860, NOW(), NOW(), 1),
('789 Phan Xích Long, Quận Phú Nhuận', 7.5, 3.8, 'meters', 1, 3, 'chưa xét duyệt', '2024-03-31 23:59:59', 10.784708, 106.679491, NOW(), NOW(), 1),
('101 Trần Hưng Đạo, Quận 5', 8.5, 4.1, 'meters', 1, 4, 'vi phạm', '2024-04-30 23:59:59', 10.759550, 106.704109, NOW(), NOW(), 1),
('202 Cộng Hòa, Quận Tân Bình', 9.5, 4.4, 'meters', 1, 5, 'Hết hạn', '2024-05-31 23:59:59', 10.754308, 106.670436, NOW(), NOW(), 1),
('303 Hoàng Văn Thụ, Quận Tân Bình', 10.5, 4.7, 'meters', 1, 6, 'còn hạn', '2024-06-30 23:59:59', 10.749800, 106.634808, NOW(), NOW(), 1),
('404 Bà Hạt, Quận 10', 11.5, 5.0, 'meters', 1, 7, 'chưa xét duyệt', '2024-07-31 23:59:59', 10.729381, 106.721877, NOW(), NOW(), 1),
('505 Võ Văn Tần, Quận 3', 12.5, 5.3, 'meters', 1, 8, 'vi phạm', '2024-08-31 23:59:59', 10.747119, 106.663315, NOW(), NOW(), 1),
('606 Hai Bà Trưng, Quận 1', 13.5, 5.6, 'meters', 1, 9, 'Hết hạn', '2024-09-30 23:59:59', 10.819665, 106.802656, NOW(), NOW(), 1),
('707 Nguyễn Văn Trỗi, Quận Phú Nhuận', 14.5, 5.9, 'meters', 1, 10, 'còn hạn', '2024-10-31 23:59:59', 10.773389, 106.667183, NOW(), NOW(), 1);



-- AdsNew
INSERT INTO AdsNew (AdsLocationId, StartDate, EndDate, Comment, CompanyInfo, Email, CompanyAddress, PhoneNumber, City, District, Ward, Width, Height, SizeUnit, AdsAddress, Latitude, Longtitude, ProcessingStatus, CreateOnUtc, LastUpdateOnUtc, CreateUserId, UpdateUserId, IsActive) VALUES
(1, '2023-12-24 09:00:00', '2023-12-31 18:00:00', 'Khuyến mãi cuối năm', 'Công ty A', 'info@a-company.com', '123 Lê Lợi, Quận 1', '0123456789', 'Thành phố Hồ Chí Minh', 'Quận 1', 'Phường Bến Nghé', 5.5, 3.2, 'meters', '123 Lê Lợi, Quận 1', 10.762622, 106.660172, 'Chưa xử lý', NOW(), NOW(), 1, 1, 1),
(2, '2023-12-25 10:00:00', '2023-12-31 20:00:00', 'Mừng Giáng Sinh', 'Công ty B', 'contact@b-company.com', '456 Nguyễn Huệ, Quận 1', '0234567890', 'Thành phố Hồ Chí Minh', 'Quận 1', 'Phường Phạm Ngũ Lão', 6.5, 3.5, 'meters', '456 Nguyễn Huệ, Quận 1', 10.787755, 106.749860, 'Đang xử lý', NOW(), NOW(), 2, 2, 1),
(3, '2023-12-26 11:00:00', '2023-12-31 21:00:00', 'Khuyến mãi Tết', 'Công ty C', 'support@c-company.com', '789 Phan Xích Long, Quận Phú Nhuận', '0345678901', 'Thành phố Hồ Chí Minh', 'Quận Phú Nhuận', 'Phường 7', 7.5, 3.8, 'meters', '789 Phan Xích Long, Quận Phú Nhuận', 10.784708, 106.679491, 'Chưa xử lý', NOW(), NOW(), 3, 3, 1),
(4, '2023-12-27 12:00:00', '2023-12-31 22:00:00', 'Mua 1 tặng 1', 'Công ty D', 'sales@d-company.com', '101 Trần Hưng Đạo, Quận 5', '0456789012', 'Thành phố Hồ Chí Minh', 'Quận 5', 'Phường 10', 8.5, 4.1, 'meters', '101 Trần Hưng Đạo, Quận 5', 10.759550, 106.704109, 'Đang xử lý', NOW(), NOW(), 4, 4, 1),
(5, '2023-12-28 13:00:00', '2023-12-31 23:00:00', 'Giảm giá 50%', 'Công ty E', 'info@e-company.com', '202 Cộng Hòa, Quận Tân Bình', '0567890123', 'Thành phố Hồ Chí Minh', 'Quận Tân Bình', 'Phường 12', 9.5, 4.4, 'meters', '202 Cộng Hòa, Quận Tân Bình', 10.754308, 106.670436, 'Chưa xử lý', NOW(), NOW(), 5, 5, 1),
(6, '2023-12-29 14:00:00', '2023-12-31 23:59:59', 'Quảng cáo mới', 'Công ty F', 'contact@f-company.com', '303 Hoàng Văn Thụ, Quận Tân Bình', '0678901234', 'Thành phố Hồ Chí Minh', 'Quận Tân Bình', 'Phường 14', 10.5, 4.7, 'meters', '303 Hoàng Văn Thụ, Quận Tân Bình', 10.749800, 106.634808, 'Đang xử lý', NOW(), NOW(), 6, 6, 1),
(7, '2023-12-30 15:00:00', '2023-12-31 23:59:59', 'Tặng voucher', 'Công ty G', 'support@g-company.com', '404 Bà Hạt, Quận 10', '0789012345', 'Thành phố Hồ Chí Minh', 'Quận 10', 'Phường 3', 11.5, 5.0, 'meters', '404 Bà Hạt, Quận 10', 10.729381, 106.721877, 'Chưa xử lý', NOW(), NOW(), 7, 7, 1),
(8, '2023-12-31 16:00:00', '2023-12-31 23:59:59', 'Năm mới, sản phẩm mới', 'Công ty H', 'sales@h-company.com', '505 Võ Văn Tần, Quận 3', '0890123456', 'Thành phố Hồ Chí Minh', 'Quận 3', 'Phường 6', 12.5, 5.3, 'meters', '505 Võ Văn Tần, Quận 3', 10.747119, 106.663315, 'Đang xử lý', NOW(), NOW(), 8, 8, 1);

-- AdsProcessing
INSERT INTO AdsProcessing (AdsNewId, ProcessingStatus, Comment, CreateOnUtc, LastUpdateOnUtc, CreateUserId, UpdateUserId, IsActive) VALUES
(1, 'Chưa xử lý', 'Yêu cầu xử lý nhanh', NOW(), NOW(), 1, 1, 1),
(2, 'Đang xử lý', 'Đang chờ thông tin khách hàng', NOW(), NOW(), 2, 2, 1),
(3, 'Chưa xử lý', 'Cần liên hệ khách hàng', NOW(), NOW(), 3, 3, 1),
(4, 'Đang xử lý', 'Đang tạo hợp đồng', NOW(), NOW(), 4, 4, 1),
(5, 'Chưa xử lý', 'Cần xác nhận thông tin', NOW(), NOW(), 5, 5, 1),
(6, 'Đang xử lý', 'Đang kiểm tra nội dung', NOW(), NOW(), 6, 6, 1),
(7, 'Chưa xử lý', 'Cần xác minh địa điểm', NOW(), NOW(), 7, 7, 1),
(8, 'Đang xử lý', 'Đang tạo báo cáo', NOW(), NOW(), 8, 8, 1),
(9, 'Chưa xử lý', 'Cần phê duyệt từ quản lý', NOW(), NOW(), 9, 9, 1),
(10, 'Đang xử lý', 'Đang tải hình ảnh', NOW(), NOW(), 10, 10, 1);

-- AdsUpdate
INSERT INTO AdsLocationUpdate (AdsLocationId, Date, Comment, StatusEdit, CreateOnUtc, LastUpdateOnUtc, CreateUserId, UpdateUserId, IsActive) VALUES
(1, '2023-12-20 09:00:00', 'Chỉnh sửa địa điểm', 'Chưa xử lý', NOW(), NOW(), 1, 2, 1),
(2, '2023-12-21 10:00:00', 'Cập nhật thông tin', 'Đang xử lý', NOW(), NOW(), 2, 3, 1),
(3, '2023-12-22 11:00:00', 'Đổi trạng thái quảng cáo', 'Chưa xử lý', NOW(), NOW(), 3, 4, 1),
(4, '2023-12-23 12:00:00', 'Thêm thông tin mới', 'Đang xử lý', NOW(), NOW(), 4, 5, 1),
(5, '2023-12-24 13:00:00', 'Xóa quảng cáo', 'Đã xử lý', NOW(), NOW(), 5, 6, 1),
(6, '2023-12-25 14:00:00', 'Cập nhật hình ảnh', 'Chưa xử lý', NOW(), NOW(), 6, 7, 1),
(7, '2023-12-26 15:00:00', 'Thêm mô tả chi tiết', 'Đang xử lý', NOW(), NOW(), 7, 8, 1),
(8, '2023-12-27 16:00:00', 'Kiểm tra địa chỉ', 'Chưa xử lý', NOW(), NOW(), 8, 9, 1),
(9, '2023-12-28 17:00:00', 'Chỉnh sửa kích thước', 'Đang xử lý', NOW(), NOW(), 9, 10, 1),
(10, '2023-12-29 18:00:00', 'Thêm thông tin liên hệ', 'Chưa xử lý', NOW(), NOW(), 10, 11, 1);


-- ReportWarning
INSERT INTO ReportWarning (WarningType, FullName, Email, PhoneNumber, Comment, AdsLocationId, ReportWarningStatus, CreateUserId, CreateOnUtc, LastUpdateOnUtc, UpdateUserId, IsActive) VALUES
('Tố giác sai phạm', 'Nguyễn Văn A', 'nguyenvana@email.com', '0123456789', 'Quảng cáo vi phạm nội dung', 1, 'Đang xử lý', 1, NOW(), NOW(), 2, 1),
('Đóng góp ý kiến', 'Trần Thị B', 'tranthib@email.com', '0234567890', 'Mong muốn quảng cáo rõ ràng hơn', 2, 'Đã xử lý', 2, NOW(), NOW(), 3, 1),
('Đăng ký nội dung', 'Lê Văn C', 'levanc@email.com', '0345678901', 'Muốn đăng ký nội dung quảng cáo mới', 3, 'Chưa xử lý', 3, NOW(), NOW(), 4, 1),
('Giải đáp thắc mắc', 'Phạm Thị D', 'phamthid@email.com', '0456789012', 'Cần thông tin chi tiết về quảng cáo', 4, 'Đang xử lý', 4, NOW(), NOW(), 5, 1),
('Tố giác sai phạm', 'Hoàng Văn E', 'hoangvane@email.com', '0567890123', 'Quảng cáo không phù hợp', 5, 'Chưa xử lý', 5, NOW(), NOW(), 6, 1),
('Đóng góp ý kiến', 'Ngọc Anh F', 'ngocanhf@email.com', '0678901234', 'Quảng cáo nên rõ ràng hơn', 6, 'Đã xử lý', 6, NOW(), NOW(), 7, 1),
('Đăng ký nội dung', 'Tuấn Anh G', 'tuananhg@email.com', '0789012345', 'Muốn đăng quảng cáo sản phẩm mới', 7, 'Chưa xử lý', 7, NOW(), NOW(), 8, 1),
('Giải đáp thắc mắc', 'Hà Minh H', 'haminhh@email.com', '0890123456', 'Cần tư vấn về chất lượng quảng cáo', 8, 'Đang xử lý', 8, NOW(), NOW(), 9, 1),
('Tố giác sai phạm', 'Linh Chi I', 'linhchii@email.com', '0901234567', 'Quảng cáo vi phạm quy định', 9, 'Đã xử lý', 9, NOW(), NOW(), 10, 1),
('Đóng góp ý kiến', 'Đức Hoàng J', 'duchoangj@email.com', '0912345678', 'Nội dung quảng cáo không chính xác', 10, 'Chưa xử lý', 10, NOW(), NOW(), 11, 1);
