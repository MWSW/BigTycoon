using System;
using System.Linq;
using BigTycoon.Generale;
using BigTycoon.GestioneDipendenti;

namespace BigTycoon.Celle.Edifici
{
    public abstract class Edificio
    {

        protected double Bilancio { get; set; }
        protected double Reddito { get; set; }
        protected int Produzione { get; set; }
        protected double Produttivita { get; set; }
        protected Dipendenti Dipendenti { get; set; }
        protected bool EdificioAttivo { get; set; }
        protected int ColoreFelicita { get; set; }
        protected int ColoreEdificio { get; set; }

        public Edificio()
        {//valori di prova
            Bilancio = 0;
            Reddito = 0;
            Produzione = 0;
            Produttivita = 0;
            EdificioAttivo = false;
            ColoreFelicita = 0;
            ColoreEdificio = 0;

            Dipendenti = new Dipendenti { };
        }

        public virtual void Update()
        {
            Produci();
        }

        protected abstract void Produci(Giocatore gio);
    }
}
