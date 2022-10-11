using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        private string face;
        private string value;
        private int point;


        public Card(string f, string v)
        {
            face = f;
            value = v;

            if (v == "Jack" || f == "Ace")
            {
                point = 1;
            }
            else if (v == "2" && f == "Club")
            {
                point = 2;
            }
            else if (v == "10" && f == "Diamond")
            {
                point = 3;
            }
            else
            {
                point = 0;
            }
        }
        public override string ToString()
        {
            return $"[{face} {value} ({point}p)]";
        }

        public bool isJack()
        {
            return value == "Jack";
        }

        public bool isSimilar(Card card)
        {
            return value == card.value;
        }
    }
}
