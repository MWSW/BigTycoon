using System;
using BigTycoon.Celle.Magazzino

namespace BigTycoon.Celle.Edifici
{
	public class Industria
	{
		public MagazzinoMateriali SlotMateriali { get; set; }
		private String risorsaTerreno;

		public Industria()
		{
			SlotMateriali = new MagazzinoMateriali();
		}

		private void CreaMateriale()
		{

		}
	}
}
