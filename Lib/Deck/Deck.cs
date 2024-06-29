using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Lib.Deck
{
    public class Deck<T> : LinkedList<T>
    {
        public bool moveTo(Deck<T> deck, T card, bool isLast)
        {
            if (Remove(card))
            {
                if (isLast) { deck.AddLast(card); } else { deck.AddFirst(card); }
                return true;
            }
            else return false;
        }
        /// <summary>
        /// TBD
        /// </summary>
        /// <returns></returns>
        public Deck<T> shuffle()
        {
            return this;
        }
        public T pass(bool isFromFirst)
        {
            T card;
            if (isFromFirst) { card = this.First(); } else { card = this.Last(); }
            Remove(card);
            return card;
        }
        public List<T> pass(bool isFromFirst, int amount)
        {
            amount = Math.Min(amount, this.Count);
            var passDeck = new List<T>();
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    var card = pass(isFromFirst);
                    passDeck.Add(card);
                }
            }
            passDeck.Reverse();
            return passDeck;
        }
        public List<T> pass(bool isFromFirst, Deck<T> deck, int amount, bool isToFirst)
        {
            amount = Math.Min(amount, this.Count);
            var passDeck = new List<T>();
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    var card = pass(isFromFirst);
                    if (!isToFirst) { deck.AddLast(card); } else { deck.AddFirst(card); }
                    passDeck.Add(card);
                }
            }
            passDeck.Reverse();
            return passDeck;
        }
    }

    public class DeckWithShowcase<T>
    {
        public Deck<T> deck;
        protected Deck<T> showcase;
        public Deck<T> waste;
        public int showcaseCap = -1;
        public DeckWithShowcase(Deck<T> deck, Deck<T> showcase, Deck<T> waste, int showcaseCap)
        {
            this.deck = deck;
            this.showcase = showcase;
            this.waste = waste;
            this.showcaseCap = showcaseCap;
        }
        public DeckWithShowcase(Deck<T> deck, int showcaseCap) : this(deck, new Deck<T>(), new Deck<T>(), showcaseCap) { }
        public DeckWithShowcase(int showcaseCap) : this(new Deck<T>(), showcaseCap) { }
        public DeckWithShowcase() : this(-1) { }
        public Deck<T> drawToShowcase(bool isFromDeckFirst, bool isToShowcaseFirst, bool isFromShowcaseFirst, bool isToWasteFirst)
        {
            deck.pass(isFromDeckFirst, showcase, 1, isToShowcaseFirst);
            if (showcase.Count > showcaseCap && showcaseCap != -1)
            {
                showcase.pass(isFromShowcaseFirst, waste, 1, isToWasteFirst);
            }
            return showcase;
        }

        public void emptyShowcase(bool isFromShowcaseFirst, bool isToWasteFirst)
        {
            showcase.pass(isFromShowcaseFirst, waste, showcase.Count, isToWasteFirst);
        }
        public Deck<T> refillDeckWithWaste()
        {
            deck = waste;
            deck.shuffle();
            waste = new Deck<T>();
            return deck;
        }
    }
}
