using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.GoalTasks.Commands
{
	public class DeleteGoalTaskCommand : DeleteBaseCommand<Guid> { }
	public class DeleteGoalTaskCommandHandler
	: DeleteBaseCommandHandler<GoalTask, Guid>
	, IRequestHandler<DeleteGoalTaskCommand>
	{
		public DeleteGoalTaskCommandHandler(IUnitOfWork unitOfWork, IGoalTasksGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		Task<Unit> IRequestHandler<DeleteGoalTaskCommand, Unit>.Handle(DeleteGoalTaskCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
