CREATE TABLE [dbo].[Action] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [ActionName]  NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED ([ID] ASC)
);

