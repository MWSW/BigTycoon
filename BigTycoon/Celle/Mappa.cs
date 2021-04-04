﻿using System;
using BigTycoon.Celle.Edifici;
using BigTycoon.Generale;

namespace BigTycoon.Celle
{
    public class Mappa
    {
        public Edificio[,] CelleEdifici { get; set; }
        public String[] CelleMateriali { get; set; }
        public String[] CelleNomi { get; set; }
        public int Dimensione { get; set; }

        public Mappa(String[] celleMateriali, String[] nomiCelle)
        {
            Dimensione = celleMateriali.Length;
            CelleEdifici = new Edificio[Dimensione];
            CelleMateriali = celleMateriali;
            CelleNomi = nomiCelle;
        }

        /// <summary>
        /// Crea un edificio del tipo specificato alla posizione specificata e sottrae soldi.
        /// <para>0: industria, 1: fabbrica, 2: negozio; default: 0</para>
        /// </summary>
        /// <param name="x">Coordinata x</param>
        /// <param name="y">Coordinata y</param>
        /// <param name="tipo">Tipo dell'edificio</param>
        /// <param name="fenoglioIlPortafoglio">Portafoglio del giocatore che crea l'edificio</param>
		public void AggiungiEdificio(int x, int y, int tipo, Portafoglio fenoglioIlPortafoglio)
        {
            Edificio tmp;
            switch (tipo)
            {
                default:
                case 0:
                    tmp = new Industria();
                    break;
                case 1:
                    tmp = new Fabbrica();
                    break;
                case 2:
                    tmp = new Negozio();
                    break;
            }
            CelleEdifici[x , y] = tmp;
        }

        /*public void RimuoviEdificio()
        {

        }*/
    }
}