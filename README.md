# TBC.RB.FinalProject.API
This is the final project API for the TBC.RB application, developed using ASP.NET Core. The API serves as the backend service providing data and functionalities for the TBC.RB application.

# Table of Contents
- Getting Started
- Prerequisites
- Installation
- Configuration
- Running the API
- API Endpoints
- Technologies Used
- Contributing
- License
# Getting Started
These instructions will help you set up and run the project on your local machine for development and testing purposes.

# Prerequisites
- .NET Core SDK (version 6.0 or later)
- SQL Lite
- Git
- Installation
Clone the repository:

```sh
git clone https://github.com/RaisaBadal/TBC.RB.FinalProject.API.git
```
```sh
cd TBC.RB.FinalProject.API
```
Restore the .NET dependencies:
```sh
dotnet restore
```
Configuration
Update the appsettings.json file with your SQL Server connection string:

json

```sh
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
  }
}
```
Apply the database migrations to set up the database schema:


```sh
dotnet ef database update
```
Running the API
To run the API, use the following command:
```sh
dotnet run
```
The API will be available at https://localhost:5001 by default.

API Endpoints
Here are some of the main endpoints available in the API:

Books
```sh
GET /api/books - Get all books
GET /api/books/{id} - Get a book by ID
POST /api/books - Add a new book
PUT /api/books/{id} - Update a book
DELETE /api/books/{id} - Delete a book
```
Authors
```sh
GET /api/authors - Get all authors
GET /api/authors/{id} - Get an author by ID
POST /api/authors - Add a new author
PUT /api/authors/{id} - Update an author
DELETE /api/authors/{id} - Delete an author
For a full list of endpoints, refer to the API documentation available at https://localhost:5001/swagger.
```
# Technologies Used
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swashbuckle (Swagger)
- SQL Lite


# Contributing
Contributions are welcome! Please create a pull request with a description of your changes.

# License
This project is licensed under the MIT License. See the LICENSE file for details.
