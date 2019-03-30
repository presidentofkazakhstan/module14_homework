using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module14_homework
{
    public class Card
    {
        ECardSuit suit;
        ECardCost cost;
        public Card(ECardSuit suit, ECardCost cost)
        {
            this.suit = suit;
            this.cost = cost;
        }
        public void Print()
        {
            Console.Write($"{suit} {cost}");
        }
        public ECardCost GetCost()
        {
            return cost;
        }
    }
}
