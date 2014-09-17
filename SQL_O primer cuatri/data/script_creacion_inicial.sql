USE [GD1C2014]
GO

CREATE SCHEMA  SQL_O AUTHORIZATION gd 
GO

CREATE TABLE SQL_O.Funcionalidad(

		Func_Cod numeric(18,0) Primary Key Identity,
		Func_Desc nvarchar(255)		
		)
GO

CREATE TABLE SQL_O.Rol(

		Rol_Cod numeric(18,0) Primary Key,
		Rol_Desc nvarchar(255),
		Rol_baja bit default 0		
		)
GO

CREATE TABLE SQL_O.Func_Por_Rol(

		Rol_Cod numeric(18,0)references SQL_O.Rol(Rol_Cod),
		Func_Cod numeric(18,0) references SQL_O.Funcionalidad(Func_Cod),	
		Primary Key (Rol_Cod,Func_Cod)
		)
GO

	

CREATE TABLE SQL_O.Tipo(
		Tipo_Cod numeric(18,0) Primary Key identity,
		Tipo_Nombre nvarchar(255),
		Tipo_Mail nvarchar(50),
		Tipo_Tel numeric(18,0),
		Tipo_Dom_Calle nvarchar(100), 
		Tipo_Nro_Calle numeric(18,0),
		Tipo_Dom_Piso numeric(18,0),
		Tipo_Depto nvarchar(50),
		Tipo_Cod_Postal nvarchar(50),
		Tipo_Localidad nvarchar(80)
	)
GO


CREATE TABLE SQL_O.Empresa(
		Emp_Cod numeric(18,0) Primary Key references SQL_O.Tipo(Tipo_Cod) NOT NULL,
		Emp_Razon_Social nvarchar(255) Unique,
		Emp_Cuit nvarchar(50) Unique,
		Emp_Fecha_Creacion datetime,
		Emp_Contacto nvarchar(50),
		Emp_Reputacion numeric(18,0) default 0,
		Emp_Baja bit default 0
	)
Go


CREATE TABLE SQL_O.Cliente(
		Cli_Id numeric(18,0) Primary Key references SQL_O.Tipo(Tipo_Cod) NOT NULL,
		Cli_NroDoc numeric(18,0), 
		Cli_TipoDoc nvarchar(20), 
		Cli_Apellido nvarchar(255),
		Cli_Nombre nvarchar(255),
		Cli_Cuil nvarchar(50) ,
		Cli_Fecha_Nac datetime,
		Cli_Reputacion numeric(18) default 0,
		Cli_Baja bit default 0
		)
GO

--quizas no deberia estar 
CREATE TABLE SQL_O.Administrativo(
		Admin_Id numeric(18,0) Primary Key References SQL_O.Tipo(Tipo_Cod) NOT NULL,
		Admin_NroDoc numeric(18,0), 
		Admin_TipoDoc nvarchar(20), 
		Admin_Apellido nvarchar(255),
		Admin_Nombre nvarchar(255),
		Admin_Cuil numeric(18,0) Unique,
		Admin_Fecha_Nac datetime,
		)
GO

CREATE TABLE SQL_O.Usuario(
		UserId numeric(18,0) Primary Key Identity,
		Username varchar(30) Unique,
		Userpass nvarchar (255),
		User_Intentos numeric (18,0) default 0,
		User_Deshabilitado bit default 0,
		User_Baja bit default 0,
		User_Tipo numeric(18,0) references SQL_O.Tipo(Tipo_Cod)
		)
GO


CREATE TABLE SQL_O.Usuarios_Por_Rol(
		UserId numeric(18,0) references SQL_O.Usuario(UserId),
		Rol_Cod numeric(18,0) references SQL_O.Rol(Rol_Cod)
		Primary Key(UserId,Rol_Cod)
	
	)
GO

CREATE TABLE SQL_O.Visibilidad(
		Vis_Cod numeric(18,0) Primary Key,
		Vis_Desc nvarchar(255),
		Vis_Duracion numeric(18,0),
		Vis_Precio numeric(18,2),
		Vis_Porcentaje numeric(18,2),
		Vis_Baja bit default 0
		)
GO

CREATE TABLE SQL_O.Publicacion(
		Pub_Cod numeric(18,0) Primary Key,
		Pub_Desc nvarchar(255),
		Pub_Stock_Inicial numeric(18,0),
		Pub_Stock_Actual numeric(18,0),
		Pub_Fecha_Ini datetime,
		Pub_Fecha_Vto datetime,
		Pub_Precio numeric(18,2),
		Pub_Tipo nvarchar(100),
		Pub_Estado nvarchar(255),
		Pub_Visibilidad numeric(18,0) references SQL_O.Visibilidad(Vis_Cod) NOT NULL,
		Pub_Duenio numeric (18,0) references SQL_O.Usuario(UserId) NOT NULL,
		Pub_Permite_Preguntas bit default 1
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
		Pre_Fecha datetime,
		Pre_User numeric(18,0) references SQL_O.Usuario(UserID),
		Pre_Respondida bit default 0
		)
GO

CREATE TABLE SQL_O.Forma_Pago(
	Forma_Pago_Id numeric(18,0) Primary Key identity,
	Forma_Pago_Desc nvarchar(255),
	Forma_Pago_NroTarjeta numeric(16,0),
	FP_Duenio_Tarjeta nvarchar(80),
	FP_Fecha_Venc_Tarj datetime,
	FP_Tipo_Tarjeta nvarchar(30)
	)
GO


CREATE TABLE SQL_O.Factura (
	Factura_Nro numeric(18,0) Primary Key, 
	Factura_Fecha datetime, 
	Factura_Total numeric(18,0) default 0,
	Factura_Forma_Pago numeric(18,0) references SQL_O.Forma_Pago(Forma_Pago_Id),
	Factura_Usuario numeric(18,0) references SQL_O.Usuario(UserId)
	)
GO	

CREATE TABLE SQL_O.Item_Factura (
	Item_Id numeric(18,0) Primary Key Identity,
	Item_Monto numeric(18,2),
	Item_Cantidad numeric(18,0),
	Item_Tipo nvarchar(255),
	Item_Publicacion numeric(18,0) references SQL_O.Publicacion(Pub_Cod),
	Item_Factura numeric(18,0) references SQL_O.Factura(Factura_Nro),
	Item_Rendido bit default 0
	)
GO

CREATE TABLE SQL_O.Compra(
		Compra_Id numeric(18,0) Primary Key identity,
		Compra_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Compra_Fecha datetime,
		Compra_Cantidad numeric(18,0),
		Compra_Comprador numeric(18,0) references SQL_O.Usuario(UserId)
		)
GO

CREATE TABLE SQL_O.Oferta(
		Oferta_Id numeric(18,0) Primary Key identity,
		Oferta_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod),
		Oferta_Fecha datetime,
		Oferta_Monto numeric(18,2),
		Oferta_Cliente numeric(18,0) references SQL_O.Usuario(UserId),
		Oferta_Gano bit default 0
		)
GO

CREATE TABLE SQL_O.Calificacion(
		Cal_Codigo numeric(18,0) Primary Key,
		Cal_Cant_Est numeric(18,0),
		Cal_Desc nvarchar(255),
		Cal_Fecha datetime,
		Cal_Pub numeric(18,0) references SQL_O.Publicacion(Pub_Cod) NOT NULL,
		Cal_User numeric(18,0) references SQL_O.Usuario(UserId)
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
*/
go

-- MIGRACIÓN --
go

--Inserts de rol.
Insert into SQL_O.Rol(Rol_Desc,Rol_Cod) values('Empresa',1)
Insert into SQL_O.Rol(Rol_Desc,Rol_Cod) values('Cliente',2)
Insert into SQL_O.Rol(Rol_Desc,Rol_Cod) values('Admin',3)
GO

--Inserts de funcionalidad.
Insert into SQL_O.Funcionalidad(Func_Desc) values ('ABM de Rol')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Modificación de password')--Todos
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Baja de usuario')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('ABM de Clientes')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Compra de productos')--Cliente
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Venta de productos')--Cliente, Empresa
Insert into SQL_O.Funcionalidad(Func_Desc) values ('ABM de Empresa')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Habilitacion Cliente')
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Habilitaion Empresa')
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Habilitacion Rol')
Insert into SQL_O.Funcionalidad(Func_Desc) values ('ABM de Rubro')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('ABM de Visibilidad')--Administrativo
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Editar publicación')--Cliente,Empresa
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Realizar preguntas')--Cliente
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Responder preguntas')--Cliente,Empresa
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Calificar vendedores')--Cliente
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Conocer historial de publicaciones')--Cliente, Empresa
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Generar facturaciones de compras')--Admin
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Pagar facturaciones pendientes')--Cliente,Empresa
Insert into SQL_O.Funcionalidad(Func_Desc) values ('Obtener Listado estadístico')--Admin
go

