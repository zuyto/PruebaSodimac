// <copyright file="SodimacLoggerOptions.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Logger.Static;

namespace PRUEBA_SODIMAC.Logger.Models
{
	public class LoggerOptions
	{
		public string Meta { get; set; } = ConfigTypeMessage.META;

		/// <summary>
		///     autor ejemplo: GSPL-DP
		/// </summary>
		public string Autor { get; set; } = string.Empty;

		/// <summary>
		///     Area, ejemplo: Digitalizacion de proveedores
		/// </summary>
		public string Area { get; set; } = string.Empty;

		/// <summary>
		///     Aplicación, ejemplo:HubProveedores
		/// </summary>
		public string Aplicacion { get; set; } = string.Empty;

		/// <summary>
		///     Proceso, ejemplo: Gestion Ordenes
		/// </summary>
		public string Proceso { get; set; } = string.Empty;

		/// <summary>
		///     servicio, ejemplo: APIOC
		/// </summary>
		public string Servicio { get; set; } = string.Empty;

		/// <summary>
		///     Endpoint, ejemplo: openshift/APIOC
		/// </summary>
		public string Endpoint { get; set; } = string.Empty;
	}
}
