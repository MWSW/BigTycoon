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

        public void Update()
        {
            CalcolaBilancio();
            CalcolaReddito();
            CalcolaSpese();
            CalcolaFamaAziendale();
        }

		private void CalcolaBilancio()
        {
            double tmpBilancio = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                if (edificio != null)
                {
                    tmpBilancio += edificio.Bilancio;
                }
            }
            portafogli.Bilancio = tmpBilancio;
        }

        private void CalcolaReddito()
        {
            double tmpReddito = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                if (edificio != null)
                {
                    tmpReddito += edificio.Reddito;
                }
            }

            portafogli.Reddito = tmpReddito;
        }

        private void CalcolaSpese()
        {
            double tmpSpese = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                if (edificio != null)
                {
                    tmpSpese += edificio.Reddito - edificio.Bilancio;
                }
            }

            portafogli.Spese = tmpSpese;
        }

        private void CalcolaFamaAziendale()
        {
            int tmp = 0;

            int dimensione = 0;
            foreach (var edificio in Program.Mappa.CelleEdifici)
            {
                if (edificio != null)
                {
                    tmp += edificio.PuntiFelicita;
                    dimensione++;
                }
            }

            if (dimensione > 0) //Per evitare la divisione per zero
                FamaAziendale = tmp / dimensione;
        }

		public void CalcolaDipendentiDisponibili()
        {
            // tanti if else per ogni tier
            
            //Se e' uguale a 5 non cambia nulla
            if (FamaAziendale > 5 && FamaAziendale < 6)
            {
                DipendentiDisponibili += 1;
            }
            else
            if (FamaAziendale >= 6 && FamaAziendale < 8)
            {
                DipendentiDisponibili += 2;
            }
            else
            if (FamaAziendale >= 6)
            {
                DipendentiDisponibili += 3;
            }
            else
            if (FamaAziendale < 5 && FamaAziendale > 4)
            {
                DipendentiDisponibili -= 1;
            }
            else
            if (FamaAziendale <= 4 && FamaAziendale > 2)
            {
                DipendentiDisponibili -= 2;
            }
            else
            if (FamaAziendale <= 2)
            {
                DipendentiDisponibili -= 3;
            }

            if(DipendentiDisponibili < 0)
            {
                System.Windows.Forms.MessageBox.Show("Hai...");
                System.Windows.Forms.MessageBox.Show("ROTTO!");
                System.Windows.Forms.MessageBox.Show("TUTTOOOOOO!!!!!!");
                System.Windows.Forms.MessageBox.Show("La societa' ti odia :<");
                Environment.Exit(-1);
            }
        }
	}
}

