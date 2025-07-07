// <copyright file="EstadosRutaEntrega.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class EstadosRutaEntrega
{
	public int IdEstadoRutaEntrega { get; set; }

	public string NombreEstado { get; set; } = null!;

	public virtual ICollection<HistorialEstadosRutaEntrega> HistorialEstadosRutaEntregas { get; set; } = new List<HistorialEstadosRutaEntrega>();

	public virtual ICollection<RutasEntrega> RutasEntregas { get; set; } = new List<RutasEntrega>();
}
