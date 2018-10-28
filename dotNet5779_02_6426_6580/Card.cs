using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5779_02_6426_6580
{
    public class Card: IComparable<Card>
    {
        public E_Color color { get; set; }

        private int number;
        public int Number {
            get
            {
                return number;
            }
            set
            {
                if (value < 2 || value > 14)
                    throw new Exception("range should be between <2-14> !!");
                number = value;
            }
        }

        public string CardName {
            
            get
            {
                switch(number)
                {
                    case 14:
                        return "Ace";
                    case 13:
                        return "King";
                    case 12:
                        return "Queen";
                    case 11:
                        return "Jack";
                    default:
                        return number.ToString();
                }
                
            }
         }

        //ctor:
        public Card() { }    //default

        public Card(int _number, E_Color _color)
        {
            Number = _number ; color = _color;
        }

        
        public int CompareTo(Card other)
        {
            return number.CompareTo(other.number);
        }

        public override string ToString()
        {
            return String.Format("card color: {0,-6} , value: {1}" , color.ToString(), CardName);
        }

       


    }
}

