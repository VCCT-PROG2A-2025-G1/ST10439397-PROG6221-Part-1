using Chatbot_Shared;
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
using static Chatbot_Shared.Class1;

namespace CyberChatbotGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string UserName = "User";
        public MainWindow()
        {
            InitializeComponent();
            //string input = Interaction.InputBox("Please enter your name:", "Welcome", "User");
            //if (!string.IsNullOrWhiteSpace(input))
            //{
            //    UserName = input.Trim();
            //}
            AddChatMessage("Bot: " + GetHelpMessage());
        }

        //--------------------------------------------------------------------------------
        // Handles the Enter key press in the UserInputBox to send the message
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInputBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(input)) return;

            AddChatMessage($"{UserState.Name}: " + input);

            string response = Processes.Process(input);
            AddChatMessage("Bot: " + response);

            UserInputBox.Clear();
        }

//--------------------------------------------------------------------------------
// 
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

    private string GetHelpMessage()
        {
            return "👋 Welcome! Here’s what I can help you with:\n" +
                   "• Add a task: 'add task' or 'remind me'\n" +
                   "• Take a cybersecurity quiz: 'start quiz'\n" +
                   "• View your tasks: 'show tasks'\n" +
                   "• Mark/delete a task in the task window\n" +
                   "• View activity log: 'show activity log'\n" +
                   "• Ask questions about cybersecurity topics\n" +
                   "• Exit: type 'exit'\n";
        }
    }
}
//=====================================0000000000END OF FILE========================================