using BigTycoon.Celle;
using BigTycoon.Generale;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigTycoon
{
    public partial class Form1 : Form
    {
        Giocatore giocatore;

        Mappa mappa;
        PictureBox[,] griglia;
        Label[,] luoghi;

        Image materialeTemp = null;

        public Form1(Mappa mappa)
        {
            InitializeComponent();

            giocatore = new Giocatore(500, 70, 6);

            portafoglio_label.Text = "Portafoglio: " + giocatore.portafogli.Soldi + "$";
            immagineAzienda_label.Text = "Immagine azienda: " + giocatore.FamaAziendale + "/100";
            richiesteLavoro_label.Text = "Richieste lavoro: " + giocatore.DipendentiDisponibili;

            #region InizializzazioneMappa
            this.mappa = mappa;

            griglia = new PictureBox[3, 5]{ { cell1, cell2, cell3, cell4, cell5 },
                                          { cell6, cell7, cell8, cell9, cell10 },
                                          { cell11, cell12, cell13, cell14, cell15 } };

            luoghi = new Label[3, 5] { { luogo1, luogo2, luogo3, luogo4, luogo5},
                                       { luogo6, luogo7, luogo8, luogo9, luogo10},
                                       { luogo11, luogo12, luogo13, luogo14, luogo15}};

            //Materiale sottostante
            for (int i = 0; i < griglia.GetLength(0); i++)
            {
                for (int j = 0; j < griglia.GetLength(1); j++)
                {
                    if (mappa.CelleMateriali[i, j] == "COMUNI")
                    {
                        griglia[i, j].BackgroundImage = Properties.Resources.comuni;
                    }
                    else if (mappa.CelleMateriali[i, j] == "PREZIOSI")
                    {
                        griglia[i, j].BackgroundImage = Properties.Resources.prezioso;
                    }
                    else if (mappa.CelleMateriali[i, j] == "RARI")
                    {
                        griglia[i, j].BackgroundImage = Properties.Resources.rari;
                    }
                }
            }

            //Nomi città
            for (int i = 0; i < griglia.GetLength(0); i++)
            {
                for (int j = 0; j < griglia.GetLength(1); j++)
                {
                    luoghi[i, j].Text = mappa.CelleNomi[i, j];
                }
            }
            #endregion
        }

        #region IconaPlus_AggiungiEdificio
        private void OnMouseEnter(object sender, EventArgs e)
        {
            materialeTemp = ((PictureBox)sender).BackgroundImage;
            ((PictureBox)sender).BackgroundImage = Properties.Resources.plus;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = materialeTemp;
        }
        #endregion

        private void AggiungiEdificio(object sender, EventArgs e)
        {
            Console.WriteLine("Crea edificio su: " + ((PictureBox)sender).Name);
        }
    }
}
