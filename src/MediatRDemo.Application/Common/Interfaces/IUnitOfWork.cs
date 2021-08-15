using MediatRDemo.Application.Common.Interfaces;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.Application.Interfaces
{
	public interface IUnitOfWork
    {
        IGenericCrudRepository<TEntity, TKey> Repository<TEntity, TKey>(IGenericCrudRepositoryScripts scripts)
            where TEntity : BaseEntity<TKey>;
    }
}
