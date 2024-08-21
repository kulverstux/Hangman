using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class UI
    {
        private readonly GameParameters _gameParameters;
        private readonly PrintOutput _printOutput;
        private readonly WordData _word;
        private readonly CheckInputs _checkInputs;
        private readonly CheckGuess _checkGuess;

        public UI()
        {
            _gameParameters = new GameParameters();
            _printOutput = new PrintOutput(_gameParameters);
            _word = new WordData(_gameParameters);
            _checkInputs = new CheckInputs(_word, _printOutput);
            _checkGuess = new CheckGuess(_gameParameters);
        }
        public string WordInit()
        {
            string zodisKuriNorimaAtspetiPaduotasKaipString = _checkInputs.PagrindinioPasirinkimuMeniuTemosPasirinkimas();
            int zodzioIlgis = zodisKuriNorimaAtspetiPaduotasKaipString.Length;
            ZodisKuriNorimaAtspetiBruksneliais(zodzioIlgis);
            return zodisKuriNorimaAtspetiPaduotasKaipString;
        }
        public void ZodisKuriNorimaAtspetiBruksneliais(int ilgis)
        {

            while (ilgis > 0)
            {
                _gameParameters.ZodisBruksneliais.Add('_');
                ilgis--;
            }
        }
        public void Start()
        {

                _printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();

                string zodisKuriNorimaAtspetiPaduotasKaipString = WordInit();
            Console.WriteLine($"zodis: {zodisKuriNorimaAtspetiPaduotasKaipString}");
                _printOutput.SpausdintiZodiSuBruksneliais();
                int bandymai = 0;
                int maxBandymuSkaicius = _gameParameters.MaxBandymuSkaicius;
                
                bool zaidimasTesiamas = true;
                bool atspetasZodis = false;
                while (zaidimasTesiamas)
                {
                    Console.Clear();
                    Console.WriteLine($"Tema: {_gameParameters.TemosPavadinimas}");
                    _printOutput.VisuSarasuSpausdinimas();
                    _printOutput.SpejimuPiesinys(bandymai);

                    Console.WriteLine("Iveskite spejama raide:");
                    string vartotojoIvestis = Console.ReadLine().ToUpper();

                    if (_checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
                    {
                        if (vartotojoIvestis.Length > 1)
                        {

                            while (_checkGuess.ArToksSpejimasJauBuvo(vartotojoIvestis))
                            {
                                var pasikartojimas = vartotojoIvestis;

                                vartotojoIvestis = Console.ReadLine().ToUpper();
                                if (!_checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
                                {
                                    vartotojoIvestis = pasikartojimas;
                                }
                                else
                                if (vartotojoIvestis.Length <= 1)
                                {
                                    Console.WriteLine("Zodi turi sudaryti daugiau nei vienas simbolis");
                                    vartotojoIvestis = pasikartojimas;
                                }
                            }

                            if (vartotojoIvestis == zodisKuriNorimaAtspetiPaduotasKaipString)
                            {
                                atspetasZodis = true;
                            }
                            else
                            {
                                Console.WriteLine("nepavyko atspeti zodzio...");
                                _gameParameters.SpetiZodziai.Add(vartotojoIvestis);
                                _printOutput.VisuSarasuSpausdinimas();
                                bandymai++;
                            }
                        }
                        else
                        {
                            char vartotojoSpetaRaide = vartotojoIvestis[0];
                            while (_checkGuess.ArToksSpejimasJauBuvo(vartotojoSpetaRaide))
                            {
                                var pasikartojimas = vartotojoSpetaRaide;
                                vartotojoIvestis = Console.ReadLine().ToUpper();
                                vartotojoSpetaRaide = vartotojoIvestis[0];

                                if (!_checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
                                {
                                    vartotojoSpetaRaide = pasikartojimas;
                                }
                            }
                            _gameParameters.ZodisBruksneliais = _checkGuess.PatikrintiArSpejimasGeras(vartotojoSpetaRaide, zodisKuriNorimaAtspetiPaduotasKaipString, out bool klaida);


                            if (klaida)
                            {
                                bandymai++;
                                if (bandymai == maxBandymuSkaicius) zaidimasTesiamas = false;
                            }

                        }
                    }
                    if (!zaidimasTesiamas)
                    {
                        Console.Clear();
                        _printOutput.SpejimuPiesinys(bandymai);
                        Console.WriteLine("Deja, pralaimejote...");
                        Console.WriteLine($"Teisingas zodis buvo : {zodisKuriNorimaAtspetiPaduotasKaipString}");
                        zaidimasTesiamas = false;
                    }
                    else
                    if (atspetasZodis ^ !_checkGuess.ArVisosRaidesAtspetos())
                    {
                        Console.Clear();
                        Console.WriteLine("Sveikiname! Jus laimejote");
                        Console.WriteLine($"Teisingas zodis buvo : {zodisKuriNorimaAtspetiPaduotasKaipString}");
                        zaidimasTesiamas = false;
                    }
                }

        }
    }
}
