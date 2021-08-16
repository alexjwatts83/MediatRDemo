using MediatR;
using MediatRDemo.Application.Base.Commands;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.TwelveWeekYears.Commands
{
	public class DeleteTwelveWeekYearCommand : DeleteBaseCommand<int> { }
	public class DeleteTwelveWeekYearCommandHandler
	: DeleteBaseCommandHandler<TwelveWeekYear, int>
	, IRequestHandler<DeleteTwelveWeekYearCommand>
	{
		public DeleteTwelveWeekYearCommandHandler(IUnitOfWork unitOfWork, ITwelveWeekYearGenericCrudRepositoryScripts scripts)
			: base(unitOfWork, scripts)
		{
		}

		Task<Unit> IRequestHandler<DeleteTwelveWeekYearCommand, Unit>.Handle(DeleteTwelveWeekYearCommand request, CancellationToken cancellationToken)
			=> Handle(request, cancellationToken);
	}
}
