// <copyright file="AutoMoqDataAttribute.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace PRUEBA_SODIMAC.UnitTests.Application.Services
{
	public class AutoMoqDataAttribute : AutoDataAttribute
	{
		public AutoMoqDataAttribute()
			: base(() => new Fixture().Customize(new AutoMoqCustomization()))
		{
		}
	}
}
