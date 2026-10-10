namespace CollectMyScenarios
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputFolderDialog = new FolderBrowserDialog();
            textBox1 = new TextBox();
            textFolderPath = new TextBox();
            chooseOutputFolder = new Button();
            previousScenarioLabel = new Label();
            currentScenarioLabel = new Label();
            nextScenarioLabel = new Label();
            checkBoxDisableNotifications = new CheckBox();
            panel1 = new Panel();
            label1 = new Label();
            checkBoxOnTop = new CheckBox();
            buttonResetScenario = new Button();
            currentScenarioNumberLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // textFolderPath
            // 
            textFolderPath.Location = new Point(157, 22);
            textFolderPath.Name = "textFolderPath";
            textFolderPath.Size = new Size(540, 23);
            textFolderPath.TabIndex = 0;
            // 
            // chooseOutputFolder
            // 
            chooseOutputFolder.Location = new Point(12, 21);
            chooseOutputFolder.Name = "chooseOutputFolder";
            chooseOutputFolder.Size = new Size(132, 23);
            chooseOutputFolder.TabIndex = 1;
            chooseOutputFolder.Text = "Choose Scenario";
            chooseOutputFolder.UseVisualStyleBackColor = true;
            chooseOutputFolder.Click += chooseOutputFolder_Click;
            // 
            // previousScenarioLabel
            // 
            previousScenarioLabel.AutoSize = true;
            previousScenarioLabel.Location = new Point(225, 64);
            previousScenarioLabel.Name = "previousScenarioLabel";
            previousScenarioLabel.Size = new Size(0, 15);
            previousScenarioLabel.TabIndex = 2;
            // 
            // currentScenarioLabel
            // 
            currentScenarioLabel.AutoSize = true;
            currentScenarioLabel.Location = new Point(21, 14);
            currentScenarioLabel.Name = "currentScenarioLabel";
            currentScenarioLabel.Size = new Size(0, 15);
            currentScenarioLabel.TabIndex = 3;
            // 
            // nextScenarioLabel
            // 
            nextScenarioLabel.AutoSize = true;
            nextScenarioLabel.Location = new Point(225, 152);
            nextScenarioLabel.Name = "nextScenarioLabel";
            nextScenarioLabel.Size = new Size(0, 15);
            nextScenarioLabel.TabIndex = 4;
            // 
            // checkBoxDisableNotifications
            // 
            checkBoxDisableNotifications.AutoSize = true;
            checkBoxDisableNotifications.Location = new Point(717, 26);
            checkBoxDisableNotifications.Name = "checkBoxDisableNotifications";
            checkBoxDisableNotifications.Size = new Size(135, 19);
            checkBoxDisableNotifications.TabIndex = 5;
            checkBoxDisableNotifications.Text = "Disable Notifications";
            checkBoxDisableNotifications.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(currentScenarioLabel);
            panel1.Location = new Point(204, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 42);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(26, 107);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 7;
            label1.Text = "Current Scenario";
            // 
            // checkBoxOnTop
            // 
            checkBoxOnTop.AutoSize = true;
            checkBoxOnTop.Location = new Point(716, 48);
            checkBoxOnTop.Name = "checkBoxOnTop";
            checkBoxOnTop.Size = new Size(104, 19);
            checkBoxOnTop.TabIndex = 8;
            checkBoxOnTop.Text = "Always On Top";
            checkBoxOnTop.UseVisualStyleBackColor = true;
            checkBoxOnTop.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // buttonResetScenario
            // 
            buttonResetScenario.Location = new Point(716, 71);
            buttonResetScenario.Name = "buttonResetScenario";
            buttonResetScenario.Size = new Size(159, 23);
            buttonResetScenario.TabIndex = 9;
            buttonResetScenario.Text = "Reset Scenario";
            buttonResetScenario.UseVisualStyleBackColor = true;
            buttonResetScenario.Click += buttonResetScenario_Click;
            // 
            // currentScenarioNumberLabel
            // 
            currentScenarioNumberLabel.AutoSize = true;
            currentScenarioNumberLabel.Font = new Font("Segoe UI", 32F);
            currentScenarioNumberLabel.Location = new Point(716, 107);
            currentScenarioNumberLabel.Name = "currentScenarioNumberLabel";
            currentScenarioNumberLabel.Size = new Size(94, 59);
            currentScenarioNumberLabel.TabIndex = 10;
            currentScenarioNumberLabel.Text = "000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 197);
            Controls.Add(currentScenarioNumberLabel);
            Controls.Add(buttonResetScenario);
            Controls.Add(checkBoxOnTop);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(checkBoxDisableNotifications);
            Controls.Add(nextScenarioLabel);
            Controls.Add(previousScenarioLabel);
            Controls.Add(chooseOutputFolder);
            Controls.Add(textFolderPath);
            Name = "Form1";
            Text = "Scenario Capture";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog outputFolderDialog;
        private TextBox textBox1;
        private TextBox textFolderPath;
        private Button chooseOutputFolder;
        private Label previousScenarioLabel;
        private Label currentScenarioLabel;
        private Label nextScenarioLabel;
        private CheckBox checkBoxDisableNotifications;
        private Panel panel1;
        private Label label1;
        private CheckBox checkBoxOnTop;
        private Button buttonResetScenario;
        private Label currentScenarioNumberLabel;
    }
}
