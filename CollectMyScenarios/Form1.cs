using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;

namespace CollectMyScenarios
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 1;
        private const uint MOD_CONTROL = 0x0002;
        private const uint VK_M = 0x4D;
        private const int WM_HOTKEY = 0x0312;

        private string _saveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private NotifyIcon _trayIcon;
        private string[] _scenarios = Array.Empty<string>();
        private int _currentScenario = 0;
        private int _currentFileNumber = 1;

        private uint _currentModifier = MOD_CONTROL;
        private uint _currentKey = VK_M;
        private string _scenarioSaveDir = DateTime.Now.ToString("yyyyMMddHHmmss");

        public Form1()
        {
            InitializeComponent();
            InitializeTrayIcon();

            // Keep this window always on top
            this.TopMost = false;

            LoadHotkeyConfig();

            if (!RegisterHotKey(this.Handle, HOTKEY_ID, _currentModifier, _currentKey))
            {
                MessageBox.Show("Failed to register configured hotkey. It may be in use by another app.",
                                "Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            textFolderPath.Text = _saveDirectory;
            InitializeScenarios(_saveDirectory);
        }

        private uint ParseModifier(string modifier)
        {
            return modifier?.ToUpper() switch
            {
                "ALT" => 0x0001,
                "CONTROL" or "CTRL" => 0x0002,
                "SHIFT" => 0x0004,
                "WIN" or "WINDOWS" => 0x0008,
                _ => MOD_CONTROL // Default fallback
            };
        }

        private uint ParseKey(string key)
        {
            if (Enum.TryParse<Keys>(key, true, out Keys parsedKey))
            {
                return (uint)parsedKey;
            }
            return VK_M; // Default fallback
        }

        private void LoadHotkeyConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotkey.json");

            if (File.Exists(configPath))
            {
                try
                {
                    string json = File.ReadAllText(configPath);
                    var config = System.Text.Json.JsonSerializer.Deserialize<HotkeyConfig>(json);

                    if (config != null)
                    {
                        _currentModifier = ParseModifier(config.Modifier);
                        _currentKey = ParseKey(config.Key);
                    }
                }
                catch
                {
                    _currentModifier = MOD_CONTROL;
                    _currentKey = VK_M;
                }
            }
        }

        private string SanitizeFileName(string input)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(c, '_');
            }
            return input;
        }

        private void populateScenarioLabels(string[] scenarios)
        {
            previousScenarioLabel.Text = "";
            currentScenarioLabel.Text = scenarios.Length > 0 ? scenarios[0] : "";
            nextScenarioLabel.Text = scenarios.Length > 1 ? scenarios[1] : "";
            currentScenarioNumberLabel.Text = scenarios.Length > 0 ? 1.ToString("D4") : 0.ToString("D4");
        }

        private void updateScenarioLabels()
        {
            // Previous scenario
            previousScenarioLabel.Text = (_currentScenario - 1 >= 0 && _currentScenario - 1 < _scenarios.Length)
                ? _scenarios[_currentScenario - 1]
                : "";

            // Current scenario
            currentScenarioLabel.Text = (_currentScenario < _scenarios.Length)
                ? _scenarios[_currentScenario]
                : "";

            // Next scenario
            nextScenarioLabel.Text = (_currentScenario + 1 < _scenarios.Length)
                ? _scenarios[_currentScenario + 1]
                : "";

            // Scenario Number padded with 4 zeros (1-based index)
            currentScenarioNumberLabel.Text = (_currentScenario < _scenarios.Length)
                ? (_currentScenario + 1).ToString("D4")
                : 0.ToString("D4");
        }

        private void InitializeScenarios(String saveDirectory)
        {
            string filePath = Path.Combine(saveDirectory, "scenarios.txt");

            if (File.Exists(filePath))
            {
                _scenarios = File.ReadLines(filePath)
                 .Select(line => line.Trim())
                 .Where(line => !string.IsNullOrWhiteSpace(line))
                 .Take(50)
                 .ToArray();

                _currentFileNumber = 1;
                _currentScenario = 0;
                _scenarioSaveDir = DateTime.Now.ToString("yyyyMMddHHmmss");
                populateScenarioLabels(_scenarios);
            }
            else
            {
                _scenarios = Array.Empty<string>();
                _currentFileNumber = 1;
                _currentScenario = 0;
                populateScenarioLabels(_scenarios);
            }
        }

        private void InitializeTrayIcon()
        {
            _trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                BalloonTipTitle = "Screenshot Captured"
            };

            _trayIcon.BalloonTipClicked += (sender, e) =>
            {
                string activeDir = Path.Combine(_saveDirectory, _scenarioSaveDir);
                if (Directory.Exists(activeDir))
                {
                    System.Diagnostics.Process.Start("explorer.exe", activeDir);
                }
            };
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                CaptureScreen();
            }
        }

        private void CaptureScreen()
        {
            string activeSaveDir = Path.Combine(_saveDirectory, _scenarioSaveDir);
            if (!Directory.Exists(activeSaveDir))
            {
                Directory.CreateDirectory(activeSaveDir);
            }

            Rectangle bounds = Screen.FromPoint(Cursor.Position).Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
                }

                string filename = $"{getCurrentFileNameForScreenshot()}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(activeSaveDir, filename);

                bitmap.Save(fullPath, ImageFormat.Png);

                if (checkBoxDisableNotifications.Checked == false)
                {
                    _trayIcon.BalloonTipText = $"Saved to: {_scenarioSaveDir}\\{filename}";
                    _trayIcon.ShowBalloonTip(2000);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);

            if (_trayIcon != null)
            {
                _trayIcon.Visible = false;
                _trayIcon.Dispose();
            }

            base.OnFormClosing(e);
        }

        private string getCurrentFileNameForScreenshot()
        {
            string fileName = $"{_currentFileNumber:D3}";
            _currentFileNumber++;
            if (_scenarios.Length > _currentScenario)
            {
                fileName = fileName + "_" + _scenarios[_currentScenario];
                fileName = SanitizeFileName(fileName);
                _currentScenario++;
                updateScenarioLabels();
            }
            return fileName;
        }

        private void chooseOutputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the base folder to save screenshots";
                folderDialog.InitialDirectory = _saveDirectory;

                if (folderDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    _saveDirectory = folderDialog.SelectedPath;
                    InitializeScenarios(_saveDirectory);
                    textFolderPath.Text = _saveDirectory;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBoxOnTop.Checked;
        }

        private void ResetScenarios()
        {
            InitializeScenarios(_saveDirectory);
            updateScenarioLabels();
        }

        private void buttonResetScenario_Click(object sender, EventArgs e)
        {
            ResetScenarios();
        }
    }
}