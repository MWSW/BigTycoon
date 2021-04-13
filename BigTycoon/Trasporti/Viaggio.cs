using System;
using BigTycoon.Celle.Edifici;
using BigTycoon.Oggetti;

namespace BigTycoon.Trasporti
{
	public class Viaggio
	{
		public Edificio Mittente { get; set; }
	    public Edificio Destinatario{ get; set; }
		public Oggetto[] Vagoni { get; set; }
		public int CapacitaVagone { get; set; }
		public int CostoVagone { get; set; }
		public int Costo { get; set; }
		public float DurataTotale { get; set; }
		public float DurataCorrente { get; set; }
		public bool Visible { get; set; }
		public int Indice { get; set; }

		public Viaggio(Edificio mittente, Edificio destinatario, Oggetto[] merce, int nVagoni, int indice)
		{
			Vagoni = new Oggetto[nVagoni];
			Destinatario = destinatario;
			Mittente = mittente;
			Indice = indice;

			CapacitaVagone = 10;
			CostoVagone = 50;
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
