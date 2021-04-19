using System.Linq;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
    public class Industria : Edificio
    {
        public MagazzinoMateriali SlotMateriali { get; set; }
        private string risorsaTerreno;

        public Industria(Giocatore gio, string ogg) : base(gio)
        {
            SlotMateriali = new MagazzinoMateriali();
            risorsaTerreno = ogg;
        }

        protected override void Produci()
        {
            var mater = SlotMateriali.DizionarioMateriali[risorsaTerreno];

            if (risorsaTerreno == null || mater.Quantita > ListaOggetti.DimMax) return;
            //Crea materiale
            if (mater.Nome == risorsaTerreno)
            {
                mater.Quantita++;
            }

            SlotMateriali.DizionarioMateriali[risorsaTerreno] = mater;
        }

        protected override void CalcolaBilancio()
        {
            var ogg = SlotMateriali.DizionarioMateriali[risorsaTerreno];

            Reddito = ogg.Valore * ogg.Quantita;

            Bilancio = Reddito - Dipendenti.Stipendio;
        }

        public override void AggiungiOggetto(Oggetto ogg)
        {
            if (!SlotMateriali.DizionarioMateriali.Keys.Contains(ogg.Nome)) return;

            SlotMateriali.DizionarioMateriali[ogg.Nome].Quantita += ogg.Quantita;
        }

        protected override bool IsEdificioAttivo()
        {
            if (Dipendenti.Quantita < Dipendenti.MinimoDipendenti)
            {
                return false;
            }

            return true;
        }
    }
}
