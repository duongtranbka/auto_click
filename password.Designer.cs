namespace Auto_Click
{
    partial class password
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
            jSubmitPassword = new Button();
            jInputPW = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // jSubmitPassword
            // 
            jSubmitPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jSubmitPassword.Location = new Point(120, 100);
            jSubmitPassword.Name = "jSubmitPassword";
            jSubmitPassword.Size = new Size(75, 23);
            jSubmitPassword.TabIndex = 0;
            jSubmitPassword.Text = "Submit";
            jSubmitPassword.UseVisualStyleBackColor = true;
            jSubmitPassword.Click += jSubmitPassword_Click;
            // 
            // jInputPW
            // 
            jInputPW.Location = new Point(108, 60);
            jInputPW.Name = "jInputPW";
            jInputPW.Size = new Size(100, 23);
            jInputPW.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 29);
            label1.Name = "label1";
            label1.Size = new Size(102, 17);
            label1.TabIndex = 3;
            label1.Text = "Enter Password";
            // 
            // password
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 155);
            Controls.Add(label1);
            Controls.Add(jInputPW);
            Controls.Add(jSubmitPassword);
            Name = "password";
            Text = "password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button jSubmitPassword;
        private TextBox jInputPW;
        private Label label1;
    }
}