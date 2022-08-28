#region Imports

using AutoMapper;
using HartleyMedical.Application.LocationModule.Queries.GetAllLoctaions;
using HartleyMedical.Application.LocationModule.Queries.GetLocationByID;
using HartleyMedical.Application.OrganizationModule.Commands.CreateOrganization;
using HartleyMedical.Application.OrganizationModule.Commands.DeleteOrganization;
using HartleyMedical.Application.OrganizationModule.Queries.GetAllOrganization;
using HartleyMedical.Application.OrganizationModule.Queries.GetOrganizationByID;
using HartleyMedical.Application.RoleModule.Queries.GetAllRoles;
using HartleyMedical.Application.SystemSettingsModule.Queries.GetSystemSettings;
using HartleyMedical.Application.UserModule.Models;
using HartleyMedical.Application.UserModule.Queries.GetAllUsers;
using HartleyMedical.Application.UserModule.Queries.GetUserDetailsByID;
using HartleyMedical.Domain.Entities;
#endregion

namespace HartleyMedical.Application.Common.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Organization, GetAllOrganizationsResponse>()
                .ForMember(dest => dest.OrganizationTypeID, opts => opts.MapFrom(src => src.fk_OrganizationTypeID));
            CreateMap<Organization, GetOrganizationByIDResponse>()
                .ForMember(dest => dest.OrganizationTypeID, opts => opts.MapFrom(src => src.fk_OrganizationTypeID));

            CreateMap<Location, GetAllLocationsResponse>()
               .ForMember(dest => dest.OrganizationID, opts => opts.MapFrom(src => src.fk_FacilityID))
               .ForMember(dest => dest.StateID, opts => opts.MapFrom(src => src.fk_StateID))
               .ForMember(dest => dest.OrganizationName, opts => opts.MapFrom(src => src.Facility != null ? src.Facility.FacilityName : null))
               .ForMember(dest => dest.StateName, opts => opts.MapFrom(src => src.State != null ? src.State.Name : null));

            CreateMap<Location, GetLocationByIDResponse>()
                 .ForMember(dest => dest.OrganizationID, opts => opts.MapFrom(src => src.fk_FacilityID))
                 .ForMember(dest => dest.StateID, opts => opts.MapFrom(src => src.fk_StateID));

            CreateMap<User, UserDto>()
                //.ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.UserToOrganizationRoles.Select(c => c.Role.RoleName).FirstOrDefault()))
                //.ForMember(dest => dest.RoleID, opts => opts.MapFrom(src => src.UserToOrganizationRoles.Select(c => c.Role.ID).FirstOrDefault()))
                .ForMember(dest => dest.UserTypeID, opts => opts.MapFrom(src => src.fk_UserTypeID));
            CreateMap<UserDto, User>();

            CreateMap<SystemSetting, GetSystemSettingsResponse>();

            CreateMap<UserType, UserTypeDto>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Type));

            CreateMap<User, GetAllUsersResponse>()
                .ForMember(dest => dest.BranchID, opts => opts.MapFrom(src => src.fk_BranchID))
                .ForMember(dest => dest.UserTypeID, opts => opts.MapFrom(src => src.fk_UserTypeID))
                .ForMember(dest => dest.RoleName, opts => opts.MapFrom(src => src.UserToOrganizationRoles.Select(c => c.Role.RoleName).FirstOrDefault()))
                .ForMember(dest => dest.UserTypeName, opts => opts.MapFrom(src => src.UserType != null ? src.UserType.Type : null));

            CreateMap<Role, GetAllRolesResponse>()
                .ForMember(dest => dest.UserTypeID, opts => opts.MapFrom(src => src.fk_UserTypeID))
                .ForMember(dest=> dest.ActiveUsers, opt=> opt.MapFrom(src=> src.UserToOrganizations.Count()))
                .ForMember(dest => dest.InActiveUsers, opt => opt.MapFrom(src => src.UserToOrganizations.Count() == 0 ? 0 : 0));

            CreateMap<GetUserDetailsByIDResponse, UserDto>();
            
        }
    }
}
