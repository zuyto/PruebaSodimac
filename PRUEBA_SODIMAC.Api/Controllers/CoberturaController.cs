// <copyright file="CoberturaController.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using PRUEBA_SODIMAC.Api.Response;
using PRUEBA_SODIMAC.Application.Common.Helpers;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Application.Common.Static;
using PRUEBA_SODIMAC.Application.Common.Struct;

namespace PRUEBA_SODIMAC.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CoberturaController : ControllerBase
	{
		private readonly ISerilogImplements _serilogImplements;
		private readonly ICoberturaService _application;

		/// <summary>
		/// Contructor
		/// </summary>
		/// <param name="serilogImplements"></param>
		/// <param name="application"></param>
		public CoberturaController(ISerilogImplements serilogImplements, ICoberturaService application)
		{
			_serilogImplements = serilogImplements;
			_application = application;
		}


		/// <summary>
		/// Obtiene la cobertura de SKUs por zona.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("ObtenerCoberturaPorZona")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ObtenerCoberturaPorZona([FromBody] DtoRequestObtenerCoberturaPorZona request)
		{
			ObjectResult result;
			string methodName = nameof(ObtenerCoberturaPorZona);

			try
			{
				if (request == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<List<DtoJsonResponseCobertura>>.CreateError(UserTypeMessages.ERROR_REQUEST, new List<DtoJsonResponseCobertura>()));
				}

				DtoGenericResponse<List<DtoJsonResponseCobertura>> response = await _application.ObtenerCoberturaZonaAsync(request.request, request.IdZona);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<List<DtoJsonResponseCobertura>>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<List<DtoJsonResponseCobertura>>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}


		/// <summary>
		/// Obtiene la cobertura de SKUs por ciudad.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("ObtenerCoberturaPorCiudad")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ObtenerCoberturaPorCiudad([FromBody] DtoRequestCoberturaPorCiudad request)
		{
			ObjectResult result;
			string methodName = nameof(ObtenerCoberturaPorCiudad);

			try
			{
				if (request == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<List<DtoJsonResponseCobertura>>.CreateError(UserTypeMessages.ERROR_REQUEST, new List<DtoJsonResponseCobertura>()));
				}

				DtoGenericResponse<List<DtoJsonResponseCobertura>> response = await _application.ObtenerCoberturaCiudadAsync(request.request, request.IdCiudad);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<List<DtoJsonResponseCobertura>>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<List<DtoJsonResponseCobertura>>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}

		/// <summary>
		/// Obtiene la cobertura de SKUs por ciudad.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("ObtenerCoberturaPorDepartamento")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<List<DtoJsonResponseCobertura>>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> ObtenerCoberturaPorDepartamento([FromBody] DtoRequestCoberturaPorDepartamento request)
		{
			ObjectResult result;
			string methodName = nameof(ObtenerCoberturaPorCiudad);

			try
			{
				if (request == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<List<DtoJsonResponseCobertura>>.CreateError(UserTypeMessages.ERROR_REQUEST, new List<DtoJsonResponseCobertura>()));
				}

				DtoGenericResponse<List<DtoJsonResponseCobertura>> response = await _application.ObtenerCoberturaDeptoAsync(request.request, request.IdDepto);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<List<DtoJsonResponseCobertura>>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<List<DtoJsonResponseCobertura>>.CreateSuccessful(response.Resultado!, response.Mensaje!));
				}

				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information, JsonConvert.SerializeObject(result, Formatting.Indented), null, string.Format(UserTypeMessages.CONTROLLER_RESPONSE, methodName));

				return result;

			}
			catch (Exception ex)
			{
				_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Critical, JsonConvert.SerializeObject(ex.HandleExceptionMessage(true), Formatting.Indented), null, string.Format(UserTypeMessages.ERRCATHCONTROLLER, methodName));
				return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse<DtoErrorResponse>.CreateError(UserTypeMessages.ERROR_NO_CONTROLADO, ex.HandleExceptionMessage()));
			}
		}

	}
}
