using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10439397_PROG6221_Part_1
{
    internal class UserQuestions
    {
        public static void Replies(string username)
        {
            //Randomiser for Array answers selection.
            Random random = new Random();

            //Arrays that hold the "How are you?" questions and answers. 
            string[] Howareyou = { "how are you?", "how are you" };
            string[] Howareyouanswers = new string[] { $"Sorry I'm not programmed with {username} or opinions, but I am functioning properly, thank you.", 
                                          $"These nutz {username}", 
                                          $"seven eleven {username}" };
            
            //^DOESNT WORK FIXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            string[] Whatisyourpupose = { "", "", ""};
            string[] Whatisyourpuposeanswers = { "", "", ""};

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("These are the questions you may ask me " + username + ": ");
            Console.WriteLine("How are you?");
            Console.WriteLine("What is your purpose?");
            Console.WriteLine("What can I ask you about?");
            Console.WriteLine("If you'd like to exit the application enter 'exit': ");
            Console.WriteLine("---------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string question = Console.ReadLine().ToLower();

            //Switch statement to check the user's input and provide a response.
            switch (question)
            {
                case string q when Howareyou.Contains(q): // Fix for CS8370 and CS0118
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int index = random.Next(Howareyouanswers.Length);
                    Console.WriteLine(Howareyouanswers[index]);
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;

                case "What is your purpose?":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("My purpose is to help you stay safe online by providing information and answering your questions about cybersecurity.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;

                case "What can I ask you about?":
                    Info(username);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;
            }
        }

        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //Method that contains the information to keep users safe on the internet.
        public static void Info(string username)
        {

            //Randomiser for Array answers selection.
            Random rand = new Random();
            string[] Line = { "---------------------------------------------------------" };

            //
            string[] Sentiment = { "worried", "curious", "frustrated"};
            

            //Array that holds the word connected to the questions the user might ask about.
            string[] questions = { "password safety", "phishing", "safe browsing", "two-factor", "malware", "firewall" };

            //Arrays that holds the information to keep users safe on the internet.
            string[] passwordsafety = { "Password safety is important. Use strong, unique passwords for each account and consider using a password manager.", };
            string[] phishing = { "Phishing is a method of obtaining personal information by impersonating a business or people of importance.", };
            string[] safeBrowsing = { "Safe browsing involves being cautious about the websites you visit and the information you share online.\n Always check for HTTPS in the URL.", };
            string[] twoFactor = { "Two-factor authentication (2FA) adds an extra layer of security by requiring something you know (password) and something you have (like your phone).", };
            string[] malware = { "Malware is malicious software like viruses, spyware, or ransomware. Keep your antivirus updated to stay protected.", };
            string[] firewall = { "A firewall helps block unauthorized access to your computer or network. It's your digital security guard.", };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You may ask me about information related to password safety, phishing, safe browsing, two-factor, malware and firewall.");
            Console.WriteLine("Please enter your question: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();

            switch (input)
            {
                case "password safety":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    passwordsafety;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                case "phishing":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    phishing;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                case "safe browsing":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    safeBrowsing;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                case "two-factor":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    twoFactor;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                case "malware":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    malware;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                case "firewall":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    firewall;
                    Console.WriteLine(Line);
                    Replies(username);
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I’m not sure about that. Please ask me about password safety, phishing, safe browsing, two-factor, malware and firewall.");
                    Console.WriteLine(Line);
                    Info(username);
                    break;
            }
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------