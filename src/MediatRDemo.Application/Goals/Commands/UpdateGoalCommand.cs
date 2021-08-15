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
	public class UpdateGoalCommand : UpdateBaseCommand<GoalDto, Guid> { }

	public class UpdateGoalCommandHandler
		: UpdateBaseCommandHandler<GoalDto, Goal, Guid>
		, IRequestHandler<UpdateGoalCommand>
	{
		public UpdateGoalCommandHandler(IUnitOfWork unitOfWork, IGoalGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		Task<Unit> IRequestHandler<UpdateGoalCommand, Unit>.Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
