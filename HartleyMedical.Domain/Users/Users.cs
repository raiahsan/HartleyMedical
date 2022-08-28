using HartleyMedical.Domain.Common;
using HartleyMedical.Domain.Models;

namespace HartleyMedical.Domain.Users;

public class Users : AuditableEntity, IHasDomainEvent
{
    public int UserID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}
