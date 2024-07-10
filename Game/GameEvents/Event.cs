using CardGame.Game.GameTerms;
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Game.GameEvents
{
    public abstract class Event
    {
        protected UnitHandle UnitHandles => Global.getGame().unitHandle;
    }

    public class GameTrigger<T> : EventTrigger<T>
    {
        public GameTrigger(Action<T> Action, int priority) : base(Global.getEventManager(),Action, priority)
        {
        }
    }
}

