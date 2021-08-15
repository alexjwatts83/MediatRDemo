using MediatR;
using MediatRDemo.Application.Goals.Commands;
using MediatRDemo.Application.Goals.Queries;
using MediatRDemo.Domain.Entities;
using System;

namespace MediatRDemo.WebApi.Controllers
{
	public class GoalController : BaseApiController<Goal, GoalDto, Guid, GetAllGoalsQuery, GetByIdGoalQuery, CreateGoalCommand, UpdateGoalCommand>
	{
		public GoalController(IMediator mediator) : base(mediator)
		{
		}
	}
}
