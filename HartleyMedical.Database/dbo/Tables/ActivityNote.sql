CREATE TABLE [dbo].[ActivityNote] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [fk_ActivityID] INT            NOT NULL,
    [Subject]       VARCHAR (250)  NOT NULL,
    [Description]   VARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_ActivityNote] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Note_Activity] FOREIGN KEY ([fk_ActivityID]) REFERENCES [dbo].[Activity] ([ID])
);

