using MediatRDemo.Application.Interfaces;
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
        public IActionResult NotifyAll()
        {
            _notifierMediatorService.Notify("This is a test notification");
            return Ok("Notify All");
        }

        [HttpGet("/{text}")]
        public IActionResult NotifyWithCustomText(string text)
        {
            _notifierMediatorService.Notify(text);
            return Ok("Notify With Custom Text");
        }
    }
}
