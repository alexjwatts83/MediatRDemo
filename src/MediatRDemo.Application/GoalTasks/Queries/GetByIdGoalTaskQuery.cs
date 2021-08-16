using MediatR;
using MediatRDemo.Application.Base.Queries;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.GoalTasks.Queries
{
	public class GetByIdGoalTaskQuery : GetByIdBaseQuery<GoalTask, Guid>
	{
	}

	public class GetByIdGoalTaskQueryHandler
		: GetByIdBaseQueryHandler<GoalTask, Guid>
		, IRequestHandler<GetByIdGoalTaskQuery, GoalTask>
	{
		public GetByIdGoalTaskQueryHandler(IUnitOfWork unitOfWork, IGoalTasksGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<GoalTask> Handle(GetByIdGoalTaskQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
