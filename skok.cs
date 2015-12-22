
using System;

namespace wat
{
    //przechowuje dane pojedyńczego skoku
    //doużytku przy wyświetlaniu wyników
	public class Skok
	{
		public int numer,odleglosc;
		public Skoczek skoczek;
		public double[] noty;
		public Skok(Skoczek skoczek,int numer, int odleglosc, double[] noty)
		{
			this.skoczek=skoczek;
			this.numer=numer;
			this.odleglosc=odleglosc;			
			this.noty=noty;
		}
	}
}
