// <copyright file="DtoRequestMilenium.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace PRUEBA_SODIMAC.Application.Common.Models.DTOs.Sodimac
{
	[ExcludeFromCodeCoverage]
	public class DtoRequestMilenium
	{
		public string User { get; set; }
		public string Key { get; set; }
		public string Proceso { get; set; }
		public List<DtoRequestRemesasMilenium> Remesas { get; set; }

	}
}
