namespace TaskTracker
{
    partial class TaskTextBox
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
            AddText = new TextBox();
            Add = new Button();
            SuspendLayout();
            // 
            // AddText
            // 
            AddText.BackColor = Color.FromArgb(37, 37, 38);
            AddText.BorderStyle = BorderStyle.FixedSingle;
            AddText.Font = new Font("Segoe UI", 12F);
            AddText.ForeColor = Color.FromArgb(212, 212, 212);
            AddText.Location = new Point(169, 102);
            AddText.Multiline = true;
            AddText.Name = "AddText";
            AddText.Size = new Size(250, 100);
            AddText.TabIndex = 0;
            AddText.TextChanged += SaveTaskText;
            // 
            // Add
            // 
            Add.BackColor = Color.FromArgb(37, 37, 38);
            Add.FlatStyle = FlatStyle.Popup;
            Add.Font = new Font("Segoe UI", 14F);
            Add.ForeColor = Color.FromArgb(212, 212, 212);
            Add.Location = new Point(221, 245);
            Add.Name = "Add";
            Add.Size = new Size(150, 50);
            Add.TabIndex = 1;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = false;
            Add.Click += AddTextToTask;
            // 
            // TaskTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(584, 361);
            Controls.Add(Add);
            Controls.Add(AddText);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TaskTextBox";
            Text = "TaskTextBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox AddText;
        private Button Add;
    }
}