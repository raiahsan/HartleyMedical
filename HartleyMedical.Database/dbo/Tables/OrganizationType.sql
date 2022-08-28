CREATE TABLE [dbo].[OrganizationType] (
    [ID]       INT           IDENTITY (1, 1) NOT NULL,
    [TypeName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrganizationType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

