USE [master]
GO
/****** Object:  Database [UserInfoDB]    Script Date: 14.02.2019 1:43:37 ******/
CREATE DATABASE [UserInfoDB]
 CONTAINMENT = NONE

ALTER DATABASE [UserInfoDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserInfoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserInfoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserInfoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserInfoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserInfoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserInfoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserInfoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserInfoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserInfoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserInfoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserInfoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserInfoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserInfoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserInfoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserInfoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserInfoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserInfoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserInfoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserInfoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserInfoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserInfoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserInfoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserInfoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserInfoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UserInfoDB] SET  MULTI_USER 
GO
ALTER DATABASE [UserInfoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserInfoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserInfoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserInfoDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UserInfoDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UserInfoDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](25) NOT NULL,
	[Password] [varchar](1200) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](25) NOT NULL,
	[ImageID] [int] NULL,
 CONSTRAINT [PK_AWARD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Award__2CB664DCD62F87CA] UNIQUE NONCLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MimeType] [varchar](100) NOT NULL,
	[ImageData] [varchar](max) NOT NULL,
 CONSTRAINT [PK_IMAGE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Role__8A2B6160400ED1D5] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Surname] [nvarchar](250) NOT NULL,
	[Patronymic] [nvarchar](250) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[ImageID] [int] NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAwards]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAwards](
	[UserID] [int] NOT NULL,
	[AwardID] [int] NOT NULL,
 CONSTRAINT [PK_UsersAwards] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AwardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [Award_fk0] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [Award_fk0]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [User_fk0] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [User_fk0]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [UsersAwards_fk0] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [UsersAwards_fk0]
GO
ALTER TABLE [dbo].[UsersAwards]  WITH CHECK ADD  CONSTRAINT [UsersAwards_fk1] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Award] ([ID])
GO
ALTER TABLE [dbo].[UsersAwards] CHECK CONSTRAINT [UsersAwards_fk1]
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAccount]
	@Login varchar(25),
	@Password varchar(1200),
	@RoleID int 
AS
BEGIN
	INSERT INTO dbo.Account (Login, Password, RoleID) VALUES (@Login, @Password, @RoleId); 
	SELECT scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
	@Title nvarchar(25),
	@AwardImageId int
AS
BEGIN
	INSERT INTO dbo.[Award] (Title, ImageID) VALUES (@Title, @AwardImageId); SELECT scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@Name nvarchar(250),
	@Surname nvarchar(250),
	@Patronymic nvarchar(250),
	@DateOfBirth datetime
AS
BEGIN
	INSERT INTO dbo.[User] (Name, Surname, Patronymic, DateOfBirth) VALUES (@Name, @Surname, @Patronymic, @DateOfBirth); 
	SELECT scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[AddUsersAwards]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUsersAwards]
	@UserID int,
	@AwardID int
AS
BEGIN
	INSERT INTO dbo.[UsersAwards] (UserID, AwardID) VALUES (@UserID, @AwardID); 
	SELECT scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[Awards_AddImageToAward]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Awards_AddImageToAward]
	@AwardId int,
	@ImageId int
AS
BEGIN
	UPDATE [dbo].[Award]
	SET [ImageID] = @ImageId
	WHERE [Id] = @AwardId
