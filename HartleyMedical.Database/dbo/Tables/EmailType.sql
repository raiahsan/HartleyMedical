CREATE TABLE [dbo].[EmailType] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [TypeName] NVARCHAR (50) NOT NULL,
    [Active]   BIT           NOT NULL,
    CONSTRAINT [PK_EmailType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

