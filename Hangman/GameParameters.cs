namespace Hangman
{
    public class GameParameters
    {
        public int MaxBandymuSkaicius = 7;
        public string TemosPavadinimas { get; set; } = "";
        public List<char> SpetosRaides { get; set; } = new List<char>();
        public List<string> SpetiZodziai { get; set; } = new List<string>();
        public List<char> ZodisBruksneliais { get; set; } = new();
    }
}
