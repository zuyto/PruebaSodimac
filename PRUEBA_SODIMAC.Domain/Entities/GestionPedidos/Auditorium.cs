// <copyright file="Auditorium.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class Auditorium
{
	public int IdAuditoria { get; set; }

	public string TablaAfectada { get; set; } = null!;

	public string Operacion { get; set; } = null!;

	public int RegistroId { get; set; }

	public string? Usuario { get; set; }

	public DateTime? FechaOperacion { get; set; }

	public string? DatosPrevios { get; set; }

	public string? DatosNuevos { get; set; }
}
