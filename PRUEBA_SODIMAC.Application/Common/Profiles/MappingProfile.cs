// <copyright file="MappingProfile.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using AutoMapper;

namespace PRUEBA_SODIMAC.Application.Common.Profiles
{
	[ExcludeFromCodeCoverage]
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			////CreateMap<TblOmsProductosContingencium, DtoProductoConCobertura>();
			////CreateMap<DtoProductosRequestCont, DtoProductoCont>();
			////CreateMap<TblSglMandatoIncidenciaCmDet, MandatoIncidenciaCmDet>();
		}

		protected internal MappingProfile(string profileName) : base(profileName)
		{
		}

		protected internal MappingProfile(string profileName,
			Action<IProfileExpression> configurationAction) : base(profileName,
			configurationAction)
		{
		}
	}
}
