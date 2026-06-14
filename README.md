# enterprise-data-pipeline-core
High-throughput, asynchronous distributed data synchronization and ingestion engine built on .NET 8, clean architecture, MediatR, and AWS SQS/Lambda infrastructure.
# Enterprise Data Pipeline Core (.NET 8)

A production-grade, highly scalable distributed data ingestion engine designed under strict SOLID principles and Clean Architecture guidelines. Developed to solve complex multi-country data latency, transaction processing challenges, and real-time synchronization pipelines under high-throughput requirements.

## Architectural Highlights
- **Clean Architecture Layers:** Strictly decoupled Domain, Application, Infrastructure, and WebAPI layers to maintain zero tight-coupling and enforce clear separation of concerns.
- **High-Throughput WebAPI:** Built on .NET 8 Minimal APIs to eliminate the legacy controller overhead, guaranteeing sub-millisecond network response metrics.
- **Cross-Cutting Pipeline Concerns:** Implemented custom MediatR pipeline behaviors for automated execution auditing, fluent validation interceptors, and background performance tracing.
- **AWS Infrastructure Node:** Integrated custom hosted background workers (`IHostedService`) for asynchronous high-volume message event stream handling (AWS SQS/SNS).
- **Enterprise Observability:** Enforced structured logging via Serilog sinks and strict exception-handling middleware for 100% data integrity and system resilience.

