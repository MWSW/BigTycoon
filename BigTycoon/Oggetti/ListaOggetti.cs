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
        public static int DimMax { get; set; } = 99;
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
            ["ProdottoComune"] = new Oggetto("ProdottoComune", 0, "MaterialeComune"),
            ["ProdottoRaro"] = new Oggetto("ProdottoRaro", 0, "MaterialeRaro"),
            ["ProdottoPrezioso"] = new Oggetto("ProdottoPrezioso", 0, "MaterialePrezioso"),
            ["ProdottoComuneRaro"] = new Oggetto("ProdottoComuneRaro", 0, "MaterialeComune", "MaterialeRaro"),
            ["ProdottoComunePrezioso"] = new Oggetto("ProdottoComunePrezioso", 0, "MaterialeComune", "MaterialePrezioso"),
            ["ProdottoRaroPrezioso"] = new Oggetto("ProdottoRaroPrezioso", 0, "MaterialeRaro", "MaterialePrezioso")
        };

        //--------Clonazione

        /// <summary>
        /// Metodo che clona il DizionarioMateriali
        /// </summary>
        public static Dictionary<string, Oggetto> ClonaDizionarioMateriali() => new Dictionary<string, Oggetto>
        {
            ["MaterialeComune"] = new Oggetto("MaterialeComune", 1),
            ["MaterialeRaro"] = new Oggetto("MaterialeRaro", 1),
            ["MaterialePrezioso"] = new Oggetto("MaterialePrezioso", 1),
        };

        /// <summary>
        /// Metodo che clona il DizionarioProdotti
        /// </summary>
        public static Dictionary<string, Oggetto> ClonaDizionarioProdotti() => new Dictionary<string, Oggetto>
        {
            ["ProdottoComune"] = new Oggetto("ProdottoComune", 0, "MaterialeComune"),
            ["ProdottoRaro"] = new Oggetto("ProdottoRaro", 0, "MaterialeRaro"),
            ["ProdottoPrezioso"] = new Oggetto("ProdottoPrezioso", 0, "MaterialePrezioso"),
            ["ProdottoComuneRaro"] = new Oggetto("ProdottoComuneRaro", 0, "MaterialeComune", "MaterialeRaro"),
            ["ProdottoComunePrezioso"] = new Oggetto("ProdottoComunePrezioso", 0, "MaterialeComune", "MaterialePrezioso"),
            ["ProdottoRaroPrezioso"] = new Oggetto("ProdottoRaroPrezioso", 0, "MaterialeRaro", "MaterialePrezioso")
        };
    }
}
