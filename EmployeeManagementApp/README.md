# Employee Management API

ASP.Net Core API + EF Core + JWT + Scalar UI


## Features
- CRUD operations for employees
- Automatic age calculation without saving in db
- Soft Delete
- JWT Authentication
- Scalar API Reference 
- Automatic database migration and data seeding in first run  
- Services and DI

## Tech Stack
- .NET 8
- Entity Framework Core (Code First)
- SQL Server
- JWT Bearer
- Scalar.AspNetCore

---

## How to Run

### 1. Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB rekomandohet)

### 2. Clone & Restore
```bash
git clone https://github.com/arditmuja/EmployeeManagementApp.git
cd EmployeeManagementApp
dotnet restore
```

### 3. Database Connection String 

Open the file `appsettings.json` and update the `DefaultConnection` according to your SQL Server setup.
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EmployeeManagementDb;Trusted_Connection=true;MultipleActiveResultSets=true"
```

---

# EMPLOYEES API DOCUMENTATION

## Base URL 
```
https://localhost:7123/scalar/
```


###  GET
https://localhost:7123/scalar/#tag/employee/get/apiemployeeget

Returns employees list, including their age.


``` 
200 OK
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "firstName": "string",
    "lastName": "string",
    "personalNumber": "string",
    "dateOfBirth": "2025-12-07T23:03:42.316Z",
    "age": 1,
    "phoneNumber": null,
    "email": null,
    "hireDate": null,
    "grossSalary": null,
    "createdAt": "2025-12-07T23:03:42.316Z"
  }
]

```

### GET/{id}  https://localhost:7123/api/Employee/get/123e4567-e89b-12d3-a456-426614174000 

Returns a single employee
```
200OK
{
  "firstName": "string",
  "lastName": "string",
  "personalNumber": "string",
  "dateOfBirth": "2025-12-07T23:03:42.316Z",
  "educationLevel": 1,
  "fullName": null,
  "phoneNumber": null,
  "email": null,
  "hireDate": null,
  "grossSalary": null,
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "createdAt": "2025-12-07T23:03:42.316Z",
  "updatedAt": null,
  "isDeleted": true
}

```


### POST https://localhost:7123/api/Employee/create

Creates a new employee
```
200OK
{
  "firstName": "string",
  "lastName": "string",
  "personalNumber": "string",
  "dateOfBirth": "2025-12-07T23:03:42.316Z",
  "educationLevel": 1,
  "fullName": null,
  "phoneNumber": null,
  "email": null,
  "hireDate": null,
  "grossSalary": null,
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "createdAt": "2025-12-07T23:03:42.316Z",
  "updatedAt": null,
  "isDeleted": true
}
```


### PUT https://localhost:7123/api/Employee/update/123e4567-e89b-12d3-a456-426614174000 
Updates employee data

```
200OK
{
  "firstName": "string",
  "lastName": "string",
  "personalNumber": "string",
  "dateOfBirth": "2025-12-07T23:03:42.316Z",
  "educationLevel": 1,
  "fullName": null,
  "phoneNumber": null,
  "email": null,
  "hireDate": null,
  "grossSalary": null,
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "createdAt": "2025-12-07T23:03:42.316Z",
  "updatedAt": null,
  "isDeleted": true
}

```


### DELETE 

https://localhost:7123/api/Employee/delete/123e4567-e89b-12d3-a456-426614174000 

```
200 OK
No content
```