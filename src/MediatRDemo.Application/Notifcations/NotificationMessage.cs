using MediatR;

namespace MediatRDemo.Application.Notifcations
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
