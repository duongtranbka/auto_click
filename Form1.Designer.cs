namespace Auto_Click
{
    partial class Auto_Click
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
            jLog = new RichTextBox();
            Start = new Button();
            updateVersionChrome = new Button();
            AddProfile = new Button();
            RemoveProfile = new Button();
            EditScenes = new Button();
            jEditButton = new Button();
            jStop = new Button();
            dataGridView1 = new DataGridView();
            jCheckforupdatesbutton = new Button();
            label1 = new Label();
            jHashID = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // jLog
            // 
            jLog.Location = new Point(12, 301);
            jLog.Name = "jLog";
            jLog.ReadOnly = true;
            jLog.Size = new Size(372, 111);
            jLog.TabIndex = 0;
            jLog.Text = "";
            // 
            // Start
            // 
            Start.BackColor = Color.FromArgb(128, 255, 128);
            Start.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Start.Location = new Point(12, 12);
            Start.Name = "Start";
            Start.Size = new Size(74, 48);
            Start.TabIndex = 1;
            Start.Text = "Start";
            Start.UseVisualStyleBackColor = false;
            Start.Click += Start_Click;
            // 
            // updateVersionChrome
            // 
            updateVersionChrome.Enabled = false;
            updateVersionChrome.Location = new Point(12, 83);
            updateVersionChrome.Name = "updateVersionChrome";
            updateVersionChrome.Size = new Size(148, 35);
            updateVersionChrome.TabIndex = 2;
            updateVersionChrome.Text = "Update Version Chrome";
            updateVersionChrome.UseVisualStyleBackColor = true;
            updateVersionChrome.Click += updateVersionChrome_Click;
            // 
            // AddProfile
            // 
            AddProfile.Location = new Point(12, 144);
            AddProfile.Name = "AddProfile";
            AddProfile.Size = new Size(148, 35);
            AddProfile.TabIndex = 3;
            AddProfile.Text = "Add Profile";
            AddProfile.UseVisualStyleBackColor = true;
            AddProfile.Click += AddProfile_Click;
            // 
            // RemoveProfile
            // 
            RemoveProfile.Location = new Point(12, 202);
            RemoveProfile.Name = "RemoveProfile";
            RemoveProfile.Size = new Size(148, 36);
            RemoveProfile.TabIndex = 4;
            RemoveProfile.Text = "Remove Profile";
            RemoveProfile.UseVisualStyleBackColor = true;
            RemoveProfile.Click += RemoveProfile_Click;
            // 
            // EditScenes
            // 
            EditScenes.Location = new Point(12, 258);
            EditScenes.Name = "EditScenes";
            EditScenes.Size = new Size(148, 37);
            EditScenes.TabIndex = 5;
            EditScenes.Text = "Edit Scenes";
            EditScenes.UseVisualStyleBackColor = true;
            EditScenes.Click += EditScenes_Click;
            // 
            // jEditButton
            // 
            jEditButton.BackColor = Color.FromArgb(192, 192, 255);
            jEditButton.Location = new Point(92, 12);
            jEditButton.Name = "jEditButton";
            jEditButton.Size = new Size(68, 48);
            jEditButton.TabIndex = 7;
            jEditButton.Text = "Edit Config";
            jEditButton.UseVisualStyleBackColor = false;
            jEditButton.Click += jEditButton_Click;
            // 
            // jStop
            // 
            jStop.BackColor = Color.FromArgb(255, 128, 128);
            jStop.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jStop.Location = new Point(180, 12);
            jStop.Name = "jStop";
            jStop.Size = new Size(77, 48);
            jStop.TabIndex = 8;
            jStop.Text = "Stop";
            jStop.UseVisualStyleBackColor = false;
            jStop.Click += jStop_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Location = new Point(399, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(389, 388);
            dataGridView1.TabIndex = 9;
            // 
            // jCheckforupdatesbutton
            // 
            jCheckforupdatesbutton.Location = new Point(180, 271);
            jCheckforupdatesbutton.Name = "jCheckforupdatesbutton";
            jCheckforupdatesbutton.Size = new Size(120, 24);
            jCheckforupdatesbutton.TabIndex = 10;
            jCheckforupdatesbutton.Text = "Check for Updates";
            jCheckforupdatesbutton.UseVisualStyleBackColor = true;
            jCheckforupdatesbutton.Click += jCheckforupdatesbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 426);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 11;
            label1.Text = "Hash ID : ";
            // 
            // jHashID
            // 
            jHashID.AutoSize = true;
            jHashID.Location = new Point(62, 426);
            jHashID.Name = "jHashID";
            jHashID.Size = new Size(0, 15);
            jHashID.TabIndex = 12;
            // 
            // Auto_Click
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(jHashID);
            Controls.Add(label1);
            Controls.Add(jCheckforupdatesbutton);
            Controls.Add(dataGridView1);
            Controls.Add(jStop);
            Controls.Add(jEditButton);
            Controls.Add(EditScenes);
            Controls.Add(RemoveProfile);
            Controls.Add(AddProfile);
            Controls.Add(updateVersionChrome);
            Controls.Add(Start);
            Controls.Add(jLog);
            Name = "Auto_Click";
            Text = "Auto_Click_new";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Start;
        private Button updateVersionChrome;
        private Button AddProfile;
        private Button RemoveProfile;
        private Button EditScenes;
        private Button jEditButton;
        private Button jStop;
        public DataGridView dataGridView1;
        private Button jCheckforupdatesbutton;
        private Label label1;
        private Label jHashID;
        public RichTextBox jLog;
    }
}
