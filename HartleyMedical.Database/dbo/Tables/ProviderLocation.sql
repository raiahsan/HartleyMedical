CREATE TABLE [dbo].[ProviderLocation] (
    [ID]            INT IDENTITY (1, 1) NOT NULL,
    [fk_ProviderID] INT NOT NULL,
    [fk_LocationID] INT NOT NULL,
    CONSTRAINT [PK_ProviderLocation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ProviderLocation_Location] FOREIGN KEY ([fk_LocationID]) REFERENCES [dbo].[Location] ([ID]),
    CONSTRAINT [FK_ProviderLocation_Provider] FOREIGN KEY ([fk_ProviderID]) REFERENCES [dbo].[Provider] ([ID])
);

