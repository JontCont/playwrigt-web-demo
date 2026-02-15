# Playwright Web Demo

[繁體中文版](./README.zh-TW.md)

A full-stack monorepo featuring an **Angular** frontend managed by **Nx** and a **.NET 10** microservices backend, all containerized with **Docker**. This project is designed as a demonstration for comprehensive end-to-end (E2E) testing with **Playwright**.

## 🚀 Quick Start

The easiest way to run the entire stack is using Docker Compose.

```bash
# Clone the repository
git clone <your-repo-url>
cd playwright-web-demo

# Start all services
docker-compose up --build
```

- **Frontend App**: [http://localhost:4200](http://localhost:4200)
- **Admin Dashboard**: [http://localhost:4201](http://localhost:4201)
- **API Gateway**: [http://localhost:5000](http://localhost:5000)

### 🔐 Default Credentials (Mock Data)

| Role | Username | Password |
| :--- | :--- | :--- |
| **User** | `user` | `password` |
| **Admin** | `admin` | `admin` |

## 🛠 Technologies

### Frontend
- **Angular 19+**: Standalone components, Signals, and modern routing.
- **Nx**: Monorepo management and build optimization.
- **SCSS**: Global and component-level styling.

### Backend
- **.NET 10**: High-performance microservices.
- **Ocelot**: API Gateway for unified entry point and routing.
- **PostgreSQL**: Relational database (containerized).

### Testing & DevOps
- **Playwright**: Robust E2E testing for multi-app flows.
- **Docker**: Containerization for consistent development and deployment.
- **Nginx**: Serving static Angular builds in production mode.

## 📂 Project Structure

```text
├── apps/
│   ├── frontend/         # User-facing Angular app
│   ├── admin/            # Admin Dashboard Angular app
│   └── *-e2e/            # Playwright E2E tests
├── backend/
│   ├── gateway/          # Ocelot API Gateway
│   ├── admin-api/        # Admin-specific microservice
│   ├── frontend-api/     # User-specific microservice
│   └── shared/           # Shared C# DTOs and Logic
├── libs/
│   └── shared/           # Shared Angular libraries
└── docker-compose.yml    # Service orchestration
```

## 🧪 Running Tests

### E2E Tests (Playwright)
Ensure the services are running, then execute:

```bash
# Run all E2E tests
npx nx run-many -t e2e

# Run specific E2E project
npx nx e2e frontend-e2e
```

## 📝 Configuration

- **Docker Override**: `docker-compose.override.yml` is used for local development settings (ignored by Git).
- **Environment**: Backend services default to `Development` in the override to enable Swagger and detailed logging.

## ⚠️ Security Note
This project currently uses **Mock Authentication** and **Hardcoded Secrets** for demonstration purposes. Before deploying to a production environment, ensure all secrets are moved to a secure Secret Manager and the authentication logic is integrated with a real Identity Provider.
