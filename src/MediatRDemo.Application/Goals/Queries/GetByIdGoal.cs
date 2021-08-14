using MediatR;
using MediatRDemo.Application.Base;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Goals.Queries
{
	public class GetByIdGoalQuery : GetByIdBaseQuery<Goal, Guid>
	{
	}

	public class GetByIdGoalQueryHandler
		: GetByIdBaseQueryHandler<Goal, Guid>
		, IRequestHandler<GetByIdGoalQuery, Goal>
	{
		public GetByIdGoalQueryHandler(IUnitOfWork unitOfWork, IGoalGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<Goal> Handle(GetByIdGoalQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
