using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class CheckGuess
    {
        private GameParameters gameParameters;
        public CheckGuess (GameParameters gameParameters)
        {
            this.gameParameters = gameParameters;
        }

        public bool ArToksSpejimasJauBuvo(string arJauSpetas)
        {
            bool toksZodisJauSpetas = false;
            foreach (var item in gameParameters.SpetiZodziai)
            {
                if (arJauSpetas == item)
                {
                    toksZodisJauSpetas = true;
                    Console.WriteLine("Toks zodis jau buvo spetas. Irasykite kita.");
                    return toksZodisJauSpetas;
                }

            }
            return false;
        }
        public bool ArToksSpejimasJauBuvo(char arJauSpetas)
        {
            bool toksZodisJauSpetas = false;
            foreach (var item in gameParameters.SpetosRaides)
            {
                if (arJauSpetas == item)
                {
                    toksZodisJauSpetas = true;
                    Console.WriteLine("Tokia raide jau buvo speta. Irasykite kita.");
                    return toksZodisJauSpetas;
                }
            }
            return false;
        }


        public  List<char> PatikrintiArSpejimasGeras(char vartotojoSpetaRaide, string zodisKuriNorimaAtspetiPaduotasKaipString, out bool klaida)
        {

            gameParameters.SpetosRaides.Add(vartotojoSpetaRaide);
            int indexas = 0;
            bool arTeisingasSpejimas = false;
            klaida = false;

            foreach (var item in zodisKuriNorimaAtspetiPaduotasKaipString)
            {
                if (vartotojoSpetaRaide == item)
                {
                    gameParameters.ZodisBruksneliais[indexas] = vartotojoSpetaRaide;
                    arTeisingasSpejimas = true;
                }
                indexas++;
            }

            if (arTeisingasSpejimas)
            {
                Console.WriteLine("Jus atspejote raide!");
                klaida = false;
            }
            else
            {
                Console.WriteLine("Deja tokios raides nera");
                klaida = true;
            }
            return gameParameters.ZodisBruksneliais;
        }
        public bool ArVisosRaidesAtspetos()
        {
            bool klaida = false;
            foreach (var item in gameParameters.ZodisBruksneliais)
            {
                if (item == '_') klaida = true;
            }
            return klaida;

        }
    }
}
