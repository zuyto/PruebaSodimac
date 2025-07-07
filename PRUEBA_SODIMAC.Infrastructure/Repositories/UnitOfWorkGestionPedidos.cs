// <copyright file="UnitOfWorkGestionPedidos.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Infrastructure.Context;
using PRUEBA_SODIMAC.Infrastructure.Repositories.GestionPedidos;

namespace PRUEBA_SODIMAC.Infrastructure.Repositories
{
	[ExcludeFromCodeCoverage]
	public class UnitOfWorkGestionPedidos : IUnitOfWorkGestionPedidos
	{
		private readonly GestionPedidosNetDbContext _gestionPedidosNetDbContext;
		private readonly ISerilogImplements _serilogImplements;

		public UnitOfWorkGestionPedidos(GestionPedidosNetDbContext gestionPedidosNetDbContext, ISerilogImplements serilogImplements)
		{
			_gestionPedidosNetDbContext = gestionPedidosNetDbContext;
			_serilogImplements = serilogImplements;
		}

		public IGestionPedidosRepository GestionPedidosRepository => new GestionPedidosRepository(_gestionPedidosNetDbContext, _serilogImplements);
		public ICoberturaRepository CoberturaRepository => new CoberturaRepository(_gestionPedidosNetDbContext, _serilogImplements);

		public void SaveChanges()
		{
			_gestionPedidosNetDbContext.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _gestionPedidosNetDbContext.SaveChangesAsync();
		}
	}

}
