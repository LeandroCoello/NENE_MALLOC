use GD2C2014
GO

--Test Login
declare @alfa numeric(1,0)
exec NENE_MALLOC.login_usuario @usuario='horsehead',@userpass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',@return=@alfa out
select @alfa

--wrong username
exec NENE_MALLOC.login_usuario @usuario='hodrsehead',@userpass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',@return=@alfa out
select @alfa

--wrong pass
declare @alfa numeric(1,0)
exec NENE_MALLOC.login_usuario @usuario='horsehead',@userpass='8d9d69eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',@return=@alfa out
select @alfa

update NENE_MALLOC.Usuario
	set Usuario_Deshabilitado=0
		where Usuario_name='horsehead'

update NENE_MALLOC.Usuario
	set USuario_Baja=0
		where Usuario_name='horsehead'
GO

--Test alta_cliente
exec NENE_MALLOC.alta_cliente @nombre= 'James', @apellido='Bond', @telefono= 48795870, 
										  @tipo_ident='DNI' , @nro_ident= 15487896, @mail='jbond@gmail.com' , 
										  @calle='Medrano', @nro_calle=951, @piso=4 , 
										  @depto='B' , @fecha_nacimiento='19890514', @nacionalidad='Argentino'

select * from NENE_MALLOC.Datos_Personales
select * from NENE_MALLOC.Cliente

--										  
exec NENE_MALLOC.alta_cliente @nombre= 'James', @apellido='Bond', @telefono= 48795870, 
										  @tipo_ident='Pasaporte' , @nro_ident= 15487896, @mail='jbond@gmail.com' , 
										  @calle='Medrano', @nro_calle=951, @piso=4 , 
										  @depto='B' , @fecha_nacimiento='19890514', @nacionalidad='Argentino'

exec NENE_MALLOC.alta_cliente @nombre= 'James', @apellido='Bond', @telefono= 48795870, 
										  @tipo_ident='Pasaporte' , @nro_ident= 15487896, @mail='jbodnd@gmail.com' , 
										  @calle='Medrano', @nro_calle=951, @piso=4 , 
										  @depto='B' , @fecha_nacimiento='19890514', @nacionalidad='Argentino'
GO

--Test alta_usuario
exec NENE_MALLOC.alta_usuario @username='horsehead', @pass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @rol='Recepcionista', @nombre='K', 
										  @apellido='Row', @telefono=46587982, @tipo_ident='DNI',
										  @nro_ident=65487985, @mail='krow@gmail.com', @calle='Medrano' ,
										  @nro_calle=951, @piso=4, @depto='Z' ,
										  @fecha_nacimiento='19870405', @hotel=3
										  
select * from NENE_MALLOC.Datos_Personales
select * from NENE_MALLOC.Usuario
select * from NENE_MALLOC.Usuario_Por_Hotel
select * from NENE_MALLOC.Usuario_Por_Rol
										  
exec NENE_MALLOC.alta_usuario @username='horsehead', @pass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @rol='Recepcionista', @nombre='K', 
										  @apellido='Row', @telefono=46587982, @tipo_ident='DNI',
										  @nro_ident=65487985, @mail='krow@gmail.com', @calle='Medrano' ,
										  @nro_calle=951, @piso=4, @depto='Z' ,
										  @fecha_nacimiento='19870405', @hotel=3
										  
exec NENE_MALLOC.alta_usuario @username='horsehead', @pass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @rol='Recepcionista', @nombre='K', 
										  @apellido='Row', @telefono=46587982, @tipo_ident='DNI',
										  @nro_ident=65487985, @mail='krDow@gmail.com', @calle='Medrano' ,
										  @nro_calle=951, @piso=4, @depto='Z' ,
										  @fecha_nacimiento='19870405', @hotel=3

exec NENE_MALLOC.alta_usuario @username='horsehead', @pass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @rol='Recepcionista', @nombre='K', 
										  @apellido='Row', @telefono=465871982, @tipo_ident='DNI',
										  @nro_ident=65487985, @mail='krDow@gmail.com', @calle='Medrano' ,
										  @nro_calle=951, @piso=4, @depto='Z' ,
										  @fecha_nacimiento='19870405', @hotel=3

exec NENE_MALLOC.alta_usuario @username='horsehead', @pass='8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @rol='Recepcionista', @nombre='K', 
										  @apellido='Row', @telefono=465871982, @tipo_ident='Pasaporte',
										  @nro_ident=65487985, @mail='krDow@gmail.com', @calle='Medrano' ,
										  @nro_calle=951, @piso=4, @depto='Z' ,
										  @fecha_nacimiento='19870405', @hotel=3
GO

--Test alta_hotel
exec NENE_MALLOC.alta_hotel @nombre='Hilton', @mail='hilton@gmail.com', @telefono=46857821,
                                        @calle='Mozart', @nro_calle=2300, @ciudad='Lugano' ,
                                        @pais ='Argentina', @fecha_creacion='20141012', @estrellas=4,
                                        @recarga_estrella=8

select * from NENE_MALLOC.Hotel

exec NENE_MALLOC.alta_hotel @nombre='Hilton1', @mail='hilton@gmail.com', @telefono=46857821,
                                        @calle='Mozart', @nro_calle=2300, @ciudad='Lugano' ,
                                        @pais ='Argentina', @fecha_creacion='20141012', @estrellas=4,
                                        @recarga_estrella=8

exec NENE_MALLOC.alta_hotel @nombre='Hilton1', @mail='hilton1@gmail.com', @telefono=46857821,
                                        @calle='Mozart', @nro_calle=2300, @ciudad='Lugano' ,
                                        @pais ='Argentina', @fecha_creacion='20141012', @estrellas=4,
                                        @recarga_estrella=8
                                        
exec NENE_MALLOC.alta_hotel @nombre='Hilton1', @mail='hilton1@gmail.com', @telefono=468557821,
                                        @calle='Mozart', @nro_calle=2300, @ciudad='Lugano' ,
                                        @pais ='Argentina', @fecha_creacion='20141012', @estrellas=4,
                                        @recarga_estrella=8
GO

--Test alta_rol

insert into NENE_MALLOC.Rol(Rol_Desc)
			values('Guest')
select * from NENE_MALLOC.Rol
GO