CREATE TABLE [dbo].[Role] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [RoleName] VARCHAR (50) NOT NULL,
    [Active]   BIT          NOT NULL,
    [Description] VARCHAR(255) NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL,
    [fk_UserTypeID] INT NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Role_CreatedUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_Role_ModifiedUser] FOREIGN KEY ([ModifiedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_Role_UserType] FOREIGN KEY ([fk_UserTypeID]) REFERENCES [UserType](ID) 
);

