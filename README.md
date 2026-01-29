# Todo Manager App

A simple Todo app built with **ASP.NET Core Web API** for the backend and **HTML/JS/CSS** for the frontend.  

---

## Features

- List all Todos with ID  
- Add new Todos  
- Mark Todos as done / undone  
- Edit Todos  
- Delete Todos  

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

## Frontend Features

- Responsive layout

- Color-coded buttons: ✔ green, ✏️ orange, 🗑 red

- Display unique ID for each Todo

- Hover effects and card-like styling

---

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/Megjafari/TodoAPIexercise.git
cd TodoAPIexercise
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
