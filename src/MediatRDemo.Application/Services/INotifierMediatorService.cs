using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Notifcations;

namespace MediatRDemo.Application.Services
{
    public interface INotifierMediatorService
    {
        void Notify(string notifyText);
    }
}
