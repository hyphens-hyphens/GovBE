/* Điểm quảng cáo */
#database GovBE

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
Create Table AdsNew(
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
    
    IsActive bit not null default 1
);

/*Hình ảnh của quảng cáo*/
Create Table AdsNewPicture
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	HinhAnh MEDIUMBLOB,
    AdsNewId int
    #FOREIGN KEY (AdsNewId) REFERENCES AdsNew(Id)
);
/*Hình ảnh của điểm quảng cáo*/
Create Table AdsLocationPicture(

	Id INT AUTO_INCREMENT PRIMARY KEY,
	HinhAnh MEDIUMBLOB,
    AdsLocationId int
    #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
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
    
    IsActive bit not null default 1
    
    #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);

Create Table ReportWarningUrl (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    ReportWarningId int,
    Url char(200),
    
    CreateOnUtc DateTime,
    CreateUserId int null
    
     #FOREIGN KEY (ReportWarningId) REFERENCES ReportWarning(Id)
);

Create Table AdsLocationUpdate (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    AdsLocationId int,
    Date datetime,
    Comment char(200),
    OldStatus int,
    NewStatus int,
    
    CreateOnUtc DateTime,
    CreateUserId int null
   #FOREIGN KEY (AdsLocationId) REFERENCES AdsLocation(Id)
);


-- Inserting sample data into AdsLocation table
INSERT INTO AdsLocation (AdsAddress, Width, Height, SizeUnit, Quantity, Latitute, Longtitute, TypeAds, Status, EndDate, CreateOnUtc, LastUpdateOnUtc, CreateUserId, UpdateUserId)
VALUES 
    ('123 Main St', 5.0, 3.0, 'inches', 10, 40.7128, -74.0060, 1, 1, '2023-12-31', '2023-01-01', '2023-12-22', 1, 1),
    ('456 Elm St', 8.0, 4.0, 'inches', 5, 34.0522, -118.2437, 2, 2, '2023-12-30', '2023-01-02', '2023-12-23', 2, 2);

-- Inserting sample data into AdsNew table
INSERT INTO AdsNew (AdsLocationId, Comment, Width, Height, SizeUnit, Latitute, Longtitute, Name, AdsAddress, KhuVuc, LoaiViTri, HinhThucQuangCao, Description, NgayBatDauHd, NgayKetThucHd, CompanyInfo, Email, CompanyAddress, PhoneNumber, City, District, Ward, ProcessingStatus, CreateOnUtc, LastUpdateOnUtc)
VALUES 
    (1, 'New ad', 5.0, 3.0, 'inches', 40.7128, -74.0060, 'ABC Company', '123 Main St', 1, 1, 1, 'Description of ad', '2023-01-01', '2023-12-31', 'XYZ Corp', 'xyz@example.com', '789 Elm St', '123-456-7890', 'Los Angeles', 'Downtown', 'Central', 1, '2023-12-22', '2023-12-22');

-- Inserting sample data into AdsNewPicture table
INSERT INTO AdsNewPicture (HinhAnh, AdsNewId)
VALUES 
    (LOAD_FILE('/path/to/image1.jpg'), 1),
    (LOAD_FILE('/path/to/image2.jpg'), 1);

-- Inserting sample data into AdsLocationPicture table
INSERT INTO AdsLocationPicture (HinhAnh, AdsLocationId)
VALUES 
    (LOAD_FILE('/path/to/image3.jpg'), 1),
    (LOAD_FILE('/path/to/image4.jpg'), 2);

-- Inserting sample data into ReportWarning table
INSERT INTO ReportWarning (WarmType, FullName, Email, PhoneNumber, Comment, AdsLocationId, Status, CreateOnUtc, LastUpdateOnUtc)
VALUES 
    (1, 'John Doe', 'john@example.com', '123-456-7890', 'Report warning comment', 1, 1, '2023-12-22', '2023-12-22'),
    (2, 'Jane Smith', 'jane@example.com', '987-654-3210', 'Another warning', 2, 2, '2023-12-23', '2023-12-23');

-- Inserting sample data into ReportWarningUrl table
INSERT INTO ReportWarningUrl (ReportWarningId, Url, CreateOnUtc, CreateUserId)
VALUES 
    (1, 'https://example.com/report1', '2023-12-22', 1),
    (2, 'https://example.com/report2', '2023-12-23', 2);

-- Inserting sample data into AdsLocationUpdate table
INSERT INTO AdsLocationUpdate (AdsLocationId, Date, Comment, OldStatus, NewStatus, CreateOnUtc, CreateUserId)
VALUES 
    (1, '2023-12-22', 'Updating status', 1, 2, '2023-12-22', 1),
    (2, '2023-12-23', 'Another update', 2, 3, '2023-12-23', 2);

