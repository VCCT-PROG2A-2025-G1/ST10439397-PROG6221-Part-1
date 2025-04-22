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
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thesee are the questions you may ask me " + username + ": ");
                Console.WriteLine("How are you?");
                Console.WriteLine("What is your purpose?");
                Console.WriteLine("What can I ask you about?");
                Console.WriteLine("If you'd like to exit the application enter 'exit': ");
                Console.WriteLine("---------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                string question = Console.ReadLine();


                //Switch statement to check the user's input and provide a response.
                switch (question)
                {
                    case "How are you?":

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Sorry I'm not programmed with emotions or opinions, but I am functionally properly, thank you.");
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that contains the information to keep  users safe on the internet.
        public static void Info(string username)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You may ask me about information related to password safety, phishing, and safe browsing");
            Console.WriteLine("Please enter your question: ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine();

            switch (input)
            {
                case "password safety":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Password safety is important. Use strong, unique passwords for each account and consider using a password manager.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;

                case "phishing":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Phishing is a method of obtaining personal information by impersonating a business or people of importance.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;

                case "safe browsing":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Safe browsing involves being cautious about the websites you visit and the information you share online.\n" +
                        "Always check for HTTPS in the URL.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies(username);
                    break;

                default:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I’m not sure about that. Please ask me about password safety, phishing, or safe browsing.");
                    Console.WriteLine("---------------------------------------------------------");
                    Info(username);
                    break;
            }
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------