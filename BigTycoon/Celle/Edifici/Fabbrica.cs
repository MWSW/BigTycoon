using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;

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
            foreach (var ogg in ListaOggetti.DizionarioProdotti)
            {
                if (nome == ogg.Key)
                {
                    ProdottoCorrente = ogg.Key;
                }
            }
        }

        protected override void Produci()
        {
            //Crea capitale
            if (ProdottoCorrente == null) return;

            foreach (var ogg in ListaOggetti.DizionarioProdotti)
            {
                if (ProdottoCorrente == ogg.Key)
                {
                    ogg.Value.Quantita++;
                }
            }

        }
    }
}
