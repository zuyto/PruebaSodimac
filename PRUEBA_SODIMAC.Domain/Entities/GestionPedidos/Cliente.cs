// <copyright file="Cliente.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Cliente
{
	public int IdCliente { get; set; }

	public string Nombres { get; set; } = null!;

	public string Direccion { get; set; } = null!;

	public string CorreoElectronico { get; set; } = null!;

	public virtual ICollection<DireccionesEntrega> DireccionesEntregas { get; set; } = new List<DireccionesEntrega>();

	public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
