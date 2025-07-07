// <copyright file="CoberturaRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using Microsoft.EntityFrameworkCore;

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac;
using PRUEBA_SODIMAC.Infrastructure.Context;

namespace PRUEBA_SODIMAC.Infrastructure.Repositories.GestionPedidos
{
	public class CoberturaRepository(GestionPedidosNetDbContext _gestionPedidosNetDbContext, ISerilogImplements serilogImplements) : ICoberturaRepository
	{
		private readonly GestionPedidosNetDbContext _context = _gestionPedidosNetDbContext;
		private readonly ISerilogImplements _serilogImplements = serilogImplements;

		public async Task<List<DtoJsonResponseCobertura>> RedesPorIdCiudad(List<DtoProductosRequestCont> request, int idCiudad)
		{
			List<string> skus = request.Select(s => s.Sku).ToList();

			const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var resultadoDb = await (from p in _context.ProductosContingencia
									 join c in _context.CoberturaContingencia
									 on p.IdValorAtributo equals c.IdValorAtributo
									 where skus.Contains(p.PrdLvlNumber)
										&& c.IdCiudad == idCiudad
									 group p by new
									 {
										 c.IdZona,
										 c.IdCiudad,
										 c.IdDepto,
										 c.IdRedZona,
										 c.Promesa,
										 c.IdPromesaCliente
									 } into g
									 select new
									 {
										 g.Key.IdZona,
										 g.Key.IdCiudad,
										 g.Key.IdDepto,
										 g.Key.IdRedZona,
										 g.Key.Promesa,
										 g.Key.IdPromesaCliente,
										 Productos = g.Select(p => p.PrdLvlNumber).ToList()
									 }).ToListAsync();

			var random = new Random();

			var resultadoFinal = resultadoDb.Select(g => new DtoJsonResponseCobertura
			{
				IdZona = (int)g.IdZona,
				IdCiudad = (int)g.IdCiudad,
				IdDepto = (int)g.IdDepto,
				IdRedZona = g.IdRedZona,
				Promesa = g.Promesa,
				IdPromesaCliente = (int)g.IdPromesaCliente,
				Productos = g.Productos.Select(prd => new DtoProductoCoberturaDetalle
				{
					PrdLvlNumber = prd,
					CantidadSku = random.Next(1, 1000),
					Sigla = new string(Enumerable.Repeat(caracteres, 3).Select(s => s[random.Next(s.Length)]).ToArray())
				}).ToList()
			}).ToList();

			return resultadoFinal;
		}

		public async Task<List<DtoJsonResponseCobertura>> RedesPorIdDepto(List<DtoProductosRequestCont> request, int idDepto)
		{
			List<string> skus = request.Select(s => s.Sku).ToList();

			const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var resultadoDb = await (from p in _context.ProductosContingencia
									 join c in _context.CoberturaContingencia
									 on p.IdValorAtributo equals c.IdValorAtributo
									 where skus.Contains(p.PrdLvlNumber)
										&& c.IdDepto == idDepto
									 group p by new
									 {
										 c.IdZona,
										 c.IdCiudad,
										 c.IdDepto,
										 c.IdRedZona,
										 c.Promesa,
										 c.IdPromesaCliente
									 } into g
									 select new
									 {
										 g.Key.IdZona,
										 g.Key.IdCiudad,
										 g.Key.IdDepto,
										 g.Key.IdRedZona,
										 g.Key.Promesa,
										 g.Key.IdPromesaCliente,
										 Productos = g.Select(p => p.PrdLvlNumber).ToList()
									 }).ToListAsync();

			var random = new Random();

			var resultadoFinal = resultadoDb.Select(g => new DtoJsonResponseCobertura
			{
				IdZona = (int)g.IdZona,
				IdCiudad = (int)g.IdCiudad,
				IdDepto = (int)g.IdDepto,
				IdRedZona = g.IdRedZona,
				Promesa = g.Promesa,
				IdPromesaCliente = (int)g.IdPromesaCliente,
				Productos = g.Productos.Select(prd => new DtoProductoCoberturaDetalle
				{
					PrdLvlNumber = prd,
					CantidadSku = random.Next(1, 1000),
					Sigla = new string(Enumerable.Repeat(caracteres, 3).Select(s => s[random.Next(s.Length)]).ToArray())
				}).ToList()
			}).ToList();

			return resultadoFinal;
		}

		public async Task<List<DtoJsonResponseCobertura>> RedesPorIdZona(List<DtoProductosRequestCont> request, int idZona)
		{
			List<string> skus = request.Select(s => s.Sku).ToList();

			const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var resultadoDb = await (from p in _context.ProductosContingencia
									 join c in _context.CoberturaContingencia
									 on p.IdValorAtributo equals c.IdValorAtributo
									 where skus.Contains(p.PrdLvlNumber)
										&& c.IdZona == idZona
									 group p by new
									 {
										 c.IdZona,
										 c.IdCiudad,
										 c.IdDepto,
										 c.IdRedZona,
										 c.Promesa,
										 c.IdPromesaCliente
									 } into g
									 select new
									 {
										 g.Key.IdZona,
										 g.Key.IdCiudad,
										 g.Key.IdDepto,
										 g.Key.IdRedZona,
										 g.Key.Promesa,
										 g.Key.IdPromesaCliente,
										 Productos = g.Select(p => p.PrdLvlNumber).ToList()
									 }).ToListAsync();

			var random = new Random();

			var resultadoFinal = resultadoDb.Select(g => new DtoJsonResponseCobertura
			{
				IdZona = (int)g.IdZona,
				IdCiudad = (int)g.IdCiudad,
				IdDepto = (int)g.IdDepto,
				IdRedZona = g.IdRedZona,
				Promesa = g.Promesa,
				IdPromesaCliente = (int)g.IdPromesaCliente,
				Productos = g.Productos.Select(prd => new DtoProductoCoberturaDetalle
				{
					PrdLvlNumber = prd,
					CantidadSku = random.Next(1, 1000),
					Sigla = new string(Enumerable.Repeat(caracteres, 3).Select(s => s[random.Next(s.Length)]).ToArray())
				}).ToList()
			}).ToList();

			return resultadoFinal;
		}
	}
}
