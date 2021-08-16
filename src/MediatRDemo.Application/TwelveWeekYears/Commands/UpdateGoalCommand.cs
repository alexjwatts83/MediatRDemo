using AutoMapper;
using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.TwelveWeekYears.Commands
{
	public class UpdateTwelveWeekYearCommand : UpdateBaseCommand<TwelveWeekYearDto, int> { }

	public class UpdateTwelveWeekYearCommandHandler
		: UpdateBaseCommandHandler<TwelveWeekYearDto, TwelveWeekYear, int>
		, IRequestHandler<UpdateTwelveWeekYearCommand>
	{
		public UpdateTwelveWeekYearCommandHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		Task<Unit> IRequestHandler<UpdateTwelveWeekYearCommand, Unit>.Handle(UpdateTwelveWeekYearCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
