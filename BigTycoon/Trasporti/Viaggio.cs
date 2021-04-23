using System;
using BigTycoon.Celle.Edifici;
using BigTycoon.Oggetti;

namespace BigTycoon.Trasporti
{
	public class Viaggio
	{
		public Edificio Mittente { get; set; }			//edificio da cui è stato spedito il carico
	    public Edificio Destinatario{ get; set; }		//edificio a cui è destinato il carico
		public Oggetto[] Merce { get; set; }			//oggetti da trasportare
		public int CapacitaVagone { get; set; }			//numero di oggetti trasportabili da un vagone
		public int CostoVagone { get; set; }			//costo fisso per l'aggiunta di un vagone al treno
		public int Costo { get; set; }					//costo totale del viaggio
		public float DurataTotale { get; set; }			//durata del viaggio
		public float DurataCorrente { get; set; }		//percentuale di completamento del viaggio
		public bool Visible { get; set; }
		public int Indice { get; set; }					//indice nel vettore di viaggi attivi

		private float unitaPercentuale;					//quantita per cui viene incrementata la percentuale di completamento

		public Viaggio(Edificio mittente, Edificio destinatario, Oggetto[] merce, int nVagoni, int indice, int durata)
		{
			Merce = merce;
			Destinatario = destinatario;
			Mittente = mittente;
			Indice = indice;
			DurataTotale = durata;

			unitaPercentuale = DurataTotale / 100;
			CapacitaVagone = 10;
			CostoVagone = 50;
			DurataCorrente = 0;
			Costo = 100 + nVagoni * CostoVagone;
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
