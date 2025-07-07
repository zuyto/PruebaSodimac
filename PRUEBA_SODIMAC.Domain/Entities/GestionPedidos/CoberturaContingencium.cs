// <copyright file="CoberturaContingencium.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

namespace PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

public partial class CoberturaContingencium
{
	public int IdCobertura { get; set; }

	public int? IdValorAtributo { get; set; }

	public int? IdZona { get; set; }

	public int? IdCiudad { get; set; }

	public int? IdDepto { get; set; }

	public int? IdRedZona { get; set; }

	public int? IdRed { get; set; }

	public int? IdFlujo { get; set; }

	public string? Sigla { get; set; }

	public int? IdPromesaCliente { get; set; }

	public string? Promesa { get; set; }

	public int? IdCanal { get; set; }

	public int? IdTipoNodoInicial { get; set; }

	public long? CodigoInternoInicial { get; set; }

	public long? NumberInternoInicial { get; set; }

	public int? IdTipoNodoFinal { get; set; }

	public long? CodigoInternoFinal { get; set; }

	public long? NumberInternoFinal { get; set; }
}
