using System.Linq;
using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
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
            throw new System.NotImplementedException();
        }

        public override void AggiungiOggetto(Oggetto ogg)
        {
            throw new System.NotImplementedException();
        }

        protected override bool IsEdificioAttivo()
        {
            throw new System.NotImplementedException();
        }
    }
}
