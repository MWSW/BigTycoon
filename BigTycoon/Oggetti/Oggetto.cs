using System;

namespace BigTycoon.Oggetti
{
    public class Oggetto
    {
        public string Nome { get; set; }
        public int Quantita { get; set; }
        public double Valore { get; set; }
        public string[] Componenti { get; set; }

        public Oggetto(string nome, double valore, params string[] componenti)
        {
            Nome = nome;
            Valore = valore;
            Quantita = 0;
            Componenti = componenti;
        }
    }
}
