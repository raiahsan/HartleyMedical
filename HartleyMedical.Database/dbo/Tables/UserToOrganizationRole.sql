CREATE TABLE [dbo].[UserToOrganizationRole] (
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [fk_UserID] INT NOT NULL,
    [fk_RoleID] INT NOT NULL,
    [fk_OrganizationID] INT NOT NULL, 
    CONSTRAINT [PK_UserToOrganizationRole] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserToOrganizationRole_Role] FOREIGN KEY ([fk_RoleID]) REFERENCES [dbo].[Role] ([ID]),
    CONSTRAINT [FK_UserToOrganizationRole_User] FOREIGN KEY ([fk_UserID]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_UserToOrganizationRole_Organization] FOREIGN KEY ([fk_OrganizationID]) REFERENCES [dbo].[Organization] ([ID])
);

