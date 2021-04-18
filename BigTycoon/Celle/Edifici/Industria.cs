using System.Linq;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
    public class Industria : Edificio
    {
        public MagazzinoMateriali SlotMateriali { get; set; }
        public string RisorsaTerreno { get; private set; }

        public Industria(Giocatore gio, string ogg) : base(gio)
        {
            SlotMateriali = new MagazzinoMateriali();
            RisorsaTerreno = ogg;

            Dipendenti = new Dipendenti(3, 8, 20);
        }

        protected override void Produci()
        {
            var mater = SlotMateriali.DizionarioMateriali[RisorsaTerreno];

            if (RisorsaTerreno == null || mater.Quantita > ListaOggetti.DimMax) return;
            //Crea materiale
            if (mater.Nome == RisorsaTerreno)
            {
                mater.Quantita++;
            }
        }

        protected override void CalcolaBilancio()
        {
            var ogg = SlotMateriali.DizionarioMateriali[RisorsaTerreno];

            Possessore.portafogli.Soldi += ogg.Valore * ogg.Quantita - Dipendenti.Stipendio;
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
