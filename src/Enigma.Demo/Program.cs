using System;

namespace Enigma.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                WriteColored("Welcome to Enigma Encryption\n\n", ConsoleColor.Green);
                WriteColored("Please enter your password: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                var pass = Console.ReadLine();
                WriteColored("Enter your input text: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                var plainText = Console.ReadLine();
                var enigma = new Enigma(pass?.Length ?? 3);

                var cipher = enigma.Encrypt(plainText, pass);
                WriteColored(cipher, ConsoleColor.DarkMagenta);

                Console.ReadLine();
            }
        }

        private static void WriteColored(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}