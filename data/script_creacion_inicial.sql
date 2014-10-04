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
		Hotel_Nombre nvarchar(255) default '',
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
		Habitacion_Desc nvarchar(255) default '', --esto no se, por ahi el enunciado se referia a la desc del tipo
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
		Reserva_FechaIng datetime,
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

CREATE TABLE NENE_MALLOC.Tipo_Item_Factura (
		Tipo_Item_Factura_Id numeric(18,0) primary key,
		)
GO

CREATE TABLE NENE_MALLOC.Estadia(
		Estadia_Id numeric(18,0) primary key references NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id),
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
		Consumible_Por_Estadia numeric(18,0) primary key references NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id),
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

--REGIMEN

Insert into NENE_MALLOC.Regimen(Regimen_Desc, Regimen_Precio)
                               (select distinct Regimen_Descripcion, Regimen_Precio
                                from gd_esquema.Maestra)
GO                                

--TIPO DE HABITACIÓN

Insert into NENE_MALLOC.Tipo_Habitacion(Tipo_Hab_Id, Tipo_Hab_Desc, Tipo_Hab_Porc)
                                       (select distinct Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
                                        from gd_esquema.Maestra)    
GO                                      
--HOTEL

Insert into NENE_MALLOC.Hotel(Hotel_Calle, Hotel_Nro_Calle, Hotel_Ciudad, Hotel_Cant_Est, Hotel_Recarga_Estrella)
			(select distinct Hotel_Calle, 
							 Hotel_Nro_Calle, 
							 Hotel_Ciudad,
							 Hotel_CantEstrella,
							 Hotel_Recarga_Estrella
			 from gd_esquema.Maestra)
GO     

--REGIMEN POR HOTEL
Declare
@calle nvarchar(255),
@nro_calle nvarchar(255),
@ciudad nvarchar(255),
@regimen nvarchar(255)
Declare cursor_migracion_regimen_por_hotel cursor 
	for (select distinct Hotel_Calle, 
					     Hotel_Nro_Calle, 
						 Hotel_Ciudad,
						 Regimen_Descripcion
		 from gd_esquema.Maestra)
		 
open cursor_migracion_regimen_por_hotel
fetch cursor_migracion_regimen_por_hotel into @calle, @nro_calle, @ciudad, @regimen
while(@@fetch_status=0)
begin 
					   
declare @hotel_id numeric(18,0)
set @hotel_id = (select Hotel_Id 
                 from NENE_MALLOC.Hotel h 
                 where h.Hotel_Calle = @calle 
                   and h.Hotel_Nro_Calle = @nro_calle
                   and h.Hotel_Ciudad = @ciudad)	
		 
Insert into NENE_MALLOC.Regimen_Por_Hotel(Regimen_Id, Hotel_Id) 
                                  values ((select Regimen_Id from NENE_MALLOC.Regimen where Regimen_Desc = @regimen),
                                          @hotel_id)       
 
fetch cursor_migracion_regimen_por_hotel into @calle, @nro_calle, @ciudad,@regimen
end
close cursor_migracion_regimen_por_hotel
deallocate cursor_migracion_regimen_por_hotel

GO
                       
--HABITACION
Declare
@calle nvarchar(255),
@nro_calle nvarchar(255),
@ciudad nvarchar(255),
@habitacion_numero numeric(18,0),
@habitacion_piso numeric(18,0),
@habitacion_vista nvarchar(50),
@habitacion_tipo numeric(18,0)
Declare cursor_migracion_hotel cursor
	for (select distinct Hotel_Calle, 
						 Hotel_Nro_Calle, 
						 Hotel_Ciudad,
						 Habitacion_Numero,
						 Habitacion_Piso,
						 Habitacion_Frente,
						 Habitacion_Tipo_Codigo
		 from gd_esquema.Maestra)
open cursor_migracion_hotel
fetch cursor_migracion_hotel into @calle, @nro_calle, @ciudad,@habitacion_numero, @habitacion_piso, 
                                  @habitacion_vista, @habitacion_tipo
                                    					      
while(@@fetch_status=0)
begin 
					   
declare @hotel_id numeric(18,0)
set @hotel_id = (select Hotel_Id 
                 from NENE_MALLOC.Hotel h 
                 where h.Hotel_Calle = @calle 
                   and h.Hotel_Nro_Calle = @nro_calle
                   and h.Hotel_Ciudad = @ciudad)		
				
