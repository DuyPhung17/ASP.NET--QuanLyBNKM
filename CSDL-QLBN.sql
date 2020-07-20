CREATE DATABASE QLBNKM
GO

USE QLBNKM
GO

--TAO BANG
CREATE TABLE BENHNHAN
(  MABN                 INT IDENTITY    PRIMARY KEY,
   TENBN                nvarchar(50)	NOT null,
   NGAYSINHBN           date			NOT NULL,
   DIACHIBN             nvarchar(50)	NOT null,
   GIOITINH             NVARCHAR(5)		NOT NULL	CHECK(GIOITINH = N'Nam' OR GIOITINH = N'Nữ'),
   CMND					varchar(10)		,
   BHYT					varchar(20)		,
   UNIQUE(CMND,BHYT)
)
GO

CREATE TABLE BACSI
(  MABS                 INT IDENTITY    PRIMARY KEY,
   TENBS                nvarchar(50)    not null,
   NGAYSINHBS           date			not NULL,
   SDTBS                varchar(10)		NOT null,
   DIACHIBS             nvarchar(50)	NOT NULL,
   CHUYENMON            nvarchar(50)	not NULL	CHECK(CHUYENMON = N'Khám Nội' OR CHUYENMON = N'Khám Ngoại'),
   TRINHDO				nvarchar(50)	NOT NULL	CHECK(TRINHDO = N'Chuyên Khoa I' OR TRINHDO = N'Chuyên Khoa II'),
   ANHBS				NVARCHAR(50)	NOT NULL,
)
GO

CREATE TABLE THUOC
(  MATHUOC              INT IDENTITY	PRIMARY KEY,
   TENTHUOC             varchar(50)     NOT NULL,
   XUATXU               nvarchar(50)    NOT NULL,
   NSX                  date            NOT NULL,
   HSD                  date            NOT NULL,
   DONVITINH            NVARCHAR(20)    NOT NULL,
   DONGIATHUOC          int             NOT NULL,
)
GO

CREATE TABLE DICHVU
(  MADV                 INT IDENTITY     PRIMARY KEY,
   TENDV                nvarchar(50)     NOT NULL,
   DONGIADV             int              NOT NULL,
)
GO

CREATE TABLE BENH
(  MABENH               INT IDENTITY     PRIMARY KEY,
   TENBENH              nvarchar(50)     NOT NULL,
)
GO

CREATE TABLE HSBA
(  MAHSBA               INT IDENTITY        PRIMARY KEY,
   MABN                 INT					FOREIGN KEY REFERENCES dbo.BENHNHAN(MABN)
   ON UPDATE CASCADE
   ON DELETE CASCADE	NOT NULL,
   MABENH				INT					FOREIGN KEY REFERENCES dbo.BENH(MABENH)		
   ON UPDATE CASCADE
   ON DELETE CASCADE	NOT NULL,
   NGAYNHAPVIEN         date				NOT NULL,
   DUYET				BIT					NOT NULL,
)
GO


CREATE TABLE CT_HSBA
(  MAHSBA               INT			FOREIGN KEY REFERENCES dbo.HSBA(MAHSBA) 
   ON UPDATE CASCADE
   ON DELETE CASCADE	NOT NULL,
   MABS                 INT			FOREIGN KEY REFERENCES dbo.BACSI(MABS)	
   ON UPDATE CASCADE
   ON DELETE CASCADE	NOT null,
   NGAYKHAM				DATE			not NULL,
   TINHTRANG            NVARCHAR(100)   null,
   PRIMARY key (MAHSBA, NGAYKHAM)
)
GO

CREATE TABLE TOATHUOC
(	MATOATHUOC			INT	IDENTITY		PRIMARY KEY,
	MAHSBA				INT			FOREIGN KEY REFERENCES dbo.HSBA(MAHSBA) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	NGAYKE				DATE		NOT NULL,
)
GO

CREATE TABLE CT_TOATHUOC
(	MATOATHUOC			INT			FOREIGN KEY REFERENCES dbo.TOATHUOC(MATOATHUOC) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	MATHUOC				INT			FOREIGN KEY REFERENCES dbo.THUOC(MATHUOC) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	SOLUONG				INT				NOT NULL,
	LIEUDUNG			NVARCHAR(50)	NOT NULL,
	PRIMARY KEY(MATOATHUOC,MATHUOC)
)
GO

CREATE TABLE BANKEDICHVU
(	MABKDV				INT IDENTITY PRIMARY KEY,
	MAHSBA				INT			FOREIGN KEY REFERENCES dbo.HSBA(MAHSBA) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	NGAYSUDUNG			DATE			NOT NULL,
)
GO

