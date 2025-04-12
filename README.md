# 🔗 Acortador de URLs

Este proyecto es una aplicación web que permite acortar URLs largas a enlaces más cortos y fáciles de compartir. Está construida con **.NET 8** para la API y utiliza **PostgreSQL** como base de datos. Todo el entorno se levanta usando **Docker y Docker Compose**.

---

## 🚀 Tecnologías Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🧠 Características

- Acortar enlaces largos generando identificadores únicos.
- Redireccionamiento automático desde la URL corta.
- Almacenamiento persistente en base de datos PostgreSQL.
- Entorno completamente dockerizado para facilitar el desarrollo y despliegue.
- Documentación automática de la API con Swagger.

---

## ⚙️ Requisitos

Antes de comenzar, asegúrate de tener instalados los siguientes programas:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 📦 Configuración del entorno

1. Crea un archivo `.env` en la raíz del proyecto con las siguientes variables:

   ```env
   ASPNETCORE_ENVIRONMENT=Development
   MY_DATABASE_CONNECTION_STRING=Host=db;Port=5432;Database=acortador;Username=admin;Password=supersecreto
   ```

   🔐 **Nota**: Este archivo no debe subirse a GitHub. Asegúrate de agregarlo a tu `.gitignore`.

2. Asegúrate de que el archivo `docker-compose.yml` esté configurado correctamente para tu entorno.

---

## 🐳 Levantar el proyecto

Desde la raíz del proyecto, ejecuta los siguientes comandos:

1. Construir y levantar los contenedores:

   ```bash
   docker-compose up --build
   ```

2. La API estará disponible en:  
   [http://localhost:8080](http://localhost:8080)

3. La base de datos PostgreSQL estará disponible en el puerto `5432`.

---

## 🌐 Endpoints de la API

Puedes explorar los endpoints de la API utilizando Swagger. Una vez que el contenedor esté en ejecución, accede a:

- [Swagger UI](http://localhost:8080/swagger/index.html)

---

## 📂 Estructura del proyecto

```
AcortadorURL/
├── AcortadorURL.sln          # Solución del proyecto
├── AcortadorURL/             # Código fuente principal
│   ├── Controllers/          # Controladores de la API
│   ├── Data/                 # Acceso a datos
│   ├── Modelo/               # Modelos de datos
│   ├── appsettings.json      # Configuración de la aplicación
│   ├── Program.cs            # Configuración principal de la aplicación
│   └── Dockerfile            # Archivo Docker para la API
├── docker-compose.yml        # Configuración de Docker Compose
├── .env                      # Variables de entorno
└── README.md                 # Documentación del proyecto
```

---

## 🧑‍💻 Autor

Desarrollado por **Nicolas Sanchez** como un proyecto de prueba para Docker y .NET.

---
