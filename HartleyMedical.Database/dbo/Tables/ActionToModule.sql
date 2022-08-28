CREATE TABLE [dbo].[ActionToModule]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [fk_ActionID] INT NOT NULL, 
    [fk_ModuleID] INT NOT NULL, 
    CONSTRAINT [FK_ActionToModule_Action] FOREIGN KEY (fk_ActionID) REFERENCES [Action](ID), 
    CONSTRAINT [FK_ActionToModule_Module] FOREIGN KEY (fk_ModuleID) REFERENCES Module(ID)
)
