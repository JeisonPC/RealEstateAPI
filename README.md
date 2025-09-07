# 🏠 Real Estate API

Una API REST moderna construida con **.NET 8** y **Clean Architecture** para la gestión de propiedades inmobiliarias, utilizando **MongoDB** como base de datos.

## 📋 Tabla de Contenidos

- [🏠 Real Estate API](#-real-estate-api)
  - [📋 Tabla de Contenidos](#-tabla-de-contenidos)
  - [🎯 Características](#-características)
  - [🏗️ Arquitectura](#️-arquitectura)
  - [🛠️ Tecnologías](#️-tecnologías)
  - [📁 Estructura del Proyecto](#-estructura-del-proyecto)
  - [🚀 Inicio Rápido](#-inicio-rápido)
    - [📋 Prerequisitos](#-prerequisitos)
    - [🔧 Instalación](#-instalación)
    - [🔑 Configuración](#-configuración)
    - [▶️ Ejecución](#️-ejecución)
  - [📚 API Endpoints](#-api-endpoints)
    - [🏠 Properties](#-properties)
  - [🔧 Desarrollo Local](#-desarrollo-local)
    - [🗄️ Base de Datos](#️-base-de-datos)
    - [🧪 Ejecutar Tests](#-ejecutar-tests)
  - [🚀 Deployment](#-deployment)
    - [🐳 Docker](#-docker)
    - [☁️ Render](#️-render)
  - [📖 Documentación de la API](#-documentación-de-la-api)
  - [🤝 Contribuir](#-contribuir)
  - [📄 Licencia](#-licencia)

## 🎯 Características

- ✅ **Clean Architecture** - Separación clara de responsabilidades
- ✅ **MongoDB** - Base de datos NoSQL moderna y escalable
- ✅ **ASP.NET Core 8** - Framework web de alto rendimiento
- ✅ **Swagger/OpenAPI** - Documentación interactiva de la API
- ✅ **CQRS Pattern** - Separación de comandos y consultas
- ✅ **Repository Pattern** - Abstracción de acceso a datos
- ✅ **Dependency Injection** - Inversión de dependencias
- ✅ **Docker Support** - Containerización para deployment
- ✅ **User Secrets** - Manejo seguro de configuraciones sensibles

## 🏗️ Arquitectura

El proyecto sigue los principios de **Clean Architecture**:

```
📦 RealEstate.Api          # Capa de Presentación
 ├── Controllers/           # Controladores REST
 ├── Requests/             # DTOs de entrada
 └── Program.cs            # Configuración de la aplicación

📦 RealEstate.Application   # Capa de Aplicación
 ├── Properties/           # Casos de uso de propiedades
 │   ├── Handlers/         # Manejadores de comandos/consultas
 │   ├── DTOs/            # Objetos de transferencia de datos
 │   └── Interfaces/      # Contratos de repositorios

📦 RealEstate.Domain       # Capa de Dominio
 └── Entities/            # Entidades del negocio
     ├── Property.cs      # Entidad Propiedad
     └── Owner.cs         # Entidad Propietario

📦 RealEstate.Infrastructure # Capa de Infraestructura
 ├── Mongo/               # Configuración de MongoDB
 ├── Properties/          # Implementación de repositorios
 └── DependencyInjection.cs # Configuración de DI

📦 RealEstate.Tests        # Pruebas Unitarias
```

## 🛠️ Tecnologías

- **Framework**: .NET 8
- **Lenguaje**: C# 12
- **Base de Datos**: MongoDB Atlas
- **ORM/Driver**: MongoDB.Driver (Driver nativo)
- **Documentación**: Swagger/OpenAPI
- **Testing**: NUnit
- **Containerización**: Docker
- **CI/CD**: GitHub Actions (opcional)

## 📁 Estructura del Proyecto

```
📁 TechnicalTest/
├── 📄 README.md                          # Este archivo
├── 📄 Dockerfile                         # Configuración de Docker
├── 📄 .gitignore                         # Archivos ignorados por Git
├── 📄 RealEstate.sln                     # Solución de Visual Studio
│
├── 📁 RealEstate.Api/                    # API Web
│   ├── 📁 Controllers/
│   │   └── PropertiesController.cs       # Controlador de propiedades
│   ├── 📁 Requests/
│   │   └── PropertyFilterQuery.cs        # Query parameters
│   ├── Program.cs                        # Punto de entrada
│   ├── appsettings.json                  # Configuración base
│   ├── appsettings.Development.json      # Configuración desarrollo
│   └── appsettings.Production.json       # Configuración producción
│
├── 📁 RealEstate.Application/            # Lógica de Aplicación
│   └── 📁 Properties/
│       ├── GetPropertyHandler.cs         # Obtener propiedad por ID
│       ├── ListPropertiesHandler.cs      # Listar propiedades
│       ├── IPropertyRepository.cs        # Interfaz del repositorio
│       ├── PropertyDtos.cs               # DTOs de respuesta
│       └── PropertyMapping.cs            # Mapeo de entidades
│
├── 📁 RealEstate.Domain/                 # Entidades de Negocio
│   └── 📁 entities/
│       ├── Property.cs                   # Entidad Propiedad
│       └── Owner.cs                      # Entidad Propietario
│
├── 📁 RealEstate.Infrastructure/         # Acceso a Datos
│   ├── 📁 Mongo/
│   │   ├── MongoContext.cs              # Contexto de MongoDB
│   │   └── MongoSettings.cs             # Configuración de MongoDB
│   ├── 📁 Properties/
│   │   ├── PropertyRepository.cs        # Implementación del repositorio
│   │   ├── PropertyDocument.cs          # Documento de MongoDB
│   │   └── PropertyImageDocument.cs     # Documento de imágenes
│   └── DependencyInjection.cs          # Configuración de DI
│
└── 📁 RealEstate.Tests/                 # Pruebas Unitarias
    ├── OwnerTests.cs                    # Tests de Owner
    └── UnitTest1.cs                     # Tests generales
```

## 🚀 Inicio Rápido

### 📋 Prerequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (o MongoDB local)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

### 🔧 Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/JeisonPC/RealEstateAPI.git
   cd RealEstateAPI
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Verificar la compilación**
   ```bash
   dotnet build
   ```

### 🔑 Configuración

#### Desarrollo Local (User Secrets)

1. **Inicializar User Secrets** (solo la primera vez)
   ```bash
   cd RealEstate.Api
   dotnet user-secrets init
   ```

2. **Configurar la cadena de conexión**
   ```bash
   dotnet user-secrets set "Mongo:ConnectionString" "tu-connection-string-de-mongodb"
   ```

#### Variables de Entorno (Producción)

```bash
MONGO__CONNECTIONSTRING=mongodb+srv://usuario:password@cluster.mongodb.net/
ASPNETCORE_ENVIRONMENT=Production
```

### ▶️ Ejecución

```bash
# Desarrollo
dotnet run --project RealEstate.Api

# Producción
dotnet run --project RealEstate.Api --configuration Release
```

La API estará disponible en:
- **HTTP**: http://localhost:5163
- **Swagger UI**: http://localhost:5163/swagger

## 📚 API Endpoints

### 🏠 Properties

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/` | Health check | - |
| `GET` | `/api/properties` | Listar propiedades | `name`, `address`, `minPrice`, `maxPrice`, `page`, `pageSize` |
| `GET` | `/api/properties/{id}` | Obtener propiedad por ID | `id` (string) |

#### Ejemplos de Uso

**Listar todas las propiedades:**
```bash
curl -X GET "https://api.realestate.com/api/properties"
```

**Filtrar propiedades:**
```bash
curl -X GET "https://api.realestate.com/api/properties?name=casa&minPrice=100000&maxPrice=500000&page=1&pageSize=10"
```

**Obtener propiedad específica:**
```bash
curl -X GET "https://api.realestate.com/api/properties/64f8a1b2c3d4e5f6g7h8i9j0"
```

#### Respuesta Ejemplo

```json
{
  "items": [
    {
      "id": "64f8a1b2c3d4e5f6g7h8i9j0",
      "idOwner": "64f8a1b2c3d4e5f6g7h8i9j1",
      "name": "Casa Moderna en el Centro",
      "address": "Calle 123 #45-67, Bogotá",
      "price": 250000000,
      "imageUrl": "https://example.com/image.jpg"
    }
  ],
  "page": 1,
  "pageSize": 20,
  "total": 1
}
```

## 🔧 Desarrollo Local

### 🗄️ Base de Datos

**Colecciones de MongoDB:**
- `properties` - Información de propiedades
- `propertyImages` - Imágenes asociadas a propiedades

**Índices Recomendados:**
```javascript
// En MongoDB Compass o Shell
db.properties.createIndex({ "name": "text", "address": "text" })
db.properties.createIndex({ "price": 1 })
db.propertyImages.createIndex({ "idProperty": 1, "enabled": 1 })
```

### 🧪 Ejecutar Tests

```bash
# Ejecutar todos los tests
dotnet test

# Ejecutar tests con cobertura
dotnet test --collect:"XPlat Code Coverage"

# Ejecutar tests específicos
dotnet test --filter "ClassName=OwnerTests"
```

## 🚀 Deployment

### 🐳 Docker

**Construir imagen:**
```bash
docker build -t realestate-api .
```

**Ejecutar contenedor:**
```bash
docker run -d \
  -p 8080:80 \
  -e MONGO__CONNECTIONSTRING="tu-connection-string" \
  -e ASPNETCORE_ENVIRONMENT=Production \
  --name realestate-api \
  realestate-api
```

### ☁️ Render

1. **Fork** este repositorio
2. Conecta tu cuenta de **Render** con GitHub
3. Crea un nuevo **Web Service**
4. Configura las variables de entorno:
   ```
   MONGO__CONNECTIONSTRING=tu-connection-string
   ASPNETCORE_ENVIRONMENT=Production
   ```
5. Usa estos comandos de build:
   ```bash
   # Build Command:
   dotnet publish -c Release -o out
   
   # Start Command:
   dotnet out/RealEstate.Api.dll
   ```

## 📖 Documentación de la API

La documentación completa de la API está disponible a través de **Swagger UI**:

- **Desarrollo**: http://localhost:5163/swagger
- **Producción**: https://tu-dominio.com/swagger

## 🤝 Contribuir

1. **Fork** el proyecto
2. Crea una **rama** para tu feature (`git checkout -b feature/AmazingFeature`)
3. **Commit** tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. **Push** a la rama (`git push origin feature/AmazingFeature`)
5. Abre un **Pull Request**

### 📝 Convenciones

- **Commits**: Usar [Conventional Commits](https://www.conventionalcommits.org/)
- **Código**: Seguir las [convenciones de C#](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
- **Tests**: Escribir tests para nuevas funcionalidades

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

---

⭐ **¡Dale una estrella a este proyecto si te ha sido útil!**

**Desarrollado con ❤️ por [JeisonPC](https://github.com/JeisonPC)**
