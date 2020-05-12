/* Stored Procude - Type : Insert */

IF (OBJECT_ID('PS_Insert_Administrative') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_Administrative]
			@IDUser INT,
			@Salary FLOAT,
			@InternPhone NVARCHAR(5)
		AS
		BEGIN
			INSERT INTO [Administrative]
				([IDUser], [Salary], [InternPhone])
			VALUES (@IDUser, @Salary, @InternPhone);
		END
	');

IF (OBJECT_ID('PS_Insert_Customer') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_Customer]
			@Name NVARCHAR(50),
			@ZipCode NVARCHAR(4),
			@City NVARCHAR(100),
			@Street NVARCHAR(100),
			@StreetNB NVARCHAR(4),
			@StreetBOX NVARCHAR(2),
			@Tel NVARCHAR(10),
			@Fax NVARCHAR(10),
			@Mail NTEXT
		AS
		BEGIN
			INSERT INTO [Customer]
				([Name], [ZipCode], [City], [Street], [StreetNB], [StreetBOX], [Tel], [Fax], [Mail])
			VALUES (@Name, @ZipCode, @City, @Street, @StreetNB, @StreetBOX, @Tel, @Fax, @Mail);
		END
	');

IF (OBJECT_ID('PS_Insert_Intervention') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_Intervention]
			@IDTicket INT,
			@IDTechnical INT,
			@DateBegin DATETIME,
			@DateEnd DATETIME,
			@Subject NVARCHAR(255),
			@TechnicalNote NTEXT
		AS
		BEGIN
			INSERT INTO [Intervention]
				([IDTicket], [IDTechnical], [DateBegin], [DateEnd], [Subject], [TechnicalNote])
			VALUES (@IDTicket, @IDTechnical, @DateBegin, @DateEnd, @Subject, @TechnicalNote);
		END
	');

IF (OBJECT_ID('PS_Insert_Technical') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_Technical]
			@IDUser INT,
			@HourRate FLOAT,
			@GSM NVARCHAR(10)
		AS
		BEGIN
			INSERT INTO [Technical]
				([IDUser], [HourRate], [GSM])
			VALUES (@IDUser, @HourRate, @GSM);
		END
	');

IF (OBJECT_ID('PS_Insert_Ticket') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_Ticket]
			@IDCustomer INT,
			@IDAdministrative INT,
			@Subject NVARCHAR(255),
			@DateIN DATETIME,
			@Note NTEXT
		AS
		BEGIN
			INSERT INTO [Ticket]
				([IDCustomer], [IDAdministrative], [Subject], [DateIN], [Note], [FFinished])
			VALUES (@IDCustomer, @IDAdministrative, @Subject, @DateIN, @Note, ''False'');
		END
	');

IF (OBJECT_ID('PS_Insert_User') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Insert_User]
			@Usn NVARCHAR(101),
			@Pwd NVARCHAR(100),
			@FName NVARCHAR(50),
			@LName NVARCHAR(50),
			@Mail NTEXT,
			@FAdmin BIT
		AS
		BEGIN
			INSERT INTO [User]
				([Usn], [Pwd], [FName], [LName], [Mail], [FAdmin], [FActive], [FDelete])
			VALUES	(@Usn, @Pwd, @FName, @LName, @Mail, @FAdmin, ''True'', ''False'');
		END
	');

/* Stored Procude - Type : Standard Update */

IF (OBJECT_ID('PS_Update_Administrative') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_Administrative]
			@IDUser INT,
			@Salary FLOAT,
			@InternPhone NVARCHAR(5)
		AS
		BEGIN
			UPDATE	[Administrative]
			SET		[Salary] = @Salary,
					[InternPhone] = @InternPhone
			WHERE	[IDUser] = @IDUser;
		END
	');

IF (OBJECT_ID('PS_Update_Customer') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_Customer]
			@Name NVARCHAR(50),
			@ZipCode NVARCHAR(4),
			@City NVARCHAR(100),
			@Street NVARCHAR(100),
			@StreetNB NVARCHAR(4),
			@StreetBOX NVARCHAR(2),
			@Tel NVARCHAR(10),
			@Fax NVARCHAR(10),
			@Mail NTEXT
		AS
		BEGIN
			UPDATE	[Customer]
			SET		[ZipCode] = @ZipCode,
					[City] = @City,
					[Street] = @Street,
					[StreetNB] = @StreetNB,
					[StreetBOX] = @StreetBOX,
					[Tel] = @Tel,
					[Fax] = @Fax,
					[Mail] = @Mail
			WHERE	[Name] = @Name;
		END
	');

IF (OBJECT_ID('PS_Update_Intervention') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_Intervention]
			@ID INT,
			@IDTicket INT,
			@IDTechnical INT,
			@DateBegin DATETIME,
			@DateEnd DATETIME,
			@Subject NVARCHAR(255),
			@Note NTEXT
		AS
		BEGIN
			UPDATE	[Intervention]
			SET		[IDTicket] = @IDTicket,
					[IDTechnical] = @IDTechnical,
					[DateBegin] = @DateBegin,
					[DateEnd] = @DateEnd,
					[Subject] = @Subject,
					[TechnicalNote] = @Note
			WHERE	[ID] = @ID;
		END
	');

