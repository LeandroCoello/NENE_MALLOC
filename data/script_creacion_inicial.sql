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

		Rol_Cod numeric(18,0) Primary Key Identity,
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
		

CREATE TABLE SQL_O.Tipo(
		Tipo_Cod numeric(18,0) Primary Key identity,
		Tipo_Nombre nvarchar(255),
		Tipo_Rol numeric(18,0) references SQL_O.Rol(Rol_Cod)
	)
GO


CREATE TABLE SQL_O.Empresa(
		Emp_Cod numeric(18,0) Primary Key references SQL_O.Tipo(Tipo_Cod) NOT NULL,
		Emp_Razon_Social nvarchar(255) Unique,
		Emp_Cuit nvarchar(50) Unique,
		Emp_Fecha_Creacion datetime,
		Emp_Contacto nvarchar(50),
		Emp_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
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
		Cli_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
		Cli_Reputacion numeric(18) default 0,
		Cli_Baja bit default 0
		)
GO

CREATE TABLE SQL_O.Administrativo(
		Admin_Id numeric(18,0) Primary Key References SQL_O.Tipo(Tipo_Cod) NOT NULL,
		Admin_NroDoc numeric(18,0), 
		Admin_TipoDoc nvarchar(20), 
		Admin_Apellido nvarchar(255),
		Admin_Nombre nvarchar(255),
		Admin_Cuil numeric(18,0) Unique,
		Admin_Fecha_Nac datetime,
		Admin_Datos_Pers numeric(18,0) references SQL_O.Datos_Pers(Datos_Id) NOT NULL,
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
		Pub_Stock numeric(18,0),
		Pub_Fecha_Ini datetime,
		Pub_Fecha_Vto datetime,
		Pub_Precio numeric(18,2),
		Pub_Tipo nvarchar(100),
		Pub_Estado nvarchar(255),
		Pub_Visibilidad numeric(18,0) references SQL_O.Visibilidad(Vis_Cod) NOT NULL,
		Pub_Duenio numeric (18,0) references SQL_O.Usuario(UserId) NOT NULL
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
		Pre_User numeric(18,0) references SQL_O.Usuario(UserID)
		)
GO

CREATE TABLE SQL_O.Factura (
	Factura_Nro numeric(18,0) Primary Key, 
	Factura_Fecha datetime, 
	Factura_Total numeric(18,0),
	Factura_Forma_Pago nvarchar(255),
	Factura_Usuario numeric(18,0) references SQL_O.Usuario(UserId)
	)
GO	

CREATE TABLE SQL_O.Item_Factura (
	Item_Id numeric(18,0) Primary Key Identity,
	Item_Monto numeric(18,2),
	Item_Cantidad numeric(18,0),
	Item_Publicacion numeric(18,0) references SQL_O.Publicacion(Pub_Cod),
	Item_Factura numeric(18,0) references SQL_O.Factura(Factura_Nro)
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

--Migracion

Insert into SQL_O.Rol(Rol_Desc) values('Empresa')
Insert into SQL_O.Rol(Rol_Desc) values('Cliente')
Insert into SQL_O.Rol(Rol_Desc) values('Admin')
GO


Insert into SQL_O.Visibilidad(Vis_Cod,Vis_Desc,Vis_Porcentaje,Vis_Precio, Vis_Duracion)
	(select distinct Publicacion_Visibilidad_Cod, 
					 Publicacion_Visibilidad_Desc,
				     Publicacion_Visibilidad_Porcentaje,
				     Publicacion_Visibilidad_Precio,7 
	from gd_esquema.Maestra)
	order by Publicacion_Visibilidad_Cod
GO
	
Insert into SQL_O.Rubro(Rubro_Desc)
	(select distinct Publicacion_Rubro_Descripcion 
		from gd_esquema.Maestra)
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
Insert into SQL_O.Tipo(Tipo_Nombre,Tipo_Rol) values ('Empresa',(select Rol_Cod from SQL_O.Rol where Rol_Desc='Empresa'))

Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal)
			values(@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal)
			
