using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_6426_6580
{
    public class Player
    {
        public string name { get; set; }
        public Queue<Card> queue = new Queue<Card>();

        

        public void addCard(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                queue.Enqueue(c);
            }
        }

        public override string ToString()
        {
            Console.WriteLine("player name: {0}, count of cards: {1}, the cards:", name , queue.Count);
            foreach (Card c in queue)
            {
                Console.WriteLine(c.ToString()); 
            }
            return null;
        }

        public bool lose()
        {
            return (queue.Count == 0);
        }

        public Card pullCard()
        {
            if (!lose())
            {
                return queue.Dequeue();
            }
            return null;
        }

    }
}