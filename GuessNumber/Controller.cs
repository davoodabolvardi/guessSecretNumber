using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class Controller
    {
        public static void Main()
        {
            var engine = new GameEngine();
            var ui = new ConsoleUserInterface();

            var numberRange = new { Min = 1, Max = 10 };

            ui.Initialize();
            engine.GenerateSecretNumber(numberRange.Min, numberRange.Max);
            while(true)
            {
                var guessNumber = ui.ReadANumber();
                var guessResult = engine.CheckGuessNumber(guessNumber);
                if (guessResult == GuessResult.Equal)
                {
                    ui.WriteMessage("Your number is equal", "green");
                    break;
                }
                else if (guessResult == GuessResult.Greater)
                {
                    ui.WriteMessage("Your number is greater", "red");
                }
                else if (guessResult == GuessResult.Less)
                {
                    ui.WriteMessage("Your number is less", "yellow");
                }
            }
            ui.Finished();
        }
    }
}
