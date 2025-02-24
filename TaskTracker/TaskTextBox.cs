using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTracker
{
    public partial class TaskTextBox : Form
    {
        private Form1 mainForm;

        private string currentTask;

        public TaskTextBox(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }
        private void SaveTaskText(object sender, EventArgs e)
        {
            currentTask = AddText.Text;
        }

        public void AddTextToTask(object sender, EventArgs e)
        {
            if (currentTask != null)
            {
                Debug.WriteLine("Adding to task list: " + currentTask);
                mainForm.UpdateTask(currentTask);
                this.Close();
            }
            else 
            {
                MessageBox.Show("Please add text to your new task!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
