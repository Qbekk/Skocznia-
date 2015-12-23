using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace wat
{
    class Program
    {
        static void Main(string[] args)
        {
	
			Console.SetWindowSize(120,55);
            /*
            int rozmiar, gracze, skill;
            string imie;
            Console.WriteLine("Witaj! Podaj rozmiar skoczni!");
            rozmiar = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilość skoczków!");
            gracze = int.Parse(Console.ReadLine());
            Skoczek[] tabela = new Skoczek[gracze];
            for (int i = 0; i< gracze; i ++)
                {
                    Console.WriteLine("Podaj imię skoczka nr {0}",i+1);
                    imie = Console.ReadLine();
                    Console.WriteLine("Podaj poziom umiejętności (między 1, a 10) skoczka nr {0}", i+1);
                    skill = int.Parse(Console.ReadLine());
                    tabela[i] = new Skoczek(imie,skill);
                }
            for (int i = 0; i < gracze; i++)
            {
                Console.WriteLine("Skoczek {0} nazywa się {1} i ma poziom umiejętności {2}",i+1,tabela[i].name, tabela[i].skill);
            }
            */
            int rozmiar,skill;
            string imie;
            Skoczek zawodnik;
            Console.WriteLine("Witaj w symulatorze skoków narciarskich 2016 v2.0!");
            Console.WriteLine("Proszę podaj rozmiar skoczni w metrach (minimum 50, zalecane maximum ok 20)");
            try
            {
                rozmiar = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("To chyba nie była liczba, ustawiam rozmiar na 120m");
                rozmiar = 120;
            }
            rozmiar /= 10;
            if (rozmiar < 5)
            {
                Console.WriteLine("Podałeś rozmiar poniżej 50m, to jest bardzo niebiezpiecznie więc ustawiam go na 50m");
                rozmiar = 5;
            }
            Console.WriteLine("Podaj imię skoczka:");
            while (true)
            {
                imie = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(imie))
                {
                    Console.WriteLine("Nie podałeś imienia, spróbuj znowu");
                }
                else
                    break;
            }
            Console.WriteLine("Oraz jego poziom umiejętności(od 1 do 10, inne wartości będą zmienione na losową liczbę z tego przedziału):");
            while (!int.TryParse(Console.ReadLine(), out skill))
            {
                Console.WriteLine("To nie była liczba, spróbuj znowu");
            }
            if (skill < 1||skill>10)
            {
                Random why = new Random();
                skill =why.Next(1,11);
                Console.WriteLine("Podałeś poziom umiejętności spoza przedziału od 1 do 10, więc wylosowano dla Ciebe wartość {0}",skill);
            }
            Skocznia skocznia = new Skocznia(rozmiar);
            zawodnik = new Skoczek(imie,skill);

            Skok skok;
            Console.WriteLine("Wszystko gotowe, naciśnij dowolny klawisz aby zobaczyć skok!");
            Console.ReadKey();
            Console.Clear();
            skocznia.buduj();
            skok=skocznia.zjazd(zawodnik,1);
            Console.Write("\n Skakał skoczek o imieniu {0}, o poziomie umiejętności {1}",zawodnik.name,zawodnik.skill);
            Console.Write("\n Noty sędziów 1: {0:f1}   2: {1:f1}   3: {2:f1}   4: {3:f1}   5: {4:f1}\n Odleglosc {5:f1} m\n Wynik: {6:f2} punktów",skok.noty[0],skok.noty[1],skok.noty[2],skok.noty[3],skok.noty[4],skok.odleglosc, skok.wynik());
            Console.Write("\n Naciśnij dowolny klawisz aby wyjść");
            Console.ReadKey();
            
        }
    }
}
