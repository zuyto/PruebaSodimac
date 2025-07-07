// <copyright file="OracleMappingConstants.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace PRUEBA_SODIMAC.Application.Common.Helpers
{
	[ExcludeFromCodeCoverage]

	public static class OracleMappingConstants
	{
		public const string P_SALIDA = "P_SALIDA";
		public const string P_RESULTADO = "P_RESULTADO";

		public const string P_TIPO_INTEGRACION = "P_TIPO_INTEGRACION";
		public const string P_ID_RESULTADO = "P_ID_RESULTADO";
		public const string P_ID_REGISTRO = "P_ID_REGISTRO";
		public const string P_VALOR = "P_VALOR";
		public const string P_TIENDA = "P_TIENDA";
		public const string P_NUM_ZONA = "P_NUM_ZONA";
		public const string P_MSJ_RESULTADO = "P_MSJ_RESULTADO";
		public const string P_MENSAJE_RPTA = "P_MENSAJE_RPTA";
		public const string P_ARCHIVO = "P_ARCHIVO";
		public const string P_TOTAL = "P_TOTAL";


		public const string P_STICKER = "P_STICKER";
		public const string P_USUARIO = "P_USUARIO";

		public const string Tag = ":P_TAG";
		public const string PROD = "DEFAULT";


		#region [Paquetes]
		/// <summary>string static con el nombre del PKG a consumir en DB</summary>
		public const string PKG_UNIGIS_TRACKING = "PKG_UNIGIS_TRACKING";
		#endregion

		#region [Procedimientos Almacenados]
		/// <summary>string static con el nombre completo del PRC a consultar en DB</summary>
		public const string PRC_OBTIENE_TRACE_ESTADO = PKG_UNIGIS_TRACKING + "." + "PRC_OBTIENE_TRACE_ESTADO";
		public const string PRC_ENVIO_TRACE_ESTADO = PKG_UNIGIS_TRACKING + "." + "PRC_ENVIO_TRACE_ESTADO";
		public const string PRC_RPTA_TRACE_ESTADO = PKG_UNIGIS_TRACKING + "." + "PRC_RPTA_TRACE_ESTADO";
		#endregion

		#region [Secuencias]
		public const string SEQ_SLT_TRACE_ESTADO = "SEQ_SLT_TRACE_ESTADO";
		public const string SEQ_SGL_INTEGRACION = "SEQ_SGL_INTEGRACION";
		#endregion

	}
}
