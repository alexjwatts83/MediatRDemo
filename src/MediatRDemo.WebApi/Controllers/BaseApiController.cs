using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Base.Queries;
using MediatRDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController<TEntity, TKey, TGetAllQuery, TGetByIdQuery>
		: ControllerBase
			where TEntity : BaseEntity<TKey>
		where TGetAllQuery : GetAllBaseQuery<TEntity, TKey>
		where TGetByIdQuery : GetByIdBaseQuery<TEntity, TKey>
	{
		private readonly IMediator _mediator;

		public BaseApiController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/[controller]
		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<TEntity>>> GetAllAsync()
		{
			var instance = Activator.CreateInstance(typeof(TGetAllQuery));
			var list = await _mediator.Send(instance);
			if(list == null)
			{
				return NotFound($"Could not get list of '{typeof(TEntity).Name}'");
			}
			return Ok(list);
		}

		// GET: api/[controller]/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<TwelveWeekYear>> GetByIdAsync(TKey id)
		{
			var request = Activator.CreateInstance(typeof(TGetByIdQuery));
			((GetByIdBaseQuery<TEntity, TKey>)request).Id = id;
			var entity = await _mediator.Send(request);
			if (entity == null)
			{
				return NotFound($"Could not find '{typeof(TEntity).Name}', with id of '{id}'");
			}
			return Ok(entity);
		}
	}
}
