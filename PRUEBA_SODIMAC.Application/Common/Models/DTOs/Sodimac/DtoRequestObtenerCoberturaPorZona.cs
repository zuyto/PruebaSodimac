// <copyright file="DtoRequestObtenerCoberturaPorZona.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	public class DtoRequestObtenerCoberturaPorZona
	{
		public List<DtoProductosRequestCont> request { get; set; }
		public int IdZona { get; set; }
	}
	public class DtoRequestCoberturaPorCiudad
	{
		public List<DtoProductosRequestCont> request { get; set; }
		public int IdCiudad { get; set; }
	}
	public class DtoRequestCoberturaPorDepartamento
	{
		public List<DtoProductosRequestCont> request { get; set; }
		public int IdDepto { get; set; }
	}
}
