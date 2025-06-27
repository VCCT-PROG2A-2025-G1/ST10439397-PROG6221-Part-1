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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberChatbotGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddChatMessage("Bot: " + GetHelpMessage());
        }

//--------------------------------------------------------------------------------
// Handles the Enter key press in the UserInputBox to send the message
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInputBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(input)) return;

            AddChatMessage("You: " + input);

            string response = Processes.Process(input);
            AddChatMessage("Bot: " + response);

            UserInputBox.Clear();
        }

//--------------------------------------------------------------------------------
// Method to handle the Enter key press in the UserInputBox
        private string GetHelpMessage()
        {
            return "Hello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.\n" +
                   "• Add a task: 'add task' or 'remind me'\n" +
                   "• Take a cybersecurity quiz: 'start quiz'\n" +
                   "• View your tasks: 'show tasks'\n" +
                   "• Mark/delete a task in the task window\n" +
                   "• View activity log: 'show activity log', 'log'\n" +
                   "• Ask questions about cybersecurity topics\n" +
                   "• Exit: type 'exit'\n";
        }

//--------------------------------------------------------------------------------
// Method to handle the Enter key press in the UserInputBox
        private void AddChatMessage(string message)
        {
            ChatPanel.Children.Add(new TextBlock
            {
                Text = message,
                Foreground = System.Windows.Media.Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 5, 0, 0)
            });
        }
    }
}
//=====================================0000000000END OF FILE========================================