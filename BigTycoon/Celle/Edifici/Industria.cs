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

        //Serve pubblico per i vari controlli del form
        public string RisorsaTerreno { get; private set; }

        public Industria(Giocatore gio, string ogg) : base(gio)
        {
            SlotMateriali = new MagazzinoMateriali();
            RisorsaTerreno = ogg;

            Dipendenti = new Dipendenti(1, 8, 10);

            Prezzo = 500;
        }

        protected override void Produci()
        {
            var mater = SlotMateriali.DizionarioMateriali[RisorsaTerreno];

            if (RisorsaTerreno == null || mater.Quantita > ListaOggetti.DimMax) return;

            int punti = 0;

            //Crea materiale
            if (mater.Nome == RisorsaTerreno)
            {
                punti = CalcolaProduzione();
            }

            mater.Quantita += punti;
            PuntiProduzione = punti;

            SlotMateriali.DizionarioMateriali[RisorsaTerreno] = mater;
        }

        public override void CalcolaBilancio()
        {
            var ogg = SlotMateriali.DizionarioMateriali[RisorsaTerreno];

            Reddito = ogg.Valore * CalcolaProduzione();

            Bilancio = Reddito - Dipendenti.Stipendio;
        }

        private int CalcolaProduzione()
        {
            int punti = 0;

            int mid = Dipendenti.MassimoDipendenti / 2 + Dipendenti.MinimoDipendenti;

            // Aggiungo un numero di prodotti in base al numero di dipendenti
            if (Dipendenti.Quantita >= Dipendenti.MinimoDipendenti && Dipendenti.Quantita < mid)
            {
                punti = 1;
            }
            else
            if (Dipendenti.Quantita <= Dipendenti.MassimoDipendenti && Dipendenti.Quantita > mid)
            {
                punti = 3;
            }
            else
            {
                punti = 2;
            }

            return punti;
        }


        public override void AggiungiOggetto(Oggetto ogg)
        {
            if (!SlotMateriali.DizionarioMateriali.Keys.Contains(ogg.Nome)) return;

            SlotMateriali.DizionarioMateriali[ogg.Nome].Quantita += ogg.Quantita;
        }

        public override void RimuoviOggetto(Oggetto ogg)
        {
            if (!SlotMateriali.DizionarioMateriali.Keys.Contains(ogg.Nome)) return;

            SlotMateriali.DizionarioMateriali[ogg.Nome].Quantita -= ogg.Quantita;
        }

        protected override bool IsEdificioAttivo()
        {
            if (Dipendenti.Quantita < Dipendenti.MinimoDipendenti)
            {
                return false;
            }

            if (SlotMateriali.DizionarioMateriali[RisorsaTerreno].Quantita >= ListaOggetti.DimMax)
                return false;

            return true;
        }
    }
}
