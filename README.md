
# ⚙️ API Gestión de Pedidos y Cobertura - Sodimac

Proyecto .NET 8 que expone APIs RESTful para la gestión de pedidos, consulta de cobertura y simulación de integración con SaaS.

---

## 🚀 Tecnologías

- ASP.NET Core 8
- Clean Architecture (Domain, Application, Infrastructure, Presentation)
- Entity Framework Core Database First
- SQL Server / Oracle / Azure SQL Database
- Integración SaaS (mock)
- Serilog para logs
- JWT Authentication (pendiente implementación)
- Swagger (OpenAPI)

---

## 📦 Módulos

### Pedidos
- `RegistrarPedidos` ➡️ registra múltiples pedidos y consulta SaaS
- `GetPedidosPorCliente` ➡️ consulta pedidos por cliente
- `CambiarEstadoPedido` ➡️ cambia el estado de un pedido
- `AsignarRutaDesdeSaas` ➡️ simula asignación de rutas SaaS

### Cobertura
- `ObtenerCoberturaPorZona`
- `ObtenerCoberturaPorCiudad`
- `ObtenerCoberturaPorDepartamento`

---

## 🛢️ Base de datos

- Scripts SQL Server / Oracle / Azure SQL
- Triggers de auditoría
- Relaciones normalizadas hasta 3FN
- Índices y particiones
- EF Core Database First (con `Scaffold-DbContext`)

---

## 🔧 Configuración local

```bash
cd src/PRUEBA_SODIMAC.Api

# Generar entidades desde la base de datos
dotnet ef dbcontext scaffold "cadena_conexion" Microsoft.EntityFrameworkCore.SqlServer -o Infrastructure/Entities -f

# Ejecutar API
dotnet run
```

Swagger: [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔑 Pendientes
- Seguridad JWT
- CRUD usuarios / roles / permisos
- Auditoría expuesta vía API
- Dockerfile y docker-compose
