//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Hangman
//{
//    public class WordData
//    {
//        private GameParameters gameParameters;
//        public WordData(GameParameters gameParameters)
//        {           
//            this.gameParameters = gameParameters;
//        }

//        public string ZodzioInicializavimas(int pasirinkimas)
//        {
//            Random rand = new Random();
//            switch (pasirinkimas)
//            {
//                case 1:
//                    {
//                        gameParameters.TemosPavadinimas = "SALYS";
//                        string[] salys = { "Latvija", "Estija", "Bulgarija", "Kinija", "Mozambikas", "Tailandas", "Danija", "Prancuzija", "Uganda", "Alzyras", "Zibutis" };
//                        int ilgis = salys.Length;
//                        int atsitiktinisPasirinkimas = rand.Next(ilgis);
//                        string zodisKuriNorimaAtspetiPaduotasKaipString = salys[atsitiktinisPasirinkimas];
//                        return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
//                    }
//                case 2:
//                    {
//                        gameParameters.TemosPavadinimas = "MIESTAI";
//                        string[] miestai = { "Vilnius", "Kaunas", "Venecija", "Kedainiai", "Paryzius", "Marokas", "Kopenhaga", "Orleanas", "Berlynas", "Pasvalys", "Visaginas" };
//                        int ilgis = miestai.Length;
//                        int atsitiktinisPasirinkimas = rand.Next(ilgis);
//                        string zodisKuriNorimaAtspetiPaduotasKaipString = miestai[atsitiktinisPasirinkimas];
//                        return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
//                    }
//                case 3:
//                    {
//                        gameParameters.TemosPavadinimas = "MEDZIAI";
//                        string[] medziai = { "Berzas", "Uosis", "Liepa", "Bukas", "Azuolas", "Pusis", "Egle", "Kukmedis", "Maumedis", "Klevas", "Baltalksnis" };
//                        int ilgis = medziai.Length;
//                        int atsitiktinisPasirinkimas = rand.Next(ilgis);
//                        string zodisKuriNorimaAtspetiPaduotasKaipString = medziai[atsitiktinisPasirinkimas];
//                        return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
//                    }
//                default:
//                    return "";
//            }
//        }

//    }
//}
