using AutoMapper;
using MediatR;
using MediatRDemo.Application.Common.Exceptions;
using MediatRDemo.Application.Common.Mappings;
using MediatRDemo.Application.Interfaces;
using MediatRDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Base.Commands
{
	public class UpdateBaseCommand<TEntityDto, TKey> : IRequest
	{
		public TKey Id { get; set; }
		public TEntityDto Entity { get; set; }
	}

	public class UpdateBaseCommandHandler<TEntityDto, TEntity, TKey>
		where TEntityDto :IMapFrom<TEntity>
		where TEntity : BaseEntity<TKey>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IGenericCrudRepositoryScripts scripts;
		private readonly IMapper mapper;

		public UpdateBaseCommandHandler(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.scripts = scripts;
			this.mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateBaseCommand<TEntityDto, TKey> request, CancellationToken cancellationToken)
		{
			var repo = unitOfWork.Repository<TEntity, TKey>(scripts);
			var entity = await repo.GetByIdAsync(request.Id);
			if(entity == null)
			{
				throw new NotFoundException(nameof(TEntity), request.Id);
			}
			var dbId = entity.Id;
			entity = mapper.Map<TEntity>(request.Entity);
			entity.Id = dbId;
			var result = repo.UpdateAsync(entity);
			return Unit.Value;
		}
	}
}
