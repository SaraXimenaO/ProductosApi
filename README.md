# ProductosApi

API para obtener, actualizar y crear productos, guarda es tiempo de demora de las transacciones en un archivo de texto palno y consume un servicio exteno para obtener el descuento por cada producto.

## Patrones de diseño 
### (DDD Domain driven desing)

### * Inyección de dependencias
### * Mediator
### * Repository

## Patrones de arquitectura:

### * Arquitectura Exagonal
### * CQRS

## Test unitarios
### * XUnit
### * Moq

## Levantar el Proyecto Localmente

### Requisitos:

#### 1. .Net Framework 7
#### 2. LocalDB SqlServer
##### 2.1. Configura el connectionstring de la siguiente manera
  "ConnectionStrings": {
    "db": "Server=(localdb)\\MSSQLLocalDB;Database=Prueba;Trusted_Connection=True"
#### 3. MockApi 
##### 4.1.  Crea un mock api para obtener los descuentos del producto de la siguiente manera:
![image](https://github.com/SaraXimenaO/ProductosApi/assets/7612153/3ccafca2-21a8-46de-9b83-dd7f43c20810)
##### 4.2.  Esquema:
![image](https://github.com/SaraXimenaO/ProductosApi/assets/7612153/8b442a68-a3b7-46bc-b339-e1e93f07cd42)
##### 4.3. Debe retornar la información de la siguiente manera:
![image](https://github.com/SaraXimenaO/ProductosApi/assets/7612153/890047cf-f7d3-409a-a01c-fb8bcaed815a)
##### 4.4. Configura la URL del servicio mock en el appsetings
  "DiscountServiceUrl": "https://65cfba45bdb50d5e5f5bc6af.mockapi.io/dicount/"

Sigue estos pasos para levantar el proyecto localmente:

1. Clona este repositorio en tu máquina local.
2. Abre la solución con VS 2022
4. ¡Disfruta del proyecto!

