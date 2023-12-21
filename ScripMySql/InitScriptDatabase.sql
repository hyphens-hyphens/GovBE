/* Điểm quảng cáo */
Create table AdsLocation (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    AdsAddress char(200),
    
    Width float,
    Height float,
    SizeUnit char(20),
    Quantity int,
    Latitute decimal,
    Longtitute decimal,
    
    TypeAds int, /* use enum TypeAds.cs*/
    Status int,/* use enum AdsLocationStatus.cs*/
    
    EndDate datetime,
    
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int,
    UpdateUserId int,
    
    IsActive bit not null default 1
);

/*Quảng cáo trên điểm quảng cáo*/
Create Table AdsAdvertising(
	Id INT AUTO_INCREMENT PRIMARY KEY,
    AdsLocationId int,
    Comment char(200),
    
    Width float,
    Height float,
    SizeUnit char(20),
    
    Latitute decimal,
    Longtitute decimal,
    
    Name char(200),
	AdsAddress char(200),
    
    KhuVuc INT, /*Use enum KhuVuc.cs*/
    LoaiViTri int,  /*Use enum LoaiViTri.cs*/
    HinhThucQuangCao int, /*Use enum HinhThucQuangCao.cs*/
	Description char(255),

    NgayBatDauHd DateTime,
    NgayKetThucHd DateTime,
    
    CompanyInfo char(200),
    Email char(60),
	CompanyAddress char(200),
    PhoneNumber char(200),
    City char(100),
	District char(100),
    Ward char(100),
    
    ProcessingStatus INT, /*Use enum ProcessingStatus.cs 
    Thông tin về việc điểm đặt đã được quy hoạch hay chưa?*/ 
    
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    
    IsActive bit not null default 1,
    
    FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);

/*Hình ảnh của quảng cáo*/
Create Table AdsAdvertisingPicture
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	HinhAnh MEDIUMBLOB,
    AdsAdvertisingId int,
    FOREIGN KEY (AdsAdvertisingId) REFERENCES AdsAdvertising(Id)
);
/*Hình ảnh của điểm quảng cáo*/
Create Table AdsLocationPicture(

	Id INT AUTO_INCREMENT PRIMARY KEY,
	HinhAnh MEDIUMBLOB,
    AdsLocationId int,
    FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);

Create Table ReportWarning (
	Id INT AUTO_INCREMENT PRIMARY KEY,
	WarmType int, /*Use enum WarmType.cs*/
	FullName char(100),
    Email char(100),
    PhoneNumber char(100),
    Comment char(200),
    AdsLocationId int,
    Status int, /*Use enum ReportWarningWarning.cs*/
    
    CreateOnUtc DateTime,
    LastUpdateOnUtc DateTime,
    CreateUserId int null,
    UpdateUserId int null,
    
    IsActive bit not null default 1,
    
    FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);

Create Table ReportWarningUrl (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    ReportWarningId int,
    Url char(200),
    
    CreateOnUtc DateTime,
    CreateUserId int null,
    
    FOREIGN KEY (ReportWarningId) REFERENCES ReportWarning(Id)
);

Create Table AdsLocationUpdate (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    AdsLocationId int,
    Date datetime,
    Comment char(200),
    OldStatus int,
    NewStatus int,
    
    CreateOnUtc DateTime,
    CreateUserId int null,
    FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);
