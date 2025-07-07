// <copyright file="GestionPedidosRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.EntityFrameworkCore;

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;
using PRUEBA_SODIMAC.Infrastructure.Context;

namespace PRUEBA_SODIMAC.Infrastructure.Repositories.GestionPedidos
{
	public class GestionPedidosRepository(GestionPedidosNetDbContext _gestionPedidosNetDbContext, ISerilogImplements serilogImplements) : IGestionPedidosRepository
	{
		private readonly GestionPedidosNetDbContext _context = _gestionPedidosNetDbContext;
		private readonly ISerilogImplements _serilogImplements = serilogImplements;

		public async Task ActualizarPedido(List<Pedido> pedidos)
		{
			_context.Pedidos.UpdateRange(pedidos);
			await _context.SaveChangesAsync();
		}

		public async Task AddPedidoAsync(Pedido pedido)
		{
			await _context.Pedidos.AddAsync(pedido);
		}

		public async Task AddPedidoAsync(List<Pedido> pedidos)
		{
			await _context.Pedidos.AddRangeAsync(pedidos);
			await _context.SaveChangesAsync();
		}

		public async Task AddRutaEntregaAsync(List<RutasEntrega> rutas)
		{
			await _context.RutasEntregas.AddRangeAsync(rutas);
			await _context.SaveChangesAsync();
		}

		public async Task AgregarHistorialEstadoPedidoAsync(HistorialEstadosPedido historialEstadosPedido)
		{
			await _context.HistorialEstadosPedidos.AddAsync(historialEstadosPedido);
		}

		public async Task<Pedido?> GetPedidoByIdAsync(int idPedido)
		{
			return await _context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == idPedido);
		}

		public async Task<IEnumerable<Pedido>> GetPedidosPorClienteAsync(int idCliente)
		{
			return await _context.Pedidos.Where(p => p.IdCliente == idCliente).ToListAsync();
		}

		public async Task<List<Pedido>> GetPedidosPorIdsPedidosAsync(List<int> idsPedios)
		{
			var pedidos = await _context.Pedidos
									.Include(p => p.IdClienteNavigation)
									.Include(p => p.IdDireccionEntregaNavigation)
									.Include(p => p.ProductosPedidos)
										.ThenInclude(pp => pp.IdProductoNavigation)
									.Where(p => idsPedios.Contains(p.IdPedido))
									.ToListAsync();

			return pedidos;
		}
	}
}
