USE [GD1C2014]
GO

CREATE SCHEMA SQL_O AUTHORIZATION gd
GO


CREATE TABLE SQL_O.Usuario(
		UserId numeric(18,0) Primary Key,
		Username varchar(30) Unique,
		Userpass char(32)
		)
GO

CREATE TABLE SQL_O.Visibilidad(
		Vis_Cod numeric(18,0) Primary Key,
		Vis_Desc nvarchar(255),
		Vis_Precio numeric(18,2),
		Vis_Porcentaje numeric(18,2)
		)
GO


CREATE TABLE SQL_O.Rol(
		Rol_Cod numeric(18,0) Primary Key,
		Rol_Nombre nvarchar(255),
		Rol_Estado bit,
		Rol_usuario numeric(18,0) references SQL_O.Usuario(UserId) NOT NULL 
	)
GO
	


CREATE TABLE SQL_O.Datos_Pers(
		Datos_Id numeric(18,0) Primary Key,
		Datos_Mail nvarchar(50),
		Datos_Tel numeric(18,0),
		Datos_Dom_Calle nvarchar(100), 
		Datos_Nro_Calle numeric(18,0),
		Datos_Dom_Piso numeric(18,0),
		Datos_Depto nvarchar(50),
		Datos_Cod_Postal nvarchar(50)
		)
GO	
		

CREATE TABLE SQL_O.Empresa(
		Emp_Cod numeric(18,0) Primary Key references SQL_O.Rol(Rol_Cod) NOT NULL,
		Emp_Razon_Social nvarchar(255) Unique,
		Emp_Cuit nvarchar(50) Unique,
		Emp_Fecha_Creacion datetime,
		Emp_Contacto nvarchar(50),
		Emp_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
		--Emp_Mail nvarchar(50),
		--Emp_Tel numeric(18,0),
		--Emp_Dom_Calle nvarchar(100), 
		--Emp_Nro_Calle numeric(18,0),
		--Emp_Dom_Piso numeric(18,0),
		--Emp_Depto nvarchar(50),
		--Emp_Cod_Postal nvarchar(50),
		Emp_Estado bit,
		Emp_Reputacion numeric(18,0),	
	)
Go


CREATE TABLE SQL_O.Cliente(
		Cli_Id numeric(18,0) Primary Key references SQL_O.Rol(Rol_Cod) NOT NULL,
		Cli_NroDoc numeric(18,0), 
		Cli_TipoDoc nvarchar(20), 
		Cli_Apellido nvarchar(255),
		Cli_Nombre nvarchar(255),
		Cli_Cuil numeric(18,0) Unique,
		Cli_Fecha_Nac datetime,
		Cli_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
		--Cli_Mail nvarchar(255),
		--Cli_Tel numeric(18,0),
		--Cli_Dom_Calle nvarchar(255),
		--Cli_Nro_Calle numeric(18,0),
		--Cli_Piso numeric(18,0),
		--Cli_Depto numeric(18,0),
		--Cli_Cod_Post nvarchar(50),
		Cli_Estdo bit,
		Cli_Reputacion numeric(18)
		--Primary Key(Cli_NroDoc,Cli_TipoDoc)
		)
GO

CREATE TABLE SQL_O.Administrativo(
		Admin_Id numeric(18,0) Primary Key References SQL_O.Rol(Rol_Cod) NOT NULL,
		Admin_NroDoc numeric(18,0), 
		Admin_TipoDoc nvarchar(20), 
		Admin_Apellido nvarchar(255),
		Admin_Nombre nvarchar(255),
		Admin_Cuil numeric(18,0) Unique,
		Admin_Fecha_Nac datetime,
		Admin_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
		Admin_Estdo bit
		--Primary Key(Admin_NroDoc,Admin_TipoDoc)
		)
GO
		

CREATE TABLE SQL_O.Tipo_Pub(
		Tipo_Id numeric(18,0) Primary Key,
		Tipo char(1),
		Tipo_Precio numeric(18,2),
		Tipo_Comprador numeric(18,0) references SQL_O.ROL(Rol_Cod) NOT NULL
		)
GO

CREATE TABLE SQL_O.Publicacion(
		Pub_Cod numeric(18,0) Primary Key,
		Pub_Desc nvarchar(255),
		Pub_Stock numeric(18,0),
		Pub_Fecha_Ini datetime,
		Pub_Fecha_Vto datetime,
		Pub_Precio numeric(18,2),
		Pub_Tipo numeric(18,0) references SQL_O.Tipo_Pub(Tipo_Id) NOT NULL,
		Pub_Estado nvarchar(255),
		Pub_Visibilidad numeric(18,0) references SQL_O.Visibilidad(Vis_Cod) NOT NULL,
		Pub_Duenio numeric (18,0) references SQL_O.Rol(Rol_Cod) NOT NULL
		)
GO

CREATE TABLE SQL_O.Respuesta(
		Res_Cod numeric(18,0) Primary key,
		Res_Texto nvarchar(255),
		Res_Fecha datetime
		)
GO
CREATE TABLE SQL_O.Pregunta(
		Pre_Id numeric(18,0) Primary Key,
		Pre_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Pre_Res numeric(18,0) references SQL_O.Respuesta(Res_Cod) NOT NULL,
		Pre_Texto nvarchar(255),
		Pre_Fecha datetime
		)
GO



CREATE TABLE SQL_O.Compra(
		Compra_Id numeric(18,0) Primary Key,
		Compra_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Compra_Fecha datetime,
		Compra_Cantidad numeric(18,0)
		)
GO

CREATE TABLE SQL_O.Oferta(
		Oferta_Id numeric(18,0) Primary Key,
		Oferta_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Oferta_Fecha datetime,
		Oferta_Monto numeric(18,2),
		Oferta_Cliente numeric(18,0) references SQL_O.Rol(Rol_Cod) NOT NULL
		)
GO

CREATE TABLE SQL_O.Calificacion(
		Cal_Codigo numeric(18,0) Primary Key,
		Cal_Cant_Est numeric(18,0),
		Cal_Desc nvarchar(255),
		Cal_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL
		)
GO

CREATE TABLE SQL_O.Rubro(
		Rubro_Cod numeric(18,0) Primary key,
		Rubro_Desc nvarchar(255)
		)
GO

CREATE TABLE SQL_O.Pub_Por_Rubro(
		Rubro_Cod numeric(18,0) references SQL_O.Rubro(Rubro_Cod) NOT NULL,
		Pub_Cod numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Primary Key(Rubro_Cod,Pub_Cod)
		)
GO

/*Notas:
	En tabla maestra:
		~ Las columnas que empiezan con Publ_ se refieren a dueños de publicaciones.
		~ Las columnas que empiezan con Cli siempre estan "unidas" a ofertas o compras, o sea son clientes que ofertaron o compraron algo.

TODO:
- Analizar tipos de datos medios fruta (userpass, entre otros).
- Tipos de usuario donde carajo iria.
- Analizar Joined de Rol.
- Ver Pks de c/u (Ejemplo los unique de tipo y nro Doc, razon social y cuit, con el joined) .
- Analizar normalizacion datos personales.
- Analizar single table de Tipo_Pub.
- Atributo de compra "cantidad" ver como meterlo.
- Agregar Factura.
- Agregar Constraints Faltantes.
- Ver que le mandamos a Admin, puede ser de ultima un single table con cliente si van a tener lo mismo.*/