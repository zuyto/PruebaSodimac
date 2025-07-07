// <copyright file="Pedido.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Pedido
{
	public int IdPedido { get; set; }

	public int IdCliente { get; set; }

	public DateTime FechaEntrega { get; set; }

	public int IdEstadoPedido { get; set; }

	public int? RutaAsignadaId { get; set; }

	public int? IdDireccionEntrega { get; set; }

	public virtual ICollection<HistorialEstadosPedido> HistorialEstadosPedidos { get; set; } = new List<HistorialEstadosPedido>();

	public virtual Cliente IdClienteNavigation { get; set; } = null!;

	public virtual DireccionesEntrega? IdDireccionEntregaNavigation { get; set; }

	public virtual EstadosPedido IdEstadoPedidoNavigation { get; set; } = null!;

	public virtual ICollection<ProductosPedido> ProductosPedidos { get; set; } = new List<ProductosPedido>();

	public virtual RutasEntrega? RutaAsignada { get; set; }
}
