USE [HireMe]
GO

/****** Object: Table [dbo].[Transacao] Script Date: 20/02/2017 22:53:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transacao] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [amount] INT           NULL,
    [type]   VARCHAR (100) NULL,
    [card]   INT           NULL,
    [number] INT           NULL
);


