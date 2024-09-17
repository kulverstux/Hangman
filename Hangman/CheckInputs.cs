namespace Hangman
{
    public class CheckInputs
    {
        private readonly PrintOutput _printOutput;
        public CheckInputs(PrintOutput printOutput)
        {
            _printOutput = printOutput;
        }
        public bool PatikrintiVartotojoIvesti(string ivestis)
        {
            ivestis = ivestis.Trim();
            if (ivestis == null)
            {
                Console.WriteLine("Klaida: tuscia ivestis.");
                return false;
            }
            else
                if (ivestis == "")
            {
                Console.WriteLine("Klaida: tuscia ivestis.");
                return false;
            }
            else
                return true;
        }

        public int PagrindinioPasirinkimuMeniuTemosPasirinkimas(string userInput)
        {
            bool arPasirinkimasKlaidingas = true;

            do
            {                
                if (PatikrintiVartotojoIvesti(userInput))
                {
                    switch (userInput)
                    {
                        case "1":
                        case "2":
                        case "3":
                            {
                                return int.Parse(userInput);
                            }
                        default:
                            {
                                _printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();
                                arPasirinkimasKlaidingas = true;
                                break;
                            }
                    }
                }
                else
                {
                    _printOutput.AtspausdintiPagrindiniPasirinkimuMeniu();
                    arPasirinkimasKlaidingas = true;
                }
            }
            while (arPasirinkimasKlaidingas);

            return 0;
        }
    }
}
