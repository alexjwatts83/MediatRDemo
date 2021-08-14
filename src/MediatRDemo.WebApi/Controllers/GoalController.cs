using MediatR;
using MediatRDemo.Application.Goals.Queries;
using MediatRDemo.Application.TwelveWeekYears.Queries;
using MediatRDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo.WebApi.Controllers
{
	public class GoalController : BaseApiController<Goal, Guid, GetAllGoalsQuery, GetByIdGoalQuery>
	{
		public GoalController(IMediator mediator) : base(mediator)
		{
		}
	}
}
