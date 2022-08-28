using HartleyMedical.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HartleyMedical.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (BadRequestException ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "HartleyMedical Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
        catch (ValidationException ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "HartleyMedical Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "HartleyMedical Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
