// <copyright file="DtoBrokerHeader.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.DtoBase
{
	[ExcludeFromCodeCoverage]
	public class DtoBrokerHeader
	{
		public string? channel { get; set; }
		public string? terminalId { get; set; }
		public string? service { get; set; }
	}
}
