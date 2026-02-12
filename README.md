

# 📄 README.md

````markdown
# 🚀 Automation Framework – Selenium + Playwright (.NET 8)

This repository contains an end-to-end automation framework built using:

- ✅ Selenium WebDriver (.NET 8)
- ✅ Playwright (.NET)
- ✅ Reqnroll (BDD)
- ✅ NUnit
- ✅ Extent Reports
- ✅ Page Object Model (POM)
- ✅ Shared Automation.Common library

The framework validates complete E2E purchase flow on:
https://automationexercise.com

---

# 📂 Project Structure

AutomationFramework  
│  
├── Automation.Common        → Shared models & services  
├── TestProject1             → Playwright automation  
├── TestProject2             → Selenium automation  
└── AutomationFramework.sln  

---

# ⚙️ Prerequisites

Make sure you have installed:

- .NET 8 SDK  
- Visual Studio 2022  
- Git  
- Chrome Browser  

---

# 📦 Install Dependencies

After cloning the project, restore packages:

```bash
dotnet restore
````

---

# ▶️ How to Run Selenium Tests (TestProject2)

### Option 1 – From Visual Studio

1. Open `AutomationFramework.sln`
2. Set `TestProject2` as Startup Project
3. Open Test Explorer
4. Click **Run All**

---


# ▶️ How to Run Playwright Tests (TestProject1)

### First time setup (VERY IMPORTANT)

Install Playwright browsers:

```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

Or:

```bash
dotnet playwright install
```

---

### Run tests

```bash
dotnet test TestProject1
```

---

# 📊 Extent Reports

After execution, reports are generated inside:

```
TestResults/ExtentReport.html
```

Open the file in browser to view:

* Step-wise logs
* Screenshots after every step
* Pass/Fail status

---

