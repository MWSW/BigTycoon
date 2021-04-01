using System;
using BigTycoon.Oggetti;

namespace BigTycoon.Oggetti
{
	public abstract class ListaOggetti
	{
		public Oggetto MaterialeComune { get; set; }
		public Oggetto MaterialeRaro { get; set; }
		public Oggetto MaterialePrezioso { get; set; }
		public Oggetto ProdottoComune { get; set; }
		public Oggetto ProdottoRaro { get; set; }
		public Oggetto ProdottoPrezioso { get; set; }
		public Oggetto ProdottoComuneRaro { get; set; }
		public Oggetto ProdottoComunePrezioso { get; set; }
		public Oggetto ProdottoRaroPrezioso { get; set; }
	}
}
