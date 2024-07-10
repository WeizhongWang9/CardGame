using CardGame.Game.GameEvents;
using CardGame.Game.GameTerms.Abilities;
using CardGame.GameEvents.UnitEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace CardGame.Game.GameTerms
{
    public class AbilityWanted : EventSystem
    {
        eventDictionary<Data> data = new eventDictionary<Data>();

        public AbilityWanted(Game game) : base(game) { }

        public void setAbility(Unit unit)
        {
            setAbility(unit, new Attribute());
        }
        public void setAbility(Unit unit, Attribute attribute)
        {
            var info = new Data();
            info.attribute = attribute;
            data[unit] = info;
        }

        public bool hasAbility(Unit unit) { return data.ContainsKey(unit); }

        public Attribute getAttribute(Unit unit)
        {
            if (data.TryGetValue(unit, out var dt))
                return dt.attribute;
            return null;
        }
        class Data
        {
            public Attribute attribute;
        }
        public class Attribute
        {
            int wanted;
            public Attribute(int wanted) { this.wanted = wanted; }
            public Attribute() : this(0) { }
        }
    }
}
