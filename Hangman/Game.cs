namespace Hangman
{
    public class Game
    {
        private readonly GameParameters _gameParameters;
        private readonly PrintOutput _printOutput;
        private readonly WordData _word;
        private readonly CheckInputs _checkInputs;
        private readonly CheckGuess _checkGuess;
        private string _vartotojoIvestis;

        public Game()
        {
            _gameParameters = new GameParameters();
            _printOutput = new PrintOutput(_gameParameters);
            _word = new WordData(_gameParameters);
            _checkInputs = new CheckInputs(_printOutput);
            _checkGuess = new CheckGuess(_gameParameters);
            _vartotojoIvestis = "";
        }
        private void WordInit()
        {
            _printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();

            Console.WriteLine("Pasirinkite tema, irasydami jos numeri:");
            string userInput = Console.ReadLine();

            _gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString =
                _word.ZodzioInicializavimas(_checkInputs.PagrindinioPasirinkimuMeniuTemosPasirinkimas(userInput));
            
            ZodisKuriNorimaAtspetiBruksneliais(_gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString.Length);
        }

        private void ZodisKuriNorimaAtspetiBruksneliais(int ilgis)
        {

            while (ilgis > 0)
            {
                _gameParameters.ZodisBruksneliais.Add('_');
                ilgis--;
            }
        }

        private bool CheckGameEnd(bool zaidimasTesiamas, bool atspetasZodis)
        {
            if (!zaidimasTesiamas)
            {
                Console.Clear();
                _printOutput.SpejimuPiesinys();
                Console.WriteLine("Deja, pralaimejote...");
                Console.WriteLine($"Teisingas zodis buvo : {_gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString}");
            }
            else if (atspetasZodis ^ !_checkGuess.ArVisosRaidesAtspetos())
            {
                Console.Clear();
                Console.WriteLine("Sveikiname! Jus laimejote");
                Console.WriteLine($"Teisingas zodis buvo : {_gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString}");
                zaidimasTesiamas = false;
            }
            return zaidimasTesiamas;
        }

        public void Start()
        {
            WordInit();
            
            bool zaidimasTesiamas = true;
            bool atspetasZodis = false;

            while (zaidimasTesiamas)
            {
                Console.Clear();
                Console.WriteLine($"Tema: {_gameParameters.TemosPavadinimas}");
                _printOutput.VisuSarasuSpausdinimas();
                _printOutput.SpejimuPiesinys();

                do
                {
                    Console.WriteLine("Iveskite spejama raide arba zodi:");
                    _vartotojoIvestis = Console.ReadLine().ToUpper();
                }
                while (!_checkInputs.PatikrintiVartotojoIvesti(_vartotojoIvestis));

                bool guess = _checkGuess.ArToksSpejimasJauBuvo(_vartotojoIvestis);

                if (!guess)
                {
                    if (_vartotojoIvestis.Length > 1)
                    {
                        atspetasZodis = _checkGuess.TryGuessWholeWord(_vartotojoIvestis);
                    }
                    else
                    {                        
                        if (!_checkGuess.PatikrintiArSpejimasGeras(_vartotojoIvestis[0], _gameParameters.ZodisKuriNorimaAtspetiPaduotasKaipString))
                        {
                            _gameParameters.Bandymai++;
                            if (_gameParameters.Bandymai == GameParameters.MaxBandymuSkaicius) zaidimasTesiamas = false;
                        }
                    }

                    zaidimasTesiamas = CheckGameEnd(zaidimasTesiamas, atspetasZodis);
                }
            }
        }
    }
}