--Inserts de funcionalidad por rol.
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (1,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (2,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (2,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (2,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (3,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (4,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (5,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (6,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (6,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (7,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (8,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (9,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (10,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (11,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (12,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (13,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (13,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (14,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (15,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (15,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (16,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (17,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (17,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (18,3)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (19,1)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (19,2)
Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) values (20,3)
go

--Migración tabla Visibilidad.
Insert into SQL_O.Visibilidad(Vis_Cod,Vis_Desc,Vis_Porcentaje,Vis_Precio, Vis_Duracion)
	(select distinct Publicacion_Visibilidad_Cod, 
					 Publicacion_Visibilidad_Desc,
				     Publicacion_Visibilidad_Porcentaje,
				     Publicacion_Visibilidad_Precio,7 
	from gd_esquema.Maestra)
	order by Publicacion_Visibilidad_Cod
GO

--Migración tabla Rubro.	
Insert into SQL_O.Rubro(Rubro_Desc)
	(select distinct Publicacion_Rubro_Descripcion 
		from gd_esquema.Maestra)
GO	

--Migración tabla Tipo, Empresa, Usuario.
Declare 
@razon_social nvarchar(255),
@cuit nvarchar(50),
@fecha_c datetime,
@mail nvarchar(50),
@dom_calle nvarchar(100),
@nro_calle numeric(18,0),
@piso numeric(18,0),
@depto nvarchar(50),
@cod_postal nvarchar(50),
@idemp numeric(18,0)

Declare cursor_Migracion_Emp cursor 
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
Open cursor_Migracion_Emp
fetch cursor_Migracion_Emp into @razon_social, @cuit, @fecha_c, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal

while(@@fetch_status=0)
begin 

set @idemp = (select MAX(UserId)from SQL_O.Usuario)
if (@idemp is null)
	begin
	set @idemp = 1
	end
else 
	begin 
	set @idemp= @idemp +1
	end
	
--userpass es 123456 con sha256
Insert into SQL_O.Tipo(Tipo_Nombre,Tipo_Mail, Tipo_Dom_Calle, Tipo_Nro_Calle, Tipo_Dom_Piso, Tipo_Depto, Tipo_Cod_Postal)
			 values ('Empresa',@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal)

Insert into SQL_O.Empresa(Emp_Cod, Emp_Razon_Social, Emp_Cuit, Emp_Fecha_Creacion) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo), @razon_social, @cuit, @fecha_c)

Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values (('Usuario'+convert(varchar(30),@idemp)),
																'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
																(select MAX(Tipo_Cod) from SQL_O.Tipo))
																
Insert into SQL_O.Usuarios_Por_Rol(UserId,Rol_Cod) values((select Max(UserId) from SQL_O.Usuario),(select Rol_Cod from SQL_O.Rol where Rol_Desc='Empresa'))

fetch cursor_Migracion_Emp into @razon_social, @cuit, @fecha_c, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal
end
close cursor_Migracion_Emp
deallocate cursor_Migracion_Emp
 
GO

--Migración tabla Tipo, Cliente, Usuario.
Declare 
@dni numeric(18,0),
@apellido nvarchar(255),
@nombre nvarchar(255),
@fecha_nac datetime,
@mail nvarchar(255),
@dom_calle nvarchar(255),
@nro_calle numeric(18,0),
@piso numeric(18,0),
@depto nvarchar(50),
@cod_postal nvarchar(50),
@idcli numeric(18,0)

Declare cursor_Migracion_Cli cursor 
     for (select Publ_Cli_Dni,
				Publ_Cli_Apeliido,
				Publ_Cli_Nombre,
				Publ_Cli_Fecha_Nac,
				Publ_Cli_Mail, 
				Publ_Cli_Dom_Calle, 
				Publ_Cli_Nro_Calle,
				Publ_Cli_Piso,
				Publ_Cli_Depto,
				Publ_Cli_Cod_Postal 
		from gd_esquema.Maestra where Publ_Cli_Dni is not null
		union select Cli_Dni,
				Cli_Apeliido,
				Cli_Nombre,
				Cli_Fecha_Nac,
				Cli_Mail, 
				Cli_Dom_Calle, 
				Cli_Nro_Calle,
				Cli_Piso,
				Cli_Depto,
				Cli_Cod_Postal 
		from gd_esquema.Maestra where Cli_Dni is not null)
Open cursor_Migracion_Cli
fetch cursor_Migracion_Cli into @dni, @apellido, @nombre, @fecha_nac, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal
while(@@fetch_status=0)
begin

set @idcli = (select MAX(UserId)from SQL_O.Usuario)
if (@idcli is null)
	begin
	set @idcli = 1
	end
else 
	begin 
	set @idcli= @idcli +1
	end


Insert into SQL_O.Tipo(Tipo_Nombre, Tipo_Mail, Tipo_Dom_Calle, Tipo_Nro_Calle, Tipo_Dom_Piso, Tipo_Depto, Tipo_Cod_Postal) 
			values ('Cliente',@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal)

			
Insert into SQL_O.Cliente(Cli_Id, Cli_NroDoc, Cli_Apellido, Cli_Nombre,Cli_Fecha_Nac,Cli_TipoDoc) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo), @dni, @apellido, @nombre,@fecha_nac,'DNI')


Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values ('Usuario'+CONVERT(varchar(30),@idcli),
															   '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
															   (select MAX(Tipo_Cod) from SQL_O.Tipo))

Insert into SQL_O.Usuarios_Por_Rol(UserId,Rol_Cod) values ((select MAX(UserId) from SQL_O.Usuario),(select Rol_Cod from SQL_O.Rol where Rol_Desc='Cliente'))

fetch cursor_Migracion_Cli into @dni, @apellido, @nombre, @fecha_nac, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal

end
close cursor_Migracion_Cli
deallocate cursor_Migracion_Cli
 
GO

--Migración tabla Publicación, Pub_Por_Rubro.
Declare 
@cod numeric(18,0),
@desc nvarchar(255),
@stock numeric(18,0),
@fecha_ini datetime,
@fecha_vto datetime,
@precio numeric(18,2),
@tipo nvarchar(255),
@visibilidad_cod numeric(18,2),
@estado nvarchar(255),
@duenio numeric(18,0),
@dni_cliente numeric(18,0),
@cuit_empresa nvarchar(50),
@rubro nvarchar (255)

Declare cursor_Migracion_Pub cursor 
     for (select distinct Publicacion_Cod,
						  Publicacion_Descripcion,
						  Publicacion_Stock,
						  Publicacion_Fecha,
						  Publicacion_Fecha_Venc,
						  Publicacion_Precio,
						  Publicacion_Tipo,
						  Publicacion_Estado,
						  Publ_Empresa_Cuit,
						  Publ_Cli_Dni,
						  Publicacion_Visibilidad_Cod,
						  Publicacion_Rubro_Descripcion					  
						  
		from gd_esquema.Maestra 
		where Publicacion_Cod is not null )
		order by Publicacion_Cod asc
		
		
Open cursor_Migracion_Pub
fetch cursor_Migracion_Pub into @cod, @desc, @stock, @fecha_ini, @fecha_vto, @precio,
							@tipo, @estado,@cuit_empresa,@dni_cliente,@visibilidad_cod,@rubro
while(@@fetch_status=0)
begin



if(@dni_cliente is not null) 
	begin
	set @duenio  = (select UserId from SQL_O.Cliente,SQL_O.Tipo,SQL_O.Usuario where @dni_cliente = Cli_NroDoc and Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	end
else
	begin
	set @duenio  = (select UserId from SQL_O.Empresa,SQL_O.Tipo,SQL_O.Usuario where @cuit_empresa = Emp_Cuit and Emp_Cod=Tipo_Cod and User_Tipo=Tipo_Cod)
	end
	

declare @unidades_vendidas numeric(18,0)
set @unidades_vendidas=0

if(@tipo='Compra Inmediata')
	begin
		set @unidades_vendidas= isnull((select SUM(Compra_Cantidad) from SQL_O.Compra where Compra_Pub=@cod),0)	
	end

Insert into SQL_O.Publicacion(Pub_Cod,Pub_Desc,Pub_Stock_Actual, Pub_Stock_Inicial,Pub_Fecha_Ini,Pub_Fecha_Vto,Pub_Precio,Pub_Tipo
							,Pub_Estado,Pub_Duenio,Pub_Visibilidad)
			values(@cod, @desc, @stock-@unidades_vendidas, @stock, @fecha_ini, @fecha_vto, @precio,@tipo,'Finalizada',@duenio,@visibilidad_cod)

Insert into SQL_O.Pub_Por_Rubro(Pub_Cod,Rubro_Cod)
			values(@cod,(select Rubro_Cod from SQL_O.Rubro where @rubro=Rubro_Desc))

fetch cursor_Migracion_Pub into @cod, @desc, @stock, @fecha_ini, @fecha_vto, @precio,
							@tipo, @estado,@cuit_empresa,@dni_cliente,@visibilidad_cod,@rubro
end
close cursor_Migracion_Pub
deallocate cursor_Migracion_Pub
 
GO

--Migración tabla Compra.
insert into SQL_O.Compra(Compra_Pub,Compra_Fecha,Compra_Cantidad,Compra_Comprador)
	(select distinct Publicacion_Cod,
					 Compra_Fecha,
					 Compra_Cantidad,
					 (select UserId from SQL_O.Cliente c,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni = c.Cli_NroDoc and c.Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	from gd_esquema.Maestra where Compra_Fecha is not null)
	
GO

--Insert Admin
Insert into SQL_O.Tipo(Tipo_Nombre,Tipo_Mail, Tipo_Dom_Calle, Tipo_Nro_Calle, Tipo_Dom_Piso, Tipo_Depto, Tipo_Cod_Postal, Tipo_Tel) 
			values ('Admin','sql_o_rulz@gmail.com', 'Medrano','951', 4, 'O','0007',47777777)

Declare @date date = '12-03-1985'
Declare @datetime datetime = @date
Insert into SQL_O.Administrativo(Admin_Id, Admin_NroDoc, Admin_Apellido, Admin_Nombre,Admin_Fecha_Nac) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo), '77777777','Horsehead Bond','James',@datetime)

Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values ('superAdmin','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',(select MAX(Tipo_Cod) from SQL_O.Tipo))

Insert into SQL_O.Usuarios_Por_Rol(UserId,Rol_Cod) values ((select MAX(UserId) from SQL_O.Usuario),(select Rol_Cod from SQL_O.Rol where Rol_Desc='Admin'))

GO

--Migración tabla Calificación.
insert into SQL_O.Calificacion(Cal_Codigo,Cal_Cant_Est,Cal_Desc,Cal_Pub,Cal_User,Cal_Fecha)
	(select distinct Calificacion_Codigo,
					 Calificacion_Cant_Estrellas, 
					 Calificacion_Descripcion,
					 Publicacion_Cod,
					 (select UserId from SQL_O.Cliente,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni=Cli_NroDoc and Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod),
					 Compra_Fecha
	 from gd_esquema.Maestra where Calificacion_Codigo is not null)
	 order by Calificacion_Codigo
	 
GO

--Migración tabla Factura.

Declare 
@fact_nro numeric(18,0),
@fact_fecha datetime,
@fact_total numeric(18,0),
@forma_pago nvarchar(255),
@fact_duenio numeric(18,0)

Declare cursor_Migracion_Factura cursor 
     for (select distinct Factura_Nro,
					Factura_Fecha,
					Factura_Total,
					Forma_Pago_Desc,
					(select Pub_Duenio from SQL_O.Publicacion where Pub_Cod = Publicacion_Cod)
	from gd_esquema.Maestra where Factura_Nro is not null)
	order by Factura_Nro
Open cursor_Migracion_Factura
fetch cursor_Migracion_Factura into @fact_nro, @fact_fecha , @fact_total, @forma_pago, @fact_duenio
while(@@fetch_status=0)
begin
     
     insert into SQL_O.Forma_Pago(Forma_Pago_Desc) values(@forma_pago)
     
     insert into SQL_O.Factura (Factura_Nro,Factura_Fecha,Factura_Total,Factura_Forma_Pago,Factura_Usuario)
			values(@fact_nro,@fact_fecha,@fact_total,(select MAX(Forma_Pago_Id) from SQL_O.Forma_Pago),@fact_duenio)


fetch cursor_Migracion_Factura into @fact_nro, @fact_fecha , @fact_total, @forma_pago, @fact_duenio
							
end
close cursor_Migracion_Factura
deallocate cursor_Migracion_Factura
 
GO

--Migración tabla Item_Factura.
insert into SQL_O.Item_Factura(Item_Cantidad,Item_Factura,Item_Monto,Item_Publicacion, Item_Rendido)
	(select Item_Factura_Cantidad,
			Factura_Nro,
			Item_Factura_Monto,
			Publicacion_Cod, 
			1
	from gd_esquema.Maestra where Item_Factura_Cantidad is not null)

GO


--Migración tabla Oferta.
insert into SQL_O.Oferta(Oferta_Pub,Oferta_Fecha,Oferta_Monto,Oferta_Cliente)
	(select distinct Publicacion_Cod,
					 Oferta_Fecha,
					 Oferta_Monto,
					 (select UserId from SQL_O.Cliente c,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni = c.Cli_NroDoc and c.Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	from gd_esquema.Maestra where Oferta_Fecha is not null)
	
GO

-- STORE PROCEDURES --
GO

-- Terminar las subastas de migracion y setear ganador

create procedure SQL_O.actualizar_subastas
as 
begin 

	update SQL_O.Publicacion
	set Pub_Estado='Finalizada'
	where Pub_Tipo='Subasta' and
	exists(select Compra_Pub from SQL_O.Compra where Compra_Pub=Pub_Cod)
	
	update SQL_O.Oferta set Oferta_Gano = 1
	where (select p.Pub_Estado 
		   from Publicacion p 
		   where Oferta_Pub = p.Pub_Cod
		   and 	Oferta_Id = (select TOP 1 o2.Oferta_Id 
							from Oferta o2 
							where o2.Oferta_Pub = p.Pub_Cod
							order by o2.Oferta_Fecha Desc)) = 'Finalizada'	   
end
GO
exec SQL_O.actualizar_subastas
GO


-- Setear reputación (la reputacion es el promedio entre total de estrellas recibidas y operaciones realizadas- entiendo  como operaciones realizadas a las ventas que tuvo+las subastas terminadas-)
create procedure SQL_O.setear_reputacion
as
	begin
	
	update SQL_O.Cliente
	set Cli_Reputacion= convert(numeric(18,0), --el convert porque la division devuelve una especie de float
	
		((select SUM(Cal_Cant_Est) from SQL_O.Calificacion,SQL_O.Publicacion,SQL_O.Usuario
		where Cal_Pub=Pub_Cod and Pub_Duenio=UserId and Cli_Id=User_Tipo) -- suma total de estrellas de ese cliente
		
		
		+(select Count(Compra_Id) from SQL_O.Compra,SQL_O.Publicacion,SQL_O.Usuario
		where Compra_Pub=Pub_Cod and Pub_Duenio=UserId and Cli_Id=User_Tipo)
		
		+(select Count(Oferta_Id) from SQL_O.Oferta,SQL_O.Publicacion,SQL_O.Usuario
		where Oferta_Pub=Pub_Cod and Pub_Duenio=UserId and Cli_Id=User_Tipo and Oferta_Gano=1))/2)

	
	update SQL_O.Empresa
	set Emp_Reputacion= convert(numeric(18,0),
	
		((select SUM(Cal_Cant_Est) from SQL_O.Calificacion,SQL_O.Publicacion,SQL_O.Usuario
		where Cal_Pub=Pub_Cod and Pub_Duenio=UserId and Emp_Cod=User_Tipo) -- suma total de estrellas de esa empresa
		
		
		+(select Count(Compra_Id) from SQL_O.Compra,SQL_O.Publicacion,SQL_O.Usuario
		where Compra_Pub=Pub_Cod and Pub_Duenio=UserId and Emp_Cod=User_Tipo)
		
		+(select Count(Oferta_Id) from SQL_O.Oferta,SQL_O.Publicacion,SQL_O.Usuario
		where Oferta_Pub=Pub_Cod and Pub_Duenio=UserId and Emp_Cod=User_Tipo and Oferta_Gano=1))/2)
	
	end
go
exec SQL_O.setear_reputacion
GO


-- Actualizar reputacion (se supone que cada vez que se califica a alguien se debe actualizar la reputacion de ese alguien)
create procedure SQL_O.actualizar_reputacion @tipo numeric(18,0), @bit bit -- el bit es para saber si es cliente o empresa
as 
	begin
		if(@bit=0)
			begin
				update SQL_O.Cliente
				set Cli_Reputacion= convert(numeric(18,0),
		
									((select SUM(Cal_Cant_Est) from SQL_O.Calificacion,SQL_O.Publicacion,SQL_O.Usuario
									where Cal_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo) 
									
									
									+(select Count(Compra_Id) from SQL_O.Compra,SQL_O.Publicacion,SQL_O.Usuario
									where Compra_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo)
									
									+(select Count(Oferta_Id) from SQL_O.Oferta,SQL_O.Publicacion,SQL_O.Usuario
									where Oferta_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo and Oferta_Gano=1))/2)
				where Cli_Id=@tipo
			end 
		else
			update SQL_O.Empresa
			set Emp_Reputacion= convert(numeric(18,0),
	
								((select SUM(Cal_Cant_Est) from SQL_O.Calificacion,SQL_O.Publicacion,SQL_O.Usuario
								where Cal_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo)
								
								
								+(select Count(Compra_Id) from SQL_O.Compra,SQL_O.Publicacion,SQL_O.Usuario
								where Compra_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo)
								
								+(select Count(Oferta_Id) from SQL_O.Oferta,SQL_O.Publicacion,SQL_O.Usuario
								where Oferta_Pub=Pub_Cod and Pub_Duenio=UserId and @tipo=User_Tipo and Oferta_Gano=1))/2)	
			where Emp_Cod=@tipo
			
	end

GO


--Login. //corregido//

create Procedure SQL_O.proc_login @usuario varchar(30),@userpass nvarchar(255),@return numeric(1,0) out
as 
begin
set @return=0 --El usuario ingresa correctamente
if exists (select Username from SQL_O.Usuario where Username=@usuario and Userpass=@userpass)
	begin 
	update SQL_O.Usuario set User_Intentos = 0
	where Username = @usuario;
	declare @deshabilitado bit
	declare @baja bit
	set @deshabilitado = (select User_Deshabilitado from SQL_O.Usuario where @usuario=Username)
	set @baja = (select User_Baja from SQL_O.Usuario where @usuario=Username)
		if (@deshabilitado=1)
		begin
		   raiserror('El usuario esta deshabilitado.',16,1)	
		   set @return=1 --El usuario no ingresa por estar deshabilitado
		   return
		end
		else
			if(@baja=1)
			begin
				raiserror('El usuario esta dado de baja.',16,1)
				set @return=2 --El usuario no ingresa por estar dado de baja
				return
			end
	end
else
	begin
		if exists (select Username from SQL_O.Usuario where Username=@usuario and Userpass!=@userpass)
		begin
			if((select User_Intentos from SQL_O.Usuario where @usuario = Username) = 2)
			begin
				
				raiserror('La contraseña ingresada no es correcta y el usuario quedo inhabilitado',16,1)
				update SQL_O.Usuario set User_Deshabilitado = 1
				where Username = @usuario
				set @return = 1
			end
			else
			begin
				update SQL_O.Usuario set User_Intentos = User_Intentos + 1
				where Username = @usuario;
				raiserror('La contraseña ingresada no es correcta.',16,1)
				set @return = 3 --El usuario no ingresa por ingresar una contraseña incorrecta
				return
			end
		end
		else
		begin
			raiserror ('El usuario no existe.',16,1)
			set @return = 4 --El usuario no existe
		end
	end
end

GO

-- Generar usuario. (CORREGIDO) revisado
create procedure SQL_O.generar_usuario @nombreUsuario nvarchar(30) out, @pass nvarchar(255) out
as
begin 
	declare @id numeric(18,0)
	set @id = (select MAX(UserId) from SQL_O.Usuario)+1
	set @nombreUsuario = 'Usuario'+CONVERT(varchar(30),@id)
	set @pass = '123456'
	insert into SQL_O.Usuario(Username,Userpass)
		values(@nombreUsuario ,'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
		
end 
GO


-- Crear Item Factura

create procedure SQL_O.crear_item @pub_cod numeric(18,0), @cantidad numeric(18,0), @tipo nvarchar(255)
as
begin transaction
	declare @monto numeric(18,2)
	
	if(@tipo = 'Publicacion')
	begin
		if((select COUNT(i.Item_Id)
				from SQL_O.Publicacion p, SQL_O.Item_Factura i 
				where i.Item_Publicacion = p.Pub_Cod
				and i.Item_Tipo = 'Publicacion'
				and p.Pub_Visibilidad =(select p3.Pub_Visibilidad
										from SQL_O.Publicacion p3 
										where p3.Pub_Cod = @pub_cod
				and p.Pub_Duenio = (select p2.Pub_Duenio
									from SQL_O.Publicacion p2 
									where p2.Pub_Cod = @pub_cod)) % 10)=0)
		begin
			set @monto = 0
		end
		else
		begin
			set @monto = (select v.Vis_Precio from SQL_O.Visibilidad v, SQL_O.Publicacion p where p.Pub_Cod = @pub_cod and p.Pub_Visibilidad = v.Vis_Cod) 
		end
	end
	else
	begin
		set @monto = (select (v.Vis_Porcentaje * p4.Pub_Precio)/100 from SQL_O.Visibilidad v, SQL_O.Publicacion p4 where p4.Pub_Cod = @pub_cod and p4.Pub_Visibilidad = v.Vis_Cod)
	end
	
	Insert into SQL_O.Item_Factura(Item_Monto,Item_Cantidad,Item_Publicacion) 
	values (@monto,@cantidad,@pub_cod)
	
commit
GO


-- Crear Publicación. //corregido//
create procedure SQL_O.alta_publicacion @descripcion nvarchar(255), @stock numeric(18,0),
										@precio numeric(18,2), @tipo nvarchar(255), 
										@estado varchar(255),@visibilidad nvarchar(255), @duenio varchar(30),
										@admite_preguntas bit,@fecha nvarchar(8), @return numeric(1,0) out
										
as
begin transaction	

	declare @fecha_real datetime
	set @fecha_real = @fecha
	set @return = 0
	if( @stock < 1) 
	begin
		rollback
		raiserror('No se puede tener un stock menor a 1(uno)',16,1)
		set @return = 1
	end

	if( @tipo = 'Subasta' and @stock > 1) 
	begin
		rollback
		raiserror('En Subastas el stock máximo permitido es 1',16,1)
		set @return = 2
	end
	
	if(@visibilidad = 'Gratis' and 
	  ((select COUNT(p.Pub_Cod) 
	    from SQL_O.Publicacion p, SQL_O.Usuario u, SQL_O.Visibilidad v
	    where p.Pub_Visibilidad = v.Vis_Cod
	      and v.Vis_Desc = 'Gratis'
	      and u.Username = @duenio
	      and p.Pub_Duenio = u.UserId
	      and p.Pub_Estado = 'Publicada')>=3))
	begin
		rollback
		raiserror('No se pueden tener más de 3 publicaciones gratuitas al mismo tiempo',16,1)
		set @return = 3
	end
											
	declare @codigo numeric(18,0)
	set @codigo = (select Max(Pub_Cod) from SQL_O.Publicacion) + 1
	
	Insert into SQL_O.Publicacion(Pub_Cod, Pub_Desc, Pub_Stock_Inicial, Pub_Stock_Actual, Pub_Fecha_Ini, Pub_Fecha_Vto, Pub_Precio, Pub_Tipo,
								  Pub_Estado,Pub_Visibilidad, Pub_Duenio,Pub_Permite_Preguntas)
			values (@codigo , @descripcion, @stock, @stock, @fecha_real, 
			 @fecha_real + (select Vis_Duracion from SQL_O.Visibilidad where @visibilidad = Vis_Desc), 
			@precio,@tipo, @estado, (select Vis_Cod from SQL_O.Visibilidad where @visibilidad = Vis_Desc),
		    (select UserId from SQL_O.Usuario where @duenio = Username),@admite_preguntas)
commit 

GO		

-- Editar Publicacion
create procedure SQL_O.editar_publicacion @nro_pub numeric(18,0),@estado nvarchar(255), @descripcion nvarchar(255),
										  @stock numeric(18,0), @precio numeric(18,2), @visibilidad nvarchar(255),
										  @duenio nvarchar(30), @permite_preg bit, @fecha nvarchar(8), @return numeric(1,0) out
as
begin transaction
	declare @vis_cod numeric(18,0)
	declare @duenio_cod numeric(18,0)
	declare @fecha_real datetime
	set @fecha_real=@fecha
	set @return = 0
	set @vis_cod = (select Vis_Cod from SQL_O.Visibilidad where Vis_Desc = @visibilidad)
	set @duenio_cod = (select UserId from SQL_O.Usuario where Username = @duenio)
	if(exists(select Pub_Cod
			  from SQL_O.Publicacion 
			  where @nro_pub = Pub_Cod
			    and Pub_Estado = 'Publicada'
			    and (@precio != Pub_Precio 
			         or @vis_cod != Pub_Visibilidad 
			         or @permite_preg != Pub_Permite_Preguntas
			         or @estado = 'Borrador'
			         or @fecha_real!=Pub_Fecha_Ini)))
	begin 
		rollback
		raiserror('No puedo cambiar esos campos en una publicacion Activa',16,1)
		set @return = 1
		return
	end	
	
	if((select Pub_Stock_Actual 
		from SQL_O.Publicacion
		where @nro_pub = Pub_Cod
		  and Pub_Estado = 'Publicada'
		  and Pub_Tipo = 'Compra Inmediata') > @stock)
	begin 
		rollback
		raiserror('No se puede decrementar el stock',16,1)
		set @return = 2
		return
	end
	
	if(exists(select Pub_Cod 
	          from SQL_O.Publicacion 
	          where @nro_pub = Pub_Cod
	            and Pub_Tipo = 'Subasta'
	            and Pub_Estado = 'Publicada'
	            and @stock != Pub_Stock_Actual))
	begin 
		rollback
		raiserror('No se puede cambiar el stock de una subasta',16,1)
		set @return = 3
		return
	end	
	
	if(exists(select Pub_Cod 
	          from SQL_O.Publicacion 
	          where @nro_pub = Pub_Cod
	            and Pub_Tipo = 'Subasta'
	            and Pub_Estado = 'Publicada'
	            and @estado = 'Pausada'))
	begin 
		rollback
		raiserror('No se pueden pausar las subastas a menos que qede inhabilitado el usuario',16,1)
		set @return = 4
		return
	end		
	
	if(exists(select Pub_Cod
			  from SQL_O.Publicacion 
			  where @nro_pub = Pub_Cod
			    and Pub_Estado = 'Pausada'
			    and (@precio != Pub_Precio 
				  or @stock != Pub_Stock_Actual
			      or @vis_cod != Pub_Visibilidad 
			      or @permite_preg != Pub_Permite_Preguntas
			      or @descripcion != Pub_Desc
			      or @estado != 'Publicada'
			      or @fecha_real!=Pub_Fecha_Ini)))
	begin 
		rollback
		raiserror('No puedo cambiar esos campos en una publicacion Pausada',16,1)
		set @return = 5
		return
	end
	
	if(exists(select Pub_Cod
			  from SQL_O.Publicacion 
			  where @nro_pub = Pub_Cod
			    and Pub_Estado = 'Finalizada'
			    and (@precio != Pub_Precio 
				  or @stock != Pub_Stock_Actual
			      or @vis_cod != Pub_Visibilidad 
			      or @permite_preg != Pub_Permite_Preguntas
			      or @descripcion != Pub_Desc
			      or @estado != Pub_Estado
			      or @fecha_real!=Pub_Fecha_Ini)))
	begin 
		rollback
		raiserror('No puedo cambiar esos campos en una publicacion Finalizada',16,1)
		set @return = 6
		return
	end
	
	if(exists(select Pub_Cod
			  from SQL_O.Publicacion 
			  where @nro_pub = Pub_Cod
			    and Pub_Estado = 'Borrador'
			    and @estado = 'Publicada'
			    and @fecha_real!=Pub_Fecha_Ini ))
	begin 
		rollback
		raiserror('Se debe actualizar la fecha al cambiar de estado Borrador a Publicada',16,1)
		set @return = 7
		return
	end
	
	update SQL_O.Publicacion
	set Pub_Desc = @descripcion,
	    Pub_Estado = @estado,
	    Pub_Permite_Preguntas = @permite_preg,
	    Pub_Precio = @precio,
	    Pub_Stock_Actual = @stock,
	    Pub_Visibilidad = @vis_cod,
	    Pub_Fecha_Ini=@fecha_real,
	    Pub_Fecha_Vto = Pub_Fecha_Ini + (select Vis_Duracion from SQL_O.Visibilidad where @vis_cod = Vis_Cod)
	where Pub_Cod = @nro_pub
commit	
GO

-- Agregar Rubro a Publicacion

create procedure SQL_O.agregar_rubro @pub_cod numeric(18,0), @rubro nvarchar(255)
as
begin transaction
	if(not(exists(select Rubro_Cod from SQL_O.Rubro where Rubro_Desc = @rubro)))
	begin
		rollback
		raiserror('El rubro no existe',16,1)
		return
	end
	
	Insert into SQL_O.Pub_Por_Rubro(Rubro_Cod,Pub_Cod) 
	values ((select Rubro_Cod from SQL_O.Rubro where Rubro_Desc = @rubro),@pub_cod)
	
commit
GO

-- Alta Cliente. //corregido//
create procedure SQL_O.alta_cliente @nrodoc numeric(18,0),@tipodoc nvarchar(20),@apellido nvarchar(255),@nombre nvarchar(255),
							  @cuil nvarchar(50),@fecha_nac datetime,@mail nvarchar(50),@tel numeric(18,0),
							  @calle nvarchar(100),@nrocalle numeric(18,0), @piso numeric(18,0),
							  @depto nvarchar(50),@codpost nvarchar(50), @usuario nvarchar(30),
							  @return numeric(1,0)
							  
as 
begin transaction
set @return = 0
		if exists(select Cli_NroDoc from SQL_O.Cliente where Cli_NroDoc=@nrodoc and Cli_TipoDoc=@tipodoc)
			begin
				rollback
				raiserror('El Numero y Tipo de Documento ya existe.',16,1)
				set @return = 1 --DNI ya existente
			end
		else 
			begin
				if exists(select Cli_Cuil from SQL_O.Cliente where Cli_Cuil=@cuil)
					begin
						rollback
						raiserror('El Cuil ingresado ya existe.',16,1)
						set @return = 2 --Cuil ya existente
					end
				else
					begin
						if exists(select Datos_Tel from SQL_O.Cliente,SQL_O.Datos_Pers where Cli_Id=Datos_Id and Datos_Tel=@tel)
							begin
								 rollback
								 raiserror('El Nro de telefono ingresado ya existe.',16,1)
								 set @return = 3 --Telefono ya existente
							end
					end
			 end
			 
		Insert into SQL_O.Tipo(Tipo_Nombre, Tipo_Mail, Tipo_Dom_Calle, Tipo_Nro_Calle, Tipo_Dom_Piso, Tipo_Depto, Tipo_Cod_Postal,Tipo_Tel) 
				values ('Cliente', @mail, @calle, @nrocalle, @piso, @depto, @codpost,@tel)
		
		update SQL_O.Usuario 
			set User_Tipo=(select max(Tipo_Cod) from SQL_O.Tipo)
				where Username=@usuario
		
		Insert into SQL_O.Cliente(Cli_Id,Cli_Datos_Pers ,Cli_NroDoc, Cli_Apellido, Cli_Nombre,Cli_Fecha_Nac,Cli_TipoDoc,Cli_Cuil) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @nrodoc, @apellido, @nombre,@fecha_nac,@tipodoc,@cuil)
		
		Insert into SQL_O.Usuarios_Por_Rol(UserId,Rol_Cod) values ((select UserId from SQL_O.Usuario where Username=@usuario),(select Rol_Cod from SQL_O.Rol where Rol_Desc='Cliente'))

commit

GO

-- Alta Empresa. //corregido//
create procedure SQL_O.alta_empresa @razon_social nvarchar(255), @cuit nvarchar(50), @fecha_c datetime,
								    @contacto nvarchar(50),@mail nvarchar(50), @dom_calle nvarchar(100),
								    @nro_calle numeric(18,0), @piso numeric(18,0), @depto nvarchar(50),
								    @tel numeric(18,0), @cod_postal nvarchar(50),@usuario nvarchar(30),
								    @return numeric (1,0) out
as 
begin transaction

set @return = 0

		if exists(select Emp_Razon_Social from SQL_O.Empresa  where Emp_Razon_Social=@razon_social)
			begin
				rollback
				raiserror('La razon social ya existe o no es valida.',16,1)				
				set @return = 1 --Razon Social ya existente
			end
		else 
			begin
				if exists(select Emp_Cuit from SQL_O.Empresa where Emp_Cuit=@cuit)
					begin
						rollback
						raiserror('El Cuit ingresado ya existe.',16,1)
						set @return = 2 --CUIT ya existente
					end
				else
					begin
						if exists(select Datos_Tel from SQL_O.Empresa,SQL_O.Datos_Pers where Emp_Cod=Datos_Id and Datos_Tel=@tel)
							begin
								 rollback
								 raiserror('El Nro de telefono ingresado ya existe.',16,1)
								 set @return = 3 --Nro de telefono ya existente
							end
					end
			 end
		
		Insert into SQL_O.Tipo(Tipo_Nombre, Tipo_Mail, Tipo_Dom_Calle, Tipo_Nro_Calle, Tipo_Dom_Piso, Tipo_Depto, Tipo_Cod_Postal, Tipo_Tel) 
				values ('Empresa', @mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal,@tel)
	 
		Insert into SQL_O.Empresa(Emp_Cod,Emp_Datos_Pers,Emp_Razon_Social, Emp_Cuit,Emp_Fecha_Creacion,Emp_Contacto) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @razon_social,@cuit,@fecha_c,@contacto)
		
		Insert into SQL_O.Usuarios_Por_Rol(UserId,Rol_Cod) values ((select UserId from SQL_O.Usuario where Username=@usuario),(select Rol_Cod from SQL_O.Rol where Rol_Desc='Empresa'))

commit

GO 

-- Alta de visibilidad.(CORREGIDO) //revisado//

create procedure SQL_O.alta_visibilidad @descripcion nvarchar(255), @duracion numeric(18,0),
										 @precio numeric(18,2), @porcentaje numeric(18,2)
										 
as
begin transaction
	if exists(select Vis_Desc from SQL_O.Visibilidad where Vis_Desc = @descripcion)
		begin
			rollback
			raiserror('La visibilidad ya existe',16,1)
		end
		
	Insert into SQL_O.Visibilidad(Vis_Cod,Vis_Desc,Vis_Duracion,Vis_Precio,Vis_Porcentaje) 
	values((select Max(Vis_Cod) from SQL_O.Visibilidad)+1 ,@descripcion,@duracion,@precio,@porcentaje)
	
commit
GO

-- Alta de rol.

create procedure SQL_O.alta_rol @rol nvarchar(255)

as
begin transaction
	if exists(select Rol_Desc from SQL_O.Rol where Rol_Desc = @rol)
		begin
			rollback
			raiserror('El rol ya existe',16,1)
		end
		
	Insert into SQL_O.Rol(Rol_Desc) values (@rol)
commit
GO

-- Alta de funcionalidad por rol.

create procedure  SQL_O.alta_funcionalidad_por_rol @funcionalidad nvarchar(255) , @rol nvarchar(255)
as
begin transaction
	
	if ((select r.Rol_baja from SQL_O.Rol r where r.Rol_Desc = @rol) = 1)
		begin
			rollback
			raiserror('El rol está dado de baja',16,1)
		end
		
	if(not(exists(select Func_Cod from SQL_O.Funcionalidad where @funcionalidad = Func_Desc)))
	begin 
		Insert into SQL_O.Funcionalidad(Func_Desc) values (@funcionalidad)
	end
	
	Insert into SQL_O.Func_Por_Rol(Func_Cod,Rol_Cod) 
	values ((select f.Func_Cod from SQL_O.Funcionalidad f where f.Func_Desc = @funcionalidad),
	        (select r.Rol_Cod from SQL_O.Rol r where r.Rol_Desc = @rol))

commit
GO

-- Calificar 

create procedure SQL_O.calificar @pub_cod numeric(18,0), @usuario varchar(30), @cant_estrellas numeric(18,0),
								 @des nvarchar(255), @fecha nvarchar(8), @return numeric (1,0)
as 
	begin transaction
	declare @userid numeric(18,0)
	set @userid = (select UserId from SQL_O.Usuario where Username=@usuario)
	set @return=0
	declare @fecha_real datetime
	set @fecha_real= @fecha
	declare @tipo nvarchar(100)
	declare @estado nvarchar(255)
	declare @ganador_subasta numeric(18,0)
		
	set @tipo=(select Pub_Tipo from SQL_O.Publicacion where Pub_Cod=@pub_cod)
	set @estado=(select Pub_Estado from SQL_O.Publicacion where Pub_Cod=@pub_cod)
	set @ganador_subasta = (select Oferta_Cliente from SQL_O.Oferta where Oferta_Pub=@pub_cod and Oferta_Gano=1)
	
	if ( (@tipo='Subasta' and @estado!='Finalizada') or (@tipo='Subasta' and @estado='Finalizada' and @ganador_subasta!=@userid) )
		 begin
			  rollback
			  raiserror('La subasta no esta finalizada o el usuario no es el ganador.',16,1)
			  set @return=1
			  return		 
		 end
	
	
	if (@cant_estrellas not between 0 and 10)
		begin
			rollback
			raiserror('La cantidad de estrellas debe estar entre 0 y 10',16,1)
			set @return=2
			return
		end
	else
	insert into SQL_O.Calificacion(Cal_Codigo,Cal_Cant_Est,Cal_Desc,Cal_Pub,Cal_User,Cal_Fecha)
			values( (select MAX(Cal_Codigo) from SQL_O.Calificacion)+1,
					@cant_estrellas, @des, @pub_cod, @userid,@fecha_real)
	
	declare @tipo_duenio numeric(18,0)
	set @tipo_duenio = (select User_Tipo from SQL_O.Publicacion,SQL_O.Usuario where Pub_Cod=@pub_cod and Pub_Duenio=UserId)
	
	declare @bit bit
	if(exists(select Cli_Id from SQL_O.Cliente where Cli_Id=@tipo_duenio))
		begin
		set @bit =0
		end
	else
		if(exists(select Emp_Cod from SQL_O.Empresa where Emp_Cod=@tipo_duenio))
			begin
			set @bit=1
			end
	exec SQL_O.actualizar_reputacion @tipo=@tipo_duenio, @bit=@bit
	
commit
GO

-- Generar Oferta

create procedure SQL_O.generar_oferta @pub_cod numeric(18,0), @usuario varchar(30),@monto numeric(18,2), @fecha nvarchar(8)
as
	begin transaction
	declare @userid numeric(18,0)
	declare @fecha_real datetime
	set @fecha_real = @fecha
	set @userid = (select UserId from SQL_O.Usuario where Username=@usuario)
	if((select Pub_Estado from SQL_O.Publicacion where Pub_Cod = @pub_cod)='Publicada')
	begin
		if((select u.Username 
			from SQL_O.Publicacion p, SQL_O.Usuario u 
			where p.Pub_Duenio = u.UserId and p.Pub_Cod = @pub_cod)=@usuario)
		begin
			rollback
			raiserror('Un usuario no puede ofertar en su publicacion',16,1)
		end
		
			if( @monto=FLOOR(@monto) and @monto> (select top 1 Oferta_Monto from SQL_O.Oferta where Oferta_Pub=@pub_cod
							order by Oferta_Fecha desc) )
				begin
					 insert into SQL_O.Oferta(Oferta_Pub,Oferta_Fecha,Oferta_Monto,Oferta_Cliente)
							values (@pub_cod,@fecha_real, @monto, @userid) 
				end
			else
			begin
				rollback
				raiserror('El monto debe ser entero y mayor a la ultima oferta.',16,1)
				return
			end
	end
	else 
	begin
		rollback
		raiserror('No se puede ofertar en un publicacion que no está activa',16,1)
		return
	end		
			
			
commit
GO

-- Inhabilitar Usuario 

create procedure SQL_O.inhabilitar_usuario @user varchar(30)
as
begin transaction
	
	update SQL_O.Usuario
	set User_Deshabilitado = 1
	where @user = Username
	
	update SQL_O.Publicacion
	set Pub_Estado = 'Pausada'
	where Pub_Duenio = (select UserId from SQL_O.Usuario where Username = @user)
	
commit
GO

-- Finalizar subasta

create procedure SQL_O.finalizar_subasta @pub_cod numeric(18,0)
as 
begin transaction
	 
	 declare @user_id numeric(18,0)
	 declare @usuario varchar(30)
	 
	 set @user_id = (select Pub_Duenio from SQL_O.Publicacion where Pub_Cod = @pub_cod)
	 set @usuario = (select Username from SQL_O.Usuario where UserId = @user_id)
	 
	 if( (select Pub_Tipo from SQL_O.Publicacion where Pub_Cod=@pub_cod)!='Subasta')
		begin
			 rollback
			 raiserror('La publicacion no es una subasta.',16,1)
			 return
		
		end
	
	if( (select Pub_Estado from SQL_O.Publicacion where Pub_Cod=@pub_cod)!='Publicada')
		begin
			 rollback
			 raiserror('No se puede finalizar una subasta que no este publicada.',16,1)
			 return
		
		end	
	 
	 
	 update SQL_O.Publicacion
	 set Pub_Estado='Finalizada'
	 where Pub_Cod=@pub_cod
		
	 declare @id_oferta numeric(18,0)
	 set @id_oferta=(select top 1 Oferta_Id from SQL_O.Oferta where Oferta_Pub=@pub_cod
							order by Oferta_Fecha desc)
	
	 update SQL_O.Oferta
	 set Oferta_Gano=1
	 where Oferta_Id=@id_oferta

	 
	 exec SQL_O.crear_item @pub_cod = @pub_cod, @cantidad = 1, @tipo = 'Publicacion'
	 exec SQL_O.crear_item @pub_cod = @pub_cod, @cantidad = 1, @tipo = 'Subasta'
	 
	 if((select COUNT(i.Item_Id)
	     from SQL_O.Item_Factura i, SQL_O.Publicacion p 
		 where i.Item_Rendido = 0 
		   and i.Item_Tipo in ('Venta Inmediata','Subasta')
		   and i.Item_Publicacion = p.Pub_Cod
		   and p.Pub_Duenio = @user_id)>10)			
	 begin
		exec SQL_O.inhabilitar_usuario @user = @usuario
		rollback
		raiserror('El usuario quedo inhabilitado por llegar a las 10 ventas sin rendir',16,1)
		return
	 end			 
commit

GO

-- Finalizar publicacion

create procedure SQL_O.finalizar_publicacion @pub_cod numeric(18,0)
as 
begin transaction
			 if( (select Pub_Tipo from SQL_O.Publicacion where Pub_Cod=@pub_cod)!='Compra Inmediata')
		begin
			 rollback
			 raiserror('La publicacion no es de compra Inmediata.',16,1)
			 return
		
		end
	
	if( (select Pub_Estado from SQL_O.Publicacion where Pub_Cod=@pub_cod)!='Publicada')
		begin
			 rollback
			 raiserror('No se puede finalizar una publicacion que no este publicada.',16,1)
			 return
		
		end
	
	 update SQL_O.Publicacion
	 set Pub_Estado='Finalizada'
	 where Pub_Cod=@pub_cod
			
	 exec SQL_O.crear_item @pub_cod = @pub_cod, @cantidad = 1, @tipo = 'Publicacion'
		
commit
GO


-- Generar Compra

create procedure SQL_O.generar_compra @pub_cod numeric(18,0), @usuario varchar(30) , @cant numeric(18,0), @fecha nvarchar(8)
as 
	begin transaction
		declare @userid numeric(18,0)
		declare @fecha_real datetime
		set @fecha_real = @fecha
		set @userid = (select UserId from SQL_O.Usuario where Username=@usuario)
	if((select Pub_Estado from SQL_O.Publicacion where Pub_Cod = @pub_cod)='Publicada')
	begin
		if((select u.Username 
			from SQL_O.Publicacion p, SQL_O.Usuario u 
			where p.Pub_Duenio = u.UserId and p.Pub_Cod = @pub_cod)=@usuario)
		begin
			rollback
			raiserror('Un usuario no puede "auto comprarse"',16,1)
		end
		declare @pub_stock numeric(18,0)
		set @pub_stock=(select Pub_Stock_Actual from SQL_O.Publicacion where @pub_cod = Pub_Cod)
		
		if(@cant <= @pub_stock)
			begin
				 insert into SQL_O.Compra(Compra_Pub,Compra_Fecha,Compra_Cantidad,Compra_Comprador)
						values (@pub_cod,@fecha_real,@cant,@userid)
						
				 update SQL_O.Publicacion
				 set Pub_Stock_Actual= Pub_Stock_Actual-@cant
					 where Pub_Cod=@pub_cod	
				 if(@cant-@pub_stock=0)
					begin
						update SQL_O.Publicacion
						set Pub_Estado='Finalizada'
							where Pub_Cod=@pub_cod
					end
				 exec SQL_O.crear_item @pub_cod = @pub_cod, @cantidad = @cant, @tipo = 'Venta Inmediata'
				 if((select COUNT(i.Item_Id)
					 from SQL_O.Item_Factura i, SQL_O.Publicacion p 
					 where i.Item_Rendido = 0 
					   and i.Item_Tipo in ('Venta Inmediata','Subasta')
					   and i.Item_Publicacion = p.Pub_Cod
					   and p.Pub_Duenio = @userid)>10)			
				 begin
					exec SQL_O.inhabilitar_usuario @user = @usuario
					rollback
					raiserror('El usuario quedo inhabilitado por llegar a las 10 ventas sin rendir',16,1)
					return
				 end		
			end
		else
		begin
			rollback
			raiserror('La cantidad debe ser menor que el stock.',16,1)
			return	
		end
	end
	else 
	begin
		rollback
		raiserror('No se puede comprar en un publicacion que no está activa',16,1)
		return
	end	
commit		
GO

-- Formular Pregunta.

create procedure SQL_O.crear_pregunta @publicacion numeric(18,0), @pregunta nvarchar(255), 
									  @autor nvarchar(255), @fecha nvarchar(8)

as 
begin transaction

	declare @fecha_real datetime
	set @fecha_real = @fecha
	
	if((select u.Username 
		from SQL_O.Publicacion p, SQL_O.Usuario u 
		where p.Pub_Duenio = u.UserId and p.Pub_Cod = @publicacion)=@autor)
	begin
		rollback
		raiserror('Un usuario no puede "auto preguntarse"',16,1)
		return
	end
	
	if((select Pub_Permite_Preguntas from SQL_O.Publicacion where Pub_Cod = @publicacion) = 0)
	begin
		rollback
		raiserror('Esta publicacion no admite preguntas',16,1)
		return
	end

	Insert into SQL_O.Pregunta(Pre_Fecha,Pre_Pub,Pre_Texto,Pre_User) 
	values (@fecha_real,@publicacion,
			@pregunta,(select u.UserId from SQL_O.Usuario u where u.Username = @autor))
commit
GO

-- Responder Pregunta.

create procedure SQL_O.responder_pregunta @pregunta numeric(18,0), @respuesta nvarchar(255), @fecha nvarchar(8)

as
begin transaction

	declare @fecha_real datetime
	set @fecha_real = @fecha
	
	if((select Pre_Respondida from SQL_O.Pregunta where Pre_Id = @pregunta)=1)
	begin
		rollback
		raiserror('La pregunta ya fue respondida',16,1)
	end
	Insert into SQL_O.Respuesta(Res_Texto,Res_Fecha) values (@respuesta,@fecha_real)
	update SQL_O.Pregunta
	set Pre_Res = (select Max(Res_Cod) from SQL_O.Respuesta),
	    Pre_Respondida = 1
	where Pre_Id = @pregunta

commit
GO

-- Modificacion de Cliente. //corregido//

create procedure SQL_O.modificacion_cliente @nrodoc numeric(18,0),@tipodoc nvarchar(20),@apellido nvarchar(255),@nombre nvarchar(255),
											@cuil nvarchar(50),@fecha_nac datetime,@mail nvarchar(50),@tel numeric(18,0),
											@calle nvarchar(100),@nrocalle numeric(18,0), @piso numeric(18,0),
											@depto nvarchar(50),@codpost nvarchar(50), @usuario nvarchar(30),
											@return numeric(1,0) out
											 
as
begin transaction
		set @return=0
		declare @id_cliente numeric(18,0)
		set @id_cliente= (select Tipo_Cod from SQL_O.Tipo,SQL_O.Usuario where Username=@usuario and User_Tipo=Tipo_Cod)
		
		if exists(select Tipo_Cod from SQL_O.Tipo, SQL_O.Cliente where Tipo_Cod=Cli_Id and @nrodoc = Cli_NroDoc and @tipodoc = Cli_TipoDoc and @id_cliente!=Cli_Id)
			begin
				rollback
				raiserror('El tipo y numero de documento ya pertenece a otro cliente', 16, 1)
				set @return=1 --ya hay alguien con el mismo tipo y nro de documento
				return
			end
		else
			
				if	exists(select Cli_Id from SQL_O.Cliente where @cuil=Cli_Cuil and @id_cliente!=Cli_Id)	
					begin
						rollback
						raiserror('El numero de cuil ya pertenece a otro cliente', 16, 1)
						set @return=2 --ya hay alguien con el mismo cuil
						return 
					end	
				else
					if exists(select Tipo_Cod from SQL_O.Tipo where @tel=Tipo_Tel and Tipo_Cod!=@id_cliente)
					   begin
						   rollback
						   raiserror('El numero de telefono ya pertenece a otro cliente', 16, 1)
						   set @return=3 --ya hay alguien con el mismo nro de tel
						   return
					   end
					else
					/*¿QUE DATOS HAY QUE ACTUALIZAR?*/ --pisamos todo :D
					update SQL_O.Cliente
					set	Cli_Nombre = @nombre, 
					Cli_Apellido = @apellido,
					Cli_TipoDoc = @tipodoc,
					Cli_NroDoc = @nrodoc,
					Cli_Cuil=@cuil,
					Cli_Fecha_Nac=@fecha_nac
					where Cli_Id = @id_cliente
						
					update SQL_O.Tipo
					set Tipo_Mail = @mail,
					Tipo_Tel=@tel,
					Tipo_Dom_Calle=@calle,
					Tipo_Nro_Calle=@nrocalle,
					Tipo_Dom_Piso=@piso,
					Tipo_Depto=@depto,
					Tipo_Cod_Postal=@codpost
					where Tipo_Cod = (select Tipo_Cod from SQL_O.Tipo where Tipo_Cod= @id_cliente)
					
commit 
GO

-- Modificacion de Empresa. //corregido//

create procedure SQL_O.modificacion_empresa  @razon_social nvarchar(255), @cuit nvarchar(50), @fecha_creacion datetime, @contacto nvarchar(50), 
											 @mail nvarchar(50), @tel numeric(18,0), @calle nvarchar(100),@nrocalle numeric(18,0), @piso numeric(18,0),
											 @dpto nvarchar(50), @cod_post nvarchar(50), @usuario nvarchar(30), @return numeric(1,0) out					 
as
begin transaction
		
		set @return=0
		declare @id_empresa numeric(18,0)
		set @id_empresa=(select Tipo_Cod from SQL_O.Usuario,SQL_O.Tipo where Username=@usuario and User_Tipo=Tipo_Cod)
		
		if exists(select Emp_Cod from SQL_O.Empresa where (@cuit = Emp_Cuit and @id_empresa!=Emp_Cod) or
					(@razon_social = Emp_Razon_Social 
					and @id_empresa != Emp_Cod))
		begin
			rollback
			raiserror('El cuit o la razon social pertenecen a otra empresa', 16, 1)
			set @return=1 -- el cuit o la razon social ya estan registrados 
			return
		end
		else
			/*¿QUE DATOS HAY QUE ACTUALIZAR?*/ --pisamos todo :D
			update SQL_O.Empresa
			set	Emp_Razon_Social = @razon_social, 
			Emp_Cuit = @cuit,
			Emp_Fecha_Creacion=@fecha_creacion,
			Emp_Contacto=@contacto
			where Emp_Cod = @id_empresa
			
			update SQL_O.Tipo
			set Tipo_Mail = @mail,
			Tipo_Tel=@tel,
			Tipo_Dom_Calle=@calle,
			Tipo_Nro_Calle=@nrocalle,
			Tipo_Dom_Piso=@piso,
			Tipo_Depto=@dpto,
			Tipo_Cod_Postal=@cod_post
			where Tipo_Cod = (select Tipo_Cod from SQL_O.Tipo where Tipo_Cod= @id_empresa)
	
commit

GO

-- Modificacion de Rol

create procedure SQL_O.modificacion_rol @rol_cod numeric(18,0) ,@descripcion nvarchar(255), @return numeric(1,0) out
as
begin transaction
	set @return = 0
	if(exists(select Rol_Desc from SQL_O.Rol where @rol_cod != Rol_Cod and Rol_Desc = @descripcion))
	begin
		rollback
		raiserror('La descripcion ya pertenece a un rol',16,1)
		set @return = 1
	end
	
	update SQL_O.Rol
	set Rol_Desc = @descripcion
	where Rol_Cod = @rol_cod
	
commit
GO

-- Quitar funcionalidad

create procedure SQL_O.quitar_funcionalidad @funcionalidad nvarchar(255), @rol nvarchar(255)
as
begin transaction
	declare @rol_cod numeric(18,0)
	declare @func_cod numeric(18,0)
	
	set @rol_cod = (select Rol_Cod from SQL_O.Rol where @rol = Rol_Desc)
	set @func_cod = (select Func_Cod from SQL_O.Funcionalidad where @funcionalidad = Func_Desc)
	
	Delete from SQL_O.Func_Por_Rol
	where Func_Cod = @func_cod and Rol_Cod = @rol_cod
	
commit
GO

-- Modificacion de Visibilidad//Si los chicos nos mandan el codigo de la visibilidad podríamos cambiar también la descripción//

create procedure SQL_O.modificacion_visibilidad @vis_cod numeric(18,0) ,@descripcion nvarchar(255), @duracion numeric(18,0), 
												@precio numeric(18,2),@porcentaje numeric(18,2), 
												@return numeric(1,0) out
as
begin transaction
	set @return=0
	if((exists(select Vis_Cod from SQL_O.Visibilidad where @descripcion = Vis_Desc and @vis_cod != Vis_Cod)))
	begin
		rollback
		raiserror('La descripción de esa visibilidad ya existe', 16, 1)
		set @return = 1
		return
	end
	
	update SQL_O.Visibilidad
	set	Vis_Desc = @descripcion,
	Vis_Duracion = @duracion,
	Vis_Precio = @precio,
	Vis_Porcentaje = @porcentaje
	where Vis_Desc = @descripcion
	
commit
GO

-- Baja de visibilidad. //revisado//

create procedure SQL_O.baja_visibilidad @visibilidad nvarchar(255)
as
begin transaction

	update SQL_O.Visibilidad set Vis_Baja = 1
	where Vis_Desc = @visibilidad
	
commit
GO 

-- Baja de Cliente.
create procedure SQL_O.baja_cliente @nombre nvarchar(255) , @apellido nvarchar(255) ,
                                    @tipo_doc nvarchar(20) ,@nro_doc numeric(18,0) , @mail nvarchar(50)
as
begin transaction
	
	declare @cliente_id numeric(18,0)
	set @cliente_id = (select c.Cli_Id 
					   from SQL_O.Cliente c
					   where Cli_Nombre = @nombre
					     and Cli_Apellido = @apellido
	                     and Cli_TipoDoc = @tipo_doc
						 and Cli_NroDoc = @nro_doc
						 and @mail = (select Datos_Mail from Datos_Pers, Cliente c where c.Cli_Datos_Pers = Datos_Id)) 
	
	update SQL_O.Cliente set Cli_Baja = 1
	where Cli_Id = @cliente_id
	
	update SQL_O.Publicacion
	set Pub_Estado = 'Finalizada'
	where Pub_Duenio = (select u.UserId 
						from SQL_O.Usuario u
						where u.User_Tipo = @cliente_id)
	
commit 
GO 

-- Baja de Empresa.

create procedure SQL_O.baja_empresa  @razon_social nvarchar(255) , @cuit nvarchar(50) , @mail nvarchar(50) 
											 
as
begin transaction

	declare @empresa_cod numeric(18,0)
	set @empresa_cod = (select Emp_Cod 
						from SQL_O.Empresa
						where Emp_Razon_Social = @razon_social
						  and Emp_Cuit = @cuit 
	                       and @mail = (select Datos_Mail from Datos_Pers, Empresa e where e.Emp_Datos_Pers = Datos_Id))
	                       
	update SQL_O.Empresa set Emp_Baja = 1
	where Emp_Cod = @empresa_cod
	
	update SQL_O.Publicacion
	set Pub_Estado = 'Finalizada'
	where Pub_Duenio = (select u.UserId 
						from SQL_O.Usuario u
						where u.User_Tipo = @empresa_cod)

commit	  
GO

-- Baja de Rol. //corregido//

create procedure SQL_O.baja_rol @rol nvarchar(255)
as
begin transaction
	
	update SQL_O.Rol set Rol_baja = 1
	where Rol_Desc = @rol
	
commit 
GO 

-- Rehabilitar Rol. //corregido//

create procedure SQL_O.rehabilitacion_rol @rol nvarchar(255)
as
begin transaction
	
	update SQL_O.Rol set Rol_baja = 0
	where Rol_Desc= @rol
	
commit 
GO 

-- Generar Factura
create procedure SQL_O.generar_factura @user nvarchar(30), @forma_pago nvarchar(255),@fecha nvarchar(8), @nro_fact numeric(18,0) out
as
begin transaction
		
		declare @fecha_real datetime
		set @fecha_real = @fecha
		
		declare @userid numeric(18,0)
		set @userid= (select UserId from SQL_O.Usuario where Username=@user)
		
		set @nro_fact=(select MAX(Factura_Nro) from SQL_O.Factura)+1
		
		insert into SQL_O.Forma_Pago(Forma_Pago_Desc) values (@forma_pago)
		
		insert into SQL_O.Factura(Factura_Nro,Factura_Fecha,Factura_Forma_Pago,Factura_Usuario)
				values(@nro_fact,@fecha_real,(select Max(Forma_Pago_Id) from SQL_O.Forma_Pago),@userid)
commit
GO

-- Cargar Datos Tarjeta
create procedure SQL_O.cargar_datos_tarjeta @nro_fact numeric(18,0), @nro_tarj numeric(16,0), @duenio nvarchar(80),@fecha_venc nvarchar(8),@tipo_tarjeta nvarchar(30)
as 
begin transaction
	  declare @fecha datetime
	  set @fecha=@fecha_venc
	  declare @forma_id numeric(18,0)
	  set @forma_id = (select Factura_Forma_Pago from SQL_O.Factura where Factura_Nro=@nro_fact)
		
	  	
	
	  update SQL_O.Forma_Pago
	  set Forma_Pago_NroTarjeta=@nro_tarj,
	  FP_Duenio_Tarjeta=@duenio,
	  FP_Fecha_Venc_Tarj= @fecha,
	  FP_Tipo_Tarjeta=@tipo_tarjeta

commit
GO

-- Agregar Items a la factura

create procedure SQL_O.agregar_item  @factura numeric(18,0), @item_factura numeric(18,0)
as
begin transaction
	if(exists(select Factura_Nro from SQL_O.Factura where @factura = Factura_Nro))
	begin 
		rollback
		raiserror('La factura no existe',16,1)
		return
	end
	
	update SQL_O.Item_factura
	set Item_Factura = @factura
	where Item_Id = @item_factura
	
	update SQL_O.Factura
	set Factura_Total = Factura_Total + (select  Item_Monto * Item_Cantidad from SQL_O.Item_Factura where @item_factura = Item_Id)
	where Factura_Nro = @factura
	
commit
GO

-- Rehabilitar Usuario 

create procedure SQL_O.rehabilitar_usuario @user varchar(30)
as
begin transaction

	update SQL_O.Usuario 
	set User_Deshabilitado = 0
	where @user = Username
	
	update SQL_O.Publicacion
	set Pub_Estado = 'Publicada'
	where Pub_Duenio = (select UserId from SQL_O.Usuario where Username = @user)
	  and Pub_Estado = 'Pausada'
	
commit
GO

-- Calcular Trimestre

create procedure SQL_O.calcular_trimestre @trimestre numeric(1,0), @mes1 numeric(2,0) out, @mes2 numeric(2,0) out
as
	begin
		 if(@trimestre=1)
				begin
					set @mes1=1
					set @mes2=3
				end
		
		if(@trimestre=2)
				begin
					set @mes1=4
					set @mes2=6
				end
				
		if(@trimestre=3)
				begin
					set @mes1=7
					set @mes2=9
				end
				
		if(@trimestre=4)
				begin
					set @mes1=10
					set @mes2=12
				end

	end
GO

-- FUNCIONES --


-- para llamar a las funciones por ej: select * from SQL_O.historial_compras('gdd1')

--Historial de compras de un usuario.

create function SQL_O.historial_compras (@usuario nvarchar(30))
returns @tabla TABLE (Codigo_Publicacion numeric(18,0),
					  Descripcion_Publicacion nvarchar(255),
					  Vendedor nvarchar(30),
					  Precio_Publicacion numeric(18,2),
					  Fecha_Compra datetime)
					  
as 
	begin
	declare @id numeric(18,0)
	set @id= (select UserId from SQL_O.Usuario where Username=@usuario)
	
	insert into @tabla(Codigo_Publicacion,Descripcion_Publicacion,Vendedor,Precio_Publicacion,Fecha_Compra)
			(select (select Pub_Cod from SQL_O.Publicacion p2 where p2.Pub_Cod=Compra_Pub) ,
					(select Pub_Desc from SQL_O.Publicacion p2 where p2.Pub_Cod=Compra_Pub) ,
					(select Username from SQL_O.Publicacion p2,SQL_O.Usuario u where p2.Pub_Cod=Compra_Pub and u.UserId=Pub_Duenio ),
					(select Pub_Precio from SQL_O.Publicacion p2 where p2.Pub_Cod=Compra_Pub) ,
					Compra_Fecha 
				from SQL_O.Compra
					where Compra_Comprador=@id)
		return
	end
GO

--Historial de calificaciones de un usuario.
create function SQL_O.historial_calif(@usuario nvarchar(30))
returns @tabla table (Codigo_Publicacion numeric(18,0),
					  Comprador nvarchar(30),--el que califico
					  Vendedor nvarchar(30),
					  Cal_Desc nvarchar(255),
					  Cant_Estrellas numeric(18,0))
					  
as 
	begin
		declare @id numeric(18,0)
		set @id= (select UserId from SQL_O.Usuario where Username=@usuario)
		
		insert into @tabla (Codigo_Publicacion,Comprador,Vendedor,Cal_Desc,Cant_Estrellas)
			(select (select Pub_Cod from SQL_O.Publicacion p2 where p2.Pub_Cod=Cal_Pub), 
					(select Username from SQL_O.Usuario u where u.UserId=Cal_User) ,
					(select Username from SQL_O.Publicacion p1,SQL_O.Usuario u3 where Cal_Pub=p1.Pub_Cod and p1.Pub_Duenio=u3.UserId) ,
					Cal_Desc,
					Cal_Cant_Est
						from SQL_O.Calificacion
								where Cal_User=@id or
									(select Pub_Duenio from SQL_O.Publicacion where Cal_Pub=Pub_Cod)=@id)
		return
	end
GO

--Historial de ofertas de un usuario.
create function SQL_O.historial_ofertas(@usuario nvarchar(30))
returns @tabla table (Publicacion_Codigo numeric(18,0),
					  Publicacion_Desc nvarchar(255),
					  Monto numeric(18,2),
					  Fecha datetime,
					  Ganador varchar(2))
as 
	begin
	declare @id numeric(18,0)
	set @id= (select UserId from SQL_O.Usuario where Username=@usuario)
	
	insert into @tabla (Publicacion_Codigo,Publicacion_Desc,Monto,Fecha,Ganador)
			(select (select Pub_Cod from SQL_O.Publicacion p2 where p2.Pub_Cod=Oferta_Pub) ,
					(select Pub_Desc from SQL_O.Publicacion p2 where p2.Pub_Cod=Oferta_Pub) ,
					Oferta_Monto,
					Oferta_Fecha,
					case when Oferta_Gano=0 then 'No'
						else 'Si' end 
					from SQL_O.Oferta
							where Oferta_Cliente=@id or
								(select Pub_Duenio from SQL_O.Publicacion where Oferta_Pub=Pub_Cod)=@id)
		return
	end
GO


-- Listado de vendedores con mayor cantidad de productos no vendidos
-- Listado de vendedores con mayor facturacion
-- Listado de vendedores con mayores calificaciones
-- Listado de clientes con mayor cantidad de publicaciones sin calificar
/*
create function SQL_O.listado_vend_prod_no_vendidos (@anio numeric(4,0), @trimestre numeric(1,0))
returns @tabla table(Anio numeric(4,0), 
	                 Mes numeric(2,0),
	                 Visibilidad nvarchar(255), 
	                 Vendedor varchar(30), 
	                 Cant_Prod numeric(18,0))
as
begin
	declare @mes_inicio numeric(2,0)
	declare @mes_fin numeric(2,0)
	
	exec SQL_O.calcular_trimestre @mes1 = @mes_inicio out, @mes2 = @mes_fin out
	insert into @tabla(Anio,Mes,Visibilidad,Vendedor,Cant_Prod) 
	(select top 5 u.Username
	 from SQL_O.Publicacion p, SQL_O.Usuario u 
	 where MONTH(p.Fecha_Ini) between @mes_inicio and @mes_fin
	   and YEAR(p.Fecha_Ini) = @anio
	   and p.Pub_Duenio = u.UserId
	 order by SUM(case when p.Pub_Tipo = 'Compra Inmediata' then (select SUM(c.Compra_Cantidad)
															      from SQL_O.Compra c
										                          where c.Compra_Pub = p.Pub_Cod)
				  case when (p.Pub_Tipo = 'Subasta' and Pub_Estado = 'Publicada') then 1
				  else 0 end)desc)
end
return
GO
 */
  
select top 5 u.Username
 from SQL_O.Publicacion p, SQL_O.Usuario u, SQL_O.Compra c
 where MONTH(p.Pub_Fecha_Ini) between 1 and 3
   and YEAR(p.Pub_Fecha_Ini) = 2013
   and p.Pub_Duenio = u.UserId
   and  c.Compra_Pub = p.Pub_Cod
 group by u.Username, p.Pub_Stock_Inicial
 order by SUM(p.Pub_Stock_Inicial - c.Compra_Cantidad) desc
  