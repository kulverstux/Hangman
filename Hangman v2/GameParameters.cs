namespace Hangman_v2
{
    public static class GameParameters
    {
        //max allowed attribute length when adding a new record into db
        public const int maxUserNameLength = 10;
        public const int maxNameLength = 15;
        public const int maxLastNameLength = 20;
        public const int maxPasswordLength = 20;
        //
        public const int MaxAttempts = 7;  //7 for full image drawing       
        public static string Theme { get; set; } = "";
        public static bool UserSuccessfullyLoggedIn { get; set; } = false;
        public static bool PlayAsAGuest { get; set; } = false;
        public static List<char> WordInDashes { get; set; } = new();
        public static List<char> GuessedLetters { get; set; } = new();
        public static List<string> GuessedWords { get; set; } = new();

    }
}
