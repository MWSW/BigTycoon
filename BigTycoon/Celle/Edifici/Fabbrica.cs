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

            Prezzo = 1000;

            //inizializzazione
            ProdottoCorrente = "";

            //test
            SlotMateriali.DizionarioMateriali["MaterialeComune"].Quantita = 10;
            SlotMateriali.DizionarioMateriali["MaterialeRaro"].Quantita = 10;
            SlotMateriali.DizionarioMateriali["MaterialePrezioso"].Quantita = 10;
        }

        public void CambiaProduzione(string nome)
        {
            /*ProdottoCorrente = SlotProdotti.DizionarioProdotti.Keys
                .Where(key => key == nome)
                .ToString();*/

            ProdottoCorrente = nome;
        }

        /// <summary>
        /// Metodo che aggiunge 1 ProdottoCorrente al magazzino se ci sono abbastanza materiali
        /// </summary>
        protected override void Produci()
        {

            // se non c'è un prodotto da produrre salta tutto
            if (ProdottoCorrente == null) return;

            var prod = SlotProdotti.DizionarioProdotti[ProdottoCorrente]; // per accorciare le chiamate

            // se il magazzino è al massimo salta tutto
            if (prod.Quantita > ListaOggetti.DimMax) return;

            // vedo se posso produrre
            if (!IsDisponibile(ProdottoCorrente)) return;

            // rimuovo i materiali usati
            foreach (var comp in SlotProdotti.DizionarioProdotti[ProdottoCorrente].Componenti)
            {
                SlotMateriali.DizionarioMateriali[comp].Quantita--;
            }

            int punti = CalcolaProduzione();
            PuntiProduzione = punti;

            prod.Quantita += punti; // aggiungo il prodotto


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

        private int CalcolaProduzione()
        {
            int punti = 0;

            int mid = Dipendenti.MassimoDipendenti / 2 + Dipendenti.MinimoDipendenti;

            // Aggiungo un numero di prodotti in base al numero di dipendenti
            if (Dipendenti.Quantita >= Dipendenti.MinimoDipendenti && Dipendenti.Quantita < mid)
            {
                punti = 1;
            }
            else
            if (Dipendenti.Quantita <= Dipendenti.MassimoDipendenti && Dipendenti.Quantita > mid)
            {
                punti = 3;
            }
            else
            {
                punti = 2;
            }

            return punti;
        }

        /// <summary>
        /// Aggiunge un oggetto nel magazzino. il magazzino è rilevato automaticamente
        /// </summary>
        /// <param name="ogg">Oggetto da aggiungere al magazzino</param>
        public override void AggiungiOggetto(Oggetto ogg)
        {
            if (SlotMateriali.DizionarioMateriali.Keys.Contains(ogg.Nome))
            {
                SlotMateriali.DizionarioMateriali[ogg.Nome].Quantita += ogg.Quantita;
            }
            else
            if (SlotProdotti.DizionarioProdotti.Keys.Contains(ogg.Nome))
            {
                SlotProdotti.DizionarioProdotti[ogg.Nome].Quantita += ogg.Quantita;
            }
        }

        /// <summary>
        /// Calcola il bilancio con lo stipendio e il valore dei prodotti
        /// </summary>
        public override void CalcolaBilancio()
        {
            var ogg = SlotProdotti.DizionarioProdotti[ProdottoCorrente];

            Reddito = ogg.Valore * CalcolaProduzione();

            Bilancio = Reddito - Dipendenti.Stipendio;
        }

        /// <summary>
        /// Controlla se l'edificio ha abbastanza dipendenti o materiali per produrre
        /// </summary>
        /// <returns></returns>
        protected override bool IsEdificioAttivo()
        {
            if (Dipendenti.Quantita < Dipendenti.MinimoDipendenti) return false;

            if (!IsDisponibile(ProdottoCorrente)) return false;

            if (SlotProdotti.DizionarioProdotti[ProdottoCorrente].Quantita >= ListaOggetti.DimMax)
                return false;

            return true;
        }
    }
}
