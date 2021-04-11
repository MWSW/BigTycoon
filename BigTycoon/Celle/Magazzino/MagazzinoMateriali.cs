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
            DizionarioMateriali = ListaOggetti.ClonaDizionarioMateriali();
        }

        public Oggetto GetElemento(string nome)
        {
            Oggetto oggetto;
            DizionarioMateriali.TryGetValue(nome, out oggetto);

            if (oggetto != null)
                return oggetto;
            else
                Console.WriteLine("Errore oggetto insensistente!");
                return null;
        }
    }
}
