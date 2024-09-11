-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Brian Wheat
-- Create date: 2024-9-11
-- Description:	adds fizzbuzz results to table
-- =============================================
CREATE PROCEDURE AddFizzBuzzResults
	@Id int,
	@Result varchar(10) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	 

    ALTER TABLE [dbo].[FizzBuzzResults]  
	NOCHECK CONSTRAINT PK_FizzBuzzResults;

	INSERT INTO [dbo].[FizzBuzzResults]
			([Id],[Result])
		VALUES
			(@Id,@Result)

END
GO
