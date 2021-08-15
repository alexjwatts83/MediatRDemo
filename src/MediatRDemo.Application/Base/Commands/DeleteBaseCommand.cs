using AutoMapper;
using MediatR;
using MediatRDemo.Application.Common.Exceptions;
using MediatRDemo.Application.Common.Interfaces;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Base.Commands
{
	public class DeleteBaseCommand<TKey> : IRequest
	{
		public TKey Id { get; set; }
	}

	public class DeleteBaseCommandHandler<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericCrudRepositoryScripts scripts;

		public DeleteBaseCommandHandler(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
		}

		public async Task<Unit> Handle(DeleteBaseCommand<TKey> request, CancellationToken cancellationToken)
		{
			var repo = unitOfWork.Repository<TEntity, TKey>(scripts);
			var entity = await repo.GetByIdAsync(request.Id);
			if (entity == null)
			{
				throw new NotFoundException(nameof(TEntity), request.Id);
			}
			var result = await repo.DeleteAsync(request.Id);
			return Unit.Value;
		}
	}
}
