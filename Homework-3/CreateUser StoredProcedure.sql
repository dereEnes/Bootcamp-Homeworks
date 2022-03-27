USE [LogoDb]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 27.03.2022 20:21:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUser]
	@FirstName nvarchar(MAX),
	@LastName nvarchar(MAX),
	@City nvarchar(MAX),
	@District nvarchar(MAX),
	@DateOfBorn datetime2(7),
	@CompanyId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Users(
		[FirstName],
		[LastName],
		[City],
		[District],
		[DateOfBorn],
		[CompanyId]
		)
VALUES ( @FirstName, @LastName, @City, @District, @DateOfBorn, @CompanyId )
END
GO

