using MediatR;
using MediatRDemo.Application.Base.Queries;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Goals.Queries
{
	public class GetAllGoalsQuery : GetAllBaseQuery<Goal, Guid>
	{
	}

	public class GetAllGoalQueryHandler
		: GetAllBaseQueryHandler<Goal, Guid>
		, IRequestHandler<GetAllGoalsQuery, IReadOnlyList<Goal>>
	{
		public GetAllGoalQueryHandler(IUnitOfWork unitOfWork, IGoalGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<IReadOnlyList<Goal>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
