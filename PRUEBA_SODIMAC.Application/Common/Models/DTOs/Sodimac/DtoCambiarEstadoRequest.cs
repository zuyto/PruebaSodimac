// <copyright file="DtoCambiarEstadoRequest.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoCambiarEstadoRequest
	{
		public int IdPedido { get; set; }
		public int NuevoEstado { get; set; }
	}
}
