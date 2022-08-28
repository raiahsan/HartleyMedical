CREATE PROCEDURE [dbo].[sp_GetUsers]
@search NVARCHAR (100), 
@pageSize INT = 10,
@pageIndex INT = 1,
@active bit NULL,
@sortColumn varchar(50) = 'u.CreatedDate',
@sortDirection varchar(50) = 'DESC'
AS
BEGIN
		DECLARE @whereClause VARCHAR(MAX) = ' u.IsDeleted = 0 ';
		
		IF (@active is not null and len(@active) > 0) 
		BEGIN
			SET @whereClause = @whereClause + ' AND u.Active = ' + CAST(@active AS VARCHAR) + ''; 
		END
		
		IF (@search is not null and len(@search) > 0) 
		BEGIN
			SET @whereClause = @whereClause + ' AND (u.Email like ''%' + @search + '%'' OR u.FirstName like ''%'  + @search + '%'' OR u.LastName like ''%' + @search + '%'')'; 
		END
		
		DECLARE @countquery VARCHAR(MAX) = 'SELECT count(distinct u.ID) AS TotalRows FROM [User] u
inner join [UserType] uty on uty.ID = u.fk_UserTypeID
Left join UserToOrganizationRole UOR on u.ID = uor.fk_UserID
Left join [Role] r on uor.fk_RoleID=r.ID AND r.Active=1  AND r.IsDeleted=0';

		DECLARE @userQuery VARCHAR(MAX) = 'SELECT u.ID, u.FirstName, u.LastName, u.Email, u.Active,SUBSTRING(u.PhoneNumber, 2, 11) AS PhoneNumber,u.TwoFAEnabled,u.fk_BranchID As BranchID, STRING_AGG(r.RoleName,'','') As RoleName, uty.Type As UserTypeName,uty.ID As UserTypeID, u.MiddleName, u.Prefix, u.DEANumber, u.IsDEANumberVerified
	  From [User] u
	  inner join [UserType] uty on uty.ID = u.fk_UserTypeID
	  Left join UserToOrganizationRole UOR on u.ID = uor.fk_UserID 
	  Left join [Role] r on uor.fk_RoleID=r.ID AND r.Active=1 AND r.IsDeleted=0';
		
		IF (@whereClause is not null and len(@whereClause) > 0)
		BEGIN
			SET @countquery = @countquery + ' where ' + @whereClause;
			SET @userQuery = @userQuery + ' where ' + @whereClause;
		END
		SET @userQuery = @userQuery + ' Group By u.ID, u.FirstName, u.LastName, u.Email, u.CreatedDate, u.Active,u.PhoneNumber,u.TwoFAEnabled,u.fk_BranchID,u.fk_UserTypeID,uty.Type,uty.ID, u.MiddleName, u.Prefix, u.DEANumber, u.IsDEANumberVerified';
		
-- 		SET @userQuery = @userQuery + ' ORDER BY 
-- 				CASE WHEN ''' + @sortColumn + ''' = ''Email'' AND ''' + @sortDirection + ''' = ''ASC'' THEN u.Email END,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''Email'' AND ''' + @sortDirection + ''' = ''DESC'' THEN u.Email END DESC,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''CreatedDate'' AND ''' + @sortDirection + ''' = ''ASC'' THEN u.CreatedDate END,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''CreatedDate'' AND ''' + @sortDirection + ''' = ''DESC'' THEN u.CreatedDate END DESC,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''FirstName'' AND ''' + @sortDirection + ''' = ''ASC'' THEN u.FirstName END,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''FirstName'' AND ''' + @sortDirection + ''' = ''DESC'' THEN u.FirstName END DESC,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''LastName'' AND ''' + @sortDirection + ''' = ''ASC'' THEN u.LastName END,
-- 				CASE WHEN ''' + @sortColumn + ''' = ''LastName'' AND ''' + @sortDirection + ''' = ''DESC'' THEN u.LastName END DESC';
		SET @userQuery = @userQuery + ' ORDER BY ' + @sortColumn + ' ' + @sortDirection;
				
		SET @userQuery = @userQuery + ' OFFSET ' + CAST(((@pageIndex - 1) * @pageSize) AS VARCHAR(MAX))  + ' Rows FETCH NEXT ' + CAST(@pageSize AS VARCHAR (MAX)) + ' ROWS ONLY' 
 			
		EXEC (@countQuery);
		EXEC (@userQuery);    
           
END