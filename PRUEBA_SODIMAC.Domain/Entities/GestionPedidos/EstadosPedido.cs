// <copyright file="EstadosPedido.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class EstadosPedido
{
	public int IdEstadoPedido { get; set; }

	public string NombreEstado { get; set; } = null!;

	public virtual ICollection<HistorialEstadosPedido> HistorialEstadosPedidos { get; set; } = new List<HistorialEstadosPedido>();

	public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
