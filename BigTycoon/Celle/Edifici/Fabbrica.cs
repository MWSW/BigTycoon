using System;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
	public class Fabbrica : Edificio
	{
		public MagazzinoProdotti SlotProdotti { get; set; }
		public MagazzinoMateriali SlotMateriali { get; set; }
		public Oggetto ProdottoCorrente { get; set; }

		public Fabbrica()
		{
			SlotProdotti = new MagazzinoProdotti();
			SlotMateriali = new MagazzinoMateriali();
		}

		public void CambiaProduzione()
        {

        }

		private void CreaProdotto()
		{

		}

        protected override void Produci(Giocatore gio)
        {
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoComune.Nome))
            {
                SlotProdotti.ProdottoComune.Quantita++;
            }
            else
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoRaro.Nome))
            {
                SlotProdotti.ProdottoRaro.Quantita++;
            }
            else
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoPrezioso.Nome))
            {
                SlotProdotti.ProdottoPrezioso.Quantita++;
            }
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoComuneRaro.Nome))
            {
                SlotProdotti.ProdottoComuneRaro.Quantita++;
            }
            else
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoComunePrezioso.Nome))
            {
                SlotProdotti.ProdottoComunePrezioso.Quantita++;
            }
            else
            if (ProdottoCorrente.Nome.Equals(SlotProdotti.ProdottoRaroPrezioso.Nome))
            {
                SlotProdotti.ProdottoRaroPrezioso.Quantita++;
            }
        }
    }
}
