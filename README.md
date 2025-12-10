# 🧩 NTier Restful Web API Project (.NET 8 - Layered Architecture)

This project is a RESTful service application built with **ASP.NET Core 8 Web API**, based on a multi-layered architecture. The goal is to provide a sustainable, testable, modular, and extensible backend architecture while establishing foundational structures suitable for real-world scenarios.

---

## 🚀 Project Overview

The project features a multi-layered design in which Entity Framework Core manages database operations, the service layer contains business rules, and the presentation layer exposes RESTful API endpoints. Several advanced features—such as CORS, pagination, filtering, sorting, role-based authorization using JWT, Swagger enhancements, and Postman integration—are implemented in the solution.

---

## 🧱 Layered Structure

The project consists of the following five primary layers:

- **Entities**: Contains models representing database tables (e.g., `Department`, `Employee`, `Job`) and related data annotations.
- **Repositories**: Includes data access operations, `IQueryable`-based querying, `trackChanges` support, and database connection infrastructure.
- **Services**: Hosts business logic, validation processes, and management of CRUD operations.
- **Presentation**: Contains controller structures. Incoming client requests are handled here, and the corresponding services are invoked.
- **WebApi**: The core startup layer of the application. Configuration tasks (Swagger, CORS, Authentication, etc.) are performed here via `Program.cs` and `ServiceExtensions`.

---

## ⚙️ Key Features

✅ Layered Architecture (N-Tier)  
✅ Repository & Service Pattern  
✅ Efficient querying with `IQueryable`  
✅ Entity tracking via `trackChanges`  
✅ Data Validation  
✅ Exception Handling and centralized error management  
✅ 🔐 **Role-Based Authorization with JWT** (Admin, Manager, User)  
✅ 🔍 **Pagination, Filtering, Searching, Sorting, Data Shaping**  
✅ 🧾 **Content Negotiation** (JSON & CSV support)  
✅ 🌐 **CORS** configuration  
✅ 📊 **Swagger UI** integration with token support for testing  
✅ 📬 **Postman collection** for test scenarios  

---

## 🛠 Installation & Setup

### 1️⃣ Clone the Repository
Run the following command in your terminal to clone the project:

```bash
git clone https://github.com/bahadirverir/Ntier-RestApi.git
```
### 2️⃣ Create the Database
Open a terminal and navigate to the WebApi layer of the project.

Run the command below to create the database.
```bash
dotnet ef database update
```
❗️ To avoid issues during setup, review the `SetupIntructions.rtf` file. 

