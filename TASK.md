---

kanban-plugin: board

---

## План

- [ ] **1.2 · Domain и PostgreSQL** — Session: состояния, переходы, срок жизни и Version; unit-тесты переходов. Оценка: 2 дня.
- [ ] **1.3 · Domain и PostgreSQL** — SessionMembership: присоединение, закрытие, начальный desired state. Оценка: 1 день.
- [ ] **1.4 · Domain и PostgreSQL** — DbContext и mappings для User, Device, Session и SessionMembership; связи, check constraints и уникальные индексы. Оценка: 2 дня.
- [ ] **1.5 · Domain и PostgreSQL** — Регистрация persistence в DI, первая миграция и её применение. Оценка: 1 день.
- [ ] **1.6 · Domain и PostgreSQL** — Инфраструктура интеграционных тестов с PostgreSQL Testcontainers; проверка ограничений БД. Оценка: 2 дня.
- [ ] **2.1 · Пользователи и аутентификация** — Общие ProblemDetails, обработка ожидаемых ошибок и валидация запросов. Оценка: 1 день.
- [ ] **2.2 · Пользователи и аутентификация** — Регистрация: нормализация email, PasswordHasher, уникальность; тесты. Оценка: 2 дня.
- [ ] **2.3 · Пользователи и аутентификация** — Login, выпуск и проверка JWT, Options с проверкой при старте. Оценка: 2 дня.
- [ ] **2.4 · Пользователи и аутентификация** — Политики user/device, текущая identity, rate limits для register/login; тесты авторизации. Оценка: 2 дня.
- [ ] **3.1 · Устройства** — Регистрация устройства, генерация credential, хранение хеша и однократная выдача секрета. Оценка: 2 дня.
- [ ] **3.2 · Устройства** — Список и получение устройств: ownership, cursor pagination, DTO без секретов. Оценка: 1 день.
- [ ] **3.3 · Устройства** — Обмен device credential на JWT, проверка отзыва, ограничения token endpoint. Оценка: 2 дня.
- [ ] **3.4 · Устройства** — Отзыв устройства; интеграционные тесты credentials, ownership и отозванного доступа. Оценка: 2 дня.
- [ ] **4.1 · Сессии и membership** — Создание, получение и список сессий; ownership и lifetime. Оценка: 1 день.
- [ ] **4.2 · Сессии и membership** — Start/Pause/Resume: expectedVersion, блокировки, проверка истечения срока, HTTP 409. Оценка: 2 дня.
- [ ] **4.3 · Сессии и membership** — Присоединение устройства: уникальность открытого membership, обработка конкурентных join. Оценка: 2 дня.
- [ ] **4.4 · Сессии и membership** — Leave и Complete: атомарное закрытие membership. Оценка: 2 дня.
- [ ] **4.5 · Сессии и membership** — Интеграционные тесты переходов, stale version, конкурентных join и закрытия. Результат блока: авторизованный REST API с устройствами и сессиями. Оценка: 2 дня.
- [ ] **5.1 · Presence и команды** — Redis в Compose, heartbeat с TTL, Online/Offline/Unknown; тесты. Оценка: 2 дня.
- [ ] **5.2 · Presence и команды** — Command, terminal statuses, mappings и миграция; unit-тесты правил. Оценка: 2 дня.
- [ ] **5.3 · Presence и команды** — Создание команды: блокировки, атомарная revision, обновление snapshot и superseding. Оценка: 2 дня.
- [ ] **5.4 · Presence и команды** — HTTP idempotency: запись immutable receipt, canonical hash и конкурентные повторы; тесты. Оценка: 2 дня.
- [ ] **5.5 · Presence и команды** — Получение команды, desired-state и pending recovery; фильтрация закрытых и истёкших сессий. Оценка: 2 дня.
- [ ] **5.6 · Presence и команды** — ACK: ownership, revision, terminal precedence и повторные подтверждения. Оценка: 2 дня.
- [ ] **5.7 · Presence и команды** — Тесты гонок ACK/Supersede/Complete и восстановления immutable receipt. Оценка: 2 дня.
- [ ] **6.1 · SignalR и Simulator** — SignalR Hub: device authentication, серверные группы и проверки отзыва. Оценка: 2 дня.
- [ ] **6.2 · SignalR и Simulator** — Временный database-backed dispatcher: поиск актуальных Pending-команд и уведомления через SignalR. Оценка: 2 дня.
- [ ] **6.3 · SignalR и Simulator** — Simulator: setup через HTTP, device authentication, heartbeat и обновление JWT. Оценка: 2 дня.
- [ ] **6.4 · SignalR и Simulator** — Simulator: HTTP reconciliation, последовательное применение snapshot, reset membership и ACK. Оценка: 2 дня.
- [ ] **6.5 · SignalR и Simulator** — Simulator: SignalR, initial connection retry и reconnect; уведомления запускают reconciliation. Оценка: 2 дня.
- [ ] **6.6 · SignalR и Simulator** — Тесты восстановления: потеря ACK, пропуск уведомления, устаревшая revision и отсутствие SignalR. Оценка: 2 дня.
- [ ] **6.7 · SignalR и Simulator** — Dockerfiles, отдельный migration step, запуск API/Worker через Compose и инструкция демонстрации. Результат блока: Milestone A — демонстрация от запроса до применения состояния устройством. Оценка: 2 дня.
- [ ] **7.1 · RabbitMQ и Outbox** — RabbitMQ в Compose, versioned contracts, topology команд, publisher confirms и mandatory routing. Оценка: 2 дня.
- [ ] **7.2 · RabbitMQ и Outbox** — Таблица Outbox и атомарная запись события вместе с командой. Оценка: 2 дня.
- [ ] **7.3 · RabbitMQ и Outbox** — Worker publisher: batch claim, lease, ClaimToken и публикация вне транзакции. Оценка: 2 дня.
- [ ] **7.4 · RabbitMQ и Outbox** — Retry публикаций, восстановление lease, Failed и явный replay; тесты. Оценка: 2 дня.
- [ ] **7.5 · RabbitMQ и Outbox** — API notification consumer: проверка актуальности, SignalR и manual ACK; отключение временного dispatcher. Оценка: 2 дня.
- [ ] **7.6 · RabbitMQ и Outbox** — Отдельные retry queues и DLQ уведомлений; confirmed handoff перед ACK. Оценка: 2 дня.
- [ ] **7.7 · RabbitMQ и Outbox** — Тесты сбоев: дубли публикации, stale claim, недоступный брокер и неподтверждённый handoff. Оценка: 2 дня.
- [ ] **8.1 · Telemetry и завершение V1** — Telemetry contracts, broker topology и admission endpoint: validation, locks, confirm и bounded concurrency. Оценка: 2 дня.
- [ ] **8.2 · Telemetry и завершение V1** — ProcessedMessage, TelemetryAggregate, mappings и миграция; canonical payload hash. Оценка: 2 дня.
- [ ] **8.3 · Telemetry и завершение V1** — Worker aggregation: minute buckets, histogram, атомарные UPSERT и deduplication. Оценка: 2 дня.
- [ ] **8.4 · Telemetry и завершение V1** — Telemetry retry/DLQ dispatcher, processing window и конфликтующие BatchId. Оценка: 2 дня.
- [ ] **8.5 · Telemetry и завершение V1** — Интеграционные тесты дублей, конкурентной агрегации и обработки после закрытия membership. Оценка: 2 дня.
- [ ] **8.6 · Telemetry и завершение V1** — Session/command expiration: bounded batches, общий порядок блокировок и terminal precedence. Оценка: 2 дня.
- [ ] **8.7 · Telemetry и завершение V1** — Retention cleanup с сохранением idempotency/recovery гарантий. Оценка: 2 дня.
- [ ] **8.8 · Telemetry и завершение V1** — Dapper statistics endpoint: объединение buckets и вычисление P95 из histogram; тесты. Оценка: 2 дня.
- [ ] **8.9 · Telemetry и завершение V1** — Serilog, безопасные structured logs и liveness/readiness. Оценка: 2 дня.
- [ ] **8.10 · Telemetry и завершение V1** — OpenTelemetry, Jaeger и trace context через RabbitMQ. Оценка: 2 дня.
- [ ] **8.11 · Telemetry и завершение V1** — GitHub Actions: restore, build, tests и Docker build. Оценка: 1 день.
- [ ] **8.12 · Telemetry и завершение V1** — NBomber: первый воспроизводимый workload и исходные измерения. Оценка: 2 дня.
- [ ] **8.13 · Telemetry и завершение V1** — Одна оптимизация по измеренному bottleneck и повторный замер. Оценка: 2 дня.
- [ ] **8.14 · Telemetry и завершение V1** — README, architecture, decisions, performance и ограничения V1. Результат блока: полная спецификация V1 и воспроизводимая проверка проекта. Оценка: 2 дня.


## В работе



## Готово

**Complete**
- [x] **1.1 · Domain и PostgreSQL** — User и Device: поля, создание, базовые ограничения. Оценка: 1 день.




%% kanban:settings
```
{"kanban-plugin":"board","list-collapse":[false,false,false]}
```
%%