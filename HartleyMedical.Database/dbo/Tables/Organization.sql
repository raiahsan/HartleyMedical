CREATE TABLE [dbo].[Organization] (
    [ID]                    INT           IDENTITY (1, 1) NOT NULL,
    [FacilityName]          NVARCHAR (50) NOT NULL,
    [fk_OrganizationTypeID] INT           NOT NULL,
    [GroupNPI] VARCHAR(15) NOT NULL, 
    [TaxIdentificationNumber] VARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 0, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Organization_OrganizationType] FOREIGN KEY ([fk_OrganizationTypeID]) REFERENCES [dbo].[OrganizationType] ([ID]), 
    CONSTRAINT [FK_Organization_CreatedUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_Organization_ModifiedUser] FOREIGN KEY ([ModifiedBy]) REFERENCES [User](ID) 
);

