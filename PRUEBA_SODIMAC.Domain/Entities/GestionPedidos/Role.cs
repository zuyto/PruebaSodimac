// <copyright file="Role.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Role
{
	public int IdRol { get; set; }

	public string NombreRol { get; set; } = null!;

	public string? Descripcion { get; set; }

	public virtual ICollection<Permiso> IdPermisos { get; set; } = new List<Permiso>();

	public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
