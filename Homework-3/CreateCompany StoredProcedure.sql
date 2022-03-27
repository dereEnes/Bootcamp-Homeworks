USE [LogoDb]
GO

/****** Object:  StoredProcedure [dbo].[CreateCompany]    Script Date: 27.03.2022 20:20:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCompany]
	@Name nvarchar(MAX),
	@Description nvarchar(MAX),
	@Address nvarchar(MAX),
	@City nvarchar(MAX),
	@Country nvarchar(MAX),
	@Location nvarchar(MAX),
	@Phone nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Companies(
		[Name],
		[Description],
		[Address],
		[City],
		[Country],
		[Location],
		[Phone]
		)
VALUES ( @Name, @Description, @Address, @City, @Country, @Location, @Phone )
END
GO

