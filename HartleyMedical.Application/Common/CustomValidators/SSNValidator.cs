﻿using FluentValidation;
using HartleyMedical.Application.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Common.CustomValidators
{
    public static class SSNValidator
    {
        public static IRuleBuilderOptions<T, TElement> IsSSN<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must((TElement value) =>
            {
                return value != null && typeof(TElement) == typeof(string) && !String.IsNullOrWhiteSpace(value.ToString()) ? value.ToString().IsSSN() : true;
            }).WithMessage("The {PropertyName} field is invalid");
        }
    }
}
