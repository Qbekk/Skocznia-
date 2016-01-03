
using System;
using System.Collections;
namespace wat
{
    //przechowuje dane pojedyńczego skoku
    //doużytku przy wyświetlaniu wyników
	public class Skok
    {
        
        public int numer,rozmiar, silawybicia, katlotu;
		public double odleglosc, wynik;
		public Skoczek skoczek;
		public double[] noty;
        
		public Skok(Skoczek skoczek,int numer, double odleglosc,int rozmiar, double[] noty,int silawybicia,int katlotu)
		{
			this.skoczek=skoczek;
			this.numer=numer;
			this.odleglosc=odleglosc;			
			this.noty=noty;
			this.rozmiar=rozmiar;
            this.silawybicia = silawybicia;
            this.katlotu = katlotu;
            this.wynik = Wynik();
        }
		public double Wynik(){
			double result=0;
			double mnoznik=1;
            double baza = 60;
            if (rozmiar <8)
				mnoznik=2;
			else if(rozmiar<=12)
				mnoznik=1.6;
			else if(rozmiar<=20)
            {
				mnoznik=1.2;
			}
            else
            {
                baza = 120;
            }
			result=baza-((rozmiar-2)*10-odleglosc)*(mnoznik);
			Array.Sort(noty);
			for (int i=1; i<noty.Length-1;i++)
			{
				result+=noty[i];
			}
            if (result < 0)
                result = 0;
			return result;

		}
        
    }
    
}
