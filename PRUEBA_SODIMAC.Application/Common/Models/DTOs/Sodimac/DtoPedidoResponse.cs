// <copyright file="DtoPedidoResponse.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoPedidoResponse
	{
		public int IdPedido { get; set; }
		public string Estado { get; set; } = string.Empty;
		public string RutaAsignada { get; set; } = string.Empty;
	}
}
