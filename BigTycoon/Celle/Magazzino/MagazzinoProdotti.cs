using System;
using System.Collections.Generic;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Magazzino
{
	public class MagazzinoProdotti
	{
		public Oggetto ProdottoComune { get; set; }
		public Oggetto ProdottoRaro { get; set; }
		public Oggetto ProdottoPrezioso { get; set; }
		public Oggetto ProdottoComuneRaro { get; set; }
		public Oggetto ProdottoComunePrezioso { get; set; }
		public Oggetto ProdottoRaroPrezioso { get; set; }

        public static Dictionary<string, Oggetto> DizionarioProdotti { get; private set; } = ListaOggetti.DizionarioProdotti;
    }
}
