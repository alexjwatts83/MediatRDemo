using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatRDemo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.WebApi.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly INotifierMediatorService _notifierMediatorService;

        public HomeController(INotifierMediatorService notifierMediatorService)
        {
            _notifierMediatorService = notifierMediatorService;
        }

        [HttpGet("")]
        public ActionResult<string> NotifyAll()
        {
            _notifierMediatorService.Notify("This is a test notification");
            return "Completed";
        }
    }
}
