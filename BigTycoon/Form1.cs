using BigTycoon.Celle;
using BigTycoon.Celle.Edifici;
using BigTycoon.Generale;
using BigTycoon.Oggetti;
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

        //crea edificio
        int r_selezionato, c_selezionato; //coordinate nella griglia
        int tipo;
        Image iconaSelezionata;

        //gestione edifici
        Edificio edificioSelezionato;


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
            for (int j = 0; j < griglia.GetLength(1); j++)
            {
                for (int i = 0; i < griglia.GetLength(0); i++)
                {
                    if (mappa.CelleMateriali[i, j] == "MaterialeComune")
                    {
                        griglia[i, j].BackgroundImage = Properties.Resources.comuni;
                    }
                    else if (mappa.CelleMateriali[i, j] == "MaterialePrezioso")
                    {
                        griglia[i, j].BackgroundImage = Properties.Resources.preziosi;
                    }
                    else if (mappa.CelleMateriali[i, j] == "MaterialeRaro")
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

        #region Timer
        private void EdificiUpdate(object sender, EventArgs e)
        {
            mappa.UpdateAll();
            AggiornaInfoGrafiche();
        }
        #endregion


        #region MetodiVari
        bool CellaVuota(PictureBox immagine)
        {
            //estraggo il numero della cella
            int indice = int.Parse(immagine.Name.Substring(4));
            indice--; //perchè i nomi sono conteggiati partendo da 1

            //partendo dalla formula
            //[width*y]+x = indice
            //y = (indice - x) / width

            //calcolo le coordinate
            int c = indice % mappa.Colon;
            int r = (indice - c) / mappa.Colon;

            return mappa.CelleEdifici[r,c] == null;
        }

        void Reset()
        {
            //icone base
            industria_bottone.Image = Properties.Resources.industria_BN;
            fabbrica_bottone.Image = Properties.Resources.fabbrica_BN;
            negozio_bottone.Image = Properties.Resources.negozio_BN;

            //nascondi bottoni
            costruisci_bottone.Visible = false;

            //nascondo i pannelli
            crea_edificio_panel.Visible = false;
            gestioneEdificio_panel.Visible = false;
        }

        void AggiornaInfoGrafiche()
        {
            if (edificioSelezionato != null)
            {
                indicatoreDipendenti.Text = edificioSelezionato.Dipendenti.Quantita + "/" + edificioSelezionato.Dipendenti.MassimoDipendenti;
                indicatoreFelicita.Text = "+" + edificioSelezionato.PuntiFelicita;

                richiesteLavoro_label.Text = "Richieste lavoro: " + giocatore.DipendentiDisponibili;

                if (gestioneEdificio_panel.Visible)
                {
                    stipendiPerc_label.Text = edificioSelezionato.Dipendenti.StipendiPerc + "%";

                    guadagnoEdificio.Text = "GUADAGNO " + edificioSelezionato.Bilancio + "$";
                    lordoEdificio.Text = "LORDO " + edificioSelezionato.Reddito + "$";

                    //Magazzino (GUI)
                    if (edificioSelezionato.GetType() == typeof(Industria))
                    {
                        Industria industria = (Industria)edificioSelezionato;
                        comuni_numero.Text = industria.SlotMateriali.GetElemento("MaterialeComune").Quantita.ToString();
                        rari_numero.Text = industria.SlotMateriali.GetElemento("MaterialeRaro").Quantita.ToString();
                        preziosi_numero.Text = industria.SlotMateriali.GetElemento("MaterialePrezioso").Quantita.ToString();
                    }
                    else if (edificioSelezionato.GetType() == typeof(Fabbrica))
                    {
                        edificioSelezionato_label.Text += "Fabbrica di ";
                    }
                    else if (edificioSelezionato.GetType() == typeof(Negozio))
                    {
                        edificioSelezionato_label.Text += "Negozio di ";
                    }
                }
            }
        }
        #endregion

        #region IconaPlus_AggiungiEdificio
        private void OnMouseEnter(object sender, EventArgs e)
        {
            //solo se la cella è vuota
            if (CellaVuota((PictureBox)sender))
            {
                materialeTemp = ((PictureBox)sender).BackgroundImage;
                ((PictureBox)sender).BackgroundImage = Properties.Resources.plus;
            }
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            //solo se la cella è vuota
            if (CellaVuota((PictureBox)sender))
            {
                ((PictureBox)sender).BackgroundImage = materialeTemp;
            }
        }
        #endregion

        //Numero dipendenti/////////////////
        private void incDipendenti_bottone_Click(object sender, EventArgs e)
        {
            edificioSelezionato.Dipendenti.AggiungiDipendenti(giocatore);

            AggiornaInfoGrafiche();
        }

        private void dimDipendenti_bottone_Click(object sender, EventArgs e)
        {
            edificioSelezionato.Dipendenti.RimuoviDipendenti(giocatore);

            AggiornaInfoGrafiche();
        }
        ////////////////////////////////////
        

        //Gestione stipendi ////////////////
        private void incStipendi_button_Click(object sender, EventArgs e)
        {
            edificioSelezionato.Dipendenti.ModStipendi(10);

            AggiornaInfoGrafiche();
        }

        private void dimStipendi_button_Click(object sender, EventArgs e)
        {
            edificioSelezionato.Dipendenti.ModStipendi(-10);

            AggiornaInfoGrafiche();
        }
        //////////////////////////////////

        #region CreaEdificio
        private void industria_bottone_Click(object sender, EventArgs e)
        {
            tipo = 0;
            costruisci_bottone.Visible = true;

            industria_bottone.Image = Properties.Resources.industria;
            fabbrica_bottone.Image = Properties.Resources.fabbrica_BN;
            negozio_bottone.Image = Properties.Resources.negozio_BN;

            iconaSelezionata = Properties.Resources.industria;

        }

        private void fabbrica_bottone_Click(object sender, EventArgs e)
        {
            tipo = 1;
            costruisci_bottone.Visible = true;

            industria_bottone.Image = Properties.Resources.industria_BN;
            fabbrica_bottone.Image = Properties.Resources.fabbrica;
            negozio_bottone.Image = Properties.Resources.negozio_BN;

            iconaSelezionata = Properties.Resources.fabbrica;
        }

        private void negozio_bottone_Click(object sender, EventArgs e)
        {
            tipo = 2;
            costruisci_bottone.Visible = true;

            industria_bottone.Image = Properties.Resources.industria_BN;
            fabbrica_bottone.Image = Properties.Resources.fabbrica_BN;
            negozio_bottone.Image = Properties.Resources.negozio;

            iconaSelezionata = Properties.Resources.negozio;
        }

        private void SelezionaCella(object sender, EventArgs e)
        {
            Reset();

            PictureBox cellaSelezionata = (PictureBox)sender;

            //estraggo il numero della cella
            int indice = int.Parse(cellaSelezionata.Name.Substring(4));
            indice--; //perchè i nomi sono conteggiati partendo da 1

            //calcolo le coordinate
            c_selezionato = indice % mappa.Colon;
            r_selezionato = (indice - c_selezionato) / mappa.Colon;

            if (CellaVuota(cellaSelezionata))
            {
                //rendi visibile il pannello
                crea_edificio_panel.Visible = true;

                cellaSelezionata_label.Text = "CELLA SELEZIONATA: " + mappa.CelleNomi[r_selezionato, c_selezionato];
            }
            else
            {
                //rendi visibile il pannello
                gestioneEdificio_panel.Visible = true;

                edificioSelezionato_label.Text = "";

                //Tipo di edificio
                edificioSelezionato = mappa.CelleEdifici[r_selezionato, c_selezionato];
                if (edificioSelezionato.GetType() == typeof(Industria))
                {
                    edificioSelezionato_label.Text += "Industria di ";
                }
                else if (edificioSelezionato.GetType() == typeof(Fabbrica))
                {
                    edificioSelezionato_label.Text += "Fabbrica di ";
                }
                else if (edificioSelezionato.GetType() == typeof(Negozio))
                {
                    edificioSelezionato_label.Text += "Negozio di ";
                }

                //Nome edificio
                edificioSelezionato_label.Text += mappa.CelleNomi[r_selezionato, c_selezionato];

                AggiornaInfoGrafiche();
            }
        }

        private void costruisci_bottone_Click(object sender, EventArgs e)
        {
            mappa.AggiungiEdificio(r_selezionato, c_selezionato, tipo, giocatore);

            //immagine
            if (tipo == 0) //tipo industria
            {
                if(mappa.CelleMateriali[r_selezionato,c_selezionato] == "MaterialeComune")
                {
                    griglia[r_selezionato, c_selezionato].BackgroundImage = Properties.Resources.industria_comuni;
                }
                else if (mappa.CelleMateriali[r_selezionato, c_selezionato] == "MaterialeRaro")
                {
                    griglia[r_selezionato, c_selezionato].BackgroundImage = Properties.Resources.industria_rari;
                }
                else if (mappa.CelleMateriali[r_selezionato, c_selezionato] == "MaterialePrezioso")
                {
                    griglia[r_selezionato, c_selezionato].BackgroundImage = Properties.Resources.industria_preziosi;
                }
            }
            else
            {
                griglia[r_selezionato, c_selezionato].BackgroundImage = iconaSelezionata;
            }

            Reset();
        }
    }
    #endregion
}
