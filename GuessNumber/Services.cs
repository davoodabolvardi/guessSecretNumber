using System;
using static GuessNumber.Program;

namespace GuessNumber
{
    public class Services
    {
        // Game Logics
        private readonly Random _random = new Random();

        public int SystemRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public int GetStatusNumberEntered(int systemNumber, int userNumberEntered)
        {
            if (systemNumber < userNumberEntered)
                return (int)StatusNumberEntered.isLessThan;

            if (systemNumber > userNumberEntered)
                return (int)StatusNumberEntered.isMoreThan;

            return (int)StatusNumberEntered.isEqual;
        }

        public void SwitchStatusNumberToPrint(int statusNumberEntered)
        {
            switch (statusNumberEntered)
            {
                case (int)StatusNumberEntered.isLessThan:
                    PrintStatusNumberEntered((int)StatusNumberEntered.isLessThan);
                    break;

                case (int)StatusNumberEntered.isMoreThan:
                    PrintStatusNumberEntered((int)StatusNumberEntered.isMoreThan);
                    break;

                default:
                    PrintStatusNumberEntered((int)StatusNumberEntered.isEqual);
                    youWon = true;
                    break;
            }
        }


        // IO Operations
        public int GetNumberFromUser(int min, int max)
        {
            Console.WriteLine("=====================GuessNumber========================");
            Console.WriteLine($"Please guess a number and enter between " +
                    $"{min} and {max} and press Enter");

            var numberEntered = Console.ReadLine();

            while(!Int32.TryParse(numberEntered, out int value))
            {
                Console.WriteLine("Not a valid number, try again.");
                numberEntered = Console.ReadLine();
            }

            return Convert.ToInt32(numberEntered);
        }

        private void PrintStatusNumberEntered(int status)
        {
            if (status == (int)StatusNumberEntered.isLessThan)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The system number is more than the number entered");
            }
            if (status == (int)StatusNumberEntered.isMoreThan)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The system number is less than the number entered");
            }
            if (status == (int)StatusNumberEntered.isEqual)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations, you won," +
                    " the number entered is equal to the system number");
            }
        }

        public void SetForegroundColorToWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void CloseProgram()
        {
            SetForegroundColorToWhite();
            Console.WriteLine("========================You Won=========================");
            Console.WriteLine("To exit press any key...");
            Console.ReadKey();
        }
    }
}
