USE [sunil]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[RegID] [int] IDENTITY(1,1) NOT NULL,
	[RegName] [varchar](100) NULL,
	[RegUserName] [varchar](100) NOT NULL,
	[RegPassword] [varchar](15) NULL,
	[RegConfirmPassword] [varchar](15) NULL,
	[RegEMail] [varchar](50) NULL,
	[RegAddress] [varchar](50) NULL,
	[RegPhone] [varchar](12) NULL,
	[RegCompany] [varchar](100) NULL,
	[TimeStamp] [smalldatetime] NULL,
	[AdminName] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RegUserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FriendDetails]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FriendDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[Education] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[Phone] [nchar](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IssueRecords]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IssueRecords](
	[IID] [int] NOT NULL,
	[Issue_ID] [char](12) NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[BID] [smallint] NOT NULL,
	[BookName] [nvarchar](256) NOT NULL,
	[Category] [varchar](50) NULL,
	[IssueDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	[ActualReturnDate] [date] NULL,
	[MailSendDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contact No] [nchar](20) NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[Posting Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DropDownValues]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DropDownValues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sorting] [int] NULL,
	[GroupId] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[Values] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewBookEntry]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewBookEntry](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[Book_ID]  AS ('BK0000'+CONVERT([varchar](100),[BID],(0))),
	[BookName] [nvarchar](100) NULL,
	[AuthorName] [varchar](100) NULL,
	[Publisher] [nvarchar](100) NULL,
	[Category] [varchar](100) NULL,
	[ISBN] [char](100) NULL,
	[PublishYear] [char](10) NULL,
	[Available] [bit] NULL,
	[Requested] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewAdmin]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewAdmin](
	[adminName] [varchar](50) NULL,
	[adminPassword] [varchar](50) NULL,
	[AdminCode] [int] IDENTITY(1001,1) NOT NULL,
	[AdminPhone] [varchar](15) NOT NULL,
	[AdminAddress] [varchar](200) NULL,
	[AdminDesignation] [varchar](200) NULL,
	[AdminCategory] [varchar](50) NULL,
	[AdminDate] [smalldatetime] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[Active] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Library_User]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library_User](
	[UserName] [nvarchar](256) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Age] [tinyint] NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[EMailID] [nvarchar](100) NULL,
	[ContactNo] [numeric](12, 0) NULL,
	[Address] [nvarchar](max) NULL,
	[DemandDraftNo] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastUpdatedUser]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LastUpdatedUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdminName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[LastUpdated] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BuyBooks]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyBooks](
	[BookName] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BookImage] [nvarchar](100) NULL,
	[Price] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeleteRequest]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeleteRequest](
	[UserName] [nvarchar](256) NOT NULL,
	[EmailID] [nvarchar](100) NOT NULL,
	[RequestDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeletedAccount]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeletedAccount](
	[DelID] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[EmailID] [nvarchar](100) NOT NULL,
	[ContactNo] [numeric](12, 0) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[DeletedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsertCapData]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InsertCapData](
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Hobbies] [nvarchar](200) NULL,
	[Gender] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InfoBook]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InfoBook](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[Book_ID]  AS ('BK0000'+CONVERT([varchar](100),[BID],(0))),
	[BookName] [nvarchar](100) NULL,
	[AuthorName] [varchar](100) NULL,
	[Publisher] [nvarchar](100) NULL,
	[Category] [varchar](100) NULL,
	[ISBN] [char](100) NULL,
	[PublishYear] [char](10) NULL,
	[Available] [bit] NULL,
	[Requested] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetUserInAdminUpdate]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserInAdminUpdate]
@RegUserName varchar(50)
AS
BEGIN
DECLARE @Name varchar(50)
IF EXISTS(SELECT * FROM UserRegistration WHERE RegUserName=@RegUserName)
BEGIN
	SELECT RegName,RegPassword,RegAddress,RegPhone,RegCompany,RegEMail FROM UserRegistration
	WHERE RegUserName=@RegUserName
	
