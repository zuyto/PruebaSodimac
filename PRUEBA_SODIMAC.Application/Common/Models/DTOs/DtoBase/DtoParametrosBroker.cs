// <copyright file="DtoParametrosBroker.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase
{
	[ExcludeFromCodeCoverage]
	public class DtoParametrosBroker
	{
		public string? idTraceEstado { get; set; }

		public string? apiKey { get; set; }

		public string? idParada { get; set; }

		public string? refDocumento { get; set; }
	}
}
