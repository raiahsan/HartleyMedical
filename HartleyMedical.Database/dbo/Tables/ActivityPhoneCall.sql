CREATE TABLE [dbo].[ActivityPhoneCall] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [fk_ActivityID]  INT            NOT NULL,
    [fk_ActivityDirectionID] INT            NOT NULL,
    [Subject]        VARCHAR (250)  NOT NULL,
    [Description]    VARCHAR (2000) NOT NULL,
    [LeftVoiceMail]  BIT            NOT NULL,
    [Duration]       TIME (7)       NOT NULL,
    CONSTRAINT [PK_ActivityPhoneCall] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PhoneCall_Activity] FOREIGN KEY ([fk_ActivityID]) REFERENCES [dbo].[Activity] ([ID]),
    CONSTRAINT [FK_PhoneCall_ActivityDirection] FOREIGN KEY ([fk_ActivityDirectionID]) REFERENCES [dbo].[ActivityDirection] ([ID])
);

