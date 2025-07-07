// <copyright file="CoberturaService.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.Extensions.Logging;

using PRUEBA_SODIMAC.Application.Common.Helpers;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Application.Common.Static;

namespace PRUEBA_SODIMAC.Application.Services
{
	public class CoberturaService : ICoberturaService
	{
		private readonly IUnitOfWorkGestionPedidos _unitOfWorkGestionPedidos;
		private readonly ILogger<CoberturaService> _logger;

		public CoberturaService(IUnitOfWorkGestionPedidos unitOfWork, ILogger<CoberturaService> logger)
		{
			_unitOfWorkGestionPedidos = unitOfWork;
			_logger = logger;
		}

		public async Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaZonaAsync(List<DtoProductosRequestCont> request, int idZona)
		{
			try
			{
				_logger.LogInformation("Consultando cobertura por Zona. Zona: {IdZona}, request: {request}", idZona, string.Join(",", request.Select(s => s.Sku)));

				List<DtoJsonResponseCobertura> coberturaPlano = await _unitOfWorkGestionPedidos.CoberturaRepository.RedesPorIdZona(request, idZona);


				if (!coberturaPlano.Any())
				{
					return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(false, coberturaPlano, UserTypeMessages.OKERRGEN01);
				}

				_logger.LogInformation("Cobertura obtenida por Zona {IdZona}: {CantidadResultados} resultados", idZona, coberturaPlano.Count);


				return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(true, coberturaPlano, UserTypeMessages.OKGEN01);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error obteniendo cobertura por Zona {IdZona}", idZona);
				throw;
			}
		}

		public async Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaCiudadAsync(List<DtoProductosRequestCont> request, int idCiudad)
		{
			try
			{
				_logger.LogInformation("Consultando cobertura por Ciudad. Ciudad: {IdCiudad}, request: {request}", idCiudad, string.Join(",", request.Select(s => s.Sku)));

				var coberturaPlano = await _unitOfWorkGestionPedidos.CoberturaRepository.RedesPorIdCiudad(request, idCiudad);

				if (!coberturaPlano.Any())
				{
					return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(false, coberturaPlano, UserTypeMessages.OKERRGEN01);
				}

				_logger.LogInformation("Cobertura obtenida por Ciudad {IdCiudad}: {CantidadResultados} resultados", idCiudad, coberturaPlano.Count);



				return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(true, coberturaPlano, UserTypeMessages.OKGEN01);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error obteniendo cobertura por Ciudad {IdCiudad}", idCiudad);
				throw;
			}
		}

		public async Task<DtoGenericResponse<List<DtoJsonResponseCobertura>>> ObtenerCoberturaDeptoAsync(List<DtoProductosRequestCont> request, int idDepto)
		{
			try
			{
				_logger.LogInformation("Consultando cobertura por Depto. Depto: {IdDepto}, request: {request}", idDepto, string.Join(",", request.Select(s => s.Sku)));

				var coberturaPlano = await _unitOfWorkGestionPedidos.CoberturaRepository.RedesPorIdDepto(request, idDepto);

				if (!coberturaPlano.Any())
				{
					return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(false, coberturaPlano, UserTypeMessages.OKERRGEN01);
				}

				_logger.LogInformation("Cobertura obtenida por Depto {IdDepto}: {CantidadResultados} resultados", idDepto, coberturaPlano.Count);


				return GenericHelpers.BuildResponse<List<DtoJsonResponseCobertura>>(true, coberturaPlano, UserTypeMessages.OKGEN01);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error obteniendo cobertura por Depto {IdDepto}", idDepto);
				throw;
			}
		}

	}

}
