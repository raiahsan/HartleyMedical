CREATE TABLE [dbo].[ExceptionLog] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [EntityName]   NVARCHAR (MAX) NULL,
    [EntityID]     INT            NOT NULL,
    [Method]       VARCHAR (50)   NULL,
    [JSON]         NVARCHAR (MAX) NULL,
    [RequestUrl]   VARCHAR (100)  NULL,
    [RequestJSON]  NVARCHAR (MAX) NULL,
    [Exception]    NVARCHAR (MAX) NULL,
    [CreatedBy]    INT            NOT NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

