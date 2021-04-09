using System;
using System.Collections.Generic;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Magazzino
{
	public class MagazzinoMateriali
	{
		public Oggetto MaterialeComune { get; set; }
		public Oggetto MaterialeRaro { get; set; }
		public Oggetto MaterialePrezioso { get; set; }

        public Dictionary<string, Oggetto> DizionarioMateriali { get; private set; } = ListaOggetti.DizionarioMateriali;
    }
}
