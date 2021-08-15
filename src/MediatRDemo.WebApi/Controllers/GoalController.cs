using MediatR;
using MediatRDemo.Application.Goals.Queries;
using MediatRDemo.Domain.Entities;
using System;

namespace MediatRDemo.WebApi.Controllers
{
	public class GoalController : BaseApiController<Goal, Guid, GetAllGoalsQuery, GetByIdGoalQuery>
	{
		public GoalController(IMediator mediator) : base(mediator)
		{
		}
	}
}
