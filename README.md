
# CinemaCalc API

CinemaCalc API is a RESTful service for managing expenses related to cinema operations. It provides endpoints to create, read, update, and delete expense records.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Installation

1. Open this project:
    ```sh
    cd CinemaCalc
    ```

2. Set up the PostgreSQL database and update the connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=cinemacalc;Username=yourusername;Password=yourpassword"
    }
    ```

3. Apply database migrations:
    ```sh
    dotnet ef database update
    ```

4. Build and run the application:
    ```sh
    dotnet run
    ```

## Usage

Once the application is running, you can access the API at `http://localhost:5000/api/Expenses`.

## API Endpoints

### GET /api/Expenses

Retrieve a list of all expenses.

### GET /api/Expenses/{id}

Retrieve a specific expense by ID.

### POST /api/Expenses

Create a new expense.

### PUT /api/Expenses/{id}

Update an existing expense by ID.

### DELETE /api/Expenses/{id}

Delete an expense by ID.
