// <copyright file="Permiso.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Permiso
{
	public int IdPermiso { get; set; }

	public string NombrePermiso { get; set; } = null!;

	public string? Descripcion { get; set; }

	public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
