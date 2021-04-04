using System;
using BigTycoon.Celle.Magazzino;
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
	}
}
