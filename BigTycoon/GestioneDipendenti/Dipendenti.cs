using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BigTycoon.GestioneDipendenti
{
	public struct Dipendenti
	{
		public int Quantita { get; private set; }
		public int Minimo { get; set; }
		public int Massimo { get; set; }
		public double Stipendi { get; private set; }
		public int StipendioBase { get; set; }
        public int Felicita { get; private set; }

        public void ModStipendi(double percentuale)
        {
            if (!((Stipendi < Minimo) || (Stipendi > Massimo) || (percentuale < 0.5) || (percentuale > 2.0)))
            {
                Trace.WriteLine($"Percentuale non corretta ({percentuale}) o stipendio massimo/minimo raggiunto ({Minimo}/{Stipendi}/{Massimo})");
                return;
            }
            Stipendi *= percentuale;
        }

        public void AumentaFelicita(int n)
        {
            Felicita += n;
        }

        public void DiminuisciFelicita(int n)
        {
            Felicita -= n;
        }
    }
}
