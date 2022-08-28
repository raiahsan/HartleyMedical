CREATE TABLE [dbo].[Entity] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [EntityName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED ([ID] ASC)
);

