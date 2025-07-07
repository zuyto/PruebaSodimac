// <copyright file="PedidosController .cs" company="MAuro Martinez">
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
using PRUEBA_SODIMAC.Application.Common.Models.DTOs;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Application.Common.Static;
using PRUEBA_SODIMAC.Application.Common.Struct;
using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Api.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class PedidosController : ControllerBase
	{
		private readonly ISerilogImplements _serilogImplements;
		private readonly IPedidoService _application;

		/// <summary>
		/// Contructor
		/// </summary>
		/// <param name="serilogImplements"></param>
		/// <param name="application"></param>
		public PedidosController(ISerilogImplements serilogImplements, IPedidoService application)
		{
			_serilogImplements = serilogImplements;
			_application = application;
		}


		/// <summary>
		/// Registra múltiples pedidos y asigna rutas mediante el SaaS.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("RegistrarPedidos")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RegistrarPedidos([FromBody] List<DtoPedidoRequest> request)
		{
			ObjectResult result;
			string methodName = nameof(RegistrarPedidos);

			try
			{
				if (request == null)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<DtoJsonResponseSaas>.CreateError(UserTypeMessages.ERROR_REQUEST, new DtoJsonResponseSaas()));
				}

				DtoGenericResponse<DtoJsonResponseSaas> response = await _application.RegistrarPedidoAsync(request);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponseSaas>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponseSaas>.CreateSuccessful(response.Resultado!, response.Mensaje!));
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
		/// Consulta los pedidos de un cliente.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("GetPedidosPorCliente")]
		[HttpPost]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<Pedido>>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<Pedido>>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<Pedido>>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GetPedidosPorCliente([FromBody] int? idCliente)
		{
			ObjectResult result;
			string methodName = nameof(RegistrarPedidos);

			try
			{
				if (null == idCliente)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<IEnumerable<Pedido>>.CreateError(UserTypeMessages.ERROR_REQUEST, []));
				}

				DtoGenericResponse<IEnumerable<Pedido>> response = await _application.ObtenerPedidosPorClienteAsync(idCliente);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<IEnumerable<Pedido>>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<IEnumerable<Pedido>>.CreateSuccessful(response.Resultado!, response.Mensaje!));
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
		/// Cambia el estado de un pedido.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("CambiarEstadoPedido")]
		[HttpPut]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponse>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponse>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CambiarEstadoPedido([FromBody] DtoCambiarEstadoRequest request)
		{
			ObjectResult result;
			string methodName = nameof(RegistrarPedidos);

			try
			{
				if (null == request)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<DtoJsonResponse>.CreateError(UserTypeMessages.ERROR_REQUEST, new DtoJsonResponse()));
				}

				DtoGenericResponse<DtoJsonResponse> response = await _application.CambiarEstadoPedidoAsync(request);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponse>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponse>.CreateSuccessful(response.Resultado!, response.Mensaje!));
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
		/// Asignar ruta a un pedido desde el SaaS y cambiar su estado.
		/// </summary>
		/// <returns></returns>
		/// <response code="200">OK. Devuelve el objeto solicitado</response>
		/// <response code="409">Error durante el proceso</response>
		/// <response code="500">Error interno en el API</response>
		/// <response code="404">Error controlado cuando el Request es invalido</response>
		/// <response code="400">Error controlado por el flitro del request</response>
		[Route("AsignarRutaDesdeSaas")]
		[HttpPut]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status409Conflict)]
		[ProducesResponseType(typeof(ApiResponse<DtoErrorResponse>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(ApiResponse<DtoJsonResponseSaas>), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ApiResponse<List<string>>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AsignarRutaDesdeSaas([FromBody] int? idPedido)
		{
			ObjectResult result;
			string methodName = nameof(RegistrarPedidos);

			try
			{
				if (null == idPedido)
				{
					return StatusCode(StatusCodes.Status404NotFound, ApiResponse<DtoJsonResponseSaas>.CreateError(UserTypeMessages.ERROR_REQUEST, new DtoJsonResponseSaas()));
				}

				DtoGenericResponse<DtoJsonResponseSaas> response = await _application.AsignarRutaSaasYActualizarPedidoAsync(idPedido);


				if (!response.EsExitoso)
				{
					result = StatusCode(StatusCodes.Status409Conflict, ApiResponse<DtoJsonResponseSaas>.CreateUnsuccessful(response.Resultado!, response.Mensaje!));
				}
				else
				{
					result = Ok(ApiResponse<DtoJsonResponseSaas>.CreateSuccessful(response.Resultado!, response.Mensaje!));
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
