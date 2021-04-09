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
            return;
        }
    }
}
