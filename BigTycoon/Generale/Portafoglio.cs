using System;

namespace BigTycoon.Generale
{
    public struct Portafoglio
    {
        public double Soldi { get; set; }
        public double Bilancio { get; set; }

        public double Reddito { get; set; }

        public double Spese { get; set; }

        public Portafoglio(double soldi)
        {
            Soldi = soldi;
            Bilancio = 0;
            Reddito = 0;
            Spese = 0;
        }
    }
}
