using MediatR;
using MediatRDemo.Application.Base;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.TwelveWeekYears.Queries
{
	public class GetByIdTwelveWeekYearQuery : GetByIdBaseQuery<TwelveWeekYear, int>
	{
	}

	public class GetByIdTwelveWeekYearQueryHandler
		: GetByIdBaseQueryHandler<TwelveWeekYear, int>
		, IRequestHandler<GetByIdTwelveWeekYearQuery, TwelveWeekYear>
	{
		public GetByIdTwelveWeekYearQueryHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		public Task<TwelveWeekYear> Handle(GetByIdTwelveWeekYearQuery request, CancellationToken cancellationToken)
			=> base.Handle(request, cancellationToken);
	}
}
