CREATE TABLE [dbo].[Location] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [LocationName]      NVARCHAR (50) NOT NULL,
    [fk_FacilityID]     INT           NOT NULL,
    [AddressLine1]      VARCHAR (50)  NOT NULL,
    [AddressLine2]      VARCHAR (50)  NULL,
    [PostalCode]        VARCHAR (50)  NOT NULL,
    [City]              VARCHAR (50)  CONSTRAINT [DF_Location_City] DEFAULT ('') NOT NULL,
    [fk_StateID]        INT           NOT NULL,
    [PhoneNumber]       VARCHAR (11)  NOT NULL,
    [Active] BIT NOT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Location_Facility] FOREIGN KEY ([fk_FacilityID]) REFERENCES [dbo].[Organization] ([ID]),
    CONSTRAINT [FK_Location_CreatedUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_Location_ModifiedUser] FOREIGN KEY ([ModifiedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_Location_State] FOREIGN KEY ([fk_StateID]) REFERENCES [State](ID) 
);

