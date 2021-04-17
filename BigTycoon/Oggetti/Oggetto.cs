using System;

namespace BigTycoon.Oggetti
{
    public class Oggetto
    {
        private string nome;
        private int quantita;
        private double valore;
        private string[] componenti;

        public Oggetto(string nome, double valore, params string[] componenti)
        {
            Nome = nome;
            Valore = valore;
            Quantita = 0;
            Componenti = componenti;
        }

        public string Nome { get => nome; set => nome = value; }
        public int Quantita {
            get => quantita; 
            set {
                if (quantita > ListaOggetti.DimMax)
                {
                    quantita = ListaOggetti.DimMax;
                }
                else quantita = value;
            }
        }
        public double Valore { get => valore; set => valore = value; }
        public string[] Componenti { get => componenti; set => componenti = value; }
    }
}
