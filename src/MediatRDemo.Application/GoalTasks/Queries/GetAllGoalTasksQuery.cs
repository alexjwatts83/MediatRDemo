using MediatR;
using MediatRDemo.Application.Base.Queries;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.GoalTasks.Queries
{
	public class GetAllGoalTasksQuery : GetAllBaseQuery<GoalTask, Guid>
	{
	}

	public class GetAllGoalTasksQueryHandler
		: GetAllBaseQueryHandler<GoalTask, Guid>
		, IRequestHandler<GetAllGoalTasksQuery, IReadOnlyList<GoalTask>>
	{
		public GetAllGoalTasksQueryHandler(IUnitOfWork unitOfWork, IGoalTasksGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<IReadOnlyList<GoalTask>> Handle(GetAllGoalTasksQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
