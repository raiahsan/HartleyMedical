CREATE TABLE [dbo].[User] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [fk_UserTypeID]        INT            NOT NULL,
    [fk_BranchID]          INT            NOT NULL,
    [FirstName]            VARCHAR (50)   NOT NULL,
    [LastName]             VARCHAR (50)   NOT NULL,
    [Email]                VARCHAR (150)  NOT NULL,
    [Password]             VARCHAR (2000) NOT NULL,
    [Active]               BIT            NOT NULL,
    [PasswordRequestHash]  VARCHAR (1500) NULL,
    [PasswordRequestDate]  DATETIME       NULL,
    [CreatedBy]            INT            NOT NULL,
    [CreatedDate]          DATETIME       NOT NULL,
    [ModifiedBy]           INT            NULL,
    [ModifiedDate]         DATETIME       NULL,
    [IsDeleted]            BIT            CONSTRAINT [DF__User__IsDeleted__5812160E] DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [TwoFACode]            VARCHAR (10)   NULL,
    [TwoFACodeRequestDate] DATETIME       NULL,
    [PhoneNumber]          VARCHAR (15)   DEFAULT ('') NOT NULL,
    [TwoFAEnabled]         BIT            DEFAULT ((0)) NOT NULL,
    [DEANumber]            VARCHAR (25)   NULL,
    [IsDEANumberVerified]  BIT            DEFAULT ((0)) NOT NULL,
    [MiddleName]           VARCHAR (50)   NULL,
    [Prefix]               VARCHAR (10)   NULL,
    [DEACertificateUrl] VARCHAR(200) NULL, 
    [PrescriberSignatureUrl] VARCHAR(200) NULL, 
    [IsPrescriberInstance] BIT NULL DEFAULT 0, 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_User_UserType] FOREIGN KEY ([fk_UserTypeID]) REFERENCES [dbo].[UserType] ([ID])
);