Insert into NENE_MALLOC.Habitacion(Habitacion_Num, Habitacion_Piso, Habitacion_Hotel, Habitacion_Tipo, Habitacion_Vista)
                            values(@habitacion_numero,@habitacion_piso, @hotel_id, @habitacion_tipo, @habitacion_vista)
                                          
fetch cursor_migracion_hotel into @calle, @nro_calle, @ciudad,@habitacion_numero, @habitacion_piso, 
                                  @habitacion_vista, @habitacion_tipo
                                    					      
end
close cursor_migracion_hotel
deallocate cursor_migracion_hotel
GO

--CLIENTE, DATOS_PERSONALES, USUARIO, USUARIO_POR_ROL (ESTA TARDA 3 minutos!!!!) casi 1 min ahora

Declare
@nacionalidad nvarchar(255),
@nombre nvarchar(255),
@apellido nvarchar(255),
--@telefono numeric(18,0),
@tipo_ident nvarchar(30),
@nro_ident numeric(18,0),
@mail nvarchar(255),
@dom_calle nvarchar(255),
@dom_nro numeric(18,0),
@dom_piso numeric(18,0),
@dom_depto nvarchar(50),
@fecha_nac datetime,
@id_cli numeric(18,0)
Declare cursor_migracion_cliente cursor
	for(select distinct Cliente_Nacionalidad,
						Cliente_Nombre,
					    Cliente_Apellido,
						Cliente_Mail,
						Cliente_Dom_Calle,
						Cliente_Nro_Calle,
						Cliente_Piso,
						Cliente_Depto,
						Cliente_Fecha_Nac,
						Cliente_Pasaporte_Nro
			   
		from gd_esquema.Maestra)
Open cursor_migracion_cliente
fetch cursor_migracion_cliente into @nacionalidad, @nombre, @apellido, @mail, @dom_calle,@dom_nro, 
                                    @dom_piso, @dom_depto, @fecha_nac, @nro_ident
while(@@fetch_status=0)
begin 

/*set @id_cli = (select MAX(Usuario_Id)from NENE_MALLOC.Usuario)
if (@id_cli is null)
	begin
	set @id_cli = 1
	end
else 
	begin 
	set @id_cli= @id_cli +1
	end*/

set @tipo_ident= 'Pasaporte'	
--userpass es 123456 con sha256

Insert into NENE_MALLOC.Datos_Personales(Datos_Nombre,Datos_Apellido,Datos_Mail,Datos_Dom_Calle, Datos_Dom_Nro_Calle,
                                         Datos_Dom_Piso, Datos_Dom_Depto, Datos_Fecha_Nac, Datos_Tipo_Ident, Datos_Nro_Ident)
                                  values(@nombre, @apellido,@mail,@dom_calle,@dom_nro,@dom_piso,
                                         @dom_depto,@fecha_nac, @tipo_ident, @nro_ident)
                                      
Insert into NENE_MALLOC.Cliente (Cliente_Datos, Cliente_Nacionalidad, Cliente_Rol)
                          values((select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales), @nacionalidad, 3) --HARDCODEADO EL ROL


								----------------------------------------------------------------
/*								
--guarda con esto, los clientes no se loguean, no tienen usuario
                          
Insert into NENE_MALLOC.Usuario(Usuario_datos, Usuario_name, Usuario_pass)
                         values((select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales),
                         ('Usuario'+convert(varchar(30),@id_cli)),
                         '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
                         
Insert into NENE_MALLOC.Usuario_Por_Rol(Usuario_Id, Rol_Id)
                                 values((select Max(Usuario_Id) from NENE_MALLOC.Usuario),
                                        (select Rol_Id from NENE_MALLOC.Rol where Rol_Desc='Guest'))*/

								----------------------------------------------------------------
                                        
fetch cursor_migracion_cliente into @nacionalidad, @nombre, @apellido, @mail, @dom_calle,@dom_nro, 
                                    @dom_piso, @dom_depto, @fecha_nac, @nro_ident
                                    
end
close cursor_migracion_cliente
deallocate cursor_migracion_cliente
 
GO


--------------------------HASTA ACÁ CREO QUE MIGRA BIEN---------------------------------------------------------
--RESERVA(ESTA NO ESTÁ FUNCIONANDO POR EL ID_CLIENTE!!!!) 


