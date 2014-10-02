USE [GD2C2014]
GO

CREATE SCHEMA  NENE_MALLOC AUTHORIZATION gd 
GO

-- Creacion de Tablas

CREATE TABLE NENE_MALLOC.Rol(
		Rol_Id numeric(18,0) primary key,
		Rol_Desc nvarchar(255),
		Rol_estado bit default 0
		)
GO

CREATE TABLE NENE_MALLOC.Funcionalidad(
		Func_Id numeric(18,0) Primary Key,
		Func_Desc nvarchar(255)		
		)
GO

CREATE TABLE NENE_MALLOC.Func_Por_Rol(
		Rol_Id numeric(18,0)references NENE_MALLOC.Rol(Rol_Id),
		Func_Id numeric(18,0) references NENE_MALLOC.Funcionalidad(Func_Id),	
		Primary Key (Rol_Id,Func_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Datos_Personales(
		Datos_Id numeric(18,0) primary key identity,
		Datos_Nombre nvarchar(255),
		Datos_Apellido nvarchar(255),
		Datos_Telefono numeric(18,0),
		Datos_Tipo_Ident nvarchar(30),
		Datos_Nro_Ident numeric(18,0),
		Datos_Mail nvarchar(255),
		Datos_Dom_Calle nvarchar(255),--puse el domicilio asi por la tabla maestra
		Datos_Dom_Nro_Calle numeric(18,0),
		Datos_Dom_Piso numeric(18,0),
		Datos_Dom_Depto nvarchar(50),
		Datos_Fecha_Nac datetime
		)
GO

CREATE TABLE NENE_MALLOC.Usuario(
		Usuario_Id numeric(18,0) Primary Key Identity,
		Usuario_name varchar(30) Unique,
		Usuario_pass nvarchar (255),
		Usuario_Intentos numeric (18,0) default 0,
		Usuario_estado bit default 0,
		Usuario_datos numeric(18,0) references NENE_MALLOC.Datos_Personales(Datos_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Usuario_Por_Rol(
		Usuario_Id numeric(18,0) references NENE_MALLOC.Usuario(Usuario_Id),
		Rol_Id numeric(18,0) references NENE_MALLOC.Rol(Rol_Id)
		Primary Key(Usuario_Id,Rol_Id)
	
	)
GO

CREATE TABLE NENE_MALLOC.Hotel(
		Hotel_Id numeric(18,0) primary key identity,
		Hotel_Nombre nvarchar(255),
		Hotel_Mail nvarchar(255),
		Hotel_Telefono numeric(18,0),
		Hotel_Calle nvarchar(255),
		Hotel_Nro_Calle numeric(18,0),
		Hotel_Ciudad nvarchar(255),
		Hotel_Pais nvarchar(255),
		Hotel_Fecha_Creacion datetime,
		Hotel_Cerrado bit default 0,
		Hotel_Cant_Est numeric(18,0),
		Hotel_Recarga_Estrella numeric(18,0) -- este campo esta en la maestra, supongo que debe ser lo del calculo del costo que era un incremento que dependia de las estrellas
		)
GO

CREATE TABLE NENE_MALLOC.Usuario_Por_Hotel(
		Hotel_Id numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id),
		Usuario_Id numeric(18,0) references NENE_MALLOC.Usuario(Usuario_Id),
		Primary Key (Hotel_Id,Usuario_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Periodos_De_Cierre(
		Periodo_Id numeric(18,0) primary key identity,
		Periodo_Hotel numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id),
		Periodo_FechaInicio datetime,
		Periodo_FechaFin datetime,
		Periodo_Motivo nvarchar(255)
		)
GO

CREATE TABLE NENE_MALLOC.Regimen(
		Regimen_Id numeric(18,0) primary key identity,
		Regimen_Desc nvarchar(255),
		Regimen_Precio numeric(18,2),
		Regimen_Inactivo bit default 0
		)
GO

CREATE TABLE NENE_MALLOC.Regimen_Por_Hotel(
		Hotel_Id numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id),
		Regimen_Id numeric(18,0) references NENE_MALLOC.Regimen(Regimen_Id)
		Primary Key(Hotel_Id,Regimen_Id)
		)
GO
--Por tabla maestra agregue el tipo como otra tabla 
CREATE TABLE NENE_MALLOC.Tipo_Habitacion(
		Tipo_Hab_Id numeric(18,0) primary key,
		Tipo_Hab_Desc nvarchar(255),
		Tipo_Hab_Porc numeric(18,2)
		)
GO

CREATE TABLE NENE_MALLOC.Habitacion(
		Habitacion_Id numeric(18,0) primary key identity,--le puse id igual, de ultima se lo sacamos
		Habitacion_Num numeric(18,0),
		Habitacion_Piso numeric(18,0),
		Habitacion_Hotel numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id),
		Habitacion_Tipo numeric(18,0) references NENE_MALLOC.Tipo_Habitacion(Tipo_Hab_Id),
		Habitacion_Vista nvarchar(50), -- en la maestra esta como frente
		Habitacion_Desc nvarchar(255), --esto no se, por ahi el enunciado se referia a la desc del tipo
		Habitacion_Cerrada bit default 0
		)
GO

CREATE TABLE NENE_MALLOC.Cliente(
		Cliente_Id numeric(18,0) primary key identity,
		Cliente_Datos numeric(18,0) references NENE_MALLOC.Datos_Personales(Datos_Id),
		Cliente_Nacionalidad nvarchar(255),
		Cliente_Deshabilitado bit default 0,
		Cliente_Rol numeric(18,0) references NENE_MALLOC.Rol(Rol_Id)
		)
GO		

CREATE TABLE NENE_MALLOC.Reserva(
		Reserva_Id numeric(18,0) primary key,
		Reserva_Cliente numeric(18,0) references NENE_MALLOC.Cliente(Cliente_Id),
		Reserva_Fecha datetime,
		Rererva_FechaIng datetime,
		Reserva_FechaSal datetime,
		Reserva_CantNoches numeric(18,0), --de nuevo por la maestra, despues vemos cual sacamos si fecha fin o este
		Reserva_Estado nvarchar(255),
		Reserva_Hotel numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Reserva_Por_Habitacion(
		RPH_Id numeric(18,0) primary key identity, --le tuve que agregar esto porque si mandaba que Estadia_Reserva referenciara a Reserva Id de aca rompia porque habia dos pks
		Reserva_Id numeric(18,0) references NENE_MALLOC.Reserva(Reserva_Id) not null,
		Habitacion_Id numeric(18,0) references NENE_MALLOC.Habitacion(Habitacion_Id)not null,
		Regimen_Id numeric(18,0) references NENE_MALLOC.Regimen(Regimen_Id)
		Unique(Reserva_Id,Habitacion_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Estadia(
		Estadia_Id numeric(18,0) primary key identity references NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id),
		Estadia_Reserva numeric(18,0) references NENE_MALLOC.Reserva_Por_Habitacion(RPH_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Estadia_Por_Cliente(
		Cliente_Id numeric(18,0) references NENE_MALLOC.Cliente(Cliente_Id),
		Estadia_Id numeric(18,0) references NENE_MALLOC.Estadia(Estadia_Id),
		Primary Key (Cliente_Id,Estadia_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Consumible(
		Consumible_Id numeric(18,0) primary key,
		Consumible_Desc nvarchar(255),
		Consumible_precio numeric(18,2)
		)
GO

CREATE TABLE NENE_MALLOC.Consumible_Por_Estadia(
		Consumible_Por_Estadia numeric(18,0) primary key identity references NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id),
		Consumible_Id numeric(18,0) references NENE_MALLOC.Consumible(Consumible_Id),
		Estadia_Id numeric(18,0) references NENE_MALLOC.Estadia(Estadia_Id),
		Consumible_Cantidad numeric(18,0)
		)
GO

CREATE TABLE NENE_MALLOC.Factura(
		Factura_Id numeric(18,0) primary key,
		Factura_Cliente numeric(18,0) references NENE_MALLOC.Cliente(Cliente_Id),
		Factura_Fecha datetime,
		Factura_Total numeric(18,2)
		)
GO

CREATE TABLE NENE_MALLOC.Tipo_Item_Factura (
		Tipo_Item_Factura_Id numeric(18,0) primary key identity,
		)
GO

CREATE TABLE NENE_MALLOC.Item_Factura(
		Item_Factura_Id numeric(18,0) primary key identity,
		Item_Factura_Cantidad numeric(18,0) default 1,
		Item_Factura_Monto numeric(18,2),
		Tipo_Item_Factura_Id numeric(18,0) references NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id),
		Item_Factura numeric(18,0) references NENE_MALLOC.Factura(Factura_Id)
		)
GO


-- Migración de datos

--ROL

Insert into NENE_MALLOC.Rol(Rol_Id, Rol_Desc) values (1, 'Administrador')
Insert into NENE_MALLOC.Rol(Rol_Id, Rol_Desc) values (2, 'Recepcionista')
Insert into NENE_MALLOC.Rol(Rol_Id, Rol_Desc) values (3, 'Guest')
GO

--FUNCIONALIDAD

Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (1,'Alta de Rol')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (2,'Baja de Rol')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (3,'Modificacion de Rol')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (4,'Login')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (5,'Alta de usuario')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (6,'Baja de usuario')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (7,'Modificacion de usuario')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (8,'Alta de Cliente')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (9,'Baja de Cliente')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (10,'Modificacion de Cliente')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (11,'Generar reserva')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (12,'Alta de Hotel')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (13,'Baja de Hotel')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (14,'Modificacion de Hotel')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (15,'Alta de Habitacion')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (16,'Baja de Habitacion')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (17,'Modificacion de Habitacion')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (18,'Alta de Regimen')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (19,'Baja de Regimen')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (20,'Modificacion de Regimen')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (21,'Modificar Reserva')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (22,'Cancelar Reserva')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (23,'Check-In')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (24,'Check-Out')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (25,'Registrar Consumibles')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (26,'Emitir Factura')
Insert into NENE_MALLOC.Funcionalidad(Func_Id,Func_Desc) values (27,'Listado Estadístico')
GO

--FUNCIONALIDAD POR ROL

Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,1)		
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,2)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,3)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,4)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,4)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,5)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,6)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,7)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,8)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,8)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,9)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,9)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,10)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,10)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,11)	
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (3,11)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,12)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,13)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,14)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,15)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,16)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,17)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,18)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,19)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,20)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,21)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (3,21)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,22)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (3,22)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,23)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,24)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,25)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,25)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,26)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (2,26)
Insert into NENE_MALLOC.Func_Por_Rol(Rol_Id, Func_Id) values (1,27)
GO

