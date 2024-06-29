using CardGame.Game.GameTerms.Cards;
using CardGame.Game.GameTerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameEvents.Info
{
    public class InfoCardPlay
    {
        public Player player;
        public Card card;
        public InfoCardPlay(Player player, Card card)
        {
            this.player = player;
            this.card = card;
        }
    }

    public class InfoCardPlayOnTarget<T> : InfoCardPlay
    {
        public T target;
        public ICardOn<T> cardEffect;
        public InfoCardPlayOnTarget(Player player, Card card, ICardOn<T> cardEffect, T target) : base(player, card)
        {
            this.target = target;
            this.cardEffect = cardEffect;
        }
    }

    public class InfoUnitMove
    {
        public Unit unit;
        public GameNode loc;
        public InfoUnitMove(Unit unit, GameNode loc)
        {
            this.unit = unit;
            this.loc = loc;
        }
    }

    public class InfoPlayerEvent
    {
        public Player player;
        public InfoPlayerEvent(Player player)
        {
            this.player = player;
        }
    }

    public class InfoPlayerBuy : InfoPlayerEvent
    {
        public Card card;
        public InfoPlayerBuy(Player player, Card card) : base(player)
        {
            this.card = card;
        }
    }

    public class InfoObjectEvent<T>
    {
        public T Obj;
        public InfoObjectEvent(T Obj)
        {
            this.Obj = Obj;
        }
    }
    public class InfoObjectOn<T,U> : InfoObjectEvent<T>
    {
        public U onObject;
        public InfoObjectOn(T Obj,U onWhat) : base(Obj)
        {
            onObject = onWhat;
        }
    }

    public class InfoUnrestIncrease : InfoObjectOn<Unit, Place>
    {
        public int unrestIncrease;

        public InfoUnrestIncrease(Unit Obj, Place onWhat, int unrestIncrease) : base(Obj, onWhat)
        {
            this.unrestIncrease = unrestIncrease;
        }
    }

}
