using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace HartleyMedical.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = 123; // Need to change this
        string userName = string.Empty;

        _logger.LogInformation("HartleyMedical Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
    }
}