--HOTEL

Insert into NENE_MALLOC.Hotel(Hotel_Calle, Hotel_Nro_Calle, Hotel_Ciudad, Hotel_Cant_Est, Hotel_Recarga_Estrella)
			(select Hotel_Calle, 
				    Hotel_Nro_Calle, 
				    Hotel_Ciudad,
				    Hotel_CantEstrella,
				    Hotel_Recarga_Estrella
			 from gd_esquema.Maestra)
GO

--CLIENTE, DATOS_PERSONALES, USUARIO, USUARIO_POR_ROL

Declare
@nacionalidad nvarchar(255),
@nombre nvarchar(255),
@apellido nvarchar(255),
--@telefono numeric(18,0),
--@tipo_doc nvarchar(30),
--@nro_doc numeric(18,0),
@mail nvarchar(255),
@dom_calle nvarchar(255),
@dom_nro numeric(18,0),
@dom_piso numeric(18,0),
@dom_depto nvarchar(50),
@fecha_nac datetime,
@id_cli numeric(18,0)
Declare cursor_migracion_cliente cursor
	for(select Cliente_Nacionalidad,
			   Cliente_Nombre,
			   Cliente_Apellido,
			   Cliente_Mail,
			   Cliente_Dom_Calle,
			   Cliente_Nro_Calle,
			   Cliente_Piso,
			   Cliente_Depto,
			   Cliente_Fecha_Nac
			   
		from gd_esquema.Maestra)
