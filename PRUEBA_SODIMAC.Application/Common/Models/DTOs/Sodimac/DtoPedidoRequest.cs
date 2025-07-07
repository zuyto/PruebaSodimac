// <copyright file="DtoPedidoRequest.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoPedidoRequest
	{
		public int IdCliente { get; set; }
		public List<DtoProductoRequest> Productos { get; set; } = new();
		public DateTime FechaEntrega { get; set; }
		public string DireccionEntrega { get; set; } = string.Empty;
		public int? IdDireccionEntrega { get; internal set; }
	}
}
