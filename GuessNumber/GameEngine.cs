using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    public class GameEngine
    {
        private readonly Random _random = new Random();
        private int _secretNumber;

        public void GenerateSecretNumber(int min, int max)
        {
            _secretNumber = _random.Next(min, max);
        }

        public GuessResult CheckGuessNumber(int guessNumber)
        {
            if (guessNumber < _secretNumber)
                return GuessResult.Less;
            else if (guessNumber > _secretNumber)
                return GuessResult.Greater;
            else
                return GuessResult.Equal;
        }
    }
}
