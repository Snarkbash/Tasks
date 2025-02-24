using System.Diagnostics;
using System.Windows.Forms;
using System.Text.Json;
using System.Reflection;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32;

namespace TaskTracker
{
    public partial class Form1 : Form
    {
        private List<Dictionary<string, object>> TasksList = new();
        private TaskManager taskManager = new();
        private const string InProgress = "IN PROGRESS";
        private const string Complete = "COMPLETE";

        public Color green = Color.FromArgb(80, 161, 79);
        public Color red = Color.FromArgb(180, 60, 60);
     
        public Form1()
        {
            InitializeComponent();


            this.ResizeBegin += (_, _) => this.SuspendLayout();
            this.ResizeEnd += (_, _) => this.ResumeLayout(true);

            InitializeTaskTable();
            LoadTasks();


            TaskGrid.Columns["Task"].Width = 200;

            // Then allow it to auto-size based on content

        }

        private void InitializeTaskTable()
        {
            TaskGrid.RowCount = 1;
            TaskGrid.AllowUserToAddRows = false;
            TaskGrid.AllowUserToDeleteRows = false;
        }

        private void LoadTasks()
        {
            TasksList = taskManager.LoadTasks();

            if (TasksList.Count == 0) return;

            SuspendLayout();

            for (int i = 0; i < TasksList.Count; i++)
            {
                string taskString = TasksList[i]["Task"].ToString();

                bool completed = ((JsonElement)TasksList[i]["Completed"]).GetBoolean();

                taskManager.InitTableData(taskString, completed, TaskGrid, this, i);

                if (completed)
                {
                    TaskGrid.Rows[i].Cells["Status"].Style.BackColor = green;
                    TasksList[i]["Completed"] = JsonDocument.Parse("false").RootElement;
                    TaskGrid.Rows[i].Cells["Status"].Value = true;
                }
                else
                {
                    TaskGrid.Rows[i].Cells["Status"].Style.BackColor = red;
                    TasksList[i]["Completed"] = JsonDocument.Parse("true").RootElement;
                    TaskGrid.Rows[i].Cells["Status"].Value = false;
                }
            }

            ResumeLayout(true);
        }
        public void UpdateTask(string task)
        {
            SuspendLayout();

            TasksList.Add(new Dictionary<string, object>
            {
                {"Task", task},
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

        public void CheckBoxClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == TaskGrid.Columns["Status"].Index)
            {
                DataGridViewCell cell = TaskGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];

                bool isComplete = Convert.ToBoolean(cell.Value);

                if (isComplete)
                {
                    cell.Style.BackColor = red;
                    TasksList[e.RowIndex]["Completed"] = false;
                }
                else
                {
                    cell.Style.BackColor = green;
                    TasksList[e.RowIndex]["Completed"] = true;
                }
                taskManager.SaveTasks(TasksList);
            }
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

