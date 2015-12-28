using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wat
{
    //obsługuje konkursy składające się z wielu skoków (na wielu skoczniach)
    public class Turniej
    {
        Skoczek[] zawodnicy;

        public Turniej(Skoczek[] zawodnicy)
        {
            this.zawodnicy =zawodnicy;

        }  

        public Skok[] Rozegraj() //do pojedyńczego konkursu
        {
            Skok[] wyniki;
            Skocznia skocznia;
            int rozmiar;
            Console.WriteLine("Na jakiej skoczni ma się odbyć konkurs? \nPodaj rozmiar w metrach (min 50, wawrtości powyżej 250 ryzykowne)");
            while (!int.TryParse(Console.ReadLine(), out rozmiar))
            {
                Console.WriteLine("To nie była liczba, spróbuj znowu");
            }
            if (rozmiar < 50)
            {
                rozmiar = 50;
                Console.WriteLine("Podałeś rozmiar skoczni poniżej minimum 50m, więc ustawiam go na 50m");
            }
            rozmiar /= 10;

            skocznia = new Skocznia(rozmiar);
            wyniki = new Skok[zawodnicy.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
            {
                skocznia.buduj();
                wyniki[i] = skocznia.zjazd(zawodnicy[i],i+1);
                Console.WriteLine("\nSkok wykonany! Na odległość {0:f1}m i z wynikiem {1:f2} pkt",wyniki[i].odleglosc ,wyniki[i].wynik());
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                Console.ReadKey();
            }

            return wyniki;
        }





    }
}
