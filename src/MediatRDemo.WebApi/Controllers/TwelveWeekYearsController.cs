using MediatR;
using MediatRDemo.Application.TwelveWeekYears.Commands;
using MediatRDemo.Application.TwelveWeekYears.Queries;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.WebApi.Controllers
{
	public class TwelveWeekYearsController
		: BaseApiController<TwelveWeekYear, TwelveWeekYearDto, int,
			GetAllTwelveWeekYearQuery, GetByIdTwelveWeekYearQuery,
			CreateTwelveWeekYearCommand, UpdateTwelveWeekYearCommand, DeleteTwelveWeekYearCommand>
	{
		public TwelveWeekYearsController(IMediator mediator) : base(mediator)
		{
		}
	}
}
