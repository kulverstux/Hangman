using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_v2
{
    public class WordSelector
    {
       // private GameParameters gameParameters;
        string wordToGuess = "";
        //public WordSelector (GameParameters gameParameters)
        //{
        //    this.gameParameters = gameParameters;
        //}

        public string SelectWord(int userChoice)
        {
            Random rand = new();
            switch (userChoice)
            {
                case 1:
                    {
                        GameParameters.Theme = "Countries";
                        string[] countries = { "Latvia", "Estonia", "Denmark", "China", "Ireland", "Thailand", "Zimbabwe", "France", "Uganda", "Poland", "Sweden" };
                        wordToGuess = countries[rand.Next(countries.Length)];
                        return wordToGuess.ToUpper();
                    }
                case 2:
                    {
                        GameParameters.Theme = "Cities";
                        string[] cities = { "Vilnius", "Kaunas", "Venice", "Kedainiai", "Paris", "Mumbai", "Philadelphia", "Dallas", "Kolkata", "Pasvalys", "Madrid" };
                        wordToGuess = cities[rand.Next(cities.Length)];
                        return wordToGuess.ToUpper();
                    }
                case 3:
                    {
                        GameParameters.Theme = "Seas";
                        string[] seas = { "Java", "Solomon", "White", "Sargasso", "Baltic", "Celebes", "labrador", "Norwegian", "Weddell", "Caribbean", "Greenland" };
                        wordToGuess = seas[rand.Next(seas.Length)];
                        return wordToGuess.ToUpper();
                    }
                default:
                    return "";
            }
        }

        public void SetUpWordInDashes()
        {
            if (wordToGuess.Length != 0)
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    GameParameters.WordInDashes.Add('_');
                }
            }
            else
            {
                Console.WriteLine("Error: failed word selection"); 
            }
        }
    }
}