CREATE TABLE CT_BANKEDICHVU
(	MABKDV				INT			FOREIGN KEY REFERENCES dbo.BANKEDICHVU(MABKDV) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	MADV				INT			FOREIGN KEY REFERENCES dbo.DICHVU(MADV) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	PRIMARY KEY(MABKDV,MADV)		
)
GO

CREATE TABLE BANKECHIPHI
(	MABKCP				INT IDENTITY    PRIMARY KEY,
	MAHSBA				INT				FOREIGN KEY REFERENCES dbo.HSBA(MAHSBA) 
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT NULL,
	NGAYLAPBKCP			DATE			NOT NULL,
	TIENTAMUNG			INT				NOT NULL,
	TIENDONGTHEM		INT				DEFAULT(0),
)
GO

CREATE TABLE TAIKHOAN
(	MATK	INT		IDENTITY	PRIMARY KEY,
	MABS                 INT			FOREIGN KEY REFERENCES dbo.BACSI(MABS)	
	ON UPDATE CASCADE
	ON DELETE CASCADE	NOT null, 
	ADMIN	BIT		NOT NULL,
	TENDN	VARCHAR(50)	NOT NULL,
	MATKHAU	VARCHAR(20) NOT NULL
)
GO

			
---------------------------------------DU LIEU---------------------------------------------------------------

INSERT dbo.BENHNHAN( TENBN ,NGAYSINHBN ,DIACHIBN ,GIOITINH, CMND, BHYT)
VALUES  
	(N'Trần Hoàng Vinh',	'1988-03-02',	N'11 Đống Đa',			N'Nam',	'225908981', 'HN2019182847190' ),
	(N'Ngô Công Linh',		'1983-03-02',	N'12 Bạch Đằng',		N'Nam',	'225908906', 'DT2019181847180'),
	(N'Vũ Hồng Liên',		'1979-02-11',	N'13 Lê Hồng Phong',	N'Nữ',	'225908977', 'TC3029181847180'),
	(N'Đặng Tuấn Quang',	'1990-12-22',	N'14 Trần Nhật Duật',	N'Nam',	'225108994', 'HN2020181847180'),
	(N'Nguyễn Quỳnh Hân',	'1999-07-14',	N'28 Tô Hiến Thành',	N'Nữ',	'226908995', 'SV4120181847180'),
	(N'Nguyễn Vũ Thanh',	'1988-04-02',	N'104 Hoàng Hoa Thám',	N'Nam',	'235908992', 'DN2020181847180'),
	(N'Trần Thùy Trâm',		'1987-05-01',	N'22 Đống Đa',			N'Nữ',	'225908998', 'NN4120181847180'),
	(N'Ngô Quốc Huy',		'1988-03-02',	N'37 Trần Phú',			N'Nam',	'225908990',  NULL),
	(N'Đặng Ngọc Tuyết',	'1989-11-12',	N'54 Đinh Tiên Hoàng',	N'Nữ',	'125908993',  NULL),
	(N'Võ Hoàng Anh',		'2008-03-02',	N'129 Lê Hồng Phong',	N'Nam',	 NULL,		 'HS4120181847180');
GO

INSERT dbo.BACSI( TENBS ,NGAYSINHBS ,SDTBS ,DIACHIBS ,CHUYENMON, TRINHDO, ANHBS)
VALUES  
	(N'Nguyễn Văn Nam',	'1970-09-03',	'0987654321',	N'17 Bạch Đằng',	N'Khám Nội',	'Chuyên Khoa II', N'BS01.png'),
	(N'Nguyễn Thị Vân',	'1980-09-03',	'0987654321',	N'31 Đồng Nai',		N'Khám Ngoại',	'Chuyên Khoa II', N'BS02.png'),
	(N'Lê Văn Chiến',	'1973-09-03',	'0987654321',	N'87 Nguyễn Trãi',	N'Khám Ngoại',	'Chuyên Khoa I', N'BS03.png'),
	(N'Ngô Quang Khoa',	'1972-09-03',	'0987654321',	N'05 Trịnh Phong',	N'Khám Nội',	'Chuyên Khoa II', N'BS04.png'),
	(N'Trần Văn Tính',	'1970-05-03',	'0997654321',	N'14 Đống Đa',		N'Khám Nội',	'Chuyên Khoa I', N'BS05.png'),
	(N'Võ Toàn Thắng',	'1969-09-03',	'0987654321',	N'37 Cửu Long',		N'Khám Ngoại',	'Chuyên Khoa II', N'BS06.png'),
	(N'Thái Ngọc Hằng',	'1988-09-03',	'0956654321',	N'10 Trịnh Phong',	N'Khám Ngoại',	'Chuyên Khoa I', N'BS07.png'),
	(N'Nguyễn Văn Sơn',	'1970-10-03',	'0987654320',	N'10 Trần Phú',		N'Khám Ngoại',	'Chuyên Khoa I', N'BS08.png'),
	(N'Lê Như Ý',		'1985-02-08',	'0187654321',	N'9A Nhị Hà',		N'Khám Nội',	'Chuyên Khoa II', N'BS09.png'),
	(N'Trần Việt Sinh','1971-09-03',	'0987654321',	N'87 Nguyễn Trãi',	N'Khám Nội',	'Chuyên Khoa I', N'BS10.png');
