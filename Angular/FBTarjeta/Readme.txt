======================================================================================
			Backend Creado por Bryan Andres Buitrago Mora 
======================================================================================

Para ejecutar el backend en un ambiente local lo primero que se tiene que tener en 
cuenta es tener visual studio community instalado, para que este sea nuestro IDE
https://visualstudio.microsoft.com/es/vs/community/, aparte tener un gestor de base 
de datos para SQL, se utilizo SQL Server Express para un ambiente Local
https://www.microsoft.com/es-es/sql-server/sql-server-downloads

A la hora de tener todo instalado lo que se debe realizar es en primera instancia 
abrir un proyecto en Visual studio y abrimos lo descargado (FBTarjeta.sln),

Para que la base de datos quede anexa al proyecto se debe modificar el archivo appsettings.json
la linea 11 en la cual encontramos 
"DevConnection": "Server=(local)\\sqlexpress;Database=BlueBank;Trusted_Connection=True;MultipleActiveResultSets=True;"
Esto se debe cambiar hacia la base de datos que se quiera apuntar si esta ya esta creada o si se desea crear una nueva 

Si se quiere crear una mediante el proyecto es necesario ir a herramientas -> Administrador de paquetes Nuget ->
 consola del Administrador de paquetes
Luego en la consola que nos abre ingresaremos 
	Add-Migration [Nombre de la migracios]
Esto para que nos migre los modelos, y los prepare para hacer la creacion de la base de datos con las tablas mencionadas en 
los modelos.

Al ejecutar esto nos creara una nueva migracion en el proyecto con dos metodos Up y Down, Up nos va a servir para 
hacer el cargue a la base de datos con lo mencionado en los modelos, y Down para eliminarlo.

Luego vamos de nuevo a la consola abierta y escribimos 
	Update-database
Si todo esta bien en la configuracion hacia la DB nos actualizara la DB o creara con las tablas necesarias y las llaver foraneas

En esto punto ya podremos ejecutar nuestro Backend, nos abrira un navegador con swagger en el cual podremos hacer pruebas de los 
elementos creados en el controlador.

