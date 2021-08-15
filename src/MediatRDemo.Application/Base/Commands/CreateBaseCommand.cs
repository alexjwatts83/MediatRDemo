using AutoMapper;
using MediatR;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Base.Commands
{
	public class CreateBaseCommand<TEntityDto, TKey> : IRequest<TKey>
	{
		public TEntityDto Entity { get; set; }
	}

	public class CreateBaseCommandHandler<TEntityDto, TEntity, TKey>
		where TEntity : BaseEntity<TKey>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericCrudRepositoryScripts scripts;
		private readonly IMapper _mapper;

		public CreateBaseCommandHandler(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
			_mapper = mapper;
		}

		public async Task<TKey> Handle(
			CreateBaseCommand<TEntityDto, TKey> request,
			CancellationToken cancellationToken)
		{
			var repo = unitOfWork.Repository<TEntity, TKey>(scripts);
			TEntity entity = _mapper.Map<TEntity>(request.Entity);
			var result = await repo.AddAsync(entity);
			if (result == null)
			{
				return default;
			}
			return entity.Id;
		}
	}
}
