CREATE TABLE [dbo].[ActivityEmail] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [fk_ActivityID] INT           NOT NULL,
    [Subject]       VARCHAR (250) NOT NULL,
    [Body]          VARCHAR (MAX) NULL,
    [Sender]        CHAR (100)    NOT NULL,
    [Recipients]    VARCHAR (100) NOT NULL,
    [CC]            VARCHAR (500) NULL,
    [BCC]           VARCHAR (500) NULL,
    CONSTRAINT [PK_ActivityEmail] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Email_Activity] FOREIGN KEY ([fk_ActivityID]) REFERENCES [dbo].[Activity] ([ID])
);

