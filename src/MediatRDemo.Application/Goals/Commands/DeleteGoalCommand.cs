using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Goals.Commands
{
	public class DeleteGoalCommand : DeleteBaseCommand<Guid> { }
	public class DeleteGoalCommandHandler
	: DeleteBaseCommandHandler<Goal, Guid>
	, IRequestHandler<DeleteGoalCommand>
	{
		public DeleteGoalCommandHandler(IUnitOfWork unitOfWork, IGoalGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		Task<Unit> IRequestHandler<DeleteGoalCommand, Unit>.Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