Insert into SQL_O.Empresa(Emp_Cod,Emp_Datos_Pers ,Emp_Razon_Social, Emp_Cuit, Emp_Fecha_Creacion) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @razon_social, @cuit, @fecha_c)

Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values (('gdd'+convert(varchar(30),@idemp)),
																'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
																(select MAX(Tipo_Cod) from SQL_O.Tipo))


fetch cursor_Migracion_Emp into @razon_social, @cuit, @fecha_c, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal
end
close cursor_Migracion_Emp
deallocate cursor_Migracion_Emp
 
GO


--Migracion Cliente
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


Insert into SQL_O.Tipo(Tipo_Nombre,Tipo_Rol) values ('Cliente',(select Rol_Cod from SQL_O.Rol where Rol_Desc='Cliente'))


Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal)
			values(@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal)
			
Insert into SQL_O.Cliente(Cli_Id,Cli_Datos_Pers ,Cli_NroDoc, Cli_Apellido, Cli_Nombre,Cli_Fecha_Nac,Cli_TipoDoc) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @dni, @apellido, @nombre,@fecha_nac,'DNI')


Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values ('gdd'+CONVERT(varchar(30),@idcli),
															   '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
															   (select MAX(Tipo_Cod) from SQL_O.Tipo))



fetch cursor_Migracion_Cli into @dni, @apellido, @nombre, @fecha_nac, @mail, @dom_calle,
							@nro_calle, @piso, @depto, @cod_postal

end
close cursor_Migracion_Cli
deallocate cursor_Migracion_Cli
 
GO

--Migracion Publicacion
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

Insert into SQL_O.Publicacion(Pub_Cod,Pub_Desc,Pub_Stock,Pub_Fecha_Ini,Pub_Fecha_Vto,Pub_Precio,Pub_Tipo
							,Pub_Estado,Pub_Duenio,Pub_Visibilidad)
			values(@cod, @desc, @stock, @fecha_ini, @fecha_vto, @precio,@tipo,@estado,@duenio,@visibilidad_cod)

Insert into SQL_O.Pub_Por_Rubro(Pub_Cod,Rubro_Cod)
			values(@cod,(select Rubro_Cod from SQL_O.Rubro where @rubro=Rubro_Desc))

fetch cursor_Migracion_Pub into @cod, @desc, @stock, @fecha_ini, @fecha_vto, @precio,
							@tipo, @estado,@cuit_empresa,@dni_cliente,@visibilidad_cod,@rubro
end
close cursor_Migracion_Pub
deallocate cursor_Migracion_Pub
 
GO


-- Insert Admin

Insert into SQL_O.Tipo(Tipo_Nombre,Tipo_Rol) values ('Admin',(select Rol_Cod from SQL_O.Rol where Rol_Desc='Admin'))

Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal,Datos_Tel)
			values('sql_o_rulz@gmail.com', 'Medrano','951', 4, 'O','0007',47777777)

Declare @date date = '12-03-1985'
Declare @datetime datetime = @date
Insert into SQL_O.Administrativo(Admin_Id,Admin_Datos_Pers ,Admin_NroDoc, Admin_Apellido, Admin_Nombre,Admin_Fecha_Nac) 
			values((select Max(Tipo_Cod) from SQL_O.Tipo),(select MAX(Datos_Id) from SQL_O.Datos_Pers), '77777777','Horsehead Bond','James',@datetime)

Insert into SQL_O.Usuario(Username,Userpass,User_Tipo) values ('superAdmin','8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',(select MAX(Tipo_Cod) from SQL_O.Tipo))

GO


