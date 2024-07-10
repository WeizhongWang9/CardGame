using CardGame.Game.GameEvents;
using CardGame.Game.GameTerms.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Game.GameTerms.Units;
namespace CardGame.Game.GameTerms.Abilities
{
    public class AbilityMove : EventSystem
    {

        class Data
        {
            public Attribute attribute;
        }

        eventDictionary<Data> datas = new eventDictionary<Data>();

        public AbilityMove(Game game) : base(game)
        {
        }

        public Attribute getAttribute(Token unit) => datas[unit].attribute;
        public void setData(Token unit, Attribute attribute)
        {
            var dt = new Data();
            dt.attribute = attribute;
            datas.Add(unit,dt);
        }
        public bool recoverMovePoint(Token unit)
        {
            if (datas.TryGetValue(unit, out var data))
            {
                var attribute = data.attribute;
                attribute.movePoint = attribute.movePointRecover;
                return true;
            }
            return false;
        }
        public bool move(Token unit, GameNode gameNode )
        {
            var attribute = getAttribute(unit);
            if (attribute.movePoint > 0)
            {
                attribute.movePoint--;
                gameNode.addUnitOnMap(unit);
                return true;
            }
            return false;

        }
        public class Attribute
        {
            public int movePoint;
            public int movePointRecover;
            public Attribute(int movePoint = 0, int movePointRecover = 0)
            {
                this.movePoint = movePoint;
                this.movePointRecover = movePointRecover;
            }
        }



    }
}
