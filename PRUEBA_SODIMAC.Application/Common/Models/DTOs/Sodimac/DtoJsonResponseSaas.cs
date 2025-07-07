// <copyright file="DtoJsonResponseSaas.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoJsonResponseSaas
	{
		public bool Estado { get; set; }
		public string? Mensaje { get; set; }
		public dynamic? Value { get; set; }
		public string? CodInterno { get; set; }
		public string? Pedido { get; set; }

		[JsonIgnore]
		public bool IsOkEsquema { get; set; }
	}
}
