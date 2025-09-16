# 🎓 Student Management System

A simple **ASP.NET Core Razor Pages application** for managing students and their scores. Built with:
- **Entity Framework Core** for data access
- **PostgreSQL** as the database
- **Dependency Injection** for clean architecture

---

## 🚀 Installation & Setup

### 1. Prerequisites
Make sure you have installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Entity Framework Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [PostgreSQL](https://www.postgresql.org/download/) server

Install EF Core CLI globally (if not already installed):
```bash
dotnet tool install --global dotnet-ef
```
### 2. Database Connection
- Open **`appsettings.json`** in the project root.
- Locate the `ConnectionStrings` section.
- Update the connection string to match your PostgreSQL setup (change `Database`, `Username`, and `Password` as needed):

```
"ConnectionStrings": {
"DefaultConnection": "Host=localhost;Database=topo_sms;Username=postgres;Password=yourpassword"
}
```
        
### 3. Apply Migrations
```bash
dotnet ef database update
```

### 4. Run the application
```bash
dotnet run
```