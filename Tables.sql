-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- DatabaseKardex.dbo.AspNetRoles definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetRoles GO

CREATE TABLE DatabaseKardex.dbo.AspNetRoles (
	Id nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Name nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	NormalizedName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	ConcurrencyStamp nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id)
) GO
 CREATE  UNIQUE NONCLUSTERED INDEX RoleNameIndex ON dbo.AspNetRoles (  NormalizedName ASC  )  
	 WHERE  ([NormalizedName] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.AspNetUsers definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetUsers GO

CREATE TABLE DatabaseKardex.dbo.AspNetUsers (
	Id nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	UserName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	NormalizedUserName nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	Email nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	NormalizedEmail nvarchar(256) COLLATE Modern_Spanish_CI_AS NULL,
	EmailConfirmed bit NOT NULL,
	PasswordHash nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	SecurityStamp nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	ConcurrencyStamp nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	PhoneNumber nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	PhoneNumberConfirmed bit NOT NULL,
	TwoFactorEnabled bit NOT NULL,
	LockoutEnd datetimeoffset NULL,
	LockoutEnabled bit NOT NULL,
	AccessFailedCount int NOT NULL,
	NombreCompleto nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Estado tinyint NOT NULL,
	isAdmin tinyint NOT NULL,
	CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
) GO
 CREATE NONCLUSTERED INDEX EmailIndex ON dbo.AspNetUsers (  NormalizedEmail ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO
 CREATE  UNIQUE NONCLUSTERED INDEX UserNameIndex ON dbo.AspNetUsers (  NormalizedUserName ASC  )  
	 WHERE  ([NormalizedUserName] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.Categorias definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Categorias GO

CREATE TABLE DatabaseKardex.dbo.Categorias (
	CategoriaId uniqueidentifier NOT NULL,
	NombreCategoria nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Descripcion nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Estado tinyint NOT NULL,
	CONSTRAINT PK_Categorias PRIMARY KEY (CategoriaId)
) GO;


-- DatabaseKardex.dbo.Clientes definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Clientes GO

CREATE TABLE DatabaseKardex.dbo.Clientes (
	ClienteId uniqueidentifier NOT NULL,
	NombreCompleto nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Sexo nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Dni nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Ruc nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Telefono nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	FechaNacimiento datetime2(7) NOT NULL,
	Direccion nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Email nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_Clientes PRIMARY KEY (ClienteId)
) GO;


-- DatabaseKardex.dbo.Proveedores definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Proveedores GO

CREATE TABLE DatabaseKardex.dbo.Proveedores (
	ProveedorId uniqueidentifier NOT NULL,
	NombreProveedor nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Telefono nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Direccion nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Estado tinyint NOT NULL,
	CONSTRAINT PK_Proveedores PRIMARY KEY (ProveedorId)
) GO;


-- DatabaseKardex.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.[__EFMigrationsHistory] GO

CREATE TABLE DatabaseKardex.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
) GO;


-- DatabaseKardex.dbo.AspNetRoleClaims definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetRoleClaims GO

CREATE TABLE DatabaseKardex.dbo.AspNetRoleClaims (
	Id int IDENTITY(1,1) NOT NULL,
	RoleId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ClaimType nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	ClaimValue nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
	CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES DatabaseKardex.dbo.AspNetRoles(Id) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_AspNetRoleClaims_RoleId ON dbo.AspNetRoleClaims (  RoleId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.AspNetUserClaims definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetUserClaims GO

CREATE TABLE DatabaseKardex.dbo.AspNetUserClaims (
	Id int IDENTITY(1,1) NOT NULL,
	UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ClaimType nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	ClaimValue nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_AspNetUserClaims PRIMARY KEY (Id),
	CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES DatabaseKardex.dbo.AspNetUsers(Id) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_AspNetUserClaims_UserId ON dbo.AspNetUserClaims (  UserId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.AspNetUserLogins definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetUserLogins GO

CREATE TABLE DatabaseKardex.dbo.AspNetUserLogins (
	LoginProvider nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ProviderKey nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ProviderDisplayName nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider,ProviderKey),
	CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES DatabaseKardex.dbo.AspNetUsers(Id) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_AspNetUserLogins_UserId ON dbo.AspNetUserLogins (  UserId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.AspNetUserRoles definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetUserRoles GO

CREATE TABLE DatabaseKardex.dbo.AspNetUserRoles (
	UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	RoleId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId,RoleId),
	CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId) REFERENCES DatabaseKardex.dbo.AspNetRoles(Id) ON DELETE CASCADE,
	CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES DatabaseKardex.dbo.AspNetUsers(Id) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_AspNetUserRoles_RoleId ON dbo.AspNetUserRoles (  RoleId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.AspNetUserTokens definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.AspNetUserTokens GO

CREATE TABLE DatabaseKardex.dbo.AspNetUserTokens (
	UserId nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	LoginProvider nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Name nvarchar(450) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Value nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId,LoginProvider,Name),
	CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES DatabaseKardex.dbo.AspNetUsers(Id) ON DELETE CASCADE
) GO;


-- DatabaseKardex.dbo.Compras definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Compras GO

CREATE TABLE DatabaseKardex.dbo.Compras (
	CompraId uniqueidentifier NOT NULL,
	FechaCompra datetime2(7) NOT NULL,
	TipoComprobante nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Serie nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Correlativo decimal(18,2) NOT NULL,
	Igv decimal(18,2) NOT NULL,
	Descuento decimal(18,2) NOT NULL,
	ProveedorId uniqueidentifier NOT NULL,
	Estado tinyint NOT NULL,
	CONSTRAINT PK_Compras PRIMARY KEY (CompraId),
	CONSTRAINT FK_Compras_Proveedores_ProveedorId FOREIGN KEY (ProveedorId) REFERENCES DatabaseKardex.dbo.Proveedores(ProveedorId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_Compras_ProveedorId ON dbo.Compras (  ProveedorId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.Productos definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Productos GO

CREATE TABLE DatabaseKardex.dbo.Productos (
	ProductoId uniqueidentifier NOT NULL,
	NombreProducto nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Descripcion nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Stock int NOT NULL,
	PrecioVenta decimal(18,2) NOT NULL,
	Estado tinyint NOT NULL,
	CategoriaId uniqueidentifier NOT NULL,
	CONSTRAINT PK_Productos PRIMARY KEY (ProductoId),
	CONSTRAINT FK_Productos_Categorias_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES DatabaseKardex.dbo.Categorias(CategoriaId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_Productos_CategoriaId ON dbo.Productos (  CategoriaId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.Ventas definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Ventas GO

CREATE TABLE DatabaseKardex.dbo.Ventas (
	VentaId uniqueidentifier NOT NULL,
	TipoComprobante nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Serie nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Correlativo decimal(18,2) NOT NULL,
	Igv decimal(18,2) NOT NULL,
	Descuento decimal(18,2) NOT NULL,
	TotalImporte decimal(18,2) NOT NULL,
	ClienteId uniqueidentifier NOT NULL,
	CONSTRAINT PK_Ventas PRIMARY KEY (VentaId),
	CONSTRAINT FK_Ventas_Clientes_ClienteId FOREIGN KEY (ClienteId) REFERENCES DatabaseKardex.dbo.Clientes(ClienteId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_Ventas_ClienteId ON dbo.Ventas (  ClienteId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.Combos definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.Combos GO

CREATE TABLE DatabaseKardex.dbo.Combos (
	ComboId uniqueidentifier NOT NULL,
	NombreCombo nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Cantidad int NOT NULL,
	PrecioCombo decimal(18,2) NOT NULL,
	ProductoId uniqueidentifier NOT NULL,
	Estado tinyint NOT NULL,
	CONSTRAINT PK_Combos PRIMARY KEY (ComboId),
	CONSTRAINT FK_Combos_Productos_ProductoId FOREIGN KEY (ProductoId) REFERENCES DatabaseKardex.dbo.Productos(ProductoId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_Combos_ProductoId ON dbo.Combos (  ProductoId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.DetallesCompras definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.DetallesCompras GO

CREATE TABLE DatabaseKardex.dbo.DetallesCompras (
	DetalleCompraId uniqueidentifier NOT NULL,
	Cantidad decimal(18,2) NOT NULL,
	PrecioUnitario decimal(18,2) NOT NULL,
	SubTotal decimal(18,2) NOT NULL,
	CompraId uniqueidentifier NOT NULL,
	ProductoId uniqueidentifier NOT NULL,
	Estado tinyint NOT NULL,
	CONSTRAINT PK_DetallesCompras PRIMARY KEY (DetalleCompraId),
	CONSTRAINT FK_DetallesCompras_Compras_CompraId FOREIGN KEY (CompraId) REFERENCES DatabaseKardex.dbo.Compras(CompraId) ON DELETE CASCADE,
	CONSTRAINT FK_DetallesCompras_Productos_ProductoId FOREIGN KEY (ProductoId) REFERENCES DatabaseKardex.dbo.Productos(ProductoId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_DetallesCompras_CompraId ON dbo.DetallesCompras (  CompraId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO
 CREATE NONCLUSTERED INDEX IX_DetallesCompras_ProductoId ON dbo.DetallesCompras (  ProductoId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- DatabaseKardex.dbo.DetallesVentas definition

-- Drop table

-- DROP TABLE DatabaseKardex.dbo.DetallesVentas GO

CREATE TABLE DatabaseKardex.dbo.DetallesVentas (
	DetalleVentaId uniqueidentifier NOT NULL,
	Descuento decimal(18,2) NOT NULL,
	Cantidad decimal(18,2) NOT NULL,
	PrecioUnitario decimal(18,2) NOT NULL,
	SubTotal decimal(18,2) NOT NULL,
	ProductoId uniqueidentifier NOT NULL,
	VentaId uniqueidentifier NOT NULL,
	CONSTRAINT PK_DetallesVentas PRIMARY KEY (DetalleVentaId),
	CONSTRAINT FK_DetallesVentas_Productos_ProductoId FOREIGN KEY (ProductoId) REFERENCES DatabaseKardex.dbo.Productos(ProductoId) ON DELETE CASCADE,
	CONSTRAINT FK_DetallesVentas_Ventas_VentaId FOREIGN KEY (VentaId) REFERENCES DatabaseKardex.dbo.Ventas(VentaId) ON DELETE CASCADE
) GO
 CREATE NONCLUSTERED INDEX IX_DetallesVentas_ProductoId ON dbo.DetallesVentas (  ProductoId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO
 CREATE NONCLUSTERED INDEX IX_DetallesVentas_VentaId ON dbo.DetallesVentas (  VentaId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;;
 
