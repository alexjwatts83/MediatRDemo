using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Application.Notifcations;

namespace MediatRDemo.WebApi.Services
{
    public class NotifierMediatorService : INotifierMediatorService
    {
        private readonly IMediator _mediator;

        public NotifierMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Notify(string notifyText)
        {
            _mediator.Publish(new NotificationMessage { NotifyText = notifyText });
        }
    }
}
