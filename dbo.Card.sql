USE [HireMe]
GO

/****** Object: Table [dbo].[Card] Script Date: 20/02/2017 22:53:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Card] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [cardholderName] VARCHAR (100) NOT NULL,
    [number]         BIGINT        NULL,
    [expirationDate] DATE          NULL,
    [cardBrand]      VARCHAR (100) NULL,
    [password]       INT           NULL,
    [type]           VARCHAR (100) NULL,
    [hasPassword]    BIT           NULL,
    [limit]          FLOAT (53)    NULL
);


