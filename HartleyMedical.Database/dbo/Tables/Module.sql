CREATE TABLE [dbo].[Module] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [ModuleName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED ([ID] ASC)
);

