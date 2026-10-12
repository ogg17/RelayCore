# RelayCore

**Open-source real-time session orchestration platform built with C# and .NET.**

RelayCore is a backend system for managing connected applications, devices, live sessions, remote commands, and telemetry.

Designed for Unity applications, desktop software, simulators, and other real-time clients.

## Features

- Device registration and online/offline monitoring
- Live session lifecycle management
- Real-time commands via SignalR
- Telemetry collection and aggregation
- Reliable asynchronous event processing
- JWT authentication and authorization
- Idempotency and optimistic concurrency
- Distributed tracing and structured logging

## Tech Stack

- **Backend:** C#, .NET, ASP.NET Core
- **Database:** PostgreSQL, EF Core, Dapper
- **Caching:** Redis
- **Messaging:** RabbitMQ
- **Real-time:** SignalR
- **Infrastructure:** Docker Compose
- **Testing:** xUnit, Testcontainers
- **Observability:** Serilog, OpenTelemetry, Jaeger
- **CI:** GitHub Actions

## Architecture

RelayCore uses a **modular monolith** with a dedicated background worker for asynchronous processing.

```mermaid
flowchart TB
    C["Real-time Clients<br/>Unity · Desktop · Simulators"]

    subgraph APP["RelayCore"]
        direction TB
        API["ASP.NET Core API<br/>REST · JWT · SignalR"]
        CORE["Application Modules<br/>Auth · Devices · Sessions<br/>Commands · Telemetry"]
        WORKER["Background Worker<br/>Outbox · Telemetry · Cleanup"]

        API --> CORE
    end

    subgraph INFRA["Infrastructure"]
        direction LR
        PG[("PostgreSQL<br/>Persistent Data")]
        RD[("Redis<br/>Heartbeat · Cache")]
        MQ[["RabbitMQ<br/>Message Broker"]]
    end

    C <-->|HTTP / SignalR| API

    CORE <--> PG
    CORE <--> RD
    CORE --> MQ

    PG <--> WORKER
    MQ --> WORKER

    classDef client fill:#2563eb,stroke:#1d4ed8,color:#ffffff
    classDef service fill:#334155,stroke:#475569,color:#ffffff
    classDef storage fill:#0f766e,stroke:#115e59,color:#ffffff

    class C client
    class API,CORE,WORKER service
    class PG,RD,MQ storage

    style APP fill:none,stroke:#64748b,stroke-width:1px
    style INFRA fill:none,stroke:#64748b,stroke-width:1px
```

### Components

- **API:** HTTP endpoints, authentication, authorization, and real-time communication.
- **Application:** Business use cases, session management, commands, and telemetry ingestion.
- **Worker:** Outbox publishing, event consumption, telemetry aggregation, and cleanup.
- **PostgreSQL:** Persistent domain state and transactional Outbox.
- **Redis:** Ephemeral device presence and caching.
- **RabbitMQ:** Asynchronous message delivery.

The API and Worker share application and infrastructure libraries but run as separate processes.

## Project Status

Under active development.

## License

Apache License 2.0.
