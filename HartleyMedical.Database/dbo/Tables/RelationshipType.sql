CREATE TABLE [dbo].[RelationshipType] (
    [ID]     INT          IDENTITY (1, 1) NOT NULL,
    [Type]   VARCHAR (50) NOT NULL,
    [Active] BIT          NOT NULL,
    CONSTRAINT [PK_RelationshipType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

