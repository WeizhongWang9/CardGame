using CardGame.Game.GameEvents;
using CardGame.GameEvents.UnitEvents;
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameTerms
{
    public class UnitHandle : HandleManager<Unit>
    {
        public UnitHandle() : base()
        {
            GameTrigger<UnitCreated> trigOnCreateUnit = new GameTrigger<UnitCreated>(onCreateUnit, -1);
            GameTrigger<UnitRemoved> trigOnRemoveUnit = new GameTrigger<UnitRemoved>(onRemoveUnit, -1);
        }

        void onCreateUnit(UnitCreated e)
        {
            var u = e.getTriggerUnit();
            u.handle = Global.getUnitHandle().assignObjectID(u);
        }

        void onRemoveUnit(UnitRemoved e)
        {
            var u = e.getTriggerUnit();
            Global.getUnitHandle().removeObject(u);
        }

    }
}
