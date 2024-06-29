using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using CardGame.Lib.EventSystem;
using CardGame.GameEvents.Events;
using CardGame.Game.GameTerms;
using CardGame.Game.GameTerms.Cards;
using CardGame.GameEvents.Info;
using System.Security.Cryptography.X509Certificates;


namespace CardGame.GameEvents.BasicEffects
{
    public class BasicEffects
    {
        static int GENERAL_PRIORITY = 1000;
        public static Move move = new Move(GENERAL_PRIORITY);
        public static BuyCard buyCard = new BuyCard(GENERAL_PRIORITY);
        public static CardPlayOn<Player> cardPlayOnPlayer = new CardPlayOn<Player>(GENERAL_PRIORITY,CardEvents.CardPlayOnTargetPlayer);
        public static CardPlayOn<Unit> cardPlayOnUnit = new CardPlayOn<Unit>(GENERAL_PRIORITY,CardEvents.CardPlayOnTargetUnit);
        public static CardPlayOn<GameNode> cardPlayOnMap = new CardPlayOn<GameNode>(GENERAL_PRIORITY,CardEvents.CardPlayOnMap);
        public static AddMoney addMoney = new AddMoney(UnitEvents.UnitGetMoney, GENERAL_PRIORITY);
        public static IncreasePlaceUnrest increasePlaceUnrest = new IncreasePlaceUnrest(GameNodeEvents.IncreasePlaceUnrest, GENERAL_PRIORITY);
        public static IncreaseDissWanted increaseDissWanted = new IncreaseDissWanted(DissEvents.IncreaseWanted, GENERAL_PRIORITY);
    }
    public class DissEffect
    {
        static int GENERAL_PRIORITY = 1000;
        public static DissSpreadUnrest dissSpreadUnrest = new DissSpreadUnrest(DissEvents.SpreadUnrest, GENERAL_PRIORITY);
    }
    
 
    public class Move : EventEffectOn<InfoUnitMove>, IEffect<InfoUnitMove>
    {
        protected static void Effect(InfoUnitMove info)
        {
            info.unit.loc = info.loc;
        }
        public Move(int priority) : base(UnitEvents.UnitMove, Effect, priority) { }

        public void call(InfoUnitMove info)
        {
            UnitEvents.UnitMove.call(info);
        }
    }
    public class BuyCard : EventEffectOn<InfoPlayerBuy>
    {
        protected static void Effect(InfoPlayerBuy info)
        {
            var Data = info;
            var player = Data.player;
            var card = Data.card;
            var cardSlot = Data.player.getCardSlot();
            cardSlot.addCard(card);
            player.money -= card.cost;
        }
        public BuyCard(int priority) : base(PlayerEvents.BuyCard, Effect, priority) { }

        public void call(Player player,Card card)
        {
            PlayerEvents.BuyCard.call(new InfoPlayerBuy(player,card));
        }
    }
    public class CardPlayOn<T> : EventEffectOn<InfoCardPlayOnTarget<T>>
    {
        protected static void Effect(InfoCardPlayOnTarget<T> info)
        {
            var Data = info;
            var card = Data.card;
            var player = Data.player;
            var cardEffect = Data.cardEffect;
            var target = Data.target;
            cardEffect.use(target);
        }
        public CardPlayOn(int priority,GenericEvent<InfoCardPlayOnTarget<T>> Event) : base(Event, Effect, priority)
        {
        }

        public void call(Player player,Card card, ICardOn<T> cardEffect,T target)
        {
            eve.call(new InfoCardPlayOnTarget<T>(player, card, cardEffect, target));
        }
    }
    public abstract class ObjectOnEffect<T,U> : EventEffectOn<InfoObjectOn<T,U>>
    {
        protected ObjectOnEffect(GenericEvent<InfoObjectOn<T, U>> Event, Action<InfoObjectOn<T, U>> effect, int priority) : base(Event, effect, priority)
        {
        }

        public void call(T obj, U onWhat)
        {
            eve.call(new InfoObjectOn<T, U>(obj, onWhat));
        }
    }
    public class AddMoney : ObjectOnEffect<Unit, int>
    {
        protected static void Effect(InfoObjectOn<Unit, int> info)
        {
            var Data = info;
            Data.Obj.Owner.money += Data.onObject;
        }

        public AddMoney(GenericEvent<InfoObjectOn<Unit, int>> Event, int priority) : base(Event, Effect, priority)
        {

        }
    }
    public class IncreasePlaceUnrest : EventEffectOn<InfoUnrestIncrease>
    {
        protected static void Effect(InfoUnrestIncrease info)
        {
            var place = info.onObject;
            var unit = info.Obj;
            place.unrest += info.unrestIncrease;

        }
        public IncreasePlaceUnrest(GenericEvent<InfoUnrestIncrease> Event, int priority) : base(Event, Effect, priority)
        {
        }
        public void call(Unit unit, Place loc, int amount)
        { eve.call(new InfoUnrestIncrease(unit, loc, amount)); }
    }
    public class IncreaseDissWanted : ObjectOnEffect<Dissident,int>
    {
        public IncreaseDissWanted(GenericEvent<InfoObjectOn<Dissident, int>> Event, int priority) : base(Event, Effect, priority)
        {
        }

        protected static void Effect(InfoObjectOn<Dissident,int> info)
        {
            var value = info.onObject;
            var unit = info.Obj;
            unit.wanted += value;
        }
    }
    public class DissSpreadUnrest : ObjectOnEffect<Dissident, Place>
    {
        public DissSpreadUnrest(GenericEvent<InfoObjectOn<Dissident, Place>> Event, int priority) : base(Event, Effect, priority)
        {
        }

        protected static void Effect(InfoObjectOn<Dissident,Place> info)
        {
            var unit = info.Obj;
            var place = info.onObject;
            var increaseValue = unit.unrestSpreadSkill;
            BasicEffects.increasePlaceUnrest.call(unit, place, increaseValue);
        }
    }

}