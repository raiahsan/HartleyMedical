using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.SystemSettingsModule.Queries.GetSystemSettings
{
    public class GetSystemSettingsRequest : IRequest<List<GetSystemSettingsResponse>>
    {
    }
}
