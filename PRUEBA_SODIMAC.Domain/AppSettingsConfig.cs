// <copyright file="AppSettingsConfig.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using ConnectionManager;

namespace PRUEBA_SODIMAC.Domain
{
	[ExcludeFromCodeCoverage]
	public class AppSettingsConfig : AppSettingsConnectionManager
	{
		public double TiempoEsperaApiExterna { get; set; }
		public string? ChannelSglBroker { get; set; }
		public string? TerminalIdSglBroker { get; set; }
		public string? ServiceSglBroker { get; set; }
		public string? ApiKey { get; set; }
		public string? SAAS { get; set; }
		public string? Token { get; set; }
	}
}