/*
Declare
@codigo numeric(18,0),
@fecha_ingreso datetime,
@cant_noches numeric(18,0),
@mail nvarchar(255),
@nacimiento datetime,
@calle nvarchar(255),
@nro_calle nvarchar(255),
@ciudad nvarchar(255)
Declare cursor_migracion_reserva cursor
	for(select distinct Reserva_Codigo,
						Reserva_Fecha_Inicio,
						Reserva_Cant_Noches,
						Cliente_Mail,
						Cliente_Fecha_Nac,
						Hotel_Calle, 
						Hotel_Nro_Calle, 
						Hotel_Ciudad 
		from gd_esquema.Maestra)

Open cursor_migracion_reserva
fetch cursor_migracion_reserva into @codigo, @fecha_ingreso, @cant_noches, @mail, @nacimiento, @calle, @nro_calle, @ciudad

while(@@fetch_status=0)
begin 	

declare @hotel_id numeric(18,0)
declare @cliente_id numeric(18,0)
set @hotel_id = (select h.Hotel_Id 
                 from NENE_MALLOC.Hotel h 
                 where h.Hotel_Calle = @calle 
                   and h.Hotel_Nro_Calle = @nro_calle
                   and h.Hotel_Ciudad = @ciudad)
set @cliente_id = (select c.Cliente_Id 
                   from NENE_MALLOC.Cliente c, NENE_MALLOC.Datos_Personales d 
                   where d.Datos_Mail = @mail
					-- and d.Datos_Fecha_Nac = @nacimiento
                     and c.Cliente_Datos = d.Datos_Id)
                   	

Insert into NENE_MALLOC.Reserva(Reserva_Id, Reserva_FechaIng, Reserva_Fecha, Reserva_CantNoches, Reserva_Cliente, 
                                Reserva_Hotel)
                         values(@codigo, @fecha_ingreso, @fecha_ingreso, @cant_noches, @cliente_id, @hotel_id)

fetch cursor_migracion_reserva into @codigo, @fecha_ingreso, @cant_noches, @mail, @nacimiento, @calle, @nro_calle, @ciudad
end
close cursor_migracion_reserva
deallocate cursor_migracion_reserva
 */
GO	

--Nota: El cursor esta bien hecho, anda bien, el tema es que son 100 mil reservas y tarda demasiado, lo cancele y recien habia insertado 2 mil en 2min
-- Resulta que para los clientes se inserta en Clientes y Datos Personales a la par, por lo tanto los Cliente_Id y Cliente_Datos coinciden (obvio que solo para la migracion)
-- Entonces el problema estaba en que al buscar el id cliente tenia que pegarle a muchas tablas y con el cursor se le hacia largo, de ahi se me ocurrio usar insert masivo y la tabla Datos_Personales para sacar el Cliente_Id

insert into NENE_MALLOC.Reserva(Reserva_Id, Reserva_CantNoches, Reserva_FechaIng, Reserva_Fecha, Reserva_Hotel, Reserva_Cliente) 
	(select distinct g.Reserva_Codigo, g.Reserva_Cant_Noches, g.Reserva_Fecha_Inicio, g.Reserva_Fecha_Inicio,
		(select h.Hotel_Id from NENE_MALLOC.Hotel h 
				where h.Hotel_Calle=g.Hotel_Calle and
					  h.Hotel_Nro_calle=g.Hotel_Nro_Calle and
					  h.Hotel_Ciudad=g.Hotel_Ciudad),
		(select d.Datos_Id from NENE_MALLOC.Datos_Personales d 
				where d.Datos_Mail= g.Cliente_Mail and
					  d.Datos_Fecha_Nac=g.Cliente_Fecha_Nac and
					  d.Datos_Nro_Ident=g.Cliente_Pasaporte_Nro)
		from gd_esquema.Maestra g)
		order by Reserva_Codigo 
GO


