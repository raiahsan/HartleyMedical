using HartleyMedical.Domain.Common;

namespace HartleyMedical.Domain.Users.Events;

public class UserCreatedEvent : DomainEvent
{
    public UserCreatedEvent(Users user)
    {
        User = user;
    }

    public Users User { get; }
}