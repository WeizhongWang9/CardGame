using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Game.GameTerms;
using CardGame.Game.GameTerms.Cards;
using CardGame.Lib.Deck;
using CardGame.GameEvents.BasicEffects;

namespace CardGame.Game.GameTerms.Cards.Utility
{
    public class CardSlot 
    {
        protected List<Card> cards;
        public CardSlot()
        {
            cards = new List<Card>();
        }

        public int addCard(Card card)
        {
            cards.Add(card);
            return 1;
        }

        public int removeCard(Card card)
        {
            cards.Remove(card);
            return 1;
        }
    }

    public class Market : DeckWithShowcase<Card>
    {
        void Buy(Player player, Card card)
        {
            EffectList.buyCard.call(player, card);
            showcase.Remove(card);
            drawToShowcase(true, true, false, false);
        }
    }
    
}
