using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Lib.EventSystem
{
    public class Event<T>
    {
        readonly SortedDictionary<int,List<Trigger<T>>> EventDic = new SortedDictionary<int, List<Trigger<T>>>();
        public Event(){ }

        public void AddTrigger(Trigger<T> trig)
        {
            var weight = trig.GetPriority();
            if (!EventDic.TryGetValue(weight, out List<Trigger<T>> list))
            {
                list = new List<Trigger<T>>();
                EventDic[weight] = list;
            }
            list.Add(trig);
        }

        public void RemoveTrigger(Trigger<T> trig)
        {
            var weight = trig.GetPriority();
            if (EventDic.TryGetValue(weight, out List<Trigger<T>> list))
            {
                list.Remove(trig);
                if (list.Count == 0)
                {
                    EventDic.Remove(weight);
                }
            }
        }
        public void Call(T info)
        {
            foreach (var ele in EventDic)
            {
                var triggerList = ele.Value;
                foreach(var trigger in triggerList)
                {
                    if (trigger.IsActive()) { trigger.Execute(info); }
                }

            }
        }
    }

    public class GenericEvent<T>
    {
        protected readonly Event<T> Play = new Event<T>();

        protected T _data;
        public T getData() { return _data; }
        public void call(T Data)
        {
            _data = Data;
            Play.Call(Data);
        }

        public void addTrigger(Trigger<T> trig)
        {
            Play.AddTrigger(trig);
        }
        public void removeTrigger(Trigger<T> trig) { Play.RemoveTrigger(trig); }
    }
}
