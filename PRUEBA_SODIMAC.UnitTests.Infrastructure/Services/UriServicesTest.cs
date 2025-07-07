// <copyright file="UriServicesTest.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Application.Common.QueryFilter;
using PRUEBA_SODIMAC.Infrastructure.Services;

namespace PRUEBA_SODIMAC.UnitTests.Infrastructure.Services
{
	public class UriServicesTest
	{
		[Theory]
		[InlineData("http://example.com/", "users", "http://example.com/users")]
		[InlineData("http://example.com/api/", "users?page=2",
			"http://example.com/api/users?page=2")]
		// Puedes añadir más casos de prueba aquí
		public void GetUserPaginationUri_ShouldReturnCorrectUri(string baseUri,
			string actionUrl, string expectedUri)
		{
			// Crear instancia de UriServices
			var uriService = new UriServices(baseUri);

			// Simular UserQueryFilter - ajusta según la estructura real de UserQueryFilter
			var filter = new UserQueryFilter();

			// Llamada al método
			var result = uriService.GetUserPaginationUri(filter, actionUrl);

			// Verificación
			Assert.Equal(expectedUri, result.ToString());
		}
	}
}
