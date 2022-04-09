CREATE DATABASE VentaProducto
GO
USE VentaProducto
GO

CREATE TABLE Cliente
(
	IdCliente INT IDENTITY PRIMARY KEY,
	Cedula VARCHAR(20),
	Nombre VARCHAR(50),
	Apellido VARCHAR(70),
	Telefono VARCHAR(20),
	FechaRegistro DATETIME
)

CREATE TABLE Producto
(
	IdProducto INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(70),
	ValorUnitario DECIMAL(15,2)
)

CREATE TABLE Venta
(
	IdVenta INT IDENTITY PRIMARY KEY,
	NumeroVenta INT,
	NombreProducto VARCHAR(70),
	Cantidad INT,
	ValorUnitario DECIMAL(15,2),
	ValorTotal DECIMAL(15,2),
	FechaVenta DATETIME,
	IdProducto INT,
	IdCliente INT,
	CONSTRAINT FK_Producto FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
	CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente)
)


