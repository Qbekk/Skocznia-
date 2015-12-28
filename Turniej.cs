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
                Console.WriteLine("\nSkok zawodnika {0} wykonany! Na odległość {1:f1}m i z wynikiem {2:f2} pkt",zawodnicy[i].name,wyniki[i].odleglosc ,wyniki[i].wynik());
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                Console.ReadKey();
            }

            return wyniki;
        }
        public Skok[,] Rozegraj(Skocznia[] skocznie)
        {
            Skok[,] wyniki;
            wyniki = new Skok [skocznie.Length, zawodnicy.Length];
            for (int i = 0; i < skocznie.Length; i++)
            {
                
                for (int j = 0; j < zawodnicy.Length; j++)
                {
                    skocznie[i].buduj();
                    wyniki[i,j] =skocznie[i].zjazd(zawodnicy[j],j+1);
                    Console.WriteLine("\nSkok zawodnika {0} wykonany! Na odległość {1:f1}m i z wynikiem {2:f2} pkt",zawodnicy[j].name ,wyniki[i,j].odleglosc, wyniki[i,j].wynik());
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                    Console.ReadKey();
                }
                //wyświtl wyniki dla jednej skoczni tutej
                //może osobne rankingi dal całego turnieju?

            }
            return wyniki;
        }




    }
}
