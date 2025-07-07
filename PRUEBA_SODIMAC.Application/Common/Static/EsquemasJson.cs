// <copyright file="EsquemasJson.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace PRUEBA_SODIMAC.Application.Common.Static
{
	[ExcludeFromCodeCoverage]

	public static class EsquemasJson
	{

		public const string JsonErr = @"
										{
										  ""$schema"": ""http://json-schema.org/draft-07/schema#"",
										  ""type"": ""object"",
										  ""properties"": {
											""status"": { ""type"": ""string"" },
											""Codigo"": { ""type"": ""string"" },
											""Descripcion"": { ""type"": ""string"" }
										  },
										  ""required"": [""status"", ""Codigo"", ""Descripcion""]
										}";


		public const string JsonOK = @"

										{
										  ""$schema"": ""http://json-schema.org/draft-07/schema#"",
										  ""type"": ""object"",
										  ""properties"": {
											""status"": { ""type"": ""string"" },
											""pedidos"": {
											  ""type"": ""array"",
											  ""items"": {
												""type"": ""object"",
												""properties"": {
												  ""pedido"": { ""type"": ""string"" },
												  ""remesa"": { ""type"": ""string"" },
												  ""estado"": { ""type"": ""string"" }
												},
												""required"": [""pedido"", ""remesa"", ""estado""]
											  }
											}
										  },
										  ""required"": [""status"", ""pedidos""]
										}";

	}
}
