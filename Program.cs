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
            var wut = new Skocznia(10);
            wut.buduj();
            wut.zjazd(4);
            Console.ReadKey();
            
        }
    }
}
