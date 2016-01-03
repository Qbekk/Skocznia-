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
        int[] punktacja = new int[] {100,80,60,50,45,40,36,32,29,26,24,22,20,18,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1 };
        Ranking[] klasyfikacja;
        public Turniej(Skoczek[] zawodnicy)
        {
            this.zawodnicy = zawodnicy;
            klasyfikacja = new Ranking[zawodnicy.Length];
            for (int i = 0; i < klasyfikacja.Length; i++)
            {
                klasyfikacja[i] = new Ranking(zawodnicy[i]);
            }
            
        }

        public class Ranking{//przypisuje liczbę punktów pucharowych do skoczka
            public Skoczek zawodnik;
            public int punkty = 0;
            public int zmiana = 0;
            public Ranking(Skoczek zawodnik)
            {
                this.zawodnik = zawodnik;
                
            }
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
                wyniki[i] = skocznia.zjazd(zawodnicy[i], i + 1);
                Console.WriteLine("\nSkok zawodnika {0} wykonany! Na odległość {1:f1}m i z wynikiem {2:f2} pkt", zawodnicy[i].name, wyniki[i].odleglosc, wyniki[i].Wynik());
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                Console.ReadKey();
            }

            return wyniki;
        }
        public Skok[][] Rozegraj(Skocznia[] skocznie)//dla wielu skoków na wielu skoczniach
        {
            Skok[][] wyniki;
            
            wyniki = new Skok [skocznie.Length][];

            for (int i = 0; i < wyniki.Length; i++)
            {
                wyniki[i] = new Skok[zawodnicy.Length];
            }
            for (int i = 0; i < skocznie.Length; i++)
            {
                
                for (int j = 0; j < zawodnicy.Length; j++)
                {
                    skocznie[i].buduj();
                    wyniki[i][j] =skocznie[i].zjazd(zawodnicy[j],j+1);
                    Console.WriteLine("\nSkok zawodnika {0} wykonany! Na odległość {1:f1}m i z wynikiem {2:f2} pkt",
                                        zawodnicy[j].name ,wyniki[i][j].odleglosc, wyniki[i][j].Wynik());
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
                    Console.ReadKey();
                }
                if (i < skocznie.Length - 1)
                Program.DisplayWyniki(wyniki[i]);
                for (int j = 0; j < klasyfikacja.Length; j++)
                {
                    for (int k = 0; k < Program.Wyniki1.Length; k++)
                    {
                        if (klasyfikacja[j].zawodnik == Program.Wyniki1[k].skoczek)
                        {
                            klasyfikacja[j].punkty+=punktacja[k];
                            klasyfikacja[j].zmiana = punktacja[k];
                            break;
                        }
                    }
                }
                klasyfikacja=klasyfikacja.OrderByDescending(Ranking => Ranking.punkty).ToArray();
                DisplayRanking();
            }
            return wyniki;
        }
        public string Naglowek = "Poz Imię               Pkt  Zmiana";
        public string LiniaRanking(int pozycja, string name, int punkty, int change)
        {
            string poz;
            string imie = name;
            string pkt = punkty.ToString();
            string zmiana = change.ToString();
            zmiana = "+" + zmiana;
            if (pozycja.ToString().Length == 2)
                poz = pozycja.ToString();
            else
                poz = " " + pozycja.ToString();

            while (18 > imie.Length)
            {
                imie += " ";
            }
            while (5 > pkt.Length)
            {
                pkt = " " + pkt;
            }
            while (4 > zmiana.Length)
            { 
                zmiana = " " + zmiana;
            }
            
            return " "+poz+" "+imie+" "+pkt+" "+zmiana;
        }
        public void DisplayRanking()
        {
            Console.WriteLine(Naglowek);
            for(int i=0;i<klasyfikacja.Length;i++)
            {
                Console.WriteLine(LiniaRanking(i+1,klasyfikacja[i].zawodnik.name,klasyfikacja[i].punkty, klasyfikacja[i].zmiana));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
            Console.ReadKey(true);
        }


    }
}
