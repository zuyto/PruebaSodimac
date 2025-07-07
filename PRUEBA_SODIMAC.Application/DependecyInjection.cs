// <copyright file="DependecyInjection.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using PRUEBA_SODIMAC.Application.Common.Helpers;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Http;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Application.Common.Profiles;
using PRUEBA_SODIMAC.Application.Services;
using PRUEBA_SODIMAC.Application.Services.Http;
using PRUEBA_SODIMAC.Application.Services.Serilog;
using PRUEBA_SODIMAC.Application.Services.Transversales;

namespace PRUEBA_SODIMAC.Application
{
	[ExcludeFromCodeCoverage]
	public static class DependecyInjection
	{
		public static IServiceCollection AddApplication(
			this IServiceCollection services)
		{
			_ = services.AddFluentValidationAutoValidation()
				.AddFluentValidationClientsideAdapters();

			_ = services.AddAutoMapper(
				Assembly.GetAssembly(typeof(MappingProfile)));

			services.AddTransient<ISerilogImplements, SerilogImplements>();
			services.AddTransient<IGenericServiceAgent, GenericServiceAgent>();
			services.AddTransient<HttpServiceManager>();
			services.AddTransient<IPedidoService, PedidoService>();
			services.AddTransient<ICoberturaService, CoberturaService>();
			services.AddTransient<IArmarJsonRequestMilenium, ArmarJsonRequestMilenium>();
			services.AddTransient<ITransversales, Transversales>();

			return services;
		}
	}
}
