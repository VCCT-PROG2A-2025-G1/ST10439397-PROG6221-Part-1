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

            VoiceGreeting.Greeting();
            ASCII.AsciiArt();
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
            UserQuestions.Replies();
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
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------