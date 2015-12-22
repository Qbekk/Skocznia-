
using System;
using System.Collections;
namespace wat
{
    //przechowuje dane pojedyńczego skoku
    //doużytku przy wyświetlaniu wyników
	public class Skok
	{
		public int numer,rozmiar;
		public double odleglosc;
		public Skoczek skoczek;
		public double[] noty;
		public Skok(Skoczek skoczek,int numer, double odleglosc,int rozmiar, double[] noty)
		{
			this.skoczek=skoczek;
			this.numer=numer;
			this.odleglosc=odleglosc;			
			this.noty=noty;
			this.rozmiar=rozmiar;
		}
		public double wynik(){
			double result=0;
			double baza=60;
			double mnoznik;
			if (rozmiar <8)
				mnoznik=2;
			else if(rozmiar<=12)
				mnoznik=1.6;
			else{
				mnoznik=1.2;
				baza=120;
			}
			result=baza-(rozmiar*10-odleglosc)*(mnoznik);
			Array.Sort(noty);
			for (int i=1; i<noty.Length-1;i++)
			{
				result+=noty[i];
				Console.Write("\n nota dodana {0},wynik {1}",noty[i],result);
			}
			return result;
		}
	}
}
