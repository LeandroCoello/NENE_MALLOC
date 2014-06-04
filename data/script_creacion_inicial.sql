USE [GD1C2014]
GO

CREATE SCHEMA SQL_O AUTHORIZATION gd
GO


CREATE TABLE SQL_O.Usuario(
		UserId numeric(18,0) Primary Key Identity,
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
		Rol_Cod numeric(18,0) Primary Key identity,
		Rol_Nombre nvarchar(255),
		Rol_usuario numeric(18,0) references SQL_O.Usuario(UserId) 
	)
GO
	


CREATE TABLE SQL_O.Datos_Pers(
		Datos_Id numeric(18,0) Primary Key Identity,
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
		Emp_Estado bit default 0,
		Emp_Reputacion numeric(18,0) default 0	
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
		Cli_Estado bit default 0,
		Cli_Reputacion numeric(18) default 0
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
		Admin_Estado bit default 0
		--Primary Key(Admin_NroDoc,Admin_TipoDoc)
		)
GO
		

CREATE TABLE SQL_O.Tipo_Pub(
		Tipo_Id numeric(18,0) Primary Key identity,
		Tipo char(1),
		Tipo_Precio numeric(18,2),
		Tipo_Desc nvarchar(255)
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
		Res_Cod numeric(18,0) Primary key identity,
		Res_Texto nvarchar(255),
		Res_Fecha datetime
		)
GO
CREATE TABLE SQL_O.Pregunta(
		Pre_Id numeric(18,0) Primary Key identity,
		Pre_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Pre_Res numeric(18,0) references SQL_O.Respuesta(Res_Cod) NOT NULL,
		Pre_Texto nvarchar(255),
		Pre_Fecha datetime
		)
GO

CREATE TABLE SQL_O.Factura (
	Factura_Nro numeric(18,0) Primary Key, 
	Factura_Fecha datetime, 
	Factura_Total numeric(18,0),
	Factura_Forma_Pago nvarchar(255)
	)
	

CREATE TABLE SQL_O.Compra(
		Compra_Id numeric(18,0) Primary Key identity,
		Compra_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Compra_Fecha datetime,
		Compra_Cantidad numeric(18,0),
		Compra_Factura numeric(18,0) references SQL_O.Factura(Factura_Nro),
		Compra_Comprador numeric(18,0) references SQL_O.Cliente(Cli_Id)
		)
GO

CREATE TABLE SQL_O.Oferta(
		Oferta_Id numeric(18,0) Primary Key identity,
		Oferta_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Oferta_Fecha datetime,
		Oferta_Monto numeric(18,2),
		Oferta_Cliente numeric(18,0) references SQL_O.Rol(Rol_Cod) NOT NULL,
		Oferta_Gano bit
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
		Rubro_Cod numeric(18,0) Primary key identity,
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

- Tipos de usuario donde carajo iria.
- Cuando se finaliza una subasta la misma pasa a ser una compra con el ultimo que oferto como comprador.
- Los items de las facturas serian las compras.
- Analizar tipos de datos medios fruta (userpass, entre otros).
*/

--Migracion

Insert into SQL_O.Visibilidad(Vis_Cod,Vis_Desc,Vis_Porcentaje,Vis_Precio)
	(select distinct Publicacion_Visibilidad_Cod, 
					 Publicacion_Visibilidad_Desc,
				     Publicacion_Visibilidad_Porcentaje,
				     Publicacion_Visibilidad_Precio 
		from gd_esquema.Maestra)
GO
	
Insert into SQL_O.Rubro(Rubro_Desc)
	(select distinct Publicacion_Rubro_Descripcion from gd_esquema.Maestra)
GO	

--recorrer select de empresa con cursor e ir insertando en empresa y datos personales
Declare 
@razon_social nvarchar(255),
@cuit nvarchar(50),
@fecha_c datetime,
@mail nvarchar(50),
@dom_calle nvarchar(100),
@nro_calle numeric(18,0),
@piso numeric(18,0),
@depto nvarchar(50),
@cod_postal nvarchar(50)

Declare cursor_Migracion cursor 
     for (select distinct 
				Publ_Empresa_Razon_Social,
				Publ_Empresa_Cuit,
				Publ_Empresa_Fecha_Creacion,
				Publ_Empresa_Mail,
				Publ_Empresa_Dom_Calle,
				Publ_Empresa_Nro_Calle,
				Publ_Empresa_Piso,
				Publ_Empresa_Depto,
				Publ_Empresa_Cod_Postal
		from gd_esquema.Maestra where Publ_Empresa_Razon_Social is not null)
Open cursor_Migracion
fetch cursor_Migracion into @razon_social, @cuit, @fecha_c, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal
while(@@fetch_status=0)
begin

Insert into SQL_O.Rol(Rol_Nombre) values ('Empresa')

Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal)
			values(@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal)
			
Insert into SQL_O.Empresa(Emp_Cod,Emp_Datos_Pers ,Emp_Razon_Social, Emp_Cuit, Emp_Fecha_Creacion) 
			values((select Max(Rol_Cod) from SQL_O.Rol),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @razon_social, @cuit, @fecha_c)


fetch cursor_Migracion into @razon_social, @cuit, @fecha_c, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal
end
close cursor_Migracion
deallocate cursor_Migracion
 
GO