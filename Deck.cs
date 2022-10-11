using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        private List<Card> cards;

        private static readonly Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            string[] faces = { "Club", "Spade", "Diamond", "Hearts" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", };

            foreach (var face in faces)
            {
                foreach (var value in values)
                {
                    Card card = new Card(face, value);
                    cards.Add(card);
                }
            }
        }

        public void Mix()
        {
            for (int i = 0; i < 50; i++)
            {
                int firstHalfCardAdress = random.Next(26);
                int secondHalfCardAdress = random.Next(26, 52);

                Card empty = cards[firstHalfCardAdress];
                cards[firstHalfCardAdress] = cards[secondHalfCardAdress];
                cards[secondHalfCardAdress] = empty;
            }
        }
        public int CountCard()
        {
            return cards.Count;
        }
        public List<Card> giveCard(int card_count)
        {
            List<Card> wbGiven = cards.Take(card_count).ToList();
            cards.RemoveRange(0, card_count);
            return wbGiven;
        }

        public override string ToString()
        {
            return String.Join(", ", cards);
        }
    }
}
