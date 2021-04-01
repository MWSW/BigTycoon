using System;
using BigTycoon.Celle.Edifici;
using BigTycoon.Generale;

namespace BigTycoon.Celle
{
	public class Mappa
	{
		public Edificio[] CelleEdifici { get; set; }
		public String[] CelleMateriali { get; set; }
		public String[] CelleNomi { get; set; }
		public int Dimensione { get; set; }

		public Mappa(String[] celleMateriali, String[] nomiCelle)
		{
			Dimensione = celleMateriali.Length;
			CelleEdifici = new Edificio[Dimensione];
			CelleMateriali = celleMateriali;
			CelleNomi = nomiCelle;
		}

		public void AggiungiEdificio(Portafoglio fenoglioIlPortafoglio)
        {

        }

		/*public void RimuoviEdificio()
        {

        }*/
	}
}
