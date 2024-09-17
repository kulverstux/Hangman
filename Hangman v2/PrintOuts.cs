namespace Hangman_v2
{
    public class PrintOuts
    {
      //  GameParameters gameParameters;
        //public PrintOuts(GameParameters gameParameters)
        //{
        //    this.gameParameters = gameParameters;
        //}

        public void PrintWordInDashes()
        {

            foreach (var item in GameParameters.WordInDashes)
            {
                Console.Write($"{item} ");
            }
        }
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("     HANGMAN");
            Console.WriteLine("+______________");
            Console.WriteLine("|/          |");
            Console.WriteLine("|           O");
            Console.WriteLine("|          /|\\");
            Console.WriteLine("|          / \\");
            Console.WriteLine("|");
            Console.WriteLine("|\\_____________");
            Console.WriteLine("Possible topics:");
            Console.WriteLine("1. Countries");
            Console.WriteLine("2. Cities");
            Console.WriteLine("3. Seas");

        }

        public static void HangmanDrawing(int attempts)
        {
            Console.WriteLine("+______________");
            switch (attempts)
            {
                case 0:
                    {
                        Console.WriteLine("|/");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|");
                        Console.WriteLine("|");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|           |");
                        Console.WriteLine("|");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|");
                        Console.WriteLine("|");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|          /");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("|/          |");
                        Console.WriteLine("|           O");
                        Console.WriteLine("|          /|\\");
                        Console.WriteLine("|          / \\");
                        break;
                    }

            }
            Console.WriteLine("|");
            Console.WriteLine("|\\_____________");


        }
    }
}
