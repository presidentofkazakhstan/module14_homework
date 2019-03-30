using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module14_homework
{
    public class Game
    {
        const int MAX_PLAYERS = 36;
        const int MIN_PLAYERS = 2;
        const int CNT_SUITS = 4;
        const int MIN_COST = 6;
        const int MAX_COST = 14;
        const int CNT_CARDS = (MAX_COST - MIN_COST + 1) * CNT_SUITS;

        List<Card> cardDeck;
        List<Card> tableCardDeck;
        List<Player> players;
        Random random;

        int cntPlayersInt;

        private void Init()
        {
            random = new Random();
            cardDeck = new List<Card>();
            players = new List<Player>();
            tableCardDeck = new List<Card>();
            while (true)
            {
                Console.Write("Введите кол-во игроков(мин.2 макс.36):");
                if (int.TryParse(Console.ReadLine(), out cntPlayersInt))
                {
                    if (cntPlayersInt >= MIN_PLAYERS && MAX_PLAYERS >= cntPlayersInt)
                    {

                        for (int i = 0; i < CNT_SUITS; i++)
                        {
                            for (int j = MIN_COST; j <= MAX_COST; j++)
                            {

                                Card card = new Card((ECardSuit)i, (ECardCost)j);
                                cardDeck.Add(card);
                            }
                        }

                        for (int i = 0; i < cardDeck.Count; i++)
                        {
                            Card temp = cardDeck[0];
                            cardDeck.RemoveAt(0);
                            cardDeck.Insert(random.Next(cardDeck.Count), temp);
                        }


                        for (int i = 0; i < cntPlayersInt; i++)
                        {
                            Console.Write($"Введите имя игрока номер {i + 1}:");
                            players.Add(new Player(Console.ReadLine()));
                        }


                        for (int i = 0; i < cntPlayersInt; i++)
                        {
                            for (int j = 0; j < CNT_CARDS / cntPlayersInt; j++)
                            {
                                players[i].AddCard(cardDeck[0]);
                                cardDeck.RemoveAt(0);
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Слишком мало или слишком много игроков!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                }
            }
        }
        public void Start()
        {
            Init();
            int turn = 0; 
            int pickupPlayer = 0;
            while (true)
            {
                if (players[turn].HasCards())
                {
                    int givingCardIndex;
                    players[turn].PrintCards();
                    Console.WriteLine("Введите индекс карты:");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out givingCardIndex))
                        {

                            if (players[turn].cards.Count > 0)
                            {
                                if (givingCardIndex - 1 < players[turn].cards.Count && givingCardIndex - 1 >= 0)
                                {
                                    tableCardDeck.Add(players[turn].GiveCard(givingCardIndex - 1)); 
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{players[turn].Name} уже проиграл, пропускаем");
                }
                if ((cntPlayersInt - 1) <= turn)
                {
                    pickupPlayer = MaxCard(tableCardDeck);

                    Console.WriteLine(pickupPlayer);
                    Console.WriteLine($"{players[pickupPlayer].Name} забирает карты");
                    for (int i = 0; i < tableCardDeck.Count; i++)
                    {
                        players[pickupPlayer].AddCard(tableCardDeck[i]);
                    }
                    tableCardDeck.Clear();
                    turn = 0;
                }
                else turn++;
                if (players[pickupPlayer].cards.Count == CNT_CARDS) 
                {
                    Console.WriteLine($"Игрок {players[pickupPlayer].Name} выиграл!");
                    break;
                }
            }
        }
        private int MaxCard(List<Card> cards)
        {
            int maxIndex = 0;
            ECardCost maxCost = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].GetCost() > maxCost)
                {
                    maxIndex = i;
                    maxCost = cards[i].GetCost();
                }
            }
            return maxIndex;
        }
    }
}