--RESERVA POR HABITACIÓN
/*
Declare
@reserva numeric(18,0),
@calle nvarchar(255),
@nro_calle nvarchar(255),
@ciudad nvarchar(255),
@habitacion_numero numeric(18,0),
@regimen nvarchar(255)
Declare cursor_migracion_reserva_por_habitacion cursor
	for (select Reserva_Codigo,
		   Hotel_Calle, 
		   Hotel_Nro_Calle,
		   Hotel_Ciudad,
		   Habitacion_Numero,
		   Regimen_Descripcion
	from gd_esquema.Maestra)
Open cursor_migracion_reserva_por_habitacion
fetch cursor_migracion_reserva_por_habitacion into @reserva, @calle, @nro_calle, @ciudad, @habitacion_numero, @regimen
while(@@fetch_status=0)
begin 	

declare @hotel_id numeric(18,0)
declare @habitacion_id numeric(18,0)
declare @regimen_id numeric(18,0)

set @hotel_id = (select h.Hotel_Id 
                 from NENE_MALLOC.Hotel h 
                 where h.Hotel_Calle = @calle 
                   and h.Hotel_Nro_Calle = @nro_calle
                   and h.Hotel_Ciudad = @ciudad)

set @habitacion_id = (select ha.Habitacion_Id 
					  from NENE_MALLOC.Hotel ho, NENE_MALLOC.Habitacion ha
					  where ha.Habitacion_Hotel = @hotel_id
                        and ha.Habitacion_Num = @habitacion_numero)
                   
set @regimen_id = (select r.Regimen_Id from NENE_MALLOC.Regimen r where r.Regimen_Desc = @regimen)

Insert into NENE_MALLOC.Reserva_Por_Habitacion(Reserva_Id, Habitacion_Id, Regimen_Id)
                                        values(@reserva,@habitacion_id,@regimen_id)

fetch cursor_migracion_reserva_por_habitacion into @reserva, @calle, @nro_calle, @ciudad, @habitacion_numero, @regimen
end
close cursor_migracion_reserva_por_habitacion
deallocate cursor_migracion_reserva_por_habitacion
*/
GO


-- Con este pasaba lo mismo que con el de arriba :S
insert into NENE_MALLOC.Reserva_Por_Habitacion(Reserva_Id, Habitacion_Id, Regimen_Id)
			(select distinct g.Reserva_Codigo,
				    (select h.Habitacion_Id from NENE_MALLOC.Habitacion h
							where h.Habitacion_Num= g.Habitacion_Numero and
								  h.Habitacion_Hotel=(select ho.Hotel_Id from NENE_MALLOC.Hotel ho
														where ho.Hotel_Calle=g.Hotel_Calle and
															  ho.Hotel_Nro_Calle=g.Hotel_Nro_Calle and
															  ho.Hotel_Ciudad=g.Hotel_Ciudad) ),
					(select r.Regimen_Id from NENE_MALLOC.Regimen r where r.Regimen_Desc = g.Regimen_Descripcion) 
	from gd_esquema.Maestra g)
	order by g.Reserva_Codigo
GO

--------------------------HASTA ACÁ MIGRA BIEN---------------------------------------------------------
GO


--ESTADIA, TIPO ITEM FACTURA, ESTADIA POR CLIENTE (HAY PROBLEMAS CON EL ID DE CLIENTE POR LOS CAMPOS REPETIDOS)
Declare
@reserva_id numeric(18,0), 
@mail nvarchar(255), 
@fecha datetime                   
Declare cursor_migracion_estadia cursor
	for (select distinct Reserva_Codigo, Cliente_Mail, Cliente_Fecha_Nac
         from gd_esquema.Maestra
         where Estadia_Cant_Noches is not null 
           and Estadia_Fecha_Inicio is not null)   
           
Open cursor_migracion_estadia
fetch cursor_migracion_estadia into @reserva_id, @mail, @fecha
                             
while(@@fetch_status=0)
begin 

declare @id_tipo_fact numeric(18,0)
set @id_tipo_fact = (select MAX(Tipo_Item_Factura_Id)from NENE_MALLOC.Tipo_Item_Factura)
if (@id_tipo_fact is null)
	begin
	set @id_tipo_fact = 1
	end
else 
	begin 
	set @id_tipo_fact= @id_tipo_fact +1
	end
	
declare @cliente_id numeric(18,0)
set @cliente_id = (select c.Cliente_Id
                   from NENE_MALLOC.Cliente c, NENE_MALLOC.Datos_Personales d
                   where c.Cliente_Datos = d.Datos_Id
                     and d.Datos_Mail = @mail
                     and d.Datos_Fecha_Nac = @fecha)

Insert into NENE_MALLOC.Tipo_Item_Factura(Tipo_Item_Factura_Id) values (@id_tipo_fact)
	
Insert into NENE_MALLOC.Estadia(Estadia_Id,Estadia_Reserva) values(@id_tipo_fact, @reserva_id)

Insert into NENE_MALLOC.Estadia_Por_Cliente(Estadia_Id, Cliente_Id) values (@id_tipo_fact, @cliente_id)


