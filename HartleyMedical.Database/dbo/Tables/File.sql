CREATE TABLE [dbo].[File] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [fk_EntityID]  INT           NOT NULL,
    [RecordID]     INT           NOT NULL,
    [fileURL]      VARCHAR (500) NOT NULL,
    [fileType]     VARCHAR (50)  NOT NULL,
    [fileSize]     VARCHAR (50)  NOT NULL,
    [UploadedBy]   INT           NOT NULL,
    [UploadedDate] DATETIME      NOT NULL,
    CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_File_Entity] FOREIGN KEY ([fk_EntityID]) REFERENCES [dbo].[Entity] ([ID]),
    CONSTRAINT [FK_File_User] FOREIGN KEY ([UploadedBy]) REFERENCES [dbo].[User] ([ID])
);

