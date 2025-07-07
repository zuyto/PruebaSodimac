// <copyright file="DynamicRepository.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository;
using PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog;
using PRUEBA_SODIMAC.Application.Common.Static;
using PRUEBA_SODIMAC.Application.Common.Struct;
using PRUEBA_SODIMAC.Infrastructure.Context;
using PRUEBA_SODIMAC.Infrastructure.Extensions;

namespace PRUEBA_SODIMAC.Infrastructure.Repositories
{
	[ExcludeFromCodeCoverage]
	internal class DynamicRepository : IDynamicRepository
	{
		private readonly DynamicContext context;
		private readonly ISerilogImplements _serilogImplements;

		public DynamicRepository(DynamicContext context, ISerilogImplements serilogImplements)
		{
			this.context = context;
			_serilogImplements = serilogImplements;
		}


		public async Task<List<object>> ExecuteSentenciaOnDatabase(string sentence,
			string secreto)
		{
			_serilogImplements.ObtainMessageDefault(ConfigurationMessageType.Information,
				MetodosMessage.pingSecretConexion, sentence, null);
			var results = context.DynamicListFromSql(sentence,
				secreto.Decrypt(), new Dictionary<string, object>()).ToList();
			return await Task.FromResult(results);
		}

		public async Task<bool> TestConnectionDynamic(string secreto)
		{
			var results = context.TestConnectionDynamic(secreto.Decrypt());
			return await Task.FromResult(results);
		}
	}
}
