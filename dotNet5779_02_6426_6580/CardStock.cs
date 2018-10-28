using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_6426_6580
{
    public class CardStock
    {
        private static Random random = new Random();
        private List<Card> cards;

        public CardStock()
        {
            cards = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                cards.Add(new Card { color = E_Color.BLACK, Number = i + 2 });
                cards.Add(new Card { color = E_Color.RED, Number = i + 2 });
            }

            shuffle();
        }

        public void shuffle()
        {
            for (int i = 0; i < 40; i++)
            {
                int i1 = random.Next(25);
                int i2 = random.Next(25);
                Card tmp = cards[i1];
                cards[i1] = cards[i2];
                cards[i2] = tmp;
            }  
        }

        public override string ToString()
        {
            Console.WriteLine("The stock:");
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine(cards[i].ToString());
            }
            return null;
        }

        public void distribute(params Player[] players)
        {
            int i = 0;
            while(cards.Count != 0)
            {
              foreach (Player p in players)   
              {   
                  if (cards.Count != 0)   
                  {   
                    p.queue.Enqueue(cards[i]);   
                    cards.RemoveAt(i);   
                  }   
              }   
            }  
        }

        public void addCard(Card c)
        {
            cards.Add(c);
        }

        public void removeCard(Card c)
        {
            cards.Remove(c);
        }

        public void sort()
        {
            cards.Sort();
        }

        public Card this[int index]
        {
            get { return cards[index]; }
            set { cards[index] = value; }
        }

    }
}