END
GO
/****** Object:  StoredProcedure [dbo].[Awards_GetAwardByTitle]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Awards_GetAwardByTitle]
	@AwardTitle nvarchar(25)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [Id], [Title], [ImageID] FROM [dbo].[Award]
	WHERE [Title] = @AwardTitle
END
GO
/****** Object:  StoredProcedure [dbo].[AwardsImage_AddDefault]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AwardsImage_AddDefault]
	@MimeType varchar(100),
	@ImageData varchar(MAX)
AS
BEGIN
	INSERT INTO [dbo].[Image] (MimeType, ImageData)	VALUES (@MimeType, @ImageData)
END
GO
/****** Object:  StoredProcedure [dbo].[AwardsImages_Add]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AwardsImages_Add]
	@MimeType varchar(100),
	@ImageData varchar(MAX),
	@Id int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].[Image] (MimeType, ImageData) VALUES (@MimeType, @ImageData)
	SET @Id = scope_identity()
END
GO
/****** Object:  StoredProcedure [dbo].[AwardsImages_GetById]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AwardsImages_GetById]
	@ImageId int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [Id], [MimeType], [ImageData] FROM [dbo].[Image]
	WHERE [Id] = @ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[AwardsImages_RemoveImage]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AwardsImages_RemoveImage]
	@ImageId int
AS
BEGIN
	DELETE FROM [dbo].[Image]
	WHERE [Id] = @ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[ChangeAccountRole]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ChangeAccountRole]
	@Id int,
	@RoleId int
AS
BEGIN
	UPDATE dbo.[Account] SET RoleID=@RoleId WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountById]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountById]
	@Id int
AS
BEGIN
	SELECT ID FROM dbo.[Account] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByIdFull]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountByIdFull]
	@Id int
AS
BEGIN
	SELECT ID, Login, RoleID FROM dbo.[Account] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByLogin]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountByLogin]
	@Login varchar(25)
AS
BEGIN
	SELECT Login FROM dbo.Account WHERE Login=@Login
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByLoginAndPassword]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountByLoginAndPassword]
	@Login varchar(25),
	@Password varchar(1200)
AS
BEGIN
	SELECT Login, Password FROM dbo.Account WHERE (Login=@Login) AND (Password=@Password)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAccountsRoles]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAccountsRoles]
	
AS
BEGIN
	SELECT dbo.Role.RoleName FROM dbo.Role INNER JOIN dbo.Account ON dbo.Role.ID=dbo.Account.RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById]
	@ID int
AS
BEGIN
	SELECT ID FROM dbo.[Award] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardByIdFull]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByIdFull]
	@Id int
AS
BEGIN
	SELECT ID, Title, ImageID FROM dbo.[Award] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwards]
	
AS
BEGIN
	SELECT Title, ID, ImageID FROM dbo.Award
END
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRole]
	@Login varchar(25)
AS
BEGIN
	SELECT RoleName FROM dbo.Role WHERE ID IN (SELECT RoleID FROM dbo.Account WHERE Login = @Login)
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserAwardsIds]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserAwardsIds]
	@Id int
AS
BEGIN
	SELECT AwardID FROM dbo.[UsersAwards] WHERE UserID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
BEGIN
	SELECT ID FROM dbo.[User] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByIdFull]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByIdFull]
	@Id int
AS
BEGIN
	SELECT ID, Name, Surname, Patronymic, DateOfBirth FROM dbo.[User] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsers]
	
AS
BEGIN
	SELECT ID, Name, Surname, Patronymic, DateOfBirth FROM dbo.[User]
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersAwardsByAwardId]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsersAwardsByAwardId]
	@ID int
AS
BEGIN
	SELECT AwardID FROM dbo.[UsersAwards] WHERE AwardID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAward]
	@Id int
AS
BEGIN
	DELETE FROM dbo.[Award] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardCascade]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveAwardCascade]
	@Id int
AS
BEGIN
	DELETE FROM dbo.[UsersAwards] WHERE AwardID=@Id; 
	DELETE FROM dbo.[Award] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveUser]
	@Id int
AS
BEGIN
	DELETE FROM dbo.[UsersAwards] WHERE UserID = @Id
	DELETE FROM dbo.[User] WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@Id int,
	@Title nvarchar(25)
AS
BEGIN
	UPDATE dbo.[Award] SET Title=@Title WHERE ID=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 14.02.2019 1:43:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@Id int,
	@Name nvarchar(250),
	@Surname nvarchar(250),
	@Patronymic nvarchar(250),
	@DateOfBirth datetime
AS
BEGIN
	UPDATE dbo.[User] SET Name=@Name, Surname=@Surname, Patronymic=@Patronymic, DateOfBirth=@DateOfBirth WHERE ID=@Id
END
GO
USE [master]
GO
ALTER DATABASE [UserInfoDB] SET  READ_WRITE 
GO
