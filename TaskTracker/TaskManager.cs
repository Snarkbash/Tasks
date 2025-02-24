using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Xml;
using TaskTracker;
using System.Drawing;
using System.Collections;

public class TaskManager
{
    private string filePath = "tasks.txt";

    public List<Dictionary<string, object>> LoadTasks()
    {
        Debug.WriteLine($"Tasks file path: {Path.GetFullPath(filePath)}");

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);
        }
        else
        {
            return new List<Dictionary<string, object>>();
        }
    }
    public void SaveTasks(List<Dictionary<string, object>> taskList)
    {
        string jsonString = JsonSerializer.Serialize(taskList);
        File.WriteAllText(filePath, jsonString);
    }


    public void InitTableData(string task, Boolean complete, DataGridView table, Form1 form1, int row)
    {
        table.Rows.Add(task);
    }
}
