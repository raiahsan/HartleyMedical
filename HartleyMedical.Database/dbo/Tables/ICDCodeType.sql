CREATE TABLE [dbo].[ICDCodeType] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [TypeName] VARCHAR (50) NOT NULL,
    [Active]   BIT          NOT NULL,
    CONSTRAINT [PK_ICDCodeType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

