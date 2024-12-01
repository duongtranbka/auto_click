namespace Auto_Click
{
    partial class Form2
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
            saveVersionChrome = new Button();
            label1 = new Label();
            getVersionChrome = new RichTextBox();
            SuspendLayout();
            // 
            // saveVersionChrome
            // 
            saveVersionChrome.BackColor = SystemColors.ActiveCaption;
            saveVersionChrome.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveVersionChrome.Location = new Point(137, 99);
            saveVersionChrome.Name = "saveVersionChrome";
            saveVersionChrome.Size = new Size(75, 38);
            saveVersionChrome.TabIndex = 0;
            saveVersionChrome.Text = "Save";
            saveVersionChrome.UseVisualStyleBackColor = false;
            saveVersionChrome.Click += saveVersionChrome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 45);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 1;
            label1.Text = "Type Version";
            // 
            // getVersionChrome
            // 
            getVersionChrome.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            getVersionChrome.Location = new Point(123, 30);
            getVersionChrome.Name = "getVersionChrome";
            getVersionChrome.Size = new Size(105, 46);
            getVersionChrome.TabIndex = 2;
            getVersionChrome.Text = "";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 149);
            Controls.Add(getVersionChrome);
            Controls.Add(label1);
            Controls.Add(saveVersionChrome);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveVersionChrome;
        private Label label1;
        private RichTextBox getVersionChrome;
    }
}