
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

