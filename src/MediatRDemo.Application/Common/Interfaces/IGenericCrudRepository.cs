﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.Application.Common.Interfaces
{
	public interface IGenericCrudRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		Task<TEntity> GetByIdAsync(TKey id);
		Task<IReadOnlyList<TEntity>> GetAllAsync();
		Task<TEntity> AddAsync(TEntity entity);
		Task<int> UpdateAsync(TEntity entity);
		Task<int> DeleteAsync(TKey id);
	}
}
