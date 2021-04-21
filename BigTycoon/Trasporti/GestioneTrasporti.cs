using System;
using System.Collections.Generic;
using BigTycoon.Celle.Edifici;
using BigTycoon.Oggetti;

namespace BigTycoon.Trasporti
{
	public class GestioneTrasporti
	{
		public List <Viaggio> ViaggiAttivi { get; set; }
		public Edificio MittenteSelezionato { get; set; }
		public Edificio DestinatarioSelezionato { get; set; }

		private int currentIndex;

		public GestioneTrasporti()
		{
			ViaggiAttivi = new List<Viaggio>();
			currentIndex = 0;
		}

		public void AggiungiViaggio (Edificio mittente, Edificio destinatario, Oggetto[] oggetti, int nVagoni, int rigMit, int colMit, int rigDes, int colDes)
        {
			int durata = calcolaDurataViaggio(rigMit, colMit, rigDes, colDes);										//calcola la durata del percorso

			ViaggiAttivi.Add(new Viaggio(mittente, destinatario, oggetti, nVagoni, currentIndex, durata));					//inizializzazione nuovo viaggio

			currentIndex ++;																						//incrementa l'indice corrente nel vettore dei viaggi attivi
		}

		public void RimuoviViaggio(Viaggio viaggio)
		{
			int tempIndex = viaggio.Indice;							//salva temporaneamente la posizione del viaggio da rimuovere
			ViaggiAttivi.RemoveAt(tempIndex);						//rimozione del viaggio dal vettore in posizione tempIndex

			currentIndex --;										//l'indice corrente viene decrementato
			IndexResetter(tempIndex);								//dalla posizione del viaggio rimosso in poi tutti i viaggi decrementano il loro indice
		}

		public void UpdateAll()										//aggiorna la percentuale di completamento di ogni viaggio
        {
            foreach (Viaggio v in ViaggiAttivi)
            {
				v.Update();
                if (v.DurataCorrente >= v.DurataTotale)
                {
					RimuoviViaggio(v);
                }
            }
        }

		//metodi privati

		private void IndexResetter(int indice)
        {
			for(int i = indice; i < ViaggiAttivi.Count; i++)
            {
				ViaggiAttivi[i].Indice --;
            }
        }

		private int calcolaDurataViaggio(int rigMit, int colMit, int rigDes, int colDes)
        {
			int distanza;
			distanza = Math.Abs(rigDes - rigMit);
            if (Math.Abs(colDes - colMit) > distanza)
            {
				distanza = Math.Abs(colDes - colMit);
			}

            switch (distanza)
            {
				case 1:
					return 12;
				case 2:
					return 24;
				case 3:
					return 36;
				default:
					return 48;
                    break;
            }
        }
	}
}
