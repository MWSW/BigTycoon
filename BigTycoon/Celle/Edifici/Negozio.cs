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
        }

        public override void Update()
        {
            base.Update();
        }

        public void CambiaProdottiVendita(string nome)
        {
            ProdottoInVendita = SlotProdotti.DizionarioProdotti.Keys
                .Where(key => key == nome)
                .ToString();
        }

        protected override void Produci()
        {
            if (ProdottoInVendita == null) return;

            var prod = SlotProdotti.DizionarioProdotti[ProdottoInVendita];

            if (prod.Quantita > 0)
            {
                prod.Quantita--;
                Possessore.portafogli.Soldi += prod.Valore;
            }

            SlotProdotti.DizionarioProdotti[ProdottoInVendita] = prod;
        }

        protected override void CalcolaBilancio()
        {
            var ogg = SlotProdotti.DizionarioProdotti[ProdottoInVendita];

            Possessore.portafogli.Soldi += ogg.Valore * ogg.Quantita - Dipendenti.Stipendio;
        }

        public override void AggiungiOggetto(Oggetto ogg)
        {
            if (SlotProdotti.DizionarioProdotti.Keys.Contains(ogg.Nome))
            {
                SlotProdotti.DizionarioProdotti[ogg.Nome].Quantita += ogg.Quantita;
            }
        }

        protected override bool IsEdificioAttivo()
        {
            if (Dipendenti.Quantita < Dipendenti.MinimoDipendenti) return false;

            if (SlotProdotti.DizionarioProdotti[ProdottoInVendita].Quantita < 1) return false;

            return true;
        }
    }
}
