// <copyright file="ArmarJsonRequestGlobal.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Application.Services
{
	[ExcludeFromCodeCoverage]
	public class ArmarJsonRequestMilenium : IArmarJsonRequestMilenium
	{
		private readonly ISerilogImplements _serilogImplements;
		private readonly IUnitOfWorkGestionPedidos _unitOfWorkGestion;

		public ArmarJsonRequestMilenium(ISerilogImplements serilogImplements, IUnitOfWorkGestionPedidos unitOfWorkGestion)
		{
			_serilogImplements = serilogImplements;
			_unitOfWorkGestion = unitOfWorkGestion;
		}

		public async Task<DtoRequestMilenium> ArmarJson(List<int> idsPedios)
		{

			List<Pedido> pedidos = await _unitOfWorkGestion.GestionPedidosRepository.GetPedidosPorIdsPedidosAsync(idsPedios);



			var remesas = pedidos.Select(p =>
			{
				var invoiceLines = p.ProductosPedidos.Select(pp => new DtoRequestInvoiceLine
				{
					Codigo = pp.IdProductoNavigation.IdProducto.ToString(),
					Nombre = pp.IdProductoNavigation.Nombre,
					Cantidad = pp.Cantidad,
					Peso_producto = (decimal)new Random().NextDouble(),
					Largo = (decimal)new Random().NextDouble(),
					Alto = (decimal)new Random().NextDouble(),
					Ancho = (decimal)new Random().NextDouble(),
					Volumen_producto = (decimal)new Random().NextDouble(),
				}).ToList();

				var totalPeso = invoiceLines.Sum(l => (l.Peso_producto ?? 0) * (l.Cantidad ?? 1));
				var totalVolumen = invoiceLines.Sum(l => (l.Volumen_producto ?? 0) * (l.Cantidad ?? 1));
				var totalCantidad = invoiceLines.Sum(l => l.Cantidad ?? 1);
				var totalValorDeclarado = invoiceLines.Sum(l => ((l.Peso_producto ?? 0) + (l.Volumen_producto ?? 0)) * (l.Cantidad ?? 1));
				// ⚠️ Reemplaza el cálculo anterior por Precio si ya tienes el campo Precio en Producto.

				return new DtoRequestRemesasMilenium
				{
					Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
					Id_cliente = "800242106",
					Nombre_remitente = "SODIMAC",
					Direccion_remitente = "Cra 1 # 1 - 1",
					Telefono_remitente = "123456789",
					Ciudad_remitente = "Bogotá",

					Nit_destinatario = p?.IdClienteNavigation?.CorreoElectronico ?? "HOMECENTER",
					Nombre_destinatario = p?.IdClienteNavigation?.Nombres ?? "SODIMAC",
					Direccion_destinatario = p?.IdDireccionEntregaNavigation?.Direccion ?? "Cra 1 # 11 - 1",
					Ciudad_destinatario = p?.IdDireccionEntregaNavigation?.Ciudad ?? "Bogotá",
					Telefono_destinatario = "123456789",

					Valor_declarado = totalValorDeclarado,
					Volumen_producto = totalVolumen,
					Peso_producto = totalPeso,
					Cant_producto = totalCantidad,

					Pedido = p.IdPedido.ToString(),
					Observaciones = "",
					Division = "Hogar",

					Invoice_lines = invoiceLines
				};
			}).ToList();

			return new DtoRequestMilenium
			{
				User = "Sodimac",
				Key = "57oeWJT2X",
				Proceso = "masivo",
				Remesas = remesas
			};



		}
	}
}
