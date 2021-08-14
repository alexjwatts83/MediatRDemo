using MediatR;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.GoalTask.Queries
{
	public class GetTwelveWeekYearQuery : IRequest<IReadOnlyList<TwelveWeekYear>>
	{
	}
	public class GetTwelveWeekYearQueryHandler
		: IRequestHandler<GetTwelveWeekYearQuery, IReadOnlyList<TwelveWeekYear>>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ITwelveWeekYearGenericCrudRepositoryScripts scripts;

		public GetTwelveWeekYearQueryHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
		}

		public async Task<IReadOnlyList<TwelveWeekYear>> Handle(
			GetTwelveWeekYearQuery request,
			CancellationToken cancellationToken)
		{
			var list = await unitOfWork.Repository<TwelveWeekYear, int>(scripts).GetAllAsync();

			return list;
		}
	}
}
