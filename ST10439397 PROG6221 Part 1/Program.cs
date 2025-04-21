using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ST10439397_PROG6221_Part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Greeting();
            AsciiArt();
            Console.ForegroundColor = ConsoleColor.Blue;
            TextDelay("“Hello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");

            //Error handling to check if the user enters thier name correctly and not leave it blank or add anything that isn't apart of the alphabet.
            try
            {
                Console.Write("Please enter your name: ");
                string Username = Console.ReadLine();

                // Validate the username input to ensure it contains only letters and is not empty.
                while (string.IsNullOrWhiteSpace(Username) ||
                       !System.Text.RegularExpressions.Regex.IsMatch(Username, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Invalid input. Name must contain only letters and not be empty.");
                    Console.Write("Please enter your name: ");
                    Username = Console.ReadLine();
                }

                Console.WriteLine($"Welcome, {Username}! Let's talk about cybersecurity.");
                Console.WriteLine("---------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }

            //Method of ways to reply to user inputs.
            Replies();
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that allows for text delay for the program.

        static void TextDelay(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that has the voice greetinng.
        public static void Greeting()
        {

            SoundPlayer player = new SoundPlayer("Greeting.wav");
            player.Play();

        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that has the Art that'll be displayed.
        static void AsciiArt()
        {

        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that asks what the user would like to answered.

        static void Replies()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Questions you may ask aligning with information that I contain: ");
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
                        Console.WriteLine("Sorry I'm not programmed to have emotions or opinions,\n" +
                            " but i do know how speak like Wally from WALL-E, if you'd like.");
                        Console.WriteLine("---------------------------------------------------------");
                        Replies();
                        break;

                    case "What is your purpose?":

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("My purpose is to help you stay safe online by providing information and answering your questions about cybersecurity.");
                        Console.WriteLine("---------------------------------------------------------");
                        Replies();
                        break;

                    case "What can I ask you about?":

                        Info();
                        break;

                    case "exit":

                        Environment.Exit(0);
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
                        Console.WriteLine("---------------------------------------------------------");
                        Replies();
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
        public static void Info()
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
                    Replies();
                    break;

                case "phishing":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Phishing is a method used by cybercriminals to trick you into giving them your personal information.\n" +
                        "Be cautious of suspicious emails or messages.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies();
                    break;

                case "safe browsing":

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Safe browsing involves being cautious about the websites you visit and the information you share online.\n" +
                        "Always check for HTTPS in the URL.");
                    Console.WriteLine("---------------------------------------------------------");
                    Replies();
                    break;

                default:

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I’m not sure about that. Please ask me about password safety, phishing, or safe browsing.");
                    Console.WriteLine("---------------------------------------------------------");
                    Info();
                    break;
            }
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------