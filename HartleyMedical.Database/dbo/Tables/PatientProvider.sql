CREATE TABLE [dbo].[PatientProvider] (
    [ID]                INT IDENTITY (1, 1) NOT NULL,
    [fk_PatientID]      INT NOT NULL,
    [fk_ProviderTypeID] INT NOT NULL,
    [fk_ProviderID]     INT NOT NULL,
    [Deleted]           BIT NOT NULL,
    CONSTRAINT [PK_PatientProvider] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientProvider_Patient] FOREIGN KEY ([fk_PatientID]) REFERENCES [dbo].[Patient] ([ID]),
    CONSTRAINT [FK_PatientProvider_Provider] FOREIGN KEY ([fk_ProviderID]) REFERENCES [dbo].[Provider] ([ID]),
    CONSTRAINT [FK_PatientProvider_ProviderType] FOREIGN KEY ([fk_ProviderTypeID]) REFERENCES [dbo].[ProviderType] ([ID])
);

