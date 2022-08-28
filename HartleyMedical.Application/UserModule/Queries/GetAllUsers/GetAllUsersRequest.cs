using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using HartleyMedical.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Queries.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<RecordSet<GetAllUsersResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public bool? Active { get; set; }
    }

    public class GetAllUsersRequestValidator : AbstractValidator<GetAllUsersRequest>
    {
        public GetAllUsersRequestValidator()
        {
            List<string> sortedColumns = new List<string>
           {
               {"Email"},
               {"CreatedDate"},
               {"FirstName"},
               {"LastName"},
           };
            RuleFor(x => x.PageIndex)
                .NotEmpty().WithMessage("PageIndex should be greater than 0");

            RuleFor(x => x.PageSize)
                .NotEmpty().WithMessage("PageSize should be greater than 0");

            RuleFor(x => x.SortDirection)
                .IsValidSortDirection();

            RuleFor(x => x.SortColumn)
                .IsValidListMember(sortedColumns);
        }
    }
}
