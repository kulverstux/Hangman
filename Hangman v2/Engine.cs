namespace Hangman_v2
{
    internal class Engine
    {
        Init start = new();
        bool choosingTopic = true;
        string userInput = "";
        int attempts = 0;
        bool gameOn = true;
       
        public void ChooseTopic()
        {
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
                            WordSelector wordSelector = new();
                            wordSelector.WordSelected(userInput);
                            choosingTopic = false;
                            break;
                        }
                    default:
                        break;
                }
            }
            Console.Clear();
        }
        public void GameLogic()
        {
            while (gameOn)
            {
                GameScreenLayout();

                Console.WriteLine("Guess a letter:");
                userInput = Console.ReadLine();

                Console.Clear();
                if (CheckUserInput.BasicChecks(userInput))
                {
                    if (userInput.Length > 1)
                    {
                        if (!(userInput.Length > WordSelector.ChosenWord.Length))
                        {
                            if (!start.checkGuess.CheckIfItsTheSameWord(userInput.ToLower()))
                            {
                                if (userInput.ToLower() == WordSelector.ChosenWord.ToLower())
                                {
                                    GameWin();
                                    gameOn = false;
                                }
                                else
                                {
                                    Console.WriteLine("Your guess was incorrect.");
                                    attempts++;
                                    if (attempts == GameParameters.MaxAttempts)
                                    {
                                        GameOver();
                                        gameOn = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"You guessed that word already..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Word you entered has more symbols than the word you trying to guess");
                        }
                    }
                    else
                    {
                        char userInputChar = char.ToLower(char.Parse(userInput));
                        if (start.checkIfEnteredLetters.CheckLetters(userInputChar))
                        {
                            if (!start.checkGuess.CheckIfItsTheSameLetter(userInputChar))
                            {
                                if (start.checkGuess.GuessChecking(char.ToLower(userInput[0]), WordSelector.ChosenWord))
                                {
                                    Console.WriteLine($"Your guess '{userInputChar}' was correct!\n");
                                    if (!GameParameters.WordInDashes.Contains('_'))
                                    {
                                        GameWin();
                                        gameOn = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Sorry, there is no '{userInputChar}' letter in this word..\n");
                                    attempts++;

                                    if (attempts == GameParameters.MaxAttempts)
                                    {
                                        GameOver();
                                        gameOn = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"You guessed '{userInput}' letter already. \n");
                            }
                        }
                        else Console.WriteLine($"Let's be real, {userInput} is not a letter.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Your entry is invalid.");
                }
            }
        }
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine($"Sorry, you've lost...");
            PrintOuts.HangmanDrawing(GameParameters.MaxAttempts);

        }
        public void GameWin()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You Won!!");
            Console.WriteLine($"Correct word - {WordSelector.ChosenWord}");
        }
        public void GameController()
        {
            if (GameParameters.UserSuccessfullyLoggedIn)
            {
                ChooseTopic();
                GameLogic();
            }
            else
            {
                if (GameParameters.PlayAsAGuest)
                {
                    ChooseTopic();
                    GameLogic();
                }
                else
                {
                    LoginScreenSelection();
                }
            }

        }
        public void GameScreenLayout()
        {
            Console.WriteLine($"Topic selected: {GameParameters.Theme}\n");// answer: {WordSelector.ChosenWord};
            PrintOuts.PrintLettersGuessed();
            PrintOuts.PrintWordsGuessed();
            Console.WriteLine();
            PrintOuts.HangmanDrawing(attempts);
            Console.WriteLine();
            start.printOuts.PrintWordInDashes();
            Console.WriteLine("\n");
        }
        public void LoginScreenSelection()
        {
            bool notGood = true;
            while (notGood)
            {
                PrintOuts.HangmanLogo();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create a new account");
                Console.WriteLine("3. Play as a guest");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                    {
                        LogInExistingUser logInExistingUser = new();
                        logInExistingUser.LoginUserScreen();
                        notGood = false;
                        break;
                    }
                    case "2":
                    {
                        NewUserAccount useracc = new();
                        useracc.NewUser();
                        notGood = false;
                        break;
                    }
                    case "3":
                    {
                        GameParameters.UserSuccessfullyLoggedIn = false;
                        GameParameters.PlayAsAGuest = true;
                        notGood = false;
                        GameController();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }
    }
}
