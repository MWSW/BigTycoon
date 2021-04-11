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
            DizionarioProdotti = ListaOggetti.ClonaDizionarioProdotti();
        }

        public Oggetto GetElemento(string nome)
        {
            Oggetto oggetto;
            DizionarioProdotti.TryGetValue(nome, out oggetto);

            if (oggetto != null)
                return oggetto;
            else
                Console.WriteLine("Errore oggetto insensistente!");
            return null;
        }
    }
}
