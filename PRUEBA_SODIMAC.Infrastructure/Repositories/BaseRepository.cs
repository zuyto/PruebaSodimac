// <copyright file="BaseRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using PRUEBA_SODIMAC.Application.Common.Exceptions;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Infrastructure.Common.Static;

namespace PRUEBA_SODIMAC.Infrastructure.Repositories
{
	[ExcludeFromCodeCoverage]
	internal class BaseRepository<T> : IRepository<T> where T : class
	{
		protected DbSet<T> _entities;

		public BaseRepository(DbContext dbContext)
		{
			_entities = dbContext.Set<T>();
		}

		public async Task<List<T>> GetAll()
		{
			return await _entities.ToListAsync();
		}

		public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
		{
			return await _entities.Where(predicate).ToListAsync();
		}

		public async Task<T?> GetById(int id)
		{
			return await _entities.FindAsync(id);
		}

		public async Task<T?> Get(Expression<Func<T, bool>> predicate)
		{
			return await _entities.Where(predicate).FirstOrDefaultAsync();
		}

		public async Task Add(T entity)
		{
			await _entities.AddAsync(entity);
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
			if (entity != null)
			{
				_entities.Remove(entity);
			}
		}

		public void Update(T entity)
		{
			try
			{
				_entities.Update(entity);
			}
			catch (Exception ex)
			{
				throw new GeneralException(
					$"{BaseRepositoryMessages.ERRBSRPSTR01}, ExMessage: {ex.Message}");
			}
		}

		public async Task<int> CountRecord()
		{
			return await _entities.CountAsync();
		}
	}
}
