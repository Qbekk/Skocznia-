/*
 * Created by SharpDevelop.
 * User: Qba
 * Date: 2015-12-16
 * Time: 09:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

/*
 //            
//            string spacje = "";
//            for (int i = 1; i <= 10; i++)//nabieg
//            {
//                Console.Write(spacje);
//                spacje += " ";
//                Console.WriteLine("\\");
//            
//            }
//
//            
//            Console.WriteLine(spacje+"\\____/");//płaska część nabiegu
//            spacje += "     ";
            int speed = 400;
//            for (int i = 13; i <= 40; i++)//stok
//            {
//                Console.Write(spacje);
//                spacje += " ";
//                Console.WriteLine("\\");
//
//            }
//
//            Console.WriteLine(spacje+"\\_______________________________");//koniec!
//			
            
            
            while (x<10){//zjazd
            	Thread.Sleep(speed);
            
            x++;
            y++;
            Console.SetCursorPosition(x+1, y);
            Console.Write('@');
            Console.SetCursorPosition(x , y-1);
            Console.Write(" ");
            speed -= 25;
            }
            Console.SetCursorPosition(1,28);
				Console.Write("x= {0}, y={1}",x,y);
            while ( x <=14 )//płaskie przed wybiciem
            {
                Thread.Sleep(speed);
                Console.SetCursorPosition(x, y);
                if (x > 11 ) { 
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
            while(y>6)//wybicie
                {
                    Thread.Sleep(speed);

                    Console.SetCursorPosition(x +1, y);
                    Console.Write('@');
                    if(x!=14){
                    Console.SetCursorPosition(x, y +1);
                    Console.Write(" ");
                    
                    }if (y ==10)
                    {
                        Console.SetCursorPosition(x+1, y );
                        Console.Write('_');
                    }
                    
                        
                    y--;
                
                    x++;
            	}
				//int d=18;
				int kat=5;
				//int k=21;
				bool falloff=false;
				Console.SetCursorPosition(1,30);
				Console.Write("x= {0}, y={1}",x,y);
				y++;
               while ( y <= 39)//spadek pod katem kat
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
                    speed -= 15;
                    
                    if (x==18)
                    {
                    Console.SetCursorPosition(x-1,y-1);
                    Console.Write(" ");
                    	
                    }
                    x++;
                    
                    if (falloff==true&&x%kat==0)                
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
                
                
                
                //Console.SetCursorPosition(d,k);
                //Console.Write("\\/");

 
 
 
 */