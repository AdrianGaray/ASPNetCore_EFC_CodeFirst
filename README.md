# ASPNetCore_EFC_CodeFirst
Tiene control total sobre el código


> ## Enfoque Code First 
>Es un enfoque muy popular y **tiene control total sobre el código en lugar de la actividad de la base de datos.**
> En este enfoque, podemos hacer todas las operaciones de la base de datos desde el código, todos los cambios manuales a la base de datos se perderán, todo depende del código.

<br />

## Instalar Entity Framework Core, desde el Package NuGet:

<p align="center">
  <img src="Entity%20Framework%20Core.jpg">
</p>

Y las herramientas de EF Core:

<p align="center">
  <img src="Microsoft.EntityFrameworkCore.Tools.jpg">
</p>

<br />

## Creando el Modelo de Datos
Sobre la carpeta Models, ir al menú Agregar -> Nuevo Elemento y seleccionamos Clase, con el nombre: Categoría. Se agrega las siguientes propiedades.

<p align="center">
  <img src="Clase.png">
</p>

Para la clase **Producto** se agrega las siguientes propiedades:

<p align="center">
  <img src="Clase_Producto.png">
</p>

<br />

### Agregar la clase del Contexto de la base de datos llamada **DbContexto**

<p align="center">
  <img src="Modelo_DbContexto.png">
</p>

<br />

Creamos dos constructores:

* Este constructor está vacío.

<p align="center">
  <img src="Constructor_vacio.png">
</p>

<br />

* Y el segundo constructor, espera por parámetro opciones que es un objeto de DbContextOptions.

<p align="center">
  <img src="constructor_DbContextOptions.png">
</p>

<br />

Declaramos las propiedades para exponer el modelo

<p align="center">
  <img src="Propiedades_Modelo.png">
</p>

<br />

Por último sobre escribir el método **OnModelCreating**. El método, nos permite mapear nuestras Entidades con la base de datos y le enviamos como parámetro un objeto que instancia de la clase **ModelBuilder**.

<p align="center">
  <img src="OnModelCreating.png">
</p>

<br />

## Registro del contexto con Inyección de Dependencias
ASP.NET Core implementa la **inyección de dependencia** de forma predeterminada. Los
servicios (como el contexto de la base de datos EF) se registran con la inyección de
dependencia durante el inicio de la aplicación. Los componentes que requieren estos
servicios (como los controladores MVC) se proporcionan a través, de parámetros de
constructor.

Se agrega la cadena de conexión de la BD, en el archivo **appsettings.json**

  `"ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\MyInstance;Initial Catalog=dbproductosCodeFirst"
  },`

<br />

El contexto de la base de datos **DbContexto** se registró como un servicio
en **Startup.cs**, en el metodo `ConfigureServices()`.

> De esta manera se hace la **Inyección de Dependencias**.

<br />

## Migraciones para crear la base de datos
Se va a migrar la estructura de Categoria y Producto, desde la consola **Nuget Package Manager**

<p align="center">
  <img src="Nuget%20Package%20Manager.png">
</p>

<br />

#### Agregar la Primera Migración, con el siguiente comando:

* `Add-Migration primera-migracion`

<p align="center">
  <img src="Add-Migration%20primera-migracion.png">
</p>

<br />

Cuando termina, se genera la carpeta **Migrations**, donde se muestra la primera migración. Donde se encuentra la definición para poder crear la base de datos con las tablas categorías y productos.

<p align="center">
  <img src="PrimeraMigracion.png">
</p>

<br />

#### Ejecutar la migración con el siguiente comando: 
* `Update-Database`

<p align="center">
  <img src="Update.png">
</p>

<br />

Abrimos el Sql Server, y se muestra la base de datos creada y las talas.

<p align="center">
  <img src="tabla.png">
</p>

<br />

#### Agregar una columna nueva a la tabla Categoría:
**1.**	En la clase Categoría agregamos la siguiente propiedad:

<p align="center">
  <img src="codigo.png">
</p>

<br />

**2.**	En la clase DbContexto, se agrega el campo nuevo, en el método **OnModelCreating**.

<p align="center">
  <img src="entitycodigo.png">
</p>

<br />

**3.**	Se agrega una nueva migración y en base a esta se va a actualizar la base de datos, ejecutando los siguientes comandos, desde la Administrador de consola:
`Add-Migration tabla-categoria-codigo`

<p align="center">
  <img src="mig2.png">
</p>

<br />

**4.**	Se crea una nueva migración

<p align="center">
  <img src="newmig.png">
</p>

<br />

**5.**	Se ejecuta el comando: Update-database

<p align="center">
  <img src="Update.png">
</p>

<br />

**6.**	Se refresca la base de datos, donde se ve el nuevo campo código

<p align="center">
  <img src="newcampo.png">
</p>






