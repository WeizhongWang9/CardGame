using CardGame.Game.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Abilities
{
    public class AbilityPolice : EventSystem
    {
        eventDictionary<Data> data = new eventDictionary<Data>();

        public AbilityPolice(Game game) : base(game)
        {
        }

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
            
        }

        public bool isArrestable(Unit unit)
        {

        }

        public void Arrest(Unit police,Unit arrested)
        {
            
        }


    }
}
