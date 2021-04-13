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

		public void AggiungiViaggio (Edificio mittente, Edificio destinatario, Oggetto[] oggetti, int nVagoni)
        {
			ViaggiAttivi.Add(new Viaggio(mittente, destinatario, oggetti, nVagoni, currentIndex));
			currentIndex ++;
		}

		public void RimuoviViaggio(Viaggio viaggio)
		{
			int tempIndex = viaggio.Indice;
			ViaggiAttivi.RemoveAt(tempIndex);

			currentIndex --;
			IndexResetter(tempIndex);
		}

		public void UpdateAll()
        {

        }

		private void IndexResetter(int indice)
        {
			for(int i = indice; i < ViaggiAttivi.Count; i++)
            {
				ViaggiAttivi[i].Indice --;
            }
        }
	}
}
