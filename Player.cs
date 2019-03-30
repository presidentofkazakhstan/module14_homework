using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module14_homework
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> cards;
        public void PrintCards()
        {
            Console.WriteLine($"У игрока {Name} есть:");
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write($"{i + 1} : ");
                cards[i].Print();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public Player(string name)
        {
            Name = name;
            cards = new List<Card>();
        }
        public void AddCard(Card newCard)
        {
            cards.Add(newCard);
        }
        public Card GiveCard(int index)
        {
            Card givingCard = cards[index];
            cards.RemoveAt(index);
            return givingCard;
        }
        public bool HasCards()
        {
            if (cards.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
