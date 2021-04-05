using BigTycoon.Celle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigTycoon
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Inizializzazioni
            //Inizializzazioni
            const int RIGHE = 3;
            const int COLONNE = 5;

            string[,] materiali = new string[RIGHE, COLONNE];
            string[,] nomi = new string[RIGHE, COLONNE];

            string[] listaMateriali = { "COMUNI", "RARI", "PREZIOSI" };
            string[] listaNomi = {"Cuneo", "Abbiategrasso", "Abbiatelardo", "Taranto",
                                  "Scampia", "Bolzano", "Ghiffa", "Palermo",
                                  "Miazzina", "Catanzaro", "Luino", "Alba", "Calascibetta",
                                  "Ribera", "Kyoto", "Costantinopoli", "Finterra", "Calbarico"};


            Random rng = new Random();

            //Materiali
            for(int i = 0; i < materiali.GetLength(0); i++)
                for (int j = 0; j < materiali.GetLength(1); j++)
                    materiali[i, j] = listaMateriali[rng.Next() % listaMateriali.Length];

            //Nomi
            for (int i = 0; i < nomi.GetLength(0); i++)
            {
                for (int j = 0; j < nomi.GetLength(1); j++)
                {
                    int indice = 0;
                    do
                    {
                        indice = rng.Next() % listaNomi.Length;

                        nomi[i, j] = listaNomi[indice];
                    }
                    while (listaNomi[indice] == " ");

                    listaNomi[indice] = " ";
                }
            }
            #endregion

            Application.Run(new Form1(new Mappa(materiali, nomi)));
        }
    }

}
