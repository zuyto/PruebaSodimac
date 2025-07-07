// <copyright file="GestionPedidosNetDbContext.cs" company="MAuro Martinez">
// 	Copyright (c).
// 	All Rights Reserved.  Licensed under the Apache License, Version 2.0.
// 	See License.txt in the project root for license information.
// </copyright>

using Microsoft.EntityFrameworkCore;

using PRUEBA_SODIMAC.Domain.Entities.PRUEBA_SODIMAC;

namespace PRUEBA_SODIMAC.Infrastructure.Context;

public partial class GestionPedidosNetDbContext : DbContext
{
	public GestionPedidosNetDbContext()
	{
	}

	public GestionPedidosNetDbContext(DbContextOptions<GestionPedidosNetDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<ApiKey> ApiKeys { get; set; }

	public virtual DbSet<Auditorium> Auditoria { get; set; }

	public virtual DbSet<Cliente> Clientes { get; set; }

	public virtual DbSet<CoberturaContingencium> CoberturaContingencia { get; set; }

	public virtual DbSet<DireccionesEntrega> DireccionesEntregas { get; set; }

	public virtual DbSet<EstadosPedido> EstadosPedidos { get; set; }

	public virtual DbSet<EstadosRutaEntrega> EstadosRutaEntregas { get; set; }

	public virtual DbSet<HistorialEstadosPedido> HistorialEstadosPedidos { get; set; }

	public virtual DbSet<HistorialEstadosRutaEntrega> HistorialEstadosRutaEntregas { get; set; }

	public virtual DbSet<LogsAplicacion> LogsAplicacions { get; set; }

	public virtual DbSet<ParametrosContingencium> ParametrosContingencia { get; set; }

	public virtual DbSet<Pedido> Pedidos { get; set; }

	public virtual DbSet<Permiso> Permisos { get; set; }

	public virtual DbSet<Producto> Productos { get; set; }

	public virtual DbSet<ProductosContingencium> ProductosContingencia { get; set; }

	public virtual DbSet<ProductosPedido> ProductosPedidos { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<RutasEntrega> RutasEntregas { get; set; }

	public virtual DbSet<Sesione> Sesiones { get; set; }

	public virtual DbSet<Usuario> Usuarios { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ApiKey>(entity =>
		{
			entity.HasKey(e => e.IdApiKey).HasName("PK__ApiKeys__5B5DC0F05EDFE775");

			entity.HasIndex(e => e.ApiKey1, "UQ__ApiKeys__A4E6E186312EA2AB").IsUnique();

			entity.Property(e => e.Activo)
				.HasMaxLength(1)
				.IsUnicode(false)
				.HasDefaultValue("S")
				.IsFixedLength();
			entity.Property(e => e.ApiKey1)
				.HasMaxLength(255)
				.HasColumnName("ApiKey");
			entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
			entity.Property(e => e.NombreAplicacion).HasMaxLength(100);
		});

		modelBuilder.Entity<Auditorium>(entity =>
		{
			entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0889B9F6A");

			entity.Property(e => e.FechaOperacion).HasDefaultValueSql("(sysdatetime())");
			entity.Property(e => e.Operacion).HasMaxLength(20);
			entity.Property(e => e.TablaAfectada).HasMaxLength(100);
			entity.Property(e => e.Usuario).HasMaxLength(100);
		});

		modelBuilder.Entity<Cliente>(entity =>
		{
			entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D59466422AEBC9BE");

			entity.HasIndex(e => e.CorreoElectronico, "UQ__Clientes__531402F3B064A982").IsUnique();

			entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
			entity.Property(e => e.Direccion).HasMaxLength(255);
			entity.Property(e => e.Nombres).HasMaxLength(100);
		});

		modelBuilder.Entity<CoberturaContingencium>(entity =>
		{
			entity.HasKey(e => e.IdCobertura).HasName("PK__Cobertur__1D5BFBDCFC887643");

			entity.HasIndex(e => e.IdCiudad, "IDX_Cobertura_IdCiudad");

			entity.HasIndex(e => e.IdDepto, "IDX_Cobertura_IdDepto");

			entity.HasIndex(e => e.IdPromesaCliente, "IDX_Cobertura_IdPromesaCliente");

			entity.HasIndex(e => e.IdValorAtributo, "IDX_Cobertura_IdValorAtributo");

			entity.HasIndex(e => e.IdZona, "IDX_Cobertura_IdZona");

			entity.Property(e => e.Promesa).HasMaxLength(100);
			entity.Property(e => e.Sigla).HasMaxLength(50);
		});

		modelBuilder.Entity<DireccionesEntrega>(entity =>
		{
			entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C7615E043E4");

			entity.ToTable("DireccionesEntrega");

			entity.Property(e => e.Ciudad).HasMaxLength(100);
			entity.Property(e => e.Departamento).HasMaxLength(100);
			entity.Property(e => e.Direccion).HasMaxLength(255);
			entity.Property(e => e.Pais).HasMaxLength(100);

			entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DireccionesEntregas)
				.HasForeignKey(d => d.IdCliente)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Direccion__IdCli__3A81B327");
		});

		modelBuilder.Entity<EstadosPedido>(entity =>
		{
			entity.HasKey(e => e.IdEstadoPedido).HasName("PK__EstadosP__86B983719681B7A8");

			entity.ToTable("EstadosPedido");

			entity.HasIndex(e => e.NombreEstado, "UQ__EstadosP__6CE5061517DDCDCF").IsUnique();

			entity.Property(e => e.NombreEstado).HasMaxLength(50);
		});

		modelBuilder.Entity<EstadosRutaEntrega>(entity =>
		{
			entity.HasKey(e => e.IdEstadoRutaEntrega).HasName("PK__EstadosR__48D9B147CAD2A282");

			entity.ToTable("EstadosRutaEntrega");

			entity.HasIndex(e => e.NombreEstado, "UQ__EstadosR__6CE506155DC59D42").IsUnique();

			entity.Property(e => e.NombreEstado).HasMaxLength(50);
		});

		modelBuilder.Entity<HistorialEstadosPedido>(entity =>
		{
			entity.HasKey(e => e.IdHistorialPedido).HasName("PK__Historia__A760BE9641960585");

			entity.ToTable("HistorialEstadosPedido");

			entity.HasIndex(e => e.FechaCambioEstado, "IDX_HistorialEstadosPedido_Fecha");

			entity.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.HistorialEstadosPedidos)
				.HasForeignKey(d => d.IdEstadoPedido)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Historial__IdEst__52593CB8");

			entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.HistorialEstadosPedidos)
				.HasForeignKey(d => d.IdPedido)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Historial__IdPed__5165187F");
		});

