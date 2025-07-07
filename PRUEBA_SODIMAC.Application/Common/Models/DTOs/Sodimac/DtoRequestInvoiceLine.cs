// <copyright file="DtoRequestInvoiceLine.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoRequestInvoiceLine
	{
		[JsonProperty("codigo")]
		public string? Codigo { get; set; }

		[JsonProperty("nombre")]
		public string Nombre { get; set; }

		[JsonProperty("cantidad")]
		public int? Cantidad { get; set; }

		[JsonProperty("peso_producto")]
		public decimal? Peso_producto { get; set; }

		[JsonProperty("largo")]
		public decimal? Largo { get; set; }

		[JsonProperty("alto")]
		public decimal? Alto { get; set; }

		[JsonProperty("ancho")]
		public decimal? Ancho { get; set; }

		[JsonProperty("volumen_producto")]
		public decimal? Volumen_producto { get; set; }
	}
}
