using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Common.CustomValidators
{
    public static class PasswordValidators
    {
        public static IRuleBuilder<T, string> IsPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((string value) =>
            {
                return !String.IsNullOrWhiteSpace(value) ? Regex.IsMatch(value, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#\?!@$%^&\*\+(),{|}<=>\/:;_~`\[\]\.\'\-]).{8,}$") : true;
            }).WithMessage("The {PropertyName} field must be atleast of 8 characters and it should contain one capital letter, one small letter, one digit and one special character");

        }
    }
}
