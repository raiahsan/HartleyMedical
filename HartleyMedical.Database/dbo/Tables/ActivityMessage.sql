CREATE TABLE [dbo].[ActivityMessage] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [fk_ActivityID]  INT            NOT NULL,
    [fk_ActivityDirectionID] INT            NOT NULL,
    [Sender]         VARCHAR (50)   NOT NULL,
    [Reipient]       VARCHAR (50)   NOT NULL,
    [Sent]           BIT            NOT NULL,
    [Description]    VARCHAR (2000) NOT NULL,
    CONSTRAINT [PK_ActivityMessage] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Message_Activity] FOREIGN KEY ([fk_ActivityID]) REFERENCES [dbo].[Activity] ([ID]),
    CONSTRAINT [FK_Message_ActivityDirection] FOREIGN KEY ([fk_ActivityDirectionID]) REFERENCES [dbo].[ActivityDirection] ([ID])
);

