using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigTycoon.Celle.Edifici;
using BigTycoon.Oggetti;
using BigTycoon.Trasporti;

namespace BigTycoon
{
    public partial class CreazioneViaggio : Form
    {
        private double costo;
        private int quantitaOggetti;
        private int nVagoni;
        private GestioneTrasporti gestioneTrasporti;
        public string NomeMittente { get; set; }
        public string NomeDestinatario { get; set; }
        public List<Oggetto> merce { get; set; }
        public Edificio Mittente { get; set; }
        public Edificio Destinatario { get; set; }

        public CreazioneViaggio(GestioneTrasporti gestioneTrasporti)
        {
            InitializeComponent();
            this.gestioneTrasporti = gestioneTrasporti;
            merce = new List<Oggetto>();
        }

        private void UpdateCosto(object sender, EventArgs e)
        {
            string nome;
            costo = 100;
            quantitaOggetti = 0;
            if (Mittente.GetType() == typeof(Fabbrica))
            {
                Fabbrica tempFabbrica = (Fabbrica)Mittente;
                
                foreach (var item in tempFabbrica.SlotProdotti.DizionarioProdotti)
                {
                    nome = item.Key + "_coso";
                    var coso = (NumericUpDown)this.Controls[nome];
                    if ((int)coso.Value <= item.Value.Quantita)
                    {
                        quantitaOggetti += (int)coso.Value;
                    }
                    else
                    {
                        coso.Value = item.Value.Quantita;
                    }
                }
                foreach (var item in ListaOggetti.DizionarioMateriali)
                {
                    nome = item.Key + "_coso";
                    var coso = (NumericUpDown)this.Controls[nome];
                    coso.Value = 0;
                }
            }
            else
            {
                Industria tempIndustria = (Industria)Mittente;

                foreach (var item in tempIndustria.SlotMateriali.DizionarioMateriali)
                {
                    nome = item.Key + "_coso";
                    var coso = (NumericUpDown)this.Controls[nome];
                    if ((int)coso.Value <= item.Value.Quantita)
                    {
                        quantitaOggetti += (int)coso.Value;
                    }
                    else
                    {
                        coso.Value = item.Value.Quantita;
                    }
                }
                foreach (var item in ListaOggetti.DizionarioProdotti)
                {
                    nome = item.Key + "_coso";
                    var coso = (NumericUpDown)this.Controls[nome];
                    coso.Value = 0;
                }
            }

            nVagoni = (int)(quantitaOggetti / 10);
            costo += nVagoni * 50;

            costo_label.Text = "Costo: " + costo.ToString() + "$";
        }

        public void UpdateDirezione(string smittente, string sdestinatario)
        {
            direzione_label.Text = smittente + "   >>   " + sdestinatario;
        }

        public void UpdateMaxValue()//in base alla quantità nel magazzino del mittente
        {

        }

        private void conferma_button_Click(object sender, EventArgs e)
        {
            string nome;
            foreach (var item in ListaOggetti.DizionarioProdotti)
            {
                nome = item.Key + "_coso";
                var coso = (NumericUpDown)this.Controls[nome];

                Oggetto tempOggetto = item.Value;
                tempOggetto.Quantita = (int)coso.Value;
                merce.Add(tempOggetto);
            }

            foreach (var item in ListaOggetti.DizionarioMateriali)
            {
                nome = item.Key + "_coso";
                var coso = (NumericUpDown)this.Controls[nome];

                Oggetto tempOggetto = item.Value;
                tempOggetto.Quantita = (int)coso.Value;
                merce.Add(tempOggetto);
            }

            gestioneTrasporti.AggiungiViaggio(Mittente, Destinatario, merce.ToArray(), nVagoni, 0, 0, 0, 0);
            this.Hide();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            //Impedisce la distruzione dell'oggetto
            this.Hide();
            e.Cancel = true;
        }
    }
}
