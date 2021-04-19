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
		public int Indice { get; set; }					//indice nel vettore di viaggi attivi

		private float unitaPercentuale;					//quantita per cui viene incrementata la percentuale di completamento

		public Viaggio(Edificio mittente, Edificio destinatario, Oggetto[] merce, int nVagoni, int indice, int durata)
		{
			Vagoni = new Oggetto[nVagoni];
			Destinatario = destinatario;
			Mittente = mittente;
			Indice = indice;
			DurataTotale = durata;

			unitaPercentuale = DurataTotale / 100;
			CapacitaVagone = 10;
			CostoVagone = 50;
			DurataCorrente = 0;
		}

		public void DisegnaLinea()
        {

        }

		private void CalcolaCosto()
        {

        }

		public void Update()									//aggiorna la percentuale di completamento dei ogni viaggio
		{
			DurataCorrente += unitaPercentuale;
		}
	}
}
