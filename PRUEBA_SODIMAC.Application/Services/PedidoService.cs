// <copyright file="PedidoService.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Newtonsoft.Json;

using PRUEBA_SODIMAC.Application.Common.Enumerations;
using PRUEBA_SODIMAC.Application.Common.Helpers;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Application.Common.Static;
using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Application.Services
{
	public class PedidoService(IUnitOfWorkGestionPedidos unitOfWorkGestionPedidos, HttpServiceManager httpServiceManager, IArmarJsonRequestMilenium armarJsonRequestMilenium, ITransversales transversales) : IPedidoService
	{
		private readonly IUnitOfWorkGestionPedidos _unitOfWorkGestionPedidos = unitOfWorkGestionPedidos;
		private readonly HttpServiceManager _httpServiceManager = httpServiceManager;
		private readonly IArmarJsonRequestMilenium _armarJsonRequestMilenium = armarJsonRequestMilenium;
		private readonly ITransversales _transversales = transversales;


		/// <summary>
		/// 
		/// </summary>
		/// <param name="idPedido"></param>
		/// <param name="idRutaEntrega"></param>
		/// <returns></returns>
		/// <exception cref="BusinessException"></exception>
		public async Task<DtoGenericResponse<DtoJsonResponse>> AsignarRutaPedidoAsync(int idPedido, int idRutaEntrega)
		{
			Pedido? pedido = await _unitOfWorkGestionPedidos.GestionPedidosRepository.GetPedidoByIdAsync(idPedido);

			if (null == pedido)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponse>(false, pedido, UserTypeMessages.OKERRGEN01);
			}

			pedido.RutaAsignadaId = idRutaEntrega;
			pedido.IdEstadoPedido = (int)EstadosProceso.EnProceso;


			await _unitOfWorkGestionPedidos.GestionPedidosRepository.AgregarHistorialEstadoPedidoAsync(new HistorialEstadosPedido
			{
				IdPedido = pedido.IdPedido,
				IdEstadoPedido = pedido.IdEstadoPedido,
				FechaCambioEstado = DateTime.UtcNow
			});

			await _unitOfWorkGestionPedidos.SaveChangesAsync();

			return GenericHelpers.BuildResponse<DtoJsonResponse>(true, pedido, UserTypeMessages.OKGEN01);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <exception cref="BusinessException"></exception>
		public async Task<DtoGenericResponse<DtoJsonResponse>> CambiarEstadoPedidoAsync(DtoCambiarEstadoRequest request)
		{
			Pedido? pedido = await _unitOfWorkGestionPedidos.GestionPedidosRepository.GetPedidoByIdAsync(request.IdPedido);
			if (null == pedido)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponse>(false, pedido, UserTypeMessages.OKERRGEN01);
			}

			pedido.IdEstadoPedido = request.NuevoEstado;

			await _unitOfWorkGestionPedidos.GestionPedidosRepository.AgregarHistorialEstadoPedidoAsync(new HistorialEstadosPedido
			{
				IdPedido = pedido.IdPedido,
				IdEstadoPedido = pedido.IdEstadoPedido,
				FechaCambioEstado = DateTime.UtcNow
			});

			await _unitOfWorkGestionPedidos.SaveChangesAsync();

			return GenericHelpers.BuildResponse<DtoJsonResponse>(true, pedido, UserTypeMessages.OKGEN01);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idCliente"></param>
		/// <returns></returns>
		public async Task<DtoGenericResponse<IEnumerable<Pedido>>> ObtenerPedidosPorClienteAsync(int? idCliente)
		{

			IEnumerable<Pedido> pedidos = await _unitOfWorkGestionPedidos.GestionPedidosRepository.GetPedidosPorClienteAsync((int)idCliente!);
			if (!pedidos.Any())
			{
				return GenericHelpers.BuildResponse<IEnumerable<Pedido>>(false, pedidos, UserTypeMessages.OKERRGEN01);
			}
			return GenericHelpers.BuildResponse<IEnumerable<Pedido>>(true, pedidos, UserTypeMessages.OKGEN01);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="idPedido"></param>
		/// <returns></returns>
		public async Task<DtoGenericResponse<Pedido>> ObtenerPedidoPorIdAsync(int idPedido)
		{

			Pedido? pedido = await _unitOfWorkGestionPedidos.GestionPedidosRepository.GetPedidoByIdAsync(idPedido);

			if (null == pedido)
			{
				return GenericHelpers.BuildResponse<Pedido>(false, pedido, UserTypeMessages.OKERRGEN01);
			}

			return GenericHelpers.BuildResponse<Pedido>(true, pedido, UserTypeMessages.OKERRGEN01);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="pedidosRequest"></param>
		/// <returns></returns>
		/// <exception cref="BusinessException"></exception>
		public async Task<DtoGenericResponse<DtoJsonResponseSaas>> RegistrarPedidoAsync(List<DtoPedidoRequest> pedidosRequest)
		{
			var pedidos = new List<Pedido>();

			foreach (var request in pedidosRequest)
			{
				pedidos.Add(new Pedido
				{
					IdCliente = request.IdCliente,
					FechaEntrega = request.FechaEntrega,
					IdEstadoPedido = (int)EstadosProceso.Registrado,
					IdDireccionEntrega = request.IdDireccionEntrega,

				});
			}

			// Insertar todos los pedidos
			await _unitOfWorkGestionPedidos.GestionPedidosRepository.AddPedidoAsync(pedidos);
			await _unitOfWorkGestionPedidos.SaveChangesAsync();


			List<int> idsPedios = pedidos.Select(p => p.IdPedido).ToList();

			DtoRequestMilenium jsonRequest = await _armarJsonRequestMilenium.ArmarJson(idsPedios);


			// Llamar al SaaS
			DtoJsonResponseSaas responseServicioSaas = await _transversales.ConsumirServicioSaas(jsonRequest);



			if (responseServicioSaas.Estado && responseServicioSaas.IsOkEsquema)
			{
				List<RutasEntrega> rutas = new();

				var json = JsonConvert.SerializeObject(responseServicioSaas.Value);

				var objeto = JsonConvert.DeserializeObject<DtoResponseServiceMileniumExitosa>(json);


				DtoResponseServiceMileniumExitosa? serviceSaas = JsonConvert.DeserializeObject<DtoResponseServiceMileniumExitosa>(JsonConvert.SerializeObject(responseServicioSaas.Value));


				List<DtoResponsePedidosMilenium> pedidosSaas = serviceSaas.Pedidos;

				foreach (var pedido in pedidos)
				{
					var asignacion = pedidosSaas.FirstOrDefault(a => a.Pedido == pedido.IdPedido.ToString());
					RutasEntrega ruta = new RutasEntrega
					{
						NombreRuta = "Bogota",
						IdEstadoRutaEntrega = 1,
						Guia = asignacion.Remesa
					};

					rutas.Add(ruta);

				}

				await _unitOfWorkGestionPedidos.GestionPedidosRepository.AddRutaEntregaAsync(rutas);

				foreach (var pedido in pedidos)
				{
					var asignacion = pedidosSaas.FirstOrDefault(a => a.Pedido == pedido.IdPedido.ToString());
					var ruta = rutas.FirstOrDefault(a => a.Guia == asignacion.Remesa);

					if (null == asignacion)
					{
						//TODO armar una lista de respuestas
						return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(false, asignacion, UserTypeMessages.OKERRGEN01);
					}

					pedido.RutaAsignadaId = ruta.IdRutaEntrega;
					pedido.IdEstadoPedido = (int)EstadosProceso.EnProceso;


				}



				await _unitOfWorkGestionPedidos.GestionPedidosRepository.ActualizarPedido(pedidos);


			}
			else
			{

				return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(false, new DtoJsonResponseSaas { Estado = false, Mensaje = $"{UserTypeMessages.ERROR_API_EXTERNA} | ERROR: {UserTypeMessages.NO_DATOS_GUIA} {responseServicioSaas.Mensaje}", Value = responseServicioSaas.Value, }, UserTypeMessages.OKERRGEN01);
			}


			return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(true, pedidos.Select(p => p.IdPedido).ToList(), UserTypeMessages.OKGEN01); ;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idPedido"></param>
		/// <returns></returns>
		/// <exception cref="BusinessException"></exception>
		public async Task<DtoGenericResponse<DtoJsonResponseSaas>> AsignarRutaSaasYActualizarPedidoAsync(int? idPedido)
		{
			List<Pedido> pedidos = new();
			Pedido? pedido = await _unitOfWorkGestionPedidos.GestionPedidosRepository.GetPedidoByIdAsync((int)idPedido!);
			if (null == pedido)
			{
				return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(false, pedido, UserTypeMessages.OKERRGEN01);
			}

			var pedidoDto = new DtoPedido
			{
				IdPedido = pedido.IdPedido,
				DireccionEntrega = pedido.IdDireccionEntrega.ToString() ?? "",
				FechaEntrega = pedido.FechaEntrega
			};

			List<int> idsPedios = [(int)idPedido];

			DtoRequestMilenium jsonRequest = await _armarJsonRequestMilenium.ArmarJson(idsPedios);

			// Llamar al SaaS
			DtoJsonResponseSaas responseServicioSaas = await _transversales.ConsumirServicioSaas(jsonRequest);


			if (responseServicioSaas.Estado && responseServicioSaas.IsOkEsquema)
			{

				var json = JsonConvert.SerializeObject(responseServicioSaas.Value);

				var objeto = JsonConvert.DeserializeObject<DtoResponseServiceMileniumExitosa>(json);


				DtoResponseServiceMileniumExitosa? serviceSaas = JsonConvert.DeserializeObject<DtoResponseServiceMileniumExitosa>(JsonConvert.SerializeObject(responseServicioSaas.Value));


				List<DtoResponsePedidosMilenium> pedidosSaas = serviceSaas.Pedidos;

				var asignacion = pedidosSaas.FirstOrDefault(a => a.Pedido == pedido.IdPedido.ToString());
				if (null == asignacion)
				{
					//TODO armar una lista de respuestas
					return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(false, asignacion, UserTypeMessages.OKERRGEN01);
				}


				pedido.IdEstadoPedido = (int)EstadosProceso.EnProceso;

				List<RutasEntrega> rutas = new();
				RutasEntrega ruta = new RutasEntrega
				{

					Guia = asignacion.Remesa,
					NombreRuta = "Bogota",
					IdEstadoRutaEntrega = 1
				};
				rutas.Add(ruta);

				await _unitOfWorkGestionPedidos.GestionPedidosRepository.AddRutaEntregaAsync(rutas);

				pedido.RutaAsignadaId = ruta.IdRutaEntrega;

				pedidos.Add(pedido);
				await _unitOfWorkGestionPedidos.GestionPedidosRepository.ActualizarPedido(pedidos);



			}
			else
			{

				return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(false, new DtoJsonResponseSaas { Estado = false, Mensaje = $"{UserTypeMessages.ERROR_API_EXTERNA} | ERROR: {UserTypeMessages.NO_DATOS_GUIA} {responseServicioSaas.Mensaje}", Value = responseServicioSaas.Value, }, UserTypeMessages.OKERRGEN01);
			}


			return GenericHelpers.BuildResponse<DtoJsonResponseSaas>(true, pedido, UserTypeMessages.OKGEN01);
		}
	}
}
