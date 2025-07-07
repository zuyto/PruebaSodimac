// <copyright file="DireccionesEntrega.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class DireccionesEntrega
{
	public int IdDireccion { get; set; }

	public int IdCliente { get; set; }

	public string Direccion { get; set; } = null!;

	public string? Ciudad { get; set; }

	public string? Departamento { get; set; }

	public string? Pais { get; set; }

	public virtual Cliente IdClienteNavigation { get; set; } = null!;

	public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
