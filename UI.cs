using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class UI
    { 
            private static GameParameters gameParameters = new GameParameters();
            private static PrintOutput printOutput = new PrintOutput(gameParameters);
            private static WordData word = new WordData(gameParameters);
            private static CheckInputs checkInputs = new CheckInputs(word, printOutput);
            private static CheckGuess checkGuess = new CheckGuess(gameParameters);
        public string WordInit()
        {
            string zodisKuriNorimaAtspetiPaduotasKaipString = checkInputs.PagrindinioPasirinkimuMeniuTemosPasirinkimas();
            int zodzioIlgis = zodisKuriNorimaAtspetiPaduotasKaipString.Length;
            ZodisKuriNorimaAtspetiBruksneliais(zodzioIlgis);
            return zodisKuriNorimaAtspetiPaduotasKaipString;
        }
        public void ZodisKuriNorimaAtspetiBruksneliais(int ilgis)
        {

            while (ilgis > 0)
            {
                gameParameters.ZodisBruksneliais.Add('_');
                ilgis--;
            }
        }
        public void Start()
        {

                printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();

                string zodisKuriNorimaAtspetiPaduotasKaipString = WordInit();
            Console.WriteLine($"zodis: {zodisKuriNorimaAtspetiPaduotasKaipString}");
                printOutput.SpausdintiZodiSuBruksneliais();
                int bandymai = 0;
                int maxBandymuSkaicius = gameParameters.MaxBandymuSkaicius;
                
                bool zaidimasTesiamas = true;
                bool atspetasZodis = false;
                while (zaidimasTesiamas)
                {
                    Console.Clear();
                    Console.WriteLine($"Tema: {gameParameters.TemosPavadinimas}");
                    printOutput.VisuSarasuSpausdinimas();
                    printOutput.SpejimuPiesinys(bandymai);

                    Console.WriteLine("Iveskite spejama raide:");
                    string vartotojoIvestis = Console.ReadLine().ToUpper();

                    if (checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
                    {
                        if (vartotojoIvestis.Length > 1)
                        {

                            while (checkGuess.ArToksSpejimasJauBuvo(vartotojoIvestis))
                            {
                                var pasikartojimas = vartotojoIvestis;

                                vartotojoIvestis = Console.ReadLine().ToUpper();
                                if (!checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
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
                                gameParameters.SpetiZodziai.Add(vartotojoIvestis);
                                printOutput.VisuSarasuSpausdinimas();
                                bandymai++;
                            }
                        }
                        else
                        {
                            char vartotojoSpetaRaide = vartotojoIvestis[0];
                            while (checkGuess.ArToksSpejimasJauBuvo(vartotojoSpetaRaide))
                            {
                                var pasikartojimas = vartotojoSpetaRaide;
                                vartotojoIvestis = Console.ReadLine().ToUpper();
                                vartotojoSpetaRaide = vartotojoIvestis[0];

                                if (!checkInputs.PatikrintiVartotojoIvesti(vartotojoIvestis))
                                {
                                    vartotojoSpetaRaide = pasikartojimas;
                                }
                            }
                            gameParameters.ZodisBruksneliais = checkGuess.PatikrintiArSpejimasGeras(vartotojoSpetaRaide, zodisKuriNorimaAtspetiPaduotasKaipString, out bool klaida);


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
                        printOutput.SpejimuPiesinys(bandymai);
                        Console.WriteLine("Deja, pralaimejote...");
                        Console.WriteLine($"Teisingas zodis buvo : {zodisKuriNorimaAtspetiPaduotasKaipString}");
                        zaidimasTesiamas = false;
                    }
                    else
                    if (atspetasZodis ^ !checkGuess.ArVisosRaidesAtspetos())
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
