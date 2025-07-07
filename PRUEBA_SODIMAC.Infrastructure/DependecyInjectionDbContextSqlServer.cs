// <copyright file="DependecyInjectionDbContextSqlServer.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>


using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Oracle.EntityFrameworkCore.Diagnostics;

using PRUEBA_SODIMAC.Application.Common.Struct;
using PRUEBA_SODIMAC.Infrastructure.Context;

namespace PRUEBA_SODIMAC.Infrastructure
{
	/// <summary>
	/// Clase encargada de realziar a consiguracion de los DbContext
	/// </summary>
	///
	[ExcludeFromCodeCoverage]
	public static class DependecyInjectionDbContextSqlServer
	{
		/// <summary>
		/// Metodo extension de WebApplicationBuilder (Program)
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static WebApplicationBuilder AddDbContextSqlServer(this WebApplicationBuilder builder)
		{

			AddDynamicContext(builder);
			AddGestionPedidosNetDbContext(builder);

			return builder!;
		}


		#region[DB DYMAMIC]
		private static void AddDynamicContext(WebApplicationBuilder builder)
		{
			builder?.Services.AddDbContext<DynamicContext>(options =>
			{
				ConfigureDbContextOptions(builder, options, ConfigurationStruct.PROD_SGL);
			}, ServiceLifetime.Scoped);
		}
		#endregion


		#region[DB GESTION PEDIDOS]
		private static void AddGestionPedidosNetDbContext(WebApplicationBuilder builder)
		{
			builder?.Services.AddDbContext<GestionPedidosNetDbContext>(options =>
			{
				ConfigureDbContextOptions(builder, options, ConfigurationStruct.GESTION_PEDIDOS_NET);
			}, ServiceLifetime.Scoped);
		}
		#endregion

		/// <summary>
		/// Metodo encargado de realizar la configuracion de los DbContext
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="options"></param>
		/// <param name="connectionStringName"></param>
		private static void ConfigureDbContextOptions(WebApplicationBuilder builder, DbContextOptionsBuilder options, string connectionStringName)
		{

			options.UseSqlServer(Environment.GetEnvironmentVariable(connectionStringName))
				.ConfigureWarnings(b => b.Ignore(OracleEventId.DecimalTypeKeyWarning));

			if (builder!.Environment.IsDevelopment()!)
			{
				// Configurar el nivel de registro
				options.EnableSensitiveDataLogging(); // Esto habilita la información sensible como parámetros de SQL
				options.LogTo(Console.WriteLine, [DbLoggerCategory.Database.Command.Name]); // Esto redirige los mensajes de registro a la consola
			}
		}
	}
}
