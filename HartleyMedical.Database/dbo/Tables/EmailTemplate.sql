CREATE TABLE [dbo].[EmailTemplate] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [fk_EmailType] INT            NOT NULL,
    [Name]         NVARCHAR (500) NULL,
    [Description]  NVARCHAR (500) NULL,
    [Subject]      NVARCHAR (500) NULL,
    [Body]         NVARCHAR (MAX) NULL,
    [Active]       BIT            NOT NULL,
    [CreatedBy]    INT            NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_EmailTemplates] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EmailTemplate_EmailType] FOREIGN KEY ([fk_EmailType]) REFERENCES [dbo].[EmailType] ([ID]),
    CONSTRAINT [FK_EmailTemplate_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_EmailTemplate_User1] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([ID])
);

