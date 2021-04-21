using System;

namespace BigTycoon.Generale
{
    public struct Portafoglio
    {
        public double Soldi { get; set; }
        public double Bilancio { get; set; }

        public Portafoglio(double soldi)
        {
            Soldi = soldi;
            Bilancio = 0;
        }
    }
}
