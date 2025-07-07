// <copyright file="DtoJsonResponseCobertura.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoJsonResponseCobertura
	{
		public int IdZona { get; set; }
		public int IdCiudad { get; set; }
		public int IdDepto { get; set; }
		public string Promesa { get; set; } = string.Empty;
		public int IdPromesaCliente { get; set; }
		public int? IdRedZona { get; set; }

		public List<DtoProductoCoberturaDetalle> Productos { get; set; } = [];
	}
}
