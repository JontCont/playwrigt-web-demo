# Playwright 網頁測試整合 Demo

這是一個完整的全端 Monorepo 專案，前端使用 **Angular** 並由 **Nx** 管理，後端則是基於 **.NET 10** 的微服務架構，整體環境透過 **Docker** 容器化。本專案的主要目的是作為 **Playwright** 全方位端對端 (E2E) 測試的示範。

[English Version](./README.md)

## 🚀 快速開始

使用 Docker Compose 是啟動整個開發環境最簡單的方式。

```bash
# 複製專案
git clone <your-repo-url>
cd playwright-web-demo

# 啟動所有服務
docker-compose up --build
```

- **前台應用 (Frontend)**：[http://localhost:4200](http://localhost:4200)
- **後台管理 (Admin)**：[http://localhost:4201](http://localhost:4201)
- **API 閘道 (Gateway)**：[http://localhost:5000](http://localhost:5000)

### 🔐 預設測試帳號 (模擬數據)

| 角色 | 帳號 | 密碼 |
| :--- | :--- | :--- |
| **一般使用者** | `user` | `password` |
| **管理員** | `admin` | `admin` |

## 🛠 使用技術

### 前端
- **Angular 19+**：使用獨立元件 (Standalone Components)、Signals 等現代化特性。
- **Nx**：Monorepo 管理與建置優化。
- **SCSS**：全域與元件級樣式設計。

### 後端
- **.NET 10**：高效能微服務框架。
- **Ocelot**：API Gateway，負責統一入口與路由轉發。
- **PostgreSQL**：關聯式資料庫 (容器化)。

### 測試與開發維運
- **Playwright**：強大的 E2E 測試框架，支援跨應用的流程測試。
- **Docker**：確保開發與部署環境的一致性。
- **Nginx**：在生產模式下部署 Angular 靜態資源。

## 📂 專案結構

```text
├── apps/
│   ├── frontend/         # 使用者前台
│   ├── admin/            # 管理員後台
│   └── *-e2e/            # Playwright E2E 測試專案
├── backend/
│   ├── gateway/          # Ocelot API 閘道
│   ├── admin-api/        # 後台微服務
│   ├── frontend-api/     # 前台微服務
│   └── shared/           # 共用 C# DTO 與邏輯
├── libs/
│   └── shared/           # 共用 Angular 函式庫
└── docker-compose.yml    # 容器編排設定
```

## 🧪 執行測試

### E2E 測試 (Playwright)
請確保服務已啟動，然後執行：

```bash
# 執行所有 E2E 測試
npx nx run-many -t e2e

# 執行特定專案的 E2E 測試
npx nx e2e frontend-e2e
```

## 📝 配置說明

- **Docker Override**：`docker-compose.override.yml` 用於本機開發設定 (Git 已忽略)。
- **環境設定**：後端服務在 Override 中預設設為 `Development` 以啟用 Swagger 與詳細日誌。

## ⚠️ 安全性提醒
本專案目前為了示範目的，使用了 **模擬身份驗證與固定密鑰**。在部署到任何正式環境前，請務必將所有密鑰移至安全的 Secret Manager，並將驗證邏輯整合至真實的身份驗證提供商。