END
ELSE
BEGIN
	PRINT 'USER DOES NOT EXISTS'
	RETURN -1
END
END


--GetUserInAdminUpdate 'SIPRAAA'
GO
/****** Object:  StoredProcedure [dbo].[GetUserForAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserForAdmin]
AS
BEGIN
	SELECT ResultName=RegUserName FROM UserRegistration WHERE IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserDetailsInAdminPopup]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserDetailsInAdminPopup]
@RegUserName varchar(50)
AS
BEGIN
IF NOT EXISTS(SELECT AdminName FROM UserRegistration WHERE RegUserName=@RegUserName AND IsActive= 1)
BEGIN
	SELECT RegName, RegUserName, RegPassword, RegEMail, RegAddress, RegPhone, RegCompany FROM UserRegistration
	WHERE RegUserName=@RegUserName AND IsActive= 1
END
ELSE
BEGIN
	SELECT RegName, RegUserName, RegPassword, RegEMail, RegAddress, RegPhone, RegCompany,
	AdminName,[TimeStamp] FROM UserRegistration WHERE RegUserName=@RegUserName AND IsActive= 1
END
if( 1 = 2)
begin
	select * from UserRegistration
end
END
GO
/****** Object:  StoredProcedure [dbo].[GetOnlineBookSearch]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetOnlineBookSearch]
@BookName varchar(100),
@ISBN varchar(50),
@AuthorName varchar(100),
@Category varchar(100)
AS
 --EXEC GetOnlineBookSearch 'Enslaved, The New Slavery','','','--select--'
 --EXEC GetOnlineBookSearch '','','','--Select--'
BEGIN
DECLARE @BookSelect nvarchar(max)= ' '
DECLARE @WHERE NVARCHAR(MAX) = ' WHERE 1 = 1'
DECLARE @AND NVARCHAR(100) = ' AND '
DECLARE @SQL NVARCHAR(MAX) = 'select Book_ID, ISBN, BookName, AuthorName, Publisher, Category from dbo.InfoBook '
IF @BookName <> '' OR @ISBN <> '' OR @AuthorName <> '' OR @Category <> '--Select--'
BEGIN
	set @SQL = @SQL + @WHERE
	IF @BookName <> ''
		set @SQL = @SQL +  @AND+ ' BookName like ' +'''%'+@BookName+'%'''
	IF @ISBN <> ''
		SET @SQL = @SQL +  @AND+ ' ISBN LIKE '+'''%'+@ISBN+'%'''
	IF @AuthorName <> ''
		SET @SQL = @SQL +  @AND+ ' AuthorName LIKE '+'''%'+@AuthorName+'%'''
	IF @Category <> '--Select--'
		SET @SQL = @SQL +  @AND+ ' Category LIKE '+'''%'+@Category+'%'''
END
ELSE
BEGIN
	IF(1 = 2)
	BEGIN
		select Book_ID, ISBN, BookName, AuthorName, Publisher, Category from dbo.InfoBook
	END
	ELSE
	BEGIN
		SET @BookSelect = ' where 1 = 1 '
		SET @SQL = @SQL + @BookSelect
	END
END
PRINT @SQL
EXECUTE SP_EXECUTESQL @SQL
END
GO
/****** Object:  StoredProcedure [dbo].[GetFriend]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetFriend]
AS
BEGIN
SELECT * FROM frienddetails
END
GO
/****** Object:  StoredProcedure [dbo].[GetDropDownListInfoBook]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDropDownListInfoBook]
@Action int
AS
begin
if (@Action = 1)
begin
	select distinct Category from dbo.InfoBook order by Category
end
if(@Action = 2)
begin
	select distinct RegUserName from UserRegistration where IsActive=1 
end
end
GO
/****** Object:  StoredProcedure [dbo].[GetBookDetailsByBookID]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetBookDetailsByBookID]
@BookID VARCHAR(50)
AS
BEGIN
SELECT BookName,AuthorName,Publisher,Category,ISBN,PublishYear FROM InfoBook WHERE Book_ID=LTRIM(RTRIM(@BookID))
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdminDropDown]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAdminDropDown]
AS
BEGIN
select distinct [Values] from dbo.DropDownValues order by [Values] asc
END
GO
/****** Object:  Table [dbo].[COMMENTS]    Script Date: 11/02/2012 08:30:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMMENTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[ComName] [varchar](50) NULL,
	[ComEMail] [varchar](50) NULL,
	[ComLocation] [varchar](50) NULL,
	[ComComments] [nvarchar](500) NULL,
	[time] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CheckUserInAdmin]    Script Date: 11/02/2012 08:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CheckUserInAdmin]
@UserName varchar(50)
AS
BEGIN
IF EXISTS(SELECT * FROM UserRegistration WHERE RegUserName=LTRIM(RTRIM(@UserName)))
BEGIN
	print 'yes1'
	RETURN 1
END
IF EXISTS(SELECT * FROM NewAdmin WHERE adminName=LTRIM(RTRIM(@UserName)))
BEGIN
	print 'yes2'
	RETURN 1
END
ELSE
	print 'no'
	RETURN 0
END

--
GO
/****** Object:  StoredProcedure [dbo].[AllInfoBook]    Script Date: 11/02/2012 08:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AllInfoBook]
@BookID VARCHAR(50)
AS
BEGIN
IF @BookID IS NULL
BEGIN
	SELECT Book_ID,ISBN,BookName,AuthorName,Publisher,Category, PublishYear FROM InfoBook
END
ELSE
BEGIN
	SELECT BookName,AuthorName,Publisher,Category,ISBN,PublishYear FROM InfoBook WHERE Book_ID=LTRIM(RTRIM(@BookID))
END
END
GO
/****** Object:  StoredProcedure [dbo].[AdminSearchList]    Script Date: 11/02/2012 08:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AdminSearchList]
@AdminName varchar(50)
AS
BEGIN
SELECT adminName, adminPassword, AdminCode, AdminPhone, AdminAddress, AdminDesignation, AdminCategory,
Active FROM NewAdmin WHERE adminName=LTRIM(RTRIM(@AdminName))
END
GO
/****** Object:  StoredProcedure [dbo].[AdminNameList]    Script Date: 11/02/2012 08:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AdminNameList]
@AdminName varchar(50)
AS
BEGIN
IF @AdminName IS NOT NULL
BEGIN
SELECT adminName, adminPassword,AdminCode,AdminPhone,AdminCategory, AdminDesignation,AdminAddress FROM NewAdmin WHERE adminName=LTRIM(RTRIM(@AdminName))
END
ELSE
BEGIN
SELECT adminName FROM NewAdmin
END
END
GO
/****** Object:  StoredProcedure [dbo].[LastUpdatedDetails]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LastUpdatedDetails]
@UserName varchar(50)
AS
BEGIN
select max(AdminName) AS AdminName, max(LastUpdated) AS LastUpdated from LastUpdatedUser 
where UserName=LTRIM(RTRIM(@UserName))
END
GO
/****** Object:  StoredProcedure [dbo].[LastUpdatedByAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from dbo.UserRegistration

--CREATE TABLE LastUpdatedUser
--(
--ID int identity(1,1),
--UserName varchar(50) not null,
--LastUpdated datetime default (getdate())
--)

CREATE PROC [dbo].[LastUpdatedByAdmin]
@AdminName varchar(50),
@UserName varchar(50)
AS
BEGIN
INSERT INTO LastUpdatedUser (AdminName,UserName)
SELECT @AdminName,@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserAcInAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteUserAcInAdmin]
@Name varchar(50)
AS
BEGIN
IF EXISTS(SELECT * FROM UserRegistration WHERE RegUserName=@Name)
	BEGIN
		delete from UserRegistration
		WHERE RegUserName=@Name
		return 0	
	END
else
		return -1
END


--DeleteUserAcInAdmin 'SUNIL'
GO
/****** Object:  StoredProcedure [dbo].[InsertSingleBook]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertSingleBook]
@BookName varchar(100),
@AuthorName varchar(100),
@Publisher varchar(100),
@Category varchar(100),
@ISBN varchar(50),
@PublishYear int
AS
BEGIN
IF EXISTS (SELECT * FROM InfoBook WHERE BookName=@BookName AND AuthorName=@AuthorName AND ISBN=@ISBN)
	RETURN -1
ELSE
BEGIN
	INSERT INTO InfoBook (BookName, AuthorName, Publisher, Category, ISBN,PublishYear)
	SELECT @BookName,@AuthorName,@Publisher,@Category,@ISBN,@PublishYear
	RETURN 0
END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertNewUser]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertNewUser]
@RegName VARCHAR(100),
@RegUserName VARCHAR(100),
@RegPassword VARCHAR(15), 
@RegConfirmPassword VARCHAR(15), 
@RegEMail VARCHAR(50),
@RegAddress VARCHAR(50),
@RegPhone VARCHAR(12),
@RegCompany VARCHAR(100)
AS
BEGIN
IF EXISTS(SELECT RegUserName FROM UserRegistration WHERE RegUserName=@RegUserName and IsActive = 1)
BEGIN
	RETURN -1
END
ELSE
INSERT INTO UserRegistration
(RegName, RegUserName, RegPassword, RegConfirmPassword, RegEMail, RegAddress, RegPhone, RegCompany)
SELECT @RegName,@RegUserName,@RegPassword,@RegConfirmPassword,@RegEMail,@RegAddress,@RegPhone,@RegCompany
	RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[InsertNewAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertNewAdmin]
@adminName varchar(50),
@adminPassword varchar(50),
@AdminPhone varchar(15),
@AdminAddress varchar(200),
@AdminDesignation varchar(200),
@AdminCategory varchar(50)
AS
BEGIN
IF EXISTS(SELECT * FROM dbo.NewAdmin WHERE adminName=@adminName)
	RETURN -1
ELSE
BEGIN
	DECLARE @AdminCode INT
	INSERT INTO dbo.NewAdmin (
	adminName, adminPassword,  AdminPhone, AdminAddress, AdminDesignation, AdminCategory)
	SELECT @adminName,@adminPassword,@AdminPhone,@AdminAddress,@AdminDesignation,@AdminCategory
	SELECT @AdminCode=ADMINCODE FROM NewAdmin WHERE adminName=@adminName
	RETURN @AdminCode
END
END
GO
/****** Object:  StoredProcedure [dbo].[validateUserName]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[validateUserName]
@USER VARCHAR(50),
@PASS VARCHAR(50)
AS

BEGIN
	SELECT Result=COUNT(0) FROM UserRegistration WHERE RegUserName = @USER and RegPassword = @PASS and IsActive = 1
END

--[validateUserName] NULL, NULL, 2
GO
/****** Object:  StoredProcedure [dbo].[ValidateAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ValidateAdmin]
@adminName varchar(50),
@AdminPassword varchar(50),
@adminCode int,
@adminCategory varchar(50)
AS
BEGIN
IF EXISTS(SELECT * FROM NewAdmin WHERE adminName=@adminName AND adminPassword=@AdminPassword and AdminCode=@adminCode AND AdminCategory=@adminCategory)
BEGIN
	print 'user exists'
	RETURN 0
END
ELSE
BEGIN
	print 'user does not exists'
	RETURN -1
END
END

/*
ValidateAdmin 'sunil','kumar',1001,'GLOBAL'
select * from NewAdmin

*/
GO
/****** Object:  StoredProcedure [dbo].[ForgotPassword]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ForgotPassword]
@UserName varchar(50),
@EMail varchar(50),
@NewPass varchar(50),
@confirmPass varchar(50)
AS
BEGIN
IF EXISTS(SELECT * FROM UserRegistration WHERE RegUserName=LTRIM(RTRIM(@UserName)) AND RegEMail=LTRIM(RTRIM(@EMail)))
BEGIN
	UPDATE UserRegistration
	SET RegPassword=@NewPass, RegConfirmPassword=@confirmPass
	WHERE RegUserName=LTRIM(RTRIM(@UserName)) AND RegEMail=LTRIM(RTRIM(@EMail))
	RETURN 1
END
ELSE
BEGIN
	RETURN -1
END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserFromAdmin]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateUserFromAdmin]
@RegName varchar(50),
@RegUserName varchar(50),
@RegEMail varchar(50),
@RegAddress varchar(50),
@RegPhone varchar(50),
@RegCompany varchar(50),
@AdminName varchar(50)
AS
BEGIN
UPDATE UserRegistration
SET RegName=@RegName , RegEMail=@RegEMail, RegAddress=@RegAddress, RegPhone=@RegPhone, AdminName=@AdminName,
RegCompany=@RegCompany, TimeStamp=GETDATE() where RegUserName=@RegUserName AND IsActive = 1
return 0
END
GO
/****** Object:  StoredProcedure [dbo].[ShowAllComments]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ShowAllComments]
AS
BEGIN
SELECT top 10 ComName,ComComments,[time] FROM COMMENTS order by time desc
END
GO
/****** Object:  StoredProcedure [dbo].[InsertComments]    Script Date: 11/02/2012 08:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertComments]
@UserName varchar(50),
@ComName varchar(50),
@ComEMail varchar(50),
@ComLocation varchar(50),
@ComComments nvarchar(500)
AS
BEGIN
IF(@UserName IS NOT null AND @ComName IS NOT null AND @ComEMail IS NOT NULL AND @ComLocation IS NOT NULL AND @ComComments IS NOT NULL)
BEGIN
INSERT INTO COMMENTS (UserName, ComName, ComEMail, ComLocation, ComComments)
SELECT @UserName,@ComName,@ComEMail,@ComLocation,@ComComments
RETURN 0
END
ELSE
	RETURN 1
END
GO
/****** Object:  Default [DF__COMMENTS__time__2C3393D0]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[COMMENTS] ADD  DEFAULT (getdate()) FOR [time]
GO
/****** Object:  Default [DF__InfoBook2__Avail__5629CD9C]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[InfoBook] ADD  DEFAULT ((1)) FOR [Available]
GO
/****** Object:  Default [DF__InfoBook2__Reque__571DF1D5]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[InfoBook] ADD  DEFAULT ((0)) FOR [Requested]
GO
/****** Object:  Default [DF__LastUpdat__LastU__31EC6D26]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[LastUpdatedUser] ADD  DEFAULT (getdate()) FOR [LastUpdated]
GO
/****** Object:  Default [DF__Admin__AdminDate__145C0A3F]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[NewAdmin] ADD  DEFAULT (getdate()) FOR [AdminDate]
GO
/****** Object:  Default [DF__Admin__UserID__15502E78]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[NewAdmin] ADD  DEFAULT (newid()) FOR [UserID]
GO
/****** Object:  Default [DF__Admin__Active__164452B1]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[NewAdmin] ADD  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF__NewBookEn__Avail__5CD6CB2B]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[NewBookEntry] ADD  DEFAULT ((1)) FOR [Available]
GO
/****** Object:  Default [DF__NewBookEn__Reque__5DCAEF64]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[NewBookEntry] ADD  DEFAULT ((0)) FOR [Requested]
GO
/****** Object:  Default [DF__UserRegis__TimeS__37A5467C]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[UserRegistration] ADD  DEFAULT (getdate()) FOR [TimeStamp]
GO
/****** Object:  Default [DF_UserRegistration_IsActive]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[UserRegistration] ADD  CONSTRAINT [DF_UserRegistration_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  ForeignKey [FK_COMMENTS_UserRegistration_RegUserName]    Script Date: 11/02/2012 08:30:08 ******/
ALTER TABLE [dbo].[COMMENTS]  WITH CHECK ADD  CONSTRAINT [FK_COMMENTS_UserRegistration_RegUserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[UserRegistration] ([RegUserName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COMMENTS] CHECK CONSTRAINT [FK_COMMENTS_UserRegistration_RegUserName]
GO
