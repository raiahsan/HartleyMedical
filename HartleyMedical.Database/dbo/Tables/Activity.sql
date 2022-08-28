CREATE TABLE [dbo].[Activity] (
    [ID]                INT      IDENTITY (1, 1) NOT NULL,
    [fk_PatientID]      INT      NOT NULL,
    [fk_ActivityTypeID] INT      NOT NULL,
    [Trackable]         BIT      NOT NULL,
    [Deleted]           BIT      NOT NULL,
    [CreatedBy]         INT      NOT NULL,
    [CreatedDate]       DATETIME NOT NULL,
    [ModifiedBy]        INT      NULL,
    [ModifiedDate]      DATETIME NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Activity_ActivityType] FOREIGN KEY ([fk_ActivityTypeID]) REFERENCES [dbo].[ActivityType] ([ID]),
    CONSTRAINT [FK_Activity_Patient] FOREIGN KEY ([fk_PatientID]) REFERENCES [dbo].[Patient] ([ID]),
    CONSTRAINT [FK_Activity_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_Activity_User1] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([ID])
);

