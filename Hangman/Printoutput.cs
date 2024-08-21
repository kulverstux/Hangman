using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class PrintOutput
    {
        private GameParameters gameParameters;
        public PrintOutput(GameParameters gameParameters)
        {
            this.gameParameters = gameParameters;
        }
    

        public void SpausdintiSpetasRaides()
        {
            Console.WriteLine("Spetos raides:");
            foreach (var item in gameParameters.SpetosRaides)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------");
        }

        public void SpausdintiSpetusZodzius()
        {
            Console.WriteLine("Speti zodziai:");
            foreach (var item in gameParameters.SpetiZodziai)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------");

        }
        public void SpausdintiZodiSuBruksneliais()
        {
            foreach (var item in gameParameters.ZodisBruksneliais)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public void VisuSarasuSpausdinimas()
        {
            SpausdintiZodiSuBruksneliais();
            SpausdintiSpetasRaides();
            SpausdintiSpetusZodzius();
        }
        public void AtspausdintiPagrindiniPasirinkimuMeniu()
        {
            Console.Clear();
            Console.WriteLine("Zaidimas PAKARUOKLIS");
            Console.WriteLine("+______________");
            Console.WriteLine("|/          |");
            Console.WriteLine("|           O");
            Console.WriteLine("|          /|\\");
            Console.WriteLine("|          / \\");
            Console.WriteLine("|");
            Console.WriteLine("|\\_____________");
            Console.WriteLine("Galimos temos:");
            Console.WriteLine("1. Salys");
            Console.WriteLine("2. Miestai");
            Console.WriteLine("3. Medziu pavadinimai");
        }

        public void SpejimuPiesinys(int bandymai)
        {
            Console.WriteLine("+______________");
            switch (bandymai)
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