GO        

INSERT dbo.THUOC( TENTHUOC ,XUATXU ,NSX ,HSD ,DONVITINH ,DONGIATHUOC)
VALUES  
	(N'Aminetan',			N'Đức',		'2017-09-01',	'2020-09-01',	N'lọ',		'45000'),
	(N'Morinphelyntaxen',	N'Pháp',	'2017-09-01',	'2020-09-01',	N'Ống',		'165000'),
	(N'Avinilyn-Omega',		N'Đức',		'2017-09-01',	'2020-09-01',	N'viên',	'20000'),
	(N'Calbutanxen',		N'Mỹ',		'2017-09-01',	'2020-09-01',	N'viên',	'40000'),
	(N'Acidcitanelin',		N'Pháp',	'2017-09-01',	'2020-09-01',	N'lọ',		'25000'),
	(N'Torralin',			N'Đức',		'2017-09-01',	'2020-09-01',	N'viên',	'40000'),
	(N'Mentophav',			N'Nga',		'2017-09-01',	'2020-09-01',	N'viên',	'35000'),
	(N'Nevanac',			N'Pháp',	'2017-09-01',	'2020-09-01',	N'lọ',		'45000'),
	(N'Vigamox',			N'Mỹ',		'2017-09-01',	'2020-09-01',	N'lọ',		'70000'),
	(N'Cravit',				N'Nhật',	'2017-09-01',	'2020-09-01',	N'lọ',		'55000'),
	(N'Sanlein',			N'Nhật',	'2017-09-01',	'2020-09-01',	N'lọ',		'55000');
GO

INSERT dbo.DICHVU( TENDV, DONGIADV )
VALUES  
	( N'Đo mắt','20000'),
	( N'Đo đường kính giác mạc','40000'),
	( N'Đo thị trường chu biên','30000'),
	( N'Đo biên độ điều tiết','45000'),
	( N'Siêu âm mắt','50000'),
	( N'Khâu giác mạc','300000'),
	( N'Khâu củng mạc','150000'),
	( N'Nghiệm pháp glocom','70000'),
	( N'Khâu mép giác mạc','450000'),
	( N'Lấy dị vật giác mạc','600000'),
	( N'Lấy dị vật hốc mắt','500000');
GO

INSERT dbo.BENH(TENBENH )
VALUES  
	(N'Viêm Kết Mạc'),
	(N'Đục Thủy Tinh Thể'),
	(N'Mộng Thịt'),
	(N'Chấn Thương Nhãn Cầu'),
	(N'Loét Giác Mạc'),
	(N'Tăng Nhãn Áp'),
	(N'Đau Mắt Hột'),
	(N'Thoái Hóa Võng Mạc'),
	(N'Thoái Hóa Hoàng Điểm'),
	(N'Bong Võng Mạc');
GO
	  
INSERT dbo.HSBA( MABN, MABENH, NGAYNHAPVIEN, DUYET )
VALUES  
	(1,	6,	'2019-01-20', 0),
	(2,	7,	'2019-02-20', 0),
	(3,	1,	'2019-03-20', 0),
	(4,	4,	'2019-04-20', 0),
	(5,	4,	'2019-05-20', 0),
	(6,	6,	'2019-06-20', 0),
	(7,	8,	'2019-07-20', 0),
	(8,	3,	'2019-08-20', 0),
	(9,	2,	'2019-09-20', 0),
	(10,1,	'2019-10-20', 0);
GO

