using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Notifcations;
using Microsoft.Extensions.Logging;

namespace MediatRDemo.Application.Handlers
{
    public class Notifier1 : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<Notifier1> _logger;

        public Notifier1(ILogger<Notifier1> logger)
        {
            _logger = logger;
        }

        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Debugging from Notifier 1. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }

    public class Notifier2 : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<Notifier1> _logger;

        public Notifier2(ILogger<Notifier1> logger)
        {
            _logger = logger;
        }

        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Debugging from Notifier 2. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
