using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;
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

            Dipendenti = new Dipendenti(2, 6, 30);
        }

        public void CambiaProduzione(string nome)
        {
            ProdottoCorrente = SlotProdotti.DizionarioProdotti.Keys
                .Where(key => key == nome)
                .ToString();
        }

        protected override void Produci()
        {

            // se non c'è un prodotto da produrre salta tutto
            if (ProdottoCorrente == null) return;

            var prod = SlotProdotti.DizionarioProdotti[ProdottoCorrente]; // per accorciare le chiamate

            // se il magazzino è al massimo salta tutto
            if (prod.Quantita > ListaOggetti.DimMax) return;

            bool contains = false; // flag per mantenere la conoscenza della ricerca dei materiali

            // itero attraverso tutti i componenti del prod. corrente e controllo se ce ne' abbastanza nel magazzino materiali
            foreach (var comp in SlotProdotti.DizionarioProdotti[ProdottoCorrente].Componenti)
            {
                // se c'e' abbastanza materiale metto la flag a true altrimenti la rimetto a false
                if (SlotMateriali.DizionarioMateriali[comp].Quantita > 0) contains = true;

                else contains = false;
            }

            // se il magazzino contiene tutti i materiali necessari eseguo la produzione
            if (contains)
            {
                // rimuovo i materiali usati
                foreach (var comp in SlotProdotti.DizionarioProdotti[ProdottoCorrente].Componenti)
                {
                    SlotMateriali.DizionarioMateriali[comp].Quantita--;
                }
                prod.Quantita++; // aggiungo il prodotto
            }

            SlotProdotti.DizionarioProdotti[ProdottoCorrente] = prod; // aggiorno il magazzino
        }
    }
}
