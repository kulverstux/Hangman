using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class CheckInputs
    {
        WordData word;
        PrintOutput printOutput;
        public CheckInputs(WordData word, PrintOutput printOutput)
        {
            this.word = word;
            this.printOutput = printOutput;
        }
        public bool PatikrintiVartotojoIvesti(string ivestis)
        {
            ivestis = ivestis.Trim();
            if (ivestis == null)
            {
                return false;
            }
            else
                if (ivestis == "")
            {
                Console.WriteLine("Iveskite bent viena raide.");
                return false;
            }
            else
                return true;
        }

        public string PagrindinioPasirinkimuMeniuTemosPasirinkimas()
        {
            bool arPasirinkimasKlaidingas = true;

            do
            {
                Console.WriteLine("Pasirinkite tema, irasydami jos numeri:");
                string irasas = Console.ReadLine();
                if (PatikrintiVartotojoIvesti(irasas))
                {
                    switch (irasas)
                    {
                        case "1":
                        case "2":
                        case "3":
                            {
                                string isrinktasZodis = word.ZodzioInicializavimas(int.Parse(irasas));
                                return isrinktasZodis;
                            }
                        default:
                            {
                                printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();
                                arPasirinkimasKlaidingas = true;
                                break;
                            }
                    } //switch end
                } //if end
                else
                {
                    printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();
                    arPasirinkimasKlaidingas = true;
                }
            }
            while (arPasirinkimasKlaidingas);

            return "";
        }
    }
}
