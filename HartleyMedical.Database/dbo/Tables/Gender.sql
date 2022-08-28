CREATE TABLE [dbo].[Gender] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Value]  VARCHAR (255) NOT NULL,
    [Active] BIT           NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED ([ID] ASC)
);

