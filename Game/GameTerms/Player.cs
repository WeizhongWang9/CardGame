using CardGame.Game.GameTerms.Cards.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms
{
    public class Player
    {
        public string name { get; set; }
        public int money { get; set; }
        public void init(string name)
        {
            this.name = name;
            this.cardSlot = new CardSlot();
        }

        public Player(string name)
        {
            init(name);

        }
        public Player()
        {
            init("Untitled Player");
        }

        protected CardSlot cardSlot;
        public CardSlot getCardSlot() { return cardSlot; }
    }


}
