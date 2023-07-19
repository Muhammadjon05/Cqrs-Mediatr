using MediatR;

namespace Cqrs_Mediatr.Notifications;

public class OrderNotifications : INotification
{
    public Guid Id { get; set; }
}