
# 🧰 Third-Party Integration Structure Guide

This guide walks you through a modular and reusable approach to scaffold third-party integrations (e.g., Stripe, QuickBooks) using a set of four structured prompts. These prompts are designed to be used in order, ensuring the solution is well-architected, testable, and maintainable across any .NET application.

---

## 📋 Overview of Prompts

| Step | File Name                  | Purpose                                                                 |
|------|----------------------------|-------------------------------------------------------------------------|
| 1️⃣   | `01.initial-setup.md`      | Collect initial inputs and scaffold folder structure based on project type |
| 2️⃣   | `02.third-party-service-setup.md` | Scaffold service files, DTOs, and config structure                        |
| 3️⃣   | `03.setup-common.md`      | Generate shared Models, Helpers, and Documentation                       |
| 4️⃣   | `04.setup-tests.md`       | Scaffold a full unit test project with mocking and test templates         |

---

## 🔰 Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (v6, v7, v8 or later)
- Basic understanding of third-party integration requirements
- Visual Studio / Rider / VS Code (IDE optional)

---

## 🧾 Step-by-Step Execution

### ✅ Step 1: Initial Setup

📄 File: `01.initial-setup.md`

**Purpose:**  
Scaffold base folder structure and set up class library or standalone project for the `{ServiceName}`.

**Required Inputs:**
- Service Name (e.g., `Stripe`)
- .NET Version (e.g., `8.0`)
- Authentication Type (None | JWT | OAuth2)
- Integration Type:
  - Class Library for Host Project
  - Standalone Web API
  - Standalone MVC

**What This Does:**
- Creates solution + project based on user choice
- Adds NuGet packages
- Creates this structure:

```
/{ServiceName}Service
  ├── Services/{ServiceName}
  ├── Common/Helpers
  ├── Common/Configuration
  ├── Models
  └── Services/{ServiceName}/Docs
```

**Notes:**
- Class Library integrations prompt for host `.csproj` and `.sln`
- Standalone integrations create their own solution and controller scaffolding
- README is initiated in `/Docs`

---

### ✅ Step 2: Service Setup

📄 File: `02.third-party-service-setup.md`

**Purpose:**  
Scaffold service logic (interfaces, implementations, DTOs) and setup DI registration.

**Required Inputs:**
- `{ServiceName}`
- `{ProjectType}`: WebAPI | MVC | Class Library
- `{AuthenticationType}`: None | JWT | OAuth2
- `{IsStandalone}`: true / false
- `{AppType}`: WebAPI or MVC (if standalone)
- `{HostProjectPath}`: (Only for Class Library integration)

**What This Does:**
- Creates:
  - `/DTO/Requests/`, `/DTO/Responses/`
  - `I{ServiceName}Service.cs` and `{ServiceName}Service.cs`
  - `/Extensions/ServiceCollectionExtensions.cs`
- Registers services using `IServiceCollection`
- Adds `/Common/Helpers/TokenProvider.cs` if auth is enabled
- Binds config from `appsettings.json` via `IOptions<{ServiceName}Options>`

**Sample Config Registration:**

```csharp
builder.Services.Configure<StripeOptions>(
    builder.Configuration.GetSection("StripeSettings"));
```

---

### ✅ Step 3: Setup Common Models & Helpers

📄 File: `03.setup-common.md`

**Purpose:**  
Scaffold reusable Models and Helpers with SOLID principles.

**Required Input:**
- `{ServiceName}`

**What This Does:**
- Generates under:
  - `/Models/{ServiceName}/`
  - `/Services/{ServiceName}/Common/Helpers/`
- Model Examples:
  - `TokenMetadata.cs`
  - `EmailModel.cs`
  - `StatusCodes.cs`
- Helper Examples:
  - `TokenHelper.cs`
  - `ValidationHelper.cs`

**Documentation Updated In:**
```
/Docs/README.md
```

Includes:
- Usage examples
- Model descriptions
- Helper usage guidelines

---

### ✅ Step 4: Setup Test Project

📄 File: `04.setup-tests.md`

**Purpose:**  
Create a full-featured unit test project with mocks and assertion fluency.

**Required Inputs:**
- Test Framework: `xUnit`, `NUnit`, or `MSTest`

**What This Does:**
- Detects if test project already exists
- Creates new test project if needed:
  - Name: `{ServiceName}Service.Tests`
  - Structure:
    ```
    /Tests
      ├── /Services/{ServiceName}
      ├── /Controllers  (if IsStandalone == true)
      └── /Common
    ```

**Each Service File Generates a Matching Test File:**
- `{ServiceName}ServiceTests.cs`
- Follows `AAA` pattern (Arrange → Act → Assert)
- Uses:
  - `Mock<IService>()`
  - `FluentAssertions`
  - Test method naming: `MethodName_ShouldDoSomething()`

**README Updated With:**
- Test framework
- NuGet packages used
- Test execution: `dotnet test`
- Coverage (optional): Coverlet / ReportGenerator

---

## 🧾 Final Checklist

| ✅ Task                                     | Status       |
|-------------------------------------------|--------------|
| Modular folder structure created           | ✅            |
| Service classes and interfaces scaffolded  | ✅            |
| DTOs and Configuration bound               | ✅            |
| Common models and helpers generated        | ✅            |
| Test project and stubs generated           | ✅            |
| Documentation (README.md) updated          | ✅            |

---

## 🧠 Reusability Notes

- All templates use `{ServiceName}` placeholder → fully dynamic
- Structure and naming follow .NET conventions
- Easily plug into host or run standalone
- Supports evolving needs with minimal changes
- Suitable for CI/CD pipelines and deployment automation

---

## 🏁 Running Everything

```bash
# Navigate to root
cd {YourRootFolder}

# Restore and build solution
dotnet restore
dotnet build

# Run (if standalone)
dotnet run --project {ServiceName}IntegrationApi

# Run tests
dotnet test {ServiceName}Service.Tests
```

---

> 📌 You can repeat this workflow for any new third-party integration—just change the `{ServiceName}` and reapply the prompts.
