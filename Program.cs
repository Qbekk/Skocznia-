using System;
namespace wat
{
    public class Program
    {
        static bool Done = false;
        static Skoczek[] zawodnicy;
        static Turniej Zawody;
        static Skok[] Wyniki1;
        public static void Main(string[] args)
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
            
            while (true)
            {
                Console.Clear();
                if (!Done)
                    Menu();
                else
                    break;
            }            
        }
        static void Menu()
        {
           
            Console.WriteLine("Witaj w symulatorze skoków narciarskich 2016 v0.3.3!");
            Console.WriteLine("Wciśnij klawisz w ( ) aby wybrać.");
            Console.WriteLine("(1) Wykonaj pojedyńczy skok");
            Console.WriteLine("(2) Rozegraj konkurs na pojedyńczej skoczni");
            Console.WriteLine("(3) Rozegraj turniej na wielu skoczniach");
            Console.WriteLine("(4) Skonfiguruj listę zawodników do użytku w turnieju lub konkursie");
            if (zawodnicy != null )
                Console.WriteLine("(5) Wyświetl obecnie zapisaną listę zawodników");
            Console.WriteLine("\n\n(0) Wyjdź");
            ConsoleKeyInfo wybor = Console.ReadKey(true);
            if (wybor.KeyChar == '1')
            {
                JedenSkok();

            }
            else if (wybor.KeyChar == '2')
            {
                Wyniki1 = new Skok[zawodnicy.Length];
                Zawody = new Turniej(zawodnicy);
                Wyniki1=Zawody.Rozegraj();
                DisplayWyniki(Wyniki1);
            }
            else if (wybor.KeyChar == '3')
            {

            }
            else if (wybor.KeyChar == '4')
            {
                CfgZawodnicy();
            }
            else if (wybor.KeyChar == '5')
            {
                DisplayZawodnicy();
            }

            else if (wybor.KeyChar == '0')
                Done = true;
                
            
            
            
        }
        public static void JedenSkok()
        {
            int rozmiar, skill;
            string imie;
            Skoczek zawodnik;
            Console.WriteLine("Proszę podaj rozmiar skoczni w metrach (minimum 50, zalecane maximum ok 200)");
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
            if (skill < 1 || skill > 10)
            {
                Random why = new Random();
                skill = why.Next(1, 11);
                Console.WriteLine("Podałeś poziom umiejętności spoza przedziału od 1 do 10, więc wylosowano dla Ciebie wartość {0}", skill);
            }
            Skocznia skocznia = new Skocznia(rozmiar);
            zawodnik = new Skoczek(imie, skill);

            Skok skok;
            Console.WriteLine("Wszystko gotowe, naciśnij dowolny klawisz aby zobaczyć skok!");
            Console.ReadKey();
            Console.Clear();
            skocznia.buduj();
            skok = skocznia.zjazd(zawodnik, 1);
            Console.Write("\n Skakał skoczek o imieniu {0}, o poziomie umiejętności {1}", zawodnik.name, zawodnik.skill);
            Console.Write("\n Noty sędziów 1: {0:f1}   2: {1:f1}   3: {2:f1}   4: {3:f1}   5: {4:f1}\n Odleglosc {5:f1} m\n Wynik: {6:f2} punktów", skok.noty[0], skok.noty[1], skok.noty[2], skok.noty[3], skok.noty[4], skok.odleglosc, skok.wynik());
            Console.Write("\n Siła wybicia = {0} i kąt lotu = {1}", skok.silawybicia, skok.katlotu);//debug
            Console.WriteLine("\n Naciśnij 0 aby wyjść, lub dowolny inny klawisz aby wrócić do menu głównego");

            if (Console.ReadKey().KeyChar == '0')
                Done = true;
            else
                Done = false;


        }
        public static void CfgZawodnicy()
        {
            uint ilosc;
            string imie;
            int skill;


            Console.WriteLine("Ilu będzie zawodników? (min 1, max 30)");
            while (!uint.TryParse(Console.ReadLine(), out ilosc)&&ilosc>0&&ilosc <31)
            {
                Console.WriteLine("To nie była dozwolona liczba, spróbuj znowu");
            }

            zawodnicy = new Skoczek[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                Console.WriteLine("Podaj imię zawodnika ({0} z {1})",i+1,ilosc);
                while (true)
                {
                    imie = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(imie))
                    {
                        Console.WriteLine("Imię nie może być puste, spróbuj ponownie");
                    }
                    else
                        break;
                }
                Console.WriteLine("Podaj poziom umiejętności zawodnika {0}, z zakresu od 1 do 10 włącznie. Wartości z poza zakresu=wartość losowa",imie);
                while (!int.TryParse(Console.ReadLine(), out skill))
                {
                    Console.WriteLine("To nie była liczba, spróbuj znowu");
                }
                if (skill < 1 || skill > 10)
                {
                    Random why = new Random();
                    skill = why.Next(1, 11);
                    Console.WriteLine("Podałeś poziom umiejętności spoza przedziału od 1 do 10, więc wylosowano dla Ciebie wartość {0}", skill);
                }
                zawodnicy[i] = new Skoczek(imie, skill);
                Console.WriteLine("Dodano zawodnika nr {0} o imieniu {1} i poziomie umiejętności {2}",i+1,imie,skill);
            }
            Console.WriteLine("Zakończono konfigurację {0} zawodników! Naciśnij dowolny klawisz aby wrócić do menu",ilosc);
            Console.ReadKey();
        }
        public static void DisplayZawodnicy ()
        {
            Console.WriteLine("Obecnie zapisanych jest {0} zawodników",zawodnicy.Length);
            for (int i=0; i<zawodnicy.Length;i++)
            {
                Console.WriteLine("Zawodnik nr {0} o imieniu {1} i poziomie umiejętności {2}",i+1,zawodnicy[i].name,zawodnicy[i].skill);

            }
            Console.WriteLine("Koniec listy zawodników! Naciśnij dowolny klawisz aby wócić do menu");
            Console.ReadKey();
        }
        public static void DisplayWyniki(Skok[] wyniki)//do wyświetlania wyników konkursu na jednej skoczni
        {
            Console.WriteLine("Wyniki ostatniego konkursu:");
            Console.WriteLine("Numer  Imię  Punkty  Odległość");
            for (int i =0;i<wyniki.Length ;i++)
            {
                Console.WriteLine("{0} {1} {2:f1} {3:f1}m",wyniki[i].numer,wyniki[i].skoczek.name,wyniki[i].wynik(),wyniki[i].odleglosc);
            }
            Console.WriteLine("naciśnij dowolny klawisz aby wrócić do menu");
            Console.ReadKey();
        }


    }
}
