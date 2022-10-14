using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Desk
    {
        private Player[] players;
        private Deck deck;
        private List<Card> place;

        private static readonly Random random = new Random();

        public Desk(int player_count)
        {
            players = new Player[player_count];
            deck = new Deck();
            deck.Mix();
            place = new List<Card>();
            for (int i = 0; i < player_count; i++)
            {
                players[i] = new Player("Player " + i);

            }
            place = deck.giveCard(4);

        }

        private void Deal()
        {
            if (deck.CountCard() > 0)
            {
                foreach (Player p in players)
                {
                    p.Take(deck.giveCard(4));
                }
            }
        }

        private bool CheckRule(Card given)
        {
            if (place.Count > 0)
            {
                Card topCard = place.LastOrDefault();
                if (given.isJack() || given.isSimilar(topCard))
                {
                    return true;
                }
            }
            return false;
        }

        
        private void PlayRound() //Each player plays one card.
        {
            foreach (Player p in players)
            {
                int cardIndexThatwbGiven = random.Next(p.CountCard());
                Card given = p.Play(cardIndexThatwbGiven);

                if (CheckRule(given))
                {
                    //If the rule works (true), the cards on the desk pass to the player, no cards are left on the desk.
                    place.Add(given);
                    p.Collect(place);
                    place.Clear();
                }
                else
                {
                    place.Add(given);
                }

            }
        }
        //First a hand of cards is dealt, then the PlayRound method is run until the players have no cards left.
        public void PlayTrick()
        {
            Player last_player = players.LastOrDefault();
            Deal();
            do
            {
                PlayRound();
            } while (last_player.CountCard() > 0);
        }

        //PlayTrick method is called until there are no cards left.
        public void PlayGame()
        {
            while (deck.CountCard() > 0)
            {
                PlayTrick();
            }

        }
        public override string ToString()
        {
            string players_str = string.Join( "\n", players.ToList());
            string place_str = string.Join( ", ", place);
            return string.Format("Deck ({0}):\nPlayers:\n{2}\n\nPlace: {1}", deck.CountCard(), place_str, players_str);
        }
    }
}
