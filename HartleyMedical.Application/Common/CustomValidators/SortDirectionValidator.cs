using FluentValidation;
using HartleyMedical.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Common.CustomValidators
{
    public static class SortDirectionValidator
    {
        public static IRuleBuilderOptions<T, TElement> IsValidSortDirection<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must((TElement value) =>
            {
                return value != null && typeof(TElement) == typeof(string) && !String.IsNullOrWhiteSpace(value.ToString()) ? Enum.TryParse(value.ToString(), true, out SortDirection result) : true;
            }).WithMessage("{PropertyName} field should only contain one of the following values (" + String.Join(',', Enum.GetNames(typeof(SortDirection))) + ")");
        }
    }
}
