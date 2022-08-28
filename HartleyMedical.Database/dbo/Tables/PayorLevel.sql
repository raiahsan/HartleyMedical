CREATE TABLE [dbo].[PayorLevel] (
    [ID]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Active] BIT          NOT NULL,
    CONSTRAINT [PK_PayorLevel] PRIMARY KEY CLUSTERED ([ID] ASC)
);

