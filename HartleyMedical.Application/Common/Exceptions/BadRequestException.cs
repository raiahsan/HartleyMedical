#region Imports

using System;

#endregion

namespace HartleyMedical.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}