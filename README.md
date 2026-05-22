# LojaCrud

> 🛍️ Sistema de gerenciamento CRUD para loja virtual. Aplicação ASP.NET Core MVC com Entity Framework Core para gestão de clientes e produtos.

[🇧🇷 Português](#-visão-geral-pt) | [🇺🇸 English](#-overview-en)

---

## 📋 Table of Contents

- [Visão Geral (PT)](#-visão-geral-pt)
- [Overview (EN)](#-overview-en)
- [Tech Stack](#-tech-stack)
- [Prerequisites](#-prerequisites)
- [Getting Started](#-getting-started)
- [Architecture](#-architecture)
- [Environment Variables](#-environment-variables)
- [Available Scripts](#-available-scripts)
- [Testing](#-testing)
- [Deployment](#-deployment)
- [Troubleshooting](#-troubleshooting)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🇧🇷 Visão Geral (PT)

Aplicação web ASP.NET Core MVC para gerenciamento de uma loja, permitindo operações CRUD completas em **Clientes** e **Produtos**. Desenvolvida com Entity Framework Core para persistência em SQL Server e interface responsiva com Bootstrap 5.

### Principais Funcionalidades

- ✅ CRUD completo para Clientes (Nome, Telefone)
- ✅ CRUD completo para Produtos (Nome, Quantidade, Valor, Cliente)
- ✅ Cálculo automático de `Total = Quantidade × Valor`
- ✅ Tabela com DataTables (busca, paginação, ordenação em PT-BR)
- ✅ Validação server-side e client-side com jQuery Validation
- ✅ Interface responsiva com Bootstrap 5
- ✅ Migrations do EF Core para versionamento do schema

---

## 🇺🇸 Overview (EN)

ASP.NET Core MVC web application for store management, providing full CRUD operations for **Customers** and **Products**. Built with Entity Framework Core for SQL Server persistence and a responsive Bootstrap 5 interface.

### Key Features

- ✅ Full CRUD for Customers (Name, Phone)
- ✅ Full CRUD for Products (Name, Quantity, Value, Customer)
- ✅ Auto-calculated `Total = Quantity × Value`
- ✅ DataTables integration (search, pagination, sorting in PT-BR)
- ✅ Server-side and client-side validation with jQuery Validation
- ✅ Responsive UI with Bootstrap 5
- ✅ EF Core Migrations for schema versioning

---

## 🛠 Tech Stack

| Category | Technology | Version | Purpose |
|----------|-----------|---------|---------|
| **Runtime** | .NET | 6.0 | Application runtime |
| **Framework** | ASP.NET Core MVC | 6.0 | Web framework, routing, controllers |
| **ORM** | Entity Framework Core | 6.0.36 | Database access, migrations |
| **Database** | SQL Server | 2019+ | Primary data store |
| **Database Provider** | Microsoft.EntityFrameworkCore.SqlServer | 6.0.36 | EF Core SQL Server adapter |
| **Frontend** | Bootstrap | 5.x | Responsive CSS framework |
| **Frontend** | jQuery | 3.x | DOM manipulation |
| **Frontend** | DataTables | 2.2.2 | Advanced table features |
| **Validation** | jQuery Validation + Unobtrusive | 1.19+ | Client-side form validation |
| **License** | GNU GPL v3 | — | Copyleft license |

### Project Dependencies (`LojaCrud.csproj`)

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.36" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.36" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.36" />
<PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="6.0.18" />
```

---

## 📦 Prerequisites

| Tool | Version | Purpose | Install Command |
|------|---------|---------|----------------|
| **.NET SDK** | 6.0.x | Build and run the application | [Download](https://dotnet.microsoft.com/download/dotnet/6.0) |
| **SQL Server** | 2019+ or Express | Database engine | [Download](https://www.microsoft.com/sql-server) |
| **Visual Studio 2022** | 17.x (optional) | IDE with .NET tooling | [Download](https://visualstudio.microsoft.com/) |
| **VS Code** | 1.80+ (optional) | Lightweight editor | [Download](https://code.visualstudio.com/) |
| **Git** | 2.30+ | Version control | `sudo apt install git` / `brew install git` |

### Verify Installation

```bash
# Check .NET SDK
dotnet --version
# Expected: 6.0.xxx

# Check EF Core tools (optional)
dotnet ef --version
# Expected: 6.0.xxx
```

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/tyxiel/tyxiel-lojacrud.git
cd tyxiel-lojacrud
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Configure Database Connection

**⚠️ Security Warning**: The default `appsettings.json` contains a development connection string with hardcoded credentials. **Never commit production credentials to source control.**

Edit `LojaCrud/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=YOUR_SERVER;Database=LojaDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

#### Connection String Options

| Scenario | Connection String Example |
|-------------------------------------|
| **Local SQL Server** | `Server=localhost\\SQLEXPRESS;Database=LojaDb;Trusted_Connection=True;TrustServerCertificate=True;` |
| **SQL Server Auth** | `Server=localhost;Database=LojaDb;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;` |
| **Azure SQL** | `Server=tcp:yourserver.database.windows.net,1433;Database=LojaDb;User Id=youruser@yourserver;Password=YourPassword;Encrypt=True;` |

### 4. Apply Database Migrations

```bash
# Navigate to project directory
cd LojaCrud

# Update database to latest migration
dotnet ef database update

# Or using Package Manager Console (Visual Studio):
# Update-Database
```

**Expected Output:**
```
Applying migration '20250306103500_FirstMigration'.
Applying migration '20250306134240_CreatingTotal'.
Done.
```

### 5. Run the Application

```bash
# From project root
dotnet run --project LojaCrud

# Or from LojaCrud directory
cd LojaCrud && dotnet run
```

**Expected Output:**
```
Now listening on: https://localhost:7279
Now listening on: http://localhost:5212
Application started. Press Ctrl+C to shut down.
```

### 6. Access the Application

Open your browser:
- 🔐 HTTPS: [https://localhost:7279](https://localhost:7279)
- 🌐 HTTP: [http://localhost:5212](http://localhost:5212)

### 7. Verify Functionality

| Feature | Test Steps | Expected Result |
|---------|-----------|----------------|
| **Home Page** | Navigate to root URL | Cards for "Clientes" and "Produtos" visible |
| **List Clients** | Click "Acessar Clientes" | Table with existing clients (or empty state) |
| **Create Client** | Click "Adicionar Cliente", fill form, submit | New client appears in list |
| **Edit Client** | Click "Editar" on a client, modify, save | Changes persist after redirect |
| **Delete Client** | Click "Apagar", confirm | Client removed from list |
| **Product Total** | Create product with Qty=2, Value=10.00 | Total column shows 20.00 |
| **DataTables** | Type in search box, change page | Table filters/paginates instantly |

---

## 🏗 Architecture

### Directory Structure

```
tyxiel-lojacrud/
├── LojaCrud.sln                    # Visual Studio solution file
├── LICENSE                         # GNU GPL v3 license
└── LojaCrud/                       # Main project
    ├── Program.cs                  # App entry point, DI, middleware pipeline
    ├── appsettings.json            # Configuration (connection strings, logging)
    ├── appsettings.Development.json # Environment-specific overrides
    ├── LojaCrud.csproj             # Project file, NuGet dependencies
    │
    ├── Controllers/                # MVC Controllers (request handlers)
    │   ├── HomeController.cs       # Landing page, privacy policy
    │   ├── ClienteController.cs    # CRUD for Cliente entity
    │   └── ProdutoController.cs    # CRUD for Produto entity (with client relation)
    │
    ├── Models/                     # Domain entities and DbContext
    │   ├── Cliente.cs              # Customer entity (Id, Nome, Telefone)
    │   ├── Produto.cs              # Product entity (Id, Nome, Quantidade, Valor, Total*)
    │   ├── LojaDbContext.cs        # EF Core DbContext with DbSet<TEntity>
    │   └── ErrorViewModel.cs       # Error page model
    │
    ├── Views/                      # Razor views (server-rendered HTML)
    │   ├── _ViewImports.cshtml     # Global @using and @addTagHelper
    │   ├── _ViewStart.cshtml       # Default layout for all views
    │   ├── Home/                   # Home controller views
    │   ├── Cliente/                # Cliente CRUD views (Index, Create, Edit, Details, Delete)
    │   ├── Produto/                # Produto CRUD views (same pattern)
    │   └── Shared/                 # Reusable partials and layout
    │       ├── _Layout.cshtml      # Master layout with nav, footer, scripts
    │       ├── _Layout.cshtml.css  # Layout-specific styles
    │       ├── _ValidationScriptsPartial.cshtml # jQuery Validation includes
    │       └── Error.cshtml        # Generic error page
    │
    ├── Migrations/                 # EF Core migration history
    │   ├── 20250306103500_FirstMigration.cs          # Initial schema (Cliente, Produto)
    │   ├── 20250306134240_CreatingTotal.cs           # Added Quantidade, Valor, CriadoEm to Produto
    │   └── LojaDbContextModelSnapshot.cs             # Current model snapshot
    │
    ├── Properties/
    │   └── launchSettings.json     # IIS Express + Kestrel profiles for debugging
    │
    └── wwwroot/                    # Static files (served directly)
        ├── css/site.css            # CSS variables for theming
        ├── js/site.js              # DataTables initialization (PT-BR locale)
        └── lib/                    # Vendor libraries (Bootstrap, jQuery, etc.)
```

### Request Lifecycle

```
1. HTTP Request → Kestrel Server
       ↓
2. Middleware Pipeline
   - UseExceptionHandler (production error handling)
   - UseHsts, UseHttpsRedirection (security)
   - UseStaticFiles (wwwroot assets)
   - UseRouting + UseAuthorization
       ↓
3. MVC Routing → Controller Action
   - Pattern: {controller=Home}/{action=Index}/{id?}
       ↓
4. Controller → Entity Framework Core
   - Async queries with ToListAsync(), FindAsync()
   - Change tracking: Add(), Update(), Remove()
   - SaveChangesAsync() persists to SQL Server
       ↓
5. Razor View Rendering
   - Model passed to .cshtml
   - HTML generated with Tag Helpers (asp-action, asp-for)
       ↓
6. HTTP Response → Browser
```

### Data Flow Diagram

```
User Action (Browser)
       ↓
HTTP POST/GET → ASP.NET Core Middleware
       ↓
Controller Action (e.g., ProdutoController.Create)
       ↓
[Model Binding] → [ModelState Validation]
       ↓
EF Core DbContext (LojaDbContext)
       ↓
SQL Server Database (via ADO.NET)
       ↓
Entity Saved → RedirectToAction("Index")
       ↓
Razor View Rendered → HTML Response → Browser
```

### Key Components

#### Entity Models

**Cliente.cs**
```csharp
public class Cliente {
    public int IdCliente { get; set; }           // PK, identity
    public string? Nome { get; set; }            // varchar(100)
    public string? Telefone { get; set; }        // varchar(25)
    public virtual ICollection<Produto> Produtos { get; set; } // Navigation
}
```

**Produto.cs**
```csharp
public class Produto {
    public int IdProduto { get; set; }           // PK, identity
    public string? Nome { get; set; }            // varchar(100)
    public int? IdCliente { get; set; }          // FK to Cliente
    public int? Quantidade { get; set; }         // Nullable int
    public decimal? Valor { get; set; }          // decimal(18,2)
    
    // Computed property (not mapped to DB)
    public decimal? Total => Quantidade * Valor; 
    
    public DateTime? CriadoEm { get; set; }      // Timestamp
    public virtual Cliente? IdClienteNavigation { get; set; } // Navigation
}
```

#### Database Schema (Current)

```sql
-- Table: Cliente
CREATE TABLE Cliente (
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NULL,
    telefone VARCHAR(25) NULL
);

-- Table: Produto
CREATE TABLE Produto (
    idProduto INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100) NULL,
    idCliente INT NULL FOREIGN KEY REFERENCES Cliente(idCliente),
    Quantidade INT NULL,
    Valor DECIMAL(18,2) NULL,
    CriadoEm DATETIME2 NULL,
    INDEX IX_Produto_idCliente (idCliente)
);
```

#### EF Core Configuration Highlights

```csharp
// LojaDbContext.cs - Fluent API
modelBuilder.Entity<Cliente>(entity => {
    entity.ToTable("Cliente");
    entity.Property(e => e.Nome).HasMaxLength(100).IsUnicode(false);
    // ...
});

modelBuilder.Entity<Produto>(entity => {
    entity.HasOne(d => d.IdClienteNavigation)
          .WithMany(p => p.Produtos)
          .HasForeignKey(d => d.IdCliente)
          .HasConstraintName("FK__Produto__idClien__38996AB5");
});
```

---

## 🔐 Environment Variables

### Configuration via appsettings.json

The application reads configuration from `appsettings.json` and environment-specific files (`appsettings.Development.json`).

| Key | Type | Description | Default |
|-----|------|-------------|---------|
| `ConnectionStrings:Default` | string | SQL Server connection string | `Server=PC03LAB2814\SENAI;...` |
| `Logging:LogLevel:Default` | string | Global log level | `Information` |
| `Logging:LogLevel:Microsoft.AspNetCore` | string | Framework log level | `Warning` |
| `AllowedHosts` | string | Allowed host headers | `*` |

### Securing Sensitive Data

**❌ Never commit production credentials to Git.** Use one of these approaches:

#### Option 1: User Secrets (Development)
```bash
# Navigate to project directory
cd LojaCrud

# Initialize user secrets
dotnet user-secrets init

# Set connection string
dotnet user-secrets set "ConnectionStrings:Default" "Server=...;Database=...;..."

# Run app (secrets automatically loaded in Development)
dotnet run
```

#### Option 2: Environment Variables (Production)
```bash
# Linux/macOS
export ConnectionStrings__Default="Server=...;Database=...;..."

# Windows CMD
set ConnectionStrings__Default=Server=...;Database=...;...

# Then run
dotnet run
```

#### Option 3: Azure Key Vault / AWS Secrets Manager (Enterprise)
Configure `Program.cs` to load secrets from cloud provider (not implemented in this project).

### Rails-like Credentials Alternative

For sensitive config without environment variables, consider adding:
```csharp
// Program.cs extension
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true);
// Then add appsettings.Local.json to .gitignore
```

---

## ⚙️ Available Scripts

| Command | Description | Use Case |
|---------|-------------|----------|
| `dotnet restore` | Restore NuGet packages | After cloning or adding packages |
| `dotnet build` | Compile project | Pre-deployment verification |
| `dotnet run` | Build + run with Kestrel | Local development |
| `dotnet watch run` | Run with auto-reload on file changes | Active development |
| `dotnet ef migrations add <Name>` | Create new EF migration | After model changes |
| `dotnet ef database update` | Apply pending migrations | Setup or deployment |
| `dotnet ef migrations remove` | Remove last migration | Undo accidental migration |
| `dotnet ef dbcontext scaffold` | Reverse-engineer DB to models | Legacy database integration |
| `dotnet publish -c Release` | Publish self-contained or framework-dependent | Production deployment |
| `dotnet test` | Run unit tests (if added) | CI/CD pipeline |

### EF Core Migration Workflow

```bash
# 1. Modify a model (e.g., add property to Produto.cs)

# 2. Create migration
dotnet ef migrations add AddDescricaoToProduto -o Migrations

# 3. Review the generated migration file
#    - Up(): schema changes to apply
#    - Down(): rollback changes

# 4. Apply to database
dotnet ef database update

# 5. Verify in SQL Server Management Studio or Azure Data Studio
```

### Visual Studio Integration

If using Visual Studio 2022:
- **Package Manager Console**: `Add-Migration`, `Update-Database`
- **Run/Debug**: F5 launches with IIS Express profile
- **Migrations**: Tools → NuGet Package Manager → Package Manager Console

---

## 🧪 Testing

### Manual Testing Checklist

```markdown
## Database
- [ ] Connection string valid and database accessible
- [ ] Migrations applied successfully (check __EFMigrationsHistory table)
- [ ] Seed data (if any) loaded correctly

## Cliente CRUD
- [ ] Index: Lists all clients, DataTables search works
- [ ] Create: Form validates required fields, saves to DB
- [ ] Edit: Pre-fills form, updates record on submit
- [ ] Delete: Confirmation prompt, removes record
- [ ] Details: Shows read-only client info

## Produto CRUD
- [ ] Index: Shows products with client name, calculated Total
- [ ] Create: Dropdown lists existing clients, Total calculated client-side
- [ ] Edit: Preserves client selection, updates all fields
- [ ] Delete: Handles foreign key constraints gracefully

## UI/UX
- [ ] Responsive layout on mobile (≤768px)
- [ ] DataTables PT-BR localization active
- [ ] Bootstrap validation styles on invalid inputs
- [ ] Navigation highlights active section
```

### API Testing (Optional)

While this is an MVC app (not API-first), you can test endpoints with curl:

```bash
# Get all clients (HTML response)
curl -I https://localhost:7279/Cliente

# Create client (form submission simulation)
curl -X POST https://localhost:7279/Cliente/Create \
  -H "Content-Type: application/x-www-form-urlencoded" \
  -d "Nome=Teste&Telefone=11999999999" \
  --cookie-jar cookies.txt
```

### Adding Automated Tests (Future Enhancement)

To add xUnit tests:

```bash
# Install test packages
dotnet add LojaCrud package Microsoft.NET.Test.Sdk
dotnet add LojaCrud package xunit
dotnet add LojaCrud package xunit.runner.visualstudio
dotnet add LojaCrud package Moq

# Create test project
dotnet new xunit -n LojaCrud.Tests
dotnet add LojaCrud.Tests reference LojaCrud/LojaCrud.csproj
```

Example test (`LojaCrud.Tests/ProdutoTests.cs`):
```csharp
public class ProdutoTests {
    [Fact]
    public void Total_CalculatedCorrectly() {
        var produto = new Produto { Quantidade = 3, Valor = 10.50m };
        Assert.Equal(31.50m, produto.Total);
    }
}
```

---

## 🌍 Deployment

### Option 1: IIS (Windows Server)

```powershell
# 1. Publish the application
dotnet publish LojaCrud/LojaCrud.csproj -c Release -o ./publish

# 2. Copy contents of ./publish to IIS wwwroot folder
#    e.g., C:\inetpub\wwwroot\LojaCrud

# 3. In IIS Manager:
#    - Create new Application Pool (.NET CLR: No Managed Code)
#    - Create new Site pointing to wwwroot\LojaCrud
#    - Set Application Pool to the one created above

# 4. Configure web.config (auto-generated by publish) for production:
#    - Set ASPNETCORE_ENVIRONMENT=Production
#    - Configure connection string via appsettings.Production.json or env vars
```

### Option 2: Azure App Service

```bash
# 1. Create resource group and App Service Plan
az group create --name loja-rg --location eastus
az appservice plan create --name loja-plan --resource-group loja-rg --sku B1 --is-linux

# 2. Create Web App
az webapp create --name loja-yourname --plan loja-plan --resource-group loja-rg --runtime "DOTNET|6.0"

# 3. Configure connection string (via Azure Portal or CLI)
az webapp config connection-string set \
  --name loja-yourname \
  --resource-group loja-rg \
  --settings Default="Server=...;Database=...;..." --connection-string-type SQLAzure

# 4. Deploy via ZIP
dotnet publish LojaCrud/LojaCrud.csproj -c Release -o ./publish
cd publish && zip -r ../deploy.zip .
az webapp deployment source config-zip \
  --name loja-yourname \
  --resource-group loja-rg \
  --src ../deploy.zip
```

### Option 3: Docker (Generic Container Deployment)

Since no `Dockerfile` exists, create one:

```dockerfile
# LojaCrud/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LojaCrud/LojaCrud.csproj", "LojaCrud/"]
RUN dotnet restore "LojaCrud/LojaCrud.csproj"
COPY . .
WORKDIR "/src/LojaCrud"
RUN dotnet build "LojaCrud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaCrud.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaCrud.dll"]
```

**Build and Run:**
```bash
# Build image
docker build -t lojacrud -f LojaCrud/Dockerfile .

# Run with environment variable for connection string
docker run -d \
  -p 8080:80 \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e ConnectionStrings__Default="Server=host.docker.internal;Database=LojaDb;..." \
  --name lojacrud-app \
  lojacrud
```

> 💡 **Note**: `host.docker.internal` resolves to host machine from Docker container (macOS/Windows). For Linux, use `172.17.0.1` or a network alias.

### Option 4: Linux with systemd (Self-Hosted)

```bash
# 1. Publish framework-dependent
dotnet publish LojaCrud/LojaCrud.csproj -c Release -o /var/www/lojacrud

# 2. Create systemd service (/etc/systemd/system/lojacrud.service)
[Unit]
Description=LojaCrud ASP.NET Core Web App
After=network.target

[Service]
WorkingDirectory=/var/www/lojacrud
ExecStart=/usr/bin/dotnet /var/www/lojacrud/LojaCrud.dll
Restart=always
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=ConnectionStrings__Default=Server=...;Database=...;...
User=www-data
SyslogIdentifier=lojacrud

[Install]
WantedBy=multi-user.target

# 3. Enable and start
sudo systemctl daemon-reload
sudo systemctl enable lojacrud
sudo systemctl start lojacrud

# 4. Configure reverse proxy (nginx example)
# /etc/nginx/sites-available/lojacrud
server {
    listen 80;
    server_name loja.seudominio.com;
    location / {
        proxy_pass http://localhost:5000;
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
    }
}
```

---

## 🔧 Troubleshooting

### ❌ "A network-related or instance-specific error occurred while establishing a connection to SQL Server"

**Cause**: Connection string invalid, SQL Server not running, or firewall blocking.

**Solution**:
```bash
# 1. Verify SQL Server is running
# Windows: services.msc → SQL Server (MSSQLSERVER)
# Linux: sudo systemctl status mssql-server

# 2. Test connection with sqlcmd
sqlcmd -S YOUR_SERVER -U YOUR_USER -P YOUR_PASSWORD -Q "SELECT 1"

# 3. Check TrustServerCertificate for self-signed certs
# Add to connection string: TrustServerCertificate=True

# 4. Ensure TCP/IP protocol enabled in SQL Server Configuration Manager
```

### ❌ "The connection string 'Default' was not found"

**Cause**: Configuration not loaded correctly.

**Solution**:
```csharp
// Verify in Program.cs that configuration is built before UseDbContext:
var builder = WebApplication.CreateBuilder(args);
// This line is critical:
builder.Services.AddDbContext<LojaDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
```

### ❌ EF Core migration fails: "Invalid object name '__EFMigrationsHistory'"

**Cause**: Database exists but migrations table missing (manual DB creation).

**Solution**:
```bash
# Option A: Let EF create the schema
dotnet ef database update

# Option B: If you created tables manually, insert migration history:
INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) 
VALUES ('20250306134240_CreatingTotal', '6.0.36');
```

### ❌ "The model backing the context has changed since the database was created"

**Cause**: Code-first model modified without applying migration.

**Solution**:
```bash
# Create and apply migration
dotnet ef migrations add FixModelChanges
dotnet ef database update
```

### ❌ DataTables not loading or PT-BR locale missing

**Cause**: CDN blocked or network issue.

**Solution**:
```html
<!-- In _Layout.cshtml, ensure these are present: -->
<link href="https://cdn.datatables.net/v/bs5/dt-2.2.2/datatables.min.css" rel="stylesheet">
<script src="https://cdn.datatables.net/v/bs5/dt-2.2.2/datatables.min.js"></script>

<!-- And in site.js: -->
var table = new DataTable('.table', {
    language: { url: '//cdn.datatables.net/plug-ins/2.2.2/i18n/pt-BR.json' }
});
```

### ❌ jQuery Validation not triggering

**Cause**: Missing unobtrusive validation scripts or form attributes.

**Solution**:
```html
<!-- Ensure _ValidationScriptsPartial.cshtml is rendered: -->
@section Scripts {
    @{ await Html.RenderPartialAsync("_ValidationScriptsPartial"); }
}

<!-- And that form has asp- attributes: -->
<form asp-action="Create" method="post">
    <input asp-for="Nome" />
    <span asp-validation-for="Nome"></span>
</form>
```

### ❌ Application crashes on startup: "Unable to resolve service for type 'ILogger<HomeController>'"

**Cause**: Dependency injection misconfiguration.

**Solution**:
```csharp
// Ensure Program.cs has:
builder.Services.AddControllersWithViews();
// This registers ILogger<T> automatically. Do not remove.
```

### ❌ HTTPS certificate warnings in development

**Cause**: Self-signed dev certificate not trusted.

**Solution** (Windows):
```powershell
dotnet dev-certs https --trust
```

**Solution** (macOS/Linux):
```bash
# Trust the certificate manually or use HTTP for local dev:
dotnet run --urls "http://localhost:5000"
```

---

## 🤝 Contributing

Contributions are welcome! This project is licensed under [GNU GPL v3](LICENSE).

### Development Workflow

```bash
# 1. Fork and clone
git clone https://github.com/YOUR_USERNAME/tyxiel-lojacrud.git
cd tyxiel-lojacrud

# 2. Create feature branch
git checkout -b feat/add-search-to-products

# 3. Make changes + test locally
dotnet watch run

# 4. Commit with conventional messages
git commit -m "feat(produto): add search by name in Index"

# 5. Push and open PR
git push origin feat/add-search-to-products
```

### Contribution Guidelines

- ✅ Follow existing code style (nullable reference types enabled)
- ✅ Add `[ValidateAntiForgeryToken]` to all POST actions
- ✅ Use async/await for all database operations
- ✅ Validate both server-side (DataAnnotations) and client-side (jQuery Validation)
- ✅ Test CRUD operations manually before submitting
- ✅ Update migrations if changing models
- ✅ Keep PRs focused (one feature/fix per PR)

### Suggested Improvements

```markdown
🔧 Technical Debt
- [ ] Move connection string to User Secrets / environment variables by default
- [ ] Add integration tests with WebApplicationFactory
- [ ] Implement pagination server-side (currently DataTables handles client-side)
- [ ] Add authorization (e.g., [Authorize] for admin actions)

✨ Feature Ideas
- [ ] Export clients/products to CSV
- [ ] Dashboard with charts (total clients, revenue)
- [ ] Soft delete instead of hard delete
- [ ] Audit log for changes (who changed what and when)
```

### Reporting Issues

Use [GitHub Issues](https://github.com/tyxiel/tyxiel-lojacrud/issues) with:

- 🐛 **Bug Report**: Steps to reproduce, expected vs actual, environment (.NET version, OS, SQL Server version)
- 💡 **Feature Request**: Use case, proposed solution, priority
- ❓ **Question**: Clear description of what you're trying to achieve

---

## 📜 License

Distributed under the **GNU General Public License v3.0**. See [`LICENSE`](LICENSE) for full text.

### What This Means

| You Can | You Must |
|---------|----------|
| ✅ Use commercially | 🔓 Disclose source if you distribute modified versions |
| ✅ Modify and redistribute | 📝 Include license and copyright notices |
| ✅ Patent use | 🔄 Share modifications under GPL v3 |
| ✅ Private use | 🔗 Provide source to recipients of binaries |

### Quick Compliance Checklist

```bash
# When distributing modified versions:
# 1. Keep LICENSE file intact
# 2. Add copyright header to new files:
// Copyright (C) 2025 Your Name
// SPDX-License-Identifier: GPL-3.0-or-later

# 3. If providing binaries, also provide source code or written offer:
#    "Source code available at: https://your-repo/tyxiel-lojacrud"

# 4. Document changes in a CHANGELOG.md or commit history
```

> ℹ️ **GPL Specific**: If you run a modified version on a server and let users interact with it over a network, you are **not** required to share source (unlike AGPL). However, if you *distribute* the software (e.g., as a downloadable package), you must provide source.

---

## 🙏 Acknowledgments

- [Microsoft Learn](https://learn.microsoft.com/dotnet/) — For .NET documentation and tutorials
- [Entity Framework Core Docs](https://docs.microsoft.com/ef/core/) — For ORM guidance
- [Bootstrap 5](https://getbootstrap.com/) — For responsive UI components
- [DataTables](https://datatables.net/) — For advanced table functionality
- [freeCodeCamp](https://www.freecodecamp.org/) — For foundational web development education

---

> 💡 **Pro Tip**: When adding new model properties, always: (1) update the C# class, (2) create a migration (`dotnet ef migrations add`), (3) update the database (`dotnet ef database update`), and (4) update the Razor views to display/edit the new field.

*Built with ❤️ by [Tyxiel](https://github.com/tyxiel)*
