using MediatR;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Base
{
	public abstract class GetAllBaseQuery<TEntity, TKey> : IRequest<IReadOnlyList<TEntity>> where TEntity : BaseEntity<TKey>
	{
	}

	public abstract class GetAllBaseQueryHandler<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericCrudRepositoryScripts scripts;

		public GetAllBaseQueryHandler(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
		}

		public async Task<IReadOnlyList<TEntity>> Handle(
			GetAllBaseQuery<TEntity, TKey> request,
			CancellationToken cancellationToken)
		{
			var repo = unitOfWork.Repository<TEntity, TKey>(scripts);
			return await repo.GetAllAsync();
		}
	}
}
