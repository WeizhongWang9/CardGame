using CardGame.Lib.EventSystem;
using CardGame.GameEvents.BasicEffects;
using CardGame.GameEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameEvents.Info;
using CardGame.Lib.EventSystem.Order;

namespace CardGame.GameEvents.Orders
{
    public class OrderMove : Order<Move, InfoUnitMove>
    {
        static string errorTextPass = "True";
        static string errorTextIsNear = "The location is not a neighborhood.";
        static string errorTextNotOpen = "The place is under lockdown.";

        public OrderMove(Move effect) : base(effect)
        {
            
        }

        public override bool check(InfoUnitMove item, out string errorText)
        {
            var unit = item.unit;
            var toLoc = item.loc;
            var fromLoc = unit.loc;
            if (!fromLoc.IsNear(toLoc))
            {
                errorText = errorTextIsNear;
                return false;
            }
            if(!toLoc.IsOpenTo(unit))
            {
                errorText = errorTextNotOpen;
                return false;
            }
            errorText = errorTextPass;
            effect.call(item);
            return true;
        }
    }
}
