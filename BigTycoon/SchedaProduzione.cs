using BigTycoon.Celle.Edifici;
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
    public partial class SchedaProduzione : Form
    {
        private Edificio edificio;
        int indice;

        public SchedaProduzione()
        {
            InitializeComponent();
        }

        public void CambiaEdificio(Edificio edificio)
        {
            this.edificio = edificio;
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            conferma_button.Visible = false;

            //Impedisce la distruzione dell'oggetto
            this.Hide();
            e.Cancel = true; 
        }

        private void conferma_button_Click(object sender, EventArgs e)
        {
            Fabbrica fab = (Fabbrica)edificio;

            switch(indice)
            {
                case 0:
                    fab.CambiaProduzione("ProdottoComune");
                    break;

                case 1:
                    fab.CambiaProduzione("ProdottoRaro");
                    break;

                case 2:
                    fab.CambiaProduzione("ProdottoPrezioso");
                    break;

                case 3:
                    fab.CambiaProduzione("ProdottoComuneRaro");
                    break;

                case 4:
                    fab.CambiaProduzione("ProdottoComunePrezioso");
                    break;

                case 5:
                    fab.CambiaProduzione("ProdottoRaroPrezioso");
                    break;
            }

            //Chiusura del form
            this.Close();
        }

        private void P_comune_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 0;
        }

        private void P_raro_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 1;
        }

        private void P_preziosi_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 2;
        }

        private void P_comuneRaro_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 3;
        }

        private void P_comunePrezioso_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 4;
        }

        private void P_raroPrezioso_Click(object sender, EventArgs e)
        {
            conferma_button.Visible = true;
            indice = 5;
        }
    }
}
