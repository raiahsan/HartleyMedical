CREATE TABLE [dbo].[ActivityStatus] (
    [ID]     INT          IDENTITY (1, 1) NOT NULL,
    [Status] VARCHAR (50) NOT NULL,
    [Active] INT          NOT NULL,
    CONSTRAINT [PK_ActivityStatus] PRIMARY KEY CLUSTERED ([ID] ASC)
);

