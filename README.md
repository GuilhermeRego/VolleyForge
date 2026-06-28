# VolleyForge

VolleyForge is a backend-first volleyball management platform built with .NET.

The project is designed as a learning and portfolio project, with the goal of developing strong backend engineering skills through a real domain: clubs, teams, players, matches, standings and statistics.

## Goals

The main goal of this project is to build a production-oriented backend application while practicing:

* Clean Architecture principles
* Domain-driven design fundamentals
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Docker
* Automated testing
* CI/CD
* Cloud deployment
* Technical documentation

## Solution Structure

```txt
VolleyForge/
├── src/
│   ├── VolleyForge.Domain/
│   ├── VolleyForge.Application/
│   ├── VolleyForge.Infrastructure/
│   └── VolleyForge.API/
│
├── tests/
│   └── VolleyForge.Tests/
│
└── docs/
```

## Architecture

The solution follows a layered architecture inspired by Clean Architecture.

### Domain

Contains the core business concepts and rules.

Examples:

* Club
* Player
* Match
* Season
* AgeGroup
* Gender

The Domain project should not depend on infrastructure concerns such as databases, APIs, frameworks or external services.

### Application

Contains application use cases, contracts, commands, queries and abstractions.

This layer defines what the system can do, but does not implement infrastructure details.

### Infrastructure

Contains technical implementations such as persistence, database access and external integrations.

Examples:

* Entity Framework Core DbContext
* Repository implementations
* PostgreSQL configuration

### API

Contains the HTTP interface exposed through ASP.NET Core Web API.

The API should be thin and delegate business/application logic to the Application layer.

### Tests

Contains automated tests for domain logic, application use cases and API behavior.

## Tech Stack

Planned stack:

* .NET
* ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Docker
* xUnit
* GitHub Actions
* Azure

## Roadmap

### Sprint 0 — Project Foundation

* Create solution structure
* Add initial domain entities
* Add first API endpoint
* Add first domain tests
* Add initial documentation

### Sprint 1 — Persistence

* Add PostgreSQL
* Add Docker Compose
* Add Entity Framework Core
* Add DbContext
* Add first migration
* Persist Clubs in the database

### Sprint 2 — Application Layer

* Add commands and queries
* Add validation
* Add use cases for Clubs and Players
* Keep controllers thin

### Sprint 3 — Volleyball Domain

* Add Matches
* Add volleyball-specific rules
* Add standings calculation
* Add domain tests

### Sprint 4 — Quality and Observability

* Add structured logging
* Add error handling
* Add Problem Details
* Add performance-focused queries

### Sprint 5 — Authentication and Security

* Add authentication
* Add authorization
* Add roles
* Document security decisions

### Sprint 6 — Delivery

* Add CI pipeline
* Add Docker build
* Add cloud deployment
* Add monitoring

## Learning Principles

This project follows a project-first learning approach.

The goal is not to consume resources passively, but to learn concepts when they become necessary to solve real problems inside the project.

Core rules:

* Build first, study when blocked.
* Keep commits small.
* Write tests from the beginning.
* Document architectural decisions.
* Do not add complexity without a clear reason.
* Do not use AI-generated code that cannot be explained.

## Running the Project

Instructions will be added as the project evolves.

Planned local setup:

```bash
dotnet build
dotnet test
dotnet run --project src/VolleyForge.API
```

## License

This project is currently intended for learning and portfolio purposes.
