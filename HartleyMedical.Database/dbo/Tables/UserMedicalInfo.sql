CREATE TABLE [dbo].[UserMedicalInfo]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NPINumber] VARCHAR(11) NOT NULL, 
    [fk_MedicalDesignationID] INT NULL DEFAULT NULL, 
    [MedicalLicenseNumber] VARCHAR(50) NOT NULL, 
    [fk_MedicalLicenseStateID] INT NULL DEFAULT NULL, 
    [fk_PrimarySpecialityID] INT NULL DEFAULT NULL, 
    [fk_SecondarySpecialityID] INT NULL DEFAULT NULL, 
    [fk_UserID] INT NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedBy] INT NULL DEFAULT NULL, 
    [ModifiedDate] DATETIME NULL , 
    CONSTRAINT [FK_UserMedicalInfo_MedicalDesignation] FOREIGN KEY ([fk_MedicalDesignationID]) REFERENCES [MedicalDesignation]([ID]), 
    CONSTRAINT [FK_UserMedicalInfo_MedicalLicenseState] FOREIGN KEY ([fk_MedicalLicenseStateID]) REFERENCES [MedicalLicenseState]([ID]), 
    CONSTRAINT [FK_UserMedicalInfo_Speciality_Primary] FOREIGN KEY ([fk_PrimarySpecialityID]) REFERENCES [Speciality]([ID]), 
    CONSTRAINT [FK_UserMedicalInfo_Speciality_Secondary] FOREIGN KEY ([fk_SecondarySpecialityID]) REFERENCES [Speciality]([ID]), 
    CONSTRAINT [FK_UserMedicalInfo_User] FOREIGN KEY ([fk_UserID]) REFERENCES [User]([ID]),
    CONSTRAINT [FK_UserMedicalInfo_CreatedUser] FOREIGN KEY ([CreatedBy]) REFERENCES [User](ID),
    CONSTRAINT [FK_UserMedicalInfo_ModifiedUser] FOREIGN KEY ([ModifiedBy]) REFERENCES [User](ID)
)
