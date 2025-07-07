// <copyright file="RutasEntrega.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class RutasEntrega
{
	public int IdRutaEntrega { get; set; }

	public string NombreRuta { get; set; } = null!;

	public int IdEstadoRutaEntrega { get; set; }

	public virtual ICollection<HistorialEstadosRutaEntrega> HistorialEstadosRutaEntregas { get; set; } = new List<HistorialEstadosRutaEntrega>();

	public virtual EstadosRutaEntrega IdEstadoRutaEntregaNavigation { get; set; } = null!;

	public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
	public string Guia { get; set; }
}
