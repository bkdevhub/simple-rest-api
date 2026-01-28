# Simple REST API

A minimal REST API built with ASP.NET Core (.NET) to demonstrate clean backend fundamentals, clear separation of concerns, and correct REST semantics.

The project is intentionally small and focuses on **structure, readability, and architectural discipline** rather than feature richness.

## 🤖 Authorship & Tooling

All architectural decisions and implementation were authored by the developer.

AI tools were selectively used to assist with documentation and presentation, ensuring clear and concise communication without detracting from technical ownership.

This approach highlights efficient use of modern tooling while maintaining high engineering standards.

## 🚀 Features

- RESTful HTTP endpoints
- Standard CRUD operations
- Clear request / response contracts
- Proper HTTP status code usage
- Dockerized application

## 🧱 Basic Clean Architecture

The solution follows a **very basic Clean Architecture approach**, keeping layers explicit but lightweight:

- **API layer**  
  Handles HTTP concerns such as routing, controllers, and status codes

- **Application layer**  
  Contains use-case logic and orchestrates application flow

- **Domain layer**  
  Defines core entities and business rules

- **Infrastructure layer**  
  Provides technical implementations (e.g. data access)

This structure ensures low coupling, better testability, and easier future extension.

## 🔌 Available Endpoints

The API exposes a simple REST interface:

- `GET /api/{resource}`  
  Retrieve all resources

- `GET /api/{resource}/{id}`  
  Retrieve a single resource by ID

- `POST /api/{resource}`  
  Create a new resource

- `PUT /api/{resource}/{id}`  
  Update an existing resource

- `DELETE /api/{resource}/{id}`  
  Delete a resource

> Endpoints follow standard REST conventions and return appropriate HTTP status codes.

## 🛠 Tech Stack

- ASP.NET Core (.NET9)
- C#
- Docker

## 📌 Purpose

This project serves as:

- A **developer portfolio example**
- A reference for clean REST API structure
- A starting point for small backend services
