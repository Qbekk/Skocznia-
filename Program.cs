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
            /*
            Console.SetWindowSize(120,55);
            var wut = new Skocznia(12);
            wut.buduj();
            wut.zjazd(4);*/
            Console.ReadKey();
            
        }
    }
}
