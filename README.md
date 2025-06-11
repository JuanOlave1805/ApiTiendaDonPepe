# 🛒 ApiTiendaDonPepe

**ApiTiendaDonPepe** es una API REST desarrollada con **ASP.NET 7**, que utiliza **PostgreSQL** como sistema gestor de base de datos, implementando la metodología ORM mediante **Dapper**. Incluye validación de autenticación mediante **JWT (JSON Web Tokens)** para proteger los endpoints.

---

## 🚀 Tecnologías Utilizadas

- ASP.NET 7  
- PostgreSQL  
- Dapper (ORM)  
- JWT (Json Web Token)  
- Visual Studio 2022+  

---

## ⚙️ Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- .NET 7 SDK  
- Visual Studio 2022  
- PostgreSQL  
- Git  

---

## 📦 Pasos para la Ejecución del Proyecto

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/ApiTiendaDonPepe.git
   ```

2. **Abrir el proyecto**
   - Abre la solución `.sln` en Visual Studio.

3. **Restaurar dependencias**
   - Visual Studio debería instalar automáticamente las dependencias al abrir el proyecto.
   - También puedes hacerlo desde la terminal:
     ```bash
     dotnet restore
     ```

4. **Instalar PostgreSQL**
   - Asegúrate de tener PostgreSQL instalado y configurado con una base de datos disponible para el proyecto.

5. **Configurar el archivo `appsettings.json`**
   - Agrega tu cadena de conexión de PostgreSQL y las claves para el JWT:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=TiendaDonPepe;Username=usuario;Password=contraseña"
     },
     "Jwt": {
       "Key": "clave-super-secreta",
       "Issuer": "ApiTiendaDonPepe",
       "Audience": "ApiClientes"
     }
     ```

6. **Ejecutar el proyecto**
   - Pulsa `F5` en Visual Studio o usa:
     ```bash
     dotnet run
     ```

---

## 🔒 Autenticación

Esta API utiliza **JWT** para autenticar las solicitudes. Asegúrate de obtener un token válido a través del endpoint de login antes de consumir otros endpoints protegidos.

---

## 🧪 Endpoints Principales

| Método | Ruta                   | Descripción              | Autenticación |
|--------|------------------------|--------------------------|----------------|
| POST   | /api/auth/login        | Iniciar sesión y obtener token | ❌ |
| GET    | /api/productos         | Listar productos         | ✅ |
| POST   | /api/productos         | Agregar nuevo producto   | ✅ |
| PUT    | /api/productos/{id}    | Editar producto          | ✅ |
| DELETE | /api/productos/{id}    | Eliminar producto        | ✅ |

✅ = Requiere token JWT  
❌ = Público

---

## 🌐 Configurar la conexión a la API en el Frontend

> Nota: Ejecuta el Frontend almacenado en el repositorio  
> [https://github.com/JuanOlave1805/FrontTiendaDonPepe.git](https://github.com/JuanOlave1805/FrontTiendaDonPepe.git)  
>  
> **Credenciales:**  
> Usuario: `admin`  
> Contraseña: `12345`

En los archivos JS del frontend donde se realiza el `fetch`, asegúrate de apuntar a la URL correcta de la API:

```js
const API_URL = "https://localhost:7253/api"; // Cambia según tu entorno
```

---

## ✍️ Autor

Desarrollado por **Juan Olave**  
📧 Contacto: [olavejuan1805@gmail.com](mailto:olavejuan1805@gmail.com)
