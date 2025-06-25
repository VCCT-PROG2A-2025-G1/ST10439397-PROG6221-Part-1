using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberChatbotGUI.Logic
{
    internal class NLPProcessor
    {

        public static string Process(string input)
        {
            if (input.Contains("quiz"))
            {
                QuizWindow quiz = new QuizWindow();
                quiz.ShowDialog();
                return "Quiz finished.";
            }
            if (input.Contains("add task") || input.Contains("remind me"))
            {
                TaskWindow taskWindow = new TaskWindow();
                taskWindow.ShowDialog();
            }
            if (input.Contains("show activity log") || input.Contains("what have you done"))
            {
                return string.Join("\n", ActivityLogger.GetLog());
            }
            return UserQuestions.GetResponse(input, "User");
        }
    }

    public static class TaskManager
    {
        public static List<TaskItem> Tasks = new List<TaskItem>();

        public static string AddTaskFromInput(string input)
        {
            string title = input; // basic placeholder logic
            Tasks.Add(new TaskItem { Title = title, Description = "Cybersecurity Task", ReminderDate = DateTime.Now.AddDays(3) });
            ActivityLogger.Add($"Task added: '{title}' with reminder in 3 days.");
            return $"Task added: '{title}'. Reminder set for 3 days from now.";
        }

        public static string ViewTasks()
        {
            if (Tasks.Count == 0) return "No tasks available.";
            return string.Join("\n", Tasks.Select(t => $"{t.Title} - {(t.ReminderDate.HasValue ? $"Reminder: {t.ReminderDate}" : "No reminder")}"));
        }
    }

    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool Completed { get; set; }
    }

    public static class QuizManager
    {
        public static List<Question> Questions = new List<Question>
        {
            new Question("What should you do if you get a phishing email?", new[] {"Reply", "Report it", "Click the link", "Ignore it"}, 1, "Reporting phishing helps stop scams."),
            new Question("True or False: You should reuse passwords.", new[] {"True", "False"}, 1, "Use unique passwords for each account."),
            // Add 8 more...
        };

        public static void StartQuiz()
        {
            int score = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"{i + 1}. {q.Text}");
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
            ActivityLogger.Add($"Quiz completed. Score: {score}/{Questions.Count}");
        }
    }

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
