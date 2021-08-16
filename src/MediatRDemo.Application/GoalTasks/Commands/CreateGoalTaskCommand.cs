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
	public class CreateGoalTaskCommand : CreateBaseCommand<GoalTaskDto, Guid>
	{
	}
	public class CreateGoalTaskCommandHandler
		: CreateBaseCommandHandler<GoalTaskDto, GoalTask, Guid>
		, IRequestHandler<CreateGoalTaskCommand, Guid>
	{
		public CreateGoalTaskCommandHandler(IUnitOfWork unitOfWork, IGoalTasksGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		public Task<Guid> Handle(CreateGoalTaskCommand request, CancellationToken cancellationToken) => base.Handle(request, cancellationToken);
	}
}
