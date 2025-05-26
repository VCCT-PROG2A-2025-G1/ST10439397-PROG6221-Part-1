using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10439397_PROG6221_Part_1
{
    internal class UserQuestions
    {
        static string[] keywords = new string[] { "password", "scam", "privacy" };
        static string[] Sentiment = new string[] { "worried", "curious", "frustrated" };
        static string[] sentimentResponses = {
                "It's completely understandable to feel that way. Let me help you stay safe.",
                "Curiosity is a great trait! Let's explore that topic.",
                "Frustration is normal. Let's sort this out together."
                };
        static string[] message = {
                    "Use a password manager to generate and store secure passwords.",
                    "Scams often look official. Never click on suspicious links or attachments.",
                    "Keep your software updated and avoid oversharing personal info online."
                }; 
        static string Line = "---------------------------------------------------------";

        public static void Replies(string username, string[] messages)
        {
            //Randomiser for Array answers selection.
            Random random = new Random();

            //Arrays that hold questions and answers. 
            string[] Howareyou = new string[] { "how are you?", "how are you" };
            string[] Howareyouanswers = new string[] { "Sorry I'm not programmed with or opinions, but I am functioning properly, thank you.", "gg", "seven eleven" };

            string[] Whatisyourpupose = new string[] { "what is your purpose", "what is your purpose?", "purpose" };
            string[] Whatisyourpuposeanswers = new string[] { "My purpose is to help you stay safe online by providing information and answering your questions about cybersecurity.", "dwa ", "dwae" };

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
            Console.ResetColor();

            string detectedSentiment = Sentiment.FirstOrDefault(s => question.Contains(s));
            string detectedKeyword = keywords.FirstOrDefault(k => question.Contains(k));

            if (detectedSentiment != null && detectedKeyword != null)
            {
                int sentimentIndex = Array.IndexOf(Sentiment, detectedSentiment);
                int keywordIndex = Array.IndexOf(keywords, detectedKeyword);

                if (sentimentIndex >= 0 && keywordIndex >= 0 && keywordIndex < messages.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(sentimentResponses[sentimentIndex]);
                    Console.WriteLine($"It seems you're concerned about {detectedKeyword}. Here's some advice:");
                    Console.WriteLine(message[keywordIndex]);
                    Console.WriteLine(Line);
                }
                else
                {
                    Console.WriteLine("Error: Sentiment or keyword index is out of bounds.");
                }

                Replies(username, messages); // loop back
                return;
            }
            else if (Howareyou.Any(q => question.Contains(q)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Howareyouanswers[random.Next(Howareyouanswers.Length)]);
            }
            else if (Whatisyourpupose.Any(q => question.Contains(q)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Whatisyourpuposeanswers[random.Next(Whatisyourpuposeanswers.Length)]);
            }
            else if (WhatcanIaskyouabout.Any(q => question.Contains(q)))
            {
                Info(username, messages);
                return;
            }
            else if (question.Contains("exit"))
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
            }

            Console.WriteLine(Line);
            Replies(username, messages);
        }

        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //Method that contains the information to keep users safe on the internet.
        public static void Info(string username, string[] messages)
        {

            //Randomiser for Dictionary answers selection.
            Random random = new Random();

            var tips = new Dictionary<string, string[]>
            {
                ["password safety"] = new[] { "Make your passwords at least 12 characters long, combining uppercase, lowercase, numbers, and special symbols.",
                                          "Don’t use your name, birthdate, or common phrases they’re easy to guess or crack.",
                                          "If one account is compromised, using unique passwords prevents attackers from accessing others.",
                                          "Add an extra layer of security by requiring a second form of verification like a text or app code.",
                                          "Tools like Bitwarden or LastPass help you generate and store strong, unique passwords securely.",
                                          "Rotate your passwords every few months, especially for sensitive accounts like email and banking.",
                                          "Never share your passwords with others even trusted friends. Use secure sharing tools if absolutely necessary."},
                ["phishing"] = new[] { "If you get an unexpected message asking for personal info or urgent action pause and verify before clicking anything.",
                                    "On a computer, hover your mouse over a link to preview the URL. Phishing links often look legitimate but lead to fake sites.",
                                    "Phishers often spoof email addresses. Look closely at email adresses for small changes and see if they match the orriginal that's related to them.",
                                    "Avoid opening attachments from unknown or untrusted sources they may contain malware or ransomware.",
                                    "Most email clients and browsers have built-in phishing protection make sure it's enabled.",
                                    "Messages saying things like “Your account will be closed!” or “Act now!” are trying to make you panic. Stay calm and verify the source.",
                                    "Always check the URL before logging into any account phishing pages can look identical to real login pages."},
                ["safe browsing"] = new[] { "Always use the latest version of your browser and keep your operating system updated to patch security vulnerabilities.",
                                        "Only enter personal information on websites with HTTPS in the URL this means the site is encrypted and more secure.",
                                        "Don't click on unknown or shortened links, especially from untrusted sources or pop-up ads.",
                                        "Regularly clear your browsing data to remove trackers and stored credentials.",
                                        "When using public computers or accessing sensitive accounts, use incognito mode to avoid leaving traces.",
                                        "Enable real-time protection and consider browser add-ons like ad blockers or anti-tracking tools.",
                                        "Only download files and apps from trusted, verified websites to avoid malware."},
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You may ask me about information related to password safety, phishing and safe browsing\n or just go back with 'back' or type 'exit' to exit.");
            Console.WriteLine("Please enter your question: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine().ToLower();


            if (input.Contains("exit"))
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
            else if (input.Contains("back"))
            {
                Replies(username, messages);
                return;
            }

            //Try to match one of the known keys
            foreach (var key in tips.Keys)
            {
                if (input.Contains(key))
                {
                    ShowTip(username, tips[key], key, random);
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I’m not sure about that. Please ask me about internet safety topics.");
            Info(username, messages);
        }

        //------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------
        //Method that contains the information to keep users safe on the internet.
        public static void ShowTip(string username, string[] messages, string topic, Random random)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int index = random.Next(messages.Length);
            Console.WriteLine(messages[index]);
            Console.WriteLine("Would you like another tip?");
            string question = Console.ReadLine().ToLower();

            if (question == "yes")
            {
                index = random.Next(messages.Length);
                Console.WriteLine(messages[index]);
                Replies(username, messages);
            }
            else
            {
                Info(username, messages);
            }
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------