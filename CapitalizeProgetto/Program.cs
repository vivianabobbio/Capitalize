using System;
using System.IO;

namespace CapitalizeProgetto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me the address of the file where to apply capitalize.");
            string indirizzo = Console.ReadLine();

            string testoFile = LeggiIlFile(indirizzo);

            if (testoFile == null)
            {
                return;
            }
            Console.WriteLine("Do you want a New File or do you want to Overwrite the previous one?");
            Console.WriteLine("Select N for new and S for overwrite");
            string sceltaNuovo = Console.ReadLine();

            Console.WriteLine("If you want to capitalize all letters press T"
                                      + Environment.NewLine
                                      + "if instead you want to capitalize the letters after the dot press P");
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
                    Console.WriteLine("Not accessible file");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
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
                    Console.WriteLine("Unable to save");
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

                    Console.WriteLine("Unable to save");
                }

            }
        }              
    }
}