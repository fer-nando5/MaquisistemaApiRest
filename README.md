# MaquisistemaApiRest
Rest Api para TEKTON - CRUD de Product.

Desarrollo:
AutoMapper 
AutoMapper.Extensions.Microsoft.DependencyInjection 
MicrosoftEntityFrameworkCore.SqlServer 6.0.12
Serilog.Extensions.Logging.File
Microsoft.Extensions.Logging
Swashbuckle.AspetCore 6.4.0
Swashbuckle.AspetCore.Annotations 6.4.0
Swashbuckle.AspetCore.SwaggerUI 6.4.0
Microsoft.Extensions.Http
Microsoft.Extensions.Configuration
 
Test (NUnit):
Microsoft.AspNetCore.Mvc.Testing
Microsoft.Extensions.Configuration.Abstractions
Microsoft.Extensions.DependencyInjection
NUnit3TestAdapter

BD:
La base de datos SQL Server 
Nombre de la Base de Datos: COMERCIO
Tabla: Product
Se adjunta archivo bak: COMERCIO.bak

Solucion:
Se desarrollo con .NET 6.0 
Solución se divide en 4 capas: 
1) Infraestructura - (Se utilizo DAPPER).
2) Dominio
3) Aplicacion
4) Servicio
5) Transversal
6) Prueba

