CREATE PROCEDURE dbo.usp_Delete_Categoria
	(
	@CategoriaId uniqueidentifier
)
AS
BEGIN
	UPDATE Categorias
	SET Estado = 0
	WHERE CategoriaId=@CategoriaId;

END;

CREATE PROCEDURE dbo.usp_Delete_Combo
	(
	@ComboId uniqueidentifier
)
AS
BEGIN
	UPDATE Combos
	SET Estado=0
	WHERE ComboId=@ComboId;
END;

CREATE PROCEDURE dbo.usp_Delete_Producto
	(
	@ProductoId uniqueidentifier
)
AS
BEGIN
	UPDATE Productos
	SET Estado=0
	WHERE ProductoId=@ProductoId;
END;

CREATE PROCEDURE dbo.usp_Delete_Proveedor
	(
	@ProveedorId uniqueidentifier
)
AS
BEGIN
	UPDATE Proveedores
	SET Estado=0
	WHERE ProveedorId=@ProveedorId;
END;

CREATE PROCEDURE dbo.usp_Get_Categoria
AS

BEGIN
	SELECT CategoriaId, NombreCategoria, Descripcion, Estado
	FROM Categorias
	Where Estado = '1';

END;

CREATE PROCEDURE dbo.usp_Get_Combo
	(
	@ProductoId uniqueidentifier
)
AS
BEGIN
	SELECT C.ComboId, C.NombreCombo, C.Cantidad, C.PrecioCombo, C.Estado
	FROM Combos C
		INNER JOIN Productos P ON  C.ProductoId = P.ProductoId
	WHERE C.ProductoId = @ProductoId and C.Estado = '1';
END;

CREATE PROCEDURE dbo.usp_Get_ComboList
AS

BEGIN
	SELECT C.ComboId, C.NombreCombo, C.Cantidad, C.PrecioCombo, C.ProductoId, C.Estado
	FROM Combos C
		INNER JOIN Productos P ON P.ProductoId = C.ProductoId
	WHERE P.Estado = '1' and C.Estado = '1';
END;

CREATE PROCEDURE dbo.usp_Get_Compra
AS
BEGIN
	SELECT
		C.CompraId,
		C.FechaCompra,
		C.TipoComprobante,
		C.Serie,
		C.Correlativo,
		C.Igv,
		C.Descuento,
		C.Estado,
		P.NombreProveedor
	FROM Compras C
		INNER JOIN Proveedores P
		ON C.ProveedorId = P.ProveedorId
;
END;

CREATE PROCEDURE dbo.usp_Get_DetalleCompra
	(
	@CompraId uniqueidentifier
)
AS
BEGIN
	SELECT
		DC.DetalleCompraId,
		DC.Cantidad,
		DC.PrecioUnitario,
		DC.SubTotal,
		P.NombreProducto,
		DC.Estado
	FROM DetallesCompras DC
		INNER JOIN Productos P
		ON DC.ProductoId = P.ProductoId
		INNER JOIN Compras C
		ON DC.CompraId = C.CompraId
	WHERE DC.CompraId =@CompraId and DC.Estado = '1';
END;

CREATE PROCEDURE dbo.usp_Get_Producto
AS
BEGIN
	SELECT P.ProductoId,
		P.NombreProducto,
		P.Descripcion,
		P.Stock,
		P.PrecioVenta,
		P.Estado,
		Cat.NombreCategoria
	FROM Productos P
		INNER JOIN Categorias Cat ON P.CategoriaId = Cat.CategoriaId
	WHERE P.Estado = '1';
END;

CREATE PROCEDURE dbo.usp_Get_Proveedor
AS
BEGIN
	SELECT ProveedorId, NombreProveedor, Telefono, Direccion, Estado
	FROM Proveedores
	WHERE Estado = '1';
END;

CREATE PROCEDURE dbo.usp_GetId_Categoria
	(
	@CategoriaId uniqueidentifier
)
AS
BEGIN
	SELECT CategoriaId, NombreCategoria, Descripcion, Estado
	FROM Categorias
	WHERE CategoriaId = @CategoriaId;
