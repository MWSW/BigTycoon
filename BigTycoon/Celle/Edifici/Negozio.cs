using System;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
	public class Negozio
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
	}
}
