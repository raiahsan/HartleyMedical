#region Imports

using System;

#endregion

namespace HartleyMedical.Application.Common.Exceptions
{
    public class DbEntityValidationException : Exception
    {
        public DbEntityValidationException(string message) : base(message)
        {
        }
    }
}