IF (OBJECT_ID('PS_Update_Technical') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_Technical]
			@IDuser INT,
			@HourRate FLOAT,
			@GSM NVARCHAR(10)
		AS
		BEGIN
			UPDATE	[Technical]
			SET		[HourRate] = @HourRate,
					[GSM] = @GSM
			WHERE	[IDUser] = @IDUser;
		END
	');

IF (OBJECT_ID('PS_Update_Ticket') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_Ticket]
			@ID INT,
			@IDCustomer INT,
			@IDAdministrative INT,
			@Subject NVARCHAR(255),
			@DateIN DATETIME,
			@Note NTEXT,
			@FFinished BIT
		AS
		BEGIN
			UPDATE	[Ticket]
			SET		[IDCustomer] = @IDCustomer,
					[IDAdministrative] = @IDAdministrative,
					[Subject] = @Subject,
					[DateIN] = @DateIN,
					[Note] = @Note,
					[FFinished] = @FFinished
			WHERE	[ID] = @ID;
		END
	');

IF (OBJECT_ID('PS_Update_User') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Update_User]
			@ID INT,
			@Usn NVARCHAR(101),
			@Pwd NVARCHAR(100),
			@FName NVARCHAR(50),
			@LName NVARCHAR(50),
			@Mail NTEXT,
			@FAdmin BIT,
			@FActive BIT,
			@FDelete BIT
		AS
		BEGIN
			UPDATE	[User]
			SET		[Usn] = @Usn,
					[Pwd] = @Pwd,
					[FName] = @FName,
					[LName] = @LName,
					[Mail] = @Mail,
					[FAdmin] = @FAdmin,
					[FActive] = @FActive,
					[FDelete] = @FDelete
			WHERE	[ID] = @ID;
		END
	');

/* Stored Procude - Type : Other Update */

IF (OBJECT_ID('PS_Other_ConcludeTicket') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_ConcludeTicket]
			@IDTicket INT
		AS
		BEGIN
			UPDATE	[Ticket]
			SET		[FFinished] = ''true''
			WHERE	[ID] = @IDTIcket;
		END
	');

IF (OBJECT_ID('PS_Other_ReopenTicket') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_ReopenTicket]
			@IDTicket INT
		AS
		BEGIN
			UPDATE	[Ticket]
			SET		[FFinished] = ''false''
			WHERE	[ID] = @IDTicket;
		END
	');

IF (OBJECT_ID('PS_Other_AddTicketNote') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_AddTicketNote]
			@IDTicket INT,
			@Note NTEXT
		AS
		BEGIN
			UPDATE	[Ticket]
			SET		[Note] = @Note
			WHERE	[ID] = @IDTicket;
		END
	');

IF (OBJECT_ID('PS_Other_ActivateUser') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_ActivateUser]
			@Usn NVARCHAR(101)
		AS
		BEGIN
			UPDATE	[User]
			SET		[FActive] = ''true''
			WHERE	[Usn] = @Usn;
		END
	');

IF (OBJECT_ID('PS_Other_DeactivateUser') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_DeactivateUser]
			@Usn NVARCHAR(101)
		AS
		BEGIN
			UPDATE	[User]
			SET		[FActive] = ''false''
			WHERE	[Usn] = @Usn;
		END
	');

IF (OBJECT_ID('PS_Other_ChangeUsername') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_ChangeUsername]
			@IDUser INT,
			@Usn NVARCHAR(101)
		AS
		BEGIN
			UPDATE	[User]
			SET		[Usn] = @Usn
			WHERE	[ID] = @IDUser;
		END
	');

IF (OBJECT_ID('PS_Other_ChangeUserPassword') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_ChangeUserPassword]
			@Usn NVARCHAR(101),
			@Pwd NVARCHAR(100)
		AS
		BEGIN
			UPDATE	[User]
			SET		[Pwd] = @Pwd
			WHERE	[Usn] = @Usn;
		END
	');

IF (OBJECT_ID('PS_Other_AddInterventionNote') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Other_AddInterventionNote]
			@IDIntervention INT,
			@Note NTEXT
		AS
		BEGIN
			UPDATE	[Intervention]
			SET		[TechnicalNote] = @Note
			WHERE	[ID] = @IDIntervention;
		END
	');

/* Stored Procude - Type : Delete/Undelete */

IF (OBJECT_ID('PS_Delete_User') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Delete_User]
			@Usn NVARCHAR(101)
		AS
		BEGIN
			UPDATE	[User]
			SET		[FDelete] = ''true''
			WHERE	[Usn] = @Usn;
		END
	');

IF (OBJECT_ID('PS_Delete_Ticket') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Delete_Ticket]
			@IDTicket INT
		AS
		BEGIN
			DELETE FROM [Ticket]
			WHERE [ID] = @IDTicket;
		END
	');

IF (OBJECT_ID('PS_Delete_Intervention') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Delete_Intervention]
			@IDIntervention INT
		AS
		BEGIN
			DELETE FROM [Intervention]
			WHERE [ID] = @IDIntervention;
		END
	');

IF (OBJECT_ID('PS_Undelete_User') IS NULL)
	EXEC
	('
		CREATE PROCEDURE [PS_Undelete_User]
			@Usn NVARCHAR(101)
		AS
		BEGIN
			UPDATE	[User]
			SET		[FDelete] = ''false''
			WHERE	[Usn] = @Usn;
		END
	');