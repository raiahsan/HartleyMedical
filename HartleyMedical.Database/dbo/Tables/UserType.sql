CREATE TABLE [dbo].[UserType] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

