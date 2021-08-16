using MediatR;
using MediatRDemo.Application.Goals.Commands;
using MediatRDemo.Application.Goals.Queries;
using MediatRDemo.Domain.Entities;
using System;

namespace MediatRDemo.WebApi.Controllers
{
	public class GoalsController
		: BaseApiController<Goal, GoalDto, Guid, GetAllGoalsQuery, GetByIdGoalQuery, CreateGoalCommand, UpdateGoalCommand, DeleteGoalCommand>
	{
		public GoalsController(IMediator mediator) : base(mediator)
		{
		}
	}
}
