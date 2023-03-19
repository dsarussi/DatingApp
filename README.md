# DatingApp Architecture Document
The DatingApp project is a web application built using .NET Core and Angular frameworks.
The purpose of the application is to allow users to register, create profiles, and interact with each other through messaging and photo sharing.

## Components
### Server-side
The server-side component of the application is built using the .NET Core framework. The main components include:

#### Controllers:
These are responsible for handling incoming requests from the client and returning appropriate responses. The API controllers use the ApiController attribute to specify the routing and behavior of the controller.

#### Models:
These are used to define the data structures and entities used in the application.

#### Data Access Layer (DAL):
This layer is responsible for interacting with the database. The DAL uses Entity Framework Core to map the models to the database schema.

#### Services:
These are responsible for implementing the application logic. The services use the DAL to read and write data to the database.

#### SignalR:
SignalR is used to enable real-time communication between the server and the client.

### Client-side
The client-side component of the application is built using the Angular framework. The main components include:

#### Components:
These are the building blocks of the UI. Each component is responsible for rendering a specific part of the application's UI.

#### Services:
These are responsible for implementing the client-side application logic. The services use the HTTP client to communicate with the server-side API.

#### Directives:
These are used to add behavior to HTML elements in the application.

#### Pipes:
These are used to transform data before it is displayed in the UI.

#### Models:
These are used to define the data structures used in the application.

## Design Patterns and Principles
The DatingApp project follows the following design patterns and principles:

#### Model-View-Controller (MVC):
The application's architecture follows the MVC pattern. The server-side API controllers serve as the controllers, while the client-side components serve as the views.

#### Repository pattern:
The DAL uses the repository pattern to encapsulate the data access logic and provide a clean separation of concerns.

#### Dependency Injection (DI):
The application uses DI to manage the dependencies between components.

#### Single Responsibility Principle (SRP):
Each component in the application has a single responsibility and does it well.

#### Don't Repeat Yourself (DRY):
The application follows the DRY principle by reusing code where possible.

## Deployment and Infrastructure
The application is deployed to Fly.io, a platform for building and deploying containerized applications. The application is packaged as a Docker container and deployed to Fly.io using a GitHub Actions workflow.

## Security
The application implements authentication and authorization using JSON Web Tokens (JWTs). Passwords are hashed using the bcrypt algorithm to protect user data.

## Performance and Scalability
The application implements paging, sorting, and filtering to improve performance when handling large datasets. SignalR is used to enable real-time communication between the server and the client.

## Conclusion
The DatingApp project is a web application built using .NET Core and Angular frameworks. The application uses a client-server architecture, with the server-side component built using .NET Core and the client-side component built using Angular. The application follows the MVC pattern, repository pattern, and other best practices to ensure a clean and maintainable codebase. The application is deployed to Fly.io, a platform for building and deploying containerized applications.

## Key Features
Authentication
Client register and login
Error handling
User interface
Photo management
Reactive forms
Paging, sorting, and filtering
Messaging
SignalR
