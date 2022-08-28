CREATE TABLE [dbo].[State] (
    [ID]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    [Code]   VARCHAR (10) NOT NULL,
    [Active] BIT          NOT NULL,
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([ID] ASC)
);

