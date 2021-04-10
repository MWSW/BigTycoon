﻿using System;

namespace BigTycoon.Generale
{
    public struct Portafoglio
    {
        public double Soldi { get; set; }
        public double Debito { get; set; } //però esiste la classe banca ~Emanuele

        public Portafoglio(double soldi, double debito)
        {
            Soldi = soldi;
            Debito = debito;
        }
    }
}
