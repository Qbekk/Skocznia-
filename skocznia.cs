﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace wat
{
	//buduje skocznie oraz odpowiada za zjazd skoczka po niej
	public class Skocznia
	{
		public int speed = 300;
		public int rozmiar;
		public Skocznia(int roz) 
		{
			this.rozmiar=roz;
		}
		public void buduj(){//buduje skocznię
			string spacje = "";
            for (int i = 1; i <= rozmiar; i++)//nabieg
            {
                Console.Write(spacje);
                spacje += " ";
                Console.WriteLine("\\");
            }
			Console.WriteLine(spacje+"\\____/");//płaska część nabiegu
            spacje += "     ";
            for (int i = rozmiar; i <= rozmiar *3; i++)//stok
            {
                Console.Write(spacje);
                spacje += " ";
                Console.WriteLine("\\");
            }
	          Console.WriteLine(spacje+"\\_______________________________/");//koniec!
		}
        public bool ziemia(int x, int y)//pomoga metodzie zjazd dowiedzieć się, czy skoczek już dotknał skoczni
        {
            if (x <= y + 5)//w sumie nie wiem czemu to działa
                return true;
            else
                return false;
        }
        public char avatar(bool zyje)
        {
            Random ran = new Random();
            if (zyje)
                return '@';
            else
            {
                switch (ran.Next(4))
                {
                    case 0:
                        return '>';
                    case 1:
                        return 'V';
                    case 2:
                        return '<';
                    case 3:
                        return 'x';
                    default:
                        return '0';
                        
                }
                
            }
        }
        public void zjazd(int kat)
        {//wykonuje zjazd gdzie spadek podczas lotu występuje co kat kroków
            int x = 0;//poczatkowa pozycja (0,0)
            int y = 0;
            bool zyje = true;
            while (x < rozmiar)
                {//zjazd
                    Thread.Sleep(speed);
                    x++;//w prawo
                    y++;//w dół
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write(avatar(zyje));
                    Console.SetCursorPosition(x, y - 1);
                    Console.Write(" ");
                    speed -= 5;
                    //Console.SetCursorPosition(60, y - 1);//debug
                    //Console.Write(speed);//debug
                }
                Console.SetCursorPosition(1, 28); //debug
                Console.Write("x= {0}, y={1}", x, y); //debug
                x += 2;//dorównanie do prawa
                while (x <= rozmiar + 3)//płaskie przed wybiciem
                {
                    Thread.Sleep(speed);
                    Console.SetCursorPosition(x, y);
                    if (x > rozmiar + 1)
                    {
                        Console.Write(avatar(zyje));
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write("_");
                    }
                    x++;    //w prawo
                }
                x -= 1;// dorównanie w lewo
                Console.SetCursorPosition(1, 29);//debug
                Console.Write("x= {0}, y={1}", x, y);//debug
                bool wybity = false;
                
                while (y > rozmiar - 3)//wybicie
                {
                    Thread.Sleep(speed);
                    if (wybity == false)//łączy z poprzednim
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("_");
                    }
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write(avatar(zyje));
                    if (x != rozmiar + 4)
                    {
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write(" ");
                    }
                    if (y == rozmiar - 1)
                    {
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write('_');
                    }
                    y--;//w górę
                    x++;//w prawo
                    wybity = true;
                }
                
                bool falloff = false;//informuje, czy już był spadek w tym cyklu
                Console.SetCursorPosition(1, 30);//debug
                Console.Write("x= {0}, y={1}", x, y);//debug
                y++;//dorównanie w dół
                
                while (y <= rozmiar * 3 + 2)//spadek pod katem kat
                {
                    if (x == rozmiar + 7)

                    {
                        Console.SetCursorPosition(x - 1, y - 1);
                        Console.Write(" ");

                    }
                    Thread.Sleep(speed);
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write(avatar(zyje));
                    Console.SetCursorPosition(x, y - 1);
                    Console.Write(" ");
                    
                    if (falloff == true && x % kat == kat - 1)
                    {
                        Console.SetCursorPosition(x + 1, y);
                        Console.Write(" ");
                    }
                    if (!ziemia(x, y))
                        speed -= 5;
                    else
                        speed -= 2;
                   
                    x++;//w prawo
                        //Console.SetCursorPosition(60, y - 1);//debug
                        //Console.Write(speed);//debug
                    if (x % kat == 1)//kiedy wyjdziesz poza zasię poprzedniego sprawdzenia cyklu
                        falloff = true;//odznacz wykonanie cyklu
                
                    if (falloff == true && x % kat == 0 && !(ziemia(x, y)))//tu się dzieje grawitacja!!!
                    {//jeżeli jeszcze nie spadł w tym cyklu, i pora żeby spadł, a nie jest na ziemi
                        x -= 1;//to niech spadnie o jeden
                        falloff = false;//i oznaczy cykle jako wykonany
                    }

                    y++;//w dół    
                }//koniec lotu
                
                Console.SetCursorPosition(1, 32);//debug
                Console.Write("x= {0}, y={1}", x, y);//debug
                y--;//dorównanie w górę
                while (x < 3.5 * rozmiar + 5 + 3)//już na płaskim, druga liczba to jak daleko dojedzie
                {
                    Thread.Sleep(speed);
                    Console.SetCursorPosition(x, y);
                    Console.Write(avatar(zyje));
                    Console.SetCursorPosition(x - 1, y);
                    if (x == rozmiar * 3 + 7)
                        Console.Write('\\');
                    else
                        Console.Write('_');
                    x++;//w prawo
                    speed += 10;
                }
            }//zamyka zjazd
        }
}
