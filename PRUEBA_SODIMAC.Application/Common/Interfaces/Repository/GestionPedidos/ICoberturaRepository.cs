// <copyright file="ICoberturaRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos
{
	public interface ICoberturaRepository
	{
		Task<List<DtoJsonResponseCobertura>> RedesPorIdCiudad(List<DtoProductosRequestCont> request, int idCiudad);
		Task<List<DtoJsonResponseCobertura>> RedesPorIdDepto(List<DtoProductosRequestCont> request, int idDepto);
		Task<List<DtoJsonResponseCobertura>> RedesPorIdZona(List<DtoProductosRequestCont> request, int idZona);
	}
}
