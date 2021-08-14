using MediatR;
using MediatRDemo.Application.GoalTask.Queries;
using MediatRDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo.WebApi.Controllers
{
	[Route("api/twelve-week-year")]
	[ApiController]
	public class TwelveWeekYearController : ControllerBase
	{
		private readonly IMediator _mediator;
		public TwelveWeekYearController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/twelve-week-year
		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<TwelveWeekYear>>> Get()
		{
			var list = await _mediator.Send(new GetTwelveWeekYearQuery());
			return Ok(list);
		}
	}
}
