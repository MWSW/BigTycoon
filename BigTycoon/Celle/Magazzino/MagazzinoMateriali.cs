using System;
using System.Collections.Generic;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Magazzino
{
    public class MagazzinoMateriali
    {
        public Dictionary<string, Oggetto> DizionarioMateriali { get; private set; }

        public MagazzinoMateriali()
        {
            DizionarioMateriali = ListaOggetti.DizionarioMateriali;
        }
    }
}
