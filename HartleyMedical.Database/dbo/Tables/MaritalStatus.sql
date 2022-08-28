CREATE TABLE [dbo].[MaritalStatus] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Value]  VARCHAR (255) NOT NULL,
    [Active] BIT           NOT NULL,
    CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED ([ID] ASC)
);

