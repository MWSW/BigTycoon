using System;
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
            FamaAziendale = tmp / Program.Mappa.CelleEdifici.Length;
        }

		private void CalcolaDipendentiDisponibili()
        {
            int max = 10;
            int inc = 2;

            Func<int, int> op = n => {
                if (FamaAziendale < 5) n -= inc;
                else
                if (FamaAziendale >= 5) n += inc;

                return n;
            };

            bool done = false;
            int i = max / 2;

            while (!done)
            {
                if (FamaAziendale > i && FamaAziendale <= i + 2)
                {
                    DipendentiDisponibili += i / 2;
                    done = true;
                }

                i = op(i);
            }
        }
	}
}

