# Project Overview

This is a full-stack monorepo featuring an Angular frontend managed by Nx and a .NET-based microservices backend. It leverages modern Angular features like standalone components and is set up for comprehensive testing with Vitest/Jest for unit tests and Playwright for end-to-end (E2E) tests. The backend consists of multiple .NET APIs and a gateway using Ocelot.

## Main Technologies

- **Nx**: Monorepo management for the frontend.
- **Angular**: Frontend framework (using standalone components, SCSS, and TypeScript).
- **.NET (C#)**: Backend framework for APIs and Gateway.
- **Ocelot**: API Gateway for the backend services.
- **Playwright**: End-to-end testing framework.
- **Vitest & Jest**: Unit testing frameworks for frontend and shared libraries.
- **ESLint & Prettier**: Code quality and formatting.

## Project Structure

- `apps/`: Contains Angular applications.
  - `admin/`: Admin dashboard application.
  - `admin-e2e/`: Playwright E2E tests for the admin application.
  - `frontend/`: Public-facing frontend application.
  - `frontend-e2e/`: Playwright E2E tests for the frontend application.
- `backend/`: Contains .NET microservices and shared projects.
  - `gateway/`: Ocelot API Gateway (entry point for all API requests).
  - `admin-api/`: Backend service specifically for the admin application.
  - `frontend-api/`: Backend service for the public-facing frontend application (handling products, users, and auth).
  - `shared/`: Shared .NET class library containing common DTOs and models.
- `libs/`: Contains shared frontend libraries and utilities.
  - `shared/utils/`: Common utility functions and shared logic.

## Building and Running

### Frontend (Nx)

All frontend commands should be executed from the root of the workspace using `npx nx`.

- **Serve Admin App**: `npx nx serve admin`
- **Serve Frontend App**: `npx nx serve frontend`
- **Build All**: `npx nx run-many -t build`
- **E2E Tests**: `npx nx e2e <e2e-project-name>`

### Backend (.NET)

Backend services are currently managed independently of the Nx workspace and can be run using the .NET CLI from their respective directories.

- **Run Gateway**: `cd backend/gateway && dotnet run`
- **Run Admin API**: `cd backend/admin-api && dotnet run`
- **Run Frontend API**: `cd backend/frontend-api && dotnet run`

> **Note**: Future integration into the Nx graph is possible by adding `project.json` files to the backend directories, enabling unified task running (e.g., `nx run-many -t serve`).

## Development Conventions

- **Standalone Components**: Follow the latest Angular patterns by using standalone components and avoiding unnecessary NgModules.
- **Styling**: Use SCSS for component styling. Follow the established structure in `src/styles.scss` for global styles.
- **Shared Code**: Place reusable logic, components, or utilities in the `libs/` directory.
- **Testing**:
  - Write unit tests for all new logic in `*.spec.ts` files.
  - Use Playwright for critical user flows in the `apps/*-e2e` projects.
- **Git**: Use meaningful commit messages. All changes should pass linting and testing before being merged.
