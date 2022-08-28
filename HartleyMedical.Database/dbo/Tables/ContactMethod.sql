CREATE TABLE [dbo].[ContactMethod] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (255) NOT NULL,
    [Active] BIT           NOT NULL,
    CONSTRAINT [PK_ContactMethod] PRIMARY KEY CLUSTERED ([ID] ASC)
);

