# Comply Test Project
A web application that allows users to view a list of items and add new items. The application is developed using Angular and .NET 8.

## Directory Structure

This project contains the following folders:
- `TodoApi`: Entrypoint that bootstraps and runs the backend .NET Core Web Api
- `TodoTest`: Contains Api integration tests
- `TodoUi`: Frontend application in Angular

## Application Setup

- `Database`: The application uses SQLite database, and EF Core migrations tool for applying domain entity changes to the database.
- `Backend`: The Api is written using `.NET Core 8.0`
- `Frontend`: The front is built using `Angular v17`

## Database
The EF Core tools is needed to create a database and run migrations. Runs this command to install the EF core tools `dotnet tool install --global dotnet-ef`. 
Once the EF Core tools is installed, proceed to apply any pending migrations by executing this command `dotnet ef database  update -- --Database "Data Source=..\\todo.db"`

## API
To run the API, execute this command: `dotnet run --project TodoApi --launch-profile http`

## UI
The frontend can be run by first installing packages with `npm i`, then start server with: `npm start` command

## Integration Tests
The API integration tests can be executed by this command `dotnet test TodoTest`