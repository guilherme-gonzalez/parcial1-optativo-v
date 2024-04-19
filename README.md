# .NET API Project outline 

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
