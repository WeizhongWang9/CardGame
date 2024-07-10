using CardGame.Game.GameEvents;
using CardGame.GameEvents.UnitEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms.Abilities
{
    public class eventDictionary<TVALUE> : Dictionary<Unit,TVALUE>
    {
        public eventDictionary()
        {
            GameTrigger<UnitRemoved> onRemoved = new GameTrigger<UnitRemoved>(onUnitRemoved, 900);
        }
        
        public void onUnitRemoved(UnitRemoved e)
        {
            Remove(e.getTriggerUnit());
        }
        /*
        public void Add(Unit unit,TVALUE vALUE)
        {
            Add(unit.getHandle(),vALUE);
        }

        public bool TryGetValue(Unit unit, out TVALUE data)
        {
            return TryGetValue(unit.getHandle(), out data);
        }

        public bool ContainsKey(Unit unit)
        {
            return ContainsKey(unit.getHandle());
        }
        */
    }

}
