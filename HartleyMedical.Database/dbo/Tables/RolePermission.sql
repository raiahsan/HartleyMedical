CREATE TABLE [dbo].[RolePermission] (
    [ID]           INT      IDENTITY (1, 1) NOT NULL,
    [fk_ActionToModuleID]  INT      NOT NULL,
    [fk_RoleID]    INT      NOT NULL,
    [Active]       BIT      NOT NULL,
    [CreatedBy]    INT      NOT NULL,
    [CreatedDate]  DATETIME NOT NULL,
    [ModifiedBy]   INT      NULL,
    [ModifiedDate] DATETIME NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_RolePermission_ActionToModule] FOREIGN KEY ([fk_ActionToModuleID]) REFERENCES [dbo].[ActionToModule] ([ID]),
    CONSTRAINT [FK_RolePermission_Role] FOREIGN KEY ([fk_RoleID]) REFERENCES [dbo].[Role] ([ID])
);

