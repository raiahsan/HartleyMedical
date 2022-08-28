CREATE PROCEDURE [dbo].[sp_GetUserByID_DEA]       
@userID int NULL,          
@DEANumber varchar(25) NULL      
AS      
BEGIN      
      
  If(@userID is NULL or @userID = '')          
  Begin          
  SELECT @userID = ID FROM [User] where DEANumber = @DEANumber AND IsDeleted = 0;          
  END      
      
  SELECT u.ID, u.fk_UserTypeID AS UserTypeID, u.fk_BranchID As BranchID, u.Prefix, u.FirstName, u.MiddleName,     
  u.LastName, u.Email, u.Active, u.TwoFAEnabled, u.DEANumber, u.IsDEANumberVerified, SUBSTRING(u.PhoneNumber, 2, 11) AS PhoneNumber, u.IsPrescriberInstance,  
  u.DEACertificateUrl, u.PrescriberSignatureUrl  
  FROM [User] u WHERE u.ID = @userID AND u.IsDeleted = 0;       
          
  SELECT utr.ID, utr.fk_UserID AS UserID, r.ID AS RoleID, r.RoleName, o.ID AS OrganizationID, o.FacilityName AS OrganizationName, ot.ID As OrganizationTypeID, ot.TypeName As OrganizationTypeName        
  from [UserToOrganizationRole] utr         
  INNER JOIN [Role] r ON utr.fk_RoleID = r.ID and r.Active = 1 and r.IsDeleted = 0        
  INNER JOIN [Organization] o ON utr.fk_OrganizationID = o.ID and o.Active = 1 and o.IsDeleted = 0        
  INNER JOIN [OrganizationType] ot ON ot.ID = o.fk_OrganizationTypeID        
  WHERE utr.fk_UserID = @userID;        
        
  select DH.ID, DH.IsExpired as DEAStatus, DH.ValidFrom, DH.ValidTo, DH.VerificationBy        
  from DEAHistory DH where fk_UserID = @userID
         
  select umi.ID, umi.NPINumber, umi.fk_MedicalDesignationID as MedicalDesignationID, md.[Name] as MedicalDesignationName,        
  umi.MedicalLicenseNumber, umi.fk_MedicalLicenseStateID as MedicalLicenseStateID, mls.[Name] as MedicalLicenseStateName,        
  umi.fk_PrimarySpecialityID as PrimarySpecialityID, ps.[Name] as PrimarySpecialityName, umi.fk_SecondarySpecialityID as SecondarySpecialityID,        
  ss.[Name] as SecondarySpecialityName         
  from UserMedicalInfo umi        
  join MedicalDesignation md on umi.fk_MedicalDesignationID = md.ID        
  join MedicalLicenseState mls on umi.fk_MedicalLicenseStateID = mls.ID        
  join Speciality ps on umi.fk_PrimarySpecialityID = ps.ID        
  join Speciality ss on umi.fk_SecondarySpecialityID = ss.ID        
  where umi.fk_UserID = @userID       
END 