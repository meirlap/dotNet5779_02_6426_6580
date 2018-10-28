using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_6426_6580
{


    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.startGame();

            while (!g.isGameOver())
            {
                Console.WriteLine("\nPress 1 to view the next move,");
                Console.WriteLine("Press 0 to run all the moves to the end:");

                int choice = Int32.Parse(Console.ReadLine());
                int step = 1;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(string.Format("STEP #{0}:",step));
                        g.takeAstep();
                        step++;
                        break;
                    case 0:
                        while (!g.isGameOver())
                        {
                            Console.WriteLine(string.Format("STEP #{0}:", step));
                            g.takeAstep();
                            step++;
                        }                            
                        break;
                    default:
                        Console.WriteLine("incorrect input, choose just 0 or 1");
                        break;
                }               
            }
            Console.WriteLine(string.Format("Congratulations!! {0}", g.checkWin()));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //100
        }
    }
}
