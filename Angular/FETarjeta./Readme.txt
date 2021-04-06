======================================================================
			Frontend Angular
======================================================================

INSTRUCCIONES DE COMO EJECUTAR

Para la parte del Frontend vamos a utilizar Angular en cual se tiene integracion con typescript, 
maquetacion en HTML.

Lo primero que se debe tener descargado es todo el servicio de Angular

Luego lo que debemos hacer es modificar la url a la aplicacion backend a la que se debe comunicar que seria 
la que se abre al ejecutar el codigo en .Net

Se debe modificar tarjeta.service.ts de la linea 10
  private myAppUrl = 'https://localhost:44389/';

Modificando esto podemos en una consola escribir ng serve --o y este nos abrira el proyecto 

