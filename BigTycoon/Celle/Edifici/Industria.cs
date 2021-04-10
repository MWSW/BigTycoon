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
            if (risorsaTerreno == null) return;
            //Crea materiale
            foreach (var ogg in SlotMateriali.DizionarioMateriali)
            {
                if (ogg.Key == risorsaTerreno)
                {
                    ogg.Value.Quantita++;
                }
            }
        }
    }
}
