CREATE TABLE [dbo].[SystemSettings] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [SettingName]     NVARCHAR (MAX) NULL,
    [SettingKey]      NVARCHAR (MAX) NULL,
    [SettingValue]    NVARCHAR (MAX) NULL,
    [SettingCategory] NVARCHAR (MAX) NULL,
    [Active]          BIT            NOT NULL,
    [Label]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED ([ID] ASC)
);

