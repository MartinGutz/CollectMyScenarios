# CollectMyScenarios

`CollectMyScenarios` is a lightweight Windows Forms application designed to streamline the process of taking and organizing screenshots for step-by-step testing scenarios, documentation, and quality assurance workflows.

---

## How the Application Works

1. **Scenario-Driven Flow**: The app reads a plain-text file (`scenarios.txt`) from your selected working directory, loading up to 50 test steps to guide your session.
2. **Global Hotkey Integration**: Using a registered Windows system hotkey (`Ctrl + M` by default), you can capture full-screen screenshots across your monitors without needing to bring the app window into focus.
3. **Structured File Naming**: Captured files are automatically prefixed with a sequential index (`001`, `002`, etc.) and the active scenario description, followed by an exact timestamp (`yyyyMMdd_HHmmss`).
4. **Session Subfolders**: Every time scenarios are initialized or reset, the app generates a unique, timestamped subfolder (`YYYYMMddHHmmss`) inside your base directory, keeping test runs neatly separated.
5. **System Tray Support**: Provides non-intrusive notifications upon capture and lets you open the active save folder directly by clicking the notification balloon.

---

## How to Use It

### 1. Preparing Your Scenarios File
Create a text file named **`scenarios.txt`** and place it in your target output directory. Each line represents an individual test step:

```
Verify login page load and TLS certificate
Enter administrator credentials and submit
Open dashboard settings and toggle dark mode
```

### 2. Customizing Hotkeys (Optional)
You can define custom global hotkeys by placing a hotkey.json file next to your executable:

```
JSON
{
  "Modifier": "Ctrl",
  "Key": "M"
}
```
(Supported modifiers: Ctrl, Alt, Shift, Win).

### 3. Capturing Scenarios
Launch CollectMyScenarios.

1 Confirm or change your output path using the folder picker (defaults to your Pictures folder).
1 Perform your test action on screen and press your hotkey (Ctrl + M).
1 The application captures the screen, saves the image into the session folder, and automatically advances the UI to the next scenario.

### 4. Resetting Your Session

Click the Reset Scenario button in the interface at any time to reload scenarios.txt, reset your counter to 001, and create a fresh timestamped folder for a new run!