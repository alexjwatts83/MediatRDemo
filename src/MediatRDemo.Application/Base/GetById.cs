using MediatR;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Base
{
	public abstract class GetByIdBaseQuery<TEntity, TKey> : IRequest<TEntity> where TEntity : BaseEntity<TKey>
	{
		public TKey Id { get; set; }
	}

	public abstract class GetByIdBaseQueryHandler<TEntity, TKey>
		where TEntity : BaseEntity<TKey>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericCrudRepositoryScripts scripts;

		public GetByIdBaseQueryHandler(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
		}

		public async Task<TEntity> Handle(
			GetByIdBaseQuery<TEntity, TKey> request,
			CancellationToken cancellationToken)
		{
			var repo = unitOfWork.Repository<TEntity, TKey>(scripts);
			return await repo.GetByIdAsync(request.Id);
		}
	}
}
