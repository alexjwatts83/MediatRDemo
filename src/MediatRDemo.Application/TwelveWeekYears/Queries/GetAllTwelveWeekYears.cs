using MediatR;
using MediatRDemo.Application.Base;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.TwelveWeekYears.Queries
{
	public class GetAllTwelveWeekYearQuery : GetAllBaseQuery<TwelveWeekYear, int>
	{
	}

	public class GetAllTwelveWeekYearQueryHandler
		: GetAllBaseQueryHandler<TwelveWeekYear, int>
		, IRequestHandler<GetAllTwelveWeekYearQuery, IReadOnlyList<TwelveWeekYear>>
	{
		public GetAllTwelveWeekYearQueryHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<IReadOnlyList<TwelveWeekYear>> Handle(GetAllTwelveWeekYearQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
