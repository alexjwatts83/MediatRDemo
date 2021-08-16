using MediatR;
using MediatRDemo.Application.GoalTasks.Commands;
using MediatRDemo.Application.GoalTasks.Queries;
using MediatRDemo.Domain.Entities;
using System;

namespace MediatRDemo.WebApi.Controllers
{
	public class GoalTasksController
		: BaseApiController<GoalTask, GoalTaskDto, Guid, GetAllGoalTasksQuery, GetByIdGoalTaskQuery, CreateGoalTaskCommand, UpdateGoalTaskCommand, DeleteGoalTaskCommand>
	{
		public GoalTasksController(IMediator mediator) : base(mediator)
		{
		}
	}
}
