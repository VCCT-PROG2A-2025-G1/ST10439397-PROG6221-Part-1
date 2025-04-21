using System;
using System.Collections.Generic;
using System.Linq;
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

        static void TextDelay(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50); // Adjust the delay as needed
            }
            Console.WriteLine();
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------

        static void Greeting()
        {
            
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------

        static void AsciiArt()
        { 
        
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------

        static void Replies()
        {
            
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------