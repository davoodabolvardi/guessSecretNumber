namespace GuessNumber
{
    class Program
    {
        public static bool youWon = false;
        public enum StatusNumberEntered { isLessThan, isMoreThan, isEqual }

        static void MainAlaki(string[] args)
        {
            var services = new Services();
            
            var min = 1;
            var max = 10;
            var secretNumber = services.SystemRandomNumber(min, max);
            System.Console.WriteLine("Secret number is: {0}", secretNumber);

            do
            {
                services.SetForegroundColorToWhite();

                var userNumberEntered = services.GetNumberFromUser(min, max);

                var getStatusNumberEntered =
                    services.GetStatusNumberEntered(secretNumber, userNumberEntered);

                services.SwitchStatusNumberToPrint(getStatusNumberEntered);

                services.SetForegroundColorToWhite();

            } while (!youWon);

            services.CloseProgram();
        }
    }
}
