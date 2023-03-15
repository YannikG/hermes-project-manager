# HERMES Project Manager
This project was initiated as a school assignment at TSBE HF in Bern on February 17th, 2023. The aim of this project is to provide support for project management using HERMES, a commonly used project methodology in Switzerland. The project is being developed using .NET 7.0, C# and Entity Framework, and it is designed to interact with a SQLite database. With this software, users will be able to manage their projects more effectively by using the HERMES methodology as a guide. By providing users with a user-friendly and intuitive interface, this software aims to simplify the process of project management, saving time and effort in the process.

## Project Goals
-	Develop a software application that can support project management using the HERMES methodology.
-	Utilize .NET 7.0, Entity Framework, and Swagger UI to create a reliable and developer-friendly application.
-	Implement a local hosting solution, requiring no setup for users.
-	Develop a HERMES-friendly project timeline builder that allows for easy categorization and definition of project phases.
-	Offer an API that allows for direct interaction with the application through Swagger UI.
- Publish project on Docker Hub for easy installation.

## Architecture
The software architecture for this project is designed to ensure separation of concerns and maintainability. The business logic is separated from the data access layer using the Service-Repository pattern, which promotes modularity and allows for easier unit testing. The entity framework is used for data access, but the business logic interacts with it through repositories.

To ensure that the API is not tightly coupled to the entity framework, it interacts only with the business logic, which provides an abstraction layer for the underlying data access layer. This allows for the API to remain decoupled from the data access layer, which is essential for maintainability and scalability.

## Wiki / Further documentation
The wiki provides details on the Service-Repository pattern, how the business logic interacts with the data access layer, and the structure of the API. It also provides information on how to set up the development environment, including instructions on how to clone the project from the repository. The wiki is an excellent resource for those looking to get started with the project, providing detailed technical information and step-by-step instructions for setting up the development environment and contributing to the project.

# Support my work
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/T6T7JEP5Q)