END;

CREATE PROCEDURE dbo.usp_GetId_Combo
	(
	@ComboId uniqueidentifier
)
AS
BEGIN
	SELECT ComboId, NombreCombo, Cantidad, PrecioCombo, ProductoId, Estado
	FROM Combos
	WHERE ComboId = @ComboId
;
END;

CREATE PROCEDURE dbo.usp_GetId_Compra
	(
	@CompraId uniqueidentifier
)
AS
BEGIN
	SELECT
		C.CompraId,
		C.FechaCompra,
		C.TipoComprobante,
		C.Serie,
		C.Correlativo,
		C.Igv,
		C.Descuento,
		C.Estado,
		P.NombreProveedor
	FROM Compras C
		INNER JOIN Proveedores P
		ON C.ProveedorId = P.ProveedorId
	WHERE CompraId = @CompraId;
END;

CREATE PROCEDURE dbo.usp_GetId_Producto
	(
	@ProductoId uniqueidentifier
)
AS
BEGIN
	SELECT P.ProductoId,
		P.NombreProducto,
		P.Descripcion,
		P.Stock,
		P.PrecioVenta,
		P.Estado,
		Cat.NombreCategoria
	FROM Productos P
		INNER JOIN Categorias Cat ON P.CategoriaId = Cat.CategoriaId
	WHERE P.ProductoId = @ProductoId;

END;

CREATE PROCEDURE dbo.usp_GetId_Proveedor
	(
	@ProveedorId uniqueidentifier
)
AS
BEGIN
	SELECT ProveedorId, NombreProveedor, Telefono, Direccion, Estado
	FROM Proveedores
	WHERE ProveedorId=@ProveedorId
;
END;

CREATE PROCEDURE dbo.usp_Post_Categoria
	(
	@CategoriaId uniqueidentifier,
	@NombreCategoria varchar(300),
	@Descripcion varchar(max)
)
AS
BEGIN
	INSERT INTO Categorias
		(CategoriaId, NombreCategoria, Descripcion, Estado)
	VALUES(@CategoriaId, @NombreCategoria, @Descripcion, '1');
END;

CREATE PROCEDURE dbo.usp_Post_Combo
	(
	@ComboId uniqueidentifier,
	@NombreCombo VARCHAR(300),
	@Cantidad DECIMAL(18,2),
	@PrecioCombo DECIMAL(18,2),
	@ProductoId uniqueidentifier
)
AS

BEGIN
	INSERT INTO Combos
		(ComboId, NombreCombo, Cantidad, PrecioCombo, ProductoId, Estado)
	VALUES(@ComboId, @NombreCombo, @Cantidad, @PrecioCombo, @ProductoId, 1);
END;

CREATE PROCEDURE dbo.usp_Post_Compra
	(
	@CompraId uniqueidentifier,
	@FechaCompra DATETIME,
	@TipoComprobante VARCHAR(300),
	@Serie VARCHAR(50),
	@Correlativo DECIMAL(18,2),
	@Igv DECIMAL(18,2),
	@Descuento DECIMAL(18,2),
	@ProveedorId uniqueidentifier
)
AS
BEGIN
	INSERT INTO Compras
		(CompraId, FechaCompra, TipoComprobante, Serie, Correlativo, Igv, Descuento, ProveedorId, Estado)
	VALUES(
			@CompraId,
			@FechaCompra,
			@TipoComprobante,
			@Serie,
			@Correlativo,
			@Igv,
			@Descuento,
			@ProveedorId,
			1
		);
END;

CREATE PROCEDURE dbo.usp_Post_DetalleCompra
	(
	@DetalleCompraId uniqueidentifier,
	@Cantidad DECIMAL(18,2),
	@PrecioUnitario	 DECIMAL(18,2),
	@SubTotal DECIMAL(18,2),
	@CompraId uniqueidentifier,
	@ProductoId uniqueidentifier
)
AS
BEGIN
	INSERT INTO DetallesCompras
		(DetalleCompraId, Cantidad, PrecioUnitario, SubTotal, CompraId, ProductoId, Estado)
	VALUES
		(
			@DetalleCompraId,
			@Cantidad,
			@PrecioUnitario,
			@SubTotal,
			@CompraId,
			@ProductoId,
			1
	);