insert into SQL_O.Calificacion(Cal_Codigo,Cal_Cant_Est,Cal_Desc,Cal_Pub,Cal_User)
	(select distinct Calificacion_Codigo,
					 Calificacion_Cant_Estrellas, 
					 Calificacion_Descripcion,
					 Publicacion_Cod,
					 (select UserId from SQL_O.Cliente,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni=Cli_NroDoc and Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	 from gd_esquema.Maestra where Calificacion_Codigo is not null)
	 
GO

insert into SQL_O.Factura(Factura_Nro,Factura_Fecha,Factura_Total,Factura_Forma_Pago,Factura_Usuario)
	(select distinct Factura_Nro,
					Factura_Fecha,
					Factura_Total,
					Forma_Pago_Desc,
					(select Pub_Duenio from SQL_O.Publicacion where Pub_Cod = Publicacion_Cod)
	from gd_esquema.Maestra where Factura_Nro is not null)
	order by Factura_Nro

GO

insert into SQL_O.Item_Factura(Item_Cantidad,Item_Factura,Item_Monto,Item_Publicacion)
	(select Item_Factura_Cantidad,
			Factura_Nro,
			Item_Factura_Monto,
			Publicacion_Cod
	from gd_esquema.Maestra where Item_Factura_Cantidad is not null)

GO


insert into SQL_O.Compra(Compra_Pub,Compra_Fecha,Compra_Cantidad,Compra_Comprador)
	(select distinct Publicacion_Cod,
					 Compra_Fecha,
					 Compra_Cantidad,
					 (select UserId from SQL_O.Cliente c,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni = c.Cli_NroDoc and c.Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	from gd_esquema.Maestra where Compra_Fecha is not null)
	
GO

insert into SQL_O.Oferta(Oferta_Pub,Oferta_Fecha,Oferta_Monto,Oferta_Cliente)
	(select distinct Publicacion_Cod,
					 Oferta_Fecha,
					 Oferta_Monto,
					 (select UserId from SQL_O.Cliente c,SQL_O.Tipo,SQL_O.Usuario where Cli_Dni = c.Cli_NroDoc and c.Cli_Id=Tipo_Cod and User_Tipo=Tipo_Cod)
	from gd_esquema.Maestra where Oferta_Fecha is not null)
	
GO

--Migración corregida
go

-- Store Procedures


--Login (CORREGIDO)
create Procedure SQL_O.proc_login @usuario varchar(30),@userpass nvarchar(255),@return numeric(1,0) out, @rol nvarchar(255) out
as 
begin
set @return=0 --El usuario ingresa correctamente
if exists (select Username from SQL_O.Usuario where Username=@usuario and Userpass=@userpass)
	begin 
	update SQL_O.Usuario set User_Intentos = 0
	where Username = @usuario;
	declare @deshabilitado bit
	declare @baja bit
	set @deshabilitado = (select Usuario_Deshabilitado from SQL_O.Usuario where @usuario=Username)
	set @baja = (select Usuario_Baja from SQL_O.Usuario where @usuario=Username)
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
			else 
				begin
				set @rol = (select Rol_Nombre from SQL_O.Rol, SQL_O.Usuario where Username = @usuario and Rol_usuario = UserId and Rol_baja = 0)
				end

	end
else
	begin
		if exists (select Username from SQL_O.Usuario where Username=@usuario and Userpass!=@userpass)
		begin
			if((select User_Intentos from SQL_O.Usuario where @usuario = Username) = 2)
			begin
				
				raiserror('La contraseña ingresada no es correcta y el usuario quedo inhabilitado',16,1)
				update SQL_O.Usuario set Usuario_Deshabilitado = 1
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

-- Generar usuario (CORREGIDO)
create procedure SQL_O.generar_usuario @nombreUsuario nvarchar(30) out, @pass nvarchar(255) out
as
begin 
	declare @id numeric(18,0)
	set @id = (select MAX(UserId) from SQL_O.Usuario)+1
	set @nombreUsuario = 'Usuario'+CONVERT(varchar(30),@id)
	set @pass = 123456
	insert into SQL_O.Usuario(Username,Userpass)
		values(@nombreUsuario ,'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
		
end 
GO

-- Alta Cliente (CORREGIDO)
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
			 
		Insert into SQL_O.Rol(Rol_Nombre,Rol_usuario) values ('Cliente',(select UserId from SQL_O.Usuario where Username = @usuario))

		Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal,Datos_Tel)
			values(@mail, @calle, @nrocalle, @piso, @depto, @codpost,@tel)
			
		Insert into SQL_O.Cliente(Cli_Id,Cli_Datos_Pers ,Cli_NroDoc, Cli_Apellido, Cli_Nombre,Cli_Fecha_Nac,Cli_TipoDoc,Cli_Cuil) 
			values((select Max(Rol_Cod) from SQL_O.Rol),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @nrodoc, @apellido, @nombre,@fecha_nac,@tipodoc,@cuil)

commit

GO

-- Alta Empresa (CORREGIDO)
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
			 
		Insert into SQL_O.Rol(Rol_Nombre,Rol_usuario) values ('Empresa',(select UserId from SQL_O.Usuario where Username = @usuario))

		Insert into SQL_O.Datos_Pers(Datos_Mail, Datos_Dom_Calle, Datos_Nro_Calle, Datos_Dom_Piso, Datos_Depto, Datos_Cod_Postal,Datos_Tel)
			values(@mail, @dom_calle, @nro_calle, @piso, @depto, @cod_postal,@tel)
			
		Insert into SQL_O.Empresa(Emp_Cod,Emp_Datos_Pers,Emp_Razon_Social, Emp_Cuit,Emp_Fecha_Creacion,Emp_Contacto) 
			values((select Max(Rol_Cod) from SQL_O.Rol),(select MAX(Datos_Id) from SQL_O.Datos_Pers), @razon_social,@cuit,@fecha_c,@contacto)

commit

GO 

-- Crear Publicación (CORREGIDO)
create procedure SQL_O.alta_publicacion @descripcion nvarchar(255), @stock numeric(18,0), @rubro nvarchar(255),
										@precio numeric(18,2), @tipo nvarchar(255), 
										@estado varchar(255),@visibilidad nvarchar(255), @duenio varchar(30),
										@return numeric(1,0)
										
as
begin transaction	

	set @return = 0
	if( @stock < 1) 
	begin
		rollback
		raiserror('No se puede tener un stock menor a 1(uno)',16,1)
		set @return = 1
	end

	if( @tipo = 'subasta' and @stock > 1) 
	begin
		rollback
		raiserror('En Subastas el stock máximo permitido es 1',16,1)
		set @return = 2
	end
											
	
	Insert into SQL_O.Tipo_Pub(Tipo_Precio, Tipo_Desc)values (@precio, @tipo)
	
	Insert into SQL_O.Publicacion(Pub_Cod, Pub_Desc, Pub_Stock, Pub_Fecha_Ini, Pub_Fecha_Vto, Pub_Precio, Pub_Tipo,
								  Pub_Estado,Pub_Visibilidad, Pub_Duenio)
			values ((select Max(Pub_Cod) from SQL_O.Publicacion) + 1, @descripcion, @stock, GETDATE(), 
			 GETDATE() + (select Vis_Duracion from SQL_O.Visibilidad where @visibilidad = Vis_Desc), 
			@precio,(select Max(Tipo_Id) from SQL_O.Tipo_Pub), @estado, (select Vis_Cod from SQL_O.Visibilidad where @visibilidad = Vis_Desc),
		    (select Rol_Cod from SQL_O.Rol, SQL_O.Usuario where @duenio = Username and Rol_Usuario = UserID))
	Insert into SQL_O.Pub_Por_Rubro (Rubro_Cod, Pub_Cod) 
		values ((select Rubro_Cod from SQL_O.Rubro where Rubro_Desc = @rubro), 	(select Max(Pub_Cod) from SQL_O.Publicacion))	
commit 

GO		


-- Alta de visibilidad(CORREGIDO)

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

-- Alta Rubro(NO HACE FALTA)
/*create procedure SQL_O.alta_rubro @codigo numeric(18,0), @descripcion nvarchar(255)
as 
begin transaction
		if exists(select Rubro_Cod from SQL_O.Rubro  where Rubro_Cod = @codigo)
			begin
				rollback
				raiserror('El rubro ya existe.',16,1)
			end
		else 
			Insert into SQL_O.Rubro(Rubro_Cod,Rubro_Desc) values (@codigo, @descripcion)
		
commit	*/	
GO

-- Modificacion de Cliente
/*
create procedure SQL_O.modificacion_cliente @nrodoc numeric(18,0),@tipodoc nvarchar(20),@apellido nvarchar(255),@nombre nvarchar(255),
											@cuil nvarchar(50),@fecha_nac datetime,@mail nvarchar(50),@tel numeric(18,0),
											@calle nvarchar(100),@nrocalle numeric(18,0), @piso numeric(18,0),
											@depto nvarchar(50),@codpost nvarchar(50), @idusuario numeric(18,0),
											@return numeric(1,0)
											 
as
begin transaction

		if exists(select Cli_Id from SQL_O.Cliente where @nro_doc = Cli_NroDoc and @tipo_doc = Cli_TipoDoc and @id_cliente != Cli_Id)
		begin
			rollback
			raiserror('El numero de documento ya pertenece a otro cliente', 16, 1)
			return
		end
		else
			/*¿QUE DATOS HAY QUE ACTUALIZAR?*/
			update SQL_O.Cliente
			set	Cli_Nombre = @nombre, 
			Cli_Apellido = @apellido,
			Cli_TipoDoc = @tipo_doc,
			Cli_NroDoc = @nro_doc
			where Cli_Id = @id_cliente
			
			update SQL_O.Datos_Pers
			set Datos_Mail = @mail
			where Datos_Id = (select Cli_Datos_Pers from SQL_O.Cliente where Cli_Id = @id_cliente)
	
commit*/
GO

-- Modificacion de Empresa
/*
create procedure SQL_O.modificacion_empresa  @id_empresa numeric(18,0), @razon_social nvarchar(255) output, 
											 @cuit nvarchar(50) output, @mail nvarchar(50) output
											 
as
begin transaction

		if exists(select Emp_Cod from SQL_O.Empresa where @cuit = Emp_Cuit 
					and @razon_social = Emp_Razon_Social 
					and @id_empresa != Emp_Cod)
		begin
			rollback
			raiserror('El cuit y la razon social pertenecen a otra empresa', 16, 1)
			return
		end
		else
			/*¿QUE DATOS HAY QUE ACTUALIZAR?*/
			update SQL_O.Empresa
			set	Emp_Razon_Social = @razon_social, 
			Emp_Cuit = @cuit
			where Emp_Cod = @id_empresa
			
			update SQL_O.Datos_Pers
			set Datos_Mail = @mail
			where Datos_Id = (select Cli_Datos_Pers from SQL_O.Cliente where Cli_Id = @id_cliente)
	
commit
*/
GO


-- Baja de Rol(CORREGIDO)

create procedure SQL_O.baja_rol @rol nvarchar(255)
as
begin transaction
	
	update SQL_O.Rol set Rol_baja = 1
	where Rol_Nombre = @rol
	
commit 
GO 

-- Rehabilitar Rol(CORREGIDO)

create procedure SQL_O.rehabilitacion_rol @rol nvarchar(255)
as
begin transaction
	
	update SQL_O.Rol set Rol_baja = 0
	where Rol_Nombre = @rol
	
commit 
GO 

-- Baja de visibilidad(CORREGIDO)

create procedure SQL_O.baja_visibilidad @visibilidad nvarchar(255)
as
begin transaction

	update SQL_O.Visibilidad set Vis_Baja = 1
	where Vis_Desc = @visibilidad
	
commit
GO 

-- Baja de Cliente 
create procedure SQL_O.baja_cliente @nombre nvarchar(255) , @apellido nvarchar(255) ,
                                    @tipo_doc nvarchar(20) ,@nro_doc numeric(18,0) , @mail nvarchar(50)
as
begin transaction
	
	update SQL_O.Cliente set Cli_Baja = 1
	where Cli_Nombre = @nombre
	  and Cli_Apellido = @apellido
	  and Cli_TipoDoc = @tipo_doc
	  and Cli_NroDoc = @nro_doc
	  and @mail = (select Datos_Mail from Datos_Pers, Cliente c where c.Cli_Datos_Pers = Datos_Id)
	
commit 
GO 


-- Baja de Empresa

create procedure SQL_O.baja_empresa  @razon_social nvarchar(255) , 
											 @cuit nvarchar(50) , @mail nvarchar(50) 
											 
as
begin transaction

	update SQL_O.Empresa set Emp_Baja = 1
	where Emp_Razon_Social = @razon_social
	  and Emp_Cuit = @cuit 
	  and @mail = (select Datos_Mail from Datos_Pers, Empresa e where e.Emp_Datos_Pers = Datos_Id)

commit	  
GO

