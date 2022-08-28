using HartleyMedical.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.GeneralModule.Queries.GetAllStates
{
    public class GetAllStatesRequest : IRequest<List<LookupDto>>
    {
    }
}
