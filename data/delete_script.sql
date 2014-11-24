use GD2C2014
go 


drop trigger [NENE_MALLOC].[tr_delete_regimen_por_hotel]
GO 

drop table [NENE_MALLOC].[Usuario_Por_Rol_Por_Hotel]
drop table [NENE_MALLOC].[Func_Por_Rol]
drop table [NENE_MALLOC].[Funcionalidad]
drop table [NENE_MALLOC].[Regimen_Por_Hotel]
drop table [NENE_MALLOC].[Periodos_De_Cierre]
drop table [NENE_MALLOC].[Estadia]
drop table [NENE_MALLOC].[Consumible_Por_Habitacion]
drop table [NENE_MALLOC].[Consumible]
drop table [NENE_MALLOC].[Usuario]
drop table [NENE_MALLOC].[Rol]
drop table [NENE_MALLOC].[Item_Factura]
drop table [NENE_MALLOC].[Factura]
drop table [NENE_MALLOC].[Datos_Tarjeta]
drop table [NENE_MALLOC].[Huesped_Por_Habitacion]
drop table [NENE_MALLOC].[Reserva_Por_Habitacion]
drop table [NENE_MALLOC].[Habitacion]
drop table [NENE_MALLOC].[Tipo_Habitacion]
drop table [NENE.MALLOC].[Log_Reserva]
drop table [NENE_MALLOC].[Reserva]
drop table [NENE_MALLOC].[Hotel]
drop table [NENE_MALLOC].[Regimen]
drop table [NENE_MALLOC].[Cliente]
drop table [NENE_MALLOC].[Datos_Personales]
GO


drop procedure [NENE_MALLOC].[login_usuario]
drop procedure [NENE_MALLOC].[baja_rol]
drop procedure [NENE_MALLOC].[alta_funcionalidad_por_rol]
drop procedure [NENE_MALLOC].[baja_funcionalidad_por_rol]
drop procedure [NENE_MALLOC].[alta_usuario]
drop procedure [NENE_MALLOC].[alta_hotel]
drop procedure [NENE_MALLOC].[alta_habitacion]
drop procedure [NENE_MALLOC].[alta_cliente]
drop procedure [NENE_MALLOC].[alta_rol]
drop procedure [NENE_MALLOC].[modificacion_usuario]
drop procedure [NENE_MALLOC].[modificacion_cliente]
drop procedure [NENE_MALLOC].[modificacion_hotel]
drop procedure [NENE_MALLOC].[modificacion_habitacion]
drop procedure [NENE_MALLOC].[modificacion_rol]
drop procedure [NENE_MALLOC].[generar_estadia]
drop procedure [NENE_MALLOC].[alta_consumible_habitacion]
drop procedure [NENE_MALLOC].[generar_factura]
drop procedure [NENE_MALLOC].[agregar_items]
drop procedure [NENE_MALLOC].[generar_reserva]
drop procedure [NENE_MALLOC].[modificar_reserva]
drop procedure [NENE_MALLOC].[agregar_tarjeta]
drop procedure [NENE_MALLOC].[candelar_reserva]

GO

drop function [NENE_MALLOC].[costo_estadia]
drop function [NENE_MALLOC].[hoteles_reservas_mas_canceladas]
drop function [NENE_MALLOC].[hoteles_consumibles_facturados]
drop function [NENE_MALLOC].[hoteles_fuera_de_servicio]
drop function [NENE_MALLOC].[habitaciones_mas_ocupadas]
drop function [NENE_MALLOC].[clientes_mas_puntos]
GO

drop schema NENE_MALLOC
GO