END;

CREATE PROCEDURE dbo.usp_Post_Producto
	(
	@ProductoId uniqueidentifier,
	@NombreProducto varchar(500),
	@Descripcion varchar(max),
	@Stock DECIMAL(18,2),
	@PrecioVenta DECIMAL(18,2),
	@CategoriaId uniqueidentifier
)
AS
BEGIN
	INSERT INTO Productos
		(ProductoId, NombreProducto, Descripcion, Stock, PrecioVenta, Estado, CategoriaId)
	VALUES(@ProductoId, @NombreProducto, @Descripcion, @Stock, @PrecioVenta, 1, @CategoriaId);

	INSERT INTO Combos
		(ComboId, NombreCombo, Cantidad, PrecioCombo, ProductoId, Estado)
	VALUES(NEWID(), @NombreProducto, 1, @PrecioVenta, @ProductoId, 1);


END;

CREATE PROCEDURE dbo.usp_Post_Proveedor
	(
	@ProveedorId uniqueidentifier,
	@NombreProveedor VARCHAR(500),
	@Telefono VARCHAR(12),
	@Direccion VARCHAR(500)
)
AS
BEGIN
	INSERT INTO Proveedores
		(ProveedorId, NombreProveedor, Telefono, Direccion, Estado)
	VALUES(@ProveedorId , @NombreProveedor, @Telefono, @Direccion, 1);
END;

CREATE PROCEDURE dbo.usp_Put_Categoria
	(
	@CategoriaId uniqueidentifier,
	@NombreCategoria varchar(300),
	@Descripcion varchar(max)
)
AS
BEGIN
	UPDATE Categorias
	SET 
		NombreCategoria = @NombreCategoria, 
		Descripcion = @Descripcion
	WHERE CategoriaId=@CategoriaId;

END;

CREATE PROCEDURE dbo.usp_Put_Combo
	(
	@ComboId uniqueidentifier,
	@NombreCombo VARCHAR(300),
	@Cantidad DECIMAL(18,2),
	@PrecioCombo DECIMAL(18,2),
	@ProductoId uniqueidentifier
)
AS
BEGIN
	UPDATE Combos
	SET NombreCombo=@NombreCombo, Cantidad=@Cantidad, PrecioCombo=@PrecioCombo
	WHERE ComboId=@ComboId and ProductoId=@ProductoId;

END;

CREATE PROCEDURE dbo.usp_Put_Producto
	(
	@ProductoId uniqueidentifier,
	@NombreProducto varchar(500),
	@Descripcion varchar(max),
	@Stock DECIMAL(18,2),
	@PrecioVenta DECIMAL(18,2),
	@CategoriaId uniqueidentifier
)
AS
BEGIN
	Declare @Id uniqueidentifier
	SELECT TOP 1
		@Id = ComboId
	FROM DatabaseKardex.dbo.Combos
	where ProductoId=@ProductoId;

	UPDATE Productos
	SET NombreProducto=@NombreProducto, Descripcion=@Descripcion, 
	PrecioVenta=@PrecioVenta, CategoriaId=@CategoriaId
	WHERE ProductoId=@ProductoId;

	UPDATE Combos
	SET NombreCombo=@NombreProducto, PrecioCombo=@PrecioVenta
	WHERE ComboId=@Id;

END;

CREATE PROCEDURE dbo.usp_Put_Proveedor
	(
	@ProveedorId uniqueidentifier,
	@NombreProveedor VARCHAR(500),
	@Telefono VARCHAR(12),
	@Direccion VARCHAR(500)
)
AS
BEGIN
	UPDATE Proveedores
	SET NombreProveedor=@NombreProveedor, Telefono=@Telefono, Direccion=@Direccion
	WHERE ProveedorId=@ProveedorId;
END;
