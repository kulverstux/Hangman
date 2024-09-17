namespace Hangman
{
    public class CheckGuess
    {
<<<<<<< HEAD
        private GameParameters gameParameters;
        public CheckGuess(GameParameters gameParameters)
=======
        private readonly GameParameters _gameParameters;
        public CheckGuess (GameParameters gameParameters)
>>>>>>> b8b778829094d367433d491cb4b0ada9cae98a61
        {
            _gameParameters = gameParameters;
        }

        public bool ArToksSpejimasJauBuvo(string arJauSpetas)
        {
            bool toksSpejimasJauBuvo = false;
            if (arJauSpetas.Length > 1)
            {
                foreach (var item in _gameParameters.SpetiZodziai)
                {
                    if (arJauSpetas == item)
                    {
                        toksSpejimasJauBuvo = true;
                        Console.WriteLine("Toks zodis jau buvo spetas.");
                        return toksSpejimasJauBuvo;
                    }
                }
            }
            else
            {
                foreach (var item in _gameParameters.SpetosRaides)
                {
                    if (arJauSpetas[0] == item)
                    {
                        toksSpejimasJauBuvo = true;
                        Console.WriteLine("Tokia raide jau buvo speta.");
                        return toksSpejimasJauBuvo;
                    }
                }
            }
            return false;
        }

<<<<<<< HEAD

        public List<char> PatikrintiArSpejimasGeras(char vartotojoSpetaRaide, string zodisKuriNorimaAtspetiPaduotasKaipString, out bool klaida)
=======
        public  bool PatikrintiArSpejimasGeras(char vartotojoSpetaRaide, string zodisKuriNorimaAtspetiPaduotasKaipString)
>>>>>>> b8b778829094d367433d491cb4b0ada9cae98a61
        {

            _gameParameters.SpetosRaides.Add(vartotojoSpetaRaide);
            int indexas = 0;
            bool arTeisingasSpejimas = false;

            foreach (var item in zodisKuriNorimaAtspetiPaduotasKaipString)
            {
                if (vartotojoSpetaRaide == item)
                {
                    _gameParameters.ZodisBruksneliais[indexas] = vartotojoSpetaRaide;
                    arTeisingasSpejimas = true;
                }
                indexas++;
            }

            if (arTeisingasSpejimas)
            {
                Console.WriteLine("Jus atspejote raide!");
            }
            else
            {
                Console.WriteLine("Deja tokios raides nera");
            }
            return arTeisingasSpejimas;
        }
        
        public bool ArVisosRaidesAtspetos()
        {
            bool klaida = false;
            foreach (var item in _gameParameters.ZodisBruksneliais)
            {
                if (item == '_') klaida = true;
            }
            return klaida;
        }
    
        public bool TryGuessWholeWord(string vartotojoIvestis)
        {
            if (vartotojoIvestis == _gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString)
            {
                return true;
            }
            else
            {
                Console.WriteLine("nepavyko atspeti zodzio...");
                _gameParameters.SpetiZodziai.Add(vartotojoIvestis);
                _gameParameters.Bandymai++;
                return false;
            }
        }
    }
}
