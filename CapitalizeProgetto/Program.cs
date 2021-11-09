using System;
using System.IO;

namespace CapitalizeProgetto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dammi l'indirizzo del file dove applicare capitalize");
            string indirizzo = Console.ReadLine();

            string testoFile = LeggiIlFile(indirizzo);

            if (testoFile == null)
            {
                return;
            }
            Console.WriteLine("Vuoi un Nuovo file o vuoi Sovrascrivere il precedente?");
            Console.WriteLine("Seleziona N per nuovo e S per sovrascrivere");
            string sceltaNuovo = Console.ReadLine();

            Console.WriteLine("Se vuoi rendere maiusole tutte le lettere premi T"
                                      + Environment.NewLine
                                      + "se invece vuoi rendere maiuscole le lettere dopo il punto premi P");
            string sceltaPunto = Console.ReadLine();

            string testoMaiuscolo = Capitalize(testoFile, sceltaPunto);

            ScriviIlFile(testoMaiuscolo, indirizzo, sceltaNuovo);

        }
        private static string Capitalize(string testoFile, string sceltaPunto)
        {
            if (sceltaPunto.Equals("P"))
            {
                string[] frasi = testoFile.Split(". ");
                for (int i = 0; i < frasi.Length; i++)
                {
                    string frase = frasi[i];

                    string primaLettera = frase[0].ToString();

                    string primaLetteraMiuscola = primaLettera.ToUpper();

                    string restoDellaFrase = frase.Substring(1);

                    string fraseMaiuscola = primaLetteraMiuscola + restoDellaFrase;

                    frasi[i] = fraseMaiuscola;
                }

                string testoMaiuscolo = string.Join(". ", frasi);
                return testoMaiuscolo;
            }
            else
            {
                string testoMaiuscolo = testoFile.ToUpper();
                return testoMaiuscolo;
            }
        }

        public static string Replace(string testo, string parolaDaCercare, string parolaDaRimpiazzare)
        {
            string testoModificato = testo.Replace(parolaDaCercare, parolaDaRimpiazzare);

            return testoModificato;
        }

        public static string LeggiIlFile(string indirizzo)
        {
            if (File.Exists(indirizzo))
            {
                try
                {
                    string testoDelFile = File.ReadAllText(indirizzo);
                    return testoDelFile;
                }
                catch (Exception)
                {
                    Console.WriteLine("File non accessibile");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Il file non esiste");
                return null;
            }
        }

        public static void ScriviIlFile(string testoDaSalvare, string indirizzo, string sceltaNuovo)
        {
            if (sceltaNuovo.Equals("N"))
            {
                string[] percorso = indirizzo.Split("\\");
                percorso[percorso.Length - 1] = "copia.txt";
                string nuovoIndirizzo = string.Join("\\", percorso);
                try
                {
                    File.WriteAllText(nuovoIndirizzo, testoDaSalvare);
                }
                catch (Exception)
                {
                    Console.WriteLine("Impossibile Salvare");
                }

            }
            else
            {
                try
                {
                    File.WriteAllText(indirizzo, testoDaSalvare);
                }
                catch (Exception)
                {

                    Console.WriteLine("Impossibile Salvare");
                }

            }
        }              
    }
}