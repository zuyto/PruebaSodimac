// <copyright file="LogsAplicacion.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class LogsAplicacion
{
	public int IdLog { get; set; }

	public string Nivel { get; set; } = null!;

	public string? Mensaje { get; set; }

	public string? StackTrace { get; set; }

	public DateTime? FechaLog { get; set; }

	public string? Origen { get; set; }

	public string? Usuario { get; set; }
}
