CREATE TABLE [dbo].[PatientAddress] (
    [ID]                INT          IDENTITY (1, 1) NOT NULL,
    [fk_PatientID]      INT          NOT NULL,
    [fk_AddressTypeID]  INT          NOT NULL,
    [AddressLine1]      VARCHAR (50) NOT NULL,
    [AddressLine2]      VARCHAR (50) NOT NULL,
    [PostalCode]        VARCHAR (50) NOT NULL,
    [City]              VARCHAR (50) CONSTRAINT [DF__PatientAdd__City__3F466844] DEFAULT ('') NOT NULL,
    [fk_StateID]        INT          NOT NULL,
    [PhoneNumber]       VARCHAR (11) NOT NULL,
    [MobileNumber]      VARCHAR (11) NOT NULL,
    [ContactPersonName] VARCHAR (50) NOT NULL,
    [CreatedBy]         INT          NOT NULL,
    [CreatedDate]       DATETIME     NOT NULL,
    [ModifiedBy]        INT          NULL,
    [ModifiedDate]      DATETIME     NULL,
    CONSTRAINT [PK_PatientAddress] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientAddress_AddressType] FOREIGN KEY ([fk_AddressTypeID]) REFERENCES [dbo].[AddressType] ([ID]),
    CONSTRAINT [FK_PatientAddress_Patient] FOREIGN KEY ([fk_PatientID]) REFERENCES [dbo].[Patient] ([ID]),
    CONSTRAINT [FK_PatientAddress_State] FOREIGN KEY ([fk_StateID]) REFERENCES [dbo].[State] ([ID])
);

