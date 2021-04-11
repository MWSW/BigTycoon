using System;
using System.Linq;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;

namespace BigTycoon.Celle.Edifici
{
    public abstract class Edificio
    {
        protected Giocatore Possessore { get; set; }
        public double Bilancio { get; protected set; }
        public double Reddito { get; protected set; }
        protected int Produzione { get; set; }
        protected double Produttivita { get; set; }
        public Dipendenti Dipendenti { get; protected set; }
        public int PuntiFelicita { get; protected set; }
        protected int ColoreEdificio { get; set; }

        public Edificio(Giocatore gio)
        {//valori di prova
            Possessore = gio;
            Bilancio = 0;
            Reddito = 0;
            Produzione = 0;
            Produttivita = 0;
            PuntiFelicita = 0;
            ColoreEdificio = 0;
        }

        public virtual void Update()
        {
            Produci();
        }

        private void CalcolaBilancio()
        {
            //
        }

        public bool IsEdificioAttivo()
        {
            //numero minimo dipendenti 
            //TODO: magazzino
            return Dipendenti.Quantita >= Dipendenti.MinimoDipendenti;
        }

        protected abstract void Produci();
    }
}
