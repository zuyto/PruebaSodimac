// <copyright file="DtoProductoCobertura.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoProductoCobertura
	{
		public string? PrdLvlNumber { get; set; }
		public int? IdZona { get; set; }
		public int? IdCiudad { get; set; }
		public int? IdDepto { get; set; }
		public int? IdRedZona { get; set; }
		public string? Promesa { get; set; }
		public int? IdPromesaCliente { get; set; }
	}
}
