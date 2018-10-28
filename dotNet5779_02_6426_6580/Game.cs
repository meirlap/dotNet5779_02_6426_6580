using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_6426_6580
{
    public class Game
    {
        private Player[] players = new Player[2];
        private CardStock deck;
 

        public override string ToString()
        {
            return string.Format(@"Player 1: {0,-8}, amount of cards: {2}.
Player 2: {1,-8}, amount of cards: {3}.", players[0].name, players[1].name, players[0].queue.Count, players[1].queue.Count);
        }

        public string checkWin()
        {
            if (players[0].queue.Count == 0) return string.Format("{0} Wins!!",players[1].name);
            if (players[1].queue.Count == 0) return string.Format("{0} Wins!!", players[0].name);
            return null;
        }

        public bool isGameOver()
        {
            return (players[0].queue.Count == 0 || players[1].queue.Count == 0);
        }

        public void startGame()
        {
            deck = new CardStock();
            players[0] = new Player();
            players[1] = new Player();
            deck.distribute(players);

            Console.WriteLine("Wellcome to WAR Card Game!");
            Console.WriteLine("Enter the first player name:");
            players[0].name = Console.ReadLine();

            Console.WriteLine("Enter the second player name:");
            players[1].name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(ToString());
        }

        public void takeAstep()
        {
            if (players[0].queue.Peek().CompareTo(players[1].queue.Peek()) > 0) // 0 bigger
            {
                players[0].queue.Enqueue(players[0].queue.Dequeue());
                players[0].queue.Enqueue(players[1].queue.Dequeue());

                Console.WriteLine(ToString());
                Console.WriteLine();
                return;
            }
            if (players[0].queue.Peek().CompareTo(players[1].queue.Peek()) < 0) // 1 bigger
            {
                players[1].queue.Enqueue(players[1].queue.Dequeue());
                players[1].queue.Enqueue(players[0].queue.Dequeue());

                Console.WriteLine(ToString());
                Console.WriteLine();
                return;
            }

            List<Card> list = new List<Card>();
            while (players[0].queue.Peek().CompareTo(players[1].queue.Peek()) == 0) // equals
            {
                list.Add(players[0].queue.Dequeue());
                list.Add(players[1].queue.Dequeue());
                if (players[0].queue.Peek().CompareTo(players[1].queue.Peek()) > 0) // 0 bigger
                {
                    players[0].queue.Enqueue(players[0].queue.Dequeue());
                    players[0].queue.Enqueue(players[1].queue.Dequeue());
                    for (int i = 0; i < list.Count; i++)
                    {
                        players[0].queue.Enqueue(list[i]);
                    }

                    Console.WriteLine(ToString());
                    Console.WriteLine();
                }
                else
                     if (players[0].queue.Peek().CompareTo(players[1].queue.Peek()) < 0) // 1 bigger
                    {
                      players[1].queue.Enqueue(players[1].queue.Dequeue());
                      players[1].queue.Enqueue(players[0].queue.Dequeue());
                      for (int i = 0; i < list.Count; i++)
                      {
                        players[1].queue.Enqueue(list[i]);
                      }

                    Console.WriteLine(ToString());
                    Console.WriteLine();

                }
                if (isGameOver()) return;
            }
        }

    }
}