// Jordan Small
// ST10439397
// GR01
// Part 1 YT LINK:
// https://youtu.be/njBOQSc4Ucg
// Part 2 YT LINK:
//
//
//Reference:
//OpenAI. (2023). ChatGPT (Mar 14 version) [Large language model]. https://chat.openai.com/
//=========================================================================

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
        private static string[] messages;

        public static void Main(string[] args)
        {

            VoiceGreeting.Greeting();
            ASCII.AsciiArt();
            Console.ForegroundColor = ConsoleColor.Blue;
            //Only time a text delay will be implemented so that the user can get there questions answered immediately.
            TextDelay("“Hello! Welcome to the Cybersecurity Awareness Bot. I’m here to help you stay safe online.");

            //Error handling to check if the user enters their name correctly and not leave it blank or add anything that isn't apart of the alphabet.
            try
            {
                Console.Write("Please enter your name: ");
                string username = Console.ReadLine();

                // Validate the username input to ensure it contains only letters and is not empty.
                while (string.IsNullOrWhiteSpace(username) ||
                       !System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Invalid input. Name must contain only letters and not be empty.");
                    Console.Write("Please enter your name: ");
                    username = Console.ReadLine();
                }

                Console.WriteLine($"Welcome, " + username + " ! Let's talk about cybersecurity.");
                Console.WriteLine("---------------------------------------------------------");

                //Method of ways to reply to user inputs.
                UserQuestions.Replies(username, messages);
            }
            catch
            {
                Console.WriteLine($"An error occurred: Please follow the instructions provided below.");
                return;
            }
        }
//------------------------------------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------------
//Method that allows for text delay for the program.

        static void TextDelay(string text)
        {
            foreach (char c in text)
            {
                //Prints each character.
                Console.Write(c);
                //Delays the text by 50 milliseconds.
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine();
        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------