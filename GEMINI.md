# Project Overview

This is an Nx-based monorepo containing multiple Angular applications and shared libraries. It leverages modern Angular features like standalone components and is set up for comprehensive testing with Vitest/Jest for unit tests and Playwright for end-to-end (E2E) tests.

## Main Technologies

- **Nx**: Monorepo management and build system.
- **Angular**: Frontend framework (using standalone components, SCSS, and TypeScript).
- **TypeScript**: Primary programming language.
- **Playwright**: End-to-end testing framework.
- **Vitest & Jest**: Unit testing frameworks.
- **ESLint**: Linting tool for code quality.
- **Prettier**: Code formatting.
- **SCSS**: CSS preprocessor for styling.

## Project Structure

- `apps/`: Contains application-specific code.
  - `admin/`: Admin dashboard application.
  - `admin-e2e/`: Playwright E2E tests for the admin application.
  - `frontend/`: Public-facing frontend application.
  - `frontend-e2e/`: Playwright E2E tests for the frontend application.
- `libs/`: Contains shared libraries and utilities.
  - `shared/utils/`: Common utility functions and shared logic.

## Building and Running

All commands should be executed from the root of the workspace using `npx nx`.

### Development

- **Serve Admin App**: `npx nx serve admin`
- **Serve Frontend App**: `npx nx serve frontend`

### Building

- **Build Admin App**: `npx nx build admin`
- **Build Frontend App**: `npx nx build frontend`
- **Build All**: `npx nx run-many -t build`

### Testing

- **Unit Tests**: `npx nx test <project-name>` (e.g., `npx nx test admin` or `npx nx test utils`)
- **E2E Tests**: `npx nx e2e <e2e-project-name>` (e.g., `npx nx e2e admin-e2e`)

### Linting and Formatting

- **Lint**: `npx nx lint <project-name>`
- **Format Check**: `npx prettier . --check`
- **Format Fix**: `npx prettier . --write`

### Workspace Visualization

- **Project Graph**: `npx nx graph`

## Development Conventions

- **Standalone Components**: Follow the latest Angular patterns by using standalone components and avoiding unnecessary NgModules.
- **Styling**: Use SCSS for component styling. Follow the established structure in `src/styles.scss` for global styles.
- **Shared Code**: Place reusable logic, components, or utilities in the `libs/` directory.
- **Testing**:
  - Write unit tests for all new logic in `*.spec.ts` files.
  - Use Playwright for critical user flows in the `apps/*-e2e` projects.
- **Git**: Use meaningful commit messages. All changes should pass linting and testing before being merged.
