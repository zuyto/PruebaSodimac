// <copyright file="IGestionPedidosRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos
{
	public interface IGestionPedidosRepository
	{
		Task ActualizarPedido(List<Pedido> pedidos);
		Task AddPedidoAsync(Pedido pedido);
		Task AddPedidoAsync(List<Pedido> pedidos);
		Task AddRutaEntregaAsync(List<RutasEntrega> rutas);
		Task AgregarHistorialEstadoPedidoAsync(HistorialEstadosPedido historialEstadosPedido);
		Task<Pedido?> GetPedidoByIdAsync(int idPedido);
		Task<IEnumerable<Pedido>> GetPedidosPorClienteAsync(int idsPedios);
		Task<List<Pedido>> GetPedidosPorIdsPedidosAsync(List<int> idsPedios);
	}
}
