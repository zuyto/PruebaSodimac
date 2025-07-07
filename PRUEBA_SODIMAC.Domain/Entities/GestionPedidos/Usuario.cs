// <copyright file="Usuario.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Usuario
{
	public int IdUsuario { get; set; }

	public string NombreUsuario { get; set; } = null!;

	public string? NombreCompleto { get; set; }

	public string CorreoElectronico { get; set; } = null!;

	public string ContrasenaHash { get; set; } = null!;

	public string? Activo { get; set; }

	public DateTime? FechaCreacion { get; set; }

	public virtual ICollection<Sesione> Sesiones { get; set; } = new List<Sesione>();

	public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
