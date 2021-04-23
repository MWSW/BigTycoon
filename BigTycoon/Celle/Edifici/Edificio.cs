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

        //Serve renderlo accessibile all'esterno
        public bool EdificioAttivo { get => IsEdificioAttivo(); protected set => edificioAttivo = value; }
        protected int ColoreEdificio { get; set; }

        public int PuntiFelicita { get => Dipendenti.Felicita; }

        public int PuntiProduzione { get; set; }

        //prezzo per la costruzione dell'edificio
        public int Prezzo { get; protected set; }

        public Edificio(Giocatore gio)
        {//valori di prova
            Possessore = gio;
            Bilancio = 0;
            Reddito = 0;
            Produzione = 0;
            Produttivita = 0;
            EdificioAttivo = false;
            ColoreEdificio = 0;
            PuntiProduzione = 1;
            Dipendenti = new Dipendenti(0, 4, 20);
        }

        public virtual void Update()
        {
            if (!EdificioAttivo)
            {
                Bilancio = 0;
                Dipendenti.Felicita = 0;

                Trace.WriteLine("Edificio non attivo");
                return;
            }

            Produci();
            CalcolaBilancio();

            //applica il bilancio
            Possessore.portafogli.Soldi += Bilancio;
            CalcolaFelicita();
        }

        public abstract void CalcolaBilancio();
        public abstract void AggiungiOggetto(Oggetto ogg);
        public abstract void RimuoviOggetto(Oggetto ogg);
        protected abstract bool IsEdificioAttivo();
        protected abstract void Produci();

        public void CalcolaFelicita()
        {
            int max = 200;
            int min = 0;
            int inc = (max - min) / 10;
            int punti = 0;

            for (int i = min; i <= max; i += inc)
            {
                if (Dipendenti.StipendiPerc >= i && Dipendenti.StipendiPerc < i + inc)
                {
                    if (punti > 10)
                        punti = 10;

                    Dipendenti.Felicita = punti;
                    return;
                }
                punti++;
            }

        }
    }
}
