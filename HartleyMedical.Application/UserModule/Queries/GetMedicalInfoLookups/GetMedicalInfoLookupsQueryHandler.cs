using HartleyMedical.Application.Common.Models;
using HartleyMedical.Application.RepositoryInterfaces.IUserRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetMedicalInfoLookups
{
    public class GetMedicalInfoLookupsQueryHandler : IRequestHandler<GetMedicalInfoLookupsRequest, GetMedicalInfoLookupsResponse>
    {
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IMedicalDesignationRepository _medicalDesignationRepository;
        private readonly IMedicalLicenseStateRepository _medicalLicenseStateRepository;
        public GetMedicalInfoLookupsQueryHandler(ISpecialityRepository specialityRepository,
            IMedicalDesignationRepository medicalDesignationRepository,
            IMedicalLicenseStateRepository medicalLicenseStateRepository)
        {
            _specialityRepository = specialityRepository;
            _medicalDesignationRepository = medicalDesignationRepository;
            _medicalLicenseStateRepository=medicalLicenseStateRepository;
        }

        public async Task<GetMedicalInfoLookupsResponse> Handle(GetMedicalInfoLookupsRequest request, CancellationToken cancellationToken)
        {
            GetMedicalInfoLookupsResponse getMedicalInfoLookupsResponse = new GetMedicalInfoLookupsResponse();
            var specialities = await _specialityRepository.GetAll();
            var medicalDesignations = await _medicalDesignationRepository.GetAll();
            var licenseStates = await _medicalLicenseStateRepository.GetAll();
             getMedicalInfoLookupsResponse.Specialities= specialities.Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Name
            }).ToList();

            getMedicalInfoLookupsResponse.MedicalDesignations = medicalDesignations.Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Name
            }).ToList();

            getMedicalInfoLookupsResponse.MedicalLicenseStates = licenseStates.Select(c => new LookupDto
            {
                Key = c.ID,
                Value = c.Name
            }).ToList();
            return getMedicalInfoLookupsResponse;
        }
    }
}
