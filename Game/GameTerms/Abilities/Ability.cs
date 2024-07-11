using CardGame.Game.GameEvents;
using CardGame.Game.GameTerms.Units;
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
    }

}
