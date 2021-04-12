using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;
using System.Linq;

namespace BigTycoon.Celle.Edifici
{
    public class Fabbrica : Edificio
    {
        public MagazzinoProdotti SlotProdotti { get; set; }
        public MagazzinoMateriali SlotMateriali { get; set; }
        public string ProdottoCorrente { get; set; }

        public Fabbrica(Giocatore gio) : base(gio)
        {
            SlotProdotti = new MagazzinoProdotti();
            SlotMateriali = new MagazzinoMateriali();
        }

        public void CambiaProduzione(string nome)
        {
            ProdottoCorrente = SlotProdotti.DizionarioProdotti.Keys
                .Where(key => key == nome)
                .ToString();
        }

        /// <summary>
        /// Metodo che aggiunge 1 ProdottoCorrente al magazzino se ci sono abbastanza materiali
        /// </summary>
        protected override void Produci()
        {
            var prod = SlotProdotti.DizionarioProdotti[ProdottoCorrente]; // per accorciare le chiamate

            // se non ce un prodotto da produrre O il magazzino è al massimo salta tutto
            if (ProdottoCorrente == null || prod.Quantita > ListaOggetti.DimMax) return;

            // vedo se posso produrre
            if (IsDisponibile(ProdottoCorrente)) return;

            // rimuovo i materiali usati
            foreach (var comp in SlotProdotti.DizionarioProdotti[ProdottoCorrente].Componenti)
            {
                SlotMateriali.DizionarioMateriali[comp].Quantita--;
            }
            prod.Quantita++; // aggiungo il prodotto


            SlotProdotti.DizionarioProdotti[ProdottoCorrente] = prod; // aggiorno il magazzino
        }

        /// <summary>
        /// Controlla se e' possibile produrre il prodotto specificato
        /// </summary>
        /// <param name="key">Chiave del materiale da controllare</param>
        /// <returns></returns>
        internal bool IsDisponibile(string key)
        {
            // se la chiave è sbagliata ritorna falso
            if (!SlotProdotti.DizionarioProdotti.Keys.Contains(key)) return false;
            // itero tutti i componenti del materiale specificato
            foreach (var comp in SlotProdotti.DizionarioProdotti[key].Componenti)
            {
                // se non c'e' abbastanza materiale ritorno false
                if (SlotMateriali.DizionarioMateriali[comp].Quantita < 1)
                {
                    return false;
                }
            }
            // se tutti i controlli precedenti passano sono sicuro che il materiale e' nel magazzino
            return true;
        }
    }
}
