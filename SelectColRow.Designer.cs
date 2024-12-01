namespace Auto_Click
{
    partial class SelectColRow
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
            jRun = new Button();
            label1 = new Label();
            jNumberCol = new ComboBox();
            jNumberRow = new ComboBox();
            SuspendLayout();
            // 
            // jRun
            // 
            jRun.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jRun.Location = new Point(168, 170);
            jRun.Name = "jRun";
            jRun.Size = new Size(99, 46);
            jRun.TabIndex = 0;
            jRun.Text = "Run";
            jRun.UseVisualStyleBackColor = true;
            jRun.Click += jRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(41, 100);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 1;
            label1.Text = "Col X Row";
            // 
            // jNumberCol
            // 
            jNumberCol.DropDownStyle = ComboBoxStyle.DropDownList;
            jNumberCol.FormattingEnabled = true;
            jNumberCol.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            jNumberCol.Location = new Point(127, 100);
            jNumberCol.Name = "jNumberCol";
            jNumberCol.Size = new Size(121, 23);
            jNumberCol.TabIndex = 2;
            // 
            // jNumberRow
            // 
            jNumberRow.DropDownStyle = ComboBoxStyle.DropDownList;
            jNumberRow.FormattingEnabled = true;
            jNumberRow.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            jNumberRow.Location = new Point(264, 100);
            jNumberRow.Name = "jNumberRow";
            jNumberRow.Size = new Size(121, 23);
            jNumberRow.TabIndex = 3;
            // 
            // SelectColRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 248);
            Controls.Add(jNumberRow);
            Controls.Add(jNumberCol);
            Controls.Add(label1);
            Controls.Add(jRun);
            Name = "SelectColRow";
            Text = "SelectColRow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button jRun;
        private Label label1;
        private ComboBox jNumberCol;
        private ComboBox jNumberRow;
    }
}