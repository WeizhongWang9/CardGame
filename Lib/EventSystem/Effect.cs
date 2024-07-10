
using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Lib.EventSystem
{
    public class EventTrigger<T> : Trigger<T>
    {
        public EventTrigger(EventManager eveSys, Action<T> Action, int priority) : base(Action, priority)
        {
            eveSys.addTrigger(this);
        }
    }
}
