# .NET API Project outline

## Description
In this project we are building a simple CRUD and list .NET API that interacts with a PostreSQL docker container.

## Directories

This project has 3 main folders:

1. api.personas (contains controllers, settings and the main program)
2. Repository (contains interfaces, classes, sql ddl statements)
3. Services (contains services)

```bash
api.personas
├── Controllers
│   ├── ClienteController.cs
│   ├── FacturaController.cs
│   └── WeatherForecastController.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── WeatherForecast.cs
├── api.personas.csproj
├── appsettings.Development.json
├── appsettings.json 
```
  
```bash
Repository
├── DDL
│   ├── cliente.sql
│   └── factura.sql
├── Data
│   ├── ClienteModel.cs
│   ├── ClienteRepository.cs
│   ├── DbConection.cs
│   ├── FacturaModel.cs
│   ├── FacturaRepository.cs
│   ├── ICliente.cs
│   └── IFactura.cs
```
```bash
Services
├── Logica
│   ├── ClienteService.cs
│   └── FacturaService.cs
```
## DDL statements
#### cliente.sql
```sql
CREATE TABLE IF NOT EXISTS public.cliente (
      id serial4 PRIMARY KEY,
      id_banco VARCHAR(255),
      nombre VARCHAR(255) NOT NULL CHECK (char_length(nombre) >= 3),
      apellido VARCHAR(255) NOT NULL CHECK (char_length(apellido) >= 3),
      documento VARCHAR(255) NOT NULL CHECK (char_length(documento) >= 3),
      direccion VARCHAR(255),
      mail VARCHAR(255),
      celular CHAR(10) CHECK (celular ~ '^[0-9]+$'),
      estado VARCHAR(255)
);
```
#### factura.sql
```sql
CREATE TABLE IF NOT EXISTS public.factura (
        id serial4 PRIMARY KEY,
        id_cliente VARCHAR(255) NOT NULL,
        nro_factura VARCHAR(255) NOT NULL CHECK (nro_factura ~ '^[0-9]{3}-[0-9]{3}-[0-9]{6}$'),
        fecha_hora TIMESTAMP NOT NULL,
        total NUMERIC NOT NULL,
        total_iva5 NUMERIC NOT NULL,
        total_iva10 NUMERIC NOT NULL,
        total_iva NUMERIC NOT NULL,
        total_letras VARCHAR(255) NOT NULL CHECK (char_length(total_letras) >= 6),
        sucursal VARCHAR(255)
    );
```
## Swagger Screenshots

### Swagger UI
![img](Swagger_screenshots/swaggerUI.png)

### Clientes CRUD and List

#### 1. Add
![img](Swagger_screenshots/Cadd.png)
#### 2. Get
![img](Swagger_screenshots/Cget.png)
#### 3. Update
![img](Swagger_screenshots/Cupdate.png)
#### 4. Delete
![img](Swagger_screenshots/Cdelete.png)
#### 5. List
![img](Swagger_screenshots/Clist.png)
#### 6. Postgres query
![img](Swagger_screenshots/Cquery.png)

### Facturas CRUD and List

#### 1. Add
![img](Swagger_screenshots/Fadd.png)
#### 2. Get
![img](Swagger_screenshots/Fget.png)
#### 3. Update
![img](Swagger_screenshots/Fupdate.png)
#### 4. Delete
![img](Swagger_screenshots/Fdelete.png)
#### 5. List
![img](Swagger_screenshots/Flist.png)
#### 6. Postgres query
![img](Swagger_screenshots/Fquery.png)
