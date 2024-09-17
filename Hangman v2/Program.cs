namespace Hangman_v2
{
    internal class Program
    {
           static void Main(string[] args)
        {
            Init start = new();

            bool choosingTopic = true;
            string userInput = "";
            string wordSelected = "";

            

            while (choosingTopic)
            {
                start.printOuts.PrintMainMenu();

                Console.WriteLine("Choose topic:");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    case "2":
                    case "3":
                        {
                            wordSelected = start.wordSelector.SelectWord(int.Parse(userInput));
                            start.wordSelector.SetUpWordInDashes();
                            choosingTopic = false;
                            break;
                        }
                    default:
                            break;
                }
            }
            Console.Clear();
            Console.WriteLine($"{wordSelected}");
            
            bool gameOn = true;
            while (gameOn)
            {
                Console.WriteLine($"Topic selected: {GameParameters.Theme}");
                Console.WriteLine();
                start.printOuts.PrintWordInDashes();           
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Guess a letter:");
                userInput = Console.ReadLine();
                Console.Clear();
                if (userInput.Length > 1)
                {

                }
                else
                {
                    char userInputChar = char.ToLower(char.Parse(userInput));
                    if (start.checkIfEnteredLetters.CheckLetters(userInputChar))
                    {
                        if (!start.checkGuess.CheckIfItsTheSameLetter(userInputChar))
                        {
                            if (start.checkGuess.GuessChecking(userInput[0], wordSelected))
                            {
                                Console.WriteLine($"Your guess '{userInputChar}' was correct!\n");
                            }
                            else
                            {
                                Console.WriteLine($"Sorry, there is no '{userInputChar}' letter in this word..\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"You guessed '{userInput}' letter already \n");
                        }
                    }
                    else Console.WriteLine($"Let's be real, {userInput} is not a letter.\n");
                }
            }
        }
    }
}

