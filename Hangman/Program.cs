using Hangman;
public class HangmanClass
{
<<<<<<< HEAD
    private readonly GameParameters _gameParameters;
    private readonly WordSelector _word;
    private readonly PrintOuts _wordInDashes;

   // private static UI userInterf = new UI();

    public HangmanClass()
    {
        _gameParameters = new();
        _word = new(_gameParameters);
=======
    private static Game game = new Game();
    public static void Main(string[] args)
    { 
       game.Start();     
>>>>>>> b8b778829094d367433d491cb4b0ada9cae98a61
    }
    public static void Main(string[] args)
    {
        HangmanClass h = new HangmanClass();

        var w = h._word.SelectWord(1);
        Console.WriteLine($"{w }");
        h._wordInDashes.WordInDashes();
        foreach (var item in h._gameParameters.WordInDashes)
        {
            Console.WriteLine($"{item}, ");
        }

    // userInterf.Start();
    }
    
 
}