		modelBuilder.Entity<HistorialEstadosRutaEntrega>(entity =>
		{
			entity.HasKey(e => e.IdHistorialRuta).HasName("PK__Historia__0954C1A6EA2A151C");

			entity.ToTable("HistorialEstadosRutaEntrega");

			entity.HasOne(d => d.IdEstadoRutaEntregaNavigation).WithMany(p => p.HistorialEstadosRutaEntregas)
				.HasForeignKey(d => d.IdEstadoRutaEntrega)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Historial__IdEst__5629CD9C");

			entity.HasOne(d => d.IdRutaEntregaNavigation).WithMany(p => p.HistorialEstadosRutaEntregas)
				.HasForeignKey(d => d.IdRutaEntrega)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Historial__IdRut__5535A963");
		});

		modelBuilder.Entity<LogsAplicacion>(entity =>
		{
			entity.HasKey(e => e.IdLog).HasName("PK__LogsApli__0C54DBC6CD5A73B3");

			entity.ToTable("LogsAplicacion");

			entity.HasIndex(e => e.FechaLog, "IDX_LogsAplicacion_Fecha");

			entity.Property(e => e.FechaLog).HasDefaultValueSql("(sysdatetime())");
			entity.Property(e => e.Mensaje).HasMaxLength(4000);
			entity.Property(e => e.Nivel).HasMaxLength(20);
			entity.Property(e => e.Origen).HasMaxLength(100);
			entity.Property(e => e.Usuario).HasMaxLength(100);
		});

		modelBuilder.Entity<ParametrosContingencium>(entity =>
		{
			entity.HasKey(e => e.IdParametro).HasName("PK__Parametr__37B016F414D38F4B");

			entity.Property(e => e.IdParametro).ValueGeneratedNever();
			entity.Property(e => e.Nombre).HasMaxLength(100);
			entity.Property(e => e.Valor).HasMaxLength(500);
		});

