using CardGame.Game.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Abilities
{
    public class AbilityChaoticMeasure : EventSystem
    {
        public AbilityChaoticMeasure(Game game) : base(game) { }

        eventDictionary<Data> data = new eventDictionary<Data>();

        public void setData(Unit unit)
        {
            setData(unit, new Attribute());
        }
        public void setData(Unit unit, Attribute attribute)
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
            int _property;
            public int property
            {
                get { return _property; }
                set
                {
                    if (value < 0) _property = 0;
                    else if(value > 3) _property = 3;
                    else _property = value;
                }
            }
            public Attribute(int property) { this.property = property; }
            public Attribute() : this(0) { }
        }
    }
}
