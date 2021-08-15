using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Base.Queries;
using MediatRDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController<TEntity, TEntityDto, TKey, TGetAllQuery, TGetByIdQuery, TCreateCommand, TUpdateCommand, TDeleteCommand>
		: ControllerBase
			where TEntity : BaseEntity<TKey>
			where TGetAllQuery : GetAllBaseQuery<TEntity, TKey>
			where TGetByIdQuery : GetByIdBaseQuery<TEntity, TKey>
			where TCreateCommand : CreateBaseCommand<TEntityDto, TKey>
			where TUpdateCommand : UpdateBaseCommand<TEntityDto, TKey>
			where TDeleteCommand : DeleteBaseCommand<TKey>
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

		[HttpPost]
		public async Task<ActionResult<TKey>> CreateAsync(TCreateCommand command)
		{
			return await _mediator.Send(command);
		}

		// PUT: api/[controller]/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync(TKey id, TUpdateCommand command)
		{
			if (!id.Equals(command.Id))
			{
				return BadRequest();
			}

			await _mediator.Send(command);

			return NoContent();
		}

		// DELETE: api/[controller]/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(TKey id)
		{
			var command = Activator.CreateInstance(typeof(TDeleteCommand));
			((DeleteBaseCommand<TKey>)command).Id = id;

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
