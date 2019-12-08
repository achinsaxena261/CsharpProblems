using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    enum Type
    {
        Clubs = 1,
        Hearts,
        Diamonds,
        Spades
    }
    class CardGame
    {
        Card[] _cards = new Card[52];
        class Card
        {
            public string Name { get; set; }
            public Type Type { get; set; }
            public int Rank { get; set; }
        }

        class CardComparer: IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                return x.Rank.CompareTo(y.Rank);
            }
        }

        public void CreateDeck()
        {
            int j = 0, k = 1;
            var types = typeof(Card).GetProperty("Type").PropertyType.GetEnumValues();
            foreach (var type in types)
            {
                for (int i = 0 + j; i < 13 * k; i++)
                {
                    if (i + 1 == j + 1)
                    {
                        _cards[i] = new Card { Name = "A", Type = (Type)type, Rank = i };
                    }
                    else if (i + 1 == j + 11)
                    {
                        _cards[i] = new Card { Name = "J", Type = (Type)type, Rank = i };
                    }
                    else if (i + 1 == j + 12)
                    {
                        _cards[i] = new Card { Name = "Q", Type = (Type)type, Rank = i };
                    }
                    else if (i + 1 == j + 13)
                    {
                        _cards[i] = new Card { Name = "K", Type = (Type)type, Rank = i };
                    }
                    else
                    {
                        _cards[i] = new Card { Name = (i + 1 - j).ToString(), Type = (Type)type, Rank = i };
                    }
                }
                j = j + 13;
                k++;
            }
        }

        public void ResetDeck()
        {
            Array.Sort(_cards, (Card x, Card y) => x.Rank.CompareTo(y.Rank));
        }

        public void ShuffleCards()
        {
            Random random = new Random(0);
            for(int i = 0; i < 52; i++) 
            {
                int swap = random.Next(52); 
                Card temp = _cards[i];
                _cards[i] = _cards[swap];
                _cards[swap] = temp;
            }
            Console.WriteLine("Shuffle completed");
        }

        public void PrintDeck()
        {
            for (int j = 0; j < 52; j++)
            {
                Console.WriteLine("{0} of {1} : Rank {2}", _cards[j].Name, _cards[j].Type, _cards[j].Rank);
            }
        }
    }
}
