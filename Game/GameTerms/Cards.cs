using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace CardGame.Game.GameTerms.Cards
{    
    public class Card : Ownerable
    {
        public int cost { set; get; }
        public bool isPublic;

        public Card(string name, string des, int cost) : base(name, des)
        {
            this.cost = cost;
            this.isPublic = true;
        }
        public Card(string name, string des, int cost, bool isPublic) : base(name, des)
        {
            this.cost = cost;
            this.isPublic = isPublic;
        }
    }
    public interface ICardOn<T>
    {
        int use(T obj);
    }

    public class ObtainMovePoint : Card, ICardOn<Unit>
    {
        int movePoint = 1;
        public int use(Unit unit)
        {
            unit.movePoint += movePoint;
            return 1;
        }

        public ObtainMovePoint(string name, string des, int cost, int movePoint) : base(name, des, cost)
        {
            this.movePoint = movePoint;
        }
    }

    public class BodyPlaceCard : Card
    {
        public BodyPlaceCard(string name, string des, int cost) : base(name, des, cost)
        {
        }
    }

}
