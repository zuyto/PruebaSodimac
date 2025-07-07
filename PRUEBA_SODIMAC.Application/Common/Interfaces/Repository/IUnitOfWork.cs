// <copyright file="IUnitOfWork.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		DatabaseFacade Database { get; }
		void SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
