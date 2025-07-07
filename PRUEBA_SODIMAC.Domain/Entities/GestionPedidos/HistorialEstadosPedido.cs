// <copyright file="HistorialEstadosPedido.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class HistorialEstadosPedido
{
	public int IdHistorialPedido { get; set; }

	public int IdPedido { get; set; }

	public int IdEstadoPedido { get; set; }

	public DateTime FechaCambioEstado { get; set; }

	public virtual EstadosPedido IdEstadoPedidoNavigation { get; set; } = null!;

	public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
