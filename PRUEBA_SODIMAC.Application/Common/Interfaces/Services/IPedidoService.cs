// <copyright file="IPedidoService.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Application.Common.Models.DTOs;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Services
{
	public interface IPedidoService
	{
		/// <summary>
		/// Registra un nuevo pedido en estado 'Registrado'.
		/// </summary>
		Task<DtoGenericResponse<DtoJsonResponseSaas>> RegistrarPedidoAsync(List<DtoPedidoRequest> pedidoRequest);

		/// <summary>
		/// Asigna una ruta a un pedido y cambia su estado a 'En Proceso'.
		/// </summary>
		Task<DtoGenericResponse<DtoJsonResponse>> AsignarRutaPedidoAsync(int idPedido, int idRutaEntrega);

		/// <summary>
		/// Cambia el estado del pedido (Ej: Entregado, Cancelado).
		/// </summary>
		Task<DtoGenericResponse<DtoJsonResponse>> CambiarEstadoPedidoAsync(DtoCambiarEstadoRequest request);

		/// <summary>
		/// Obtiene todos los pedidos de un cliente.
		/// </summary>
		Task<DtoGenericResponse<IEnumerable<Pedido>>> ObtenerPedidosPorClienteAsync(int? idCliente);

		/// <summary>
		/// Obtiene un pedido por su Id.
		/// </summary>
		Task<DtoGenericResponse<Pedido>> ObtenerPedidoPorIdAsync(int idPedido);
		Task<DtoGenericResponse<DtoJsonResponseSaas>> AsignarRutaSaasYActualizarPedidoAsync(int? idPedido);
	}
}
