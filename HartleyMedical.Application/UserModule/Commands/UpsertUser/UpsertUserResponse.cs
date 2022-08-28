using FluentValidation;
using HartleyMedical.Application.Common.CustomValidators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.UserModule.Commands.UpsertUser
{
    public class UpsertUserResponse
    {
        public int ID { get; set; }
    }
}
