using System.Windows.Forms;
using System;


namespace CardGame.Lib.EventSystem
{
    public class Trigger<T>
    {
        int priority;
        bool active;
        Action<T> action;
        public Trigger(Action<T> action, int priority)
        {
            active = true;
            this.action = action;
            this.priority = priority;
        }

        public void SetActive(bool active) { this.active = active; }
        public bool IsActive() { return active; }
        public void Execute(T info) { action.Invoke(info); }
        public int GetPriority() { return priority; }
    }

}