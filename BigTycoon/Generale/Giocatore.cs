using System.Linq;
using BigTycoon;

namespace BigTycoon.Generale
{
	public class Giocatore
	{
        internal Portafoglio portafogli; //lo struct non può essere una proprietà
        public int FamaAziendale { get; set; }
		public int DipendentiDisponibili { get; set; }

        public Giocatore(int soldiIniziali, int famaIniziale, int dipendentiDisponibili)
		{
            portafogli = new Portafoglio { Soldi = soldiIniziali};
			FamaAziendale = famaIniziale;
			DipendentiDisponibili = dipendentiDisponibili;
		}

		public Portafoglio getPortafogli()
        {
			return portafogli;
        }

		private void CalcolaBilancio()
        {
            double tmpBilancio = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                tmpBilancio += edificio.Bilancio;
            }
            portafogli.Bilancio = tmpBilancio;
        }

		private void CalcolaFamaAziendale()
        {
            int tmp = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                tmp += edificio.PuntiFelicita;
            }
            FamaAziendale = tmp;
        }

		private void CalcolaDipendentiDisponibili()
        {

        }
	}
}

