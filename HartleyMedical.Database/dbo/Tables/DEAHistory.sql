CREATE TABLE [dbo].[DEAHistory]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IsExpired] BIT NOT NULL, 
    [ValidFrom] DATETIME NOT NULL, 
    [ValidTo] DATETIME NOT NULL, 
    [VerificationBy] VARCHAR(50) NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [fk_UserID] INT NOT NULL, 
    CONSTRAINT [FK_DEAHistory_User] FOREIGN KEY ([fk_UserID]) REFERENCES [User]([ID]),
    CONSTRAINT [FK_DEAHistory_CreatedUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_DEAHistory_ModifiedUser] FOREIGN KEY ([ModifiedBy]) REFERENCES [User](ID)
)
