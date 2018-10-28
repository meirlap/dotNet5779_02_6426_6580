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

            Console.WriteLine("Wellcome to WAR Card Game!");
            Console.WriteLine("Enter the first player name");
            g.players[0].name = Console.ReadLine();

            Console.WriteLine("Enter the second player name");
            g.players[1].name = Console.ReadLine();
            Console.WriteLine();

            foreach (Player p in g.players)
            {
                p.ToString();
                Console.WriteLine();
            }

            while (!g.isGameOver())
            {
                Console.WriteLine(
@"
Press 1 to view the next move,
Press 0 to run all the moves to the end:");


                int choice = Int32.Parse(Console.ReadLine());
                int step = 1;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(string.Format("STEP #{0}:",step));
                        g.takeAstep();
                        Console.WriteLine(g.players[0].ToString());
                        Console.WriteLine(g.players[1].ToString());
                        step++;
                        break;
                    case 0:
                        while (!g.isGameOver())
                        {
                            Console.WriteLine(string.Format("STEP #{0}:", step));
                            g.takeAstep();
                            Console.WriteLine(g.players[0].ToString());
                            Console.WriteLine(g.players[1].ToString());
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
