using MediatR;
using MediatRDemo.Application.TwelveWeekYears.Queries;
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
		public async Task<ActionResult<IReadOnlyList<TwelveWeekYear>>> GetAllAsync()
		{
			var list = await _mediator.Send(new GetAllTwelveWeekYearQuery());
			return Ok(list);
		}

		// GET: api/twelve-week-year/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<TwelveWeekYear>> GetByIdAsync(int id)
		{
			var request = new GetByIdTwelveWeekYearQuery() { Id = id };
			var list = await _mediator.Send(request);
			return Ok(list);
		}
	}
}
