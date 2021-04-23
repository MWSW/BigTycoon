using System.Linq;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
    public class Negozio : Edificio
    {
        public MagazzinoProdotti SlotProdotti { get; set; }
        public string ProdottoInVendita { get; set; }

        public Negozio(Giocatore gio) : base(gio)
        {
            SlotProdotti = new MagazzinoProdotti();

            Dipendenti = new Dipendenti(3, 3, 40);

            ProdottoInVendita = "";

            Prezzo = 3000;

            //test
            SlotProdotti.DizionarioProdotti["ProdottoComune"].Quantita = 10;
            SlotProdotti.DizionarioProdotti["ProdottoRaro"].Quantita = 10;
            SlotProdotti.DizionarioProdotti["ProdottoPrezioso"].Quantita = 10;

            SlotProdotti.DizionarioProdotti["ProdottoComuneRaro"].Quantita = 10;
            SlotProdotti.DizionarioProdotti["ProdottoComunePrezioso"].Quantita = 10;
            SlotProdotti.DizionarioProdotti["ProdottoRaroPrezioso"].Quantita = 10;
        }

        public void CambiaProdottiVendita(string nome)
        {
            /*ProdottoInVendita = SlotProdotti.DizionarioProdotti.Keys
                .Where(key => key == nome)
                .ToString();*/

            ProdottoInVendita = nome;
        }

        protected override void Produci()
        {
            if (ProdottoInVendita == null) return;

            var prod = SlotProdotti.DizionarioProdotti[ProdottoInVendita];

            if (prod.Quantita > 0)
            {
                prod.Quantita--;

                //Il guadagno lo applichiamo all'interno di Update
                //Possessore.portafogli.Soldi += prod.Valore;
            }

            SlotProdotti.DizionarioProdotti[ProdottoInVendita] = prod;
        }

        public override void CalcolaBilancio()
        {
            if (SlotProdotti.DizionarioProdotti.ContainsKey(ProdottoInVendita))
            {
                var ogg = SlotProdotti.DizionarioProdotti[ProdottoInVendita];

                Reddito = ogg.Valore;

                Bilancio = Reddito - Dipendenti.Stipendio;
            }
        }

        public override void AggiungiOggetto(Oggetto ogg)
        {
            if (SlotProdotti.DizionarioProdotti.Keys.Contains(ogg.Nome))
            {
                SlotProdotti.DizionarioProdotti[ogg.Nome].Quantita += ogg.Quantita;
            }
        }

        public override void RimuoviOggetto(Oggetto ogg)
        {
            if (SlotProdotti.DizionarioProdotti.Keys.Contains(ogg.Nome))
            {
                SlotProdotti.DizionarioProdotti[ogg.Nome].Quantita -= ogg.Quantita;
            }
        }

        protected override bool IsEdificioAttivo()
        {
            if (Dipendenti.Quantita < Dipendenti.MinimoDipendenti) return false;

            if (SlotProdotti.DizionarioProdotti.ContainsKey(ProdottoInVendita))
            {
                if (SlotProdotti.DizionarioProdotti[ProdottoInVendita].Quantita < 1) 
                    return false;
            }
            else
            {
                return false;
            }


            return true;
        }
    }
}
