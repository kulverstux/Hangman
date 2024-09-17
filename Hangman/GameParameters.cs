namespace Hangman
{
    public class GameParameters
    {
        public int MaxBandymuSkaicius = 7;
        public string Theme { get; set; } = "";
       // public List<char> SpetosRaides { get; set; } = new List<char>();
       // public List<string> SpetiZodziai { get; set; } = new List<string>();
        public List<char> WordInDashes { get; set; } = new();
    }
}
