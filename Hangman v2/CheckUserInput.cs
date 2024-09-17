using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_v2
{
    public class CheckUserInput
    {
        public bool BasicChecks(string userInput)
        {
            {
                userInput = userInput.Trim();
                if (userInput == null)
                {
                    return false;
                }
                else
                    if (userInput == "")
                {
                    return false;
                }
                else
                    return true;
            }
        }
    }
    public class CheckIfEnteredLetters : CheckUserInput
    {
        public bool CheckLetters(char userInput)
        {
            char LetterIinAscii = char.ToLower(userInput);
            if ((int)LetterIinAscii > 96 && (int)LetterIinAscii < 123)
            {
                return true;
            }
            return false;
        }

    }
}
