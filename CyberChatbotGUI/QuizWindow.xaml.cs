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
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private int currentIndex = 0;
        private int score = 0;

        public QuizWindow()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            var q = QuizManager.Questions[currentIndex];
            QuestionText.Text = q.Text;
            OptionList.Items.Clear();
            foreach (var opt in q.Options)
                OptionList.Items.Add(opt);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (OptionList.SelectedIndex == -1) return;

            var q = QuizManager.Questions[currentIndex];
            if (OptionList.SelectedIndex == q.CorrectIndex)
            {
                FeedbackText.Text = "Correct! " + q.Explanation;
                score++;
            }
            else
            {
                FeedbackText.Text = "Incorrect. " + q.Explanation;
            }

            currentIndex++;
            if (currentIndex < QuizManager.Questions.Count)
            {
                LoadQuestion();
            }
            else
            {
                FeedbackText.Text = $"Quiz complete. Score: {score}/{QuizManager.Questions.Count}";
                ActivityLogger.Add($"Quiz completed. Score: {score}/{QuizManager.Questions.Count}");
                this.Close();
            }
        }
    }
}
