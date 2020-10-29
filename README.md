# ASPNetCore_EFC_CodeFirst

## Enfoque Code First
> Es un enfoque muy popular y **tiene control total sobre el código en lugar de la actividad de la base de datos.**
> En este enfoque, podemos hacer todas las operaciones de la base de datos desde el código, todos los cambios manuales a la base de datos se perderán, todo depende del código.

## Instalar Entity Framework Core, desde el Package NuGet:

![](Entity%20Framework%20Core.jpg)

Y las herramientas de EF Core:
![](Microsoft.EntityFrameworkCore.Tools.jpg)


## Creando el Modelo de Datos
Sobre la carpeta Models, ir al menú Agregar -> Nuevo Elemento y seleccionamos Clase, con el nombre: Categoría. Se agrega las siguientes propiedades.

![](Clase.png)

Para la clase **Producto** se agrega las siguientes propiedades:
![](Clase_Producto.png)

### Agregar la clase del Contexto de la base de datos llamada **DbContexto**
![](Modelo_DbContexto.png)

Creamos dos constructores:

* Este constructor está vacío.

![](Constructor_vacio.png)

* Y el segundo constructor, espera por parámetro opciones que es un objeto de DbContextOptions.

![](constructor_DbContextOptions.png)

Declaramos las propiedades para exponer el modelo
![](Propiedades_Modelo.png)

Por último sobre escribir el método **OnModelCreating**. El método nos permite mapear nuestras Entidades con la base de datos y le enviamos como parámetro un objeto que instancia de la clase **ModelBuilder**.
![](OnModelCreating.png)

## Registro del contexto con Inyección de Dependencias
ASP.NET Core implementa la **inyección de dependencia** de forma predeterminada. Los
servicios (como el contexto de la base de datos EF) se registran con la inyección de
dependencia durante el inicio de la aplicación. Los componentes que requieren estos
servicios (como los controladores MVC) se proporcionan a través de parámetros de
constructor.

Se agrega la cadena de conexión de la BD, en el archivo **appsettings.json**
  `"ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MyInstance;Initial Catalog=dbproductosCodeFirst"
  },`

El contexto de la base de datos **DbContexto** se registró como un servicio
en **Startup.cs**, en el metodo `ConfigureServices()`.

> De esta manera se hace la **Inyección de Dependencias**.

## Migraciones para crear la base de datos
Se va a migrar la estructura de Categoria y Producto, desde la consola **Nuget Package Manager**
![Nuget Package Manager](Nuget%20Package%20Manager.png)

Agregar la Primera Migración, con el siguiente comando:

* `Add-Migration primera-migracion`

![](Add-Migration%20primera-migracion.png)








