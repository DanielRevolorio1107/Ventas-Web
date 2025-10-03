#  VentasWeb

Una aplicación **ASP.NET Core MVC (Razor Pages)** que funciona como **frontend** para la [VentasApi](../VentasApi).  
Permite visualizar productos, registrar ventas con carrito de compras y consultar historial de ventas por cliente.

---

##  Tecnologías usadas
- **ASP.NET Core 8 MVC (Razor Pages)**
- **Bootstrap 5** (UI responsiva)
- **JavaScript (fetch API)** para comunicación con la API
- **Swagger (en la API backend)**

---

##  Estructura del proyecto

│── Controllers/ # Controladores MVC (Home, Productos, Ventas)
│── Models/ # DTOs y ViewModels para consumir la API
│── Views/ # Vistas Razor (Productos, Ventas, etc.)
│── wwwroot/ # Archivos estáticos (css, js, bootstrap)
│── appsettings.json # Configuración (url de la API)
│── Program.cs # Configuración inicial de la app

##  Configuración inicial

1. Clonar el repositorio:

git clone https://github.com/tuusuario/VentasWeb.git
cd VentasWeb

dotnet restore
dotnet run

 Funcionalidades
 Productos

Ver listado de productos disponibles (/Productos).

## Registrar Venta

Seleccionar cliente.

Agregar productos al carrito.

Mostrar total.

Enviar venta a la API para registrar.

## Historial de Ventas

Consultar ventas de un cliente específico (/Ventas/Historial).

## Validaciones

 No se puede agregar más productos de los que hay en stock.

Cliente debe seleccionarse antes de registrar la venta.

 El carrito no puede estar vacío.

## Interfaz

UI construida con Bootstrap 5.

Tablas dinámicas para productos y carrito.

Mensajes de confirmación y error al registrar ventas
