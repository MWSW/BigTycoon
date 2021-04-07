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

        public Industria(string ogg)
        {
            SlotMateriali = new MagazzinoMateriali();
            risorsaTerreno = ogg;
        }

        private void CreaMateriale()
        {
            //
        }

        protected override void Produci(Giocatore gio)
        {
            if (risorsaTerreno.Equals(SlotMateriali.MaterialeComune.Nome))
            {
                SlotMateriali.MaterialeComune.Quantita++;
            }
            else
            if (risorsaTerreno.Equals(SlotMateriali.MaterialeRaro.Nome))
            {
                SlotMateriali.MaterialeRaro.Quantita++;
            }
            else
            if (risorsaTerreno.Equals(SlotMateriali.MaterialePrezioso.Nome))
            {
                SlotMateriali.MaterialePrezioso.Quantita++;
            }
        }
    }
}
