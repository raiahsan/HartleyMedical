CREATE TABLE [dbo].[PatientDiagnosis] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [fk_PatientID]     INT           NOT NULL,
    [fk_DiagnosisID]   INT           NOT NULL,
    [Sequence]         VARCHAR (50)  NULL,
    [ShortDescription] VARCHAR (500) NULL,
    [CreatedBy]        INT           NOT NULL,
    [CreatedDate]      DATETIME      NOT NULL,
    [ModifiedBy]       INT           NULL,
    [ModifiedDate]     DATETIME2 (7) NULL,
    CONSTRAINT [PK_PatientDiagnosis] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientDiagnosis_Diagnosis] FOREIGN KEY ([fk_DiagnosisID]) REFERENCES [dbo].[Diagnosis] ([ID]),
    CONSTRAINT [FK_PatientDiagnosis_Patient] FOREIGN KEY ([fk_PatientID]) REFERENCES [dbo].[Patient] ([ID]),
    CONSTRAINT [FK_PatientDiagnosis_User] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[User] ([ID]),
    CONSTRAINT [FK_PatientDiagnosis_User1] FOREIGN KEY ([ModifiedBy]) REFERENCES [dbo].[User] ([ID])
);

