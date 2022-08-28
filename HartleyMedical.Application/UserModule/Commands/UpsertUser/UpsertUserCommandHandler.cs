using MediatR;
using HartleyMedical.Domain.Entities;
using HartleyMedical.Application.Common.Helpers;
using HartleyMedical.Application.Common.Exceptions;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using HartleyMedical.Application.ServicesInterfaces;
using HartleyMedical.Application.ExternalDependencies;

namespace HartleyMedical.Application.UserModule.Commands.UpsertUser;



public class UpsertUserCommandHandler : IRequestHandler<UpsertUserRequest, UpsertUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserToOrganizationRoleRepository _userToOrganizationRoleRepository;
    private readonly IDEAHistoryRepository _DEAHistoryRepository;
    private readonly IMedicalInfoRepository _medicalInfoRepository;
    private readonly IUserTypeRepository _userTypeRepository;
    private readonly IEmailService _emailService;
    private readonly IFileService _fileService;
    public UpsertUserCommandHandler(IUserRepository userRepository, IUserTypeRepository userTypeRepository,
        IEmailService emailService, IUserToOrganizationRoleRepository userToOrganizationRoleRepository,
        IDEAHistoryRepository DEAHistoryRepository, IMedicalInfoRepository MedicalInfoRepository,
        IFileService fileService)
    {
        _userRepository = userRepository;
        _userToOrganizationRoleRepository = userToOrganizationRoleRepository;
        _DEAHistoryRepository = DEAHistoryRepository;
        _medicalInfoRepository = MedicalInfoRepository;
        _userTypeRepository = userTypeRepository;
        _emailService = emailService;
        _fileService = fileService;
    }

    public async Task<UpsertUserResponse> Handle(UpsertUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = new User();
            var userType = await _userTypeRepository.Get(request.UserTypeID);
            if (userType == null)
            {
                throw new BadRequestException($"UserType '{request.UserTypeID}' not found");
            }
            else
            {

                if (request.ID <= 0)
                {
                    var userDEA = _userRepository.GetUserDetailsByDEANumber(request.DEANumber?.Trim());
                    if (userDEA != null)
                    {
                        throw new BadRequestException("DEA Number already exists");
                    }
                    user = await _userRepository.GetUserByEmail(request.Email?.Trim());
                    if (user != null)
                    {
                        throw new BadRequestException("Email already exists");
                    }
                    user = new User
                    {
                        IsPrescriberInstance = request.IsPrescriberInstance,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Prefix = request.Prefix,
                        MiddleName = request.MiddleName,
                        DEANumber = request.DEANumber,
                        Email = request.Email?.Trim(),
                        PhoneNumber = "1" + request.PhoneNumber?.Trim().RemoveSpecialCharacters(), // concat country code
                        Active = request.Active,
                        IsDeleted = false,
                        TwoFAEnabled = request.TwoFAEnabled,
                        fk_UserTypeID = request.UserTypeID,
                        Password = "",
                        PasswordRequestDate = DateTime.UtcNow,
                        PasswordRequestHash = Guid.NewGuid().ToString(),
                        DEACertificateUrl = request.DEACertificateUrl,
                        PrescriberSignatureUrl = request.PrescriberSignatureUrl
                    };
                    //user.UserToOrganizationRoles.Add(new UserToOrganizationRole
                    //{
                    //    //fk_RoleID = request.RoleID,
                    //});
                    await _userRepository.Add(user);
                    _userRepository.Complete();
                    request.ID = user.ID;
                    _emailService.SendAccountCreatedEmail(user);
                }
                else
                {
                    user = _userRepository.GetUserByID(request.ID);
                    if (user != null)
                    {
                        user.IsPrescriberInstance = request.IsPrescriberInstance;
                        user.FirstName = request.FirstName;
                        user.LastName = request.LastName;
                        user.PhoneNumber = "1" + request.PhoneNumber?.Trim().RemoveSpecialCharacters(); // concat country code
                        user.Active = request.Active;
                        user.IsDeleted = false;
                        user.TwoFAEnabled = request.TwoFAEnabled;
                        user.fk_UserTypeID = request.UserTypeID;
                        user.Prefix = request.Prefix;
                        user.MiddleName = request.MiddleName;
                        _userRepository.Update(user);
                        _userRepository.Complete();
                    }
                    else
                    {
                        throw new BadRequestException($"User '{request.ID}' not found");
                    }
                }
            }

            #region Associate DEAHistory
            if (request.IsPrescriberInstance)
            {
                foreach (var item in request.UserToDEAHistoryDetails)
                {
                    if (item.ID <= 0)
                    {
                        var DEAHistory = new DEAHistory
                        {
                            IsExpired = false,
                            ValidFrom = item.ValidFrom,
                            ValidTo = item.ValidTo,
                            VerificationBy = item.VerificationBy,
                            fk_UserID = request.ID
                        };

                        await _DEAHistoryRepository.Add(DEAHistory);
                        _DEAHistoryRepository.Complete();
                        item.ID = DEAHistory.ID;
                    }
                    else
                    {
                        var DEAHistory = _DEAHistoryRepository.GetDEAHistoryByID(item.ID);
                        DEAHistory.IsExpired = false;
                        DEAHistory.ValidFrom = item.ValidFrom;
                        DEAHistory.ValidTo = item.ValidTo;
                        DEAHistory.VerificationBy = item.VerificationBy;
                        DEAHistory.fk_UserID = request.ID;
                        _DEAHistoryRepository.Update(DEAHistory);
                        _DEAHistoryRepository.Complete();
                    }
                }
            }
            #endregion

            #region Associate MedicalInfo
            if (request.UserToMedicalInfoDetails.ID <= 0)
            {
                var UserMedicalInfo = new UserMedicalInfo
                {
                    NPINumber = request.UserToMedicalInfoDetails.NPINumber,
                    fk_MedicalDesignationID = request.UserToMedicalInfoDetails.MedicalDesignationID,
                    MedicalLicenseNumber = request.UserToMedicalInfoDetails.MedicalLicenseNumber,
                    fk_MedicalLicenseStateID = request.UserToMedicalInfoDetails.MedicalLicenseStateID,
                    fk_PrimarySpecialityID = request.UserToMedicalInfoDetails.PrimarySpecialityID,
                    fk_SecondarySpecialityID = request.UserToMedicalInfoDetails.SecondarySpecialityID,
                    fk_UserID = request.ID
                };

                await _medicalInfoRepository.Add(UserMedicalInfo);
                _medicalInfoRepository.Complete();
                request.UserToMedicalInfoDetails.ID = UserMedicalInfo.ID;
            }
            else
            {
                var UserMedicalInfo = _medicalInfoRepository.GetUserMedicalInfoByID(request.UserToMedicalInfoDetails.ID);
                UserMedicalInfo.NPINumber = request.UserToMedicalInfoDetails.NPINumber;
                UserMedicalInfo.fk_MedicalDesignationID = request.UserToMedicalInfoDetails.MedicalDesignationID;
                UserMedicalInfo.MedicalLicenseNumber = request.UserToMedicalInfoDetails.MedicalLicenseNumber;
                UserMedicalInfo.fk_MedicalLicenseStateID = request.UserToMedicalInfoDetails.MedicalLicenseStateID;
                UserMedicalInfo.fk_PrimarySpecialityID = request.UserToMedicalInfoDetails.PrimarySpecialityID;
                UserMedicalInfo.fk_SecondarySpecialityID = request.UserToMedicalInfoDetails.SecondarySpecialityID;
                UserMedicalInfo.fk_UserID = request.ID;
                _medicalInfoRepository.Update(UserMedicalInfo);
                _medicalInfoRepository.Complete();
            }
            #endregion

            #region Associate Organizations
            request.UserToOrganizationDetails = request.UserToOrganizationDetails.Distinct().ToList();

            var userToOrganizationRolesInDB = _userToOrganizationRoleRepository.GetMany(c => c.fk_UserID == user.ID);
            var userToOrganizationRolesToDelete = userToOrganizationRolesInDB.Where(c => !request.UserToOrganizationDetails.Any(userToOrg => userToOrg.OrganizationID == c.fk_OrganizationID)).ToList();
            var rolePermissionsToAdd = request.UserToOrganizationDetails.Where(userToOrg => !userToOrganizationRolesInDB.Any(c => c.fk_OrganizationID == userToOrg.OrganizationID)).ToList();

            foreach (var item in userToOrganizationRolesToDelete)
            {
                _userToOrganizationRoleRepository.Delete(item);
            }
            foreach (var item in rolePermissionsToAdd)
            {
                await _userToOrganizationRoleRepository.Add(new UserToOrganizationRole
                {
                    fk_UserID = user.ID,
                    fk_RoleID = item.RoleID,
                    fk_OrganizationID = item.OrganizationID
                });
            }
            _userToOrganizationRoleRepository.Complete();

            #endregion

            return new UpsertUserResponse
            {
                ID = request.ID
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
