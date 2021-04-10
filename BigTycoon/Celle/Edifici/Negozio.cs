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

            SlotProdotti.DizionarioProdotti
                .Where(ogg => ogg.Key == ProdottoInVendita)
                .Select(ogg => Possessore.portafogli.Soldi += ogg.Value.Valore);

            /*
            foreach (var ogg in SlotProdotti.DizionarioProdotti)
            {
                if (ogg.Key == ProdottoInVendita)
                {
                    Possessore.portafogli.Soldi += ogg.Value.Valore;
                }
            }*/
        }
    }
}
