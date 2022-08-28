CREATE TABLE [dbo].[ActivityDirection] (
    [ID]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Active] BIT          NOT NULL,
    CONSTRAINT [PK_ActivityDirection] PRIMARY KEY CLUSTERED ([ID] ASC)
);

