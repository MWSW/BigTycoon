using System.Diagnostics;
using System.Linq;
using BigTycoon.Oggetti;
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
        protected bool EdificioAttivo { get => IsEdificioAttivo(); set => edificioAttivo = value; }
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
            if (!EdificioAttivo)
            {
                Trace.WriteLine("Edificio non attivo");
                return;
            }

            Produci();
            CalcolaBilancio();
            CalcolaFelicita();
        }

        protected abstract void CalcolaBilancio();
        public abstract void AggiungiOggetto(Oggetto ogg);
        protected abstract bool IsEdificioAttivo();
        protected abstract void Produci();

        protected void CalcolaFelicita()
        {
            int max = 200;
            int min = 50;
            int inc = (max - min) / 10;
            int punti = 1;

            for (int i = min; i <= max; i += inc)
            {
                if (Dipendenti.StipendiPerc >= i && Dipendenti.StipendiPerc < i + inc)
                {
                    Dipendenti.Felicita = punti;
                    return;
                }
                punti++;
            }
        }
    }
}
