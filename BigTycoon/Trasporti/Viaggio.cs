using System;
using BigTycoon.Celle.Edifici;
using BigTycoon.Oggetti;

namespace BigTycoon.Trasporti
{
	public class Viaggio
	{
		public Edificio Mittente { get; set; }
	    public Edificio Destinatario{ get; set; }
		public Oggetto[] Merce { get; set; }
		public int Costo { get; set; }
		public float DurataTotale { get; set; }
		public float DurataCorrente { get; set; }
		public bool Visible { get; set; }

		public Viaggio()
		{

		}

		public void DisegnaLinea()
        {

        }

		private void CalcolaCosto()
        {

        }

		public void Update()
        {

        }
	}
}
