using MediatRDemo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Interfaces
{
	public interface ICrudMediatorService<TEntity, TKey> where TEntity: BaseEntity<TKey>
	{
		Task<TEntity> GetByIdAsync(TKey id);
		Task<IReadOnlyList<TEntity>> GetAllAsync();
	}
}
