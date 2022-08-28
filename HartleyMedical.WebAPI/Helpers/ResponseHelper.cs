using HartleyMedical.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HartleyMedical.WebAPI.Helpers;
public class ResponseHelper
{
    protected object CreateResponse(Func<object> function)
    {
        object response;
        try
        {
            response = function.Invoke();
        }
        catch (BadRequestException ex)
        {
            response = new SuccessResponseVM
            {
                Message = ex.InnerException?.Message ?? ex.Message,
                Result = "",
                StatusCode = HttpStatusCode.BadRequest,
                Success = false
            };
        }
        catch (DbEntityValidationException ex)
        {
            response = new SuccessResponseVM
            {
                Message = ex.InnerException?.Message ?? ex.Message,
                Result = ex.StackTrace,
                StatusCode = HttpStatusCode.BadRequest,
                Success = false
            };
        }
        catch (DbUpdateException dbEx)
        {
            response = new SuccessResponseVM
            {
                Message = dbEx.InnerException?.Message ?? dbEx.Message,
                Result = dbEx.StackTrace,
                StatusCode = HttpStatusCode.InternalServerError,
                Success = false
            };
        }
        catch (ValidationException ex)
        {
            response = new SuccessResponseVM
            {
                Message = ex.InnerException?.Message ?? ex.Message,
                Result = ex.Errors,
                StatusCode = HttpStatusCode.BadRequest,
                Success = false
            };
        }
        catch (Exception ex)
        {
            if (ex.InnerException is ValidationException)
            {
                response = new SuccessResponseVM
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    Result = (ex.InnerException as ValidationException).Errors,
                    StatusCode = HttpStatusCode.BadRequest,
                    Success = false
                };
            }
            else if (ex.InnerException is BadRequestException)
            {
                response = new SuccessResponseVM
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    Result = "",
                    StatusCode = HttpStatusCode.BadRequest,
                    Success = false
                };
            }
            else
            {
                response = new SuccessResponseVM
                {
                    Message = ex.InnerException?.Message ?? ex.Message,
                    Result = ex.StackTrace,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        return response;
    }
}
