🛒 ApiTiendaDonPepe
ApiTiendaDonPepe es una API REST desarrollada con ASP.NET 7, que utiliza PostgreSQL como sistema gestor de base de datos, implementando la metodología ORM mediante Dapper. Incluye validación de autenticación mediante JWT (JSON Web Tokens) para proteger los endpoints.

🚀 Tecnologías Utilizadas
ASP.NET 7

PostgreSQL

Dapper (ORM)

JWT (Json Web Token)

Visual Studio 2022+

⚙️ Requisitos Previos
Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

.NET 7 SDK

Visual Studio 2022

PostgreSQL

Git

📦 Pasos para la Ejecución del Proyecto
Clonar el repositorio

bash
Copiar
Editar
git clone https://github.com/tu-usuario/ApiTiendaDonPepe.git
Abrir el proyecto

Abre la solución .sln en Visual Studio.

Restaurar dependencias

Visual Studio debería instalar automáticamente las dependencias al abrir el proyecto.

También puedes hacerlo desde la terminal:

bash
Copiar
Editar
dotnet restore
Instalar PostgreSQL

Asegúrate de tener PostgreSQL instalado y configurado con una base de datos disponible para el proyecto.

Configurar el archivo appsettings.json

Agrega tu cadena de conexión de PostgreSQL y las claves para el JWT:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=TiendaDonPepe;Username=usuario;Password=contraseña"
},
"Jwt": {
  "Key": "clave-super-secreta",
  "Issuer": "ApiTiendaDonPepe",
  "Audience": "ApiClientes"
}
Ejecutar el proyecto

Pulsa F5 o usa:

bash
Copiar
Editar
dotnet run
🔒 Autenticación
Esta API utiliza JWT para autenticar las solicitudes. Asegúrate de obtener un token válido a través del endpoint de login antes de consumir otros endpoints protegidos.

🧪 Endpoints Principales
Método	Ruta	Descripción	Autenticación
POST	/api/auth/login	Iniciar sesión y obtener token	❌
GET	/api/productos	Listar productos	✅
POST	/api/productos	Agregar nuevo producto	✅
PUT	/api/productos/{id}	Editar producto	✅
DELETE	/api/productos/{id}	Eliminar producto	✅

✅ = Requiere token JWT
❌ = Público

✍️ Autor
Desarrollado por Juan Olave
📧 Contacto: olavejuan1805gmail.com