		modelBuilder.Entity<Pedido>(entity =>
		{
			entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos__9D335DC36EE70A70");

			entity.ToTable(tb => tb.HasTrigger("TRG_AUDIT_PEDIDOS"));

			entity.HasIndex(e => e.IdCliente, "IDX_Pedidos_IdCliente");

			entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
				.HasForeignKey(d => d.IdCliente)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Pedidos__IdClien__47DBAE45");

			entity.HasOne(d => d.IdDireccionEntregaNavigation).WithMany(p => p.Pedidos)
				.HasForeignKey(d => d.IdDireccionEntrega)
				.HasConstraintName("FK__Pedidos__IdDirec__4AB81AF0");

			entity.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.Pedidos)
				.HasForeignKey(d => d.IdEstadoPedido)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Pedidos__IdEstad__48CFD27E");

			entity.HasOne(d => d.RutaAsignada).WithMany(p => p.Pedidos)
				.HasForeignKey(d => d.RutaAsignadaId)
				.HasConstraintName("FK__Pedidos__RutaAsi__49C3F6B7");
		});

		modelBuilder.Entity<Permiso>(entity =>
		{
			entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__0D626EC87200A90A");

			entity.HasIndex(e => e.NombrePermiso, "UQ__Permisos__BA19B18D0FFD2A68").IsUnique();

			entity.Property(e => e.Descripcion).HasMaxLength(255);
			entity.Property(e => e.NombrePermiso).HasMaxLength(100);
		});

		modelBuilder.Entity<Producto>(entity =>
		{
			entity.HasKey(e => e.IdProducto).HasName("PK__Producto__0988921096606CA9");

			entity.Property(e => e.Descripcion).HasMaxLength(255);
			entity.Property(e => e.Nombre).HasMaxLength(100);
		});

		modelBuilder.Entity<ProductosContingencium>(entity =>
		{
			entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892109B8416C0");

			entity.HasIndex(e => e.IdValorAtributo, "IDX_Productos_IdValorAtributo");

			entity.HasIndex(e => e.PrdLvlNumber, "IDX_Productos_PrdLvlNumber");

			entity.Property(e => e.OrigenNumber).HasMaxLength(50);
			entity.Property(e => e.PrdLvlChild).HasMaxLength(50);
			entity.Property(e => e.PrdLvlNumber).HasMaxLength(50);
		});

		modelBuilder.Entity<ProductosPedido>(entity =>
		{
			entity.HasKey(e => new { e.IdPedido, e.IdProducto }).HasName("PK__Producto__8DABD4E240F06699");

			entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ProductosPedidos)
				.HasForeignKey(d => d.IdPedido)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Productos__IdPed__4D94879B");

			entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductosPedidos)
				.HasForeignKey(d => d.IdProducto)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Productos__IdPro__4E88ABD4");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584CB3562F7B");

			entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537F82A6C6E6").IsUnique();

			entity.Property(e => e.Descripcion).HasMaxLength(255);
			entity.Property(e => e.NombreRol).HasMaxLength(50);

			entity.HasMany(d => d.IdPermisos).WithMany(p => p.IdRols)
				.UsingEntity<Dictionary<string, object>>(
					"RolesPermiso",
					r => r.HasOne<Permiso>().WithMany()
						.HasForeignKey("IdPermiso")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__RolesPerm__IdPer__693CA210"),
					l => l.HasOne<Role>().WithMany()
						.HasForeignKey("IdRol")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__RolesPerm__IdRol__68487DD7"),
					j =>
					{
						j.HasKey("IdRol", "IdPermiso").HasName("PK__RolesPer__BA9F7EA0B3B569D0");
						j.ToTable("RolesPermisos");
					});
		});

		modelBuilder.Entity<RutasEntrega>(entity =>
		{
			entity.HasKey(e => e.IdRutaEntrega).HasName("PK__RutasEnt__EE1DE377DAC3F41C");

			entity.ToTable("RutasEntrega");

			entity.Property(e => e.NombreRuta).HasMaxLength(100);

			entity.HasOne(d => d.IdEstadoRutaEntregaNavigation).WithMany(p => p.RutasEntregas)
				.HasForeignKey(d => d.IdEstadoRutaEntrega)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__RutasEntr__IdEst__44FF419A");
		});

		modelBuilder.Entity<Sesione>(entity =>
		{
			entity.HasKey(e => e.IdSesion).HasName("PK__Sesiones__22EC535B50CD4F72");

			entity.Property(e => e.Activo)
				.HasMaxLength(1)
				.IsUnicode(false)
				.HasDefaultValue("S")
				.IsFixedLength();
			entity.Property(e => e.FechaInicio).HasDefaultValueSql("(sysdatetime())");
			entity.Property(e => e.Token).HasMaxLength(255);

			entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Sesiones)
				.HasForeignKey(d => d.IdUsuario)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK__Sesiones__IdUsua__72C60C4A");
		});

		modelBuilder.Entity<Usuario>(entity =>
		{
			entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF9794140842");

			entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F38C62A6F9").IsUnique();

			entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE0D33D6E97").IsUnique();

			entity.Property(e => e.Activo)
				.HasMaxLength(1)
				.IsUnicode(false)
				.HasDefaultValue("S")
				.IsFixedLength();
			entity.Property(e => e.ContrasenaHash).HasMaxLength(255);
			entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
			entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysdatetime())");
			entity.Property(e => e.NombreCompleto).HasMaxLength(100);
			entity.Property(e => e.NombreUsuario).HasMaxLength(50);

			entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
				.UsingEntity<Dictionary<string, object>>(
					"UsuariosRole",
					r => r.HasOne<Role>().WithMany()
						.HasForeignKey("IdRol")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__UsuariosR__IdRol__656C112C"),
					l => l.HasOne<Usuario>().WithMany()
						.HasForeignKey("IdUsuario")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK__UsuariosR__IdUsu__6477ECF3"),
					j =>
					{
						j.HasKey("IdUsuario", "IdRol").HasName("PK__Usuarios__89C12A134AB789B5");
						j.ToTable("UsuariosRoles");
					});
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
