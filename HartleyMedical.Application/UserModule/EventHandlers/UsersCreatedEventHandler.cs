using MediatR;
using Microsoft.Extensions.Logging;
using HartleyMedical.Application.Common.Models;
using HartleyMedical.Domain.Users.Events;

namespace HartleyMedical.Application.UserModule.EventHandlers;


public class UsersCreatedEventHandler : INotificationHandler<DomainEventNotification<UserCreatedEvent>>
{
    private readonly ILogger<UsersCreatedEventHandler> _logger;

    public UsersCreatedEventHandler(ILogger<UsersCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<UserCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("HartleyMedical Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
