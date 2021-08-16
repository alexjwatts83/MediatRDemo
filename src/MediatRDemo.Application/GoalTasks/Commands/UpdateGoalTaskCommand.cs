using AutoMapper;
using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.GoalTasks.Commands
{
	public class UpdateGoalTaskCommand : UpdateBaseCommand<GoalTaskDto, Guid> { }

	public class UpdateGoalTaskCommandHandler
		: UpdateBaseCommandHandler<GoalTaskDto, GoalTask, Guid>
		, IRequestHandler<UpdateGoalTaskCommand>
	{
		public UpdateGoalTaskCommandHandler(IUnitOfWork unitOfWork, IGoalTasksGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		Task<Unit> IRequestHandler<UpdateGoalTaskCommand, Unit>.Handle(UpdateGoalTaskCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
