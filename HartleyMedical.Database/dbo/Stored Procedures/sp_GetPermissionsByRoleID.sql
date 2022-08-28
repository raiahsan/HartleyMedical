CREATE PROCEDURE [dbo].[sp_GetPermissionsByRoleID] 
@roleID INT NULL,
@isAllowed BIT NULL
AS
BEGIN
	WITH RolePermissions AS
	(SELECT am.ID AS ActionToModuleID,a.ID AS ActionID, a.ActionName, m.ID as ModuleID, m.ModuleName, CASE WHEN rp.fk_ActionToModuleID IS NULL THEN 0 ELSE 1 END AS IsAllowed, rp.ID As RolePermissionID 
	FROM ActionToModule am
	INNER JOIN [Action] a ON a.ID = am.fk_ActionID
	INNER JOIN [Module] m ON m.ID = am.fk_ModuleID
	LEFT JOIN [RolePermission] rp ON rp.fk_ActionToModuleID = am.ID AND rp.Active = 1 AND rp.fk_RoleID = @roleID)
	
	SELECT * from RolePermissions rp
	WHERE @isAllowed IS NULL OR rp.IsAllowed = @isAllowed
	    
END