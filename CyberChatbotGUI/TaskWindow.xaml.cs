using CyberChatbotGUI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CyberChatbotGUI.Logic;

namespace CyberChatbotGUI
{
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
            RefreshTaskList();
        }

//--------------------------------------------------------------------------------
//How the Task Manager system captures tasks and reminders
        public static class TaskManager
        {
            public static List<TaskItem> Tasks = new List<TaskItem>();
        }

//--------------------------------------------------------------------------------
//How the Task Manager system captures tasks and reminders
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text;
            string description = TaskDescriptionBox.Text;
            DateTime? selectedDate = ReminderDatePicker.SelectedDate;

            if (!string.IsNullOrWhiteSpace(title))
            {
                DateTime? reminder = null;
                string reminderMsg = "";

                // If a reminder date is selected, set the reminder and calculate days difference
                if (selectedDate.HasValue)
                {
                    reminder = selectedDate.Value;
                    int daysDiff = (reminder.Value - DateTime.Now.Date).Days;
                    reminderMsg = $" (Reminder set for {daysDiff} day(s) from now)";
                }

                // Adds the task to the TaskManager and logs the action
                TaskManager.Tasks.Add(new TaskItem
                {
                    Title = title,
                    Description = description,
                    ReminderDate = reminder,
                    Completed = false
                });

                ActivityLogger.Add($"Task added: '{title}'{reminderMsg}");
                RefreshTaskList();

                //Resets the input fields after adding a task
                TaskTitleBox.Clear();
                TaskDescriptionBox.Clear();
                ReminderDatePicker.SelectedDate = null;
            }
        }

//--------------------------------------------------------------------------------
// Refreshes the TaskList with current tasks and their statuses
        private void RefreshTaskList()
        {
            TaskList.Items.Clear();
            foreach (var task in TaskManager.Tasks)
            {
                string status = task.Completed ? "(Completed)" : "(Pending)";
                string display = $"{task.Title} {status}" + (task.ReminderDate.HasValue ? $" - Reminder: {task.ReminderDate.Value:d}" : "");
                TaskList.Items.Add(display);
            }
        }

//--------------------------------------------------------------------------------
// Toggles the completion status of the selected task and logs the action
        private void ToggleComplete_Click(object sender, RoutedEventArgs e)
        {
            int index = TaskList.SelectedIndex;

            // Check if the selected index is valid
            if (index >= 0 && index < TaskManager.Tasks.Count)
            {
                var task = TaskManager.Tasks[index];
                task.Completed = !task.Completed;
                // Log the action based on the task's new status
                string action = task.Completed ? "marked completed" : "marked as pending";
                ActivityLogger.Add($"Task {action}: '{task.Title}'");
                RefreshTaskList();
            }
        }
//--------------------------------------------------------------------------------
// Deletes the task to the TaskList while also logging the action
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            int index = TaskList.SelectedIndex;

            // Check if the selected index is valid
            if (index >= 0 && index < TaskManager.Tasks.Count)
            {
                ActivityLogger.Add($"Task deleted: '{TaskManager.Tasks[index].Title}'");
                TaskManager.Tasks.RemoveAt(index);
                RefreshTaskList();
            }
        }

//--------------------------------------------------------------------------------
// Takes the user back to the MainWindow
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
//=====================================0000000000END OF FILE========================================