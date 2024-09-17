namespace Hangman_v2
{
    public static class GameParameters
    {
        public static int MaxAttempts = 7;
        public static string Theme { get; set; } = "";
        public static List<char> WordInDashes { get; set; } = new();
        public static List<char> GuessedLetters { get; set; } = new();

    }
}
