using System.Text.Json;
using System.Reflection;
using System.Threading.Tasks;


namespace TaskTracker
{
    public partial class Form1 : Form
    {
        private List<Dictionary<string, object>> TasksList = new();
        private TaskManager taskManager = new();
        private bool isProcessing = false;

        public Color green = Color.FromArgb(80, 161, 79);
        public Color red = Color.FromArgb(180, 60, 60);
     
        public Form1()
        {
            InitializeComponent();


            this.ResizeBegin += (_, _) => this.SuspendLayout();
            this.ResizeEnd += (_, _) => this.ResumeLayout(true);

            InitializeTaskTable();
            LoadTasks();


            TaskGrid.Columns["Tasks"].Width = 200;

            // Then allow it to auto-size based on content

        }

        private void InitializeTaskTable()
        {
            TaskGrid.RowCount = 1;
            TaskGrid.AllowUserToAddRows = false;
            TaskGrid.AllowUserToDeleteRows = false;
        }

        private async void LoadTasks()
        {
            TasksList = taskManager.LoadTasks();

            if (TasksList.Count == 0) return;

            SuspendLayout();

            for (int i = 0; i < TasksList.Count; i++)
            {
                string taskString = TasksList[i]["Tasks"].ToString();

                bool completed = ((JsonElement)TasksList[i]["Completed"]).GetBoolean();

                taskManager.InitTableData(taskString, completed, TaskGrid, this, i);
                TaskGrid.Rows[i].Cells["Status"].Style.BackColor = completed ? green : red;
                TaskGrid.Rows[i].Cells["Status"].Value = completed ? true : false;
                TasksList[i]["Completed"] = completed;


                ResumeLayout(true);
            }
        }
        public void UpdateTask(string task)
        {
            SuspendLayout();

            TasksList.Add(new Dictionary<string, object>
            {
                {"Tasks", task},
                {"Completed", false}
            });

            taskManager.InitTableData(task, false, TaskGrid, this, TaskGrid.RowCount - 1);
            TaskGrid.Rows[TaskGrid.Rows.Count - 1].Cells["Status"].Style.BackColor = red;

            taskManager.SaveTasks(TasksList);
            ResumeLayout(true);
        }
        private void AddTask(object sender, EventArgs e)
        {
            var taskTextBox = Application.OpenForms.OfType<TaskTextBox>().FirstOrDefault() ?? new TaskTextBox(this);
            taskTextBox.ShowDialog();
        }

        public async void CheckBoxClick(object sender, DataGridViewCellEventArgs e)
        {
            TaskGrid.Enabled = false;
            if (e.RowIndex >= 0 && e.ColumnIndex == TaskGrid.Columns["Status"].Index)
            {
                
                TaskGrid.EndEdit();

                DataGridViewCell cell = TaskGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool isComplete = Convert.ToBoolean(TasksList[e.RowIndex]["Completed"]);

                cell.Style.BackColor = isComplete ? red : green;
                TasksList[e.RowIndex]["Completed"] = isComplete ? false : true;

                taskManager.SaveTasks(TasksList);
                await Task.Delay(500);
            }
            TaskGrid.Enabled = true;
        }



        private void Clear_Click(object sender, EventArgs e)
        {
            TaskGrid.SuspendLayout();
            TaskGrid.Controls.Clear();
            TaskGrid.RowCount = 0;
            TaskGrid.ResumeLayout();
            TasksList.Clear();
            taskManager.SaveTasks(TasksList);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffering(this);
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            var screenSize = Screen.PrimaryScreen.Bounds.Size;

            this.Size = screenSize;
            this.Location = new Point(0, 0);

            MainPanel.Size = screenSize;
            int xPos = (this.ClientSize.Width - MainPanel.Width) / 2;
            int yPos = (this.ClientSize.Height - MainPanel.Height) / 2;

            MainPanel.Location = new Point(xPos, yPos);

            MainPanel.AutoScroll = true;

            //panel1.Height = (int)(screenSize.Height * 0.6);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout(true);
            base.OnResizeEnd(e);
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Instance, null, control, new object[] { true });
        }
    }
}

