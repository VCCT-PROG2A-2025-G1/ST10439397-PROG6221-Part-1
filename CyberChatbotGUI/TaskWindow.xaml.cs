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
                InitializeComponent(); // Ensure this is called within the constructor of the correct class
                RefreshTaskList();
            }

            private void AddTask_Click(object sender, RoutedEventArgs e)
            {
                string title = TaskTitleBox.Text; // Accessing TextBox.Text property
                string description = TaskDescriptionBox.Text; // Accessing TextBox.Text property
                if (!string.IsNullOrWhiteSpace(title))
                {
                    TaskManager.Tasks.Add(new TaskItem
                    {
                        Title = title,
                        Description = description,
                        ReminderDate = DateTime.Now.AddDays(3),
                        Completed = false
                    });
                    ActivityLogger.Add($"Task added: '{title}'");
                    RefreshTaskList();
                    TaskTitleBox.Clear(); // Clear method for TextBox
                    TaskDescriptionBox.Clear(); // Clear method for TextBox
                }
            }

            private void RefreshTaskList()
            {
                TaskList.Items.Clear(); // Clear method for ListBox
                foreach (var task in TaskManager.Tasks)
                {
                    string display = task.Title + (task.ReminderDate.HasValue ? $" (Reminder: {task.ReminderDate.Value:d})" : "");
                    TaskList.Items.Add(display); // Add method for ListBox
                }
            }
        }
}
