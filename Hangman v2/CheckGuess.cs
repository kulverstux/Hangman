using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_v2
{
    public class CheckGuess
    {
       // private GameParameters gameParameters;
        //public CheckGuess(GameParameters gameParameters)
        //{
        //    this.gameParameters = gameParameters;
        //}
        public bool GuessChecking(char userInput, string wordSelected)
        {
            int indexCount = 0;
            bool guessWasCorrect = false;
            foreach (var item in wordSelected.ToLower())
            {
                if (item == userInput)
                {
                    GameParameters.WordInDashes[indexCount] = userInput;
                    guessWasCorrect = true;
                }
                indexCount++;
            }
            return guessWasCorrect;
        }
        public bool CheckIfItsTheSameLetter(char userInput)
        {
            if (!GameParameters.GuessedLetters.Contains(userInput))
            {
                GameParameters.GuessedLetters.Add(userInput);
                return false;
            }
            return true;
        }
    }
}
