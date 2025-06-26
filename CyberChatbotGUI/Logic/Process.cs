using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CyberChatbotGUI.Logic
{
    internal class Processes
    {
//--------------------------------------------------------------------------------
// Main processing method for user input
        public static string Process(string input)
        {
            if (input.Contains("quiz"))
            {
                QuizWindow quiz = new QuizWindow();
                quiz.ShowDialog();
                return "Quiz finished.";
            }
            if (input.Contains("add task") || input.Contains("remind me") || input.Contains("show tasks"))
            {
                TaskWindow taskWindow = new TaskWindow();
                taskWindow.ShowDialog();
                return "Task management window closed.";
            }
            if (input.Contains("show activity log") || input.Contains("what have you done") || input.Contains(" show logs") || input.Contains("logs"))
            {
                return string.Join("\n", ActivityLogger.GetLog());
            }
            if (input.Contains("exit"))
            {
                Environment.Exit(0);
            }
            return UserQuestions.GetResponse(input, "User");
        }
    }

//--------------------------------------------------------------------------------
//Getters and Setters for TaskItems
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool Completed { get; set; }
    }

//--------------------------------------------------------------------------------
//Quiz Management Method
    public static class QuizManager
    {
        public static List<Question> Questions = new List<Question>
        {
            new Question("What should you do if you get a phishing email?", new[] {"Reply", "Report it", "Click the link", "Ignore it"}, 1, "Reporting phishing helps stop scams."),
            new Question("True or False: You should reuse passwords.", new[] {"True", "False"}, 1, "Use unique passwords for each account."),
            new Question("What is two-factor authentication?", new[] {"A second password", "A security feature", "A type of encryption", "A phishing technique"}, 1, "Two-factor authentication adds an extra layer of security."),
            new Question("What is the purpose of a firewall?", new[] {"To block malware", "To speed up internet", "To filter spam", "To encrypt data"}, 0, "A firewall helps protect your network from unauthorized access."),
            new Question("What is social engineering?", new[] {"A type of malware", "Manipulating people", "A network protocol", "A programming language"}, 1, "Social engineering involves tricking people into giving up sensitive information."),
            new Question("What is a strong password?", new[] {"123456", "password", "A mix of letters, numbers, and symbols", "Your name"}, 2, "A strong password is complex and hard to guess."),
            new Question("True or False: .", new[] {"True", "False"}, 1, "."),
            new Question("True or False: You should reuse passwords.", new[] {"True", "False"}, 1, "Use unique passwords for each account."),
            new Question("True or False: You should reuse passwords.", new[] {"True", "False"}, 1, "Use unique passwords for each account."),
            new Question("True or False: You should reuse passwords.", new[] {"True", "False"}, 1, "Use unique passwords for each account."),
        };

        public static void StartQuiz()
        {
            int score = 0;

            //Loop through each question.
            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                
                Console.WriteLine($"{i + 1}. {q.Text}");

                //Loop through each option for the question that allows for answer selection.
                for (int j = 0; j < q.Options.Length; j++)
                
                    Console.WriteLine($"{(char)(65 + j)}) {q.Options[j]}");
                
                string answer = Console.ReadLine()?.ToUpper();
                
                if ((answer?[0] - 'A') == q.CorrectIndex)
                {
                    Console.WriteLine("Correct! " + q.Explanation);
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect. " + q.Explanation);
                }
            }

            //Output final score and log the activity.
            Console.WriteLine($"Quiz completed. Score: {score}/{Questions.Count}");
            ActivityLogger.Add($"Quiz completed. Score: {score}/{Questions.Count}");
        }
    }

//--------------------------------------------------------------------------------
//Question Class for Quiz
    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Explanation { get; set; }

        public Question(string text, string[] options, int correctIndex, string explanation)
        {
            Text = text;
            Options = options;
            CorrectIndex = correctIndex;
            Explanation = explanation;
        }
    }

//--------------------------------------------------------------------------------
//Activity Recorder Method
    public static class ActivityLogger
    {
        private static readonly Queue<string> log = new Queue<string>();

        public static void Add(string action)
        {
            if (log.Count >= 10) log.Dequeue();
            log.Enqueue(action);
        }

        public static List<string> GetLog()
        {
            return new List<string>(log);
        }
    }

//--------------------------------------------------------------------------------
//Part 2 integration to the WPF
    public static class UserQuestions
    {
        public static string GetResponse(string input, string userName)
        {
            var responses = new Dictionary<string[], string[]>
            {
                [new[] { "how are you", "how do you feel" }] = new[]
                {
                    $"I'm functioning optimally, thanks for asking, {userName}!",
                    $"All systems are green, {userName}."
                },
                [new[] { "password", "passwords" }] = new[]
                {
                    $"Use strong, unique passwords, {userName}.",
                    $"Enable two-factor authentication, {userName}."
                },
                [new[] { "phishing", "email scam" }] = new[]
                {
                    $"Phishing emails trick users — don't click unknown links, {userName}."
                }
            };

            foreach (var pair in responses)
            {
                if (pair.Key.Any(k => input.Contains(k)))
                {
                    return pair.Value[new Random().Next(pair.Value.Length)];
                }
            }

            return "I'm not sure I understand. Could you rephrase that?";
        }
    }
}
//=====================================0000000000END OF FILE========================================