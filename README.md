# 🔗 Acortador de URLs

Este proyecto es una aplicación web que permite acortar URLs largas a enlaces más cortos y fáciles de compartir. Está construida con **.NET 8** para la API y utiliza **PostgreSQL** como base de datos. Todo el entorno se levanta usando **Docker y Docker Compose**.

---

## 🚀 Tecnologías Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [PostgreSQL 16](https://www.postgresql.org/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 🧠 Características

- Acortar enlaces largos generando identificadores únicos.
- Redireccionamiento automático desde la URL corta.
- Almacenamiento persistente en base de datos PostgreSQL.
- Entorno completamente dockerizado para facilitar el desarrollo y despliegue.

---

## ⚙️ Requisitos

- Docker
- Docker Compose

---

## 📦 Configuración del entorno

1. Crea un archivo `.env` en la raíz del proyecto con las siguientes variables:

```env
POSTGRES_USER=admin
POSTGRES_PASSWORD=supersecreto
POSTGRES_DB=acortador
ASPNETCORE_ENVIRONMENT=Development
MY_DATABASE_CONNECTION_STRING=Host=db;Port=5432;Database=acortador;Username=admin;Password=supersecreto
```
🔐 Nota: Este archivo no debe subirse a GitHub. Asegúrate de agregarlo a tu .gitignore.

##🐳 Levantar el proyecto
Desde la raíz del proyecto, ejecuta:
docker compose up --build

##🗄️ Base de datos
docker exec -it acortador-db psql -U username -d bdname

##🌐 Endpoints de la API
http://localhost:8080/swagger/index.html

##🧑‍💻 Autor
Desarrollador por Nicolas Sanchez a modo de pruebas para docker
