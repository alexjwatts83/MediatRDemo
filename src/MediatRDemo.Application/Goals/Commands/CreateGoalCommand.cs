using AutoMapper;
using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Goals.Commands
{
	public class CreateGoalCommand : CreateBaseCommand<GoalDto, Guid>
	{
	}
	public class CreateGoalCommandHandler
		: CreateBaseCommandHandler<GoalDto, Goal, Guid>
		, IRequestHandler<CreateGoalCommand, Guid>
	{
		public CreateGoalCommandHandler(IUnitOfWork unitOfWork, IGoalGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		public Task<Guid> Handle(CreateGoalCommand request, CancellationToken cancellationToken) => base.Handle(request, cancellationToken);
	}
}
