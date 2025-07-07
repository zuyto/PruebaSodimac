// <copyright file="ProductosContingencium.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class ProductosContingencium
{
	public int IdProducto { get; set; }

	public string? PrdLvlNumber { get; set; }

	public int? IdValorAtributo { get; set; }

	public long? OrgLvlChild { get; set; }

	public int? IdNodo { get; set; }

	public string? OrigenNumber { get; set; }

	public int? IdTipoNodo { get; set; }

	public string? PrdLvlChild { get; set; }
}
