// <copyright file="IUriServices.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Application.Common.QueryFilter;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Services
{
	public interface IUriServices
	{
		Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl);
	}
}
