using System;
using System.Collections.Generic;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Magazzino
{
	public class MagazzinoProdotti
	{
        public Dictionary<string, Oggetto> DizionarioProdotti { get; private set; }

        public MagazzinoProdotti()
        {
            DizionarioProdotti = ListaOggetti.DizionarioProdotti;
        }
    }
}
