CREATE TABLE [dbo].[ApiLog] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [RequestURL]         VARCHAR (250)  NULL,
    [IPAddress]          VARCHAR (30)   NULL,
    [RequestByURL]       VARCHAR (100)  NULL,
    [RequestBody]        NVARCHAR (MAX) NULL,
    [Response]           NVARCHAR (MAX) NULL,
    [ResponseStatusCode] INT            NOT NULL,
    [RequestAt]          DATETIME2 (7)  NOT NULL,
    [ResponseAt]         DATETIME2 (7)  NULL,
    CONSTRAINT [PK_ApiLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);

