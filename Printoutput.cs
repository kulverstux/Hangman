using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class PrintOutput
    {
       

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

    }
}
