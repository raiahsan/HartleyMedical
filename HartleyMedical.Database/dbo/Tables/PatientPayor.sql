CREATE TABLE [dbo].[PatientPayor] (
    [ID]                      INT              IDENTITY (1, 1) NOT NULL,
    [PatientPayorGUID]        UNIQUEIDENTIFIER NOT NULL,
    [fk_PatientID]            INT              NOT NULL,
    [fk_PayorID]              INT              NOT NULL,
    [fk_PayorLevelID]         INT              NOT NULL,
    [fk_PolicyHolderGenderID] INT              NULL,
    [PolicyNumber]            VARCHAR (50)     NULL,
    [PolicyHolderName]        VARCHAR (50)     NULL,
    [PolicyHolderDOB]         DATE             NULL,
    [GroupNumber]             VARCHAR (50)     NULL,
    [Bin]                     VARCHAR (50)     NULL,
    [Pcn]                     VARCHAR (50)     NULL,
    [NCDPDPolicyNumber]       VARCHAR (50)     NULL,
    [NCPDPGroupNumber]        VARCHAR (50)     NULL,
    [InsuredFirstName]        VARCHAR (50)     NULL,
    [InsuredLastName]         VARCHAR (50)     NULL,
    [InsuredPhone]            VARCHAR (50)     NULL,
    [InsuredAddress1]         VARCHAR (80)     NULL,
    [InsuredAddress2]         VARCHAR (80)     NULL,
    [InsuredCity]             VARCHAR (50)     NULL,
    [InsuredZip]              VARCHAR (50)     NULL,
    [PolicyStartDate]         DATETIME         NULL,
    [PolicyEndDate]           DATETIME         NULL,
    [PayPercent]              DECIMAL (18)     NULL,
    [Deductible]              DECIMAL (18)     NULL,
    [GroupName]               VARCHAR (80)     NULL,
    [PayorContact]            VARCHAR (80)     NULL,
    [Active]                  BIT              NOT NULL,
    [Deleted]                 BIT              NOT NULL,
    [InsVerified]             BIT              NULL,
    [InsVerifiedBy]           VARCHAR (50)     NULL,
    [InsVerifiedDate]         DATETIME         NULL,
    [VerificationType]        VARCHAR (50)     NULL,
    [RawData]                 VARCHAR (MAX)    NOT NULL,
    [CreatedBy]               INT              NOT NULL,
    [CreatedDate]             DATETIME         NOT NULL,
    [ModifiedBy]              INT              NULL,
    [ModifiedDate]            DATETIME         NULL,
    [fk_InsuredStateID]       INT              NULL,
    CONSTRAINT [PK_PatientPayor] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PatientPayor_Gender] FOREIGN KEY ([fk_PolicyHolderGenderID]) REFERENCES [dbo].[Gender] ([ID]),
    CONSTRAINT [FK_PatientPayor_Patient] FOREIGN KEY ([fk_PatientID]) REFERENCES [dbo].[Patient] ([ID]),
    CONSTRAINT [FK_PatientPayor_Payor] FOREIGN KEY ([fk_PayorID]) REFERENCES [dbo].[Payor] ([ID]),
    CONSTRAINT [FK_PatientPayor_PayorLevel] FOREIGN KEY ([fk_PayorLevelID]) REFERENCES [dbo].[PayorLevel] ([ID]),
    CONSTRAINT [FK_PatientPayor_State] FOREIGN KEY ([fk_InsuredStateID]) REFERENCES [dbo].[State] ([ID])
);

