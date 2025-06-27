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
        private string[] keywords = new[] { "password", "scam", "privacy" };
        private string[] Sentiment = new[] { "worried", "curious", "frustrated" };

        private string[] sentimentResponses =
        {
                "It's completely understandable to feel that way. Let me help you stay safe.",
                "Curiosity is a great mindset! Let's explore that topic.",
                "Frustration is normal. Let's sort this out together."
            };

        private string[] message =
        {
                "Use a password manager to generate and store secure passwords.",
                "Scams often look official. Never click on suspicious links or attachments.",
                "Keep your software updated and avoid oversharing personal info online."
            };
//--------------------------------------------------------------------------------
// Main processing method for user input
        public static string Process(string input)
        {
            // Create an instance of Processes to access non-static fields
            Processes instance = new Processes();

            string detectedSentiment = instance.Sentiment.FirstOrDefault(s => input.Contains(s));
            string detectedKeyword = instance.keywords.FirstOrDefault(k => input.Contains(k));

            // Do a quiz.
            if (input.Contains("quiz"))
            {
                QuizWindow quiz = new QuizWindow();
                quiz.ShowDialog();
                return "Quiz finished.";
            }

            // Check for task management requests.
            if (input.Contains("add task") || input.Contains("remind me") || input.Contains("show tasks"))
            {
                TaskWindow taskWindow = new TaskWindow();
                taskWindow.ShowDialog();
                return "Task management window closed.";
            }

            // Check for activity log requests.
            if (input.Contains("show activity log") || input.Contains("what have you done") || input.Contains("show logs") || input.Contains("logs"))
            {
                return string.Join("\n", ActivityLogger.GetLog());
            }

            //Sentiment and keyword detection.
            if (detectedSentiment != null && detectedKeyword != null)
            {
                int sentimentIndex = Array.IndexOf(instance.Sentiment, detectedSentiment);
                int keywordIndex = Array.IndexOf(instance.keywords, detectedKeyword);

                if (sentimentIndex >= 0 && keywordIndex < instance.message.Length)
                {
                    return instance.sentimentResponses[sentimentIndex] + $"\nOn the topic of {detectedKeyword}, here's some advice: {instance.message[keywordIndex]}";
                }
                else
                {
                    return "Hmm, something went wrong detecting your sentiment or keyword.";
                }
            }

            //Quit.
            if (input.Contains("exit") || input.Contains("quit"))
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
            new Question("True or False: Public Wi-Fi is always safe to use without protection.", new[] { "True", "False" }, 1, "Public Wi-Fi can be insecure. Always use a VPN when accessing sensitive information."),
            new Question("True or False: Hovering over a link can help you see if it's suspicious.", new[] { "True", "False" }, 0, "Yes! Always check the actual URL before clicking."),
            new Question("What is two-factor authentication?", new[] {"A second password", "A security feature", "A type of encryption", "A phishing technique"}, 1, "Two-factor authentication adds an extra layer of security."),
            new Question("True or False: Antivirus software should be updated regularly.", new[] { "True", "False" }, 0, "Keeping antivirus software up to date helps protect against the latest threats."),
            new Question("What is the purpose of a firewall?", new[] {"To block malware", "To speed up internet", "To filter spam", "To encrypt data"}, 0, "A firewall helps protect your network from unauthorized access."),
            new Question("What is social engineering?", new[] {"A type of malware", "Manipulating people", "A network protocol", "A programming language"}, 1, "Social engineering involves tricking people into giving up sensitive information."),
            new Question("True or False: It's safe to share your passwords with trusted friends.", new[] { "True", "False" }, 1, "You should never share your passwords — even with people you trust."),
            new Question("What is a strong password?", new[] {"123456", "password", "A mix of letters, numbers, and symbols", "Your name"}, 2, "A strong password is complex and hard to guess.")
            
        };
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
                    $"I'm functioning optimally, thanks for asking!",
                    $"All systems are green."
                },
                [new[] { "password", "passwords" }] = new[]
                {
                    $"Make your passwords at least 12 characters long, combining uppercase, lowercase, numbers, and special symbols.",
                    $"Don’t use your name, birthdate, or common phrases they’re easy to guess or crack.",
                    $"If one account is compromised, using unique passwords prevents attackers from accessing others.",
                    $"Add an extra layer of security by requiring a second form of verification like a text or app code.",
                },
                [new[] { "phishing", "email scam" }] = new[]
                {
                    $"If you get an unexpected message asking for personal info or urgent action pause and verify before clicking anything.",
                    $"On a computer, hover your mouse over a link to preview the URL. Phishing links often look legitimate but lead to fake sites.",
                    $"Phishers often spoof email addresses. Look closely at email adresses for small changes and see if they match the orriginal that's related to them.",
                    $"Avoid opening attachments from unknown or untrusted sources they may contain malware or ransomware.",
                },
                [new[] { "safe browsing" }] = new[]
                {   
                     $"Always use the latest version of your browser and keep your operating system updated to patch security vulnerabilities.",
                     $"Only enter personal information on websites with HTTPS in the URL this means the site is encrypted and more secure.",
                     $"Don't click on unknown or shortened links, especially from untrusted sources or pop-up ads.",
                     $"Regularly clear your browsing data to remove trackers and stored credentials."
                }
            };

            foreach (var p in responses)
            {
                if (p.Key.Any(k => input.Contains(k)))
                {
                    return p.Value[new Random().Next(p.Value.Length)];
                }
            }

            return "I'm not sure I understand. Could you rephrase that?";
        }
    }
}
//=====================================0000000000END OF FILE========================================