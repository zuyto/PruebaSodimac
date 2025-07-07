// <copyright file="ICoberturaService.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Services
{
	public interface ICoberturaService
	{
		Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaCiudadAsync(List<DtoProductosRequestCont> request, int idCiudad);
		Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaDeptoAsync(List<DtoProductosRequestCont> request, int idDepto);
		Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaZonaAsync(List<DtoProductosRequestCont> request, int idZona);
	}
}
