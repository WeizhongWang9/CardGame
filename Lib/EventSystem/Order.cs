using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardGame.Lib.EventSystem.Order
{
    /// <summary>
    /// An order is an effect with a validation. 
    /// </summary>
    public abstract class Order<T, U> where T : IEffect<U>
    {
        protected T effect;
        public abstract bool check(U item, out string errorText);
        public Order(T effect) { this.effect = effect; }
        public bool tryCall(U item, out string errorText)
        {
            if (check(item,out errorText))
            {
                effect.call(item);
                return true;
            }
            return false;
        }
    }
    


}
