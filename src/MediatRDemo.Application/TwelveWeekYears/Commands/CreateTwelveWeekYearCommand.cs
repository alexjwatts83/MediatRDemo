using AutoMapper;
using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.TwelveWeekYears.Commands
{
	public class CreateTwelveWeekYearCommand : CreateBaseCommand<TwelveWeekYearDto, int>
	{
	}
	public class CreateTwelveWeekYearCommandHandler
		: CreateBaseCommandHandler<TwelveWeekYearDto, TwelveWeekYear, int>
		, IRequestHandler<CreateTwelveWeekYearCommand, int>
	{
		public CreateTwelveWeekYearCommandHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts, IMapper mapper)
			: base(unitOfWork, scripts, mapper)
		{
		}

		public Task<int> Handle(CreateTwelveWeekYearCommand request, CancellationToken cancellationToken) => base.Handle(request, cancellationToken);
	}
}
