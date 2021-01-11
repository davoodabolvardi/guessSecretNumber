using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class ConsoleUserInterface
    {
        public void Initialize()
        {
            Console.WriteLine("============ Welcome to SecretNumberGame ===============");
        }

        public int ReadANumber()
        {
            Console.WriteLine("Please guess a number");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);
            return number;
        }

        public void WriteMessage(string message, string color)
        {
            const ConsoleColor DefaultForegroundColor = ConsoleColor.White;

            var previousColor = Console.ForegroundColor;
            var consoleColor = ColorNameToConsoleColor(color).
                               GetValueOrDefault(DefaultForegroundColor);

            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }

        private ConsoleColor? ColorNameToConsoleColor(string color)
        {
            switch (color.ToLower())
            {
                case "yellow":
                    return ConsoleColor.Yellow;
                case "red":
                    return ConsoleColor.Red;
                case "green":
                    return ConsoleColor.Green;
                default:
                    return null;
            }
        }

        public void Finished()
        {
            Console.WriteLine("to exit game press any key...");
            Console.ReadKey();
        }
    }
}
