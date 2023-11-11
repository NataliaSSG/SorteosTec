# TekTrekAPI
## Descripción 

Esta API esta desarrollada como un ORM (Object Relational Mapping), lo que implica que cada una de las tablas de nuestra base de datos esta representada como una clase la cual conoceremos como un modelo.
Cada modelo tiene una capa de sevicio y un controlador, separar a la Api en capas, el codigo se mantiene organizado,y mas sencillo de depurar.
### Controladores

Es la capa que interactua de manera directa con las solicitudes de el usuario, maneja solicitudes HTTP, realiza validaciones, y las transfiere a su capa de servicio.

### Servicios

Contiene la logica de servicio, procesa los datos, aplica restricciones, y realiza otras operaciones con el proposito de asegurar que los datos manejados esten en el formato adecuado que requiere la base de datos, esta capa tambien es responsable de interactuar con la capa de acceso de datos (dbContext.cs en nuestro caso) para almacenar y tomar datos.

---
## Configuración Previa 

1. Crea la base de datos TecTrek utilizando el archivo TecTrek.sql dentro de el folder SQL en el directorio wwwroot del proyecto Sorteos Tec [Liga al DDL](https://github.com/NataliaSSG/SorteosTec/blob/main/Sorteos%20Tec/SorteosTec/wwwroot/SQL/TecTrek2.sql)
2. Una vez creada la base de datos, modifica el connection string utilizando tu usuario y contraseña dentro del archivo appsettings.json, debera de verse de la siguiente manera:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "dbContext": "server=localhost;database=TecTrek;user=tu_nombre_de_usuario;password=tu_contraseña"
  }
}
```
3. Corre el proyecto para verificar su funcionamiento, se te redirigira a una pagina de swagger, realiza una solicitud get para cualquiera de las tablas, de estar configurado de manera correcta, recibiras un código de estatus no. 200, de otra manera, te encontraras con errores de conexión 

---
## Accede a la Documentación Creada con Swagger

1. Abre el proyecto con visual studio seleccionando el archivo TecTrekAPI.sln
2. Ejecuta el proyecto y de inmediato se abrira una pagina nueva en tu navegador con swagger abierto
3. Experimenta con las operaciónes CRUD para cada tabla dentro de la base de datos

En caso de que no se abra una nueva página en tu navegador, accede a localhost en el puerto 7254, de todos modos, la liga a swagger desde ese puerto de localhost esta abajo
[Liga a localhost con Swagger](https://localhost:7254/swagger/v1/swagger.json)
