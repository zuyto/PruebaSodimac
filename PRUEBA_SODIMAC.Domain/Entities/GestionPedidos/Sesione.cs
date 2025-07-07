// <copyright file="Sesione.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Sesione
{
	public int IdSesion { get; set; }

	public int IdUsuario { get; set; }

	public string Token { get; set; } = null!;

	public DateTime? FechaInicio { get; set; }

	public DateTime? FechaExpiracion { get; set; }

	public string? Activo { get; set; }

	public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
