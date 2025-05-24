using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10439397_PROG6221_Part_1
{
    internal class UserQuestions
    {
        static string[] keywords = new string[] { "password", "scam", "privacy" };
        static string[] Sentiment = new string[] { "worried", "curious", "frustrated" };
        static string[] sen = new string[] { "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe.", "Curiosity is a great trait! How can I assist you today?", "Frustration is understandable. Let me help you with that." };
        static string Line = "---------------------------------------------------------";

        public static void Replies(string username)
        {
            //Randomiser for Array answers selection.
            Random random = new Random();

            //Arrays that hold the "How are you?" questions and answers. 
            string[] Howareyou = new string[] { "how are you?", "how are you" };
            string[] Howareyouanswers = new string[] { "Sorry I'm not programmed with or opinions, but I am functioning properly, thank you.", "These nutz", "seven eleven" };
            
            string[] Whatisyourpupose = new string[] { "what is your purpose", "what is your purpose?", "purpose"};
            string[] Whatisyourpuposeanswers = new string[] { "My purpose is to help you stay safe online by providing information and answering your questions about cybersecurity.", "dwa ", "dwae"};

            string[] WhatcanIaskyouabout = new string[] { "what can I ask you about?", "what can I ask you about", "what can i ask" };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("These are the questions you may ask me " + username + ": ");
            Console.WriteLine("How are you?");
            Console.WriteLine("What is your purpose?");
            Console.WriteLine("What can I ask you about?");
            Console.WriteLine("If you'd like to exit the application enter 'exit': ");
            Console.WriteLine(Line);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string question = Console.ReadLine().ToLower();

            if (Howareyou.Any(question.Contains))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int index = random.Next(Howareyouanswers.Length);
                Console.WriteLine(Howareyouanswers[index]);
                Console.WriteLine(Line);
                Replies(username);
            }
            else if (Whatisyourpupose.Any(q => question.Contains(q)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int index2 = random.Next(Whatisyourpuposeanswers.Length);
                Console.WriteLine(Whatisyourpuposeanswers[index2]);
                Console.WriteLine(Line);
                Replies(username);
            }
            else if (WhatcanIaskyouabout.Any(q => question.Contains(q)))
            {
                Info(username);
            }
            else if (question.Contains("exit"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                Console.WriteLine(Line);
                Replies(username);
            }
        }

        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //Method that contains the information to keep users safe on the internet.
        public static void Info(string username)
        {

            //Randomiser for Array answers selection.
            Random random = new Random();

            //Array that holds the word connected to the questions the user might ask about.
            string[] questions = new string[] { "password safety", "phishing", "safe browsing", "two-factor", "malware", "firewall", "exit", "back"};

            //Arrays that holds the information to keep users safe on the internet.
            string[] passwordsafety = new string[] { $"Password safety is important. Use strong, unique passwords for each account and consider using a password manager.", "rg"};
            string[] phishing = new string[] { $"Phishing is a method of obtaining personal information by impersonating a business or people of importance.", "faf"};
            string[] safeBrowsing = new string[] { $"Safe browsing involves being cautious about the websites you visit and the information you share online.\n Always check for HTTPS in the URL.", "fa" };
            string[] twoFactor = new string[] { $"Two-factor authentication (2FA) adds an extra layer of security by requiring something you know (password) and something you have (like your phone).", "bfs" };
            string[] malware = new string[] { $"Malware is malicious software like viruses, spyware, or ransomware. Keep your antivirus updated to stay protected.", "jy" };
            string[] firewall = new string[] { $"A firewall helps block unauthorized access to your computer or network. It's your digital security guard.", "utk" };

            string yes = "yes";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You may ask me about information related to password safety, phishing, safe browsing, two-factor, malware and firewall\n" +
                              " or just go back with 'back' or type 'exit' to exit.");
            Console.WriteLine("Please enter your question: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine().ToLower();

            //questions is compared to the user input and if it contains any of the words in the array, it will return a random answer from the array.
            //PasswordSafety
            if (input.Contains("password safety"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index1 = random.Next(passwordsafety.Length);
                Console.WriteLine(passwordsafety[Index1]);
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index1 = random.Next(passwordsafety.Length);
                    Console.WriteLine(passwordsafety[Index1]);
                    Console.WriteLine(Line);
                    Replies(username);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Phishing
            else if (input.Contains("phishing"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index2 = random.Next(phishing.Length);
                Console.WriteLine(phishing[Index2]);
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index2 = random.Next(passwordsafety.Length);
                    Console.WriteLine(passwordsafety[Index2]);
                    Console.WriteLine(Line);
                    Replies(username);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Safe Browsing
            else if (input.Contains("safe browsing"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index3 = random.Next(safeBrowsing.Length);
                Console.WriteLine(safeBrowsing[Index3]);
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index3 = random.Next(passwordsafety.Length);
                    Console.WriteLine(passwordsafety[Index3]);
                    Console.WriteLine(Line);
                    Replies(username);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Two Factor
            else if (input.Contains("two factor"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index4 = random.Next(twoFactor.Length);
                Console.WriteLine(twoFactor[Index4]);
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index4 = random.Next(passwordsafety.Length);
                    Console.WriteLine(passwordsafety[Index4]);
                    Console.WriteLine(Line);
                    Replies(username);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Malware
            else if (input.Contains("malware"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index5 = random.Next(malware.Length);
                Console.WriteLine(malware[Index5]); ;
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index5 = random.Next(passwordsafety.Length);
                    Console.WriteLine(passwordsafety[Index5]);
                    Console.WriteLine(Line);
                    Replies(username);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Firewall
            else if (input.Contains("firewall"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int Index6 = random.Next(firewall.Length);
                Console.WriteLine(firewall[Index6]);
                Console.WriteLine(Line);
                Console.WriteLine("Would you like another tip?");
                string question = Console.ReadLine().ToLower();

                if (question == yes)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Index6 = random.Next(firewall.Length);
                    Console.WriteLine(firewall[Index6]);
                    Console.WriteLine(Line);
                }
                else
                {
                    Info(username);
                }

                Info(username);
            }
            //Back
            else if (input.Contains("back"))
            {
                Console.WriteLine(Line);
                Replies(username);
            }
            //Exit
            else if (input.Contains("exit"))
            {
                Console.WriteLine(Line);
                Environment.Exit(0);
            }
            //Error Handling
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("I’m not sure about that.");
                Console.WriteLine(Line);
                Info(username);
            }
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------