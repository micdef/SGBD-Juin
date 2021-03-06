USE [SGBD-Juin]

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Customer')))
BEGIN
	CREATE TABLE [Customer]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[Name] NVARCHAR(50) NOT NULL,
		[ZipCode] NVARCHAR(4) NOT NULL,
		[City] NVARCHAR(100) NOT NULL,
		[Street] NVARCHAR(100) NOT NULL,
		[StreetNB] NVARCHAR(4) NOT NULL,
		[StreetBOX] NVARCHAR(2) NULL,
		[Tel] NVARCHAR(10) NOT NULL,
		[Fax] NVARCHAR(10) NULL,
		[Mail] NTEXT NOT NULL,
		CONSTRAINT [PK_Customer_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [UK_Customer_Name] UNIQUE ([Name])
	);
END

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'User')))
BEGIN
	CREATE TABLE [User]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[Usn] NVARCHAR(101) NOT NULL,
		[Pwd] NVARCHAR(100) NOT NULL,
		[FName] NVARCHAR(50) NOT NULL,
		[LName] NVARCHAR(50) NOT NULL,
		[Mail] NTEXT NOT NULL,
		[FAdmin] BIT NOT NULL,
		[FActive] BIT NOT NULL,
		[FDelete] BIT NOT NULL,
		CONSTRAINT [PK_User_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [UK_User_Usn] UNIQUE ([Usn])
	);
END

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Administrative')))
BEGIN
	CREATE TABLE [Administrative]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[IDUser] INT NOT NULL,
		[Salary] FLOAT NOT NULL,
		[InternPhone] NVARCHAR(5) NOT NULL,
		CONSTRAINT [PK_Administrative_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [FK_Administrative_IDUser] FOREIGN KEY ([IDUser]) REFERENCES [User]([ID]),
		CONSTRAINT [UK_Administrative_IDUser] UNIQUE ([IDUser])
	);
END

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Technical')))
BEGIN
	CREATE TABLE [Technical]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[IDUser] INT NOT NULL,
		[HourRate] FLOAT NOT NULL,
		[GSM] NVARCHAR(10) NOT NULL,
		CONSTRAINT [PK_Technical_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [FK_Technical_IDUser] FOREIGN KEY ([IDUser]) REFERENCES [User]([ID]),
		CONSTRAINT [UK_Technical_IDUser] UNIQUE ([IDUser])
	);
END

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ticket')))
BEGIN
	CREATE TABLE [Ticket]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[IDCustomer] INT NOT NULL,
		[IDAdministrative] INT NOT NULL,
		[Subject] NVARCHAR(255) NOT NULL,
		[DateIN] DATETIME NOT NULL,
		[Note] NTEXT NULL,
		[FFinished] BIT NOT NULL,
		CONSTRAINT [PK_Ticket_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [FK_Ticket_IDCustomer] FOREIGN KEY ([IDCustomer]) REFERENCES [Customer]([ID]),
		CONSTRAINT [FK_Ticket_IDAdministrative] FOREIGN KEY ([IDAdministrative]) REFERENCES [Administrative]([ID]),
		CONSTRAINT [UK_Ticket_IDCustomerDateIN] UNIQUE ([IDCustomer], [DateIN])
	);
END

IF(NOT(EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Intervention')))
BEGIN
	CREATE TABLE [Intervention]
	(	[ID] INT IDENTITY(1,1) NOT NULL,
		[IDTicket] INT NOT NULL,
		[IDTechnical] INT NOT NULL,
		[DateBegin] DATETIME NOT NULL,
		[DateEnd] DATETIME NOT NULL,
		[Subject] NVARCHAR(255) NOT NULL,
		[TechnicalNote] NTEXT NULL,
		CONSTRAINT [PK_Intervention_ID] PRIMARY KEY ([ID]),
		CONSTRAINT [FK_Intervention_IDTicket] FOREIGN KEY ([IDTicket]) REFERENCES [Ticket]([ID]),
		CONSTRAINT [FK_Intervention_IDTechnical] FOREIGN KEY ([IDTechnical]) REFERENCES [Technical]([ID]),
		CONSTRAINT [UK_Intervention_IDTicket-IDTechnical-DateBegin-DateEnd] UNIQUE ([IDTicket], [IDTechnical], [DateBegin], [DateEnd])
	);
END