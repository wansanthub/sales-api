# sales-api

## Running the Project
To run the project, follow these steps:

### **1. Install Dependencies**
Ensure you have the following installed:
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)
- Update Linux Sub System version on Windows

### **2. Run RabbitMQ using Docker Compose**
Use the following `docker-compose.yml` file to start RabbitMQ:

```yaml
version: '3.8'

services:
  rabbitmq:
    image: rabbitmq:3-management
    container_name: rabbitmq
    restart: always
    ports:
      - "5672:5672"  # RabbitMQ broker port
      - "15672:15672"  # RabbitMQ management UI
    environment:
      RABBITMQ_DEFAULT_USER: guest
      RABBITMQ_DEFAULT_PASS: guest
```
Run the command:
```sh
docker-compose up -d
```
This will start RabbitMQ in the background.

### **3. Configure Environment Variables**
Ensure the application has the required environment settings:
```sh
RABBITMQ_HOST=localhost
RABBITMQ_PORT=5672
```

### **4. Run the Application**
```sh
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

### **5. Access the API**
Once running, the API will be available at:
```
http://localhost:5000
```
RabbitMQ Management UI:
```
http://localhost:15672
```
(Default username/password: guest/guest)

## Running Tests
To run unit tests, execute:
```sh
dotnet test
```

## Overview
This section provides a high-level overview of the project and the various skills and competencies it aims to assess for developer candidates. 

See [Overview](/.doc/overview.md)

## Tech Stack
This section lists the key technologies used in the project, including the backend, testing, frontend, and database components. 

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
This section outlines the frameworks and libraries that are leveraged in the project to enhance development productivity and maintainability. 

See [Frameworks](/.doc/frameworks.md)