/*Que onda con esto? En la maestra solo facturan consumibles!!!!
Insert into NENE_MALLOC.Item_Factura(Item_Factura_Cantidad, Item_Factura_Monto, Tipo_Item_Factura_Id, Item_Factura)
                              values(@item_cant, @item_monto, @id_tipo_fact, @factura_id)  */
fetch cursor_migracion_estadia into @reserva_id, @mail, @fecha
end	
close cursor_migracion_estadia
deallocate cursor_migracion_estadia

GO

--CONSUMIBLE
Declare 
@codigo numeric(18,0),
@descripcion nvarchar(255),
@precio numeric(18,2),
@item_cant numeric(18,0),
@item_monto numeric(18,2),
@factura_id numeric(18,0),
@reserva_id numeric(18,0)
Declare cursor_migracion_consumible cursor
	for(select Consumible_Codigo, 
	           Consumible_Descripcion, 
	           Consumible_Precio,
	           Item_Factura_Cantidad,
	           Item_Factura_Monto,
	           Factura_Nro,
	           Reserva_Codigo
        from gd_esquema.Maestra
        where Consumible_Codigo is not null)

Open cursor_migracion_consumible
fetch cursor_migracion_consumible into @codigo, @descripcion, @precio, @item_cant, @item_monto, @factura_id
while(@@fetch_status=0)
begin 

declare @id_tipo_fact numeric(18,0)
set @id_tipo_fact = (select MAX(Tipo_Item_Factura_Id)from NENE_MALLOC.Tipo_Item_Factura)
if (@id_tipo_fact is null)
	begin
	set @id_tipo_fact = 1
	end
else 
	begin 
	set @id_tipo_fact= @id_tipo_fact +1
	end

declare @estadia_id numeric(18,0)
set @estadia_id = (select Estadia_Id from NENE_MALLOC.Estadia where Estadia_Reserva = @reserva_id)
        
Insert into NENE_MALLOC.Consumible(Consumible_Id, Consumible_Desc, Consumible_precio)
                            values(@codigo, @descripcion, @precio)

Insert into NENE_MALLOC.Consumible_Por_Estadia(Consumible_Por_Estadia, Consumible_Id, Estadia_Id, Consumible_Cantidad)
                                        values(@id_tipo_fact, @codigo, @estadia_id, @item_cant)

Insert into NENE_MALLOC.Item_Factura(Item_Factura_Cantidad, Item_Factura_Monto, Tipo_Item_Factura_Id, Item_Factura)
                              values(@item_cant, @item_monto, @id_tipo_fact, @factura_id)             

/*Hay que saber que habitacion consumio que cosa*/                                           
fetch cursor_migracion_consumible into @codigo, @descripcion, @precio, @item_cant, @item_monto, @factura_id
end
close cursor_migracion_consumible
deallocate cursor_migracion_consumible

GO

--FACTURA
Declare 
@codigo numeric(18,0),
@cliente_mail nvarchar(255),
@nacimiento datetime,
@fecha datetime,
@total numeric(18,2)
Declare cursor_migracion_factura cursor
	for(select distinct Factura_Nro,
					    Cliente_Mail,
					    Cliente_Fecha_Nac,
					    Factura_Fecha,
					    Factura_Total
	    from gd_esquema.Maestra
	    where Factura_Nro is not null)
	    
Open cursor_migracion_factura
fetch cursor_migracion_factura into @codigo, @cliente_mail, @nacimiento, @fecha, @total
while(@@fetch_status=0)
begin 	

declare @cliente_id numeric(18,0)
set @cliente_id = (select c.Cliente_Id
                   from NENE_MALLOC.Cliente c, NENE_MALLOC.Datos_Personales d 
                   where c.Cliente_Datos = d.Datos_Id
                     and d.Datos_Mail = @cliente_mail
                     and d.Datos_Fecha_Nac = @nacimiento)

Insert into NENE_MALLOC.Factura(Factura_Id, Factura_Cliente, Factura_Fecha, Factura_Total)
                         values(@codigo, @cliente_id, @fecha, @total)

fetch cursor_migracion_factura into @codigo, @cliente_mail, @nacimiento, @fecha, @total
end
close cursor_migracion_factura
deallocate cursor_migracion_factura
GO

select * from NENE_MALLOC.Factura

--Faltan en la maestra Hotel_Nombre, Hotel_Mail, Hotel_Telefono, Hotel_Pais, Hotel_Fecha_Creacion, 
--Cliente_Telefono, Cliente_Nro_Documento, Cliente_Tipo_Doc