// <copyright file="HistorialEstadosRutaEntrega.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class HistorialEstadosRutaEntrega
{
	public int IdHistorialRuta { get; set; }

	public int IdRutaEntrega { get; set; }

	public int IdEstadoRutaEntrega { get; set; }

	public DateTime FechaCambioEstado { get; set; }

	public virtual EstadosRutaEntrega IdEstadoRutaEntregaNavigation { get; set; } = null!;

	public virtual RutasEntrega IdRutaEntregaNavigation { get; set; } = null!;
}
