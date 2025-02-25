namespace TaskTracker
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button1 = new Button();
            MainPanel = new Panel();
            button2 = new Button();
            TaskGrid = new DataGridView();
            Tasks = new DataGridViewTextBoxColumn();
            Status = new DataGridViewCheckBoxColumn();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TaskGrid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(51, 51, 51);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 14F);
            button1.ForeColor = Color.FromArgb(212, 212, 212);
            button1.Location = new Point(490, 850);
            button1.Name = "button1";
            button1.Size = new Size(150, 50);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += AddTask;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BackColor = Color.FromArgb(38, 38, 38);
            MainPanel.Controls.Add(button2);
            MainPanel.Controls.Add(TaskGrid);
            MainPanel.Controls.Add(button1);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1284, 961);
            MainPanel.TabIndex = 5;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(51, 51, 51);
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 14F);
            button2.ForeColor = Color.FromArgb(212, 212, 212);
            button2.Location = new Point(660, 850);
            button2.Name = "button2";
            button2.Size = new Size(150, 50);
            button2.TabIndex = 6;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Clear_Click;
            // 
            // TaskGrid
            // 
            TaskGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TaskGrid.BackgroundColor = Color.FromArgb(30, 30, 30);
            TaskGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(37, 37, 38);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(212, 212, 212);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(212, 212, 212);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            TaskGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            TaskGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TaskGrid.Columns.AddRange(new DataGridViewColumn[] { Tasks, Status });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(37, 37, 38);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(212, 212, 212);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(212, 212, 212);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            TaskGrid.DefaultCellStyle = dataGridViewCellStyle4;
            TaskGrid.Dock = DockStyle.Top;
            TaskGrid.EnableHeadersVisualStyles = false;
            TaskGrid.Location = new Point(0, 0);
            TaskGrid.Margin = new Padding(0);
            TaskGrid.Name = "TaskGrid";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            TaskGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            TaskGrid.RowHeadersVisible = false;
            TaskGrid.ScrollBars = ScrollBars.Vertical;
            TaskGrid.Size = new Size(1284, 800);
            TaskGrid.TabIndex = 5;
            TaskGrid.CellContentClick += CheckBoxClick;
            // 
            // Tasks
            // 
            Tasks.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Tasks.DefaultCellStyle = dataGridViewCellStyle2;
            Tasks.HeaderText = "Tasks";
            Tasks.MinimumWidth = 1230;
            Tasks.Name = "Tasks";
            Tasks.Resizable = DataGridViewTriState.True;
            Tasks.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Status.DefaultCellStyle = dataGridViewCellStyle3;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.Resizable = DataGridViewTriState.True;
            Status.Width = 50;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.LightGray;
            ClientSize = new Size(1284, 961);
            Controls.Add(MainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Tasks";
            MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TaskGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel MainPanel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn sssq;
        private DataGridView TaskGrid;
        private Button button2;
        private DataGridViewTextBoxColumn Tasks;
        private DataGridViewCheckBoxColumn Status;
    }
}
