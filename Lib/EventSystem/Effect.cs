using CardGame.Lib.EventSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Lib.EventSystem
{
    public class EventEffectOn<T>
    {
        int EVENT_PRIORITY;
        Trigger<T> trig;
        protected GenericEvent<T> eve;

        public EventEffectOn(GenericEvent<T> Event, Action<T> Effect, int priority)
        {
            EVENT_PRIORITY = priority;
            trig = new Trigger<T>(Effect, priority);
            eve = Event;
            Event.addTrigger(trig);
        }
    }

    public interface IEffect<T>
    {
        void call(T obj);
    }
}
