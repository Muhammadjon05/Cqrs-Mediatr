using MediatR;

namespace Cqrs_Mediatr.Notifications;

public class OrderNotificationHandler : INotificationHandler<OrderNotifications>
{
    private readonly ILogger _logger;

    public OrderNotificationHandler(ILogger<OrderNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OrderNotifications notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Order created with id:{ notification.Id}");
        return Task.CompletedTask;
    }
}