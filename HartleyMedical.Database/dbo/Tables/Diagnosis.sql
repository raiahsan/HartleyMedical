CREATE TABLE [dbo].[Diagnosis] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [ICDCode]          VARCHAR (50)  NOT NULL,
    [fk_ICDCodeTypeID] INT           NOT NULL,
    [Description]      VARCHAR (250) NOT NULL,
    [Active]           BIT           NOT NULL,
    CONSTRAINT [PK_Diagnosis] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Diagnosis_ICDCodeType] FOREIGN KEY ([fk_ICDCodeTypeID]) REFERENCES [dbo].[ICDCodeType] ([ID])
);

