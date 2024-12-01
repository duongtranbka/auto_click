namespace Auto_Click
{
    partial class AddProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            inputUserDir = new TextBox();
            inputProfileName = new TextBox();
            SaveProfile = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 92);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 0;
            label1.Text = "User Data Dir";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 165);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 1;
            label2.Text = "Profile Name";
            // 
            // inputUserDir
            // 
            inputUserDir.BorderStyle = BorderStyle.None;
            inputUserDir.Location = new Point(171, 90);
            inputUserDir.Name = "inputUserDir";
            inputUserDir.Size = new Size(368, 16);
            inputUserDir.TabIndex = 2;
            // 
            // inputProfileName
            // 
            inputProfileName.BorderStyle = BorderStyle.None;
            inputProfileName.Location = new Point(171, 163);
            inputProfileName.Name = "inputProfileName";
            inputProfileName.Size = new Size(368, 16);
            inputProfileName.TabIndex = 3;
            // 
            // SaveProfile
            // 
            SaveProfile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveProfile.Location = new Point(286, 216);
            SaveProfile.Name = "SaveProfile";
            SaveProfile.Size = new Size(75, 39);
            SaveProfile.TabIndex = 4;
            SaveProfile.Text = "Save";
            SaveProfile.UseVisualStyleBackColor = true;
            SaveProfile.Click += SaveProfile_Click;
            // 
            // AddProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 279);
            Controls.Add(SaveProfile);
            Controls.Add(inputProfileName);
            Controls.Add(inputUserDir);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddProfile";
            Text = "AddProfile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox inputUserDir;
        private TextBox inputProfileName;
        private Button SaveProfile;
    }
}