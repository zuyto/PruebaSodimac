// <copyright file="IUnitOfWorkGestionPedidos.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using PRUEBA_SODIMAC.Application.Common.Interfaces.Repository.GestionPedidos;

namespace PRUEBA_SODIMAC.Application.Common.Interfaces.Repository
{
	public interface IUnitOfWorkGestionPedidos
	{
		void SaveChanges();
		Task<int> SaveChangesAsync();

		#region[REPOSITORIES]
		public IGestionPedidosRepository GestionPedidosRepository { get; }
		public ICoberturaRepository CoberturaRepository { get; }
		#endregion
	}
}
