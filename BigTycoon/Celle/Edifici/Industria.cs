using System;
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

        }
    }
}
