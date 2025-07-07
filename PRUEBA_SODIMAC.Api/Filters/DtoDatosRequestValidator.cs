// <copyright file="DtoDatosRequestValidator.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

using FluentValidation;

using PRUEBA_SODIMAC.Application.Common.Models.DTOs;

namespace PRUEBA_SODIMAC.Api.Filters
{
	/// <summary>
	/// 
	/// </summary>
	///
	[ExcludeFromCodeCoverage]
	public class DtoDatosRequestValidator : AbstractValidator<DtoDatosRequest>
	{
		/// <summary>
		/// 
		/// </summary>
		public DtoDatosRequestValidator()
		{
			RuleFor(x => x.IdZona)
		   .NotEmpty().WithMessage("IdZona no puede estar vacío.")
		   .NotNull().WithMessage("IdZona no puede estar null.")
		   .GreaterThan(0).WithMessage("IdZona debe ser mayor que 0.");

			RuleFor(x => x.IdCiudad)
				.NotEmpty().WithMessage("IdCiudad no puede estar vacío.")
				.NotNull().WithMessage("IdCiudad no puede estar null.")
				.GreaterThan(0).WithMessage("IdCanal debe ser mayor que 0.");

			RuleFor(x => x.IdDepartamento)
				.NotEmpty().WithMessage("IdDepartamento no puede estar vacío.")
				.NotNull().WithMessage("IdDepartamento no puede estar null.")
				.GreaterThan(0).WithMessage("IdDepartamento debe ser mayor que 0.");

			RuleFor(x => x.IdCanal)
				.GreaterThan(0).WithMessage("IdCanal debe ser mayor que 0.")
				.NotNull().WithMessage("IdCanal no puede estar null.");

			RuleFor(x => x.OrgLvlChild)
				.GreaterThan(0).WithMessage("OrgLvlChild debe ser mayor que 0.")
				.NotNull().WithMessage("OrgLvlChild no puede estar null.")
				.GreaterThan(0).WithMessage("OrgLvlChild debe ser mayor que 0.");

		}
	}
}
