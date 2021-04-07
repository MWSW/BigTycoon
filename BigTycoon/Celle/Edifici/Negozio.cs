using System;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
	public class Negozio : Edificio
	{
		public MagazzinoProdotti SlotProdotti { get; set; }
		public Oggetto ProdottoInVendita { get; set; }

		public Negozio()
		{
			SlotProdotti = new MagazzinoProdotti();
		}

		public void CambiaProdottiVendita()
		{

		}

        protected override void Produci(Giocatore gio)
        {
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoComune.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoComune.Valore;
            }
            else
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoRaro.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoRaro.Valore;
            }
            else
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoPrezioso.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoPrezioso.Valore;
            }
            else
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoComuneRaro.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoComuneRaro.Valore;
            }
            else
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoComunePrezioso.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoComunePrezioso.Valore;
            }
            else
            if (ProdottoInVendita.Nome.Equals(SlotProdotti.ProdottoRaroPrezioso.Nome))
            {
                gio.portafogli.Soldi += SlotProdotti.ProdottoRaroPrezioso.Valore;
            }
        }
    }
}