Open cursor_migracion_cliente
fetch cursor_migracion_cliente into @nacionalidad, @nombre, @apellido, @mail, @dom_calle,@dom_nro, 
                                    @dom_piso, @dom_depto, @fecha_nac
while(@@fetch_status=0)
begin 

set @id_cli = (select MAX(Usuario_Id)from NENE_MALLOC.Usuario)
if (@id_cli is null)
	begin
	set @id_cli = 1
	end
else 
	begin 
	set @id_cli= @id_cli +1
	end
	
--userpass es 123456 con sha256

Insert into NENE_MALLOC.Datos_Personales(Datos_Nombre,Datos_Apellido,Datos_Mail,Datos_Dom_Calle, Datos_Dom_Nro_Calle,
                                         Datos_Dom_Piso, Datos_Dom_Depto, Datos_Fecha_Nac)
                                  values(@nombre, @apellido,@mail,@dom_calle,@dom_nro,@dom_piso,
                                         @dom_depto,@fecha_nac)
                                      
Insert into NENE_MALLOC.Cliente (Cliente_Datos, Cliente_Nacionalidad, Cliente_Rol)
                          values((select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales), @nacionalidad, 8) --HARDCODEADO EL ROL
                          
Insert into NENE_MALLOC.Usuario(Usuario_datos, Usuario_name, Usuario_pass)
                         values((select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales),
                         ('Usuario'+convert(varchar(30),@id_cli)),
                         '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
                         
Insert into NENE_MALLOC.Usuario_Por_Rol(Usuario_Id, Rol_Id)
                                 values((select Max(Usuario_Id) from NENE_MALLOC.Usuario),
                                        (select Rol_Id from NENE_MALLOC.Rol where Rol_Desc='Guest'))
                                        
fetch cursor_migracion_cliente into @nacionalidad, @nombre, @apellido, @mail, @dom_calle,@dom_nro, 
                                    @dom_piso, @dom_depto, @fecha_nac
                                    
end
close cursor_migracion_cliente
deallocate cursor_migracion_cliente
 
GO

--Faltan en la maestra Hotel_Nombre, Hotel_Mail, Hotel_Telefono, Hotel_Pais, Hotel_Fecha_Creacion, 
--Cliente_Telefono, Cliente_Nro_Documento, Cliente_Tipo_Doc