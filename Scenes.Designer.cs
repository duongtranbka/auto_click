namespace Auto_Click
{
    partial class Scenes
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
            jScreenTable = new DataGridView();
            jTimeoutLabel = new Label();
            jDropCommand = new ComboBox();
            jSaveScene = new Button();
            jAddCMD = new Button();
            jInputTimeOut = new TextBox();
            jInputImageUrl = new TextBox();
            JImageUrlLable = new Label();
            jCoordinateLabel = new Label();
            jUrlWebLabel = new Label();
            jInputCoordinate = new TextBox();
            jInputWebUrl = new TextBox();
            jRemoveCMD = new Button();
            jInputDrag = new TextBox();
            JDragLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)jScreenTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 0;
            label1.Text = "Scenes Table";
            // 
            // jScreenTable
            // 
            jScreenTable.AllowUserToAddRows = false;
            jScreenTable.AllowUserToDeleteRows = false;
            jScreenTable.AllowUserToResizeColumns = false;
            jScreenTable.AllowUserToResizeRows = false;
            jScreenTable.BackgroundColor = Color.White;
            jScreenTable.BorderStyle = BorderStyle.None;
            jScreenTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            jScreenTable.Location = new Point(240, 37);
            jScreenTable.Name = "jScreenTable";
            jScreenTable.ReadOnly = true;
            jScreenTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            jScreenTable.Size = new Size(240, 386);
            jScreenTable.TabIndex = 1;
            // 
            // jTimeoutLabel
            // 
            jTimeoutLabel.AutoSize = true;
            jTimeoutLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jTimeoutLabel.Location = new Point(21, 228);
            jTimeoutLabel.Name = "jTimeoutLabel";
            jTimeoutLabel.Size = new Size(60, 17);
            jTimeoutLabel.TabIndex = 5;
            jTimeoutLabel.Text = "Timeout";
            // 
            // jDropCommand
            // 
            jDropCommand.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jDropCommand.FormattingEnabled = true;
            jDropCommand.Items.AddRange(new object[] { "Go To", "Click To X/Y", "Click To Image", "Wait Image", "Wait", "Sroll_Down", "Scroll_Up", "Drag" });
            jDropCommand.Location = new Point(113, 37);
            jDropCommand.Name = "jDropCommand";
            jDropCommand.Size = new Size(121, 25);
            jDropCommand.TabIndex = 2;
            jDropCommand.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // jSaveScene
            // 
            jSaveScene.BackColor = SystemColors.ActiveCaption;
            jSaveScene.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jSaveScene.Location = new Point(113, 347);
            jSaveScene.Name = "jSaveScene";
            jSaveScene.Size = new Size(121, 29);
            jSaveScene.TabIndex = 3;
            jSaveScene.Text = "Save Scene";
            jSaveScene.UseVisualStyleBackColor = false;
            jSaveScene.Visible = false;
            // 
            // jAddCMD
            // 
            jAddCMD.BackColor = SystemColors.ActiveCaption;
            jAddCMD.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jAddCMD.Location = new Point(113, 253);
            jAddCMD.Name = "jAddCMD";
            jAddCMD.Size = new Size(121, 30);
            jAddCMD.TabIndex = 4;
            jAddCMD.Text = "Add CMD";
            jAddCMD.UseVisualStyleBackColor = false;
            jAddCMD.Click += jAddCommand_Click;
            // 
            // jInputTimeOut
            // 
            jInputTimeOut.Location = new Point(113, 224);
            jInputTimeOut.Name = "jInputTimeOut";
            jInputTimeOut.Size = new Size(121, 23);
            jInputTimeOut.TabIndex = 6;
            // 
            // jInputImageUrl
            // 
            jInputImageUrl.Location = new Point(113, 195);
            jInputImageUrl.Name = "jInputImageUrl";
            jInputImageUrl.Size = new Size(121, 23);
            jInputImageUrl.TabIndex = 7;
            // 
            // JImageUrlLable
            // 
            JImageUrlLable.AutoSize = true;
            JImageUrlLable.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JImageUrlLable.Location = new Point(21, 198);
            JImageUrlLable.Name = "JImageUrlLable";
            JImageUrlLable.Size = new Size(68, 17);
            JImageUrlLable.TabIndex = 8;
            JImageUrlLable.Text = "Image Url";
            // 
            // jCoordinateLabel
            // 
            jCoordinateLabel.AutoSize = true;
            jCoordinateLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jCoordinateLabel.Location = new Point(21, 166);
            jCoordinateLabel.Name = "jCoordinateLabel";
            jCoordinateLabel.Size = new Size(29, 17);
            jCoordinateLabel.TabIndex = 9;
            jCoordinateLabel.Text = "X,Y";
            // 
            // jUrlWebLabel
            // 
            jUrlWebLabel.AutoSize = true;
            jUrlWebLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jUrlWebLabel.Location = new Point(21, 139);
            jUrlWebLabel.Name = "jUrlWebLabel";
            jUrlWebLabel.Size = new Size(58, 17);
            jUrlWebLabel.TabIndex = 10;
            jUrlWebLabel.Text = "Web Url";
            // 
            // jInputCoordinate
            // 
            jInputCoordinate.Location = new Point(113, 166);
            jInputCoordinate.Name = "jInputCoordinate";
            jInputCoordinate.Size = new Size(121, 23);
            jInputCoordinate.TabIndex = 11;
            // 
            // jInputWebUrl
            // 
            jInputWebUrl.Location = new Point(113, 137);
            jInputWebUrl.Name = "jInputWebUrl";
            jInputWebUrl.Size = new Size(121, 23);
            jInputWebUrl.TabIndex = 12;
            // 
            // jRemoveCMD
            // 
            jRemoveCMD.BackColor = SystemColors.ActiveCaption;
            jRemoveCMD.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            jRemoveCMD.Location = new Point(113, 301);
            jRemoveCMD.Name = "jRemoveCMD";
            jRemoveCMD.Size = new Size(121, 27);
            jRemoveCMD.TabIndex = 13;
            jRemoveCMD.Text = "Remove CMD";
            jRemoveCMD.UseVisualStyleBackColor = false;
            jRemoveCMD.Click += jRemoveCMD_Click;
            // 
            // jInputDrag
            // 
            jInputDrag.Location = new Point(113, 108);
            jInputDrag.Name = "jInputDrag";
            jInputDrag.Size = new Size(121, 23);
            jInputDrag.TabIndex = 14;
            // 
            // JDragLabel
            // 
            JDragLabel.AutoSize = true;
            JDragLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            JDragLabel.Location = new Point(21, 114);
            JDragLabel.Name = "JDragLabel";
            JDragLabel.Size = new Size(82, 17);
            JDragLabel.TabIndex = 15;
            JDragLabel.Text = "X1,Y1,X2,Y2";
            // 
            // Scenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 453);
            Controls.Add(JDragLabel);
            Controls.Add(jInputDrag);
            Controls.Add(jRemoveCMD);
            Controls.Add(jInputWebUrl);
            Controls.Add(jInputCoordinate);
            Controls.Add(jUrlWebLabel);
            Controls.Add(jCoordinateLabel);
            Controls.Add(JImageUrlLable);
            Controls.Add(jInputImageUrl);
            Controls.Add(jInputTimeOut);
            Controls.Add(jTimeoutLabel);
            Controls.Add(jAddCMD);
            Controls.Add(jSaveScene);
            Controls.Add(jDropCommand);
            Controls.Add(jScreenTable);
            Controls.Add(label1);
            Name = "Scenes";
            Text = "Scenes";
            ((System.ComponentModel.ISupportInitialize)jScreenTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView jScreenTable;
        private Label jTimeoutLabel;
        private ComboBox jDropCommand;
        private Button jSaveScene;
        private Button jAddCMD;
        private TextBox jInputTimeOut;
        private TextBox jInputImageUrl;
        private Label JImageUrlLable;
        private Label jCoordinateLabel;
        private Label jUrlWebLabel;
        private TextBox jInputCoordinate;
        private TextBox jInputWebUrl;
        private Button jRemoveCMD;
        private TextBox jInputDrag;
        private Label JDragLabel;
    }
}