using System;

namespace BigTycoon.Generale
{
	public class Banca
	{
		public double SoldiPrestati { get; set; }
		public double SogliaSoldi { get; set; }
		public double Interesse { get; set; }
		public int TurnoLimite { get; set; }
        public double Debito { get; set; }

		public Banca(int turnoLimite)
		{
			SoldiPrestati = 0;
            Debito = 0;
			//SogliaSoldi = ;
			Interesse = 0;
			TurnoLimite = turnoLimite;
		}

		public void PrestaSoldi()
        {

        }

		public void RestituisciSoldi()
        {

        }

		public void MandaArthur()		//(hai perso)
        {

        }

        private void CalcolaDebito()
        {
            
        }

        public void Update()
        {

        }
	}
}
