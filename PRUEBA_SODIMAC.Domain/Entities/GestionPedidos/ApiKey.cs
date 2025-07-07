// <copyright file="ApiKey.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class ApiKey
{
	public int IdApiKey { get; set; }

	public string NombreAplicacion { get; set; } = null!;

	public string ApiKey1 { get; set; } = null!;

	public string? Activo { get; set; }

	public DateTime? FechaCreacion { get; set; }

	public DateTime? FechaExpiracion { get; set; }
}
