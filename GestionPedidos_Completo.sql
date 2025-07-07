
-- ==============================
-- SCRIPT COMPLETO BASE DE DATOS GESTION PEDIDOS
-- ==============================

CREATE DATABASE GestionPedidos;
GO

USE GestionPedidos;
GO

-------------------------------------------------
-- CORE
-------------------------------------------------

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    CorreoElectronico NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE DireccionesEntrega (
    IdDireccion INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    Ciudad NVARCHAR(100),
    Departamento NVARCHAR(100),
    Pais NVARCHAR(100),
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255)
);

CREATE TABLE EstadosPedido (
    IdEstadoPedido INT IDENTITY(1,1) PRIMARY KEY,
    NombreEstado NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE EstadosRutaEntrega (
    IdEstadoRutaEntrega INT IDENTITY(1,1) PRIMARY KEY,
    NombreEstado NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE RutasEntrega (
    IdRutaEntrega INT IDENTITY(1,1) PRIMARY KEY,
    NombreRuta NVARCHAR(100) NOT NULL,
    IdEstadoRutaEntrega INT NOT NULL,
    FOREIGN KEY (IdEstadoRutaEntrega) REFERENCES EstadosRutaEntrega(IdEstadoRutaEntrega)
);

CREATE TABLE Pedidos (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    FechaEntrega DATETIME2 NOT NULL,
    IdEstadoPedido INT NOT NULL,
    RutaAsignadaId INT,
    IdDireccionEntrega INT,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    FOREIGN KEY (IdEstadoPedido) REFERENCES EstadosPedido(IdEstadoPedido),
    FOREIGN KEY (RutaAsignadaId) REFERENCES RutasEntrega(IdRutaEntrega),
    FOREIGN KEY (IdDireccionEntrega) REFERENCES DireccionesEntrega(IdDireccion)
);

CREATE TABLE ProductosPedidos (
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PRIMARY KEY (IdPedido, IdProducto),
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);

-------------------------------------------------
-- HISTÓRICOS
-------------------------------------------------

CREATE TABLE HistorialEstadosPedido (
    IdHistorialPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdPedido INT NOT NULL,
    IdEstadoPedido INT NOT NULL,
    FechaCambioEstado DATETIME2 NOT NULL,
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    FOREIGN KEY (IdEstadoPedido) REFERENCES EstadosPedido(IdEstadoPedido)
);

CREATE TABLE HistorialEstadosRutaEntrega (
    IdHistorialRuta INT IDENTITY(1,1) PRIMARY KEY,
    IdRutaEntrega INT NOT NULL,
    IdEstadoRutaEntrega INT NOT NULL,
    FechaCambioEstado DATETIME2 NOT NULL,
    FOREIGN KEY (IdRutaEntrega) REFERENCES RutasEntrega(IdRutaEntrega),
    FOREIGN KEY (IdEstadoRutaEntrega) REFERENCES EstadosRutaEntrega(IdEstadoRutaEntrega)
);

-------------------------------------------------
-- SEGURIDAD
-------------------------------------------------

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(100),
    CorreoElectronico NVARCHAR(100) NOT NULL UNIQUE,
    ContrasenaHash NVARCHAR(255) NOT NULL,
    Activo CHAR(1) DEFAULT 'S',
    FechaCreacion DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Permisos (
    IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
    NombrePermiso NVARCHAR(100) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255)
);

CREATE TABLE UsuariosRoles (
    IdUsuario INT NOT NULL,
    IdRol INT NOT NULL,
    PRIMARY KEY (IdUsuario, IdRol),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

CREATE TABLE RolesPermisos (
    IdRol INT NOT NULL,
    IdPermiso INT NOT NULL,
    PRIMARY KEY (IdRol, IdPermiso),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    FOREIGN KEY (IdPermiso) REFERENCES Permisos(IdPermiso)
);

CREATE TABLE ApiKeys (
    IdApiKey INT IDENTITY(1,1) PRIMARY KEY,
    NombreAplicacion NVARCHAR(100) NOT NULL,
    ApiKey NVARCHAR(255) NOT NULL UNIQUE,
    Activo CHAR(1) DEFAULT 'S',
    FechaCreacion DATETIME2 DEFAULT SYSDATETIME(),
    FechaExpiracion DATETIME2
);

CREATE TABLE Sesiones (
    IdSesion INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    Token NVARCHAR(255) NOT NULL,
    FechaInicio DATETIME2 DEFAULT SYSDATETIME(),
    FechaExpiracion DATETIME2,
    Activo CHAR(1) DEFAULT 'S',
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

-------------------------------------------------
-- AUDITORÍA Y LOGS
-------------------------------------------------

CREATE TABLE Auditoria (
    IdAuditoria INT IDENTITY(1,1) PRIMARY KEY,
    TablaAfectada NVARCHAR(100) NOT NULL,
    Operacion NVARCHAR(20) NOT NULL,
    RegistroId INT NOT NULL,
    Usuario NVARCHAR(100),
    FechaOperacion DATETIME2 DEFAULT SYSDATETIME(),
    DatosPrevios NVARCHAR(MAX),
    DatosNuevos NVARCHAR(MAX)
);

CREATE TABLE LogsAplicacion (
    IdLog INT IDENTITY(1,1) PRIMARY KEY,
    Nivel NVARCHAR(20) NOT NULL,
    Mensaje NVARCHAR(4000),
    StackTrace NVARCHAR(MAX),
    FechaLog DATETIME2 DEFAULT SYSDATETIME(),
    Origen NVARCHAR(100),
    Usuario NVARCHAR(100)
);

-- ================================================
-- CONTINGENCIA
-- ================================================

CREATE TABLE ProductosContingencia (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    PrdLvlNumber NVARCHAR(50),
    IdValorAtributo INT,
    OrgLvlChild BIGINT,
    IdNodo INT,
    OrigenNumber NVARCHAR(50),
    IdTipoNodo INT,
    PrdLvlChild NVARCHAR(50)
);

CREATE TABLE CoberturaContingencia (
    IdCobertura INT IDENTITY(1,1) PRIMARY KEY,
    IdValorAtributo INT,
    IdZona INT,
    IdCiudad INT,
    IdDepto INT,
    IdRedZona INT,
    IdRed INT,
    IdFlujo INT,
    Sigla NVARCHAR(50),
    IdPromesaCliente INT,
    Promesa NVARCHAR(100),
    IdCanal INT,
    IdTipoNodoInicial INT,
    CodigoInternoInicial BIGINT,
    NumberInternoInicial BIGINT,
    IdTipoNodoFinal INT,
    CodigoInternoFinal BIGINT,
    NumberInternoFinal BIGINT
);

CREATE TABLE ParametrosContingencia (
    IdParametro INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Valor NVARCHAR(500)
);

-------------------------------------------------
-- TRIGGER DE AUDITORÍA
-------------------------------------------------

CREATE TRIGGER TRG_AUDIT_PEDIDOS
ON Pedidos
AFTER UPDATE, DELETE
AS
BEGIN
    INSERT INTO Auditoria (TablaAfectada, Operacion, RegistroId, Usuario, FechaOperacion, DatosPrevios, DatosNuevos)
    SELECT
        'Pedidos',
        CASE WHEN EXISTS (SELECT * FROM inserted) THEN 'UPDATE' ELSE 'DELETE' END,
        deleted.IdPedido,
        SYSTEM_USER,
        SYSDATETIME(),
        'Estado: ' + CAST(deleted.IdEstadoPedido AS NVARCHAR),
        CASE WHEN EXISTS (SELECT * FROM inserted) THEN 'Estado: ' + CAST(inserted.IdEstadoPedido AS NVARCHAR) ELSE NULL END
    FROM deleted
    LEFT JOIN inserted ON deleted.IdPedido = inserted.IdPedido;
END;

-------------------------------------------------
-- INSERTS INICIALES DE ESTADOS Y ROLES
-------------------------------------------------

INSERT INTO EstadosPedido (NombreEstado) VALUES ('Registrado'), ('En proceso'), ('Despachado'), ('Entregado');
INSERT INTO EstadosRutaEntrega (NombreEstado) VALUES ('En tránsito'), ('Reportado'), ('Con novedad'), ('Entregado');
INSERT INTO Roles (NombreRol, Descripcion) VALUES ('ADMIN', 'Administrador general'), ('OPERADOR', 'Usuario operador'), ('CLIENTE', 'Cliente externo');
INSERT INTO Permisos (NombrePermiso, Descripcion) VALUES ('GESTION_PEDIDOS', 'Permiso para gestionar pedidos'), ('CONSULTAR_RUTAS', 'Permiso para consultar rutas');


-------------------------------------------------
-- INSERTS INICIALES DE CLIENTES
-------------------------------------------------
INSERT INTO Clientes (Nombres, Direccion, CorreoElectronico) VALUES
('Juan Perez', 'Calle 123', 'juan.perez@email.com'),
('Maria Gomez', 'Av. Principal', 'maria.gomez@email.com'),
('Carlos Ruiz', 'Cra 45', 'carlos.ruiz@email.com'),
('Laura Torres', 'Calle 78', 'laura.torres@email.com'),
('Pedro León', 'Diagonal 99', 'pedro.leon@email.com');


-------------------------------------------------
-- INSERTS INICIALES DE PRODUCTOS
-------------------------------------------------
INSERT INTO Productos (Nombre, Descripcion) VALUES
('Laptop Lenovo', 'Core i5, 8GB RAM'),
('Mouse Logitech', 'Inalámbrico Bluetooth'),
('Monitor Samsung', '24 pulgadas LED'),
('Teclado Genius', 'USB estándar'),
('Impresora HP', 'Multifuncional láser');

-------------------------------------------------
-- INSERTS INICIALES DE DIRECCIONESENTREGA
-------------------------------------------------
INSERT INTO DireccionesEntrega (IdCliente, Direccion, Ciudad, Departamento, Pais) VALUES
(1, 'Calle 45', 'Bogotá', 'Cundinamarca', 'Colombia'),
(2, 'Av. Caracas', 'Bogotá', 'Cundinamarca', 'Colombia'),
(3, 'Carrera 10', 'Medellín', 'Antioquia', 'Colombia');

-------------------------------------------------
-- INSERTS INICIALES DE PEDIDOS
-------------------------------------------------
INSERT INTO Pedidos (IdCliente, FechaEntrega, IdEstadoPedido, IdDireccionEntrega) VALUES
(1, GETDATE(), 1, 1),
(2, GETDATE(), 1, 2),
(3, GETDATE(), 2, 3);

-------------------------------------------------
-- INSERTS INICIALES DE PRODUCTOSPEDIDOS
-------------------------------------------------
INSERT INTO ProductosPedidos (IdPedido, IdProducto, Cantidad) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 1),
(2, 4, 3),
(3, 5, 1);

-------------------------------------------------
-- INSERTS INICIALES DE CONTINGENCIA
-------------------------------------------------

INSERT INTO ProductosContingencia (PrdLvlNumber, IdValorAtributo, OrgLvlChild, IdNodo, OrigenNumber, IdTipoNodo, PrdLvlChild)
VALUES
('SKU100', 1, 101, 10, 'ORG001', 1, 'SKU-100-A'),
('SKU200', 2, 102, 11, 'ORG002', 1, 'SKU-200-A'),
('SKU300', 3, 103, 12, 'ORG003', 1, 'SKU-300-A');


INSERT INTO CoberturaContingencia (IdValorAtributo, IdZona, IdCiudad, IdDepto, IdRedZona, IdRed, IdFlujo, Sigla, IdPromesaCliente, Promesa,
                                         IdCanal, IdTipoNodoInicial, CodigoInternoInicial, NumberInternoInicial,
                                         IdTipoNodoFinal, CodigoInternoFinal, NumberInternoFinal)
VALUES
(1, 5, 50, 500, 1001, 2001, 3001, 'SIG001', 1, 'Domicilio en fecha',
 1, 10, 101, 10001, 20, 201, 20001),

(2, 6, 60, 600, 1002, 2002, 3002, 'SIG002', 1, 'Domicilio en fecha',
 1, 11, 102, 10002, 21, 202, 20002),

(3, 7, 70, 700, 1003, 2003, 3003, 'SIG003', 1, 'Domicilio en fecha',
 1, 12, 103, 10003, 22, 203, 20003);


 INSERT INTO TblOmsParametrosContingencia (IdParametro, Nombre, Valor)
VALUES
(3, 'HoraInicioDomicilio', '08:00'),
(4, 'HoraFinDomicilio', '19:00'),
(6, 'TiempoPromesaDomicilio', '48 horas');


-------------------------------------------------
-- ÍNDICES CLAVE
-------------------------------------------------
CREATE INDEX IDX_Pedidos_IdCliente ON Pedidos (IdCliente);
CREATE INDEX IDX_HistorialEstadosPedido_Fecha ON HistorialEstadosPedido (FechaCambioEstado);
CREATE INDEX IDX_LogsAplicacion_Fecha ON LogsAplicacion (FechaLog);

CREATE NONCLUSTERED INDEX IDX_Productos_PrdLvlNumber ON ProductosContingencia (PrdLvlNumber);
CREATE NONCLUSTERED INDEX IDX_Productos_IdValorAtributo ON ProductosContingencia (IdValorAtributo);

CREATE NONCLUSTERED INDEX IDX_Cobertura_IdZona ON CoberturaContingencia (IdZona);
CREATE NONCLUSTERED INDEX IDX_Cobertura_IdCiudad ON CoberturaContingencia (IdCiudad);
CREATE NONCLUSTERED INDEX IDX_Cobertura_IdDepto ON CoberturaContingencia (IdDepto);
CREATE NONCLUSTERED INDEX IDX_Cobertura_IdPromesaCliente ON CoberturaContingencia (IdPromesaCliente);
CREATE NONCLUSTERED INDEX IDX_Cobertura_IdValorAtributo ON CoberturaContingencia (IdValorAtributo);


ALTER TABLE RutasEntrega ADD Guia NVARCHAR(100) NULL;

-------------------------------------------------
-- FIN SCRIPT
-------------------------------------------------
