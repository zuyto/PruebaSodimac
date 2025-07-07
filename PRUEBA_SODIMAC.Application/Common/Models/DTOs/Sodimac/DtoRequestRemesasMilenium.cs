// <copyright file="DtoRequestRemesasMilenium.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoRequestRemesasMilenium
	{
		[JsonProperty("fecha")]
		public string Fecha { get; set; }

		[JsonProperty("id_cliente")]
		public string Id_cliente { get; set; }

		[JsonProperty("nombre_remitente")]
		public string Nombre_remitente { get; set; }

		[JsonProperty("direccion_remitente")]
		public string? Direccion_remitente { get; set; }

		[JsonProperty("telefono_remitente")]
		public string? Telefono_remitente { get; set; }

		[JsonProperty("ciudad_remitente")]
		public string Ciudad_remitente { get; set; }

		[JsonProperty("nit_destinatario")]
		public string Nit_destinatario { get; set; }

		[JsonProperty("nombre_destinatario")]
		public string Nombre_destinatario { get; set; }

		[JsonProperty("direccion_destinatario")]
		public string Direccion_destinatario { get; set; }

		[JsonProperty("ciudad_destinatario")]
		public string Ciudad_destinatario { get; set; }

		[JsonProperty("telefono_destinatario")]
		public string? Telefono_destinatario { get; set; }

		[JsonProperty("valor_declarado")]
		public decimal Valor_declarado { get; set; }

		[JsonProperty("volumen_producto")]
		public decimal Volumen_producto { get; set; }

		[JsonProperty("peso_producto")]
		public decimal Peso_producto { get; set; }

		[JsonProperty("cant_producto")]
		public int Cant_producto { get; set; }

		[JsonProperty("pedido")]
		public string Pedido { get; set; }

		[JsonProperty("observaciones")]
		public string Observaciones { get; set; }

		[JsonProperty("division")]
		public string Division { get; set; }

		[JsonProperty("invoice_lines")]
		public List<DtoRequestInvoiceLine> Invoice_lines { get; set; }



		[JsonIgnore]
		public string? CodInterno { get; set; }
		[JsonIgnore]
		public string? Sticker { get; set; }
	}
}
