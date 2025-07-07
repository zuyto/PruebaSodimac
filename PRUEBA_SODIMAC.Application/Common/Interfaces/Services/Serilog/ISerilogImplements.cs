// <copyright file="ISerilogImplements.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Runtime.CompilerServices;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Services.Serilog
{
	public interface ISerilogImplements
	{
		public string? ObtainMessageDefault(string messageType, string? method,
			string? parameters, string? message, [CallerMemberName] string memberName = "",
			[CallerFilePath] string sourceFilePath = "",
			[CallerLineNumber] int sourceLineNumber = 0);
	}
}
