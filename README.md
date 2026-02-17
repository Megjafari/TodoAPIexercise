# Todo Manager App

This project demonstrates a full CRUD backend built with ASP.NET Core Web API and SQL Server, along with a simple frontend client that consumes the API.
---

## Features

- Full CRUD operations (Create, Read, Update, Delete)
- RESTful API design
- Entity Framework Core integration
- SQL Server database persistence
- Swagger for API testing
- Simple HTML/JavaScript frontend client

---


## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- HTML, CSS, JavaScript

---

## API Endpoints

| Method | Endpoint           | Description        |
|--------|------------------|------------------|
| GET    | /api/items        | Get all Todos     |
| GET    | /api/items/{id}   | Get Todo by ID    |
| POST   | /api/items        | Create a new Todo |
| PUT    | /api/items/{id}   | Update a Todo     |
| DELETE | /api/items/{id}   | Delete a Todo     |



---

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/Megjafari/TodoAPIApp.git

```
2. Run the backend


```bash
cd backend
dotnet run
```
- API URL: https://localhost:7158/api/items
- Swagger UI: https://localhost:7158/swagger

3. Run the frontend
- Open frontend/index.html using Live Server (VS Code)
