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
		Usuario_Deshabilitado bit default 0,
		Usuario_Baja bit default 0,
		Usuario_datos numeric(18,0) references NENE_MALLOC.Datos_Personales(Datos_Id)
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

CREATE TABLE NENE_MALLOC.Usuario_Por_Rol_Por_Hotel(
		Usuario_Id numeric(18,0) references NENE_MALLOC.Usuario(Usuario_Id),
		Hotel_Id numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id),
		Rol_Id numeric(18,0) references NENE_MALLOC.Rol(Rol_Id)
		Primary Key(Usuario_Id, Hotel_Id, Rol_Id)
	
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
		)
GO		

CREATE TABLE NENE_MALLOC.Reserva(
		Reserva_Id numeric(18,0) primary key,
		Reserva_Cliente numeric(18,0) references NENE_MALLOC.Cliente(Cliente_Id),
		Reserva_Fecha datetime,
		Reserva_FechaIng datetime,
		Reserva_CantNoches numeric(18,0), --de nuevo por la maestra, despues vemos cual sacamos si fecha fin o este
		Reserva_Estado nvarchar(255),
		Reserva_Regimen numeric(18,0) references NENE_MALLOC.Regimen(Regimen_Id),
		Reserva_Hotel numeric(18,0) references NENE_MALLOC.Hotel(Hotel_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Reserva_Por_Habitacion(
		RPH_Id numeric(18,0) primary key identity, --le tuve que agregar esto porque si mandaba que Estadia_Reserva referenciara a Reserva Id de aca rompia porque habia dos pks
		Reserva_Id numeric(18,0) references NENE_MALLOC.Reserva(Reserva_Id) not null,
		Habitacion_Id numeric(18,0) references NENE_MALLOC.Habitacion(Habitacion_Id)not null,
		Unique(Reserva_Id,Habitacion_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Consumible(
		Consumible_Id numeric(18,0) primary key,
		Consumible_Desc nvarchar(255),
		Consumible_precio numeric(18,2)
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
		Item_Factura_Id numeric(18,0) primary key,
		Item_Factura_Cantidad numeric(18,0) default 1,
		Item_Factura_Monto numeric(18,2),
		Item_Factura numeric(18,0) references NENE_MALLOC.Factura(Factura_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Consumible_Por_Habitacion(
		Consumible_Por_Habitacion_Id numeric(18,0) primary key references NENE_MALLOC.Item_Factura(Item_Factura_Id),
		Consumible_Id numeric(18,0) references NENE_MALLOC.Consumible(Consumible_Id),
		RPH_Id numeric(18,0) references NENE_MALLOC.Reserva_Por_Habitacion(RPH_Id),
		Consumible_Cantidad numeric(18,0)
		)
GO

CREATE TABLE NENE_MALLOC.Estadia(
		Estadia_Id numeric(18,0) primary key references NENE_MALLOC.Item_Factura(Item_Factura_Id),
		Estadia_Reserva numeric(18,0) references NENE_MALLOC.Reserva(Reserva_Id)
		)
GO

CREATE TABLE NENE_MALLOC.Estadia_Por_Cliente(
		Cliente_Id numeric(18,0) references NENE_MALLOC.Cliente(Cliente_Id),
		Estadia_Id numeric(18,0) references NENE_MALLOC.Estadia(Estadia_Id),
		Primary Key (Cliente_Id,Estadia_Id)
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

Insert into NENE_MALLOC.Regimen_Por_Hotel(Hotel_Id, Regimen_Id)
	(select distinct (select h.Hotel_Id from NENE_MALLOC.Hotel h 
							where h.Hotel_Calle=g.Hotel_Calle and
								  h.Hotel_Nro_Calle=g.Hotel_Nro_Calle and 
								h.Hotel_Ciudad=g.Hotel_Ciudad),
					 (select r.Regimen_Id from NENE_MALLOC.Regimen r 
							where r.Regimen_Desc= g.Regimen_Descripcion)
		 from gd_esquema.Maestra g)
GO
                       
--HABITACION
Insert into NENE_MALLOC.Habitacion(Habitacion_Num, Habitacion_Piso, Habitacion_Hotel, Habitacion_Tipo, Habitacion_Vista)
				(select distinct g.Habitacion_Numero,
						 g.Habitacion_Piso,
						 (select h.Hotel_Id from NENE_MALLOC.Hotel h 
							where h.Hotel_Calle=g.Hotel_Calle and 
								  h.Hotel_Nro_Calle=g.Hotel_Nro_Calle and 
								  h.Hotel_Ciudad=g.Hotel_Ciudad),
						 g.Habitacion_Tipo_Codigo,
						 g.Habitacion_Frente
		 from gd_esquema.Maestra g)
GO
 

--CLIENTE, DATOS_PERSONALES

Insert into NENE_MALLOC.Datos_Personales(Datos_Nombre,Datos_Apellido,Datos_Mail,Datos_Dom_Calle, Datos_Dom_Nro_Calle,
                                         Datos_Dom_Piso, Datos_Dom_Depto, Datos_Fecha_Nac, Datos_Tipo_Ident, Datos_Nro_Ident)
			(select distinct Cliente_Nombre,
					    Cliente_Apellido,
						Cliente_Mail,
						Cliente_Dom_Calle,
						Cliente_Nro_Calle,
						Cliente_Piso,
						Cliente_Depto,
						Cliente_Fecha_Nac,
						'Pasaporte',
						Cliente_Pasaporte_Nro
					from gd_esquema.Maestra)

Insert into NENE_MALLOC.Cliente (Cliente_Nacionalidad)
(select Cliente_Nacionalidad
		from gd_esquema.Maestra 
			group by Cliente_Mail,Cliente_Fecha_Nac,Cliente_Pasaporte_Nro,Cliente_Nacionalidad)

update NENE_MALLOC.Cliente
	set Cliente_Datos=s.datos_id
	from  (select d.Datos_Id datos_id from NENE_MALLOC.Datos_Personales d)s
		where datos_id=Cliente_Id
GO



-- Resulta que para los clientes se inserta en Clientes y Datos Personales a la par, por lo tanto los Cliente_Id y Cliente_Datos coinciden (obvio que solo para la migracion)

--RESERVA
insert into NENE_MALLOC.Reserva(Reserva_Id, Reserva_CantNoches, Reserva_FechaIng, Reserva_Fecha, Reserva_Hotel, 
								Reserva_Regimen, Reserva_Cliente) 
	(select distinct g.Reserva_Codigo, g.Reserva_Cant_Noches, g.Reserva_Fecha_Inicio, g.Reserva_Fecha_Inicio,
		(select h.Hotel_Id from NENE_MALLOC.Hotel h 
				where h.Hotel_Calle=g.Hotel_Calle and
					  h.Hotel_Nro_calle=g.Hotel_Nro_Calle and
					  h.Hotel_Ciudad=g.Hotel_Ciudad),
		(select r.Regimen_Id from NENE_MALLOC.Regimen r where r.Regimen_Desc = g.Regimen_Descripcion),
		(select d.Datos_Id from NENE_MALLOC.Datos_Personales d 
				where d.Datos_Mail= g.Cliente_Mail and
					  d.Datos_Fecha_Nac=g.Cliente_Fecha_Nac and
					  d.Datos_Nro_Ident=g.Cliente_Pasaporte_Nro)
		from gd_esquema.Maestra g)
		order by Reserva_Codigo 

update NENE_MALLOC.Reserva
	set Reserva_Estado= 'Efectivizada'
		from (select distinct Reserva_Codigo from gd_esquema.Maestra where Estadia_Fecha_Inicio is not null)t
			where Reserva_Id=t.Reserva_Codigo

GO

--RESERVA POR HABITACIÓN
insert into NENE_MALLOC.Reserva_Por_Habitacion(Reserva_Id, Habitacion_Id)
			(select distinct g.Reserva_Codigo,
				    (select h.Habitacion_Id from NENE_MALLOC.Habitacion h
							where h.Habitacion_Num= g.Habitacion_Numero and
								  h.Habitacion_Hotel=(select ho.Hotel_Id from NENE_MALLOC.Hotel ho
														where ho.Hotel_Calle=g.Hotel_Calle and
															  ho.Hotel_Nro_Calle=g.Hotel_Nro_Calle and
															  ho.Hotel_Ciudad=g.Hotel_Ciudad) ) 
				from gd_esquema.Maestra g)
				order by g.Reserva_Codigo
GO

--FACTURA
Insert into NENE_MALLOC.Factura(Factura_Id, Factura_Cliente, Factura_Fecha, Factura_Total)
	(select distinct g.Factura_Nro,
	                (select d.Datos_Id from NENE_MALLOC.Datos_Personales d 
					 where d.Datos_Mail= g.Cliente_Mail and
						   d.Datos_Fecha_Nac=g.Cliente_Fecha_Nac and
					       d.Datos_Nro_Ident=g.Cliente_Pasaporte_Nro),
					 g.Factura_Fecha,
					 g.Factura_Total			       
	 from gd_esquema.Maestra g
	 where g.Factura_Nro is not null)
	 order by g.Factura_Nro
GO

--CONSUMIBLE
Insert into NENE_MALLOC.Consumible(Consumible_Id, Consumible_Desc, Consumible_precio)
            (select distinct Consumible_Codigo,
							 Consumible_Descripcion,
							 Consumible_Precio
             from gd_esquema.Maestra
             where Consumible_Codigo is not null)
GO

--ESTADIA, TIPO ITEM FACTURA, ESTADIA POR CLIENTE
Declare
@reserva_id numeric(18,0),   
@item_cant numeric(18,0),
@item_monto numeric(18,2),
@fact_num numeric(18,0)             
Declare cursor_migracion_estadia cursor
	for (select Reserva_Codigo, Item_Factura_Cantidad, Item_Factura_Monto, Factura_Nro
         from gd_esquema.Maestra
         where Estadia_Cant_Noches is not null and
			   Estadia_Fecha_Inicio is not null and
			   Item_Factura_Cantidad is not null and
			   Consumible_Codigo is null)   
           
Open cursor_migracion_estadia
fetch cursor_migracion_estadia into @reserva_id, @item_cant, @item_monto, @fact_num
                             
while(@@fetch_status=0)
begin 

declare @id_item_fact numeric(18,0)
set @id_item_fact = (ISNULL((select MAX(Item_Factura_Id)from NENE_MALLOC.Item_Factura),0)) + 1
	
Insert into NENE_MALLOC.Item_Factura(Item_Factura_Id, Item_Factura_Cantidad, Item_Factura_Monto, Item_Factura) 
					values (@id_item_fact, @item_cant, @item_monto, @fact_num)
	
Insert into NENE_MALLOC.Estadia(Estadia_Id,Estadia_Reserva) values(@id_item_fact, @reserva_id)

fetch cursor_migracion_estadia into @reserva_id, @item_cant, @item_monto, @fact_num
end	
close cursor_migracion_estadia
deallocate cursor_migracion_estadia
GO


--ESTADIA POR CLIENTE

Insert into NENE_MALLOC.Estadia_Por_Cliente(Estadia_Id, Cliente_Id)
	(select distinct 
			(select e.Estadia_Id
			 from NENE_MALLOC.Estadia e
			 where e.Estadia_Reserva = g.Reserva_Codigo),
			 (select d.Datos_Id from NENE_MALLOC.Datos_Personales d 
			  where d.Datos_Mail= g.Cliente_Mail and
			        d.Datos_Fecha_Nac=g.Cliente_Fecha_Nac and
					d.Datos_Nro_Ident=g.Cliente_Pasaporte_Nro)
         from gd_esquema.Maestra g
         where g.Estadia_Cant_Noches is not null 
           and g.Estadia_Fecha_Inicio is not null)  

GO       

--CONSUMIBLE POR HABITACION 2.42
-- Los consumibles estan siempre facturados

Declare 
@codigo numeric(18,0),
@item_cant numeric(18,0),
@item_monto numeric(18,2),
@factura_id numeric(18,0),
@reserva_id numeric(18,0),
@numero_habitacion numeric(18,0)
Declare cursor_migracion_consumible cursor
	for(select distinct Consumible_Codigo, 
					    Item_Factura_Cantidad,
					    Item_Factura_Monto,
					    Factura_Nro,
					    Reserva_Codigo,
					    Habitacion_Numero
        from gd_esquema.Maestra
        where Consumible_Codigo is not null)

           
Open cursor_migracion_consumible
fetch cursor_migracion_consumible into @codigo, @item_cant, @item_monto, @factura_id, @reserva_id, @numero_habitacion
                             
while(@@fetch_status=0)
begin 

declare @id_item_fact numeric(18,0)
set @id_item_fact = (ISNULL((select MAX(Item_Factura_Id)from NENE_MALLOC.Item_Factura),0)) + 1

declare @reserva_por_habitacion numeric(18,0)
set @reserva_por_habitacion = (select r.RPH_Id 
							   from NENE_MALLOC.Reserva_Por_Habitacion r,NENE_MALLOC.Habitacion h
							   where @reserva_id = r.Reserva_Id and
									 r.Habitacion_Id=h.Habitacion_Id and
						             @numero_habitacion = h.Habitacion_Num)


Insert into NENE_MALLOC.Item_Factura(Item_Factura_Id, Item_Factura_Cantidad, Item_Factura_Monto, Item_Factura)
										values(@id_item_fact, @item_cant, @item_monto, @factura_id)

Insert into NENE_MALLOC.Consumible_Por_Habitacion(Consumible_Por_Habitacion_Id, Consumible_Id, RPH_Id, 
												  Consumible_Cantidad)
                                        values(@id_item_fact, @codigo, @reserva_por_habitacion, @item_cant)           

fetch cursor_migracion_consumible into @codigo, @item_cant, @item_monto, @factura_id, @reserva_id, @numero_habitacion
end
close  cursor_migracion_consumible
deallocate cursor_migracion_consumible                              
GO
			     

------------------------------STORE PROCEDURES---------------------------------------------
--IMPORTANTE!! FORMATO DE STRING DE FECHAS TIENE QUE SER AAAAMMDD PARA QUE LO PODAMOS ASIGNAR DIRECTAMENTE A UN DATETIME.

--LOGIN (TESTEADOS TODOS LOS CASOS)

create Procedure NENE_MALLOC.login_usuario @usuario varchar(30),@userpass nvarchar(255),@return numeric(1,0) out
as 
begin
set @return=0 --El usuario ingresa correctamente
if exists (select Usuario_name from NENE_MALLOC.Usuario where Usuario_name=@usuario and Usuario_pass=@userpass)
	begin 
	update NENE_MALLOC.Usuario 
	set Usuario_Intentos = 0
	where Usuario_name = @usuario;
	declare @deshabilitado bit
	declare @baja bit
	set @deshabilitado = (select Usuario_Deshabilitado from NENE_MALLOC.Usuario where @usuario=Usuario_name)
	set @baja = (select Usuario_Baja from NENE_MALLOC.Usuario where @usuario=Usuario_name)
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
		if exists (select Usuario_name from NENE_MALLOC.Usuario where Usuario_name=@usuario and Usuario_pass!=@userpass)
		begin
			if((select Usuario_Intentos from NENE_MALLOC.Usuario where @usuario = Usuario_name) = 2)
			begin
				
				raiserror('La contraseña ingresada no es correcta y el usuario quedo inhabilitado',16,1)
				update NENE_MALLOC.Usuario set Usuario_Deshabilitado = 1
				where Usuario_name = @usuario
				set @return = 1
			end
			else
			begin
				update NENE_MALLOC.Usuario set Usuario_Intentos = Usuario_Intentos + 1
				where Usuario_name = @usuario;
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

--BAJA DEL ROL
create procedure NENE_MALLOC.baja_rol @rol nvarchar(255)
as
begin transaction
	
	update NENE_MALLOC.Rol
		 set Rol_estado = 1
		 where Rol_Desc = @rol
	
commit 
GO 

--MODIFICACION DE ROL
create procedure NENE_MALLOC.modificacion_rol @rol_id numeric(18,0), @descripcion nvarchar(255)
as
begin transaction
	
	if exists(select r.Rol_Desc from NENE_MALLOC.Rol r 
				where r.Rol_Desc = @descripcion)
		begin
			raiserror('El rol ya existe',16,1)
		end
	
	update NENE_MALLOC.Rol  
		set Rol_Desc = @descripcion
		where Rol_Id = @rol_id
commit
GO

-- ALTA DE FUNCIONALIDAD POR ROL.

create procedure  NENE_MALLOC.alta_funcionalidad_por_rol @funcionalidad nvarchar(255) , @rol nvarchar(255)
as
begin transaction
	
	if ((select r.Rol_estado from NENE_MALLOC.Rol r where r.Rol_Desc = @rol) = 1)
		begin
			rollback
			raiserror('El rol está dado de baja',16,1)
		end
		
	if(not(exists(select f.Func_Id from NENE_MALLOC.Funcionalidad f where @funcionalidad = Func_Desc)))
		begin 
			Insert into NENE_MALLOC.Funcionalidad(Func_Id, Func_Desc) values ((select MAX(Func_Id) from NENE_MALLOC.Funcionalidad) + 1, @funcionalidad)
		end
	
	Insert into NENE_MALLOC.Func_Por_Rol(Func_Id,Rol_Id) 
	values ((select f.Func_Id from NENE_MALLOC.Funcionalidad f where f.Func_Desc = @funcionalidad),
	        (select r.Rol_Id from NENE_MALLOC.Rol r where r.Rol_Desc = @rol))

commit
GO

-- BAJA DE FUNCIONALIDAD POR ROL.

create procedure  NENE_MALLOC.baja_funcionalidad_por_rol @funcionalidad nvarchar(255) , @rol nvarchar(255)
as
begin transaction
	
	declare @rol_id numeric(18,0)
	declare @func_id numeric(18,0)
	
	set @rol_id = (select r.Rol_Id from NENE_MALLOC.Rol r where r.Rol_Desc = @rol)
	set @func_id = (select f.Func_Id from NENE_MALLOC.Funcionalidad f where @funcionalidad = Func_Desc)
	
	if ((select r.Rol_estado from NENE_MALLOC.Rol r where r.Rol_Desc = @rol) = 1)
		begin
			rollback
			raiserror('El rol está dado de baja',16,1)
		end
		
	if (@rol_id is null)
		begin
			rollback
			raiserror('El rol no existe',16,1)
		end
		
	if(@func_id is null)
		begin 
			rollback
			raiserror('La funcionalidad no existe',16,1)
		end
		
	delete from NENE_MALLOC.Func_Por_Rol
	where Rol_Id = @rol_id and Func_Id = @func_id

commit
GO

--ALTA DE USUARIO (TESTEADOS TODOS LOS CASOS)

create procedure NENE_MALLOC.alta_usuario @username varchar(30), @pass nvarchar(255), @rol nvarchar(255), @nombre nvarchar(255), 
										  @apellido nvarchar(255), @telefono numeric(18,0), @tipo_ident nvarchar(30),
										  @nro_ident numeric(18,0), @mail nvarchar(255), @calle nvarchar(255),
										  @nro_calle numeric(18,0), @piso numeric(18,0), @depto nvarchar(50),
										  @fecha_nacimiento nvarchar(15), @hotel numeric(18,0)
as
begin transaction
	
	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Tipo_Ident = @tipo_ident and Datos_Nro_Ident = @nro_ident)
		begin
			rollback
			raiserror('Ya existe un usuario con ese tipo y numero de documento',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Usuario u where u.Usuario_name = @username)
		begin
			rollback
			raiserror('Ya existe un usuario con ese nombre de usuario',16,1)
			return
		end		

	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Mail = @mail)
		begin
			rollback
			raiserror('Ya existe un usuario con ese mail',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Telefono = @telefono)
		begin
			rollback
			raiserror('Ya existe un usuario con ese telefono',16,1)
			return
		end
		
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_nacimiento
	Insert into NENE_MALLOC.Datos_Personales(Datos_Nombre, Datos_Apellido, Datos_Telefono, Datos_Tipo_Ident,
											 Datos_Nro_Ident, Datos_Mail, Datos_Dom_Calle, Datos_Dom_Nro_Calle,
											 Datos_Dom_Piso, Datos_Dom_Depto, Datos_Fecha_Nac)
									  values(@nombre, @apellido, @telefono, @tipo_ident, @nro_ident, @mail,
									         @calle, @nro_calle, @piso, @depto, @fecha_correcta)
									         
    Insert into NENE_MALLOC.Usuario(Usuario_name, Usuario_pass, Usuario_datos)
                             values(@username, @pass, (select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales))
                             
        
    Insert into NENE_MALLOC.Usuario_Por_Rol_Por_Hotel(Usuario_Id, Hotel_Id, Rol_Id) 
			values ((select MAX(Usuario_Id) from NENE_MALLOC.Usuario), 
					@hotel, 
					(select Rol_Id from NENE_MALLOC.Rol where Rol_Desc = @rol) )

commit
GO

--MODIFICACION USUARIO
create procedure NENE_MALLOC.modificacion_usuario @username varchar(30), @pass nvarchar(255), @rol nvarchar(255), @nombre nvarchar(255), 
										  @apellido nvarchar(255), @telefono numeric(18,0), @tipo_ident nvarchar(30),
										  @nro_ident numeric(18,0), @mail nvarchar(255), @calle nvarchar(255),
										  @nro_calle numeric(18,0), @piso numeric(18,0), @depto nvarchar(50),
										  @fecha_nacimiento nvarchar(15), @hotel numeric(18,0), @usuario_id numeric(18,0)
as
begin transaction
	
	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Usuario u 
				where u.Usuario_datos = d.Datos_Id and
					  d.Datos_Tipo_Ident = @tipo_ident and 
					  d.Datos_Nro_Ident = @nro_ident and
					  u.Usuario_Id != @usuario_id)
		begin
			rollback
			raiserror('Ya existe un usuario con ese tipo y numero de documento',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Usuario u
				 where u.Usuario_name = @username and
					   u.Usuario_Id != @usuario_id)
		begin
			rollback
			raiserror('Ya existe un usuario con ese nombre de usuario',16,1)
			return
		end		

	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Usuario u 
				where u.Usuario_datos = d.Datos_Id and
					  d.Datos_Mail = @mail and
					  u.Usuario_Id != @usuario_id)
		begin
			rollback
			raiserror('Ya existe un usuario con ese mail',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Usuario u 
				where u.Usuario_datos = d.Datos_Id and
					  d.Datos_Telefono = @telefono and
					  u.Usuario_Id != @usuario_id)
		begin
			rollback
			raiserror('Ya existe un usuario con ese telefono',16,1)
			return
		end
		
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_nacimiento
	declare @datos_id numeric(18,0)
	set @datos_id = (select u.Usuario_datos from NENE_MALLOC.Usuario u
						where u.Usuario_Id = @usuario_id)
	
	
	update NENE_MALLOC.Datos_Personales
		set Datos_Nombre = @nombre,
			Datos_Apellido = @apellido,
			Datos_Telefono = @telefono,
			Datos_Tipo_Ident = @tipo_ident,
			Datos_Nro_Ident = @nro_ident,
			Datos_Mail = @mail,
			Datos_Dom_Calle = @calle, 
			Datos_Dom_Nro_Calle = @nro_calle,
			Datos_Dom_Piso = @piso, 
			Datos_Dom_Depto = @depto, 
			Datos_Fecha_Nac = @fecha_correcta		
		where Datos_Id = @datos_id
	
	update NENE_MALLOC.Usuario
		set Usuario_name = @username,
			Usuario_pass = @pass
		where Usuario_Id = @usuario_id
									         
commit
GO

--ALTA DE CLIENTE (TESTEADOS TODOS LOS CASOS)

create procedure NENE_MALLOC.alta_cliente @nombre nvarchar(255), @apellido nvarchar(255), @telefono numeric(18,0), 
										  @tipo_ident nvarchar(30), @nro_ident numeric(18,0), @mail nvarchar(255), 
										  @calle nvarchar(255), @nro_calle numeric(18,0), @piso numeric(18,0), 
										  @depto nvarchar(50), @fecha_nacimiento nvarchar(15), @nacionalidad nvarchar(255)
as
begin transaction
	
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Tipo_Ident = @tipo_ident and Datos_Nro_Ident = @nro_ident)
		begin
			rollback
			raiserror('Ya existe un cliente con ese tipo y numero de identificacion.',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Mail = @mail)
		begin
			rollback
			raiserror('Ya existe un cliente con ese mail.',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d where d.Datos_Telefono = @telefono)
		begin
			rollback
			raiserror('Ya existe un cliente con ese telefono.',16,1)
			return
		end
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_nacimiento
	
	Insert into NENE_MALLOC.Datos_Personales(Datos_Nombre, Datos_Apellido, Datos_Telefono, Datos_Tipo_Ident,
											 Datos_Nro_Ident, Datos_Mail, Datos_Dom_Calle, Datos_Dom_Nro_Calle,
											 Datos_Dom_Piso, Datos_Dom_Depto, Datos_Fecha_Nac)
									  values(@nombre, @apellido, @telefono, @tipo_ident, @nro_ident, @mail,
									         @calle, @nro_calle, @piso, @depto, @fecha_correcta)
									         
    Insert into NENE_MALLOC.Cliente(Cliente_Nacionalidad, Cliente_Datos)
                             values(@nacionalidad, (select MAX(Datos_Id) from NENE_MALLOC.Datos_Personales))
                             
commit
GO

--MODIFICACION CLIENTE
create procedure NENE_MALLOC.modificacion_cliente @nombre nvarchar(255), @apellido nvarchar(255), @telefono numeric(18,0), 
												  @tipo_ident nvarchar(30), @nro_ident numeric(18,0), @mail nvarchar(255), 
												  @calle nvarchar(255), @nro_calle numeric(18,0), @piso numeric(18,0), 
												  @depto nvarchar(50), @fecha_nacimiento nvarchar(15), @nacionalidad nvarchar(255),
												  @cliente_id numeric(18,0)
as
begin transaction
	
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Cliente c 
				where c.Cliente_Datos = d.Datos_Id and
					  d.Datos_Tipo_Ident = @tipo_ident and 
					  d.Datos_Nro_Ident = @nro_ident and
					  c.Cliente_Id != @cliente_id)
		begin
			rollback
			raiserror('Ya existe un cliente con ese tipo y numero de identificacion.',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Cliente c 
				where c.Cliente_Datos = d.Datos_Id and
					  d.Datos_Mail = @mail and
					  c.Cliente_Id != @cliente_id)
		begin
			rollback
			raiserror('Ya existe un cliente con ese mail.',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Datos_Personales d, NENE_MALLOC.Cliente c 
				where c.Cliente_Datos = d.Datos_Id and
					  d.Datos_Telefono = @telefono and
					  c.Cliente_Id != @cliente_id)
		begin
			rollback
			raiserror('Ya existe un cliente con ese telefono.',16,1)
			return
		end
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_nacimiento
	declare @datos_id numeric(18,0)
	set @datos_id = (select c.Cliente_Datos from NENE_MALLOC.Cliente c
						where c.Cliente_Id = @cliente_id )
	
	update NENE_MALLOC.Datos_Personales
	set Datos_Nombre = @nombre,
			Datos_Apellido = @apellido,
			Datos_Telefono = @telefono,
			Datos_Tipo_Ident = @tipo_ident,
			Datos_Nro_Ident = @nro_ident,
			Datos_Mail = @mail,
			Datos_Dom_Calle = @calle, 
			Datos_Dom_Nro_Calle = @nro_calle,
			Datos_Dom_Piso = @piso, 
			Datos_Dom_Depto = @depto, 
			Datos_Fecha_Nac = @fecha_correcta		
		where Datos_Id = @datos_id
		
	update NENE_MALLOC.Cliente
		set Cliente_Nacionalidad = @nacionalidad
		where Cliente_Id = @cliente_id

commit
GO

--ALTA DE HOTEL

create procedure NENE_MALLOC.alta_hotel @nombre nvarchar(255), @mail nvarchar(255), @telefono numeric(18,0),
                                        @calle nvarchar(255), @nro_calle numeric(18,0), @ciudad nvarchar(255),
                                        @pais nvarchar(255), @fecha_creacion nvarchar(15), @estrellas numeric(18,0),
                                        @recarga_estrella numeric(18,0)

as
begin transaction
	
	if exists(select *  from NENE_MALLOC.Hotel h where h.Hotel_Nombre = @nombre)
		begin
			rollback
			raiserror('Ya existe un hotel con este nombre',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Hotel h where h.Hotel_Mail = @mail)
		begin
			rollback
			raiserror('Ya existe un hotel con este mail',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Hotel h where h.Hotel_Telefono = @telefono)
		begin
			rollback
			raiserror('Ya existe un hotel con este telefono',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Hotel h where h.Hotel_Ciudad = @ciudad and
	                                                   h.Hotel_Pais = @pais and
	                                                   h.Hotel_Calle = @calle and
	                                                   h.Hotel_Nro_Calle = @nro_calle)
		begin
			rollback
			raiserror('Ya existe un hotel en esta direccion',16,1)
			return
		end	
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_creacion
		
	Insert into NENE_MALLOC.Hotel(Hotel_Nombre, Hotel_Mail, Hotel_Telefono, Hotel_Calle, Hotel_Nro_Calle, 
	                              Hotel_Ciudad, Hotel_Pais, Hotel_Fecha_Creacion, Hotel_Cant_Est, Hotel_Recarga_Estrella)
		                   values(@nombre, @mail, @telefono, @calle, @nro_calle, @ciudad, @pais, @fecha_correcta,
		                          @estrellas, @recarga_estrella)	                 
commit
GO

--MODIFICACIÓN DE HOTEL

create procedure NENE_MALLOC.modificacion_hotel @nombre nvarchar(255), @mail nvarchar(255), @telefono numeric(18,0),
												@calle nvarchar(255), @nro_calle numeric(18,0), @ciudad nvarchar(255),
												@pais nvarchar(255), @fecha_creacion nvarchar(15), @estrellas numeric(18,0),
												@recarga_estrella numeric(18,0), @hotel_id numeric(18,0)

as
begin transaction
	
	if exists(select *  from NENE_MALLOC.Hotel h 
				where h.Hotel_Nombre = @nombre and
				      h.Hotel_Id != @hotel_id)
		begin
			rollback
			raiserror('Ya existe un hotel con este nombre',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Hotel h 
				where h.Hotel_Mail = @mail and
				      h.Hotel_Id != @hotel_id)
		begin
			rollback
			raiserror('Ya existe un hotel con este mail',16,1)
			return
		end

	if exists(select *  from NENE_MALLOC.Hotel h 
				where h.Hotel_Telefono = @telefono and
				      h.Hotel_Id != @hotel_id)
		begin
			rollback
			raiserror('Ya existe un hotel con este telefono',16,1)
			return
		end
		
	if exists(select *  from NENE_MALLOC.Hotel h where h.Hotel_Ciudad = @ciudad and
	                                                   h.Hotel_Pais = @pais and
	                                                   h.Hotel_Calle = @calle and
	                                                   h.Hotel_Nro_Calle = @nro_calle and
													   h.Hotel_Id != @hotel_id)
		begin
			rollback
			raiserror('Ya existe un hotel en esta direccion',16,1)
			return
		end	
		
	declare @fecha_correcta datetime
	set @fecha_correcta = @fecha_creacion

	update NENE_MALLOC.Hotel
	set Hotel_Nombre = @nombre,
	    Hotel_Mail = @mail,
	    Hotel_Telefono = @telefono,
	    Hotel_Calle = @calle,
	    Hotel_Nro_Calle = @nro_calle,
	    Hotel_Ciudad = @ciudad,
	    Hotel_Pais = @pais,
	    Hotel_Fecha_Creacion = @fecha_correcta,
	    Hotel_Cant_Est = @estrellas,
	    Hotel_Recarga_Estrella = @recarga_estrella		
		where Hotel_Id = @hotel_id		
                 
commit
GO

--ALTA DE HABITACION

create procedure NENE_MALLOC.alta_habitacion @numero numeric(18,0), @piso numeric(18,0), @hotel numeric(18,0),
                                             @tipo numeric(18,0), @vista nvarchar(50), @descripcion nvarchar(255)
as
begin transaction

	if exists(select h.Habitacion_Id from NENE_MALLOC.Habitacion h where h.Habitacion_Num = @numero and
	                                                                     h.Habitacion_Piso = @piso and
	                                                                     h.Habitacion_Hotel = @hotel)
		begin
			rollback
			raiserror('La habitacion ya existe en el hotel',16,1)
			return
		end
	
	Insert into NENE_MALLOC.Habitacion(Habitacion_Num, Habitacion_Piso, Habitacion_Hotel, Habitacion_Tipo,
	                                   Habitacion_Vista, Habitacion_Desc) 
	                            values(@numero, @piso, @hotel, @tipo, @vista, @descripcion)                                                                    
	
commit 
GO

--MODIFICACIÓN DE HABITACIÓN

create procedure NENE_MALLOC.modificacion_habitacion @numero numeric(18,0), @piso numeric(18,0), @hotel numeric(18,0),
													 @tipo numeric(18,0), @vista nvarchar(50), @descripcion nvarchar(255),
													 @habitacion_id numeric(18,0)
as
begin transaction

	if exists(select h.Habitacion_Id from NENE_MALLOC.Habitacion h where h.Habitacion_Num = @numero and
	                                                                     h.Habitacion_Piso = @piso and
	                                                                     h.Habitacion_Hotel = @hotel and
	                                                                     h.Habitacion_Id != @habitacion_id)
		begin
			rollback
			raiserror('La habitacion ya existe en el hotel',16,1)
			return
		end
		
		
		update NENE_MALLOC.Habitacion
		set Habitacion_Num = @numero,
		    Habitacion_Piso = @piso,
		    Habitacion_Hotel = @hotel,
		    Habitacion_Tipo = @tipo,
		    Habitacion_Vista = @vista,
		    Habitacion_Desc = @descripcion		
		where Habitacion_Id = @habitacion_id		
                 
commit 
GO

--------------------------------TRIGGERS-----------------------------------------------------

--ALTA DEL ROL
create trigger NENE_MALLOC.alta_rol on NENE_MALLOC.Rol
instead of insert
as
begin
	if exists(select r.Rol_Desc from NENE_MALLOC.Rol r, Inserted i where r.Rol_Desc = i.Rol_Desc)
		begin
			raiserror('El rol ya existe',16,1)
		end
	else
		Insert into NENE_MALLOC.Rol(Rol_Id, Rol_Desc) values ((select MAX(Rol_Id) from NENE_MALLOC.Rol) + 1,(select i.Rol_Desc from Inserted i))
end 
GO

--------------------------------FUNCIONES-----------------------------------------------------


--------------------------LISTADO ESTADÍSTICO---------------------------------------------------


--HOTELES CON MAYOR CANTIDAD DE RESERVAS CANCELADAS
create function NENE_MALLOC.hoteles_reservas_mas_canceladas (@anio numeric(4,0),@mesInicio numeric(2,0), @mesFin numeric(2,0))
returns @tabla table (hotel_nombre nvarchar(255),
					  hotel_mail nvarchar(255),
					  hotel_telefono numeric(18,0),
					  hotel_ciudad nvarchar(255),
					  hotel_pais nvarchar(255) )
	as begin 
	
	
	insert into @tabla (hotel_nombre, hotel_mail, hotel_telefono, hotel_ciudad, hotel_pais)
			(select top 5 h.Hotel_Nombre, h.Hotel_Mail, h.Hotel_Telefono, h.Hotel_Ciudad, h.Hotel_Pais
				  from NENE_MALLOC.Reserva r, NENE_MALLOC.Hotel h
						where r.Reserva_Estado='Cancelada' and 
							  r.Reserva_Hotel=h.Hotel_Id and
							  year(r.Reserva_Fecha)=@anio and
							  month(r.Reserva_Fecha) between @mesInicio and @mesFin
								group by h.Hotel_Id,h.Hotel_Nombre, h.Hotel_Mail, h.Hotel_Telefono, h.Hotel_Ciudad, h.Hotel_Pais)
								order by count(r.Reserva_Id) desc
	
	return 
end
GO

--HOTELES CON MAYOR CANTIDAD DE CONSUMIBLES FACTURADOS
create function NENE_MALLOC.hoteles_consumibles_facturados(@anio numeric(4,0),@mesInicio numeric(2,0), @mesFin numeric(2,0))
returns @tabla table (hotel_nombre nvarchar(255),
					  hotel_mail nvarchar(255),
					  hotel_telefono numeric(18,0),
					  hotel_ciudad nvarchar(255),
					  hotel_pais nvarchar(255) )
	as begin 
	
	
	insert into @tabla (hotel_nombre, hotel_mail, hotel_telefono, hotel_ciudad, hotel_pais)
			(select top 5 ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais
				  from NENE_MALLOC.Reserva_Por_Habitacion r, NENE_MALLOC.Hotel ho, NENE_MALLOC.Habitacion ha,
				       NENE_MALLOC.Consumible_Por_Habitacion c, NENE_MALLOC.Factura f, NENE_MALLOC.Item_Factura i
				  where c.RPH_Id = r.RPH_Id and
				        r.Habitacion_Id = ha.Habitacion_Id and
				        ha.Habitacion_Hotel = ho.Hotel_Id and
				        i.Item_Factura = f.Factura_Id and
				        i.Item_Factura_Id = c.Consumible_Por_Habitacion_Id and
						year(f.Factura_Fecha)=@anio and
						month(f.Factura_Fecha) between @mesInicio and @mesFin
				  group by ho.Hotel_Id ,ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais)
				  order by count(c.Consumible_Por_Habitacion_Id) desc
	
	return 
end
GO


--HOTELES CON MAYOR CANTIDAD DE DIAS FUERA DE SERVICIO
create function NENE_MALLOC.hoteles_fuera_de_servicio(@anio numeric(4,0),@mesInicio numeric(2,0), @mesFin numeric(2,0))
returns @tabla table (hotel_nombre nvarchar(255),
					  hotel_mail nvarchar(255),
					  hotel_telefono numeric(18,0),
					  hotel_ciudad nvarchar(255),
					  hotel_pais nvarchar(255) )
	as begin 
	
	
	insert into @tabla (hotel_nombre, hotel_mail, hotel_telefono, hotel_ciudad, hotel_pais)
			(select top 5 ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais
				  from NENE_MALLOC.Hotel ho, NENE_MALLOC.Periodos_De_Cierre p
				  where p.Periodo_Hotel = ho.Hotel_Id and
						year(p.Periodo_FechaInicio)=@anio and
						month(p.Periodo_FechaInicio) between @mesInicio and @mesFin
				  group by ho.Hotel_Id,ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais)
				  order by SUM(DATEDIFF(DAY,p.Periodo_FechaInicio,p.Periodo_FechaFin)) desc

	return 
end
GO

--HABITACIONES CON MAYOR CANTIDAD DE DÍAS Y VECES QUE FUERON OCUPADAS
create function NENE_MALLOC.habitaciones_más_ocupadas(@anio numeric(4,0),@mesInicio numeric(2,0), @mesFin numeric(2,0))
returns @tabla table (hotel_nombre nvarchar(255),
					  hotel_mail nvarchar(255),
					  hotel_telefono numeric(18,0),
					  hotel_ciudad nvarchar(255),
					  hotel_pais nvarchar(255) )
	as begin 
	
	
	insert into @tabla (hotel_nombre, hotel_mail, hotel_telefono, hotel_ciudad, hotel_pais)
			(select top 5 ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais
				  from NENE_MALLOC.Hotel ho, NENE_MALLOC.Periodos_De_Cierre p
				  where p.Periodo_Hotel = ho.Hotel_Id and
						year(p.Periodo_FechaInicio)=@anio and
						month(p.Periodo_FechaInicio) between @mesInicio and @mesFin
				  group by ho.Hotel_Id, ho.Hotel_Nombre, ho.Hotel_Mail, ho.Hotel_Telefono, ho.Hotel_Ciudad, ho.Hotel_Pais)
				  order by SUM(DATEDIFF(DAY,p.Periodo_FechaInicio,p.Periodo_FechaFin))

	return 
end
GO

/*
Los siguientes procedimientos/triggers no los desarrollamos así los hacen los chicos:
-BAJA ROL
-BAJA USUARIO
-BAJA DE USUARIO POR HOTEL
-Modificacion de Usuario_Por_Rol_Por_Hotel

Lei esto en uno de los mails que puso el ayudante:
"En cuanto al guest, estaría muyyyyyyyyyyy mal asignarselo a todos los clientes por justamente del guest al no hacer 
login no se puede identificar a la persona, es alguien que hace uso del sistema y ahce la reserva en nombre de alguien 
que dice ser o supone ser la misma persona que realiza la reserva."

*/