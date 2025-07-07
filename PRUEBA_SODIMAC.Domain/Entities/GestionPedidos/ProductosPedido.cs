// <copyright file="ProductosPedido.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class ProductosPedido
{
	public int IdPedido { get; set; }

	public int IdProducto { get; set; }

	public int Cantidad { get; set; }

	public virtual Pedido IdPedidoNavigation { get; set; } = null!;

	public virtual Producto IdProductoNavigation { get; set; } = null!;
}
