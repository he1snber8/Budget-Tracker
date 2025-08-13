# Budget-Tracker — title

Description: A platform that helps users manage expenses, set savings goals, and receive AI-powered recommendations for smarter financial decisions.

## Tech Stack
- Scala (AI/ML recommendation service)
- Express.js (Node.js API gateway)
- ASP.NET Core (Core back-end API)

## Requirements
- Manage expenses
- Set savings goals
- Provide AI-powered recommendations for smarter financial decisions

## Installation
Prerequisites:
- Node.js 18+ and npm
- .NET 8 SDK
- Java 11+ and Scala 3
- sbt 1.9+

Repository structure (suggested):
- services/core-service (ASP.NET Core Web API)
- services/api-gateway (Express.js)
- services/ai-service (Scala service)

1) Core Service (ASP.NET Core)
- Navigate: cd services/core-service
- If starting from scratch: dotnet new webapi -n CoreService
- Restore/build: dotnet restore and dotnet build
- Environment variables:
  - ASPNETCORE_URLS=http://localhost:5199
  - DATABASE_URL=(optional; use for persistence if configured)
- Run: dotnet run
- Key files (typical): Program.cs, appsettings.json, Controllers/ (or Minimal APIs in Program.cs)

2) API Gateway (Express.js)
- Navigate: cd services/api-gateway
- Initialize/install: npm init -y and npm install express dotenv node-fetch
- Create a .env file with:
  - PORT=3000
  - CORE_SERVICE_URL=http://localhost:5199
  - AI_SERVICE_URL=http://localhost:7070
- Start: node server.js (or add a start script in package.json and use npm start)
- Key files (typical): package.json, server.js, .env

3) AI Service (Scala)
- Navigate: cd services/ai-service
- Initialize sbt project: sbt new scala/scala3.g8 (or ensure build.sbt exists)
- Add a main class to start a simple HTTP server using Java's built-in HttpServer
- Environment variables:
  - AI_SERVICE_PORT=7070
  - MODEL_PATH=(optional; path to a serialized rules/config file if used)
- Run: sbt run
- Key files (typical): build.sbt, src/main/scala/RecommendationServer.scala

Verification:
- Check Node.js: node -v
- Check .NET: dotnet --version
- Check Java: java -version
- Check sbt: sbt sbtVersion

## Usage
- Start the AI Service (Scala) on port 7070
- Start the Core Service (ASP.NET Core) on port 5199
- Start the API Gateway (Express.js) on port 3000

Example requests (through the API Gateway on http://localhost:3000):
- Create an expense: POST /api/expenses with JSON body { "amount": 125.50, "category": "Food", "date": "2025-01-10", "note": "Groceries" }
- List expenses: GET /api/expenses
- Create a goal: POST /api/goals with JSON body { "name": "Emergency Fund", "targetAmount": 1000, "deadline": "2025-12-31" }
- Get recommendations: POST /api/recommendations with JSON body { "expenses": [...], "goals": [...] }

## Implementation Steps
1. Scaffold services
   - Create three services: core-service (ASP.NET Core Web API), api-gateway (Express.js), ai-service (Scala)
   - Ensure typical files exist: Program.cs/appsettings.json (ASP.NET), package.json/server.js/.env (Express), build.sbt/src/main/scala (Scala)

2. Core domain models (ASP.NET Core)
   - Implement models: Expense { id, amount, category, date, note }, Goal { id, name, targetAmount, deadline, progress }
   - Use in-memory storage initially for expenses and goals (thread-safe collections)

3. Core API endpoints (ASP.NET Core)
   - CRUD for /expenses and /goals (GET all, GET by id, POST, PUT, DELETE)
   - Optional summaries: GET /summary for totals by category and progress toward goals

4. AI Service (Scala)
   - Implement a simple HTTP server using Java HttpServer
   - Expose POST /recommendations
   - Input: { expenses: [...], goals: [...] }
   - Output: { tips: [...], savingsOpportunities: [...], riskAlerts: [...] }
   - Start on AI_SERVICE_PORT (default 7070)

5. API Gateway (Express.js)
   - Implement routes under /api that proxy to the Core Service and AI Service
   - /api/expenses and /api/goals forward to Core Service
   - /api/recommendations forwards body to AI Service and returns AI output
   - Load CORE_SERVICE_URL and AI_SERVICE_URL from environment variables

6. Validation and error handling
   - Validate request bodies (amount > 0, dates are ISO-8601)
   - Normalize errors to JSON with status codes

7. Configuration
   - Use environment variables in all services
   - Document defaults and how to override ports

8. Run and test
   - Start services in separate terminals
   - Use curl or any REST client to verify endpoints

(Optional) ## API Endpoints
API Gateway (Express.js) — base: http://localhost:3000/api
- Expenses
  - GET /expenses — list expenses
  - GET /expenses/:id — get an expense by id
  - POST /expenses — create an expense
  - PUT /expenses/:id — update an expense
  - DELETE /expenses/:id — delete an expense
- Goals
  - GET /goals — list goals
  - GET /goals/:id — get a goal by id
  - POST /goals — create a goal
  - PUT /goals/:id — update a goal
  - DELETE /goals/:id — delete a goal
- Recommendations
  - POST /recommendations — body: { expenses: [...], goals: [...] } → proxies to AI Service

Core Service (ASP.NET Core) — base: http://localhost:5199
- /expenses — same verbs as above
- /goals — same verbs as above
- /summary — optional aggregated data

AI Service (Scala) — base: http://localhost:7070
- POST /recommendations — returns AI-driven suggestions based on provided expenses and goals