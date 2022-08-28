CREATE TABLE [dbo].[ActivityTask] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [fk_ActivityID] INT           NOT NULL,
    [fk_ActivityStatusID]   INT           NOT NULL,
    [Subject]       VARCHAR (250) NOT NULL,
    [Description]   VARCHAR (MAX) NOT NULL,
    [Due]           DATETIME      NOT NULL,
    [AssignedTo]    INT           NOT NULL,
    CONSTRAINT [PK_ActivityTask] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Task_Activity] FOREIGN KEY ([fk_ActivityID]) REFERENCES [dbo].[Activity] ([ID]),
    CONSTRAINT [FK_Task_ActivityStatus] FOREIGN KEY ([fk_ActivityStatusID]) REFERENCES [dbo].[ActivityStatus] ([ID])
);

