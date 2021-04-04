﻿using System;
using BigTycoon.GestioneDipendenti;

namespace BigTycoon.Celle.Edifici
{
	public abstract class Edificio
	{
		protected int Felicita { get; set; }
		protected double Bilancio { get; set; }
		protected double Reddito { get; set; }
		protected int Produzione { get; set; }
		protected double Produttivita { get; set; }
		protected Dipendenti Dipendenti { get; set; }
		protected bool EdificioAttivo { get; set; }
		protected int ColoreFelicita { get; set; }
		protected int ColoreEdificio { get; set; }

		public Edificio()
		{
			Felicita = 50;			//valori di prova
			Bilancio = 0;
			Reddito = 0;
			Produzione = 0;
			Produttivita = 0;
			EdificioAttivo = false;
			ColoreFelicita = 0;
			ColoreEdificio = 0;

			//this.Dipendenti = ;
		}

		public void AumentaStipendi()
        {

        }

		public void DiminuisciStipendi()
		{

		}

		public void AumentaFelicita(int n)
		{

		}

		public void DiminuisciFelicita(int n)
		{

		}

		public virtual void Update()
		{

		}
	}
}