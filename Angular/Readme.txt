===========================================================================
			Blue Bank
===========================================================================

Despues de seguir las instrucciones dadas en el readme de cada una de las partes

Supuestos de negocio.

Las supociones que se realizan son:
	Las tablas a crear, se normaliza la data a 3 forma y nos da como resultado 3 tablas, 
	las cuales son Client, Cuenta y CuentaCliente, en cliente se suponen dos columnas para el nombre 
	de la persona, para asi tener separado el nombre con el apellido, tambien se supone una columna de mas 
	para saber la fecha de nacimiento de la persona, esto por que el cliente puede mas adelante pedirnos
	autorizacion de creacion a solo mayores de edad o regalos a los clientes de ellos para fechas especiales,
	Se supone para CuentaCliente un password para hacer las trasacciones necesarias con X tarjeta 

La tecnologia para solucionar el problema son 3 partes de codigo para optimizar y tener mayor seguridad 
ya que se tiene varias capas, la primera capa es la que crea Angular con typeScript, la segunda se crea
con el backend en .NET y la ultima es la base de datos, ademas de que en la base de datos se crean primary keys 
dentro de cada tabla para poder indexar los datos, ademas de tambien crear llaves foraneas, esto nos ayuda a la hora 
de optimizacion de datos.

Si se tuviera mas tiempo para el proyecto, se crearia un tema de roles en el aplicativo y en base de datos, esto 
para mantener seguro los datos, tambien se encriptaria la clave en las bases de datos, esto para que nadie sepa que clave
tiene una tarjeta, ademas tambien se crearia un login en el cual el usuario se pueda logear para ver solo informacion que 
le interese a este mismo, tambien por falta de informacion para que usuario es el final se dejo expuesto que saldo tiene la 
persona, esto tambien se mejoraria para otra persona no pueda ver el saldo de otra pero el banco si lo pudiera hacer
esto para promocionar cosas, ejemplo tarjetas de credito, prestamos o estudios dentro de la misma. 

