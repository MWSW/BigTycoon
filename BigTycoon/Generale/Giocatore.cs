using System;

namespace BigTycoon.Generale
{
	public class Giocatore
	{
		public Portafoglio portafogli;		//lo struct non può essere una proprietà
		public int FamaAziendale { get; set; }
		public int DipendentiDisponibili { get; set; }

		public Giocatore(int soldiIniziali, int famaIniziale, int dipendentiDisponibili)
		{
			portafogli.Soldi = soldiIniziali;
            portafogli.Debito = 0;
			FamaAziendale = famaIniziale;
			DipendentiDisponibili = dipendentiDisponibili;
		}

		public Portafoglio getPortafogli()
        {
			return portafogli;
        }

		private void CalcolaBilancio()
        {

        }

		private void CalcolaDebito()
        {

        }

		private void CalcolaFamaAziendale()
        {

        }

		private void CalcolaDipendentiDisponibili()
        {

        }
	}
}

