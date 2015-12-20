/*
 * Created by SharpDevelop.
 * User: Qba
 * Date: 2015-12-16
 * Time: 09:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace wat
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Skocznia
	{
		public int speed = 300;
		public int rozmiar;
		public Skocznia(int roz)
		{
			this.rozmiar=roz;
		}
		public void buduj(){
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
	          Console.WriteLine(spacje+"\\_______________________________");//koniec!
		}
		public void zjazd(int kat){
			int x=0;
			int y=0;
			
			while (x<rozmiar){//zjazd
            	Thread.Sleep(speed);
            
            x++;
            y++;
            Console.SetCursorPosition(x+1, y);
            Console.Write('@');
            Console.SetCursorPosition(x , y-1);
            Console.Write(" ");
            speed -= 5;
            }
            Console.SetCursorPosition(1,28);
				Console.Write("x= {0}, y={1}",x,y);
            while ( x <=rozmiar +4 )//płaskie przed wybiciem
            {
                Thread.Sleep(speed);
                Console.SetCursorPosition(x, y);
                if (x > rozmiar+1 ) { 
                Console.Write('@');
                Console.SetCursorPosition(x-1, y);
                Console.Write("_");
            	
                }
            	x++;	
            }
            
            x-=2;
            //int z = 10;  y
            //int a = 12;  x
            Console.SetCursorPosition(1,29);
				Console.Write("x= {0}, y={1}",x,y);
            while(y>rozmiar - 3)//wybicie
                {
                    Thread.Sleep(speed);

                    Console.SetCursorPosition(x +1, y);
                    Console.Write('@');
                    if(x!=rozmiar +4){
                    Console.SetCursorPosition(x, y +1);
                    Console.Write(" ");
                    
                    }if (y ==rozmiar)
                    {
                        Console.SetCursorPosition(x+1, y );
                        Console.Write('_');
                    }
                    
                        
                    y--;
                
                    x++;
            	}
				//int d=18;
				//int kat=5;
				//int k=21;
				bool falloff=false;
				Console.SetCursorPosition(1,30);
				Console.Write("x= {0}, y={1}",x,y);
				y++;
               while ( y <= rozmiar *3+2)//spadek pod katem kat
                {
                    Thread.Sleep(100);
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write('@');
                    Console.SetCursorPosition(x, y - 1);
                    Console.Write(" ");
                    
                    if(falloff==true&&x%kat==kat-1)
                    {
                    Console.SetCursorPosition(x+1, y );
                    Console.Write(" ");	
                    }
                    if (!ziemia(x, y))
                        speed -= 5;
                    else
                        speed -= 2;
                    if (x==rozmiar+7)
                    {
                    Console.SetCursorPosition(x-1,y-1);
                    Console.Write(" ");
                    	
                    }
                    x++;
                    Console.SetCursorPosition(60, y - 1);
                    Console.Write(speed);
                    if (falloff==true&&x%kat==0&&!(ziemia(x,y)))                
                    	{
                    		x-=1;
                    		falloff=false;
                    	}
                    	if(x%kat==1)
                    		falloff=true;
        			y++;
                    
                }
                Console.SetCursorPosition(1,32);
				Console.Write("x= {0}, y={1}",x,y);
                y--;
                while(x<3.5*rozmiar+5+10)
                {
                    Thread.Sleep(speed);
                    Console.SetCursorPosition(x, y);
                    Console.Write('@');
                    Console.SetCursorPosition(x-1, y);
                    if (x == rozmiar * 3+7 )
                        Console.Write('\\');
                    else
                        Console.Write('_');
                    x++;
                    speed += 10;
                }
                
			
			
			
		}
        public bool ziemia(int x, int y)
        {
            if (x <= y+5 )
                return true;
            else
                return false;
        }
        	
	
	
	
	
	}
}