INSERT dbo.CT_HSBA(MAHSBA, MABS, NGAYKHAM, TINHTRANG)
VALUES  
	(1,	9,	'2019-01-20',	N'Loét giác mạc'),
	(1,	4,	'2019-01-21',	N'Giảm loét giác mạc'),

	(2,	2,	'2019-02-21',	N'Dị vật hốc mắt'),

	(3,	3,	'2019-03-20',	N'Đục thủy tinh thể'),

	(4,	7,	'2019-04-20',	N'Loét giác mạc'),

	(5,	8,	'2019-05-20',	N'Rách giác mạc'),

	(6,	1,	'2019-06-20',	N'Đục thủy tinh thể'),

	(7,	5,	'2019-07-20',	N'Mộng thịt'),

	(8, 3,	'2019-08-20',	N'Dị ứng mắt'),
	(8, 1,	'2019-08-21',	N'Đỏ vùng khóe mắt'),

	(9,	4,	'2019-09-20',	N'Dị vật hốc mắt'),
	(9,	2,	'2019-09-21',	N'Sưng tấy hốc mắt'),

	(10,5,	'2019-10-20',	N'Đục thủy tinh thể');
GO

INSERT dbo.TOATHUOC(MAHSBA, NGAYKE )
VALUES  
	(1,		'2019-01-20'),
	(1,		'2019-01-21'),

	(2,		'2019-02-21'),

	(3,		'2019-03-20'),

	(4,		'2019-04-20'),

	(5,		'2019-05-20'),

	(6,		'2019-06-20'),

	(7,		'2019-07-20'),

	(8,		'2019-08-20'),
	(8,		'2019-08-21'),

	(9,		'2019-09-21'),

	(10,	'2019-02-21');
GO

INSERT dbo.CT_TOATHUOC( MATOATHUOC ,MATHUOC ,SOLUONG ,LIEUDUNG)
VALUES  
	(1, 5, 2, N'2 lần/ngày'),
	(1, 8, 1, N'2 lần/ngày'),
	(1, 9, 1, N'1 lần/ngày'),

	(2, 6, 3, N'1 lần/ngày'),
	(2, 8, 3, N'1 lần/ngày'),

	(3, 1, 2, N'3 lần/ngày'),
	(3, 4, 2, N'2 lần/ngày'),

	(4, 3, 1, N'2 lần/ngày'),

	(5, 4, 1, N'1 lần/ngày'),
	(5, 5, 2, N'1 lần/ngày'),

	(6, 1, 2, N'2 lần/ngày'),

	(7, 7, 2, N'1 lần/ngày'),
	(7, 3, 3, N'2 lần/ngày'),

	(8, 9, 1, N'1 lần/ngày'),
	(8, 4, 2, N'1 lần/ngày'),
	(8, 1, 2, N'1 lần/ngày'),

	(9, 10, 2, N'1 lần/ngày'),

	(10, 3, 3, N'3 lần/ngày'),
	(10, 9, 1, N'2 lần/ngày'),

	(11, 5, 2, N'2 lần/ngày'),

	(12, 4, 2, N'2 lần/ngày');
GO

INSERT dbo.BANKEDICHVU(MAHSBA, NGAYSUDUNG )
VALUES  
	(1,	'2019-01-20'),
	(2,	'2019-02-21'),
	(3,	'2019-03-20'),
	(6,	'2019-06-20'),
	(7,	'2019-07-20'),

	(8,	'2019-08-20'),
	(8,	'2019-08-21'),

	(9,	'2019-09-20');
GO

INSERT dbo.CT_BANKEDICHVU( MABKDV, MADV )
VALUES 
	(1, 3),
	(1, 7),

	(2, 4),
	(3, 1),
	(4, 2),
	(5, 2),
	(6, 9),
	(7, 2),
	(8, 5);
GO

INSERT dbo.BANKECHIPHI(MAHSBA ,NGAYLAPBKCP ,TIENTAMUNG ,TIENDONGTHEM)
VALUES  
	(1,  '2019-01-23',	'800000',	'100000'),
	(2,  '2019-02-23',	'500000',	'100000'),
	(3,  '2019-03-23',	'500000',	'100000'),
	(4,  '2019-04-23',	'300000',	'600000'),
	(5,  '2019-05-23',	'500000',	'200000'),
	(6,  '2019-06-23',	'550000',	'300000'),
	(7,  '2019-07-23',	'700000',	'400000'),
	(8,  '2019-08-23',	'1000000',	'200000'),
	(9,  '2019-09-23',	'400000',	'300000'),
	(10, '2019-10-23',	'600000',	'500000');
GO

INSERT dbo.TAIKHOAN(ADMIN, MABS,  TENDN, MATKHAU )
VALUES  
	(1,1, 'duy' ,'123'),
	(0,3, 'huy'	,'123');
GO
