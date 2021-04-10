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

        private bool edificioAttivo;
        protected bool EdificioAttivo { get => edificioAttivo; set => IsEdificioAttivo(); }
        public int PuntiFelicita { get; protected set; }
        protected int ColoreEdificio { get; set; }

        public Edificio(Giocatore gio)
        {//valori di prova
            Possessore = gio;
            Bilancio = 0;
            Reddito = 0;
            Produzione = 0;
            Produttivita = 0;
            EdificioAttivo = false;
            PuntiFelicita = 0;
            ColoreEdificio = 0;
            Dipendenti = new Dipendenti(0, 4, 20);
        }

        public virtual void Update()
        {
            Produci();
        }

        private void CalcolaBilancio()
        {
            //
        }

        protected bool IsEdificioAttivo()
        {
            //
            return true;
        }

        protected abstract void Produci();
    }
}
