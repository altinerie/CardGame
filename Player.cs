using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        private string nickName;
        private int points;
        private List<Card> collected;
        private List<Card> trick;

        public Player(string n)
        {
            nickName = n;
            points = 0;
            collected = new List<Card>();
            trick = new List<Card>();
        }

        public void Take(List<Card> cards)
        {
            trick = cards;
        }

        public void Collect(List<Card> atDesk)
        {
            collected.AddRange(atDesk);
        }

        public Card Play(int card_index)
        {
            Card wbPlayed = trick[card_index];
            trick.RemoveAt(card_index);
            return wbPlayed;
        }

        public int CountCard()
        {
            return trick.Count;
        }
        public override string ToString()
        {
            string trick_str = string.Join( ", ", trick);
            string collected_str = string.Join( ", ", collected);

            return string.Format("{0} ({1}p):\nTrick: {2}\nCollected:{3}", nickName, points, trick_str, collected_str);
        }
    }
}
