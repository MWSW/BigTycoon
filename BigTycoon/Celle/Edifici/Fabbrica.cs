using BigTycoon.Celle.Magazzino;
using BigTycoon.Generale;
using BigTycoon.Oggetti;

namespace BigTycoon.Celle.Edifici
{
    public class Fabbrica : Edificio
    {
        public MagazzinoProdotti SlotProdotti { get; set; }
        public MagazzinoMateriali SlotMateriali { get; set; }
        public Oggetto ProdottoCorrente { get; set; }

        public Fabbrica()
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
                    ProdottoCorrente = ogg.Value;
                }
            }
        }

        protected override void Produci()
        {
            //Crea capitale
            if (ProdottoCorrente != null)
            {
                foreach (var ogg in ListaOggetti.DizionarioProdotti)
                {
                    if (ProdottoCorrente.Nome == ogg.Key)
                    {
                        ProdottoCorrente.Quantita++;
                    }
                }
            }
        }
    }
}
