using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Application.Base;
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
			// TO Create class
			var repositoryType = typeof(GetAllBaseQuery<,>);
			var instance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)));

			//var instance = Activator.CreateInstance(typeof(TGetAllQuery));
			var list = await _mediator.Send(instance);
			return Ok(list);
		}
	}
}
