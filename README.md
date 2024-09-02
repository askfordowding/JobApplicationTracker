# JobApplicationTracker

# Job Application Tracker

## Overview

Job Application Tracker is a web application designed to help users track their job applications. It allows users to manage job application data, including application dates, CVs, contacts, cover letters, and interview schedules. The application utilizes microservices architecture and follows SOLID principles for clean and maintainable code.

## Features

- Track job applications with detailed information.
- Manage CVs and cover letters.
- Schedule and track interviews.
- Add and manage notes related to each job application.
- Integration with job platforms via REST APIs.

## Architecture

The project is structured into several key components:

1. **API Layer (`JobApplicationService.API`)**:
   - Provides RESTful APIs for interacting with the job application data.

2. **Core Layer (`JobApplicationService.Core`)**:
   - Contains the core business logic and interfaces.

3. **Infrastructure Layer (`JobApplicationService.Infrastructure`)**:
   - Implements the core interfaces and manages data access using Entity Framework.

4. **Testing Layer (`JobApplicationService.IntegrationTests`)**:
   - Contains integration tests to ensure the application works as expected.

## Technologies Used

- **.NET Core 8.0**: Framework for building the web application.
- **ASP.NET Core**: For building the RESTful APIs.
- **Entity Framework Core**: For data access and ORM.
- **SQL Server**: Database for storing application data.
- **Vue.js**: Frontend framework for building the user interface.
- **Swagger**: For API documentation.
- **xUnit**: For unit and integration testing.

## Getting Started

### Prerequisites

- [.NET Core SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Node.js](https://nodejs.org/) (for running the frontend)

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/JobApplicationTracker.git
   cd JobApplicationTracker
