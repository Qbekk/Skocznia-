
using System;

namespace wat
{
    //przechowuje dane pojedyńczego skoku
    //doużytku przy wyświetlaniu wyników
	public class Skok
	{
		public int numer,odleglosc,punkty;
		
		
		public Skok(int numer, int odleglosc, int punkty)
		{
			this.numer=numer;
			this.odleglosc=odleglosc;			
			this.punkty=punkty;
		}
	}
}
