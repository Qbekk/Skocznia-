using System;
using System.Linq;
using System.Collections;
namespace wat
{
    public class Program
    {
        static bool Done = false;
        static Skoczek[] zawodnicy;
        static Turniej Zawody;
        public static Skok[] Wyniki1;
        public static Skok[][] Wyniki2;
        static Skocznia[] skocznie;
        public static void Main(string[] args)
        {
            
			Console.SetWindowSize(120,55);
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
           
            Console.WriteLine("Witaj w symulatorze skoków narciarskich 2016 v0.3.9! Zaprogramowane przez Qbek Studios");
            Console.WriteLine("Wciśnij klawisz w ( ) aby wybrać.");
            Console.WriteLine("(1) Wykonaj pojedyńczy skok");
            Console.WriteLine("(2) Rozegraj konkurs na pojedyńczej skoczni");
            Console.WriteLine("(3) Rozegraj turniej na wielu skoczniach");
            Console.WriteLine("(4) Skonfiguruj listę zawodników do użytku w turnieju lub konkursie");
            Console.WriteLine("(5) Skonfiguruj listę skoczni do użytku w turnieju");
            if (Wyniki1 != null||Wyniki2!=null)
                Console.WriteLine("(6) Wyświetl wyniki ostanich zawodów");
            Console.WriteLine("\n");
            if (zawodnicy != null )
                Console.WriteLine("(7) Wyświetl obecnie zapisaną listę zawodników");
            if (skocznie != null)
                Console.WriteLine("(8) Wyświetl obecnie zapisaną listę skoczni");
            Console.WriteLine("(9) Wykonaj testowy skok o losowych parametrach na losowej skoczni");
            Console.WriteLine("\n\n(0) Wyjdź");
            ConsoleKeyInfo wybor = Console.ReadKey(true);

            switch (wybor.KeyChar)
            {
                case '1':
                    JedenSkok();
                    break;
                case '2':
                    CfgZawodnicy();
                    Wyniki2 = null;
                    Wyniki1= new Skok[zawodnicy.Length];
                    Zawody = new Turniej(zawodnicy);
                    Wyniki1 = Zawody.Rozegraj();
                    DisplayWyniki(Wyniki1);
                    break;
                case '3':
                    CfgZawodnicy();
                    CfgSkocznie();
                    Wyniki1 = null;
                    Wyniki2 = new Skok[skocznie.Length][];
                    for (int i = 0; i < Wyniki2.Length; i++)
                    {
                        Wyniki2[i] = new Skok[zawodnicy.Length];
                    }
                    Zawody = new Turniej(zawodnicy);
                    Wyniki2 = Zawody.Rozegraj(skocznie);
                    
                    DisplayWyniki(Wyniki2);
                    break;
                case '4':
                    CfgZawodnicy();
                    break;
                case '5':
                    CfgSkocznie();
                    break;
                case '6':
                    if (Wyniki2 != null)
                    {
                        Zawody.DisplayRanking();
                        DisplayWyniki(Wyniki2);
                    }
                    else if (Wyniki1 != null)
                        DisplayWyniki(Wyniki1);

                    break;
                case '7':
                    if (zawodnicy != null)
                        DisplayZawodnicy();

                    break;
                case '8':
                    if (skocznie != null)
                        DisplaySkocznie();
                    break;
                case '9':
                    Test();
                    break;
                case '0':
                    Done = true;
                    break;
                default:
                    break;
            }   
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
            Console.Write("\n Noty sędziów 1: {0:f1}   2: {1:f1}   3: {2:f1}   4: {3:f1}   5: {4:f1}\n Odleglosc {5:f1} m\n Wynik: {6:f2} punktów", skok.noty[0], skok.noty[1], skok.noty[2], skok.noty[3], skok.noty[4], skok.odleglosc, skok.Wynik());
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
            bool? nadpisz=null;
            Console.WriteLine("Konfiguracja zawodników");
            if (zawodnicy != null)
            {
                Console.WriteLine("Wykryto listę zawodników w pamięci. Czy chcesz ja nadpisać?(y/n)");
                while (nadpisz == null)
                {
                    ConsoleKeyInfo wybor = Console.ReadKey(true);
                    if (wybor.KeyChar == 'y')
                        nadpisz = true;
                    else if (wybor.KeyChar == 'n')
                        nadpisz = false;
                }
            }
            else
            {
                nadpisz = true;
            }
            if (nadpisz == true)
            {
                Console.WriteLine("Ilu będzie zawodników? (min 1, max 30)");
                while (!uint.TryParse(Console.ReadLine(), out ilosc) && ilosc > 0 && ilosc < 31)
                {
                    Console.WriteLine("To nie była dozwolona liczba, spróbuj znowu");
                }

                zawodnicy = new Skoczek[ilosc];
                for (int i = 0; i < ilosc; i++)
                {
                    Console.WriteLine("Podaj imię zawodnika, nie dłuższe niż 18 znaków ({0} z {1})", i + 1, ilosc);
                    while (true)
                    {
                        imie = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(imie))
                        {
                            Console.WriteLine("Imię nie może być puste, spróbuj ponownie");
                        }
                        else if (imie.Length<1||imie.Length>18)
                            Console.WriteLine("Imię nie może być dłuższe niż 18 znaków, twoje miało {0}, spróbuj ponownie",imie.Length);
                        else
                            break;
                    }
                    Console.WriteLine("Podaj poziom umiejętności zawodnika {0}, z zakresu od 1 do 10 włącznie. Wartości z poza zakresu=wartość losowa", imie);
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
                    Console.WriteLine("Dodano zawodnika nr {0} o imieniu {1} i poziomie umiejętności {2}", i + 1, imie, skill);
                }
                Console.WriteLine("Zakończono konfigurację {0} zawodników! Naciśnij dowolny klawisz.", ilosc);
                Console.ReadKey();
            }
        }
        public static void DisplayZawodnicy ()
        {
            Console.WriteLine("Obecnie zapisanych jest {0} zawodników",zawodnicy.Length);
            for (int i=0; i<zawodnicy.Length;i++)
            {
                Console.WriteLine("Zawodnik nr {0} o imieniu {1} i poziomie umiejętności {2}",i+1,zawodnicy[i].name,zawodnicy[i].skill);

            }
            Console.WriteLine("Koniec listy zawodników! Naciśnij dowolny klawisz aby wrócić do menu");
            Console.ReadKey();
        }
        public static void CfgSkocznie()
        {

            uint ilosc;
            int rozmiar;
            bool? nadpisz = null;
            Console.WriteLine("Konfiguracja skoczni");
            if (skocznie != null)
            {
                Console.WriteLine("Wykryto listę skoczni w pamięci. Czy chcesz ja nadpisać?(y/n)");
                while (nadpisz == null)
                {
                    ConsoleKeyInfo wybor = Console.ReadKey(true);
                    if (wybor.KeyChar == 'y')
                        nadpisz = true;
                    else if (wybor.KeyChar == 'n')
                        nadpisz = false;
                }
            }
            else
            {
                nadpisz = true;
            }
            if (nadpisz==true)
            {
                Console.WriteLine("Ile będzie skoczni? (min 1, max 12)");
                while (!uint.TryParse(Console.ReadLine(), out ilosc) && ilosc > 0 && ilosc < 13)
                {
                    Console.WriteLine("To nie była dozwolona liczba, spróbuj znowu");
                }

                skocznie = new Skocznia[ilosc];
            }
            for (int i = 0; i < skocznie.Length; i++)
            {
                Console.WriteLine("Podaj rozmiar skoczni nr {0} (min 50m, max ok 250m)",i+1);
                while (!int.TryParse(Console.ReadLine(), out rozmiar))
                {
                    Console.WriteLine("To nie była liczba, spróbuj znowu");
                }
                if (rozmiar<50)
                {
                    Console.WriteLine("Podałeś wartość poniżej 50m, przyjmuję rozmiar domyślny = 140m");
                    rozmiar = 140;
                }
                rozmiar /= 10;
                skocznie[i] = new Skocznia(rozmiar);
            }
            Console.WriteLine("konfiguracja skoczni zakończona, naciśnij dowolny klawisz.");
            Console.ReadKey();
        }
        public static void DisplaySkocznie()
        {
            Console.WriteLine("Obecnie zapisanych jest {0} skoczni", skocznie.Length);
            for (int i = 0; i < skocznie.Length; i++)
            {
                Console.WriteLine("Skocznia nr {0} o rozmiarze {1} metrów", i+1, skocznie[i].rozmiar);
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby wrócić do menu.");
            Console.ReadKey();
        }
        public static string Naglowek = "Poz Nr Imię               Pkt   Odl   Noty";
        public static string Linia(int pozycja ,int numer, string name, double punkty, double odleglosc, double[] noty )
        {
            string poz;
            string nr;
            string imie=name;
            string pkt= String.Format("{0:f1}",punkty);
            string odl= String.Format("{0:f1}",odleglosc);
            string not= String.Format("1: {0:f1} 2: {1:f1} 3: {2:f1} 4: {3:f1} 5: {4:f1}", noty[0], noty[1], noty[2], noty[3], noty[4]);
            if (pozycja.ToString().Length == 2)
                poz = pozycja.ToString();
            else
                poz = " "+ pozycja.ToString();
            if (numer.ToString().Length == 2)
                nr = numer.ToString();
            else
                nr = " " + numer.ToString();
            for (int i = 0; i < 18 - name.Length; i++)
                imie += " ";
            for (int i = 0; i < 5-pkt.Length; i++)
                pkt = " "+pkt;
            for (int i = 0; i < 5 - odl.Length; i++)
                odl = " " + odl;
            return " "+poz+" "+nr+" "+imie+" "+pkt+" "+odl+" "+not;
        }

        public static void DisplayWyniki(Skok[] wyniki)//do wyświetlania wyników konkursu na jednej skoczni
        {
            Wyniki1 = wyniki.OrderByDescending(Skok => Skok.wynik).ToArray();

            Console.WriteLine("Wyniki ostatniego konkursu:");
            Console.WriteLine(Naglowek);
            for (int i =0;i< Wyniki1.Length ;i++)
            {
                Console.WriteLine(Linia(i+1, Wyniki1[i].numer, Wyniki1[i].skoczek.name, Wyniki1[i].Wynik(), Wyniki1[i].odleglosc, Wyniki1[i].noty));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować.");
            Console.ReadKey();
        }
        public static void DisplayWyniki(Skok[][] wyniki)//na wielu skoczniach
        {
            Console.WriteLine("Wyniki ostaniego turnieju ({0} skoczni)",wyniki.GetLength(0));
            for (int i = 0; i < wyniki.GetLength(0); i++)
            {
                
                Wyniki2[i] = wyniki[i].OrderByDescending(Skok => Skok.wynik).ToArray();
                Console.WriteLine("Wyniki dla skoczni numer {0}",i+1);
                Console.WriteLine(Naglowek);
                for (int j = 0; j < wyniki[i].Length; j++)
                {
                    Console.WriteLine(Linia(j+1, wyniki[i][j].numer, wyniki[i][j].skoczek.name, wyniki[i][j].Wynik(), wyniki[i][j].odleglosc,wyniki[i][j].noty));
                }


            }
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować");
            Console.ReadKey(true);
            
        }
        public static void Test()
        {
            string imie = "Tester";
            int rozmiar, skill;
            Skoczek zawodnik;
            Skocznia skocznia;
            Skok skok;
            Random zycie = new Random();
            skill = zycie.Next(1, 11);
            rozmiar = zycie.Next(5,23);
            zawodnik = new Skoczek(imie,skill);
            skocznia = new Skocznia(rozmiar);
            skocznia.buduj();
            skok = skocznia.zjazd(zawodnik,1);
            Console.Write("\n Skakał skoczek o imieniu {0}, o poziomie umiejętności {1}", zawodnik.name, zawodnik.skill);
            Console.Write("\n Noty sędziów 1: {0:f1}   2: {1:f1}   3: {2:f1}   4: {3:f1}   5: {4:f1}\n Odleglosc {5:f1} m\n Wynik: {6:f2} punktów", skok.noty[0], skok.noty[1], skok.noty[2], skok.noty[3], skok.noty[4], skok.odleglosc, skok.Wynik());
            Console.Write("\n Rozmiar skoczni {0} m Siła wybicia = {1} i kąt lotu = {2}",skocznia.rozmiar*10 ,skok.silawybicia, skok.katlotu);//debug
            Console.WriteLine("\n Naciśnij dowolny klawisz aby wrócić do menu głównego");
            Console.ReadKey();
        }
    }
}
