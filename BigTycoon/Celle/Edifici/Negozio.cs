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

		public void CambiaProdottiVendita(string nome)
		{
            ProdottoInVendita = SlotProdotti.DizionarioProdotti.Keys.Where(key => key == nome).ToString();
		}

        protected override void Produci()
        {
            foreach (var ogg in SlotProdotti.DizionarioProdotti)
            {
                if (ogg.Key == ProdottoInVendita)
                {
                    //Possessore.Portafoglio.Soldi += ogg.Value.Valore;
                }
            }
        }
    }
}
