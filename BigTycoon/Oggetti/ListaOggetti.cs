using System;
using System.Collections.Generic;
using BigTycoon.Oggetti;

namespace BigTycoon.Oggetti
{
    /// <summary>
    /// Raccolta di liste che elencano gli oggetti del gioco
    /// </summary>
	public static class ListaOggetti
    {
        /// <summary>
        /// Dizionario che elenca le stringhe dei tipi di materiali e le associa al loro oggetto base
        /// </summary>
        public static Dictionary<string, Oggetto> DizionarioMateriali { get; private set; } = new Dictionary<string, Oggetto>
        {
            ["MaterialeComune"] = new Oggetto("MaterialeComune", 1),
            ["MaterialeRaro"] = new Oggetto("MaterialeRaro", 1),
            ["MaterialePrezioso"] = new Oggetto("MaterialePrezioso", 1),
        };
        /// <summary>
        /// Dizionario che elenca le stringhe dei tipi di prodotti e le associa al loro oggetto base
        /// </summary>
        public static Dictionary<string, Oggetto> DizionarioProdotti { get; private set; } = new Dictionary<string, Oggetto>
        {
            ["ProdottoComune"] = new Oggetto("ProdottoComune", 0 ),
            ["ProdottoRaro"] = new Oggetto("ProdottoRaro", 0 ),
            ["ProdottoPrezioso"] = new Oggetto("ProdottoPrezioso", 0 ),
            ["ProdottoComuneRaro"] = new Oggetto("ProdottoComuneRaro", 0 ),
            ["ProdottoComunePrezioso"] = new Oggetto("ProdottoComunePrezioso", 0 ),
            ["ProdottoRaroPrezioso"] = new Oggetto("ProdottoRaroPrezioso", 0 )
        };
    }
}
