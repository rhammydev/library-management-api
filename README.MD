# Library Management API

A RESTful API built with **ASP.NET Core**, **Entity Framework Core**, and **SQLite** for managing a library's book catalog. This project demonstrates the Repository Pattern, Dependency Injection, and clean controller architecture.

---

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite (`library.db`)
- Repository Pattern
- Async/Await & LINQ

---

## Project Structure

```
LibraryManagementAPI/
├── Controllers/
│   └── BooksController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   └── Book.cs
├── Repositories/
│   ├── IBookRepository.cs
│   └── BookRepository.cs
├── library.db               # Auto-generated on first run
└── Program.cs
```

---

##  Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

```bash
dotnet tool install --global dotnet-ef
```

### Setup & Run

```bash
# 1. Clone the repository
git clone https://github.com/rhammydev/library-management-api.git
cd library-management-api

# 2. Apply database migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

# 3. Run the API
dotnet run
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`).

---

## Book Model

| Property    | Type     | Notes                        |
|-------------|----------|------------------------------|
| `Id`        | int      | Auto-generated primary key   |
| `Title`     | string   | Required                     |
| `Author`    | string   | Required                     |
| `Category`  | string   | Required                     |
| `Price`     | decimal  | Must be greater than 0       |
| `Quantity`  | int      | Cannot be negative           |
| `CreatedAt` | DateTime | Set automatically on creation|

---

## API Endpoints

### Books

| Method | Endpoint                                     | Description              |
|--------|----------------------------------------------|--------------------------|
| GET    | `/api/books/get-all-books`                   | Get all books            |
| GET    | `/api/books/get-book-by-id/{id}`             | Get a book by ID         |
| POST   | `/api/books/create-book`                     | Create a new book        |
| PUT    | `/api/books/update-book/{id}`                | Update a book            |
| DELETE | `/api/books/delete-book/{id}`                | Delete a book            |
| GET    | `/api/books/search-books?title={title}`      | Search books by title    |
| GET    | `/api/books/get-book-by-category/{category}` | Filter books by category |
| GET    | `/api/books/get-out-of-stock-books`          | Get out-of-stock books   |

---

## Validation Rules

Validation is enforced inside the repository layer:

- `Price` must be greater than 0
- `Quantity` cannot be negative
- `Title`, `Author`, and `Category` are required fields

---

## Architecture

This project follows the **Repository Pattern** to keep business logic decoupled from the controller layer.

```
Request → BooksController → IBookRepository → BookRepository → ApplicationDbContext → SQLite
```

- **Controllers** handle HTTP concerns only (routing, status codes, response shaping)
- **Repositories** contain all data access and validation logic
- **DbContext** manages EF Core interactions with the SQLite database

---

## Database Migrations

```bash
# Create a new migration
dotnet ef migrations add <MigrationName>

# Apply pending migrations
dotnet ef database update

# Revert the last migration
dotnet ef migrations remove
```

---

## License

This project is for educational purposes as part of a course assignment on ASP.NET Core Web API development.