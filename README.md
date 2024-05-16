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
 
## Spin Up Docker Compose To Run The Application
In the root directory of the project run `docker compose up` to spin up the application both the backend api, database, and the web app.
 
## Integration Tests
The API integration tests can be executed by this command `dotnet test TodoTest`