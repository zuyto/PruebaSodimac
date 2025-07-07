// <copyright file="Transversales.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using PRUEBA_SODIMAC.Application.Common.Helpers;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Application.Common.Static;
using PRUEBA_SODIMAC.Application.Common.Struct;
using PRUEBA_SODIMAC.Domain;

namespace PRUEBA_SODIMAC.Application.Services.Transversales
{
	[ExcludeFromCodeCoverage]
	public class Transversales(HttpServiceManager httpServiceManager, IOptions<AppSettings> options) : ITransversales
	{
		private readonly HttpServiceManager _httpServiceManager = httpServiceManager;
		private readonly AppSettings _appSettings = options.Value;


		/// <summary>
		/// Consume el servicio de Milenium para crear guías de forma masiva (One to Many).
		/// </summary>
		/// <param name="requestMilenium"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<DtoJsonResponseSaas> ConsumirServicioSaas(DtoRequestMilenium requestMilenium)
		{
			DtoGenericResponseHttp respuestaApiExterna = new();
			DtoJsonResponseSaas respuesta = new();


			string json = JsonConvert.SerializeObject(requestMilenium, Formatting.Indented);


			respuestaApiExterna = await _httpServiceManager.PostHttpAsync(ConfigurationStruct.SAAS, json, _appSettings.AppSettingsConfig.Token);



			if (null == respuestaApiExterna || string.IsNullOrWhiteSpace(respuestaApiExterna.ResultadoHttp))
			{
				respuesta = new DtoJsonResponseSaas { Estado = false, Mensaje = "No se retornaron datos para la generación de la guia", Value = null };

			}

			var jsonRaw = respuestaApiExterna.ResultadoHttp.Trim();

			var jObject = JObject.Parse(jsonRaw);
			var status = jObject["status"]?.ToString()?.Trim();


			if (string.Equals(status, Constantes.PROCESADO, StringComparison.OrdinalIgnoreCase))
			{
				DtoGenericResponse<object> res = await ProcesaOkHttp(respuestaApiExterna);

				respuesta = new DtoJsonResponseSaas { Estado = true, Mensaje = res.Mensaje, Value = res.Resultado, IsOkEsquema = res.IsOkEsquema };

			}
			else if (string.Equals(status, Constantes.ERROR, StringComparison.OrdinalIgnoreCase))
			{
				DtoGenericResponse<object> res = await ProcesaErrorHttp(respuestaApiExterna);

				respuesta = new DtoJsonResponseSaas { Estado = false, Mensaje = res.Mensaje, Value = res.Resultado, IsOkEsquema = res.IsOkEsquema };

			}
			else
			{
				respuestaApiExterna.Mensaje = UserTypeMessages.ERROR_CREA_GUIA;

				respuesta = new DtoJsonResponseSaas { Estado = false, Mensaje = UserTypeMessages.ERROR_CREA_GUIA, IsOkEsquema = false };
			}



			return respuesta;

		}

		private static async Task<DtoGenericResponse<object>> ProcesaErrorHttp(DtoGenericResponseHttp respuestaApiExterna)
		{
			bool validaEsquemaErr = GenericHelpers.ValidarEsquemaErr(respuestaApiExterna.ResultadoHttp);
			object? erroRes = validaEsquemaErr ? GenericHelpers.TryDeserialize<DtoResponseServiceMileniumFallida>(respuestaApiExterna.ResultadoHttp) : respuestaApiExterna.ResultadoHttp;
			Console.WriteLine($"\n*** ERROR CONSUMIENDO TRASPORTADORA ***\n | ERROR:{erroRes}");

			return await Task.FromResult(GenericHelpers.BuildResponse<object>(false, erroRes, respuestaApiExterna.Mensaje, validaEsquemaErr));
		}

		private static async Task<DtoGenericResponse<object>> ProcesaOkHttp(DtoGenericResponseHttp respuestaApiExterna)
		{
			bool validaEsquemaOk = GenericHelpers.ValidarEsquemaOk(respuestaApiExterna.ResultadoHttp);
			object? erroRes = validaEsquemaOk ? GenericHelpers.TryDeserialize<DtoResponseServiceMileniumExitosa>(respuestaApiExterna.ResultadoHttp) : respuestaApiExterna.ResultadoHttp;
			Console.WriteLine($"\n*** RESPONSE CONSUMIENDO TRASPORTADORA ***\n | RSP: {erroRes}");

			return await Task.FromResult(GenericHelpers.BuildResponse<object>(true, erroRes, respuestaApiExterna.Mensaje, validaEsquemaOk));
		}

		/// <summary>
		/// Arma la respuesta JSON
		/// </summary>
		/// <param name="respuestaApiExterna"></param>
		/// <param name="codInterno"></param>
		/// <param name="pedido"></param>
		/// <param name="estado"></param>
		/// <param name="responseServiceMilenium"></param>
		/// <returns></returns>
		//private static DtoJsonResponse ArmarRespuesta(DtoGenericResponseHttp? respuestaApiExterna, string? codInterno, string pedido, bool estado, dynamic responseServiceMilenium = null)
		//{
		//	return new DtoJsonResponse
		//	{
		//		Estado = estado,
		//		Mensaje = respuestaApiExterna?.Mensaje,
		//		Value = responseServiceMilenium,
		//		CodInterno = codInterno,
		//		Pedido = pedido
		//	};
		//}



	}
}
