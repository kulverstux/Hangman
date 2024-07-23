using System;
using System.Collections.Generic;
public class HangmanClass
{
    public static List<char> ZodisKuriNorimaAtspetiBruksneliais(int ilgis)
    {
        List<char> zodisBruksneliais = new();
        while (ilgis > 0)
        {
            zodisBruksneliais.Add('_');
            ilgis--;
        }
        return zodisBruksneliais;
    }
    public static bool PatikrintiVartotojoIvesti(string ivestis)
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
    public static void SpausdintiSpetasRaides(List<char> spetosRaides)
    {
        Console.WriteLine("Spetos raides:");
        foreach (var item in spetosRaides)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine("-----------");
    }
    public static void SpausdintiSpetusZodzius(List<string> spetiZodziai)
    {
        Console.WriteLine("Speti zodziai:");
        foreach (var item in spetiZodziai)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine("-----------");

    }
    public static void SpausdintiZodiSuBruksneliais(List<char> zodisBruksneliais)
    {
        foreach (var item in zodisBruksneliais)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    public static void VisuSarasuSpausdinimas(List<char> spetosRaides, List<string> spetiZodziai, List<char> zodisBruksneliais)
    {
        SpausdintiZodiSuBruksneliais(zodisBruksneliais);
        SpausdintiSpetasRaides(spetosRaides);
        SpausdintiSpetusZodzius(spetiZodziai);
    }


    public static bool ArToksSpejimasJauBuvo(string arJauSpetas, List<string> spetiZodziai)
    {
        bool toksZodisJauSpetas = false;
        foreach (var item in spetiZodziai)
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
    public static bool ArToksSpejimasJauBuvo(char arJauSpetas, List<char> spetosRaides)
    {
        bool toksZodisJauSpetas = false;
        foreach (var item in spetosRaides)
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

    public static string ZodzioInicializavimas(int pasirinkimas)
    {
        Random rand = new Random();
        switch (pasirinkimas)
        {
            case 1:
                {
                    string[] salys = { "Latvija", "Estija", "Bulgarija", "Kinija", "Mozambikas", "Tailandas", "Danija", "Prancuzija", "Uganda", "Alzyras", "Zibutis" };
                    int ilgis = salys.Length;
                    int atsitiktinisPasirinkimas = rand.Next(ilgis);
                    string zodisKuriNorimaAtspetiPaduotasKaipString = salys[atsitiktinisPasirinkimas];
                    return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
                }
            case 2:
                {
                    string[] miestai = { "Vilnius", "Kaunas", "Venecija", "Kedainiai", "Paryzius", "Marokas", "Kopenhaga", "Orleanas", "Berlynas", "Pasvalys", "Visaginas" };
                    int ilgis = miestai.Length;
                    int atsitiktinisPasirinkimas = rand.Next(ilgis);
                    string zodisKuriNorimaAtspetiPaduotasKaipString = miestai[atsitiktinisPasirinkimas];
                    return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
                }
            case 3:
                {
                    string[] medziai = { "Berzas", "Uosis", "Liepa", "Bukas", "Azuolas", "Pusis", "Egle", "Kukmedis", "Maumedis", "Klevas", "Baltalksnis" };
                    int ilgis = medziai.Length;
                    int atsitiktinisPasirinkimas = rand.Next(ilgis);
                    string zodisKuriNorimaAtspetiPaduotasKaipString = medziai[atsitiktinisPasirinkimas];
                    return zodisKuriNorimaAtspetiPaduotasKaipString.ToUpper();
                }
            default:
                break;
        }
        return "Programos klaida bandant pasirinkti is temu saraso";

    }
    public static List<char> PatikrintiArSpejimasGeras(List<char> spetosRaides, char vartotojoSpetaRaide, string zodisKuriNorimaAtspetiPaduotasKaipString, List<char> zodisBruksneliais, out bool klaida)
    {

        spetosRaides.Add(vartotojoSpetaRaide);
        int indexas = 0;
        bool arTeisingasSpejimas = false;
        bool kla = false;

        foreach (var item in zodisKuriNorimaAtspetiPaduotasKaipString)
        {
            if (vartotojoSpetaRaide == item)
            {
                zodisBruksneliais[indexas] = vartotojoSpetaRaide;
                arTeisingasSpejimas = true;
            }
            indexas++;
        }

        if (arTeisingasSpejimas)
        {
            Console.WriteLine("Jus atspejote raide!");
            kla = false;
        }
        else
        {
            Console.WriteLine("Deja tokios raides nera");
            kla = true;
        }
        klaida = kla;
        return zodisBruksneliais;
    }

    public static void AtspausdintiPagrindiniPasirinkimuMeniu()
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
    public static string PagrindinioPasirinkimuMeniuTemosPasirinkimas()
    {
        bool arPasirinkimasKlaidingas = true;

        while (arPasirinkimasKlaidingas)
        {
            Console.WriteLine("Pasirinkite tema, irasydami jos numeri:");
            string irasas = Console.ReadLine();
            if (PatikrintiVartotojoIvesti(irasas))
            {
                switch (irasas)
                {
                    case "1":
                        {
                            string isrinktasZodis = ZodzioInicializavimas(1);
                            arPasirinkimasKlaidingas = false;
                            return isrinktasZodis;
                        }
                    case "2":
                        {
                            string isrinktasZodis = ZodzioInicializavimas(2);
                            arPasirinkimasKlaidingas = false;
                            return isrinktasZodis;
                        }
                    case "3":
                        {
                            string isrinktasZodis = ZodzioInicializavimas(3);
                            arPasirinkimasKlaidingas = false;
                            return isrinktasZodis;
                        }
                    default:
                        {
                            Console.WriteLine("Prasom pasirinkti tema is pateikto saraso.");
                            AtspausdintiPagrindiniPasirinkimuMeniu();
                            arPasirinkimasKlaidingas = true;
                            break;
                        }
                }        //switch end
            }    //if end
            else
            {
                Console.WriteLine("Prasom pasirinkti tema is pateikto saraso.");
                AtspausdintiPagrindiniPasirinkimuMeniu();
                arPasirinkimasKlaidingas = true;
            }
        }
        return "Klaida renkantis temos numeri";
    }
    public static void SpejimuPiesinys(int bandymai)
    {
        Console.Clear();
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
    public static void Main(string[] args)
    {
        bool arPirmaKartaPaleistaPrograma = true;

        if (arPirmaKartaPaleistaPrograma)
        {
            AtspausdintiPagrindiniPasirinkimuMeniu();
            arPirmaKartaPaleistaPrograma = false;
        }

        string zodisKuriNorimaAtspetiPaduotasKaipString = PagrindinioPasirinkimuMeniuTemosPasirinkimas();
        int zodzioIlgis = zodisKuriNorimaAtspetiPaduotasKaipString.Length;

        var zodisBruksneliais = ZodisKuriNorimaAtspetiBruksneliais(zodzioIlgis);

        List<char> spetosRaides = new();
        List<string> spetiZodziai = new();

        SpausdintiZodiSuBruksneliais(zodisBruksneliais);

        int bandymai = 0;
        int maxBandymuSkaicius = 7;

        while (bandymai < maxBandymuSkaicius)
        {
            Console.Clear();
            SpejimuPiesinys(bandymai);                        //cia turi buti piesinys
            Console.WriteLine($"bandymas Nr. {bandymai}");
            Console.WriteLine($"bandymas Nr. {zodisKuriNorimaAtspetiPaduotasKaipString}");
            Console.WriteLine("Iveskite spejama raide:");
            string vartotojoIvestis = Console.ReadLine().ToUpper();

            if (PatikrintiVartotojoIvesti(vartotojoIvestis))
            {
                if (vartotojoIvestis.Length > 1)
                {

                    while (ArToksSpejimasJauBuvo(vartotojoIvestis, spetiZodziai))
                    {
                        var pasikartojimas = vartotojoIvestis;

                        vartotojoIvestis = Console.ReadLine().ToUpper();
                        if (!PatikrintiVartotojoIvesti(vartotojoIvestis))
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
                        Console.WriteLine("Atspejote zodi!");
                        Console.WriteLine($"Teisingas zodis: {zodisKuriNorimaAtspetiPaduotasKaipString}");
                        bandymai = maxBandymuSkaicius + 1;
                    }
                    else
                    {
                        Console.WriteLine("nepavyko atspeti zodzio...");
                        spetiZodziai.Add(vartotojoIvestis);
                        VisuSarasuSpausdinimas(spetosRaides, spetiZodziai, zodisBruksneliais);
                        bandymai++;
                    }
                }
                else
                {
                    char vartotojoSpetaRaide = char.Parse(vartotojoIvestis);
                    while (ArToksSpejimasJauBuvo(vartotojoSpetaRaide, spetosRaides))
                    {
                        var pasikartojimas = vartotojoSpetaRaide;
                        vartotojoIvestis = Console.ReadLine().ToUpper();
                        vartotojoSpetaRaide = char.Parse(vartotojoIvestis);
                        if (!PatikrintiVartotojoIvesti(vartotojoIvestis))
                        {
                            vartotojoSpetaRaide = pasikartojimas;
                        }
                    }
                    zodisBruksneliais = PatikrintiArSpejimasGeras(spetosRaides, vartotojoSpetaRaide, zodisKuriNorimaAtspetiPaduotasKaipString, zodisBruksneliais, out bool klaida);

                    VisuSarasuSpausdinimas(spetosRaides, spetiZodziai, zodisBruksneliais);
                    if (klaida)
                    {
                        bandymai++;
                    }

                }
            }

        }
        if (bandymai == maxBandymuSkaicius)
        {
            Console.WriteLine("Deja, pralaimejote...");
            Console.WriteLine($"Teisingas zodis buvo : {zodisKuriNorimaAtspetiPaduotasKaipString}");

        }
    }
}