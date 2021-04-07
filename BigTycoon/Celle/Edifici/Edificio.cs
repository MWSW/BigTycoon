using System;
using System.Linq;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;

namespace BigTycoon.Celle.Edifici
{
    public abstract class Edificio
    {

        public double Bilancio { get; protected set; }
        public double Reddito { get; protected set; }
        protected int Produzione { get; set; }
        protected double Produttivita { get; set; }
        public Dipendenti Dipendenti { get; protected set; }
        protected bool EdificioAttivo { get; set; }
        public int PuntiFelicita { get; protected set; }
        protected int ColoreEdificio { get; set; }

        public Edificio()
        {//valori di prova
            Bilancio = 0;
            Reddito = 0;
            Produzione = 0;
            Produttivita = 0;
            EdificioAttivo = false;
            PuntiFelicita = 0;
            ColoreEdificio = 0;

            Dipendenti = new Dipendenti(0, 4, 20);

        }

        public virtual void Update(Giocatore giocatore)
        {
            Produci(giocatore);
        }

        protected abstract void Produci(Giocatore gio);
    }
}
