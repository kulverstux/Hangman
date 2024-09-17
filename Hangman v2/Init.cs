using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_v2
{
    public class Init
    {
        //public static GameParameters gameParameters = new GameParameters();
        public WordSelector wordSelector = new();
        public PrintOuts printOuts = new();
        public CheckIfEnteredLetters checkIfEnteredLetters = new();
        public CheckGuess checkGuess = new();
    }
}
