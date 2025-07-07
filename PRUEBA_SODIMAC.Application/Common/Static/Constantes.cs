// <copyright file="Constantes.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using PRUEBA_SODIMAC.Application.Common.Helpers;

namespace PRUEBA_SODIMAC.Application.Common.Static
{
	[ExcludeFromCodeCoverage]

	public static class Constantes
	{

		public const string Proceso_Exitoso = "Proceso exitoso";

		public const string SEQ_TBL_OMS_CAMBIO_ESTADO_NP_AUD = "SEQ_TBL_OMS_CAMBIO_ESTADO_NP_AUD";

		public const string ConsultaObtenerSecuencia = "select (SGL.PKG_APLICACION.FNC_GET_SEQ_BY_NAME('{0}')) as Id from dual";

		public const string DEPRISA = "DEPRISA";

		public const string USUARIO_API = "UNIGIS_NET_MOD_ITEM_PARADA";

		public const string ESTADO_FINALIZADO = "ESTADO_FINALIZADO";
		public const string CED_REMITENTE_PROVEEDOR = "800242106";
		public const string ENTREGA = "ENTREGA";
		public const string TELEFONO_DESTINATARIO = "3204774085";
		public const string FLUJO_RPTDA = "RP-TDA";
		public const string HOMECENTER = "HOMECENTER ";
		public const string COMPRA = "COMPRA N";

		public const string ORDEN_COMPRA = "OC";
		public const string NOMBREREMITENTE = " COLOMBIA";

		public const string PAIS = "057";
		public const string NIT = "NIT";
		public const string EMAIL_REMITENTE = "sc@homecenter.co";
		public const string CLIENTE_DESTINATARIO = "99999999";
		public const string CENTRO_DESTINATARIO = "99";
		public const string NA = "NA";

		public const string CODIGO_SERVICIO = "3005";
		public const string TIPO_PORTES = "P";
		public const string ASEGURAR_ENVIO = "S";
		public const string MONEDA = "COP";

		public const string CIUDAD_DC = "BOGOTA. D.C.";
		public const string CIUDAD = "BOGOTA";

		public const string OBTENER_GUIA = "OBTENER_GUIA";

		public const string TERMICA = "T";

		public const string LYT = "LYT";
		public const string LIFTIT = "LIFTIT";

		public const string? SALIDA_OMS_CRGVTA = "SALIDA_OMS_CRGVTA";
		public const string? ENTRADA_DISPO_CRGVTA = "ENTRADA_DISPO_CRGVTA";

		public const int OPCION_MENU = 0;
		public const string USUARIO_LOGIN = "OMS";



		public const string SALOMSCRGV = "SALOMSCRGV";
		public const string ENTDISCRGV = "ENTDISCRGV";

		public const string FNC_COSTO_GENERAL = "FNC_COSTO_GENERAL";
		public const string SQL_PRC_FNC_COSTO_GENERAL = $"SELECT {ProceduresMappingConstants.PKG_COSTOS_FNC_COSTO}('{FNC_COSTO_GENERAL}', @parametro1 || ',' || @parametro2, 2) as COSTO from dual;";

		public const string CARGA_TRX_MASIVO = "CARGA_TRX_MASIVO";
		public const string TRACKING_INVENTARIO = "TRACKING_INVENTARIO";

		public const string BROKER_TRACE_ESTADO = "BROKER_TRACE_ESTADO";

		public const string CONSULTAR_SECUENCIA_MODELO_ = "SELECT PKG_APLICACION.FNC_GET_SEQ_BY_NAME('#NombreSecuencia') FROM DUAL";


		public const string? OK = "OK";
		public const string? PROCESADO = "Procesado";
		public const string? ERROR = "ERROR";
	}
}
